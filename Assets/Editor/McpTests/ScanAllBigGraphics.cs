using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;

public static class ScanAllBigGraphics
{
    public static void Execute()
    {
        Debug.Log("[Big] Screen=" + Screen.width + "x" + Screen.height);
        foreach (var c in Object.FindObjectsOfType<Canvas>(true))
        {
            Debug.Log("[Big] canvas '" + c.gameObject.name + "' active=" + c.gameObject.activeInHierarchy
                + " mode=" + c.renderMode + " sortOrder=" + c.sortingOrder
                + " path=" + GetPath(c.transform));
        }

        var graphics = new List<(string path, Graphic gr, float area, Image img, RawImage ri)>();
        foreach (var gr in Object.FindObjectsOfType<Graphic>(true))
        {
            if (!gr.gameObject.activeInHierarchy) continue;
            if (!gr.enabled) continue;
            if (gr.color.a < 0.5f) continue;
            // skip text
            if (gr is Text || gr.GetType().Name.StartsWith("Text")) continue;
            var rt = gr.GetComponent<RectTransform>();
            if (rt == null) continue;
            var c4 = new Vector3[4];
            rt.GetWorldCorners(c4);
            // Skip 3D things, only canvas-based
            var canvas = gr.canvas;
            if (canvas == null) continue;
            Camera cam = (canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : canvas.worldCamera;
            var sBL = RectTransformUtility.WorldToScreenPoint(cam, c4[0]);
            var sTR = RectTransformUtility.WorldToScreenPoint(cam, c4[2]);
            float w = Mathf.Abs(sTR.x - sBL.x), h = Mathf.Abs(sTR.y - sBL.y);
            float a = w * h;
            if (a < 5000) continue;
            graphics.Add((GetPath(gr.transform), gr, a, gr as Image, gr as RawImage));
        }
        graphics.Sort((x, y) => y.area.CompareTo(x.area));
        Debug.Log("[Big] big-area visible graphics=" + graphics.Count);
        int n = 0;
        foreach (var g in graphics)
        {
            string detail;
            if (g.img != null)
            {
                bool whiteish = g.img.color.r > 0.85f && g.img.color.g > 0.85f && g.img.color.b > 0.85f;
                detail = "Image sprite=" + (g.img.sprite != null ? g.img.sprite.name : "<NULL>")
                    + " white=" + whiteish + " color=" + g.img.color;
            }
            else if (g.ri != null)
            {
                bool whiteish = g.ri.color.r > 0.85f && g.ri.color.g > 0.85f && g.ri.color.b > 0.85f;
                detail = "RawImage tex=" + (g.ri.texture != null ? g.ri.texture.name : "<NULL>")
                    + " white=" + whiteish + " color=" + g.ri.color;
            }
            else detail = g.gr.GetType().Name;
            Debug.Log("[Big] area=" + g.area.ToString("F0") + " " + g.path + " | " + detail);
            n++;
            if (n >= 30) break;
        }
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
