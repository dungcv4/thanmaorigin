// File: Assets/_Project/Scripts/Network/GatewayHandshake.cs
//
// State machine for the Gateway connection lifecycle.
// Replaces the gốc native XGatewayClient (libclient_scene.so) which has
// XOR-encrypted response parsers (cannot be statically decoded).
//
// Drives the Lua login flow by firing these EventNotify events:
//   emNOTIFY_GATEWAY_CONNECT (=1)        — TCP connect result
//   emNOTIFY_GATEWAY_HANDED  (=50)       — handshake response
//   emNOTIFY_UPDATE_SERVER_LIST          — after server list arrives
// These match gốc Script_EventSystem_EventNotify.lua and feed
// Script_Ui_Window_UILoginChannelInner.lua handlers 1-1.
//
// Architecture:
//   - One MonoBehaviour ticked from NetworkManager.Update() drains
//     GatewaySocket.InboundQueue on the main thread.
//   - SendRequest(account, authInfo) does TCP connect + handshake send.
//   - On RSP_HANDSHAKE: fires emNOTIFY_GATEWAY_HANDED(retCode, nShowAgreement).
//   - On RSP_ERROR or any failure: fires HANDED with non-zero code so Lua
//     opens UIMessageBoxBig with a clear error (never silent).

using System;
using UnityEngine;

namespace ThanMaOrigin.Network
{
    public static class GatewayHandshake
    {
        private static GatewaySocket? _sock;

        // Cached for re-send if needed (e.g. retry).
        public static string LastAccount = "";
        public static string LastAuthInfo = "";

        public static GatewaySocket? CurrentSocket => _sock;

        /// <summary>
        /// Open new gateway connection + send handshake. Returns true if TCP connect ok
        /// (handshake response is delivered async via Tick).
        /// </summary>
        public static bool SendRequest(string ip, int port, string account, string authInfo)
        {
            // Tear down any previous socket
            if (_sock != null)
            {
                _sock.Close();
                _sock = null;
            }

            LastAccount = account ?? "";
            LastAuthInfo = authInfo ?? "";

            _sock = new GatewaySocket();
            bool connected = _sock.Connect(ip, port);
            if (!connected)
            {
                Debug.LogError($"[GatewayHandshake] TCP connect failed: {_sock.LastError}");
                // Fire HANDED with explicit error so Lua opens UIMessageBoxBig.
                // gốc convention: nRetCode != 0 → fail branch in
                //   tbWnd:GatewayHandSuccess (UILoginChannelInner.lua:177).
                //   nRetCode 5000 = "GatewayRetCode 5000" — clear that gateway connect itself failed.
                ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                    "emNOTIFY_GATEWAY_HANDED", 5000, 0);
                _sock = null;
                return false;
            }

            byte[] pkt = GatewayProtocol.BuildHandshakeRequest(LastAccount);
            Debug.Log($"[GatewayHandshake] → handshake packet {pkt.Length} bytes account='{LastAccount}'");
            _sock.SendRaw(pkt);
            return true;
        }

        /// <summary>
        /// Send REQ_GET_SERVER_LIST after handshake success.
        /// Called from UILoginServer.lua's RequestServerList() (via KGlobalLua binding).
        /// </summary>
        public static void RequestServerList()
        {
            if (_sock == null || !_sock.Connected)
            {
                Debug.LogError("[GatewayHandshake] RequestServerList: gateway socket not open");
                ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName("emNOTIFY_UPDATE_SERVER_LIST", 0);
                return;
            }
            _sock.SendRaw(GatewayProtocol.BuildGetServerListRequest());
            Debug.Log("[GatewayHandshake] → REQ_GET_SERVER_LIST");
        }

        /// <summary>
        /// Send REQ_LOGIN_SERVER (user picked a server). Reply contains world server addr+port.
        /// </summary>
        public static void RequestLoginServer(int serverId)
        {
            if (_sock == null || !_sock.Connected)
            {
                Debug.LogError("[GatewayHandshake] RequestLoginServer: gateway socket not open");
                return;
            }
            _sock.SendRaw(GatewayProtocol.BuildLoginServerRequest(serverId));
            Debug.Log($"[GatewayHandshake] → REQ_LOGIN_SERVER serverId={serverId}");
        }

        // Server list cache (filled when RSP_GET_SERVER_LIST arrives).
        public static GatewayProtocol.GatewayServerEntry[]? CachedServerList { get; private set; }

        // Last login-server reply (world server addr+port).
        public static string? LastWorldAddr { get; private set; }
        public static int LastWorldPort { get; private set; }

        /// <summary>
        /// Drain inbound responses on the main thread + fire Lua events.
        /// Called once per frame from NetworkManager.Update().
        /// </summary>
        public static void Tick()
        {
            if (_sock == null) return;

            while (_sock.InboundQueue.TryDequeue(out var msg))
            {
                try
                {
                    DispatchResponse(msg.opcode, msg.payload);
                }
                catch (Exception e)
                {
                    Debug.LogError($"[GatewayHandshake] dispatch error opcode 0x{msg.opcode:X2}: {e.Message}");
                    ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                        "emNOTIFY_GATEWAY_HANDED", 5001, 0);
                }
            }

