using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Reflection;

public static class _ProbeViaFind
{
    public static void Execute()
    {
        Debug.Log("[PROBE2] BEGIN");
        if (!Application.isPlaying) { Debug.Log("[PROBE2] not playing"); return; }
        var all = Resources.FindObjectsOfTypeAll<MonoBehaviour>();
        var le = all.FirstOrDefault(c => c != null && c.GetType().Name == "LuaEngine");
        if (le == null) { Debug.LogError("[PROBE2] no LuaEngine"); return; }
        // Reflection: get Env property
        var envProp = le.GetType().GetProperty("Env");
        if (envProp == null) { Debug.LogError("[PROBE2] no Env property"); return; }
        var env = envProp.GetValue(le);
        if (env == null) { Debug.LogError("[PROBE2] Env value null"); return; }
        // Call DoString via reflection
        var method = env.GetType().GetMethod("DoString", new[] { typeof(string), typeof(string) });
        if (method == null) { Debug.LogError("[PROBE2] no DoString"); return; }
        try
        {
            method.Invoke(env, new object[] {
                @"local d = CS.UnityEngine.Debug
                  d.Log('[PROBE2] type(Ui) = ' .. type(Ui))
                  d.Log('[PROBE2] type(Ui.UIPanel) = ' .. tostring(type(Ui.UIPanel)))
                  d.Log('[PROBE2] tostring(Ui.UIPanel) = ' .. tostring(Ui.UIPanel))
                  d.Log('[PROBE2] type(CS.Game.UI.UIPanel) = ' .. tostring(type(CS.Game.UI.UIPanel)))
                  d.Log('[PROBE2] tostring(CS.Game.UI.UIPanel) = ' .. tostring(CS.Game.UI.UIPanel))
                  d.Log('[PROBE2] tostring(CS.Game.UI) = ' .. tostring(CS.Game.UI))",
                "Probe2"
            });
        }
        catch (System.Exception e)
        {
            Debug.LogError("[PROBE2] DoString FAIL: " + e.Message);
        }
        Debug.Log("[PROBE2] END");
    }
}
