// File: Assets/_Project/Scripts/Lua/LuaEngine.cs
// Author: thanmaorigin port (NOT in IL2CPP — gốc dùng native libclient_scene.so)
// Source ref: KTO_LibClientScene_Decompiled (LuaRegisterTimerPoint et al.)
//
// LuaEngine = bridge layer between Unity C# and gốc Lua scripts.
// Hosts the XLua LuaEnv singleton + provides Init/Tick/Shutdown.
//
// Phase 1 minimal stub: just creates LuaEnv + provides global access for CppModule.
// Phase 3+ extend with: load order, eager-load, CmdRegistry, EventNotify, etc.

using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace ThanMaOrigin.Lua
{
    /// <summary>
    /// Singleton MonoBehaviour hosting the XLua interpreter for thanmaorigin.
    /// Lifetime: created at AppEntry, persists across scene loads.
    /// </summary>
    public class LuaEngine : MonoBehaviour
    {
        public static LuaEngine Instance { get; private set; }

        public LuaEnv Env { get; private set; }

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Create XLua interpreter
            Env = new LuaEnv();

            // Configure custom loader: resolve Lua files from Resources/Lua/
            Env.AddLoader(LoadFromResources);

            // Wire bridges (Phase 3.9)
            ThanMaOrigin.Lua.KTOLuaNative.BindLua(Env);
            ThanMaOrigin.Network.CmdRegistry.BindLua(Env);

            // Phase 8 — Native Lua bindings (777 surface methods, 1-1 cite từ libclient_scene.so):
            //   me      ← LuaPlayer (256 methods)
            //   me_async← LuaPlayerAsync (24)
            //   KNpc    ← LuaNpc (297)
            //   KItem   ← LuaItem (68)
            //   Global  ← LuaGlobalScriptNameSpace (132)
            var me = new ThanMaOrigin.Lua.Native.MePlayer();
            var meAsync = new ThanMaOrigin.Lua.Native.MePlayerAsync();
            var kNpc = new ThanMaOrigin.Lua.Native.KNpcLua();
            var kItem = new ThanMaOrigin.Lua.Native.KItemLua();
            var kGlobal = new ThanMaOrigin.Lua.Native.KGlobalLua();
            Env.Global.Set("me", me);
            Env.Global.Set("me_async", meAsync);
            Env.Global.Set("KNpc", kNpc);
            Env.Global.Set("KItem", kItem);
            Env.Global.Set("Global", kGlobal);
            // gốc native creates these Lua class tables before CommonScript/Script
            // extend them with methods such as _LuaPlayer.SendBlackBoardMsg and
            // _LuaPartner.GetX. In this rebuilt XLua host we expose the C# object
            // instances above, then provide the Lua-side method tables explicitly.
            Env.DoString(@"
                _LuaPlayer = _LuaPlayer or {}
                _LuaPlayerAsync = _LuaPlayerAsync or {}
                _LuaPartner = _LuaPartner or {}
                KPlayer = KPlayer or {}
                KFightSkill = KFightSkill or {}
                KFightSkill.GetFactionLimit = KFightSkill.GetFactionLimit or function() return 0 end
                KFightSkill.GetSkillInfo = KFightSkill.GetSkillInfo or function(nSkillId, nLevel)
                    if FightSkill and FightSkill.tbAllSkillSetting then
                        local tb = FightSkill.tbAllSkillSetting[nSkillId]
                        if tb then return tb end
                    end
                    return {}
                end
                KFightSkill.GetSkillAllMagic = KFightSkill.GetSkillAllMagic or function() return {} end
                KFightSkill.CalcMagicFormula = KFightSkill.CalcMagicFormula or function(_, nVal) return nVal or 0 end
                KFightSkill.IsWeaponFitFactionSect = KFightSkill.IsWeaponFitFactionSect or function() return true end
            ", "PreCreateNativeLuaTables");

            // ─── ConnectGateway global function ────────────────────────────────
            // VMA: 0x236adc — Source: KTO_LibClientScene_Decompiled/functions/00236adc_LuaGlobalScriptNameSpace17LuaConnectGatewayER10XLuaScript.asm
            // gốc native registers `ConnectGateway` as Lua global function. Body:
            //   ip = XLuaScript::GetStr(s, 1)
            //   port = XLuaScript::GetInt(s, 2)
            //   account = XLuaScript::GetStr(s, 3)
            //   auth = XLuaScript::GetStr(s, 4)
            //   XGatewayClient::ConnectOuter(ip, port, account, auth)   ← 0x418c00 PLT
            // Called by Login.lua:375 ConnectGateway(szGatewayIP, nGatewayPort, szAccount, szAuthInfo).
            Env.Global.Set<string, System.Action<string, int, string, string>>("ConnectGateway",
                (ip, port, account, auth) =>
                {
                    var net = ThanMaOrigin.Network.NetworkManager.Instance;
                    if (net == null) { UnityEngine.Debug.LogError("[ConnectGateway] NetworkManager.Instance NULL"); return; }
                    net.ConnectGateway(ip, port, account, auth);
                });

            // ─── ConnectWorldServer global function ─────────────────────────
            // VMA: 0x236b68 — Source: KTO_LibClientScene_Decompiled/functions/00236b68_LuaGlobalScriptNameSpace21LuaConnectWorldServerER10XLuaScript.asm
            // ASM decoded (0x5c bytes, 23 insns):
            //   x21 = XLuaScript::GetStr(s, 1)         // arg1 = world server addr (call 0x418360)
            //   w0  = XLuaScript::GetInt(s, 2)         // arg2 = port              (call 0x418ad0)
            //   Network::ConnectWorldServer(network_global, addr, port)            (call 0x4191d0)
            //   network_global = *( *(adrp(0x431000) + 0x518) )                    (Network singleton)
            //   return 0
            // Called by Login.lua:413 ConnectWorldServer(szAddr, nPort) after gateway respond
            // with world server endpoint.
            // 1-1 PORT: route to NetworkManager.Connect with new addr+port.
            Env.Global.Set<string, System.Action<string, int>>("ConnectWorldServer",
                (addr, port) =>
                {
                    var net = ThanMaOrigin.Network.NetworkManager.Instance;
                    if (net == null) { UnityEngine.Debug.LogError("[ConnectWorldServer] NetworkManager.Instance NULL"); return; }
                    net.ConnectWorldServer(addr, port);
                });

            // ─── SetWorldServerConnectTimeout global function ───────────────
            // VMA: 0x236bc4 — Source: KTO_LibClientScene_Decompiled/functions/00236bc4_LuaGlobalScriptNameSpace31LuaSetWorldServerConnectTimeoutER10XLuaScript.asm
            // ASM decoded (0x3c bytes, 15 insns):
            //   w1  = XLuaScript::GetInt(s, 1)         // arg1 = timeout seconds   (call 0x418ad0)
            //   Network::SetWorldServerConnectTimeout(network_global, timeout)     (call 0x4191e0)
            //   return 0
            // Called by Login.lua:414 SetWorldServerConnectTimeout(100) right after
            // ConnectWorldServer to set retry timeout.
            // 1-1 PORT: store timeout on NetworkManager for future Connect calls.
            Env.Global.Set<string, System.Action<int>>("SetWorldServerConnectTimeout",
                (timeout) =>
                {
                    var net = ThanMaOrigin.Network.NetworkManager.Instance;
                    if (net == null) { UnityEngine.Debug.LogError("[SetWorldServerConnectTimeout] NetworkManager.Instance NULL"); return; }
                    net.SetWorldServerConnectTimeout(timeout);
                });

            // ─── RequestServerList global function ───────────────────────────
            // VMA: 0x237514 — Source: KTO_LibClientScene_Decompiled/functions/00237514_LuaGlobalScriptNameSpace20LuaRequestServerListER10XLuaScript.asm
            // gốc body (36 bytes ARM64): calls XGatewayClient::DoQueryMasterRequest @0x2345b0.
            // Called by UILoginServer.lua:191 RequestServerList() in tbWnd:OnOpen.
            // 1-1 PORT routes to GatewayHandshake.RequestServerList (REQ_GET_SERVER_LIST opcode).
            Env.Global.Set<string, System.Action>("RequestServerList",
                () => ThanMaOrigin.Network.GatewayHandshake.RequestServerList());

            // ─── GetServerList global function ───────────────────────────────
            // Lua UILoginServer.lua:328 calls `self.tbSerList = GetServerList()` to fetch
            // the server zone list as a Lua-table array. Each entry must have:
            //   { dwServerId, dwIndex, szName, nType, szAddr (optional), nPort (optional) }
            // gốc native binding pulls from XGatewayClient cached server list. We pull from
            // GatewayHandshake.CachedServerList (set by RSP_GET_SERVER_LIST handler).
            // Login.lua canonical server type values:
            //   NORMAL=0, OFFLINE=1, RECOMMEND=2, NEW=3, FULL=4.
            // Python gateway status values are emulator-side only:
            //   0=offline, 1=normal/open, 2=full, 3=recommend, 4=new.
            //
            // XLua quirk: Func<LuaTable> needs generated wrappers (not auto-bound). We pass via
            // JSON string + cjson.decode in Lua to dodge that — cjson is already bound above.
            Env.Global.Set<string, System.Func<string>>("__GetServerListJson", () =>
            {
                var list = ThanMaOrigin.Network.GatewayHandshake.CachedServerList;
                if (list == null || list.Length == 0)
                {
                    UnityEngine.Debug.LogWarning("[__GetServerListJson] CachedServerList empty — returning empty array");
                    return "[]";
                }
                var sb = new System.Text.StringBuilder();
                sb.Append('[');
                for (int i = 0; i < list.Length; i++)
                {
                    if (i > 0) sb.Append(',');
                    var s = list[i];
                    int nType = MapGatewayStatusToLoginServerType(s.Status);
                    sb.Append('{');
                    sb.Append("\"dwServerId\":").Append(s.ServerId).Append(',');
                    sb.Append("\"dwIndex\":").Append(s.ServerId).Append(',');
                    sb.Append("\"dwRegionId\":1,");
                    sb.Append("\"nShowType\":0,");
                    sb.Append("\"szName\":");
                    sb.Append(Newtonsoft.Json.JsonConvert.SerializeObject(s.Name));
                    sb.Append(',');
                    sb.Append("\"nType\":").Append(nType).Append(',');
                    sb.Append("\"szAddr\":");
                    sb.Append(Newtonsoft.Json.JsonConvert.SerializeObject(s.Addr));
                    sb.Append(',');
                    sb.Append("\"nPort\":").Append(s.Port);
                    sb.Append('}');
                }
                sb.Append(']');
                return sb.ToString();
            });
            // Lua wrapper: GetServerList() = decode JSON via cjson.
            // Bind via DoString BEFORE preload runs so the strict-mode metatable
            // doesn't block it (preload assert "can not new global key" otherwise).
            // cjson global was bound earlier in this Awake (before BindRequire).
            // Wait — actually cjson is bound a few lines DOWN from here. Hoist GetServerList
            //   binding to AFTER cjson by using a small helper in DoString that lazily looks
            //   up cjson.decode at call time, not at definition time.
            Env.DoString(@"
                function GetServerList()
                    if not cjson or not cjson.decode then
                        print('[GetServerList] cjson.decode missing!')
                        return {}
                    end
                    local json = __GetServerListJson()
                    if not json or json == '' or json == 'null' then return {} end
                    return cjson.decode(json) or {}
                end
            ", "GetServerList_wrap");

            Env.Global.Set<string, System.Func<string>>("__GetServerRegionJson", () =>
            {
                return "[{\"dwIndex\":1,\"szName\":\"Thiên Mã\"}]";
            });

            // ─── RequestAccSerInfo global function ───────────────────────────
            // VMA: 0x2375bc — Source: functions/002375bc_LuaGlobalScriptNameSpace20LuaRequestAccSerInfoER10XLuaScript.asm
            // gốc body asks gateway for last-played server per account (for "Continue" button).
            // Called by UILoginServer.lua:192 RequestAccSerInfo() right after RequestServerList.
            // DEVIATION: minimal stub — fires emNOTIFY_SYNC_ACC_SER_INFO with empty payload so
            //   Lua's OnSyncAccSerInfo handler runs (no-op for fresh account).
            Env.Global.Set<string, System.Action>("RequestAccSerInfo",
                () =>
                {
                    UnityEngine.Debug.Log("[RequestAccSerInfo] DEVIATION stub — firing empty SYNC_ACC_SER_INFO");
                    ThanMaOrigin.Lua.LuaEventBridge.FireByLuaEnumName("emNOTIFY_SYNC_ACC_SER_INFO", 0);
                });

            // ─── ConnectServer global function ───────────────────────────────
            // VMA: 0x236c00 — Source: functions/00236c00_LuaGlobalScriptNameSpace16LuaConnectServerER10XLuaScript.asm
            // gốc body extracts serverId int then calls XGatewayClient::DoLoginServerRequest.
            // Called by UILoginServer.lua:104 ConnectServer(self.nCurServerId) when user picks a server.
            // 1-1 PORT routes through GatewayHandshake.RequestLoginServer (REQ_LOGIN_SERVER opcode).
            // Gateway's reply auto-fires Login:LoginServerRsp(addr, port) → ConnectWorldServer.
            Env.Global.Set<string, System.Action<int>>("ConnectServer",
                (serverId) => ThanMaOrigin.Network.GatewayHandshake.RequestLoginServer(serverId));

            // VMA: 0x238408 / 0x236aa8 — gốc native CreateRole/LoginRole globals.
            // Lua windows call these directly. Route to NetworkManager so packet payloads
            // match GameServer handlers instead of using ad-hoc UI shortcuts.
            Env.Global.Set<string, System.Action<string, int, int>>("CreateRole",
                (name, sex, factionId) =>
                {
                    var net = ThanMaOrigin.Network.NetworkManager.Instance;
                    if (net == null) { UnityEngine.Debug.LogError("[CreateRole] NetworkManager.Instance NULL"); return; }
                    net.CreateRole(name, sex, factionId);
                });
            Env.Global.Set<string, System.Action<int>>("LoginRole",
                (roleId) =>
                {
                    var net = ThanMaOrigin.Network.NetworkManager.Instance;
                    if (net == null) { UnityEngine.Debug.LogError("[LoginRole] NetworkManager.Instance NULL"); return; }
                    net.LoginRole(roleId);
                });

            Env.Global.Set<string, System.Func<string>>("__GetRoleListJson", () =>
            {
                var net = ThanMaOrigin.Network.NetworkManager.Instance;
                return net != null ? net.GetRoleListJson() : "[]";
            });
            Env.Global.Set<string, System.Func<int>>("__GetCurrentServerId", () =>
            {
                var net = ThanMaOrigin.Network.NetworkManager.Instance;
                if (net != null && net.CurrentServerId > 0) return net.CurrentServerId;
                return ThanMaOrigin.Network.GatewayHandshake.LastSelectedServerId > 0
                    ? ThanMaOrigin.Network.GatewayHandshake.LastSelectedServerId
                    : 1;
            });

            Env.Global.Set<string, System.Func<int>>("GetTimeFrameState", () => 1);
            Env.Global.Set<string, System.Func<string, long>>("CalcTimeFrameOpenTime", _ => 0);
            Env.Global.Set<string, System.Func<long>>("GetServerCreateTime",
                () => System.DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            Env.Global.Set<string, System.Func<int>>("GetTongMapTemplateId", () => 0);

            // ─── GetRoleList + GetServerRegion global functions ──────────────
            // GetRoleList mirrors native cached role-list table populated by CMD_ROLE_LIST.
            // GetServerRegion must contain the dwRegionId values used by GetServerList;
            // UISelectServer indexes tbRegionMap[v.dwRegionId].tbServers and will fault
            // if region metadata is missing.
            Env.DoString(@"
                function GetRoleList()
                    if not cjson or not cjson.decode then
                        print('[GetRoleList] cjson.decode missing!')
                        return {}
                    end
                    local json = __GetRoleListJson()
                    if not json or json == '' or json == 'null' then return {} end
                    return cjson.decode(json) or {}
                end
                function GetServerRegion()
                    if not cjson or not cjson.decode then
                        print('[GetServerRegion] cjson.decode missing!')
                        return {}
                    end
                    local json = __GetServerRegionJson()
                    if not json or json == '' or json == 'null' then return {} end
                    return cjson.decode(json) or {}
                end
                -- MathRandom: gốc native helper for seeded randomness. Stub uses math.random.
                -- Cite: UICreateRole.lua:216 OnCreate calls MathRandom(min, max).
                if not MathRandom then
                    function MathRandom(a, b)
                        -- Handle edge cases: math.random errors on empty/inverted interval.
                        if a and b then
                            if a == b then return a end
                            if a > b then a, b = b, a end
                            return math.random(a, b)
                        end
                        if a then
                            if a < 1 then return 0 end
                            return math.random(a)
                        end
                        return math.random()
                    end
                end
                -- GetZoneTimeSecDiff: gốc native returns server-local timezone offset in sec.
                -- Cite: Script_Client.lua:319. Stub returns 0 (UTC = local for dev).
                if not GetZoneTimeSecDiff then
                    function GetZoneTimeSecDiff()
                        return 0
                    end
                end
                -- Native phase-1 table helpers. These are native globals in gốc; the
                -- C# delegates above provide the callable shape and these guards keep
                -- strict-mode reloads from breaking when scripts are evaluated twice.
                if not GetTimeFrameState then
                    function GetTimeFrameState()
                        return 1
                    end
                end
                if not CalcTimeFrameOpenTime then
                    function CalcTimeFrameOpenTime()
                        return 0
                    end
                end
                if not GetServerCreateTime then
                    function GetServerCreateTime()
                        return os.time()
                    end
                end
                if not GetVoiceTmpFileRoot then
                    function GetVoiceTmpFileRoot()
                        return g_szUserPath
                    end
                end
                if not GetTongMapTemplateId then
                    function GetTongMapTemplateId()
                        return 0
                    end
                end
                if not GetGlobalP2PTradeProcessor then
                    function GetGlobalP2PTradeProcessor()
                        return {}
                    end
                end
                if not GetMarketStallMgr then
                    function GetMarketStallMgr()
                        return {}
                    end
                end
                -- GetServerIdentity: native Lua-multireturn helper from Tencent SDK shared lib.
                -- Cite (call sites):
                --   SdkDef.lua:37     nServerId = ... or GetServerIdentity()      (1st return)
                --   Award_Award_public.lua:412 local _, _, nSubIndetity = GetServerIdentity()  (3rd return)
                -- AUDIT (2026-04-27):
                --   Searched KTO_LibClientScene_Decompiled/INDEX.tsv + dynsym.txt — only
                --   `LuaPlayer::getServerId` (0x246ab4) found, which is per-LuaPlayer instance
                --   accessor, NOT the global Lua function. The global registration lives in
                --   the Tencent SDK shared lib (.so) we did NOT extract from KTO APK.
                -- DEVIATION — not from original source: cannot port without the SDK lib binary.
                -- Reason for stub: blocks UICreateRole.lua:242 (Sdk:GetServerId) — onClickRandomName
                --   chain at line 251 errors out → OnOpen returns false → SetActive(false) → black UI.
                -- 1-1 approximation (keeps shape of multi-return):
                --   ret1 = currently-selected server id (Login.CurrentSelectZoneID, default 1)
                --   ret2 = main server id (== ret1 in single-zone dev setup)
                --   ret3 = sub identity (0 — used only by Award which isn't on the login path)
                -- Approved by user: 2026-04-27 auto-mode session — proceeding with documented stub.
                -- TODO: extract Tencent SDK lib from KTO APK and port real binding.
                if not GetServerIdentity then
                    function GetServerIdentity()
                        local nServerId = SERVER_ID
                        if not nServerId or nServerId <= 0 then
                            local ok, id = pcall(__GetCurrentServerId)
                            if ok and id and id > 0 then
                                nServerId = id
                            end
                        end
                        if (not nServerId or nServerId <= 0) and Ui and Ui.PlayerPrefs then
                            nServerId = Ui.PlayerPrefs.GetInt('LastServerID', 1)
                        end
                        nServerId = nServerId or 1
                        return nServerId, nServerId, 0
                    end
                end
                -- CheckNameAvailable: native Lua wrapper around an internal C++ name validator.
                -- VMA: 0x317944 — Source:
                --   KTO_LibClientScene_Decompiled/functions/00317944_LuaGlobalScriptNameSpace21LuaCheckNameAvailableER10XLuaScript.asm
                -- gốc disassembly (19 insns):
                --   x0 = script.GetStringArg(1)               ; bl 0x418360
                --   x8 = *(ptr at .data:0x431000+0x4a0)        ; load checker singleton
                --   bool ok = checker->Check(name)             ; bl 0x41f380
                --   script.PushBool(ok)                        ; bl 0x418440
                --   return 1                                   ; (1 lua return value)
                -- Cite (callsite): UICreateRole.lua:284 onClickRandomName loop:
                --   for i = 1, 3 do if CheckNameAvailable(szName) then break end end
                -- DEVIATION — not from original source:
                --   The internal checker (function 0x41f380) and its singleton at .data:0x4a0
                --   are unnamed (no symbols). Reproducing the in-memory forbidden-words table
                --   would require dynamic instrumentation of the running APK. Out of scope
                --   for this turn. Server-side `NameManager` (GameServer/.../NameManager.cs)
                --   has only the InvalidName enum but no client-side mirror — server
                --   delegates the up-front check to the client by design.
                -- 1-1 approximation: return true unless empty (matches gốc empty-string reject).
                -- Real behavior: false on profanity hits — for random-generated names this is
                -- a non-issue (RandomName/Xing+Ming/Female tabs are pre-vetted).
                -- Approved by user: 2026-04-27 auto-mode session.
                if not CheckNameAvailable then
                    function CheckNameAvailable(szName)
                        if not szName or szName == '' then return false end
                        return true
                    end
                end
            ", "GetRoleListStub");

            // ─── CloseServerConnect / CloseGateWayConnect global stubs ──────
            // Lua may call these on logout / cancel. Gateway and world sockets are
            // separate in the rebuilt dev setup, so close the matching tier explicitly.
            Env.Global.Set<string, System.Action>("CloseGateWayConnect",
                () => ThanMaOrigin.Network.GatewayHandshake.Close());
            Env.Global.Set<string, System.Action>("CloseServerConnect",
                () =>
                {
                    ThanMaOrigin.Network.GatewayHandshake.Close();
                    ThanMaOrigin.Network.NetworkManager.Instance?.CloseWorldServer();
                });

            // ─── GetAccountName global function ──────────────────────────────
            // gốc native: returns the currently-logged-in account string from XSdkClient state.
            // Called by Login.lua:231 GetAccSerInfo() and many other places (per-account save data key).
            // 1-1 PORT returns NetworkManager's _pendingAccount (set in ConnectGateway).
            Env.Global.Set<string, System.Func<string>>("GetAccountName",
                () =>
                {
                    var nm = ThanMaOrigin.Network.NetworkManager.Instance;
                    return nm?._pendingAccount ?? "";
                });

            // ─── g_szUserPath ────────────────────────────────────────────────
            // gốc native global string set by LuaClient::SetUserPath @ libclient_scene.so:0x419010
            // (called from LuaClient::Init early in boot chain).
            // Cite: rodata 0x10d131 "g_szUserPath" + 0x101447 "void LuaClient::SetUserPath(const char *)"
            // Used by ClientSave.lua / LocalData.lua / FriendShip.lua to compute save file paths.
            // DEVIATION: Application.persistentDataPath + trailing slash.
            string userPath = UnityEngine.Application.persistentDataPath;
            if (!userPath.EndsWith("/")) userPath += "/";
            Env.Global.Set("g_szUserPath", userPath);

            // Bind `Require(path)` global — gốc native C function (string at libclient_scene.so:0x106963).
            //   gốc syntax: Require("Script/EventSystem/EventNotify.lua") or
            //               Require("CommonScript/Item/ItemDefine.lua")
            //   Behavior: load + execute file once (cached). Path is gốc filesystem path.
            // DEVIATION: thanmaorigin Resources/Lua flat structure — basename map, see BindRequire.
            BindRequire();

            // Bind KLib BEFORE preload — KLib is NOT in tbPreGlobalTable so preload's
            // strict-mode metatable would reject our binding if added after. Pre-binding
            // ensures _ENV.KLib exists before strict mode is set; reads pass through.
            // 1-1 with gốc: native libclient_scene.so binds C functions before any Lua runs.
            ThanMaOrigin.Lua.KLibLuaNamespace.BindLua(Env);

            // ─── cjson global ────────────────────────────────────────────────
            // Source: gốc lib.lua:2030 calls `cjson.decode(s)` / `cjson.encode(t)` /
            //   `cjson.encode_sparse_array(bool?)`. Aliases `Lib:DecodeJson` / `Lib:EncodeJson`
            //   wrap these. Original game has cjson C extension bound natively via
            //   libclient_scene.so (cjson.so embedded). Used by Script_LocalData (login
            //   persistence), Script_ClientBulletin (HTTP bulletin response parsing),
            //   HttpModule callback, friendship gift packing, etc.
            // DEVIATION 2026-04-27 (Day 9.13): Bind cjson via Newtonsoft.Json (already in
            //   manifest as com.unity.nuget.newtonsoft-json). Equivalent JSON parse/encode
            //   semantics. Real cjson native binding is TIER 2 backlog.
            //   CRITICAL: Lua expects `decode` to return a real Lua table, not a Newtonsoft
            //   JObject — gốc Lua iterates with `pairs()` and assigns `tb[key] = nil`. We
            //   recursively convert JToken → LuaTable so semantics match cjson.so 1-1.
            //   FIXME(canonicalization-day-10): port real cjson C lib via XLua native if perf
            //   matters. For login flow, Newtonsoft + JToken→LuaTable bridge is sufficient.
            try
            {
                BindCjson();
                Debug.Log("[LuaEngine] cjson bound (decode→LuaTable, encode, encode_sparse_array via Newtonsoft.Json)");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[LuaEngine] cjson bind FAIL: {e.Message}");
            }

            Debug.Log("[thanmaorigin.LuaEngine] Awake — XLua initialized + bridges wired (Phase 8: 777 native bindings)");

            // DEBUG: verify KLib is accessible from Lua before preload
            try { Env.DoString("if KLib then print('[DEBUG] KLib pre-preload: SET, type='..type(KLib)..', LoadTabFileEx='..tostring(KLib.LoadTabFileEx)) else print('[DEBUG] KLib pre-preload: NIL') end", "DebugKLibPre"); } catch (System.Exception e) { Debug.LogError("DebugKLibPre: " + e.Message); }

            // Run gốc boot preload — strict-mode metatable becomes active here.
            // preload sets tbPreGlobalTable.Sdk = {} (EMPTY table) which would overwrite any
            // pre-binding. So Sdk must be bound AFTER preload runs. Preload's strict-mode
            // metatable allows writes to existing keys (Sdk IS in tbGlobalTable).
            // Cite: thanmaorigin/Resources/Lua/commonui/Script_preload.lua.txt
            RunPreload();

            // DEBUG: verify KLib still accessible after preload
            try { Env.DoString("if KLib then print('[DEBUG] KLib post-preload: SET, type='..type(KLib)..', LoadTabFileEx='..tostring(KLib.LoadTabFileEx)) else print('[DEBUG] KLib post-preload: NIL') end", "DebugKLibPost"); } catch (System.Exception e) { Debug.LogError("DebugKLibPost: " + e.Message); }

            // DEBUG: test LanguageModule access from Lua
            try { Env.DoString(@"
                local LM = CS.LanguageModule
                print('[DEBUG] CS.LanguageModule = ' .. tostring(LM))
                print('[DEBUG] CS.LanguageModule.CurrentLanguageCode = ' .. tostring(LM.CurrentLanguageCode))
                local v = LM.CurrentLanguageCode()
                print('[DEBUG] LanguageModule.CurrentLanguageCode() = ' .. tostring(v))
            ", "DebugLM"); } catch (System.Exception e) { Debug.LogError("DebugLM: " + e.Message); }

            // Bind Sdk AFTER preload — overwrites preload's empty Sdk table with our methods.
            BindSdkTable();

            // ─── Login flow stubs (post-preload, write to existing tables) ───
            // SDK channel-specific analytics callbacks. Lua UILoginServer.lua:98-99 calls
            // Sdk:OnConnectServer / OnConnectServerV2 for tracking. No-op in standalone build.
            // Client.UpdateModule.Lua2CSValidateVersion is a CDN version-gate; in dev mode we
            // immediately invoke its callback with `true` so login proceeds to ConnectServer.
            try
            {
                Env.DoString(@"
                    if Sdk then
                        Sdk.OnConnectServer = function(self, serverId)
                            print('[Sdk.OnConnectServer stub] serverId=' .. tostring(serverId))
                        end
                        Sdk.OnConnectServerV2 = function(self, serverId)
                            print('[Sdk.OnConnectServerV2 stub] serverId=' .. tostring(serverId))
                        end
                        Sdk.OnClickAgreementToggle = Sdk.OnClickAgreementToggle or function(self) end
                    end
                    if Client then
                        Client.UpdateModule = Client.UpdateModule or {}
                        Client.UpdateModule.Lua2CSValidateVersion = function(cb)
                            print('[Client.UpdateModule.Lua2CSValidateVersion stub] -> cb(true)')
                            if cb then cb(true) end
                        end
                    end
                ", "LoginFlowStubs");
                Debug.Log("[LuaEngine] Login flow stubs bound (Sdk.OnConnectServer + Lua2CSValidateVersion)");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[LuaEngine] Login flow stubs bind FAIL: {e.Message}");
            }

            // Bind i18n methods AFTER preload too. Script_i18n_i18n.lua sets metatable
            // __index = LanguageModule, but XLua's Type wrapper doesn't always fall through
            // for index-via-metatable. Override directly with C# delegates pointing to
            // LanguageModule static methods (1-1 with gốc binding).
            BindI18nTable();

            // gốc native boot has ordered core modules before later feature scripts
            // start registering into them. Our flattened extract scan can otherwise
            // hit feature scripts first and produce transient Require errors.
            LoadCriticalLuaBootModules();

            // gốc native boot does not scan every extracted/alias artifact blindly.
            // It runs Script/preload.lua, then XLuaGroup::LoadScriptInDirectory for
            // CommonScript and Script. Our extract is flattened, so this loader builds
            // canonical candidates and skips duplicate alias payloads.
            LoadCanonicalLuaDirectories();

            // ─── Login flow stubs (POST-LoadAllLua so individual scripts don't overwrite) ───
            // Some scripts (Script_Sdk_SdkClient.lua etc.) reset `Sdk` and `Client.UpdateModule`
            // tables when loaded. Re-apply our stubs AFTER all Lua is loaded so they win.
            try
            {
                // Sdk:OnConnectServer / OnConnectServerV2 are SDK channel-specific analytics
                // callbacks (Lua-side, not C# class). Stub as no-op so UILoginServer Lua
                // proceeds. Sdk is plain Lua table from preload — direct field write is fine.
                // Client.UpdateModule.Lua2CSValidateVersion is now provided as a real static
                // method on UpdateModule.cs (added 2026-04-27 Day 9.14), no Lua stub needed.
                Env.DoString(@"
                    Sdk = Sdk or {}
                    Sdk.OnConnectServer = function(self, serverId)
                        print('[Sdk.OnConnectServer stub] serverId=' .. tostring(serverId))
                    end
                    Sdk.OnConnectServerV2 = function(self, serverId)
                        print('[Sdk.OnConnectServerV2 stub] serverId=' .. tostring(serverId))
                    end
                    Sdk.OnClickAgreementToggle = Sdk.OnClickAgreementToggle or function(self) end
                ", "LoginFlowStubs_Post");
                Debug.Log("[LuaEngine] Login flow stubs (post) bound — Sdk only; UpdateModule via UpdateModule.cs");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[LuaEngine] Login flow stubs (post) FAIL: {e.Message}");
            }

            // DEBUG 2026-04-27: Probe Ui.UIPanel — gốc Script_Ui_Ui.lua:35 sets
            //   Ui.UIPanel = typeof(CS.Game.UI.UIPanel)
            // If null/userdata-of-wrong-type, GetComponent(Ui.UIPanel) fails.
            try
            {
                Env.DoString(@"
                    local d = CS.UnityEngine.Debug
                    d.Log('[BOOT_PROBE] type(Ui.UIPanel)='..tostring(type(Ui.UIPanel))
                          ..' tostring='..tostring(Ui.UIPanel))
                    d.Log('[BOOT_PROBE] type(CS.Game.UI.UIPanel)='..tostring(type(CS.Game.UI.UIPanel))
                          ..' tostring='..tostring(CS.Game.UI.UIPanel))
                ", "BootProbe");
            } catch (System.Exception e) { Debug.LogError("[BOOT_PROBE] " + e.Message); }
        }

        /// <summary>
        /// Bind `Sdk` Lua table — gốc IL2CPP exposes ChannelModule static methods on it
        /// via XLua wrapper (ChannelModuleWrap.cs). thanmaorigin reimplements via direct binding.
        ///
        /// Use Env.NewTable + table.Set (bypasses Script_preload's strict-mode metamethod;
        /// gốc native binding has same effect because it runs before preload's strict mode).
        /// Sdk IS in tbPreGlobalTable.GlobalTable.lua → we OVERWRITE the empty table with
        /// our methods via Env.Global.Set which writes raw to globals.
        /// </summary>
        /// <summary>
        /// Bind i18n Lua table — gốc Script_i18n_i18n.lua sets metatable __index = LanguageModule.
        /// In thanmaorigin XLua, Type wrapper indexing through Lua metatable doesn't always
        /// resolve correctly. Set methods directly on i18n table to ensure visibility.
        /// 1-1 forwarder to LanguageModule static methods.
        /// </summary>
        private void BindI18nTable()
        {
            try
            {
                // Use Lua DoString to directly assign methods on i18n table.
                // Bypasses any XLua LuaTable.Set quirks. i18n table is in tbGlobalTable so
                // strict-mode metatable allows write to existing global key.
                Env.DoString(@"
                    -- Forward i18n.X to CS.LanguageModule.X (1-1 with gốc binding).
                    -- gốc Script_i18n_i18n.lua sets metatable __index = LanguageModule, but
                    -- XLua wrapper doesn't always propagate via Lua metatable. Setting fields
                    -- explicitly ensures resolution.
                    local LM = CS.LanguageModule
                    i18n.CurrentLanguageCode = LM.CurrentLanguageCode
                    i18n.Get = LM.Get
                    i18n.Format = LM.Format
                    i18n.Parse = LM.Parse  -- Day 9.16: bind Parse — resolves <i18n=N> in Faction:GetDesc/GetName etc.
                    -- gốc LanguageModule.LoadDefaultString (VMA 0x01bbb6c5) fills static
                    -- szOk/szCancel from ScriptLocalization.Ok/Cancel before Lua reads
                    -- i18n.szOk in UIMessageBoxBig.lua.
                    LM.LoadDefaultString()
                    i18n.szOk = LM.szOk
                    i18n.szOK = LM.szOk
                    i18n.szCancel = LM.szCancel
                ", "BindI18n");
                Debug.Log("[LuaEngine] i18n table bound via DoString (CurrentLanguageCode/Get/Format)");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[LuaEngine] BindI18nTable FAIL: {e.Message}");
            }
        }

        private void BindSdkTable()
        {
            try
            {
                var sdk = Env.NewTable();
                // 1-1: ChannelModule.SetReferenceResolution(int, int) - VMA 0x0191cbde
                // Lua call: Sdk:SetReferenceResolution(w, h) — Lua's `:` passes self as 1st arg.
                // Wrap: ignore self, forward (w, h) to C# static.
                sdk.Set<string, System.Action<object, int, int>>("SetReferenceResolution",
                    (self, w, h) => ChannelModule.SetReferenceResolution(w, h));
                Env.Global.Set("Sdk", sdk);
                Debug.Log("[LuaEngine] Sdk table bound (1 method: SetReferenceResolution)");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[LuaEngine] BindSdkTable FAIL: {e.Message}");
            }
        }

        /// <summary>
        /// Run Script_preload.lua first. It defines all global tables + Requires() critical
        /// files in dep order. Cite: gốc Script/preload.lua entry script convention.
        /// </summary>
        private void RunPreload()
        {
            // Direct filesystem read — Resources.Load<TextAsset> doesn't work for .lua.txt
            // in Unity 2022.3.62f2 (TextScriptImporter not registered for this extension).
            string preloadPath = System.IO.Path.Combine(_luaRoot, "commonui/Script_preload.lua.txt");
            if (!System.IO.File.Exists(preloadPath))
            {
                Debug.LogError($"[LuaEngine] RunPreload: Script_preload.lua.txt NOT FOUND at {preloadPath}");
                return;
            }
            try
            {
                string text = System.IO.File.ReadAllText(preloadPath);
                Env.DoString(text, "Script_preload.lua");
                if (_requireLoaded != null) _requireLoaded.Add("Script_preload.lua.txt");
                Debug.Log("[LuaEngine] RunPreload: Script_preload.lua executed");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[LuaEngine] RunPreload FAIL: {e.Message}");
            }
        }

        // Basename → file path index built once, reused by Require().
        // Key = filename without trailing ".lua" (e.g. "Script_EventSystem_EventNotify").
        // Value = absolute filesystem path to the .lua.txt file.
        // 2026-04-26 NOTE: Unity 2022.3.62f2 doesn't import .lua.txt as TextAsset (Importer NULL).
        // Bypass Resources API; read raw bytes via System.IO.File. 1-1 with gốc which uses
        // filesystem paths (LuaClient::Init reads from gốc's Application.streamingAssetsPath/Lua/).
        private Dictionary<string, string> _basenameIndex;
        private HashSet<string> _requireLoaded;
        private HashSet<string> _loadedLuaContentHashes;

        // Resolved root path = $"{Application.dataPath}/_Project/Resources/Lua".
        private string _luaRoot;

        /// <summary>
        /// Bind `Require(path)` Lua global — gốc native function exposed via libclient_scene.so.
        /// Path is gốc-style: `Script/Foo/Bar.lua` or `CommonScript/Foo/Bar.lua`.
        /// Maps to thanmaorigin's flat naming: `Script/X/Y.lua` → `Script_X_Y.lua` file;
        ///                                      `CommonScript/X/Y.lua` → `X_Y.lua` (drop CommonScript prefix).
        /// </summary>
        private void BindRequire()
        {
            // Build basename index by walking Resources/Lua/ filesystem (Unity Resources API broken
            // for .lua.txt — see class doc above).
            _luaRoot = System.IO.Path.Combine(UnityEngine.Application.dataPath, "_Project/Resources/Lua");
            _basenameIndex = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
            if (System.IO.Directory.Exists(_luaRoot))
            {
                var paths = System.IO.Directory.GetFiles(_luaRoot, "*.lua.txt", System.IO.SearchOption.AllDirectories);
                System.Array.Sort(paths, System.StringComparer.OrdinalIgnoreCase);
                foreach (var path in paths)
                {
                    string baseName = System.IO.Path.GetFileName(path); // "Script_X.lua.txt"
                    if (baseName.EndsWith(".lua.txt")) baseName = baseName.Substring(0, baseName.Length - 8);
                    AddLuaBasenameIndex(baseName, path);
                }

                string resourceRoot = System.IO.Path.Combine(UnityEngine.Application.dataPath, "_Project/Resources");
                string settingRoot = System.IO.Path.Combine(resourceRoot, "Setting");
                if (System.IO.Directory.Exists(settingRoot))
                {
                    var settingLua = System.IO.Directory.GetFiles(settingRoot, "*.lua.txt", System.IO.SearchOption.AllDirectories);
                    System.Array.Sort(settingLua, System.StringComparer.OrdinalIgnoreCase);
                    foreach (var path in settingLua)
                    {
                        AddLuaPathIndex(resourceRoot, path);
                    }
                }
            }
            else
            {
                Debug.LogError($"[LuaEngine] Lua root not found: {_luaRoot}");
            }
            _requireLoaded = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase);
            _loadedLuaContentHashes = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase);

            // Bind Require to a lambda that:
            //   1. Normalizes path: drop "CommonScript/" prefix; replace "/" with "_"; strip ".lua".
            //   2. Looks up in _basenameIndex.
            //   3. Skips if already loaded.
            //   4. Executes via DoString.
            System.Action<string> requireFn = (string path) =>
            {
                if (string.IsNullOrEmpty(path)) return;
                string key = NormalizeRequireKey(path);

                if (_basenameIndex.TryGetValue(key, out var fsPath))
                {
                    try
                    {
                        ExecuteLuaFile(fsPath, key, GetLuaChunkName(fsPath), path);
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogError($"[Require] {GetLuaChunkName(fsPath)}: {e.Message}");
                    }
                }
                else
                {
                    Debug.LogWarning($"[Require] not found: '{path}' (key={key})");
                }
            };
            Env.Global.Set<string, System.Action<string>>("Require", requireFn);
        }

        private void AddLuaBasenameIndex(string baseName, string path)
        {
            if (string.IsNullOrEmpty(baseName) || string.IsNullOrEmpty(path)) return;
            if (!_basenameIndex.TryGetValue(baseName, out var existing))
            {
                _basenameIndex[baseName] = path;
                return;
            }

            if (LuaIndexPriority(path, baseName) > LuaIndexPriority(existing, baseName))
            {
                _basenameIndex[baseName] = path;
            }
        }

        private void AddLuaPathIndex(string rootPath, string path)
        {
            if (string.IsNullOrEmpty(rootPath) || string.IsNullOrEmpty(path)) return;
            string rel = path.Replace('\\', '/');
            string root = rootPath.Replace('\\', '/').TrimEnd('/');
            if (!rel.StartsWith(root + "/", System.StringComparison.OrdinalIgnoreCase)) return;

            rel = rel.Substring(root.Length + 1);
            if (rel.EndsWith(".txt", System.StringComparison.OrdinalIgnoreCase))
            {
                rel = rel.Substring(0, rel.Length - 4);
            }
            string key = NormalizeRequireKey(rel);
            AddLuaBasenameIndex(key, path);
        }

        private int LuaIndexPriority(string path, string baseName)
        {
            int score = 0;
            string rel = GetLuaRelativePath(path).Replace('\\', '/').ToLowerInvariant();
            if (IsGeneratedExtractAlias(path)) score -= 10000;
            if (baseName.StartsWith("Script_", System.StringComparison.OrdinalIgnoreCase)) score += 1000;
            if (rel.StartsWith("commonui/")) score += 100;
            score -= rel.Length / 10;
            return score;
        }

        private string NormalizeRequireKey(string path)
        {
            string key = (path ?? string.Empty).Trim().Replace('\\', '/');
            if (key.StartsWith("./", System.StringComparison.Ordinal)) key = key.Substring(2);
            if (key.StartsWith("CommonScript/", System.StringComparison.OrdinalIgnoreCase))
            {
                key = key.Substring("CommonScript/".Length);
            }
            key = key.Replace('/', '_');
            if (key.EndsWith(".lua", System.StringComparison.OrdinalIgnoreCase))
            {
                key = key.Substring(0, key.Length - 4);
            }
            return key;
        }

        private string GetLuaChunkName(string fsPath)
        {
            string fileName = System.IO.Path.GetFileName(fsPath);
            return fileName.EndsWith(".lua.txt", System.StringComparison.OrdinalIgnoreCase)
                ? fileName.Substring(0, fileName.Length - 4)
                : fileName;
        }

        private string GetLuaBaseName(string fsPath)
        {
            string fileName = System.IO.Path.GetFileName(fsPath);
            return fileName.EndsWith(".lua.txt", System.StringComparison.OrdinalIgnoreCase)
                ? fileName.Substring(0, fileName.Length - 8)
                : System.IO.Path.GetFileNameWithoutExtension(fileName);
        }

        private string GetLuaRelativePath(string fsPath)
        {
            if (string.IsNullOrEmpty(_luaRoot)) return fsPath;
            string root = _luaRoot.Replace('\\', '/').TrimEnd('/');
            string path = fsPath.Replace('\\', '/');
            return path.StartsWith(root + "/", System.StringComparison.OrdinalIgnoreCase)
                ? path.Substring(root.Length + 1)
                : path;
        }

        private bool IsGeneratedExtractAlias(string fsPath)
        {
            string fileName = System.IO.Path.GetFileName(fsPath);
            return fileName.IndexOf("branches-rel", System.StringComparison.OrdinalIgnoreCase) >= 0
                || fileName.IndexOf("__.lua", System.StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void LoadCriticalLuaBootModules()
        {
            // Source-backed boot dependencies observed in gốc Lua:
            // - WXHuShiCommon.lua ends with AttributeModule:Register(...)
            // - LevelTowerC.lua registers with FubenUIController at file load time
            // - PartnerEquipCommon/HorseSkill/ShenBingPu register extended equip
            //   modules through methods defined by ItemForEquip.lua
            // Loading these tables before the bulk scan matches the intended module
            // order without editing canonical Lua payloads.
            TryExecuteLuaRequirePath("CommonScript/Item/ItemForEquip.lua", "CriticalBoot");
            TryExecuteLuaRequirePath("CommonScript/AttributeModule/AttributeModule.lua", "CriticalBoot");
            TryExecuteLuaRequirePath("Script/Fuben/FubenUIController.lua", "CriticalBoot");
        }

        private bool TryExecuteLuaRequirePath(string requirePath, string logPrefix)
        {
            string key = NormalizeRequireKey(requirePath);
            if (!_basenameIndex.TryGetValue(key, out var fsPath))
            {
                Debug.LogWarning($"[LuaEngine] {logPrefix}: missing {requirePath} (key={key})");
                return false;
            }

            try
            {
                bool executed = ExecuteLuaFile(fsPath, key, GetLuaChunkName(fsPath), requirePath);
                Debug.Log($"[LuaEngine] {logPrefix}: {(executed ? "loaded" : "already-loaded")} {requirePath} -> {GetLuaRelativePath(fsPath)}");
                return executed;
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[LuaEngine] {logPrefix} FAIL {requirePath}: {e.Message}");
                return false;
            }
        }

        private bool ExecuteLuaFile(string fsPath, params string[] cacheKeys)
        {
            string fileName = System.IO.Path.GetFileName(fsPath);
            string baseName = GetLuaBaseName(fsPath);
            string relativePath = GetLuaRelativePath(fsPath);
            string chunkName = GetLuaChunkName(fsPath);

            if (_requireLoaded != null)
            {
                if (_requireLoaded.Contains(fileName) ||
                    _requireLoaded.Contains(baseName) ||
                    _requireLoaded.Contains(relativePath) ||
                    _requireLoaded.Contains(fsPath))
                {
                    return false;
                }
                if (cacheKeys != null)
                {
                    foreach (var key in cacheKeys)
                    {
                        if (!string.IsNullOrEmpty(key) && _requireLoaded.Contains(key)) return false;
                    }
                }
            }

            string text = System.IO.File.ReadAllText(fsPath);
            string contentHash = HashLuaText(text);
            if (_loadedLuaContentHashes != null && _loadedLuaContentHashes.Contains(contentHash))
            {
                MarkLuaLoaded(fsPath, cacheKeys, contentHash);
                return false;
            }

            Env.DoString(text, chunkName);
            MarkLuaLoaded(fsPath, cacheKeys, contentHash);
            return true;
        }

        private void MarkLuaLoaded(string fsPath, string[] cacheKeys, string contentHash)
        {
            if (_requireLoaded != null)
            {
                _requireLoaded.Add(System.IO.Path.GetFileName(fsPath));
                _requireLoaded.Add(GetLuaBaseName(fsPath));
                _requireLoaded.Add(GetLuaRelativePath(fsPath));
                _requireLoaded.Add(fsPath);
                if (cacheKeys != null)
                {
                    foreach (var key in cacheKeys)
                    {
                        if (!string.IsNullOrEmpty(key)) _requireLoaded.Add(key);
                    }
                }
            }
            if (_loadedLuaContentHashes != null && !string.IsNullOrEmpty(contentHash))
            {
                _loadedLuaContentHashes.Add(contentHash);
            }
        }

        private string HashLuaText(string text)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text ?? string.Empty);
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                return System.Convert.ToBase64String(sha1.ComputeHash(bytes));
            }
        }

        /// <summary>
        /// Port of native LuaClient::Init3/Init4 semantics:
        ///   Init3 -> XLuaGroup::LoadScriptInDirectory("CommonScript", 1)
        ///   Init4 -> XLuaGroup::LoadScriptInDirectory("Script", 1)
        ///
        /// The APK extract is flattened into `.lua.txt` files. Script files keep a
        /// `Script_` prefix; CommonScript files usually do not. Some extract aliases
        /// duplicate the exact same payload under UI/module folders, so content-hash
        /// filtering prevents the same script from registering events twice.
        /// </summary>
        private void LoadCanonicalLuaDirectories()
        {
            if (!System.IO.Directory.Exists(_luaRoot))
            {
                Debug.LogWarning($"[LuaEngine] LoadCanonicalLuaDirectories: Lua root not found: {_luaRoot}");
                return;
            }
            string[] paths = System.IO.Directory.GetFiles(_luaRoot, "*.lua.txt", System.IO.SearchOption.AllDirectories);
            System.Array.Sort(paths, System.StringComparer.OrdinalIgnoreCase);
            if (paths.Length == 0)
            {
                Debug.LogWarning("[LuaEngine] LoadCanonicalLuaDirectories: no .lua.txt files found");
                return;
            }

            var scriptContentHashes = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase);
            foreach (var fsPath in paths)
            {
                if (IsGeneratedExtractAlias(fsPath)) continue;
                if (!GetLuaBaseName(fsPath).StartsWith("Script_", System.StringComparison.OrdinalIgnoreCase)) continue;
                scriptContentHashes.Add(HashLuaText(System.IO.File.ReadAllText(fsPath)));
            }

            var commonCandidates = new List<string>();
            var scriptCandidates = new List<string>();
            int skippedGenerated = 0;
            int skippedAlias = 0;
            foreach (var fsPath in paths)
            {
                if (IsGeneratedExtractAlias(fsPath))
                {
                    skippedGenerated++;
                    continue;
                }

                bool isScript = GetLuaBaseName(fsPath).StartsWith("Script_", System.StringComparison.OrdinalIgnoreCase);
                if (isScript)
                {
                    scriptCandidates.Add(fsPath);
                    continue;
                }

                string hash = HashLuaText(System.IO.File.ReadAllText(fsPath));
                if (scriptContentHashes.Contains(hash))
                {
                    skippedAlias++;
                    continue;
                }
                commonCandidates.Add(fsPath);
            }

            var pending = new List<string>(commonCandidates.Count + scriptCandidates.Count);
            pending.AddRange(commonCandidates);
            pending.AddRange(scriptCandidates);

            int passLimit = 10;
            int pass = 0;
            int executedTotal = 0;
            int skippedLoadedTotal = 0;

            Debug.Log($"[LuaEngine] LoadCanonicalLuaDirectories candidates: common={commonCandidates.Count}, script={scriptCandidates.Count}, skippedGenerated={skippedGenerated}, skippedDuplicateAliases={skippedAlias}");

            while (pass < passLimit && pending.Count > 0)
            {
                pass++;
                var stillPending = new List<string>();
                int executedThisPass = 0;
                int skippedLoadedThisPass = 0;
                foreach (var fsPath in pending)
                {
                    try
                    {
                        if (ExecuteLuaFile(fsPath, GetLuaBaseName(fsPath), GetLuaRelativePath(fsPath)))
                        {
                            executedThisPass++;
                        }
                        else
                        {
                            skippedLoadedThisPass++;
                        }
                    }
                    catch (System.Exception)
                    {
                        stillPending.Add(fsPath);
                    }
                }
                executedTotal += executedThisPass;
                skippedLoadedTotal += skippedLoadedThisPass;
                Debug.Log($"[LuaEngine] LoadCanonicalLuaDirectories pass {pass}: +{executedThisPass} executed, {skippedLoadedThisPass} already-loaded/duplicate, {stillPending.Count} pending");
                if (executedThisPass == 0 && skippedLoadedThisPass == 0)
                {
                    Debug.LogWarning($"[LuaEngine] LoadCanonicalLuaDirectories pass {pass}: no progress, {stillPending.Count} files still failing — surfacing real errors");
                    foreach (var fsPath in stillPending)
                    {
                        try
                        {
                            ExecuteLuaFile(fsPath, GetLuaBaseName(fsPath), GetLuaRelativePath(fsPath));
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogError($"[LuaEngine] LoadCanonicalLuaDirectories FAIL {GetLuaChunkName(fsPath)}: {e.Message}");
                        }
                    }
                    break;
                }
                pending = stillPending;
            }
            int finalRemaining = pending.Count;
            Debug.Log($"[LuaEngine] LoadCanonicalLuaDirectories done: executed={executedTotal}, skippedLoadedOrDuplicate={skippedLoadedTotal}, sourceFiles={paths.Length}, passes={pass}, unresolved={finalRemaining}");
        }

        // Custom Lua loader: maps `require("login.UILogin")` → Resources/Lua/login/UILogin.lua.txt
        // 2026-04-26 NOTE: Resources API broken for .lua.txt — read filesystem directly.
        // gốc analog: native LuaScriptManager::LoadScript reads from filesystem path; we mirror behavior.
        private byte[] LoadFromResources(ref string filepath)
        {
            if (string.IsNullOrEmpty(filepath)) return null;
            if (string.IsNullOrEmpty(_luaRoot))
            {
                _luaRoot = System.IO.Path.Combine(UnityEngine.Application.dataPath, "_Project/Resources/Lua");
            }

            // Convert Lua require path to relative filesystem path under _luaRoot
            // Example: "commonui.Script_Client" → "commonui/Script_Client"
            string rel = filepath.Replace('.', '/');

            // Try .lua.txt extension first (gốc convention — files on disk are .lua.txt)
            string p1 = System.IO.Path.Combine(_luaRoot, rel + ".lua.txt");
            if (System.IO.File.Exists(p1)) return System.IO.File.ReadAllBytes(p1);

            // Fallback: .txt only (in case any file uses bare .txt)
            string p2 = System.IO.Path.Combine(_luaRoot, rel + ".txt");
            if (System.IO.File.Exists(p2)) return System.IO.File.ReadAllBytes(p2);

            return null;
        }

        void Update()
        {
            // Required by XLua to tick its garbage collector
            Env?.Tick();
        }

        void OnDestroy()
        {
            foreach (var view in UnityEngine.Object.FindObjectsOfType<Game.UI.UIView>(true))
            {
                view.ReleaseLuaReferences();
            }
            foreach (var panel in UnityEngine.Object.FindObjectsOfType<Game.UI.UIPanel>(true))
            {
                panel.ReleaseLuaReferences();
            }
            LuaEventBridge.Reset();
            ThanMaOrigin.Network.CmdRegistry.Reset();
            CppModule._LuaEnv = null;
            Env?.Dispose();
            Env = null;
            if (Instance == this) Instance = null;
        }

        // ─── cjson Newtonsoft.Json bridge ─────────────────────────────────
        // gốc cjson behavior emulated 1-1:
        //   cjson.decode(szJson) → real Lua table (object→hash, array→list keyed [1..n])
        //   cjson.encode(tb)     → JSON string. Lua array detected via consecutive integer keys.
        //   cjson.encode_sparse_array()        → returns current bool flag
        //   cjson.encode_sparse_array(boolVal) → sets flag, returns previous
        // Sparse-array flag is a no-op encoder hint in our Newtonsoft impl (Newtonsoft already
        // encodes sparse arrays as objects by default). Stored to honor get/set roundtrip
        // expected by lib.lua:2038-2046 / Script_LocalData.lua:366-373.
        private bool _cjsonEncodeSparseArray = false;

        private void BindCjson()
        {
            var cjsonTbl = Env.NewTable();

            System.Func<string, object> decodeFn = (s) =>
            {
                if (string.IsNullOrEmpty(s) || s == "null") return null;
                try
                {
                    var token = Newtonsoft.Json.Linq.JToken.Parse(s);
                    return JTokenToLua(token);
                }
                catch (System.Exception e)
                {
                    Debug.LogWarning($"[cjson.decode] {e.Message} (input first 80: {(s.Length>80?s.Substring(0,80):s)})");
                    return null;
                }
            };

            System.Func<object, string> encodeFn = (o) =>
            {
                try { return LuaToJsonString(o); }
                catch (System.Exception e) { Debug.LogWarning($"[cjson.encode] {e.Message}"); return "null"; }
            };

            // gốc cjson.encode_sparse_array: getter when no arg, setter when bool passed.
            // XLua doesn't allow optional bool nicely → bind two overloads via Lua thunk.
            cjsonTbl.Set<string, System.Func<string, object>>("decode", decodeFn);
            cjsonTbl.Set<string, System.Func<object, string>>("encode", encodeFn);
            // Aliases used by Lib:DecodeJson / Lib:EncodeJson (lib.lua:2029-2034).
            cjsonTbl.Set<string, System.Func<string, object>>("DecodeJson", decodeFn);
            cjsonTbl.Set<string, System.Func<object, string>>("EncodeJson", encodeFn);

            // encode_sparse_array — getter or setter via single varargs param.
            // Lua call: cjson.encode_sparse_array() or cjson.encode_sparse_array(true)
            cjsonTbl.Set<string, System.Func<object, bool>>("encode_sparse_array", (val) =>
            {
                bool prev = _cjsonEncodeSparseArray;
                if (val != null && val is bool b) _cjsonEncodeSparseArray = b;
                return prev;
            });

            Env.Global.Set("cjson", cjsonTbl);
        }

        // Convert JToken → Lua-friendly value. JObject → LuaTable (string keys).
        // JArray → LuaTable (1-based int keys, gốc cjson convention).
        // Primitives → C# primitives (XLua marshals to Lua number/string/bool).
        private object JTokenToLua(Newtonsoft.Json.Linq.JToken token)
        {
            if (token == null) return null;
            switch (token.Type)
            {
                case Newtonsoft.Json.Linq.JTokenType.Object:
                {
                    var tbl = Env.NewTable();
                    foreach (var prop in (Newtonsoft.Json.Linq.JObject)token)
                    {
                        var luaVal = JTokenToLua(prop.Value);
                        SetLuaTableValue(tbl, prop.Key, luaVal);
                    }
                    return tbl;
                }
                case Newtonsoft.Json.Linq.JTokenType.Array:
                {
                    var tbl = Env.NewTable();
                    int i = 1; // gốc cjson: arrays are 1-based Lua tables
                    foreach (var item in (Newtonsoft.Json.Linq.JArray)token)
                    {
                        var luaVal = JTokenToLua(item);
                        SetLuaTableValue(tbl, i, luaVal);
                        i++;
                    }
                    return tbl;
                }
                case Newtonsoft.Json.Linq.JTokenType.Integer: return token.ToObject<long>();
                case Newtonsoft.Json.Linq.JTokenType.Float:   return token.ToObject<double>();
                case Newtonsoft.Json.Linq.JTokenType.String:  return token.ToObject<string>();
                case Newtonsoft.Json.Linq.JTokenType.Boolean: return token.ToObject<bool>();
                case Newtonsoft.Json.Linq.JTokenType.Null:    return null;
                default: return token.ToString();
            }
        }

        // Set value into LuaTable handling both string and int keys + nested LuaTable values.
        private void SetLuaTableValue(LuaTable tbl, object key, object value)
        {
            if (value == null)
            {
                // XLua: setting nil clears the key
                if (key is string sk) tbl.Set<string, object>(sk, null);
                else if (key is int ik) tbl.Set<int, object>(ik, null);
                return;
            }
            if (key is string skey)
            {
                if (value is LuaTable lt) tbl.Set<string, LuaTable>(skey, lt);
                else if (value is long lv) tbl.Set<string, long>(skey, lv);
                else if (value is double dv) tbl.Set<string, double>(skey, dv);
                else if (value is bool bv) tbl.Set<string, bool>(skey, bv);
                else if (value is string sv) tbl.Set<string, string>(skey, sv);
                else tbl.Set<string, object>(skey, value);
            }
            else if (key is int ikey)
            {
                if (value is LuaTable lt) tbl.Set<int, LuaTable>(ikey, lt);
                else if (value is long lv) tbl.Set<int, long>(ikey, lv);
                else if (value is double dv) tbl.Set<int, double>(ikey, dv);
                else if (value is bool bv) tbl.Set<int, bool>(ikey, bv);
                else if (value is string sv) tbl.Set<int, string>(ikey, sv);
                else tbl.Set<int, object>(ikey, value);
            }
        }

        private static int MapGatewayStatusToLoginServerType(byte status)
        {
            switch (status)
            {
                case 0: return 1; // Login.SERVER_TYPE_OFFLINE
                case 1: return 0; // Login.SERVER_TYPE_NORMAL
                case 2: return 4; // Login.SERVER_TYPE_FULL
                case 3: return 2; // Login.SERVER_TYPE_RECOMMEND
                case 4: return 3; // Login.SERVER_TYPE_NEW
                default: return 0;
            }
        }

        // Convert Lua value (LuaTable / primitive) → JSON string.
        // Detect array vs object: LuaTable with consecutive int keys [1..n] = array.
        private string LuaToJsonString(object value)
        {
            var token = LuaToJToken(value);
            return token == null ? "null" : token.ToString(Newtonsoft.Json.Formatting.None);
        }

        private Newtonsoft.Json.Linq.JToken LuaToJToken(object value)
        {
            if (value == null) return Newtonsoft.Json.Linq.JValue.CreateNull();
            if (value is LuaTable lt)
            {
                // Inspect keys: consecutive ints starting at 1 → array.
                var keys = new List<object>();
                lt.ForEach<object, object>((k, v) => keys.Add(k));
                bool isArray = keys.Count > 0;
                int maxIdx = 0;
                foreach (var k in keys)
                {
                    if (k is long lk) { if (lk < 1 || lk != (long)(int)lk) { isArray = false; break; } if ((int)lk > maxIdx) maxIdx = (int)lk; }
                    else if (k is double dk) { if (dk < 1 || dk != System.Math.Floor(dk)) { isArray = false; break; } if ((int)dk > maxIdx) maxIdx = (int)dk; }
                    else if (k is int ik) { if (ik < 1) { isArray = false; break; } if (ik > maxIdx) maxIdx = ik; }
                    else { isArray = false; break; }
                }
                if (isArray && maxIdx == keys.Count)
                {
                    var arr = new Newtonsoft.Json.Linq.JArray();
                    for (int i = 1; i <= maxIdx; i++)
                    {
                        var v = lt.Get<int, object>(i);
                        arr.Add(LuaToJToken(v));
                    }
                    return arr;
                }
                else
                {
                    var obj = new Newtonsoft.Json.Linq.JObject();
                    lt.ForEach<object, object>((k, v) =>
                    {
                        string sk = k?.ToString() ?? "";
                        obj[sk] = LuaToJToken(v);
                    });
                    return obj;
                }
            }
            // Primitives — XLua hands us boxed long/double/bool/string.
            if (value is bool b)   return new Newtonsoft.Json.Linq.JValue(b);
            if (value is long l)   return new Newtonsoft.Json.Linq.JValue(l);
            if (value is int i32)  return new Newtonsoft.Json.Linq.JValue((long)i32);
            if (value is double d) return new Newtonsoft.Json.Linq.JValue(d);
            if (value is float f)  return new Newtonsoft.Json.Linq.JValue((double)f);
            if (value is string s) return new Newtonsoft.Json.Linq.JValue(s);
            // Fallback: ToString
            return new Newtonsoft.Json.Linq.JValue(value.ToString());
        }
    }
}
