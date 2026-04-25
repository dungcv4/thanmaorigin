// File: Assets/_Project/Scripts/Lua/LuaEngine.cs
// Author: thanmaorigin port (NOT in IL2CPP — gốc dùng native libclient_scene.so)
// Source ref: KTO_LibClientScene_Decompiled (LuaRegisterTimerPoint et al.)
//
// LuaEngine = bridge layer between Unity C# and gốc Lua scripts.
// Hosts the XLua LuaEnv singleton + provides Init/Tick/Shutdown.
//
// Phase 1 minimal stub: just creates LuaEnv + provides global access for CppModule.
// Phase 3+ extend with: load order, eager-load, CmdRegistry, EventNotify, etc.

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

            Debug.Log("[thanmaorigin.LuaEngine] Awake — XLua initialized + bridges wired (Phase 8: 777 native bindings)");
        }

        // Custom Lua loader: maps `require("login.UILogin")` → Resources/Lua/login/UILogin.lua.txt
        private byte[] LoadFromResources(ref string filepath)
        {
            // Convert Lua require path to Resources path
            // Example input: "login.UILogin" or "login/UILogin"
            string resourcePath = filepath.Replace('.', '/');
            var ta = Resources.Load<TextAsset>($"Lua/{resourcePath}");
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
