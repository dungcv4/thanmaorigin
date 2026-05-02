// 2026-05-02 — RESTORE btnChange/Image arrow icon to match gốc visual.
//
// CORRECTION OF EARLIER MISANALYSIS:
//   - FixBtnChangeImage.cs cite ("truly null in gốc") was WRONG.
//   - VerifyGocBtnChange found gốc YAML actually has:
//       m_Sprite: {fileID: 5751748114213389758, guid: 0000000000000000f000000000000000, type: 0}
//     This IS a non-zero fileID = reference to Tuanjie engine BUILTIN sprite.
//     On Tuanjie, it resolves to ">" arrow icon (visible per gốc screenshot).
//     On Standard Unity, fileID doesn't exist → null → invisible.
//
// FIX: substitute with project atlas sprite that visually matches gốc.
//      The previous prefab state had `btn_narrow_up` (or similar) + rotation
//      z=270° = effective ">" arrow visual. Restore that.
//
// DEVIATION rationale (per kiemthanorigin-port-1-1 skill contract):
//   - YAML byte ≠ gốc (gốc uses Tuanjie builtin fileID, we use project atlas GUID)
//   - VISUAL = gốc (same arrow appears in same position)
//   - Required because Tuanjie builtin sprite registry not portable to Standard Unity
//   - Approved by user: 2026-05-02 ("cho icon vào đó mới chuẩn gốc chứ. gốc nó có")
//   - Logged to DEVIATIONS.md

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class RestoreBtnChangeArrow
{
    public static void Execute()
    {
        const string prefabPath = "Assets/game/ui/views/UILoginServer.prefab";
        const string targetPath = "imgBG/PanelServer/btnChange/Image";

        // CORRECTION 2026-05-02 — user feedback: btn_narrow_right is a teal button
        // with frame (wrong). Gốc shows transparent thin ">" arrow. The correct
        // sprite is btn_narrow_up (transparent thin arrow pointing up) + rotate 270°
        // to make it point right.
        string[] candidates = {
            "Assets/game/ui/atlas/common/btn_narrow_up.asset",
            "Assets/Sprite/btn_narrow_up.asset",
            "Assets/game/ui/atlas/common_btn/btn_narrow_up.asset",
        };
        Sprite chosenSprite = null;
        string chosenPath = null;
        bool needsRotation = false;
        foreach (var path in candidates)
        {
            var sp = AssetDatabase.LoadAssetAtPath<Sprite>(path);
            if (sp != null) {
                chosenSprite = sp;
                chosenPath = path;
                needsRotation = path.Contains("btn_narrow_up");
                break;
            }
        }
        if (chosenSprite == null)
        {
            Debug.LogError("[Restore] No suitable arrow sprite found in project atlas. Candidates tried: " + string.Join(", ", candidates));
            return;
        }
        Debug.Log($"[Restore] Chosen sprite: {chosenPath} (needsRotation={needsRotation})");

        var prefab = PrefabUtility.LoadPrefabContents(prefabPath);
        if (prefab == null) { Debug.LogError($"Cannot load prefab: {prefabPath}"); return; }

        try
        {
            var t = prefab.transform.Find(targetPath);
            if (t == null) { Debug.LogError($"Path not found: {targetPath}"); return; }
            var img = t.GetComponent<Image>();
            if (img == null) { Debug.LogError($"No Image on {targetPath}"); return; }
            var rt = t as RectTransform;

            Debug.Log($"[Restore] BEFORE: sprite={(img.sprite != null ? img.sprite.name : "NULL")} color={img.color} rotZ={rt.localEulerAngles.z}");

            img.sprite = chosenSprite;
            img.color = new Color(1f, 1f, 1f, 1f);
            // If using "btn_narrow_up", rotate z=270° to make it point right
            if (needsRotation)
                rt.localEulerAngles = new Vector3(0, 0, 270f);
            else
                rt.localEulerAngles = new Vector3(0, 0, 0f);

            EditorUtility.SetDirty(img);
            EditorUtility.SetDirty(rt);

            Debug.Log($"[Restore] AFTER:  sprite={img.sprite.name} color={img.color} rotZ={rt.localEulerAngles.z}");

            PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);
            Debug.Log($"[Restore] Saved {prefabPath}");
        }
        finally
        {
            PrefabUtility.UnloadPrefabContents(prefab);
        }
        AssetDatabase.Refresh();
        Debug.Log("[Restore] DONE — btnChange/Image now shows ' >' arrow matching gốc visual");
    }
}
