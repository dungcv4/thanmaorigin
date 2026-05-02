using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class InspectWhiteSprites
{
    public static void Execute()
    {
        string[] roots = new string[]
        {
            "UILoginServer/imgBG/PanelServer",
            "UISelectServer/node/imgBG/Content/PanelServerList/MaskView/List/Element1",
            "UISelectServer/node/imgBG/Content/PanelServerList/MaskView/List/Element2",
        };
        foreach (var root in roots)
        {
            var go = GameObject.Find(root);
            if (go == null)
            {
                Debug.Log("[Inspect] not found: " + root);
                continue;
            }
            Debug.Log("[Inspect] === " + root + " ===");
            var imgs = go.GetComponentsInChildren<Image>(true);
            foreach (var img in imgs)
            {
                if (!img.enabled) continue;
                if (!img.gameObject.activeInHierarchy) continue;
                string path = GetPath(img.transform);
                string sprName = img.sprite != null ? img.sprite.name : "<NULL>";
                string sprPath = img.sprite != null ? AssetDatabase.GetAssetPath(img.sprite) : "<NULL>";
                var rt = img.GetComponent<RectTransform>();
                var sd = rt != null ? rt.sizeDelta : Vector2.zero;
                var ap = rt != null ? rt.anchoredPosition : Vector2.zero;
                bool isWhiteBox = (img.sprite == null) && (img.color.a > 0.01f);
                string flag = isWhiteBox ? " [WHITE-BOX]" : "";
                Debug.Log("[Inspect]" + flag + " " + path
                    + " | sprite=" + sprName
                    + " | path=" + sprPath
                    + " | sd=" + sd
                    + " | ap=" + ap
                    + " | colorA=" + img.color.a);
            }
        }
    }

    static string GetPath(Transform t)
    {
        if (t == null) return "";
        string p = t.name;
        var parent = t.parent;
        while (parent != null)
        {
            p = parent.name + "/" + p;
            parent = parent.parent;
        }
        return p;
    }
}
