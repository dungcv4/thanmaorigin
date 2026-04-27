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

            // Bind i18n methods AFTER preload too. Script_i18n_i18n.lua sets metatable
            // __index = LanguageModule, but XLua's Type wrapper doesn't always fall through
            // for index-via-metatable. Override directly with C# delegates pointing to
            // LanguageModule static methods (1-1 with gốc binding).
            BindI18nTable();

            // Eager-load all Lua scripts. KLib/Sdk/i18n references resolve via _ENV.
            LoadAllLua();

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
            _basenameIndex = new Dictionary<string, string>();
            if (System.IO.Directory.Exists(_luaRoot))
            {
                foreach (var path in System.IO.Directory.GetFiles(_luaRoot, "*.lua.txt", System.IO.SearchOption.AllDirectories))
                {
                    string baseName = System.IO.Path.GetFileName(path); // "Script_X.lua.txt"
                    if (baseName.EndsWith(".lua.txt")) baseName = baseName.Substring(0, baseName.Length - 8);
                    _basenameIndex[baseName] = path;
                }
            }
            else
            {
                Debug.LogError($"[LuaEngine] Lua root not found: {_luaRoot}");
            }
            _requireLoaded = new HashSet<string>();

            // Bind Require to a lambda that:
            //   1. Normalizes path: drop "CommonScript/" prefix; replace "/" with "_"; strip ".lua".
            //   2. Looks up in _basenameIndex.
            //   3. Skips if already loaded.
            //   4. Executes via DoString.
            System.Action<string> requireFn = (string path) =>
            {
                if (string.IsNullOrEmpty(path)) return;
                string key = path;
                // Drop "CommonScript/" prefix per gốc convention
                if (key.StartsWith("CommonScript/")) key = key.Substring("CommonScript/".Length);
                // "Script/" prefix is KEPT in flattened name, do NOT strip.
                key = key.Replace('/', '_');
                if (key.EndsWith(".lua")) key = key.Substring(0, key.Length - 4);

                if (_basenameIndex.TryGetValue(key, out var fsPath))
                {
                    string chunkName = System.IO.Path.GetFileName(fsPath);
                    if (_requireLoaded.Contains(chunkName)) return;
                    _requireLoaded.Add(chunkName);
                    try
                    {
                        string text = System.IO.File.ReadAllText(fsPath);
                        Env.DoString(text, chunkName);
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogError($"[Require] {chunkName}: {e.Message}");
                    }
                }
                else
                {
                    Debug.LogWarning($"[Require] not found: '{path}' (key={key})");
                }
            };
            Env.Global.Set<string, System.Action<string>>("Require", requireFn);
        }

        /// <summary>
        /// Eager-load all Lua scripts từ Resources/Lua/. Multi-pass to resolve
        /// inter-file dependencies (file A may use globals defined in file B).
        ///
        /// 1-1 port của gốc XLuaGroup::LoadScriptInDirectory @ libclient_scene.so:0x2efcd0.
        /// </summary>
        private void LoadAllLua()
        {
            // Direct filesystem walk — Resources.LoadAll<TextAsset> returns 0 for .lua.txt
            // in Unity 2022.3.62f2. Bypass with System.IO.Directory.GetFiles which works
            // identically to gốc native filesystem walk.
            if (!System.IO.Directory.Exists(_luaRoot))
            {
                Debug.LogWarning($"[LuaEngine] LoadAllLua: Lua root not found: {_luaRoot}");
                return;
            }
            string[] paths = System.IO.Directory.GetFiles(_luaRoot, "*.lua.txt", System.IO.SearchOption.AllDirectories);
            if (paths.Length == 0)
            {
                Debug.LogWarning("[LuaEngine] LoadAllLua: no .lua.txt files found");
                return;
            }

            var pending = new List<string>(paths);
            int passLimit = 10; // gốc handoff: 3 passes typical; bump for deep dep chains
            int pass = 0;
            int loadedTotal = 0;
            int failedFinal = 0;

            while (pass < passLimit && pending.Count > 0)
            {
                pass++;
                var stillPending = new List<string>();
                int loadedThisPass = 0;
                foreach (var fsPath in pending)
                {
                    string fileName = System.IO.Path.GetFileName(fsPath); // e.g. "Script_Client.lua.txt"
                    string chunkName = fileName.EndsWith(".lua.txt")
                        ? fileName.Substring(0, fileName.Length - 4) // → "Script_Client.lua"
                        : fileName;
                    // Skip if already loaded via Require during a prior pass
                    if (_requireLoaded != null && _requireLoaded.Contains(fileName))
                    {
                        loadedThisPass++;
                        continue;
                    }
                    try
                    {
                        string text = System.IO.File.ReadAllText(fsPath);
                        Env.DoString(text, chunkName);
                        if (_requireLoaded != null) _requireLoaded.Add(fileName);
                        loadedThisPass++;
                    }
                    catch (System.Exception)
                    {
                        // Some files fail because deps not yet defined. Retry next pass.
                        stillPending.Add(fsPath);
                    }
                }
                loadedTotal += loadedThisPass;
                Debug.Log($"[LuaEngine] LoadAllLua pass {pass}: +{loadedThisPass} loaded, {stillPending.Count} pending");
                if (loadedThisPass == 0)
                {
                    // No progress — remaining files have genuine errors. Log + abort retry loop.
                    failedFinal = stillPending.Count;
                    Debug.LogWarning($"[LuaEngine] LoadAllLua pass {pass}: no progress, {failedFinal} files still failing — surfacing real errors");
                    foreach (var fsPath in stillPending)
                    {
                        string fileName = System.IO.Path.GetFileName(fsPath);
                        string chunkName = fileName.EndsWith(".lua.txt") ? fileName.Substring(0, fileName.Length - 4) : fileName;
                        try
                        {
                            string text = System.IO.File.ReadAllText(fsPath);
                            Env.DoString(text, chunkName);
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogError($"[LuaEngine] LoadAllLua FAIL {chunkName}: {e.Message}");
                        }
                    }
                    break;
                }
                pending = stillPending;
            }
            int finalRemaining = pending.Count;
            Debug.Log($"[LuaEngine] LoadAllLua done: {loadedTotal}/{paths.Length} loaded across {pass} passes ({finalRemaining} unresolved)");
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
            Env?.Dispose();
            Env = null;
            if (Instance == this) Instance = null;
        }
    }
}
