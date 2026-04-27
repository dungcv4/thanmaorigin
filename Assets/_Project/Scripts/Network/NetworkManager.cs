// File: Assets/_Project/Scripts/Network/NetworkManager.cs
// Singleton wrapping TMSKSocket + dispatch inbound packets to CmdRegistry on main thread.

using UnityEngine;

namespace ThanMaOrigin.Network
{
    public class NetworkManager : MonoBehaviour
    {
        public static NetworkManager Instance { get; private set; } = null!;

        // World/Game server endpoints (used by TMSKSocket post-handshake).
        // DEVIATION: redirect to thanmaorigin LocalServer (GameServer_NET8/AppConfig.xml port 3001).
        public string ServerHost = "127.0.0.1";
        public int ServerPort = 3001;

        // Gateway endpoints — separate process (Python emulator at alo/gateway_server/).
        // gốc Script_ClientDef.lua:5-9 had 61.28.227.* gateway IPs. We redirect to the
        // Python gateway emulator that we control. Override in inspector or via
        // ConnectGateway() args (Lua passes ip/port from Login:GetGatewayAddr()).
        public string GatewayHostDefault = "127.0.0.1";
        public int GatewayPortDefault = 3000;

        private TMSKSocket _sock = new TMSKSocket();

        public bool Connected => _sock.Connected;

        void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Wire CmdRegistry → outbound socket
            CmdRegistry.OnSendCmd += OnSendCmd;
        }

        public bool Connect()
        {
            return _sock.Connect(ServerHost, ServerPort);
        }

        // VMA: 0x418c00 — Source: KTO_LibClientScene_Decompiled/plt_imports.txt
        //   _ZN14XGatewayClient12ConnectOuterEPKciS1_S1_  (XGatewayClient::ConnectOuter)
        // gốc body: connect TCP to (ip, port), send login packet with (account, auth).
        // Called by libclient_scene.so:0x236adc LuaConnectGateway after extracting 4 Lua args.
        // 1-1 PORT: connect socket + queue login CMD with credentials.
        public bool ConnectGateway(string ip, int port, string account, string authInfo)
        {
            // Day 9.14 (2026-04-27): split gateway from world server.
            //   gốc 3-tier architecture: Client → Gateway → World → Game.
            //   We have GameServer:3001 only — Python gateway emulator (alo/gateway_server/)
            //   stands in for Tencent Gateway tier on port 3000.
            //   gốc native XGatewayClient::ConnectOuter @0x418c00 (libclient_scene.so) is
            //   replaced by GatewayHandshake.SendRequest which speaks our Python gateway protocol.
            // ip/port comes from Login:GetGatewayAddr() in Lua. In dev mode the Lua server list
            //   may give the same IP as world server — we redirect to gateway port unless caller
            //   explicitly overrides.
            string gwHost = string.IsNullOrEmpty(ip) ? GatewayHostDefault : ip;
            int gwPort = port > 0 ? port : GatewayPortDefault;
            // If Lua passed port matching world server (3001), assume it didn't know about
            // the dev gateway split and redirect to our gateway port.
            if (gwPort == 3001) gwPort = GatewayPortDefault;

            UnityEngine.Debug.Log($"[NetworkManager.ConnectGateway] gateway={gwHost}:{gwPort} account={account}");

            _pendingAccount = account ?? "";
            _pendingAuth = authInfo ?? "";

            // Fire emNOTIFY_GATEWAY_CONNECT(1) immediately — gốc semantic for "TCP attempt
            // initiated successfully". Real handshake result will fire as emNOTIFY_GATEWAY_HANDED.
            // If GatewayHandshake.SendRequest can't even open TCP, IT will fire HANDED with
            // an error code so the user sees a clear UIMessageBoxBig instead of a hang.
            // Source: gốc Lua tbWnd:GatewayConnectResult(nResult) (UILoginChannelInner.lua:163-173).
            ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName("emNOTIFY_GATEWAY_CONNECT", 1);

            bool ok = ThanMaOrigin.Network.GatewayHandshake.SendRequest(
                gwHost, gwPort, _pendingAccount, _pendingAuth);
            return ok;
        }

        // Stash credentials for the login handshake; Lua-side flow sends CMD_LOGIN
        // via Operation:LoginRole / Sdk:Login after Login.lua receives gateway accept.
        public string _pendingAccount;
        public string _pendingAuth;

