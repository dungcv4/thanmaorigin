// Phase B.3 verify: trigger ConnectGateway from Lua + observe TCP connection.
using UnityEditor;
using UnityEngine;
using System.Reflection;

public static class _TriggerConnect
{
    public static void Execute()
    {
        Debug.Log("[TC] BEGIN");
        if (!Application.isPlaying) { Debug.LogError("[TC] not playing"); return; }
        // Find LuaEngine.Env via reflection
        System.Type t = null;
        foreach (var asm in System.AppDomain.CurrentDomain.GetAssemblies())
        { t = asm.GetType("ThanMaOrigin.Lua.LuaEngine"); if (t != null) break; }
        if (t == null) { Debug.LogError("[TC] LuaEngine type not found"); return; }
        var inst = Object.FindObjectOfType(t);
        if (inst == null) { Debug.LogError("[TC] no instance"); return; }
        var env = t.GetProperty("Env").GetValue(inst);
        if (env == null) { Debug.LogError("[TC] env null"); return; }
        // Find DoString(string, string, LuaTable)
        MethodInfo ds = null;
        foreach (var m in env.GetType().GetMethods())
        {
            if (m.Name == "DoString" && m.GetParameters().Length == 3
                && m.GetParameters()[0].ParameterType == typeof(string)) { ds = m; break; }
        }
        if (ds == null) { Debug.LogError("[TC] DoString not found"); return; }
        Debug.Log($"[TC] DoString found");
        try
        {
            ds.Invoke(env, new object[] {
                "Log('[TC.LUA] ConnectGateway type=' .. type(ConnectGateway))",
                "TC1", null
            });
            ds.Invoke(env, new object[] {
                "ConnectGateway('127.0.0.1', 3001, 'test_account', 'authstub')",
                "TC2", null
            });
            Debug.Log("[TC] DoString completed without throw");
        }
        catch (System.Exception e)
        {
            Debug.LogError("[TC] DS threw: " + (e.InnerException != null ? e.InnerException.Message : e.Message));
        }
        Debug.Log("[TC] END");
    }
}
