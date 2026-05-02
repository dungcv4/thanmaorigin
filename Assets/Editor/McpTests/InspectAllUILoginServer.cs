using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections.Generic;

public static class InspectAllUILoginServer
{
    public static void Execute()
    {
        var roots = GameObject.FindGameObjectsWithTag("Untagged");
        var ulss = new List<GameObject>();
        foreach (var go in Object.FindObjectsOfType<GameObject>(true))
            if (go.name == "UILoginServer" && go.transform.parent == null)
                ulss.Add(go);
        Debug.Log("[Full] root UILoginServer count=" + ulss.Count);
        foreach (var uls in ulss)
        {
            Debug.Log("[Full] === scene=" + uls.scene.name + " active=" + uls.activeInHierarchy);
            // dump every Graphic
            foreach (var gr in uls.GetComponentsInChildren<Graphic>(true))
            {
                if (!gr.gameObject.activeInHierarchy) continue;
                if (!gr.enabled) continue;
                if (gr.color.a < 0.01f) continue;
                string path = GetPath(gr.transform);
                string type = gr.GetType().Name;
                string what = "";
                if (gr is Image img)
                {
                    bool whiteish = img.color.r > 0.9f && img.color.g > 0.9f && img.color.b > 0.9f;
                    string spr = img.sprite != null ? img.sprite.name : "<NULL>";
                    string flag = (img.sprite == null && whiteish) ? " [NULL-WHITE]"
                                : (img.sprite != null && whiteish && img.sprite.rect.width <= 4 && img.sprite.rect.height <= 4) ? " [TINY-WHITE-SPRITE]"
                                : "";
                    what = "Image" + flag + " sprite=" + spr + " color=(" + img.color.r + "," + img.color.g + "," + img.color.b + "," + img.color.a + ")";
                }
                else if (gr is RawImage ri)
                {
                    string tex = ri.texture != null ? ri.texture.name : "<NULL>";
                    bool whiteish = ri.color.r > 0.9f && ri.color.g > 0.9f && ri.color.b > 0.9f;
                    string flag = (ri.texture == null && whiteish) ? " [NULL-WHITE-RAW]" : "";
                    what = "RawImage" + flag + " tex=" + tex + " color=(" + ri.color.r + "," + ri.color.g + "," + ri.color.b + "," + ri.color.a + ")";
                }
                else if (gr is Text t)
                {
                    what = "Text text='" + t.text + "'";
                }
                else
                {
                    what = type;
                }
                var rt = gr.GetComponent<RectTransform>();
                Debug.Log("[Full] " + path + " | " + what + " | sd=" + rt.sizeDelta + " ap=" + rt.anchoredPosition);
            }
        }
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
