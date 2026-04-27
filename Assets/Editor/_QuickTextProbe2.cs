using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public static class _QuickTextProbe2
{
    public static void Execute()
    {
        var go = new GameObject("X");
        var t = go.AddComponent<UnityEngine.UI.Text>();
        Debug.Log($"[QTP2] addComp returned: {(t == null ? "NULL" : t.GetType().FullName)}");
        var ts = go.GetComponentsInChildren<UnityEngine.UI.Text>(true);
        Debug.Log($"[QTP2] inMemory GetComp<Text>(true).Length = {ts.Length}");
        var all = go.GetComponents<Component>();
        foreach (var c in all)
            Debug.Log($"[QTP2] comp: {(c == null ? "NULL" : c.GetType().FullName)}");
        Object.DestroyImmediate(go);
    }
}
