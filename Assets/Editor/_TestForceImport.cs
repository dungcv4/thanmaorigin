using UnityEditor;
using UnityEngine;

public static class _TestForceImport
{
    public static void Execute()
    {
        Debug.Log("[FORCE] Refresh + ForceUpdate");
        // Full refresh
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
        var paths = new[]
        {
            "Assets/game/ui/views/UILoginBG.prefab",
            "Assets/game/ui/views/UITopEffect.prefab",
            "Assets/game/ui/views/UILoginChannelInner.prefab",
        };

        foreach (var path in paths)
        {
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);

            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            Debug.Log($"[FORCE] LoadAssetAtPath<GameObject> {path}: {(prefab == null ? "NULL" : prefab.name)}");

            var allAssets = AssetDatabase.LoadAllAssetsAtPath(path);
            Debug.Log($"[FORCE] LoadAllAssets {path}: {allAssets.Length}");

            var guid = AssetDatabase.AssetPathToGUID(path);
            Debug.Log($"[FORCE] GUID for {path}: {guid}");
        }
    }
}
