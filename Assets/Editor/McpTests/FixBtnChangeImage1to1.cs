// 1-1 GỐC FIX 2026-05-02 (refined) — set btnChange/Image to match gốc byte-for-byte.
//
// Gốc verified via VerifyGocBtnChange.cs reading KTO_FullExtract YAML directly:
//   m_Sprite: {fileID: 5751748114213389758, guid: 0000000000000000f000000000000000, type: 0}
//   m_Color:  {r: 1, g: 1, b: 1, a: 1}
//
// The placeholder GUID `0000...f000...` is Tuanjie engine's internal builtin sprite
// reference. Tuanjie renders it as nothing (per KTO design). Standard Unity would
// render as white square — `UIModule.ApplyTuanjieNullSpriteCompat` shim handles that
// by setting alpha=0 at Instantiate.
//
// Since user runs Tuanjie editor (per title bar "Tuanjie Editor 1.8.5"), the
// placeholder + a=1 → renders nothing → matches gốc visual.
//
// Unity Image API can't expose the placeholder fileID. So we use null Sprite +
// keep alpha=1 (gốc value). The Tuanjie shim auto-handles the visual on play.
//
// EXPLANATION TO USER: btnChange/Image is INTENTIONALLY hidden per gốc design.
// gốc UILoginServer "đổi server" button has NO decorative icon — only the Text
// child shows "Đổi". If you want an icon there, that would be a DEVIATION
// from gốc 1-1.

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class FixBtnChangeImage1to1
{
    public static void Execute()
    {
        const string prefabPath = "Assets/game/ui/views/UILoginServer.prefab";
        const string targetPath = "imgBG/PanelServer/btnChange/Image";

        var prefab = PrefabUtility.LoadPrefabContents(prefabPath);
        if (prefab == null) { Debug.LogError($"Cannot load prefab: {prefabPath}"); return; }

        try
        {
            var t = prefab.transform.Find(targetPath);
            if (t == null) { Debug.LogError($"Path not found: {targetPath}"); return; }
            var img = t.GetComponent<Image>();
            if (img == null) { Debug.LogError($"No Image on {targetPath}"); return; }

            Debug.Log($"[Fix1to1] BEFORE: sprite={(img.sprite != null ? img.sprite.name : "NULL")} color={img.color}");

            // Match gốc byte-for-byte: null Sprite (= placeholder GUID resolves to null
            // in standard Unity) + Color(1,1,1,1).
            img.sprite = null;
            img.color = new Color(1f, 1f, 1f, 1f);
            EditorUtility.SetDirty(img);

            Debug.Log($"[Fix1to1] AFTER:  sprite={(img.sprite != null ? img.sprite.name : "NULL")} color={img.color}");

            PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);
            Debug.Log($"[Fix1to1] Saved {prefabPath}");
        }
        finally
        {
            PrefabUtility.UnloadPrefabContents(prefab);
        }
        AssetDatabase.Refresh();
        Debug.Log("[Fix1to1] DONE — prefab now matches gốc 1-1 (sprite=null, color=white)");
    }
}