            // Surface any background-thread error.
            if (!string.IsNullOrEmpty(_sock.LastError) && !_sock.Connected)
            {
                Debug.LogError($"[GatewayHandshake] socket failed: {_sock.LastError}");
                ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                    "emNOTIFY_GATEWAY_HANDED", 5002, 0);
                _sock.LastError = "";  // don't refire
                _sock.Close();
                _sock = null;
            }
        }

        private static void DispatchResponse(byte opcode, byte[] payload)
        {
            switch (opcode)
            {
                case GatewayProtocol.RSP_HANDSHAKE:
                {
                    var (retCode, nShowAgreement) = GatewayProtocol.ParseHandshakeResponse(payload);
                    Debug.Log($"[GatewayHandshake] ← RSP_HANDSHAKE ret={retCode} nShowAgreement={nShowAgreement}");
                    // gốc Lua tbWnd:GatewayHandSuccess(nRetCode, nShowAgreement) consumes both ints.
                    ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                        "emNOTIFY_GATEWAY_HANDED", retCode, nShowAgreement);

                    // BACKUP path: directly run GatewayHandSuccess on UILoginChannelInner singleton.
                    // The EventNotify subscriber chain is fragile (Repeat Regist warnings on UI
                    // re-instantiation can leave subscriber list empty per probe at 21:00). Calling
                    // the handler directly via Ui.tbClass lookup guarantees UILoginServer opens
                    // even when subscriber wasn't registered at fire time.
                    // gốc behavior: handler runs once. Calling twice = no-op since handler is
                    // idempotent (CloseWindow + OpenWindow are guarded).
                    if (retCode == 0)
                    {
                        var env = ThanMaOrigin.Lua.LuaEngine.Instance?.Env;
                        if (env != null)
                        {
                            try
                            {
                                env.DoString($@"
                                    local tbWnd = Ui.tbClass and Ui.tbClass.UILoginChannelInner
                                    if tbWnd and tbWnd.GatewayHandSuccess then
                                        local ok, err = xpcall(function()
                                            tbWnd:GatewayHandSuccess({retCode}, {nShowAgreement})
                                        end, debug.traceback)
                                        if not ok then print('[GatewayHandshake direct call] FAIL: '..tostring(err)) end
                                    else
                                        print('[GatewayHandshake direct call] UILoginChannelInner singleton not found — skipping')
                                    end
                                ", "GatewayDirectHandSuccess");
                            }
                            catch (System.Exception e)
                            {
                                Debug.LogError($"[GatewayHandshake] direct GatewayHandSuccess call failed: {e.Message}");
                            }
                        }
                    }
                    break;
                }
                case GatewayProtocol.RSP_GET_SERVER_LIST:
                {
                    CachedServerList = GatewayProtocol.ParseServerListResponse(payload);
                    Debug.Log($"[GatewayHandshake] ← RSP_GET_SERVER_LIST count={CachedServerList.Length}");
                    foreach (var s in CachedServerList)
                        Debug.Log($"  [{s.ServerId}] '{s.Name}' {s.Addr}:{s.Port} status={s.Status}");
                    // Lua UILoginServer subscribes emNOTIFY_UPDATE_SERVER_LIST → handler
                    // tbWnd:OnSyncServerListDone(nCode) treats nCode==1 as success
                    // (UILoginServer.lua:310-311). Calls __UpdateSerInfo() → GetServerList().
                    int nCode = CachedServerList.Length > 0 ? 1 : 0;
                    ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                        "emNOTIFY_UPDATE_SERVER_LIST", nCode);
                    break;
                }
                case GatewayProtocol.RSP_LOGIN_SERVER:
                {
                    var (addr, port) = GatewayProtocol.ParseLoginServerResponse(payload);
                    LastWorldAddr = addr;
                    LastWorldPort = port;
                    Debug.Log($"[GatewayHandshake] ← RSP_LOGIN_SERVER addr={addr}:{port}");
                    // Drive Lua: Login:LoginServerRsp(addr, port) → calls native ConnectWorldServer(addr, port).
                    // Our LuaGameStubs/KGlobalLua will route ConnectWorldServer back to
                    // NetworkManager.ConnectWorldServer which uses TMSKSocket on GameServer:3001.
                    var env = ThanMaOrigin.Lua.LuaEngine.Instance?.Env;
                    if (env != null)
                    {
                        try
                        {
                            env.DoString(
                                $"if Login and Login.LoginServerRsp then Login:LoginServerRsp('{addr.Replace("'", "\\'")}', {port}) end",
                                "GatewayHandshake_LoginServerRsp");
                        }
                        catch (Exception e)
                        {
                            Debug.LogError($"[GatewayHandshake] Login:LoginServerRsp call failed: {e.Message}");
                        }
                    }
                    break;
                }
                case GatewayProtocol.RSP_ERROR:
                {
                    var (errorCode, message) = GatewayProtocol.ParseErrorResponse(payload);
                    Debug.LogError($"[GatewayHandshake] ← RSP_ERROR code={errorCode} msg='{message}'");
                    // Surface as HANDED failure with the error code so Lua's
                    // GatewayHandSuccess opens UIMessageBoxBig(GatewayRetCode N).
                    ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                        "emNOTIFY_GATEWAY_HANDED", errorCode > 0 ? errorCode : 5003, 0);
                    break;
                }
                default:
                    Debug.LogWarning($"[GatewayHandshake] unhandled response opcode 0x{opcode:X2} len={payload.Length}");
                    break;
            }
        }

        /// <summary>
        /// Close the gateway connection (e.g. before transitioning to world server).
        /// </summary>
        public static void Close()
        {
            if (_sock != null)
            {
                _sock.Close();
                _sock = null;
                Debug.Log("[GatewayHandshake] socket closed");
            }
        }
    }
}
