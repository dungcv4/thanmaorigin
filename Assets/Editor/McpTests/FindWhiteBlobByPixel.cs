using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;

public static class FindWhiteBlobByPixel
{
    public static void Execute()
    {
        // Pause Unity to freeze state
        EditorApplication.isPaused = true;
        Debug.Log("[Px] Unity paused. Screen=" + Screen.width + "x" + Screen.height);

        // Find every active visible Image with sprite=null+white OR with white sprite -- regardless of position
        var ucr = GameObject.Find("UICreateRole");
        if (ucr == null) { Debug.Log("[Px] no UICreateRole — game must be in another state"); return; }

        // For each Image, compute SCREEN rect (in actual pixels) by transforming RT corners through canvas
        Debug.Log("[Px] === All Images in UICreateRole, with screen-pixel rect ===");
        foreach (var img in ucr.GetComponentsInChildren<Image>(true))
        {
            if (!img.gameObject.activeInHierarchy) continue;
            if (!img.enabled) continue;
            if (img.color.a < 0.5f) continue;
            var rt = img.GetComponent<RectTransform>();
            var canvas = img.canvas;
            if (canvas == null) continue;

            // Use canvas.worldCamera or null + canvas.scaleFactor for ScreenSpaceOverlay
            var c4 = new Vector3[4];
            rt.GetWorldCorners(c4);
            // For ScreenSpaceOverlay, world corners already in pixel coords (since canvas matches Screen)
            // For ScreenSpaceCamera/WorldSpace, need camera projection
            Vector2 sBL, sTR;
            if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                sBL = new Vector2(c4[0].x, c4[0].y);
                sTR = new Vector2(c4[2].x, c4[2].y);
            }
            else
            {
                Camera cam = canvas.worldCamera;
                sBL = RectTransformUtility.WorldToScreenPoint(cam, c4[0]);
                sTR = RectTransformUtility.WorldToScreenPoint(cam, c4[2]);
            }

            string sprName = img.sprite != null ? img.sprite.name : "<NULL>";
            bool whiteish = img.color.r > 0.85f && img.color.g > 0.85f && img.color.b > 0.85f;
            string flag = "";
            if (img.sprite == null && whiteish) flag = " [NULL-W]";
            else if (img.sprite != null && whiteish && img.sprite.rect.width <= 4 && img.sprite.rect.height <= 4) flag = " [TINY-W]";

            Debug.Log("[Px]" + flag + " " + GetPath(img.transform)
                + " | sprite=" + sprName + " color=" + img.color
                + " | screenBL=" + sBL.ToString("F0") + " screenTR=" + sTR.ToString("F0"));
        }
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
