// Apply SetNativeSize() to btnChange/Image so sprite renders at native rect
// (25.9×12.9) instead of stretched to RectTransform sizeDelta (60×60).
//
// DEVIATION rationale:
//   Gốc YAML sizeDelta = 60×60 (Tuanjie engine renders sprite at native rect
//   regardless of sizeDelta — per memory `feedback_tuanjie_null_sprite_compat`
//   + `fix-oversized-avatar-stretch`).
//   Standard Unity Image.type=Simple stretches sprite to sizeDelta → distorted.
//   To match gốc VISUAL, set sizeDelta = sprite.rect.size via SetNativeSize().
// User approval: 2026-05-02 ("size đang quá to check lại")
// DEVIATION already logged for sprite substitution; this size fix is consequence.

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class SetBtnChangeArrowNativeSize
{
    public static void Execute()
    {
        const string prefabPath = "Assets/game/ui/views/UILoginServer.prefab";
        const string targetPath = "imgBG/PanelServer/btnChange/Image";

        var prefab = PrefabUtility.LoadPrefabContents(prefabPath);
        try
        {
            var t = prefab.transform.Find(targetPath);
            var img = t.GetComponent<Image>();
            var rt = t as RectTransform;

            Debug.Log($"[Native] BEFORE: sizeDelta={rt.sizeDelta} sprite={img.sprite.name} sprite.rect={img.sprite.rect}");

            img.SetNativeSize();
            EditorUtility.SetDirty(img);
            EditorUtility.SetDirty(rt);

            Debug.Log($"[Native] AFTER:  sizeDelta={rt.sizeDelta}");

            PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);
            Debug.Log("[Native] Saved prefab");
        }
        finally
        {
            PrefabUtility.UnloadPrefabContents(prefab);
        }
        AssetDatabase.Refresh();
    }
}
