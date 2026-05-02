using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class InspectAllPanelServer
{
    public static void Execute()
    {
        var go = GameObject.Find("UILoginServer/imgBG/PanelServer");
        if (go == null) { Debug.Log("[All] not found"); return; }

        // Walk every descendant, check ANY UI Graphic (Image, RawImage, Text)
        var graphics = go.GetComponentsInChildren<Graphic>(true);
        Debug.Log("[All] found " + graphics.Length + " graphics");
        foreach (var gr in graphics)
        {
            string path = GetPath(gr.transform);
            string type = gr.GetType().Name;
            bool active = gr.gameObject.activeInHierarchy;
            bool en = gr.enabled;
            float a = gr.color.a;
            string sprName = "";
            string sprPath = "";
            string extra = "";
            if (gr is Image img)
            {
                sprName = img.sprite != null ? img.sprite.name : "<NULL>";
                sprPath = img.sprite != null ? AssetDatabase.GetAssetPath(img.sprite) : "<NULL>";
                extra = " color=" + ColorToHex(img.color) + " sprite=" + sprName;
            }
            else if (gr is RawImage ri)
            {
                sprName = ri.texture != null ? ri.texture.name : "<NULL>";
                sprPath = ri.texture != null ? AssetDatabase.GetAssetPath(ri.texture) : "<NULL>";
                extra = " color=" + ColorToHex(ri.color) + " tex=" + sprName;
            }
            else if (gr is Text t)
            {
                extra = " text='" + t.text + "'";
            }
            var rt = gr.GetComponent<RectTransform>();
            string rect = rt != null ? "sd=" + rt.sizeDelta + " ap=" + rt.anchoredPosition : "";

            string flag = "";
            if (gr is Image img2 && img2.sprite == null && a > 0.01f && active && en)
                flag = " [WHITE]";
            if (gr is RawImage ri2 && ri2.texture == null && a > 0.01f && active && en)
                flag = " [WHITE-RAW]";
            Debug.Log("[All]" + flag + " " + type + " " + path
                + " active=" + active + " en=" + en + " a=" + a
                + extra + " " + rect + " path=" + sprPath);
        }
    }
    static string GetPath(Transform t)
    {
        string p = t.name;
        var par = t.parent;
        while (par != null) { p = par.name + "/" + p; par = par.parent; }
        return p;
    }
    static string ColorToHex(Color c)
    {
        return string.Format("({0:F2},{1:F2},{2:F2},{3:F2})", c.r, c.g, c.b, c.a);
    }
}
