using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public static class _QuickImageProbe
{
    public static void Execute()
    {
        Debug.Log("[QIP] BEGIN");
        var go = new GameObject("X");
        go.AddComponent<Canvas>();
        go.AddComponent<UnityEngine.UI.Image>();
        var path = "Assets/_qip.prefab";
        PrefabUtility.SaveAsPrefabAsset(go, path);
        Object.DestroyImmediate(go);
        AssetDatabase.Refresh();
        var p = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        var imgs = p.GetComponentsInChildren<UnityEngine.UI.Image>(true);
        Debug.Log($"[QIP] count={imgs.Length}");
        AssetDatabase.DeleteAsset(path);
        Debug.Log("[QIP] END");
    }
}