        // VMA: 0x4191d0 — Source: KTO_LibClientScene_Decompiled (called from
        //   LuaConnectWorldServer @ 0x236b68). gốc body:
        //   Network::ConnectWorldServer(this, addr, port)
        //     → close current socket if any, open new TCP to (addr, port)
        // Called by Login.lua:413 after gateway responds with world server endpoint.
        // 1-1 PORT: re-target socket to the new addr+port.
        public bool ConnectWorldServer(string addr, int port)
        {
            ServerHost = string.IsNullOrEmpty(addr) ? "127.0.0.1" : addr;
            ServerPort = port > 0 ? port : 3001;
            UnityEngine.Debug.Log($"[NetworkManager.ConnectWorldServer] {ServerHost}:{ServerPort}");
            if (_sock.Connected)
            {
                _sock.Close();
            }
            bool ok = _sock.Connect(ServerHost, ServerPort);
            if (ok)
            {
                // Right after TCP connect, send CMD_LOGIN_ON. gốc native
                // XWorldClient::DoHandshakeRequest @0x282e6c (XOR-encrypted, can't 1-1 port)
                // does this automatically inside the socket-connect callback.
                // We mirror that behavior in C# using LoginTokenHelper.
                // CMD_LOGIN_ON = 100 (TCPGameServerCmds.CMD_LOGIN_ON in server enum).
                try
                {
                    byte[] payload = LoginTokenHelper.BuildLoginOnPayload(_pendingAccount);
                    _sock.Send(100, payload);
                    UnityEngine.Debug.Log($"[NetworkManager.ConnectWorldServer] → CMD_LOGIN_ON sent ({payload.Length} bytes) for account='{_pendingAccount}'");

                    // Fire emNOTIFY_LOGIN_HAND_SHAKE_END(0) so Lua's UILoginServer
                    // OnHandShakeEnd handler closes UILoadingTips on success path.
                    // gốc fires this from native XWorldClient::OnHandShakeRespond once
                    // server replies. We fire optimistically; if server rejects login,
                    // CMD_LOGIN_ON reply handler (CmdRegistry CMD 100) will fire
                    // appropriate error event.
                    ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                        "emNOTIFY_LOGIN_HAND_SHAKE_END", 0);
                }
                catch (System.Exception e)
                {
                    UnityEngine.Debug.LogError($"[NetworkManager.ConnectWorldServer] CMD_LOGIN_ON build/send FAIL: {e.Message}");
                    // Fire HAND_SHAKE_END with non-zero so Lua opens UIMessageBoxBig.
                    ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                        "emNOTIFY_LOGIN_HAND_SHAKE_END", 1);
                }
            }
            return ok;
        }

        // Connect-retry timeout in seconds (default 100, set by Login.lua:414).
        public int WorldServerConnectTimeout = 100;

        // VMA: 0x4191e0 — Source: KTO_LibClientScene_Decompiled (called from
        //   LuaSetWorldServerConnectTimeout @ 0x236bc4). gốc body:
        //   Network::SetWorldServerConnectTimeout(this, timeout)
        //     → store retry budget on Network instance
        // Called by Login.lua:414 SetWorldServerConnectTimeout(100).
        // 1-1 PORT: store timeout for next reconnect attempt.
        public void SetWorldServerConnectTimeout(int timeoutSec)
        {
            WorldServerConnectTimeout = timeoutSec > 0 ? timeoutSec : 100;
            UnityEngine.Debug.Log($"[NetworkManager.SetWorldServerConnectTimeout] {WorldServerConnectTimeout}s");
        }

        void OnSendCmd(int cmdId, byte[] payload)
        {
            _sock.Send(cmdId, payload);
        }

        void Update()
        {
            // Dispatch inbound packets on main thread
            while (_sock.InboundQueue.TryDequeue(out var pkt))
            {
                CmdRegistry.OnPacketReceived(pkt.opcode, pkt.payload);
            }
            // Drain Gateway socket inbound + fire Lua events on main thread
            ThanMaOrigin.Network.GatewayHandshake.Tick();
        }

        void OnDestroy()
        {
            CmdRegistry.OnSendCmd -= OnSendCmd;
            ThanMaOrigin.Network.GatewayHandshake.Close();
            _sock.Close();
            if (Instance == this) Instance = null!;
        }
    }
}
