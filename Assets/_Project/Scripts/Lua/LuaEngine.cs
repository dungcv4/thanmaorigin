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

            // Bind `Require(path)` global — gốc native C function (string at libclient_scene.so:0x106963).
            //   gốc syntax: Require("Script/EventSystem/EventNotify.lua") or
            //               Require("CommonScript/Item/ItemDefine.lua")
            //   Behavior: load + execute file once (cached). Path is gốc filesystem path.
            // DEVIATION: thanmaorigin Resources/Lua flat structure — basename map, see BindRequire.
            BindRequire();

            Debug.Log("[thanmaorigin.LuaEngine] Awake — XLua initialized + bridges wired (Phase 8: 777 native bindings)");

            // Run gốc boot preload FIRST — this is gốc's manifest file.
            // It defines all global tables (EventNotify, Operation, Login, ...) via
            // tbPreGlobalTable + _ENV manipulation, and Require()s critical files in
            // correct dep order (lib.lua, Item.lua, Ui.lua, UI*.lua, ...).
            // Without preload running first, every subsequent file fails because their
            // globals don't exist.
            // Cite: thanmaorigin/Resources/Lua/commonui/Script_preload.lua.txt
            //       gốc origin: Script/preload.lua (entry script per gốc convention)
            RunPreload();

            // Eager-load all Lua scripts before user-Lua runs.
            // 1-1 port của gốc native boot chain:
            //   LuaClient::Init(path)   @ libclient_scene.so:0x235d90 — registers C funcs
            //   LuaClient::LoadDir(path)@ 0x23618c (3-insn wrapper)
            //     → XLuaGroup::LoadScriptInDirectory(path, recursive=1) @ 0x2efcd0
            //       — recursively loads all .lua files in directory
            // Caller chain ends with all globals (Lib, Timer, Ui, EventNotify, ...) defined.
            // DEVIATION: filesystem walk → Unity Resources.LoadAll<TextAsset>("Lua") (XLua framework
            //   constraint: assets bundled into Resources/, no real filesystem at runtime). Behavior
            //   identical: load every Lua file before any user Lua executes.
            // Multi-pass solves dep order without manifest (per LUA_RUNTIME_PORT_SESSION handoff
            //   "Phase 2 multi-pass eager-load" — files mostly self-contained, retry resolves).
            LoadAllLua();
        }

        /// <summary>
        /// Run Script_preload.lua first. It defines all global tables + Requires() critical
        /// files in dep order. Cite: gốc Script/preload.lua entry script convention.
        /// </summary>
        private void RunPreload()
        {
            var preload = Resources.Load<TextAsset>("Lua/commonui/Script_preload.lua");
            if (preload == null)
            {
                Debug.LogError("[LuaEngine] RunPreload: Script_preload.lua NOT FOUND at Resources/Lua/commonui/");
                return;
            }
            try
            {
                Env.DoString(preload.text, "Script_preload.lua");
                if (_requireLoaded != null) _requireLoaded.Add(preload.name);
                Debug.Log("[LuaEngine] RunPreload: Script_preload.lua executed");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"[LuaEngine] RunPreload FAIL: {e.Message}");
            }
        }

        // Basename → TextAsset index built once, reused by Require().
        // Key = asset name without trailing ".lua" (e.g. "Script_EventSystem_EventNotify").
        private Dictionary<string, TextAsset> _basenameIndex;
        private HashSet<string> _requireLoaded;

        /// <summary>
        /// Bind `Require(path)` Lua global — gốc native function exposed via libclient_scene.so.
        /// Path is gốc-style: `Script/Foo/Bar.lua` or `CommonScript/Foo/Bar.lua`.
        /// Maps to thanmaorigin's flat naming: `Script/X/Y.lua` → `Script_X_Y.lua` file;
        ///                                      `CommonScript/X/Y.lua` → `X_Y.lua` (drop CommonScript prefix).
        /// </summary>
        private void BindRequire()
        {
            // Build basename index from Resources/Lua/. One-shot scan.
            var assets = Resources.LoadAll<TextAsset>("Lua");
            _basenameIndex = new Dictionary<string, TextAsset>(assets.Length);
            foreach (var ta in assets)
            {
                string baseName = ta.name; // Unity strips ".txt" → e.g. "Script_X.lua"
                if (baseName.EndsWith(".lua")) baseName = baseName.Substring(0, baseName.Length - 4);
                _basenameIndex[baseName] = ta;
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

                if (_basenameIndex.TryGetValue(key, out var ta))
                {
                    if (_requireLoaded.Contains(ta.name)) return;
                    _requireLoaded.Add(ta.name);
                    try { Env.DoString(ta.text, ta.name); }
                    catch (System.Exception e)
                    {
                        Debug.LogError($"[Require] {ta.name}: {e.Message}");
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
            var assets = Resources.LoadAll<TextAsset>("Lua");
            if (assets == null || assets.Length == 0)
            {
                Debug.LogWarning("[LuaEngine] LoadAllLua: no Lua assets found under Resources/Lua/");
                return;
            }

            // Build path map: TextAsset.name = "<basename>.lua" (Unity strips .txt last).
            // Need Resources.Load path with extension to find Asset's full Resources-relative path.
            // Easier: just track the asset object + name; XLua DoString takes raw bytes.
            var pending = new List<TextAsset>(assets);
            int passLimit = 10; // gốc handoff: 3 passes typical; bump for deep dep chains
            int pass = 0;
            int loadedTotal = 0;
            int failedFinal = 0;

            while (pass < passLimit && pending.Count > 0)
            {
                pass++;
                var stillPending = new List<TextAsset>();
                int loadedThisPass = 0;
                foreach (var ta in pending)
                {
                    string chunkName = ta.name; // e.g. "Script_Client.lua"
                    // Skip if already loaded via Require during a prior pass
                    if (_requireLoaded != null && _requireLoaded.Contains(ta.name))
                    {
                        loadedThisPass++;
                        continue;
                    }
                    try
                    {
                        Env.DoString(ta.text, chunkName);
                        if (_requireLoaded != null) _requireLoaded.Add(ta.name);
                        loadedThisPass++;
                    }
                    catch (System.Exception)
                    {
                        // Some files fail because deps not yet defined. Retry next pass.
                        stillPending.Add(ta);
                    }
                }
                loadedTotal += loadedThisPass;
                Debug.Log($"[LuaEngine] LoadAllLua pass {pass}: +{loadedThisPass} loaded, {stillPending.Count} pending");
                if (loadedThisPass == 0)
                {
                    // No progress — remaining files have genuine errors. Log + abort retry loop.
                    failedFinal = stillPending.Count;
                    Debug.LogWarning($"[LuaEngine] LoadAllLua pass {pass}: no progress, {failedFinal} files still failing — surfacing real errors");
                    foreach (var ta in stillPending)
                    {
                        try { Env.DoString(ta.text, ta.name); }
                        catch (System.Exception e)
                        {
                            Debug.LogError($"[LuaEngine] LoadAllLua FAIL {ta.name}: {e.Message}");
                        }
                    }
                    break;
                }
                pending = stillPending;
            }
            int finalRemaining = pending.Count;
            Debug.Log($"[LuaEngine] LoadAllLua done: {loadedTotal}/{assets.Length} loaded across {pass} passes ({finalRemaining} unresolved)");
        }

        // Custom Lua loader: maps `require("login.UILogin")` → Resources/Lua/login/UILogin.lua.txt
        // Files on disk are *.lua.txt — Unity strips trailing .txt so asset name = "X.lua".
        // Resources.Load<TextAsset>("Lua/login/UILogin.lua") matches the trailing .lua.
        private byte[] LoadFromResources(ref string filepath)
        {
            // Convert Lua require path to Resources path
            // Example input: "login.UILogin" or "login/UILogin"
            string resourcePath = filepath.Replace('.', '/');

            // Try with explicit .lua suffix first (matches *.lua.txt → asset name *.lua)
            var ta = Resources.Load<TextAsset>($"Lua/{resourcePath}.lua");
            if (ta == null)
            {
                // Fallback: bare name (covers *.txt-only files if any)
                ta = Resources.Load<TextAsset>($"Lua/{resourcePath}");
            }
            if (ta == null) return null;
            return ta.bytes;
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
