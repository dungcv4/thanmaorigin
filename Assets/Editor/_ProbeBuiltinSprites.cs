// Probe Tuanjie built-in sprite fileIDs by listing them via EditorGUIUtility.
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public static class _ProbeBuiltinSprites
{
    public static void Execute()
    {
        Debug.Log("[PBS] BEGIN");
        // Create UI elements with default sprites and save prefab to inspect YAML
        var go = new GameObject("Probe");
        go.AddComponent<Canvas>();
        // Add default sprite assignments via Unity's editor defaults
        // - Image gets default UISprite (use SetSpriteDirect)
        // - Toggle has Background + Checkmark
        // - InputField has Background + Placeholder
        // - Dropdown has Arrow

        // Probe via PrefabUtility's "create" method which auto-fills default sprite.
        var imgGO = (GameObject)PrefabUtility.InstantiatePrefab(null);
        if (imgGO == null)
        {
            // Fallback: create Image GameObject via Unity's built-in menu helper if available
            // Unity creates Image with UI/UISprite default
            imgGO = new GameObject("ImgUISprite");
            imgGO.transform.SetParent(go.transform, false);
            var img = imgGO.AddComponent<Image>();
            // Trigger default sprite assignment via reflection
            var field = typeof(Image).GetField("m_Sprite", System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Instance);
            // Or use SerializedObject defaults
        }
        // Just use a direct AssetDatabase load of Tuanjie built-in
        var spriteAtPath = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        Debug.Log($"[PBS] BuiltinExtra UISprite: {(spriteAtPath == null ? "NULL" : spriteAtPath.name)}");
        if (spriteAtPath != null)
        {
            // Get its GUID + fileID
            string assetPath = AssetDatabase.GetAssetPath(spriteAtPath);
            Debug.Log($"[PBS]   path: {assetPath}");
            string guid = AssetDatabase.AssetPathToGUID(assetPath);
            long localId;
            if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(spriteAtPath, out _, out localId))
            {
                Debug.Log($"[PBS]   guid={guid} localId={localId}");
            }
        }
        // Try Background, Checkmark, UIMask
        foreach (var n in new[] {"Background", "Checkmark", "UIMask", "DropdownArrow", "InputFieldBackground", "UISprite"})
        {
            var s = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/" + n + ".psd");
            if (s != null)
            {
                long localId;
                AssetDatabase.TryGetGUIDAndLocalFileIdentifier(s, out _, out localId);
                Debug.Log($"[PBS] {n} fileID={localId}");
            }
            else Debug.Log($"[PBS] {n} not found");
        }

        // Toggle (has Background + Checkmark sprites)
        var togGO = new GameObject("TogProbe");
        togGO.transform.SetParent(go.transform, false);
        var tog = togGO.AddComponent<Toggle>();
        var bgGO = new GameObject("Background");
        bgGO.transform.SetParent(togGO.transform, false);
        var bgImg = bgGO.AddComponent<Image>();
        bgImg.sprite = (Sprite)EditorGUIUtility.Load("UI/Skin/Background.psd");
        var ckGO = new GameObject("Checkmark");
        ckGO.transform.SetParent(bgGO.transform, false);
        var ckImg = ckGO.AddComponent<Image>();
        ckImg.sprite = (Sprite)EditorGUIUtility.Load("UI/Skin/Checkmark.psd");

        var path = "Assets/_builtin_probe.prefab";
        PrefabUtility.SaveAsPrefabAsset(go, path);
        Object.DestroyImmediate(go);
        var content = File.ReadAllText(path);
        // Print all m_Sprite refs
        var lines = content.Split('\n');
        foreach (var line in lines)
        {
            if (line.Contains("m_Sprite:") && !line.Contains("fileID: 0}"))
            {
                Debug.Log($"[PBS] {line.Trim()}");
            }
        }
        AssetDatabase.DeleteAsset(path);
        Debug.Log("[PBS] END");
    }
}
