using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class DumpCanvasesNonText
{
    public static void Execute()
    {
        Debug.Log("[CN] === root GameObjects in active scene ===");
        var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        foreach (var root in scene.GetRootGameObjects())
        {
            Debug.Log("[CN] root: " + root.name + " active=" + root.activeInHierarchy);
        }

        Debug.Log("[CN] === EVERY visible Image+RawImage with sprite NULL or color ~white ===");
        foreach (var gr in Object.FindObjectsOfType<Graphic>(true))
        {
            if (!gr.gameObject.activeInHierarchy) continue;
            if (!gr.enabled) continue;
            if (gr.color.a < 0.5f) continue;
            if (gr is Text || gr.GetType().Name.StartsWith("Text")) continue;
            string sprName = "";
            bool whiteish = false;
            if (gr is Image img)
            {
                sprName = img.sprite != null ? img.sprite.name : "<NULL>";
                whiteish = img.color.r > 0.85f && img.color.g > 0.85f && img.color.b > 0.85f;
                if (img.sprite == null && whiteish)
                {
                    var rt = img.GetComponent<RectTransform>();
                    Debug.Log("[CN] [NULL-W] " + GetPath(gr.transform) + " sd=" + rt.sizeDelta + " ap=" + rt.anchoredPosition + " | parent=" + (gr.transform.parent != null ? gr.transform.parent.name : "null"));
                }
            }
            else if (gr is RawImage ri)
            {
                whiteish = ri.color.r > 0.85f && ri.color.g > 0.85f && ri.color.b > 0.85f;
                if (ri.texture == null && whiteish)
                {
                    var rt = ri.GetComponent<RectTransform>();
                    Debug.Log("[CN] [NULL-W-RAW] " + GetPath(gr.transform) + " sd=" + rt.sizeDelta + " ap=" + rt.anchoredPosition);
                }
            }
        }
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
