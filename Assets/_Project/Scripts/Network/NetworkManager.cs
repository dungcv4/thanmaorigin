// File: Assets/_Project/Scripts/Network/NetworkManager.cs
// Singleton wrapping TMSKSocket + dispatch inbound packets to CmdRegistry on main thread.

using System;
using System.Collections.Generic;
using System.Text;
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
        public int CurrentServerId { get; private set; } = 1;
        public int CurrentZoneId => CurrentServerId;
        public string CurrentUserId => _sdkPlatformUserId ?? "";
        public string CurrentUserName => _sdkUserName ?? "";

        private const int CMD_LOGIN_ON2 = 20;
        private const int CMD_LOGIN_ON = 100;
        private const int CMD_ROLE_LIST = 101;
        private const int CMD_CREATE_ROLE = 102;
        private const int CMD_INIT_GAME = 104;
        private const int CMD_PLAY_GAME = 106;
        private const int CMD_SYNC_END = 209;
        private const int CMD_SPR_FIRE_EVENT = 32200;

        private const int DEFAULT_NEWBIE_VILLAGE_ID = 1;

        public sealed class RoleInfo
        {
            public int RoleId;
            public int Sex;
            public int FactionId;
            public string Name = "";
            public int Level;
            public int ZongShiLevel;
            public int BanEndTime;
            public string BanReason = "";
            public string EquipMini = "-1_-1_-1_0_-1";
        }

        private readonly List<RoleInfo> _cachedRoles = new List<RoleInfo>();
        private string _sdkUserName = "";
        private int _pendingLoginRoleId;
        private bool _loginRoleRespondFired;

        void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Wire CmdRegistry → outbound socket
            CmdRegistry.OnSendCmd += OnSendCmd;

            // ─── Wire C# handlers for post-login CMD chain ──────────────────
            // gốc protocol: client sends CMD_LOGIN_ON → server replies CMD_LOGIN_ON
            // with "RandKey:WaitSecs". Then client sends CMD_ROLE_LIST → server
            // returns role data. Client opens UISelectRoleExist or UICreateRole.
            CmdRegistry.RegisterCSharpHandler(CMD_LOGIN_ON, OnLoginOnReply);      // CMD_LOGIN_ON reply
            CmdRegistry.RegisterCSharpHandler(CMD_LOGIN_ON2, OnLoginOn2Reply);    // CMD_LOGIN_ON2 reply (SDK auth path)
            CmdRegistry.RegisterCSharpHandler(CMD_ROLE_LIST, OnRoleListReply);    // CMD_ROLE_LIST reply
            CmdRegistry.RegisterCSharpHandler(CMD_CREATE_ROLE, OnCreateRoleReply);
            CmdRegistry.RegisterCSharpHandler(CMD_INIT_GAME, OnInitGameReply);
            CmdRegistry.RegisterCSharpHandler(CMD_PLAY_GAME, OnPlayGameReply);
            CmdRegistry.RegisterCSharpHandler(CMD_SYNC_END, OnSyncEnd);
            CmdRegistry.RegisterCSharpHandler(CMD_SPR_FIRE_EVENT, OnFireEvent);
        }

        public void SetSelectedServerId(int serverId)
        {
            if (serverId <= 0) return;
            CurrentServerId = serverId;
            UnityEngine.Debug.Log($"[NetworkManager] CurrentServerId={CurrentServerId}");
        }

        // CMD_LOGIN_ON2 reply per ProcessUserLogin2Cmd KT_TCPHandler_Core.cs:1478:
        //   SUCCESS: "userID:userName:userToken:isadult"   (4 fields)
        //   FAILURE: "<errorCode>:..."                     (single error code)
        //
        // The userToken returned is a NEW server-generated RC4+SHA1 token. We must
        // send it back via CMD_LOGIN_ON (id=100) — the REAL session-registration
        // step. Only after CMD_LOGIN_ON does OnlineUserSession.AddSession run, so
        // CMD_ROLE_LIST works.
        //
        // Flow: SDK login → CMD_LOGIN_ON2 (web auth) → CMD_LOGIN_ON (session) → CMD_ROLE_LIST
        private void OnLoginOn2Reply(byte[] payload)
        {
            string s = payload != null ? System.Text.Encoding.UTF8.GetString(payload) : "";
            UnityEngine.Debug.Log($"[NetworkManager] ← CMD_LOGIN_ON2 reply: '{s}'");
            var fields = s.Split(':');
            if (fields.Length < 4)
            {
                UnityEngine.Debug.LogError($"[NetworkManager] CMD_LOGIN_ON2 FAILED fields={fields.Length} payload='{s}'");
                ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                    "emNOTIFY_LOGIN_HAND_SHAKE_END", 1);
                return;
            }
            // fields[0]=userID (e.g. "3_testuser"), fields[1]=userName, fields[2]=NEW userToken, fields[3]=isadult
            string userID = fields[0];
            string userName = fields[1];
            string userToken = fields[2];
            string isadult = fields[3];
            UnityEngine.Debug.Log($"[NetworkManager] CMD_LOGIN_ON2 SUCCESS userID='{userID}' userName='{userName}'");

            // Send CMD_LOGIN_ON (id=100) per ProcessUserLoginCmd:1499 expected format:
            //   "userID:userName:userToken:roleRandToken:verSign:userIsAdult"
            // 6 fields = first-time login (no role yet). Server validates token via
            // UserLoginToken.SetEncryptString → registers session via OnlineUserSession.AddSession.
            // roleRandToken: we use 0 (unused on initial login per server line 1530).
            _sdkPlatformUserId = userID;
            _sdkUserName = userName;
            string loginBody = $"{userID}:{userName}:{userToken}:0:{LoginTokenHelper.VerSign}:{isadult}";
            _sock.Send(CMD_LOGIN_ON, Encoding.UTF8.GetBytes(loginBody));
            UnityEngine.Debug.Log($"[NetworkManager] → CMD_LOGIN_ON sent body='{loginBody}'");
        }

        // SDK platform_user_id stash for CMD_ROLE_LIST userID field (set after SDK verify).
        private string _sdkPlatformUserId;

        // CMD_LOGIN_ON reply per ProcessUserLoginCmd KT_TCPHandler_Core.cs:1668:
        //   SUCCESS: "RandKey:WaitSecs" — session registered via OnlineUserSession.AddSession.
        //   FAILURE: single error code field.
        // After SUCCESS we send CMD_ROLE_LIST since session is now active.
        private void OnLoginOnReply(byte[] payload)
        {
            string s = payload != null ? System.Text.Encoding.UTF8.GetString(payload) : "";
            UnityEngine.Debug.Log($"[NetworkManager] ← CMD_LOGIN_ON reply: '{s}'");
            var fields = s.Split(':');
            if (fields.Length < 2)
            {
                UnityEngine.Debug.LogError($"[NetworkManager] CMD_LOGIN_ON failed: code={fields[0]}");
                ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                    "emNOTIFY_LOGIN_HAND_SHAKE_END", 1);
                return;
            }
            UnityEngine.Debug.Log($"[NetworkManager] CMD_LOGIN_ON SUCCESS RandKey={fields[0]} WaitSecs={fields[1]}");

            // Send CMD_ROLE_LIST. Format = "userID:zoneID". userID = SDK platform_user_id
            // we used in CMD_LOGIN_ON2 + CMD_LOGIN_ON (e.g. "3_testuser").
            string userId = _sdkPlatformUserId ?? _pendingAccount ?? "";
            string body = $"{userId}:{CurrentZoneId}";
            _sock.Send(CMD_ROLE_LIST, Encoding.UTF8.GetBytes(body));
            UnityEngine.Debug.Log($"[NetworkManager] → CMD_ROLE_LIST sent body='{body}'");
        }

        // Server replies CMD_ROLE_LIST with:
        //   "{count}:{roleID$sex$factionID$roleName$level$preDelLeftSeconds$armor_helm_weapon_enhance_mantle|...}"
        // Source: GameDBServer/Server/TCPCmdHandler.cs ProcessGetRoleListCmd.
        // gốc Lua then reads GetRoleList() and opens UISelectRoleExist/UICreateRole.
        private void OnRoleListReply(byte[] payload)
        {
            string s = payload != null ? Encoding.UTF8.GetString(payload) : "";
            UnityEngine.Debug.Log($"[NetworkManager] ← CMD_ROLE_LIST reply: '{s}'");
            ParseRoleListPayload(s);
            ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName("emNOTIFY_SYNC_ROLE_LIST_DONE");
        }

        private void ParseRoleListPayload(string payload)
        {
            _cachedRoles.Clear();
            if (string.IsNullOrEmpty(payload)) return;

            string[] head = payload.Split(new[] { ':' }, 2);
            if (head.Length == 0 || !int.TryParse(head[0], out int count) || count <= 0)
            {
                return;
            }

            if (head.Length < 2 || string.IsNullOrEmpty(head[1])) return;
            string[] rows = head[1].Split('|');
            for (int i = 0; i < rows.Length; i++)
            {
                if (string.IsNullOrEmpty(rows[i])) continue;
                string[] fields = rows[i].Split('$');
                if (fields.Length < 6) continue;
                _cachedRoles.Add(new RoleInfo
                {
                    RoleId = ParseInt(fields[0]),
                    Sex = ParseInt(fields[1]),
                    FactionId = ParseInt(fields[2]),
                    Name = fields[3].Replace('*', '|'),
                    Level = ParseInt(fields[4]),
                    ZongShiLevel = 0,
                    BanEndTime = 0,
                    BanReason = "",
                    EquipMini = fields.Length > 6 ? fields[6] : "-1_-1_-1_0_-1",
                });
            }

            if (_cachedRoles.Count != count)
            {
                UnityEngine.Debug.LogWarning($"[NetworkManager] ROLE_LIST declared count={count}, parsed={_cachedRoles.Count}");
            }
        }

        public string GetRoleListJson()
        {
            var rows = new List<object>(_cachedRoles.Count);
            foreach (var r in _cachedRoles)
            {
                rows.Add(new
                {
                    nRoleID = r.RoleId,
                    nSex = r.Sex,
                    nFaction = r.FactionId,
                    szName = r.Name,
                    nLevel = r.Level,
                    nZongShiLevel = r.ZongShiLevel,
                    nBanEndTime = r.BanEndTime,
                    szBanReason = r.BanReason,
                    szEquipMini = r.EquipMini,
                });
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(rows);
        }

        public void CreateRole(string name, int sex, int factionId)
        {
            if (!_sock.Connected)
            {
                UnityEngine.Debug.LogError("[NetworkManager.CreateRole] world socket not connected");
                NotifyCreateRoleRespond(6, 0);
                return;
            }

            string userId = _sdkPlatformUserId ?? "";
            string userName = string.IsNullOrEmpty(_sdkUserName) ? (_pendingAccount ?? "") : _sdkUserName;
            if (string.IsNullOrEmpty(userId))
            {
                UnityEngine.Debug.LogError("[NetworkManager.CreateRole] missing SDK user id");
                NotifyCreateRoleRespond(6, 0);
                return;
            }

            string safeName = SanitizePacketField(name);
            string safeUserName = SanitizePacketField(userName);
            string body = $"{userId}:{safeUserName}:{sex}:{factionId}:{safeName}$0:{CurrentServerId}:{DEFAULT_NEWBIE_VILLAGE_ID}";
            _sock.Send(CMD_CREATE_ROLE, Encoding.UTF8.GetBytes(body));
            UnityEngine.Debug.Log($"[NetworkManager] → CMD_CREATE_ROLE body='{body}'");
        }

        private void OnCreateRoleReply(byte[] payload)
        {
            string s = payload != null ? Encoding.UTF8.GetString(payload) : "";
            UnityEngine.Debug.Log($"[NetworkManager] ← CMD_CREATE_ROLE reply: '{s}'");

            string[] head = s.Split(new[] { ':' }, 2);
            int serverCode = head.Length > 0 ? ParseInt(head[0]) : 0;
            string roleBlob = head.Length > 1 ? head[1] : "";
            if (serverCode == 1)
            {
                RoleInfo? role = ParseRoleBlob(roleBlob);
                int roleId = role?.RoleId ?? 0;
                if (role != null)
                {
                    UpsertRole(role);
                }
                NotifyCreateRoleRespond(0, roleId);
                return;
            }

            NotifyCreateRoleRespond(MapCreateRoleCode(serverCode), 0);
        }

        public void LoginRole(int roleId)
        {
            if (!_sock.Connected)
            {
                UnityEngine.Debug.LogError("[NetworkManager.LoginRole] world socket not connected");
                ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName("emNOTIFY_LOGIN_ROLE_RESPOND", 0, 4, roleId);
                return;
            }
            if (roleId <= 0)
            {
                ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName("emNOTIFY_LOGIN_ROLE_RESPOND", 0, 4, roleId);
                return;
            }

            _pendingLoginRoleId = roleId;
            _loginRoleRespondFired = false;
            string deviceId = SanitizePacketField(UnityEngine.SystemInfo.deviceUniqueIdentifier);
            if (string.IsNullOrEmpty(deviceId) || deviceId == "unsupported")
            {
                deviceId = "thanmaorigin-editor";
            }
            string deviceModel = SanitizePacketField(UnityEngine.SystemInfo.deviceModel);
            string body = $"{CurrentUserId}:{roleId}:{deviceId}:{deviceModel}";
            _sock.Send(CMD_INIT_GAME, Encoding.UTF8.GetBytes(body));
            UnityEngine.Debug.Log($"[NetworkManager] → CMD_INIT_GAME body='{body}'");
        }

        private void OnInitGameReply(byte[] payload)
        {
            UnityEngine.Debug.Log($"[NetworkManager] ← CMD_INIT_GAME reply: {payload?.Length ?? 0} bytes");
            if (_pendingLoginRoleId <= 0 || payload == null || payload.Length == 0)
            {
                FireLoginRoleRespondOnce(0, 4, _pendingLoginRoleId);
                return;
            }

            string body = _pendingLoginRoleId.ToString();
            _sock.Send(CMD_PLAY_GAME, Encoding.UTF8.GetBytes(body));
            UnityEngine.Debug.Log($"[NetworkManager] → CMD_PLAY_GAME body='{body}'");
        }

        private void OnPlayGameReply(byte[] payload)
        {
            string s = payload != null ? Encoding.UTF8.GetString(payload) : "";
            UnityEngine.Debug.Log($"[NetworkManager] ← CMD_PLAY_GAME reply: '{s}'");
            int roleId = ParseInt(s);
            if (roleId <= 0) roleId = _pendingLoginRoleId;
            FireLoginRoleRespondOnce(1, 0, roleId);
        }

        private void OnSyncEnd(byte[] payload)
        {
            UnityEngine.Debug.Log("[NetworkManager] ← CMD_SYNC_END");
            if (_pendingLoginRoleId > 0 && !_loginRoleRespondFired)
            {
                FireLoginRoleRespondOnce(1, 0, _pendingLoginRoleId);
            }
            ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName("emNOTIFY_SYNC_PLAYER_DATA_END", 0);
        }

        private void OnFireEvent(byte[] payload)
        {
            string s = payload != null ? Encoding.UTF8.GetString(payload) : "";
            UnityEngine.Debug.Log($"[NetworkManager] ← CMD_SPR_FIRE_EVENT payload='{s}'");
            // Server still emits legacy fake gate event 7 before the full initial
            // player snapshot. Keep it logged, but use CMD_SYNC_END (209) as the
            // canonical point to fire emNOTIFY_SYNC_PLAYER_DATA_END.
        }

        private void FireLoginRoleRespondOnce(int success, int code, int roleId)
        {
            if (_loginRoleRespondFired) return;
            _loginRoleRespondFired = true;
            ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                "emNOTIFY_LOGIN_ROLE_RESPOND", success, code, roleId);
        }

        private void NotifyCreateRoleRespond(int code, int roleId)
        {
            var env = ThanMaOrigin.Lua.LuaEngine.Instance?.Env;
            if (env == null)
            {
                ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName("emNOTIFY_CREATE_ROLE_RESPOND", code, roleId);
                return;
            }

            try
            {
                env.DoString($@"
                    if Login and Login.OnCreateRoleRespond then
                        Login:OnCreateRoleRespond({code}, {roleId})
                    elseif EventNotify then
                        EventNotify.OnNotify(EventNotify.emNOTIFY_CREATE_ROLE_RESPOND, {code}, {roleId})
                    end
                ", "NetworkManager_CreateRoleRespond");
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError($"[NetworkManager.NotifyCreateRoleRespond] {e.Message}");
                ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName("emNOTIFY_CREATE_ROLE_RESPOND", code, roleId);
            }
        }

        private static RoleInfo? ParseRoleBlob(string roleBlob)
        {
            if (string.IsNullOrEmpty(roleBlob)) return null;
            string[] fields = roleBlob.Split('$');
            if (fields.Length < 6) return null;
            return new RoleInfo
            {
                RoleId = ParseInt(fields[0]),
                Sex = ParseInt(fields[1]),
                FactionId = ParseInt(fields[2]),
                Name = fields[3],
                Level = ParseInt(fields[4]),
                ZongShiLevel = 0,
                BanEndTime = 0,
                BanReason = "",
                EquipMini = fields.Length > 6 ? fields[6] : "-1_-1_-1_0_-1",
            };
        }

        private void UpsertRole(RoleInfo role)
        {
            for (int i = 0; i < _cachedRoles.Count; i++)
            {
                if (_cachedRoles[i].RoleId == role.RoleId)
                {
                    _cachedRoles[i] = role;
                    return;
                }
            }
            _cachedRoles.Add(role);
        }

        private static int MapCreateRoleCode(int serverCode)
        {
            switch (serverCode)
            {
                case -3: return 1;     // name invalid/already used
                case -1: return 2;     // invalid name/params
                case -2: return 5;     // server role data full
                case -7: return 7;     // create role disabled/limited
                case -1000: return 9;  // max roles on account
                case 0: return 6;      // generic DB/server error
                default: return 6;
            }
        }

        private static int ParseInt(string value)
        {
            return int.TryParse(value, out int n) ? n : 0;
        }

        private static string SanitizePacketField(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            return value.Replace(":", "_").Replace("|", "_").Replace("$", "_");
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

            // Do not fire emNOTIFY_GATEWAY_CONNECT inline here. In gốc native,
            // LuaConnectGateway @0x236adc only calls XGatewayClient::ConnectOuter
            // and returns; XGatewayClient::ConnectSuccess @0x233fe0 or
            // ProcessSocketError @0x2340e4 reports the result later. Reporting it
            // inline races Login.lua:376, where UILoadingTips is opened after
            // ConnectGateway(), leaving the loading overlay on top of UIMessageBoxBig
            // for immediate connection failures.
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
                // Right after TCP connect, run SDK auth + send CMD_LOGIN_ON2 (id=20).
                // gốc flow (per KiemTheOrigin_DeepExtract/01_Login/Scripts/LoginSceneUI.cs):
                //   1. Sdk:Login() → POST sdk_server :8887/loginsdk.aspx with (user, pass)
                //   2. SDK returns access_token
                //   3. POST /verifyaccount.aspx with token → returns platform_user_id, sign_token, l_time
                //   4. Send CMD_LOGIN_ON2 to GameServer:3001:
                //      "verSign:platform_user_id:account_name:l_time:isadult:sign_token"
                //   5. GameServer recomputes sign_token = MD5(...+WEB_KEY) → if match, login OK
                //
                // Day 9.16 (2026-04-27): replace LoginTokenHelper RC4+SHA1 path with this.
                //   The RC4+SHA1 path was for CMD_LOGIN_ON (id=100), which works but doesn't
                //   actually authenticate against any user database — only validates a token
                //   server itself signed. CMD_LOGIN_ON2 (id=20) is the real auth path used
                //   by gốc Sdk channel.
                //
                // For DEV mode: hard-coded test credentials (testuser/12345678) since
                // UILoginChannelInner only has account input field — no password input UI yet.
                // TODO: add password input field to UILoginChannelInner prefab so user types
                //       both. For now: account text overrides username if not blank, password
                //       always "12345678" (dev test account from local_state.json).
                StartCoroutine(DoSdkLoginCoroutine());
            }
            return ok;
        }

        private System.Collections.IEnumerator DoSdkLoginCoroutine()
        {
            string username = string.IsNullOrEmpty(_pendingAccount) ? "testuser" : _pendingAccount;
            // DEV: hard-coded test password. local_state.json has testuser/12345678.
            // TODO Phase 5: pipe password from UI input field.
            string password = "12345678";
            UnityEngine.Debug.Log($"[NetworkManager] SDK auth chain start user={username}");

            var loginTask = SdkHttpClient.LoginAndVerifyAsync(username, password);
            // Yield until task done (Unity coroutine pattern for Task<T>)
            while (!loginTask.IsCompleted) yield return null;
            var r = loginTask.Result;
            if (!r.Success)
            {
                UnityEngine.Debug.LogError($"[NetworkManager] SDK auth FAIL: code={r.ErrorCode} msg='{r.ErrorMsg}'");
                ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                    "emNOTIFY_LOGIN_HAND_SHAKE_END", 1);
                yield break;
            }

            // CMD_LOGIN_ON2 (id=20) payload: "verSign:platform_user_id:account_name:l_time:isadult:sign_token"
            // verSign = 20140624 (TCPCmdProtocolVer.VerSign).
            // isadult = "1" (must match what we passed to verify; SDK server hardcodes "1" in formula).
            _sdkPlatformUserId = r.PlatformUserId;  // stash for CMD_ROLE_LIST
            _sdkUserName = r.AccountName;
            string body = $"{LoginTokenHelper.VerSign}:{r.PlatformUserId}:{r.AccountName}:{r.LTime}:1:{r.SignToken}";
            byte[] payload = Encoding.UTF8.GetBytes(body);
            _sock.Send(CMD_LOGIN_ON2, payload);
            UnityEngine.Debug.Log($"[NetworkManager] → CMD_LOGIN_ON2 sent ({payload.Length} bytes) body='{body}'");

            ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName(
                "emNOTIFY_LOGIN_HAND_SHAKE_END", 0);
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

        public void CloseWorldServer()
        {
            _sock.Close();
            _pendingLoginRoleId = 0;
            _loginRoleRespondFired = false;
            UnityEngine.Debug.Log("[NetworkManager.CloseWorldServer] closed world socket");
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
