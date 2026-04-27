using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public static class _TestLoadUIHud
{
    public static void Execute()
    {
        Debug.Log("[HUD_TEST] BEGIN");
        const string path = "Assets/game/ui/views/UIHud.prefab";

        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceSynchronousImport | ImportAssetOptions.ForceUpdate);
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        if (prefab == null)
        {
            Debug.Log("[HUD_TEST] LoadAssetAtPath: NULL");
            Debug.Log("[HUD_TEST] END");
            return;
        }
        Debug.Log($"[HUD_TEST] Root: {prefab.name}, children={prefab.transform.childCount}");

        var images = prefab.GetComponentsInChildren<Image>(true);
        var texts = prefab.GetComponentsInChildren<Text>(true);
        var buttons = prefab.GetComponentsInChildren<Button>(true);
        var canvases = prefab.GetComponentsInChildren<Canvas>(true);

        int withSprite = 0;
        foreach (var img in images) if (img.sprite != null) withSprite++;

        Debug.Log($"[HUD_TEST] Images: {images.Length} (with sprite: {withSprite})");
        Debug.Log($"[HUD_TEST] Texts:   {texts.Length}");
        Debug.Log($"[HUD_TEST] Buttons: {buttons.Length}");
        Debug.Log($"[HUD_TEST] Canvases:{canvases.Length}");

        Debug.Log("[HUD_TEST] END");
    }
}
