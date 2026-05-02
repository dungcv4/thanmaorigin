// Why isn't Element1 receiving raycast at its own worldCenter?
// Hypothesis: Mask on parent MaskView clips it OR Element1 sizeDelta=0.

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;

public static class DiagMaskClip
{
    public static void Execute()
    {
        Debug.Log("=== DiagMaskClip START ===");
        var roots = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => go.name == "UISelectServer" && go.scene.IsValid() && !EditorUtility.IsPersistent(go))
            .ToArray();
        if (roots.Length == 0) { Debug.LogError("UISelectServer not in scene"); return; }
        var root = roots[0];

        var paths = new[]
        {
            "node/imgBG/Content/PanelServerList/MaskView",
            "node/imgBG/Content/PanelServerList/MaskView/List",
            "node/imgBG/Content/PanelServerList/MaskView/List/Element1",
            "node/imgBG/Content/PanelServerList/MaskView/List/Element2",
            "node/imgBG/Content/PanelKindList/MaskView",
            "node/imgBG/Content/PanelKindList/MaskView/List",
            "node/imgBG/Content/PanelKindList/MaskView/List/Element1",
        };

        foreach (var p in paths)
        {
            var t = root.transform.Find(p) as RectTransform;
            if (t == null) { Debug.Log($"  {p}: NOT FOUND"); continue; }

            Vector3[] corners = new Vector3[4];
            t.GetWorldCorners(corners);
            Vector2 wcMin = corners[0];
            Vector2 wcMax = corners[2];

            var img = t.GetComponent<Image>();
            var msk = t.GetComponent<Mask>();
            var rmsk = t.GetComponent<RectMask2D>();
            var btn = t.GetComponent<Button>();
            var canvasGroup = t.GetComponent<CanvasGroup>();
            var sr = t.GetComponent<UnityEngine.UI.ScrollRect>();

            string info = $"sizeDelta={t.sizeDelta} worldRect=({wcMin.x:F1},{wcMin.y:F1})→({wcMax.x:F1},{wcMax.y:F1}) active={t.gameObject.activeSelf}";
            string comps = "";
            if (img != null) comps += $" Image(rt={img.raycastTarget},sprite={(img.sprite!=null?img.sprite.name:"null")},a={img.color.a:F2})";
            if (msk != null) comps += $" Mask(showGraphic={msk.showMaskGraphic})";
            if (rmsk != null) comps += $" RectMask2D";
            if (btn != null) comps += " Button";
            if (canvasGroup != null) comps += $" CanvasGroup(a={canvasGroup.alpha},blocksRaycasts={canvasGroup.blocksRaycasts},interactable={canvasGroup.interactable})";
            if (sr != null) comps += " ScrollRect";

            Debug.Log($"  {p}");
            Debug.Log($"    {info}{comps}");
        }

        Debug.Log("=== END ===");
    }
}
