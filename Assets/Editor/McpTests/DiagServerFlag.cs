// DEBUG 2026-05-02 — diagnose why ServerFlagGreen Image.sprite is "" at runtime
// despite hard-coded GUID 4172838de8eb39ce5e77fcb2ae7375b0 in prefab YAML.
//
// Three checks:
//   (1) Resolve 5 sample hard-coded GUIDs to asset paths via AssetDatabase
//   (2) Find runtime ServerFlagGreen GO + dump Image.sprite + Image.color
//   (3) Find prefab path "UILoginServer" in AssetDatabase + check the Image
//       component's sprite reference at edit time

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;

public static class DiagServerFlag
{
    public static void Execute()
    {
        Debug.Log("=== DiagServerFlag START ===");

        // (1) Resolve 5 sample hard-coded GUIDs
        string[] guids = {
            "4172838de8eb39ce5e77fcb2ae7375b0",
            "b90fe21d4bdf7d4d91b238c27fd352a9",
            "bcdac1089a28759e9d426673753b10cd",
            "b5245c7254222f7d2fe7cb96b875ea94",
            "efb25cc1451134d997154fe0d90141ec",
        };
        foreach (var g in guids)
        {
            var path = AssetDatabase.GUIDToAssetPath(g);
            var sprite = !string.IsNullOrEmpty(path) ? AssetDatabase.LoadAssetAtPath<Sprite>(path) : null;
            Debug.Log($"  GUID {g.Substring(0,8)}... → path='{path}' sprite={(sprite != null ? sprite.name : "NULL")}");
        }

        // (2) Find runtime ServerFlagGreen
        var serverFlags = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => go.name.StartsWith("ServerFlag") && !go.name.Contains("(Clone)"))
            .ToArray();
        Debug.Log($"\n  Runtime ServerFlag* GameObjects found: {serverFlags.Length}");
        foreach (var go in serverFlags)
        {
            string fullPath = GetPath(go.transform);
            var img = go.GetComponent<Image>();
            if (img == null) {
                Debug.Log($"  {fullPath}: NO Image");
                continue;
            }
            Debug.Log($"  {fullPath}: active={go.activeInHierarchy} sprite={(img.sprite != null ? img.sprite.name : "NULL")} color.a={img.color.a:F2} enabled={img.enabled}");
        }

        // (3) Read prefab — check edit-time sprite refs
        var prefabPath = "Assets/game/ui/views/UILoginServer.prefab";
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab == null) { Debug.LogError($"  prefab not found at {prefabPath}"); return; }
        Debug.Log($"\n  Loaded prefab {prefabPath}");
        var prefImgs = prefab.GetComponentsInChildren<Image>(includeInactive: true);
        foreach (var img in prefImgs)
        {
            if (img.transform.name.StartsWith("ServerFlag"))
            {
                Debug.Log($"    PREFAB {GetPath(img.transform)}: sprite={(img.sprite != null ? img.sprite.name : "NULL")} color.a={img.color.a:F2}");
            }
        }
        Debug.Log("=== DiagServerFlag END ===");
    }

    static string GetPath(Transform t) {
        var stack = new System.Collections.Generic.Stack<string>();
        while (t != null) { stack.Push(t.name); t = t.parent; }
        return string.Join("/", stack);
    }
}
