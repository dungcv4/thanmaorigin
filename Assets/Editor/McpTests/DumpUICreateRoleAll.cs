using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class DumpUICreateRoleAll
{
    public static void Execute()
    {
        var ucr = GameObject.Find("UICreateRole");
        if (ucr == null) { Debug.Log("[D] no UICreateRole"); return; }
        Debug.Log("[D] Screen=" + Screen.width + "x" + Screen.height);
        foreach (var gr in ucr.GetComponentsInChildren<Graphic>(true))
        {
            if (!gr.gameObject.activeInHierarchy) continue;
            if (!gr.enabled) continue;
            if (gr.color.a < 0.1f) continue;
            // skip texts to reduce noise
            if (gr is Text || gr.GetType().Name.StartsWith("Text")) continue;
            var rt = gr.GetComponent<RectTransform>();
            if (rt == null) continue;
            var canvas = gr.canvas;
            Camera cam = (canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay) ? canvas.worldCamera : null;
            var c4 = new Vector3[4];
            rt.GetWorldCorners(c4);
            var sBL = RectTransformUtility.WorldToScreenPoint(cam, c4[0]);
            var sTR = RectTransformUtility.WorldToScreenPoint(cam, c4[2]);
            string sprName = "<null>";
            string colStr = "";
            if (gr is Image img)
            {
                sprName = img.sprite != null ? img.sprite.name : "<NULL>";
                colStr = " color=" + img.color;
            }
            else if (gr is RawImage ri)
            {
                sprName = ri.texture != null ? ri.texture.name : "<NULL>";
                colStr = " color=" + ri.color;
            }
            Debug.Log("[D] " + GetPath(gr.transform) + " | type=" + gr.GetType().Name
                + " sprite=" + sprName + colStr
                + " | sBL=" + sBL + " sTR=" + sTR);
        }
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
