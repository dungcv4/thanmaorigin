// Trigger XLua code generation (to populate Assets/XLua/Gen/ with delegate bridges).
// Required for Lua → C# delegate conversions like UnityAction<bool> for Toggle.onValueChanged.
using UnityEditor;
using UnityEngine;

public static class _XLuaGen
{
    public static void Execute()
    {
        Debug.Log("[XLG] BEGIN");
        if (Application.isPlaying)
        {
            Debug.LogError("[XLG] cannot generate during play mode — exit first");
            EditorApplication.ExitPlaymode();
            return;
        }
        try
        {
            // Call CSObjectWrapEditor.Generator.GenAll() via reflection (it's in editor assembly).
            var t = System.Type.GetType("CSObjectWrapEditor.Generator, Assembly-CSharp-Editor")
                    ?? System.Type.GetType("CSObjectWrapEditor.Generator");
            if (t == null)
            {
                foreach (var asm in System.AppDomain.CurrentDomain.GetAssemblies())
                {
                    t = asm.GetType("CSObjectWrapEditor.Generator");
                    if (t != null) break;
                }
            }
            if (t == null) { Debug.LogError("[XLG] Generator type not found"); return; }
            var gen = t.GetMethod("GenAll", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, null, new System.Type[0], null);
            if (gen == null) { Debug.LogError("[XLG] GenAll not found"); return; }
            gen.Invoke(null, null);
            Debug.Log("[XLG] GenAll completed");
        }
        catch (System.Exception e)
        {
            Debug.LogError("[XLG] threw: " + e.Message + (e.InnerException != null ? "\nInner: " + e.InnerException.Message : ""));
        }
        AssetDatabase.Refresh();
        Debug.Log("[XLG] END");
    }
}
