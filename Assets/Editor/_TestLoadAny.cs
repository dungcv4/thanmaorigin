using UnityEditor;
using UnityEngine;
using System.IO;

public static class _TestLoadAny
{
    public static void Execute()
    {
        Debug.Log("[ANY_TEST] BEGIN");
        // Find ANY .prefab in Assets/Resources or Assets/_Project (small, simple)
        string[] candidates = new string[]
        {
            "Assets/Resources/DefaultViewportMaterial.mat",   // simple .mat
            "Assets/_Project/Scenes/BootScene.unity",          // current loaded scene
            "Assets/Editor/_TestLoadAny.cs",                   // this very script
        };
        foreach (var path in candidates)
        {
            var importer = AssetImporter.GetAtPath(path);
            var asset = AssetDatabase.LoadMainAssetAtPath(path);
            Debug.Log($"[ANY_TEST] {path}");
            Debug.Log($"   importer={(importer == null ? "NULL" : importer.GetType().Name)}");
            Debug.Log($"   main_asset={(asset == null ? "NULL" : asset.GetType().Name)}");
        }

        // Check what's actually imported - find the smallest prefab in project that's imported
        var allPrefabs = AssetDatabase.FindAssets("t:Prefab");
        Debug.Log($"[ANY_TEST] FindAssets t:Prefab returned: {allPrefabs.Length} GUIDs");
        if (allPrefabs.Length > 0)
        {
            var path = AssetDatabase.GUIDToAssetPath(allPrefabs[0]);
            var asset = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            Debug.Log($"[ANY_TEST] First prefab: {path} -> {(asset == null ? "NULL" : asset.name)}");
        }
        else
        {
            Debug.LogWarning("[ANY_TEST] NO PREFABS INDEXED — Tuanjie hasn't completed import.");
        }

        Debug.Log("[ANY_TEST] END");
    }
}
