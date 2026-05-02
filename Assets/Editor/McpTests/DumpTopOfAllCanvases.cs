using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

public static class DumpTopOfAllCanvases
{
    public static void Execute()
    {
        Debug.Log("[Top] Screen=" + Screen.width + "x" + Screen.height);
        var hits = new List<(string path, Graphic gr, Rect screenRect)>();
        foreach (var gr in Object.FindObjectsOfType<Graphic>(true))
        {
            if (!gr.gameObject.activeInHierarchy) continue;
            if (!gr.enabled) continue;
            if (gr.color.a < 0.5f) continue;
            if (gr is Text || gr.GetType().Name.StartsWith("Text")) continue;
            var rt = gr.GetComponent<RectTransform>();
            if (rt == null) continue;
            var canvas = gr.canvas;
            if (canvas == null) continue;
            Camera cam = (canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : canvas.worldCamera;
            var c4 = new Vector3[4];
            rt.GetWorldCorners(c4);
            var sBL = RectTransformUtility.WorldToScreenPoint(cam, c4[0]);
            var sTR = RectTransformUtility.WorldToScreenPoint(cam, c4[2]);
            float xMin = Mathf.Min(sBL.x, sTR.x), xMax = Mathf.Max(sBL.x, sTR.x);
            float yMin = Mathf.Min(sBL.y, sTR.y), yMax = Mathf.Max(sBL.y, sTR.y);
            hits.Add((GetPath(gr.transform), gr, new Rect(xMin, yMin, xMax-xMin, yMax-yMin)));
        }
        // Sort by yMax descending -> topmost first
        hits.Sort((a, b) => b.screenRect.yMax.CompareTo(a.screenRect.yMax));
        Debug.Log("[Top] total visible non-text graphics=" + hits.Count + " (sorted by topmost screenY)");
        int n = 0;
        foreach (var h in hits)
        {
            string sprName = "<n/a>";
            string col = "";
            if (h.gr is Image img) { sprName = img.sprite != null ? img.sprite.name : "<NULL>"; col = " color=" + img.color; }
            else if (h.gr is RawImage ri) { sprName = "[tex]" + (ri.texture != null ? ri.texture.name : "<NULL>"); col = " color=" + ri.color; }
            Debug.Log("[Top] yMax=" + h.screenRect.yMax.ToString("F0")
                + " xRange=[" + h.screenRect.xMin.ToString("F0") + ".." + h.screenRect.xMax.ToString("F0") + "]"
                + " yRange=[" + h.screenRect.yMin.ToString("F0") + ".." + h.screenRect.yMax.ToString("F0") + "]"
                + " | " + h.path + " | " + h.gr.GetType().Name + " sprite=" + sprName + col);
            n++;
            if (n >= 20) break;
        }
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
