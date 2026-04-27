using UnityEditor;
using UnityEngine;

public static class _TestUiUIPanel
{
    public static void Execute()
    {
        Debug.Log("[UIP_TEST] BEGIN");
        if (!Application.isPlaying)
        {
            Debug.Log("[UIP_TEST] not in play mode, skipping");
            return;
        }
        if (ThanMaOrigin.Lua.LuaEngine.Instance == null) { Debug.Log("[UIP_TEST] LuaEngine.Instance null"); return; }
        var env = ThanMaOrigin.Lua.LuaEngine.Instance.Env;
        if (env == null) { Debug.Log("[UIP_TEST] Env null"); return; }
        try
        {
            // Probe Ui.UIPanel
            env.DoString("Log('[UIP_TEST] type(Ui.UIPanel) = ' .. type(Ui.UIPanel)); Log('[UIP_TEST] tostring(Ui.UIPanel) = ' .. tostring(Ui.UIPanel))");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"[UIP_TEST] DoString failed: {e}");
        }
    }
}
