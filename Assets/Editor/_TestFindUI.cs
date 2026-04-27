using UnityEditor;
using UnityEngine;

public static class _TestFindUI
{
    public static void Execute()
    {
        // Test multiple search variants
        string[] queries = { "UILoginBG t:Prefab", "UILoginBG", "UILoginBG t:GameObject", "t:Prefab" };
        foreach (var q in queries)
        {
            var guids = AssetDatabase.FindAssets(q);
            Debug.Log($"[Test] FindAssets '{q}' = {guids.Length}");
            if (guids.Length > 0 && guids.Length < 6)
            {
                foreach (var g in guids) Debug.Log($"  → {AssetDatabase.GUIDToAssetPath(g)}");
            }
        }
        // Direct path
        var direct = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/game/ui/views/UILoginBG.prefab");
        Debug.Log($"[Test] Direct LoadAssetAtPath: {(direct == null ? "NULL" : direct.name)}");
    }
}
