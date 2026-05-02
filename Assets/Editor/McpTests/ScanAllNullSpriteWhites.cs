using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;

public static class ScanAllNullSpriteWhites
{
    public static void Execute()
    {
        var hits = new List<(string path, Image img, RectTransform rt)>();
        foreach (var img in Object.FindObjectsOfType<Image>(true))
        {
            if (!img.gameObject.activeInHierarchy) continue;
            if (!img.enabled) continue;
            if (img.color.a < 0.01f) continue;
            if (img.sprite != null) continue;
            // null sprite + visible + enabled
            string path = GetPath(img.transform);
            var rt = img.GetComponent<RectTransform>();
            hits.Add((path, img, rt));
        }
        Debug.Log("[Scan] found " + hits.Count + " null-sprite visible Images in scene");
        // sort by area descending so big white boxes come first
        hits.Sort((a, b) =>
        {
            float aA = Mathf.Abs(a.rt.sizeDelta.x * a.rt.sizeDelta.y);
            float bA = Mathf.Abs(b.rt.sizeDelta.x * b.rt.sizeDelta.y);
            return bA.CompareTo(aA);
        });
        int n = 0;
        foreach (var h in hits)
        {
            float area = Mathf.Abs(h.rt.sizeDelta.x * h.rt.sizeDelta.y);
            // world position
            var corners = new Vector3[4];
            h.rt.GetWorldCorners(corners);
            Debug.Log("[Scan] " + h.path
                + " | sd=" + h.rt.sizeDelta
                + " | area=" + area.ToString("F0")
                + " | color=(" + h.img.color.r + "," + h.img.color.g + "," + h.img.color.b + "," + h.img.color.a + ")"
                + " | worldBL=" + corners[0] + " worldTR=" + corners[2]);
            n++;
            if (n >= 25) { Debug.Log("[Scan] ... (truncated)"); break; }
        }
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
