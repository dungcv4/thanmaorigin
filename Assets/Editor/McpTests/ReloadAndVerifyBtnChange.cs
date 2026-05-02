using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Linq;

public static class ReloadAndVerifyBtnChange
{
    public static void Execute()
    {
        AssetDatabase.Refresh();
        AssetDatabase.SaveAssets();
        Debug.Log("[Verify] AssetDatabase refreshed");

        // Find existing UILoginServer instance and force re-spawn it from prefab
        var existing = GameObject.Find("UILoginServer");
        if (existing != null)
        {
            Debug.Log("[Verify] Destroying existing UILoginServer instance to force re-spawn");
            Object.DestroyImmediate(existing);
        }

        // Reload the prefab from disk and instantiate
        const string prefabPath = "Assets/game/ui/views/UILoginServer.prefab";
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab == null)
        {
            Debug.LogError("[Verify] prefab not found: " + prefabPath);
            return;
        }
        // Find a Canvas to parent under (preserve original scene parenting)
        var canvas = Object.FindObjectsOfType<Canvas>()
            .FirstOrDefault(c => c.gameObject.name.Contains("UIRoot")
                              || c.renderMode == RenderMode.ScreenSpaceOverlay);
        Transform parent = canvas != null ? canvas.transform : null;
        var inst = (GameObject)PrefabUtility.InstantiatePrefab(prefab, parent);
        inst.name = "UILoginServer";
        Debug.Log("[Verify] re-instantiated UILoginServer under "
            + (parent != null ? parent.name : "<root>"));

        // Inspect btnChange/Image
        var img = GameObject.Find("UILoginServer/imgBG/PanelServer/btnChange/Image")?.GetComponent<Image>();
        if (img == null)
        {
            Debug.LogError("[Verify] btnChange/Image not found");
            return;
        }
        string sprName = img.sprite != null ? img.sprite.name : "<NULL>";
        bool ok = (img.sprite == null) && (img.color.a == 0f);
        Debug.Log("[Verify] btnChange/Image: sprite=" + sprName + " colorA=" + img.color.a + " => " + (ok ? "OK MATCH GOC" : "STILL WRONG"));
    }
}
