using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public static class _TestTextDirect
{
    public static void Execute()
    {
        Debug.Log("[TXT_TEST] BEGIN");
        // Create empty GO + Text + serialize → see what Tuanjie outputs
        var go = new GameObject("TempTextProbe");
        var text = go.AddComponent<UnityEngine.UI.Text>();
        text.text = "Hello";
        text.color = Color.white;
        // Save as prefab (tmp) and read YAML
        var tempPath = "Assets/_tmp_text_probe.prefab";
        var prefab = PrefabUtility.SaveAsPrefabAsset(go, tempPath);
        Object.DestroyImmediate(go);

        // Read YAML
        var yaml = File.ReadAllText(tempPath);
        Debug.Log($"[TXT_TEST] Tuanjie-saved Text prefab YAML:\n{yaml}");

        // Cleanup
        AssetDatabase.DeleteAsset(tempPath);

        Debug.Log("[TXT_TEST] END");
    }
}
