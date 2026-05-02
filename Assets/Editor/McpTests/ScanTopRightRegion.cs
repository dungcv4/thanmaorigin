using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;

public static class ScanTopRightRegion
{
    public static void Execute()
    {
        // Scan everything with screen rect overlapping top-right corner
        // Screen is 1739x993. Top-right region: x > 1300, y > 750
        Debug.Log("[TR] Screen=" + Screen.width + "x" + Screen.height);
        int xMin = 1300, yMin = 750;
        var hits = new List<(string path, Graphic gr, Rect rect)>();
        foreach (var gr in Object.FindObjectsOfType<Graphic>(true))
        {
            if (!gr.gameObject.activeInHierarchy) continue;
            if (!gr.enabled) continue;
            var rt = gr.GetComponent<RectTransform>();
            if (rt == null) continue;
            var canvas = gr.canvas;
            if (canvas == null) continue;
            Camera cam = (canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : canvas.worldCamera;
            var c = new Vector3[4];
            rt.GetWorldCorners(c);
            var sBL = RectTransformUtility.WorldToScreenPoint(cam, c[0]);
            var sTR = RectTransformUtility.WorldToScreenPoint(cam, c[2]);
            var rect = new Rect(Mathf.Min(sBL.x, sTR.x), Mathf.Min(sBL.y, sTR.y),
                                Mathf.Abs(sTR.x - sBL.x), Mathf.Abs(sTR.y - sBL.y));
            if (rect.xMax < xMin || rect.yMax < yMin) continue;
            if (rect.width < 50 || rect.height < 50) continue;
            hits.Add((GetPath(gr.transform), gr, rect));
        }
        hits.Sort((a, b) => (b.rect.width * b.rect.height).CompareTo(a.rect.width * a.rect.height));
        Debug.Log("[TR] hits=" + hits.Count);
        int n = 0;
        foreach (var h in hits)
        {
            string detail = "";
            if (h.gr is Image img)
            {
                string sprName = img.sprite != null ? img.sprite.name : "<NULL>";
                string sprPath = img.sprite != null ? AssetDatabase.GetAssetPath(img.sprite) : "<NULL>";
                bool whiteish = img.color.r > 0.85f && img.color.g > 0.85f && img.color.b > 0.85f && img.color.a > 0.85f;
                detail = "Image sprite=" + sprName + " (path=" + sprPath + ") white=" + whiteish + " color=" + img.color
                    + (img.sprite != null ? " spriteRect=" + img.sprite.rect.size : "");
            }
            else if (h.gr is RawImage ri)
            {
                detail = "RawImage tex=" + (ri.texture != null ? ri.texture.name : "<NULL>") + " color=" + ri.color;
            }
            else if (h.gr is Text t)
            {
                detail = "Text '" + t.text + "' color=" + t.color;
            }
            else
            {
                detail = h.gr.GetType().Name;
            }
            Debug.Log("[TR] " + h.path + " | rect=" + h.rect + " | " + detail);
            n++; if (n >= 25) break;
        }
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
