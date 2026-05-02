// Deep diag why Element1 isn't being raycast.
// Check IsRaycastLocationValid + ScrollRect viewport + Mask + canvas pixelRect.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;

public static class DiagElement1RaycastDeep
{
    public static void Execute()
    {
        Debug.Log("=== DiagElement1RaycastDeep START ===");
        var roots = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => go.name == "UISelectServer" && go.scene.IsValid() && !EditorUtility.IsPersistent(go))
            .ToArray();
        if (roots.Length == 0) { Debug.LogError("popup not in scene"); return; }
        var root = roots[0];

        var canvas = root.GetComponentInChildren<Canvas>();
        Debug.Log($"  Screen: {Screen.width}x{Screen.height}  Canvas pixelRect={canvas.pixelRect} scaleFactor={canvas.scaleFactor}");

        var elem = root.transform.Find("node/imgBG/Content/PanelServerList/MaskView/List/Element1") as RectTransform;
        var img = elem.GetComponent<Image>();
        var btn = elem.GetComponent<Button>();
        Vector3[] cs = new Vector3[4];
        elem.GetWorldCorners(cs);
        Debug.Log($"  Element1 worldCorners: BL={cs[0]} TL={cs[1]} TR={cs[2]} BR={cs[3]}");
        Debug.Log($"  Element1 sizeDelta={elem.sizeDelta} lossyScale={elem.lossyScale}");
        Debug.Log($"  Image alphaHitTestMinimumThreshold={img.alphaHitTestMinimumThreshold} useSpriteMesh={img.useSpriteMesh}");
        Debug.Log($"  Button targetGraphic={(btn.targetGraphic!=null?btn.targetGraphic.name:"NULL")} interactable={btn.interactable}");

        // Walk parent chain — list ALL CanvasGroup, Mask, RectMask2D, ScrollRect
        Debug.Log("  Parent chain components:");
        Transform t = elem;
        while (t != null && t.GetComponent<Canvas>() == null)
        {
            var cg = t.GetComponent<CanvasGroup>();
            var m = t.GetComponent<Mask>();
            var rm = t.GetComponent<RectMask2D>();
            var sr = t.GetComponent<ScrollRect>();
            string note = "";
            if (cg != null) note += $" CG(a={cg.alpha},blocks={cg.blocksRaycasts},inter={cg.interactable})";
            if (m != null) note += " Mask";
            if (rm != null)
            {
                var rrt = (t as RectTransform);
                Vector3[] mcs = new Vector3[4];
                rrt.GetWorldCorners(mcs);
                note += $" RectMask2D(rect=({mcs[0].x:F1},{mcs[0].y:F1})→({mcs[2].x:F1},{mcs[2].y:F1}))";
            }
            if (sr != null) note += " SR";
            if (!string.IsNullOrEmpty(note)) Debug.Log($"    {t.name}: {note}");
            t = t.parent;
        }

        // IsRaycastLocationValid at Element1 worldCenter
        Vector2 wc = (cs[0] + cs[2]) * 0.5f;
        bool valid = img.IsRaycastLocationValid(wc, null);
        Debug.Log($"  Image.IsRaycastLocationValid({wc}, null) = {valid}");

        // Try at a few sample points
        var samples = new[] {
            cs[0] + new Vector3(5, 5, 0),       // near BL corner
            (cs[0] + cs[2]) * 0.5f,             // center
            cs[2] - new Vector3(5, 5, 0),       // near TR
            new Vector3(Screen.width/2f, Screen.height/2f, 0),  // screen center
        };
        var es = EventSystem.current;
        foreach (var sp in samples)
        {
            var ped = new PointerEventData(es) { position = new Vector2(sp.x, sp.y) };
            var results = new List<RaycastResult>();
            es.RaycastAll(ped, results);
            string firstHit = results.Count > 0 ? GetPath(results[0].gameObject.transform) + " (so="+results[0].sortingOrder+",d="+results[0].depth+")" : "NO HIT";
            Debug.Log($"  RaycastAll@({sp.x:F1},{sp.y:F1}): hits={results.Count} TOP={firstHit}");
        }

        Debug.Log("=== END ===");
    }

    static string GetPath(Transform t)
    {
        var stack = new Stack<string>();
        while (t != null) { stack.Push(t.name); t = t.parent; }
        return string.Join("/", stack);
    }
}
