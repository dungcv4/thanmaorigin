using UnityEditor;
using UnityEngine;

public static class _FullRefresh
{
    public static void Execute()
    {
        Debug.Log("[FULL_REFRESH] Begin...");
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
        // Re-import the views folder forcefully
        AssetDatabase.ImportAsset("Assets/game/ui/views",
            ImportAssetOptions.ImportRecursive | ImportAssetOptions.ForceSynchronousImport | ImportAssetOptions.ForceUpdate);
        AssetDatabase.SaveAssets();
        Debug.Log("[FULL_REFRESH] Done");
    }
}
