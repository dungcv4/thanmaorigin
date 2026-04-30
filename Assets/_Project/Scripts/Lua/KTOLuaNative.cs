// File: Assets/_Project/Scripts/Lua/KTOLuaNative.cs
// Native Lua binding ports — gốc lives in libclient_scene.so.
// Source: KTO_LibClientScene_Decompiled/INDEX.tsv (1112 Lua-binding functions).
//
// Most are XLua-handled in our DEVIATION. These are essential helpers that Lua scripts call.

using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace ThanMaOrigin.Lua
{
    public static class KTOLuaNative
    {
        // VMA: 0x23660c — libclient_scene.so `_ZN24LuaGlobalScriptNameSpace21LuaRegisterTimerPointER10XLuaScript`
        // gốc: register a Lua function to fire after N logic frames (uses CppModule.m_nLogicFrame counter).
        // DEVIATION: use Unity Coroutine instead.
        private static readonly Dictionary<int, System.Action> _timerPoints = new Dictionary<int, System.Action>();
        private static int _nextTimerId = 1;

        public static int LuaRegisterTimerPoint(int frames, LuaFunction fn)
        {
            if (fn == null || frames < 0) return 0;
            int id = _nextTimerId++;
            // Convert frames (gốc 18Hz logic frames) to time
            float waitSec = frames / 18f;
            var le = LuaEngine.Instance;
            if (le != null)
            {
                le.StartCoroutine(FireAfter(id, waitSec, () =>
                {
                    try { fn.Call(); }
                    catch (System.Exception e) { Debug.LogError($"[TimerPoint {id}] {e.Message}"); }
                }));
            }
            return id;
        }

        private static System.Collections.IEnumerator FireAfter(int id, float sec, System.Action cb)
        {
            yield return new WaitForSeconds(sec);
            cb?.Invoke();
            _timerPoints.Remove(id);
        }

        // VMA: 0x238520 — libclient_scene.so `_ZN24LuaGlobalScriptNameSpace12LuaGetLuaTopER10XLuaScript`
        // gốc: return current Lua stack depth via lua_gettop(L).
        // DEVIATION: XLua doesn't expose lua_gettop directly — return 0.
        public static int LuaGetLuaTop() => 0;

        // VMA: 0x239408 — libclient_scene.so `_ZN24LuaGlobalScriptNameSpace12LuaIsPayOpenER10XLuaScript`
        // gốc: check if payment system enabled (Tencent SDK flag).
        // DEVIATION: skip Tencent SDK — always false (private server, no real payment).
        public static bool LuaIsPayOpen() => false;

        /// <summary>
        /// Bind these helpers as Lua globals. Call after LuaEngine init.
        ///
        /// Naming convention: Lua-side name (NO `Lua` prefix) per gốc rodata strings:
        ///   "RegisterTimerPoint" @ libclient_scene.so rodata 0x0f64de
        ///   "GetLuaTop"          @ rodata (inferred — convention mirror of LuaGetLuaTop@0x238520)
        ///   "IsPayOpen"          @ rodata (inferred mirror of LuaIsPayOpen)
        /// C++ class methods are named `LuaX` (registry helpers); Lua-callable globals drop the prefix.
        /// </summary>
        public static void BindLua(LuaEnv env)
        {
            if (env == null) return;
            // Lua-callable global names (no "Lua" prefix) — match gốc rodata
            env.Global.Set<string, System.Func<int, LuaFunction, int>>("RegisterTimerPoint", LuaRegisterTimerPoint);
            env.Global.Set<string, System.Func<int>>("GetLuaTop", LuaGetLuaTop);
            env.Global.Set<string, System.Func<bool>>("IsPayOpen", LuaIsPayOpen);
            // Backwards-compat aliases (in case any code calls the C++-style names)
            env.Global.Set<string, System.Func<int, LuaFunction, int>>("LuaRegisterTimerPoint", LuaRegisterTimerPoint);
            env.Global.Set<string, System.Func<int>>("LuaGetLuaTop", LuaGetLuaTop);
            env.Global.Set<string, System.Func<bool>>("LuaIsPayOpen", LuaIsPayOpen);

            // Bind `Log` globals — gốc native libclient_scene.so accepts Lua varargs.
            // XLua delegate binding does not reliably convert Lua varargs to object[] in
            // reflection mode, so join varargs on the Lua side and forward one string.
            env.Global.Set<string, System.Action<string>>("__KTO_LogLine",
                msg => Debug.Log("[LUA] " + (msg ?? "")));
            env.Global.Set<string, System.Action<string>>("__KTO_LogErrorLine",
                msg => Debug.LogError("[LUA] " + (msg ?? "")));
            env.Global.Set<string, System.Action<string>>("__KTO_LogWarningLine",
                msg => Debug.LogWarning("[LUA] " + (msg ?? "")));
            env.DoString(@"
                local function __kto_join_log_args(...)
                    local n = select('#', ...)
                    if n == 0 then return '' end
                    local parts = {}
                    for i = 1, n do
                        parts[i] = tostring(select(i, ...))
                    end
                    return table.concat(parts, ' ')
                end
                Log = function(...) __KTO_LogLine(__kto_join_log_args(...)) end
                LogError = function(...) __KTO_LogErrorLine(__kto_join_log_args(...)) end
                LogErr = function(...) __KTO_LogErrorLine(__kto_join_log_args(...)) end
                LogWarning = function(...) __KTO_LogWarningLine(__kto_join_log_args(...)) end
                LogWarn = function(...) __KTO_LogWarningLine(__kto_join_log_args(...)) end
            ", "BindKTOLogVarargs");
        }

        private static string JoinArgs(object[] args)
        {
            if (args == null || args.Length == 0) return "";
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < args.Length; i++)
            {
                if (i > 0) sb.Append(' ');
                sb.Append(args[i] != null ? args[i].ToString() : "nil");
            }
            return sb.ToString();
        }
    }
}
