using UnityEditor;
using UnityEngine;

public static class _ProbeUiUIPanel
{
    public static void Execute()
    {
        Debug.Log("[PROBE] BEGIN");
        if (!Application.isPlaying)
        {
            Debug.Log("[PROBE] not in play mode — enter first");
            return;
        }
        var le = ThanMaOrigin.Lua.LuaEngine.Instance;
        if (le == null) { Debug.LogError("[PROBE] LuaEngine.Instance NULL"); return; }
        try
        {
            le.Env.DoString(@"
                local d = CS.UnityEngine.Debug
                d.Log('[PROBE] type(Ui)        = ' .. type(Ui))
                d.Log('[PROBE] type(Ui.UIPanel)= ' .. tostring(type(Ui.UIPanel)))
                d.Log('[PROBE] tostring(Ui.UIPanel) = ' .. tostring(Ui.UIPanel))
                d.Log('[PROBE] type(CS) = ' .. tostring(type(CS)))
                d.Log('[PROBE] type(CS.Game) = ' .. tostring(type(CS.Game)))
                d.Log('[PROBE] type(CS.Game.UI) = ' .. tostring(type(CS.Game.UI)))
                d.Log('[PROBE] type(CS.Game.UI.UIPanel) = ' .. tostring(type(CS.Game.UI.UIPanel)))
                d.Log('[PROBE] tostring(CS.Game.UI.UIPanel) = ' .. tostring(CS.Game.UI.UIPanel))
            ", "Probe");
        }
        catch (System.Exception e)
        {
            Debug.LogError("[PROBE] DoString ERR: " + e.Message);
        }
        Debug.Log("[PROBE] END");
    }
}
