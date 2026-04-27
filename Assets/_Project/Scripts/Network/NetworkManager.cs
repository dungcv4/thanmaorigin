// File: Assets/_Project/Scripts/Network/NetworkManager.cs
// Singleton wrapping TMSKSocket + dispatch inbound packets to CmdRegistry on main thread.

using UnityEngine;

namespace ThanMaOrigin.Network
{
    public class NetworkManager : MonoBehaviour
    {
        public static NetworkManager Instance { get; private set; } = null!;

        // Gateway endpoints (gốc Script_ClientDef.lua:5-9 had 61.28.227.* IPs).
        // DEVIATION: redirect to thanmaorigin LocalServer (GameServer_NET8/AppConfig.xml port 3001).
        public string ServerHost = "127.0.0.1";
        public int ServerPort = 3001;

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
            ServerHost = string.IsNullOrEmpty(ip) ? "127.0.0.1" : ip;
            // Port 3001 — Source: memory [KTO full pipeline] (verified 2026-04-17)
            //   Client → GameServer:3001 → GameDBServer:23001 → MySQL AWS
            // GameServer reads port from CLI XML attribute Socket.port at Program.cs:1595.
            // Default 3001 used when Lua doesn't supply explicit port (dev mode).
            // Confirmed by user 2026-04-27: "3001 nhé".
            ServerPort = port > 0 ? port : 3001;
            UnityEngine.Debug.Log($"[NetworkManager.ConnectGateway] {ServerHost}:{ServerPort} account={account}");
            bool ok = _sock.Connect(ServerHost, ServerPort);
            if (ok)
            {
                // Send login CMD with account+auth. CMD ID matches gốc protocol.
                // Per memory `reference_kto_full_pipeline`: CMD_LOGIN id resolves at server bridge.
                // For now, store credentials; CMD send happens via Lua after Login response.
                _pendingAccount = account;
                _pendingAuth = authInfo;
            }
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
            return _sock.Connect(ServerHost, ServerPort);
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
        }

        void OnDestroy()
        {
            CmdRegistry.OnSendCmd -= OnSendCmd;
            _sock.Close();
            if (Instance == this) Instance = null!;
        }
    }
}
