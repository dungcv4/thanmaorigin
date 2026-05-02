using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class TraceUILoginServerSource
{
    public static void Execute()
    {
        var img = GameObject.Find("UILoginServer/imgBG/PanelServer/btnChange/Image")?.GetComponent<Image>();
        if (img == null) { Debug.Log("[Trace] btnChange/Image not found"); return; }

        Debug.Log("[Trace] btnChange/Image LIVE: sprite=" + (img.sprite != null ? img.sprite.name : "<NULL>")
            + " color=(" + img.color.r + "," + img.color.g + "," + img.color.b + "," + img.color.a + ")");

        // Walk up to find prefab root
        Transform root = img.transform;
        while (root.parent != null) root = root.parent;
        Debug.Log("[Trace] root GO name=" + root.name + " scene=" + root.gameObject.scene.name);

        // Get prefab source if linked
        var src = PrefabUtility.GetCorrespondingObjectFromSource(root.gameObject);
        if (src != null)
        {
            string srcPath = AssetDatabase.GetAssetPath(src);
            Debug.Log("[Trace] PrefabUtility source path=" + srcPath);
            // Read source's btnChange/Image
            var srcImg = src.transform.Find("imgBG/PanelServer/btnChange/Image")?.GetComponent<Image>();
            if (srcImg != null)
            {
                Debug.Log("[Trace] PREFAB source btnChange/Image: sprite=" + (srcImg.sprite != null ? srcImg.sprite.name : "<NULL>")
                    + " a=" + srcImg.color.a);
            }
        }
        else
        {
            Debug.Log("[Trace] no PrefabUtility source — was instantiated by code, not linked to prefab asset");
        }

        // Load Assets/.../UILoginServer.prefab via AssetDatabase to verify edit took effect
        var assetPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/game/ui/views/UILoginServer.prefab");
        if (assetPrefab != null)
        {
            var assetImg = assetPrefab.transform.Find("imgBG/PanelServer/btnChange/Image")?.GetComponent<Image>();
            if (assetImg != null)
                Debug.Log("[Trace] Assets/.../UILoginServer.prefab btnChange/Image: sprite=" + (assetImg.sprite != null ? assetImg.sprite.name : "<NULL>") + " a=" + assetImg.color.a);
        }

        // Apply runtime fix to LIVE instance to confirm
        img.sprite = null;
        var c = img.color; c.a = 0; img.color = c;
        img.SetAllDirty();
        Debug.Log("[Trace] applied runtime fix: a=" + img.color.a);
    }
}
