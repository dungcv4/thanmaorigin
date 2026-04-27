using UnityEditor;
using UnityEngine;
using System.Reflection;

public static class _ProbeAlive
{
    public static void Execute()
    {
        Debug.Log($"[PRB3] BEGIN isPlaying={Application.isPlaying} willChange={EditorApplication.isPlayingOrWillChangePlaymode}");
        // Use FindObjectOfType — returns null if no scene-active instance
        var le = (MonoBehaviour)null;
        var t = System.Type.GetType("ThanMaOrigin.Lua.LuaEngine, Assembly-CSharp");
        if (t == null) t = System.Type.GetType("ThanMaOrigin.Lua.LuaEngine");
        if (t == null)
        {
            // Search loaded assemblies
            foreach (var asm in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                t = asm.GetType("ThanMaOrigin.Lua.LuaEngine");
                if (t != null) { Debug.Log("[PRB3] type from " + asm.GetName().Name); break; }
            }
        }
        if (t == null) { Debug.LogError("[PRB3] type not found"); return; }
        var instProp = t.GetProperty("Instance", BindingFlags.Public|BindingFlags.Static);
        if (instProp == null) { Debug.LogError("[PRB3] no Instance prop"); return; }
        var inst = instProp.GetValue(null);
        Debug.Log($"[PRB3] Instance={(inst == null ? "NULL" : "OK type="+inst.GetType().FullName)}");
        if (inst == null)
        {
            le = Object.FindObjectOfType(t) as MonoBehaviour;
            Debug.Log($"[PRB3] FindObjectOfType={(le == null ? "NULL" : "OK go="+le.gameObject.name)}");
        }
        else
        {
            le = inst as MonoBehaviour;
        }
        if (le == null) { Debug.LogError("[PRB3] no LuaEngine alive"); return; }

        var env = le.GetType().GetProperty("Env").GetValue(le);
        if (env == null) { Debug.LogError("[PRB3] Env null on alive obj"); return; }
        Debug.Log($"[PRB3] Env OK type={env.GetType().FullName}");

        try
        {
            var ds = env.GetType().GetMethod("DoString", new[] { typeof(string), typeof(string) });
            ds.Invoke(env, new object[] {
                @"local d = CS.UnityEngine.Debug
d.Log('[PRB3.LUA] type(Ui)='..type(Ui))
d.Log('[PRB3.LUA] type(Ui.UIPanel)='..type(Ui.UIPanel))
d.Log('[PRB3.LUA] type(CS.Game.UI.UIPanel)='..type(CS.Game.UI.UIPanel))
d.Log('[PRB3.LUA] tostring(Ui.UIPanel)='..tostring(Ui.UIPanel))
d.Log('[PRB3.LUA] tostring(CS.Game.UI.UIPanel)='..tostring(CS.Game.UI.UIPanel))",
                "Probe3"
            });
        }
        catch (System.Exception e) { Debug.LogError("[PRB3] DS FAIL: "+e.InnerException?.Message+" / "+e.Message); }
        Debug.Log("[PRB3] END");
    }
}
