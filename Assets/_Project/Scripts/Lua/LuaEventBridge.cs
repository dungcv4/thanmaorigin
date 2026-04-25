// File: Assets/_Project/Scripts/Lua/LuaEventBridge.cs
// Bridge: C# event source → Lua subscribers (gốc EventNotify pattern).
// Source ref: KTO_LibClientScene_Decompiled (LuaServerRemoteCallEntry + EventNotify dispatch chain).
//
// Gốc fires events via CppApi.OnEvent → Lua's EventNotify.OnNotify(eventId, params).
// thanmaorigin: bridge from C# code (e.g. SceneLoadManager) → fire to gốc EventNotify Lua module.

using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace ThanMaOrigin.Lua
{
    public static class LuaEventBridge
    {
        // Cache resolved EventNotify.OnNotify function from Lua side.
        private static LuaFunction _onNotify;

        private static LuaFunction GetOnNotify()
        {
            if (_onNotify != null) return _onNotify;
            var env = LuaEngine.Instance?.Env;
            if (env == null) return null;
            var en = env.Global.Get<LuaTable>("EventNotify");
            if (en == null) return null;
            _onNotify = en.Get<LuaFunction>("OnNotify");
            return _onNotify;
        }

        /// <summary>
        /// Fire event by integer enum id. Equivalent to gốc `EventNotify.OnNotify(nEvent, params)`.
        /// </summary>
        public static void Fire(int eventId, params object[] args)
        {
            var fn = GetOnNotify();
            if (fn == null) return;
            // Prepend eventId to args
            var allArgs = new object[args.Length + 1];
            allArgs[0] = eventId;
            for (int i = 0; i < args.Length; i++) allArgs[i + 1] = args[i];
            try { fn.Call(allArgs); }
            catch (System.Exception e) { Debug.LogError($"[LuaEventBridge.Fire] {e.Message}"); }
        }

        /// <summary>
        /// Fire event by Lua enum NAME (looks up emNOTIFY_X value at call time).
        /// Avoids C# enum drift risk per session 2026-04-24 handoff.
        /// </summary>
        public static void FireByLuaEnumName(string enumName, params object[] args)
        {
            var env = LuaEngine.Instance?.Env;
            if (env == null) return;
            // gốc: EventNotify.emNOTIFY_<X> — integer constants on EventNotify table.
            var en = env.Global.Get<LuaTable>("EventNotify");
            if (en == null) { Debug.LogWarning($"[LuaEventBridge] EventNotify not loaded"); return; }
            int nEvent = en.Get<int>(enumName);
            if (nEvent == 0)
            {
                Debug.LogWarning($"[LuaEventBridge] Lua enum {enumName} = 0 (not registered yet?)");
            }
            Fire(nEvent, args);
        }

        /// <summary>
        /// Reset cache when Lua VM reloads.
        /// </summary>
        public static void Reset()
        {
            _onNotify?.Dispose();
            _onNotify = null;
        }
    }
}
