// DEBUG 2026-05-02 — find btnChange/Image actual sprite + cross-check with gốc.
// Also resolve GUID dcd8b2f2a7a0ab5e36c036c152302644 to file path.

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class DiagBtnChangeImage
{
    public static void Execute()
    {
        Debug.Log("=== DiagBtnChangeImage START ===");

        // (1) Resolve GUID
        var guidPath = AssetDatabase.GUIDToAssetPath("dcd8b2f2a7a0ab5e36c036c152302644");
        Debug.Log($"  GUID dcd8b2f2... → '{guidPath}'");
        if (!string.IsNullOrEmpty(guidPath))
        {
            var sp = AssetDatabase.LoadAssetAtPath<Sprite>(guidPath);
            if (sp != null) Debug.Log($"    Sprite name='{sp.name}' rect={sp.rect} pivot={sp.pivot}");
        }

        // (2) Read prefab btnChange/Image edit-time state
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/game/ui/views/UILoginServer.prefab");
        if (prefab == null) { Debug.LogError("prefab not found"); return; }
        var t = prefab.transform.Find("imgBG/PanelServer/btnChange/Image");
        if (t == null) { Debug.LogError("btnChange/Image not found in prefab tree"); return; }
        var img = t.GetComponent<Image>();
        Debug.Log($"  PREFAB btnChange/Image: sprite={(img.sprite != null ? img.sprite.name : "NULL")} color.a={img.color.a:F2} sizeDelta={(t as RectTransform).sizeDelta}");

        // (3) Runtime btnChange/Image state
        var runtimeT = GameObject.Find("UILoginServer/imgBG/PanelServer/btnChange/Image");
        if (runtimeT != null)
        {
            var runtimeImg = runtimeT.GetComponent<Image>();
            Debug.Log($"  RUNTIME btnChange/Image: sprite={(runtimeImg.sprite != null ? runtimeImg.sprite.name : "NULL")} color.a={runtimeImg.color.a:F2}");
        }

        Debug.Log("=== DiagBtnChangeImage END ===");
    }
}
