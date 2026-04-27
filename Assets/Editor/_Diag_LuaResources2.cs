using UnityEditor;
using UnityEngine;

public static class _Diag_LuaResources2
{
    public static void Execute()
    {
        // Try AssetDatabase (works in editor without import status)
        var ad = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/_Project/Resources/Lua/commonui/Script_Client.lua.txt");
        Debug.Log($"[Diag2] AssetDB LoadAssetAtPath: {(ad == null ? "NULL" : $"OK len={ad.bytes.Length}")}");

        // Check if imported
        var guid = AssetDatabase.AssetPathToGUID("Assets/_Project/Resources/Lua/commonui/Script_Client.lua.txt");
        Debug.Log($"[Diag2] GUID for Script_Client: {guid}");

        // Get importer type
        var importer = AssetImporter.GetAtPath("Assets/_Project/Resources/Lua/commonui/Script_Client.lua.txt");
        Debug.Log($"[Diag2] Importer type: {(importer == null ? "NULL" : importer.GetType().FullName)}");

        // Find ALL TextAssets via AssetDB filter
        var allTas = AssetDatabase.FindAssets("t:TextAsset", new[] { "Assets/_Project/Resources/Lua" });
        Debug.Log($"[Diag2] AssetDB Find t:TextAsset under Lua: {allTas.Length}");

        // Test default ScriptableObject importer asset?
        var defaultAsset = AssetDatabase.LoadAssetAtPath<Object>("Assets/_Project/Resources/Lua/commonui/Script_Client.lua.txt");
        Debug.Log($"[Diag2] As Object: {(defaultAsset == null ? "NULL" : defaultAsset.GetType().FullName)}");

        // List sibling folder
        var siblings = AssetDatabase.FindAssets("Script_Client", new[] { "Assets/_Project/Resources/Lua/commonui" });
        Debug.Log($"[Diag2] Find 'Script_Client': {siblings.Length}");
    }
}
