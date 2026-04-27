using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public static class _TestProbeTextLoad
{
    public static void Execute()
    {
        // Save fresh Tuanjie text prefab
        var go = new GameObject("ProbeText");
        go.AddComponent<Canvas>();
        var t = go.AddComponent<UnityEngine.UI.Text>();
        t.text = "TestText";
        var path = "Assets/_probe_text_load.prefab";
        PrefabUtility.SaveAsPrefabAsset(go, path);
        Object.DestroyImmediate(go);

        // Re-load and check
        AssetDatabase.Refresh();
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        var texts = prefab.GetComponentsInChildren<UnityEngine.UI.Text>(true);
        Debug.Log($"[PROBE_TXT_LOAD] saved + loaded prefab. UI.Text count = {texts.Length}");
        foreach (var txt in texts)
            Debug.Log($"[PROBE_TXT_LOAD]   text='{txt.text}' fontSize={txt.fontSize}");
        AssetDatabase.DeleteAsset(path);
    }
}
