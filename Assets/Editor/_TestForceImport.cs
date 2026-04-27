using UnityEditor;
using UnityEngine;

public static class _TestForceImport
{
    public static void Execute()
    {
        Debug.Log("[FORCE] Refresh + ForceUpdate");
        // Full refresh
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
        // Re-import the specific prefab
        var path = "Assets/game/ui/views/UILoginBG.prefab";
        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);

        // Try multiple load methods
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        Debug.Log($"[FORCE] LoadAssetAtPath<GameObject>: {(prefab == null ? "NULL" : prefab.name)}");

        var asObject = AssetDatabase.LoadAssetAtPath<Object>(path);
        Debug.Log($"[FORCE] LoadAssetAtPath<Object>: {(asObject == null ? "NULL" : asObject.GetType().FullName + ": " + asObject.name)}");

        var allAssets = AssetDatabase.LoadAllAssetsAtPath(path);
        Debug.Log($"[FORCE] LoadAllAssets: {allAssets.Length}");
        foreach (var a in allAssets) if (a != null) Debug.Log($"[FORCE]   - {a.GetType().FullName}: {a.name}");

        // Check if GUID looks up
        var guid = AssetDatabase.AssetPathToGUID(path);
        Debug.Log($"[FORCE] GUID for {path}: {guid}");
    }
}
