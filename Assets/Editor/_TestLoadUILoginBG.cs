using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public static class _TestLoadUILoginBG
{
    public static void Execute()
    {
        Debug.Log("[LOAD_TEST] BEGIN");
        const string path = "Assets/game/ui/views/UILoginBG.prefab";

        // Force re-import to make sure Tuanjie reads new file content from disk
        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceSynchronousImport | ImportAssetOptions.ForceUpdate);

        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        if (prefab == null)
        {
            Debug.Log("[LOAD_TEST] LoadAssetAtPath: NULL");
            Debug.Log("[LOAD_TEST] END");
            return;
        }
        Debug.Log($"[LOAD_TEST] Root: {prefab.name}, children={prefab.transform.childCount}");

        // Walk tree, count Images and check populated fields
        var images = prefab.GetComponentsInChildren<Image>(true);
        Debug.Log($"[LOAD_TEST] Image count (incl inactive): {images.Length}");
        int withSprite = 0, withColor = 0, totalNonNullColor = 0;
        foreach (var img in images)
        {
            if (img.sprite != null) withSprite++;
            // Check non-default values
            if (img.color != Color.clear) totalNonNullColor++;
            if (img.color != default) withColor++;
        }
        Debug.Log($"[LOAD_TEST]   Images with sprite assigned: {withSprite}/{images.Length}");
        Debug.Log($"[LOAD_TEST]   Images with non-default color: {withColor}/{images.Length}");

        // Print first 3 image details
        for (int i = 0; i < System.Math.Min(3, images.Length); i++)
        {
            var img = images[i];
            Debug.Log($"[LOAD_TEST]   [Image {i}] name={img.name} sprite={(img.sprite == null ? "NULL" : img.sprite.name)} color={img.color} type={img.type} fillAmount={img.fillAmount}");
        }

        // Also count CanvasScaler/Canvas/Texts
        var canvases = prefab.GetComponentsInChildren<Canvas>(true);
        var scalers = prefab.GetComponentsInChildren<CanvasScaler>(true);
        var texts = prefab.GetComponentsInChildren<Text>(true);
        Debug.Log($"[LOAD_TEST] Canvas={canvases.Length} CanvasScaler={scalers.Length} Text={texts.Length}");

        Debug.Log("[LOAD_TEST] END");
    }
}
