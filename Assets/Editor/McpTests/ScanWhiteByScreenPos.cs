using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;

public static class ScanWhiteByScreenPos
{
    public static void Execute()
    {
        // The big white box in the latest screenshot is at top-right.
        // Screenshot is 1374x711. White box approx x:1040..1330, y:0..140 (top is y=0 in image, but Unity world y is flipped).
        // We'll dump every Graphic in scene whose RT bounds overlap the top-right region.

        var cam = Camera.main;
        var canvases = Object.FindObjectsOfType<Canvas>(true);
        Debug.Log("[ScanW] canvases=" + canvases.Length);

        var hits = new List<(string path, Graphic gr, Vector3[] corners, float area)>();
        foreach (var gr in Object.FindObjectsOfType<Graphic>(true))
        {
            if (!gr.gameObject.activeInHierarchy) continue;
            if (!gr.enabled) continue;
            if (gr.color.a < 0.05f) continue;
            var rt = gr.GetComponent<RectTransform>();
            if (rt == null) continue;
            var corners = new Vector3[4];
            rt.GetWorldCorners(corners);
            // Convert to screen coords using the canvas's camera (or null for ScreenSpaceOverlay)
            var canvas = gr.canvas;
            Camera renderCam = (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay) ? canvas.worldCamera : null;
            var screenBL = RectTransformUtility.WorldToScreenPoint(renderCam, corners[0]);
            var screenTR = RectTransformUtility.WorldToScreenPoint(renderCam, corners[2]);
            // top-right region in screen: x > 950, y > Screen.height - 200 (Unity screen y=0 at bottom)
            if (Mathf.Max(screenBL.x, screenTR.x) > 900 &&
                Mathf.Max(screenBL.y, screenTR.y) > Screen.height - 220)
            {
                float w = Mathf.Abs(screenTR.x - screenBL.x);
                float h = Mathf.Abs(screenTR.y - screenBL.y);
                float a = w * h;
                if (a < 200) continue; // skip tiny
                hits.Add((GetPath(gr.transform), gr, new Vector3[] { screenBL, screenTR }, a));
            }
        }
        hits.Sort((a, b) => b.area.CompareTo(a.area));
        Debug.Log("[ScanW] top-right region hits=" + hits.Count + " (Screen=" + Screen.width + "x" + Screen.height + ")");
        int n = 0;
        foreach (var h in hits)
        {
            string detail = "";
            if (h.gr is Image img)
            {
                detail = "Image sprite=" + (img.sprite != null ? img.sprite.name : "<NULL>")
                    + " color=(" + img.color.r + "," + img.color.g + "," + img.color.b + "," + img.color.a + ")"
                    + " type=" + img.type;
                if (img.sprite != null)
                    detail += " spriteRect=" + img.sprite.rect.size;
            }
            else if (h.gr is RawImage ri)
            {
                detail = "RawImage tex=" + (ri.texture != null ? ri.texture.name : "<NULL>")
                    + " color=(" + ri.color.r + "," + ri.color.g + "," + ri.color.b + "," + ri.color.a + ")";
            }
            else
            {
                detail = h.gr.GetType().Name;
            }
            Debug.Log("[ScanW] " + h.path + " | screenBL=" + h.corners[0] + " TR=" + h.corners[1] + " | " + detail);
            n++;
            if (n >= 30) break;
        }
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
