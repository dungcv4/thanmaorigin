using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public static class _SaveImageProbe
{
    public static void Execute()
    {
        var go = new GameObject("ImageProbe");
        go.AddComponent<Canvas>();
        go.AddComponent<UnityEngine.UI.Image>();
        var path = "Assets/_image_probe.prefab";
        PrefabUtility.SaveAsPrefabAsset(go, path);
        Object.DestroyImmediate(go);
        var content = File.ReadAllText(path);
        // Print just the Image MB block (between !u!114 and end)
        var idx = content.IndexOf("--- !u!114");
        Debug.Log($"[IMG_PROBE] Image MB block:\n{content.Substring(idx)}");
    }
}
