// Forces Unity to refresh + recompile. Created 2026-04-26 to break compile stuck-state.
using UnityEditor;
using UnityEngine;

public static class ForceRefresh_2026_04_26
{
    [InitializeOnLoadMethod]
    private static void Init()
    {
        Debug.Log("[ForceRefresh] Editor loaded — Assembly-CSharp compile succeeded.");
    }
}
