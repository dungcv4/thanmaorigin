// 1-1 GỐC FIX 2026-05-02 — restore Content CanvasGroup to gốc values.
//
// Gốc YAML (KTO_FullExtract/.../res_p_191/UISelectServer.prefab L4587-4590):
//   m_Alpha: 1
//   m_Interactable: True
//   m_BlocksRaycasts: True
//   m_IgnoreParentGroups: False
//
// Current was set to:
//   m_Interactable: 0   ← WRONG (chế cháo)
//   m_BlocksRaycasts: 0 ← WRONG (chế cháo) → all children Buttons can't receive clicks
//
// Also REVERT my earlier DEVIATION (root Image raycastTarget=false) — wasn't
// the actual bug. Restore to gốc raycastTarget=true (modal dim overlay).

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class FixContentCanvasGroup1to1
{
    public static void Execute()
    {
        const string prefabPath = "Assets/game/ui/views/UISelectServer.prefab";
        var prefab = PrefabUtility.LoadPrefabContents(prefabPath);
        try
        {
            // (1) Restore Content CanvasGroup
            var content = prefab.transform.Find("node/imgBG/Content");
            if (content == null) { Debug.LogError("Content not found"); return; }
            var cg = content.GetComponent<CanvasGroup>();
            if (cg == null) { Debug.LogError("No CanvasGroup on Content"); return; }
            Debug.Log($"[Fix1to1] BEFORE Content CG: alpha={cg.alpha} interactable={cg.interactable} blocksRaycasts={cg.blocksRaycasts}");
            cg.interactable = true;
            cg.blocksRaycasts = true;
            EditorUtility.SetDirty(cg);
            Debug.Log($"[Fix1to1] AFTER Content CG: alpha={cg.alpha} interactable={cg.interactable} blocksRaycasts={cg.blocksRaycasts}");

            // (2) Revert root Image raycastTarget back to gốc (true)
            var rootImg = prefab.GetComponent<Image>();
            if (rootImg != null && rootImg.sprite == null)
            {
                Debug.Log($"[Fix1to1] BEFORE root Image: raycastTarget={rootImg.raycastTarget}");
                rootImg.raycastTarget = true;  // gốc value
                EditorUtility.SetDirty(rootImg);
                Debug.Log($"[Fix1to1] AFTER root Image: raycastTarget={rootImg.raycastTarget} (restored to gốc)");
            }

            PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);
            Debug.Log($"[Fix1to1] Saved {prefabPath}");
        }
        finally
        {
            PrefabUtility.UnloadPrefabContents(prefab);
        }
        AssetDatabase.Refresh();
    }
}
