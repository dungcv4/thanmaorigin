using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public static class _QuickTextProbe
{
    public static void Execute()
    {
        Debug.Log("[QTP] BEGIN");
        var go = new GameObject("X");
        go.AddComponent<Canvas>();
        go.AddComponent<UnityEngine.UI.Text>();
        var path = "Assets/_qtp.prefab";
        PrefabUtility.SaveAsPrefabAsset(go, path);
        Object.DestroyImmediate(go);
        AssetDatabase.Refresh();
        var p = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        var ts = p.GetComponentsInChildren<UnityEngine.UI.Text>(true);
        Debug.Log($"[QTP] count={ts.Length}");
        AssetDatabase.DeleteAsset(path);
        Debug.Log("[QTP] END");
    }
}
