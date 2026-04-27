using UnityEditor;
using UnityEngine;
using System.Reflection;

public static class _TestConnectGatewayBind
{
    public static void Execute()
    {
        Debug.Log("[CGB] BEGIN");
        if (!Application.isPlaying) { Debug.LogError("[CGB] not playing"); return; }
        // Find LuaEngine via reflection (across recompile)
        var t = System.Type.GetType("ThanMaOrigin.Lua.LuaEngine, Assembly-CSharp");
        if (t == null)
        {
            foreach (var asm in System.AppDomain.CurrentDomain.GetAssemblies())
            { t = asm.GetType("ThanMaOrigin.Lua.LuaEngine"); if (t != null) break; }
        }
        if (t == null) { Debug.LogError("[CGB] no type"); return; }
        var inst = t.GetProperty("Instance", BindingFlags.Public|BindingFlags.Static)?.GetValue(null);
        Debug.Log($"[CGB] Instance={(inst == null ? "NULL" : "OK")}");
        if (inst == null)
        {
            inst = Object.FindObjectOfType(t);
            Debug.Log($"[CGB] FindObjectOfType={(inst == null ? "NULL" : "OK")}");
            if (inst == null) { Debug.LogError("[CGB] no instance"); return; }
        }
        var envProp = t.GetProperty("Env");
        Debug.Log($"[CGB] envProp={(envProp == null ? "NULL" : "OK")}");
        var env = envProp.GetValue(inst);
        Debug.Log($"[CGB] env={(env == null ? "NULL" : "OK")}");
        if (env == null) { Debug.LogError("[CGB] env null"); return; }
        var ds = env.GetType().GetMethod("DoString", new[] { typeof(string), typeof(string), typeof(XLua.LuaTable) });
        if (ds == null) {
            // Try other signature
            foreach (var m in env.GetType().GetMethods())
            {
                if (m.Name == "DoString" && m.GetParameters().Length == 3 && m.GetParameters()[0].ParameterType == typeof(string)) { ds = m; break; }
            }
        }
        if (ds == null) { Debug.LogError("[CGB] no DoString method"); return; }
        Debug.Log($"[CGB] DoString found, params={ds.GetParameters().Length}");
        try
        {
            ds.Invoke(env, new object[] {
                "Log('[CGB.LUA] type(ConnectGateway)='..type(ConnectGateway))",
                "TestCGB1",
                null
            });
            ds.Invoke(env, new object[] {
                "if type(ConnectGateway) == 'function' then ConnectGateway('127.0.0.1', 3001, 'testacc', 'dummyAuth') Log('[CGB.LUA] called OK') end",
                "TestCGB2",
                null
            });
        }
        catch (System.Exception e) { Debug.LogError("[CGB] " + e.InnerException?.Message + " / " + e.Message); }
        Debug.Log("[CGB] END");
    }
}
