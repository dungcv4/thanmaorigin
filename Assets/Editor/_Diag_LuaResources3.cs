using UnityEditor;
using UnityEngine;

public static class _Diag_LuaResources3
{
    public static void Execute()
    {
        // Try force-importing the asset
        var path = "Assets/_Project/Resources/Lua/commonui/Script_Client.lua.txt";
        Debug.Log($"[Diag3] Force-importing {path}...");
        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

        // Now try loading it
        var ta = AssetDatabase.LoadAssetAtPath<TextAsset>(path);
        Debug.Log($"[Diag3] After force import: {(ta == null ? "STILL NULL" : $"OK len={ta.bytes.Length}")}");

        // Try as DefaultAsset
        var da = AssetDatabase.LoadAssetAtPath<DefaultAsset>(path);
        Debug.Log($"[Diag3] As DefaultAsset: {(da == null ? "NULL" : "OK")}");

        // Get all guids in folder
        var ids = AssetDatabase.FindAssets("", new[] {"Assets/_Project/Resources/Lua/commonui"});
        Debug.Log($"[Diag3] Total assets in commonui folder: {ids.Length}");
        if (ids.Length > 0)
        {
            for (int i = 0; i < System.Math.Min(3, ids.Length); i++)
            {
                var p = AssetDatabase.GUIDToAssetPath(ids[i]);
                var importer = AssetImporter.GetAtPath(p);
                Debug.Log($"[Diag3]   [{i}] {p} → importer: {(importer == null ? "NULL" : importer.GetType().FullName)}");
            }
        }
    }
}
