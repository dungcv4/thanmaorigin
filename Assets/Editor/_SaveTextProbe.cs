using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public static class _SaveTextProbe
{
    public static void Execute()
    {
        var go = new GameObject("TextProbe");
        go.AddComponent<Canvas>();
        var text = go.AddComponent<UnityEngine.UI.Text>();
        text.text = "Hello";
        text.color = Color.white;
        text.fontSize = 20;
        var path = "Assets/_text_probe2.prefab";
        PrefabUtility.SaveAsPrefabAsset(go, path);
        Object.DestroyImmediate(go);
        // Don't delete this time
    }
}
