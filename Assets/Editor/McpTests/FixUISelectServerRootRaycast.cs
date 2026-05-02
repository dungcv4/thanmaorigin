// 1-1 GỐC + DEVIATION fix 2026-05-02 — disable raycastTarget on UISelectServer
// root Image to allow clicks to propagate to children Buttons.
//
// Gốc YAML (KTO_FullExtract res_p_191) has:
//   m_Color: rgba(0, 0, 0, 0.706)  ← semi-transparent black modal overlay
//   m_RaycastTarget: 1               ← TRUE (catches outside-clicks)
//   m_Sprite: null
//
// On Tuanjie engine: raycast propagates to deepest child first → server-list
// Buttons receive click → modal overlay only catches clicks OUTSIDE content.
//
// On Standard Unity: GraphicRaycaster returns hits, ExecuteEvents.Execute()
// runs handler on FIRST hit (root in this case) + walks UP parent chain.
// Root Image has no IPointerClickHandler → click consumed silently → Buttons
// never see the click.
//
// DEVIATION: set m_RaycastTarget=0 on root Image. Modal overlay still
// renders dim black (visual gốc) but doesn't absorb clicks. Children
// Buttons receive clicks normally.
//
// User approval: 2026-05-02 ("ko click được chọn cái gì check luôn bug này
// với gốc 1-1, xem có phải bị cái gì che mất ko, hay bị lỗi event click")

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class FixUISelectServerRootRaycast
{
    public static void Execute()
    {
        const string prefabPath = "Assets/game/ui/views/UISelectServer.prefab";
        var prefab = PrefabUtility.LoadPrefabContents(prefabPath);
        try
        {
            // Root GO of UISelectServer — find the FULL-SCREEN Image with sprite=null
            // and raycastTarget=true (the modal overlay).
            var allImgs = prefab.GetComponentsInChildren<Image>(includeInactive: true);
            int fixedCount = 0;
            foreach (var img in allImgs)
            {
                // Only target full-screen Images (root level) with null sprite + raycast=true
                if (img.transform.parent != null) continue;  // root-level only
                if (img.sprite != null) continue;
                if (!img.raycastTarget) continue;

                Debug.Log($"[FixRaycast] Root Image found: {img.name} sprite=NULL color={img.color} raycastTarget=true → setting false");
                img.raycastTarget = false;
                EditorUtility.SetDirty(img);
                fixedCount++;
            }
            Debug.Log($"[FixRaycast] Modified {fixedCount} root Image(s)");

            PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);
            Debug.Log($"[FixRaycast] Saved {prefabPath}");
        }
        finally
        {
            PrefabUtility.UnloadPrefabContents(prefab);
        }
        AssetDatabase.Refresh();
    }
}
