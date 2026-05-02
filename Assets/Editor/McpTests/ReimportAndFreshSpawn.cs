using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public static class ReimportAndFreshSpawn
{
    public static void Execute()
    {
        const string prefabPath = "Assets/game/ui/views/UILoginServer.prefab";
        // Force Unity to re-import the .prefab file from disk (in case of external edit caching)
        AssetDatabase.ImportAsset(prefabPath, ImportAssetOptions.ForceUpdate);
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        Debug.Log("[Re] reimported " + prefabPath);

        // Destroy any stale UILoginServer in scene
        var stale = GameObject.Find("UILoginServer");
        if (stale != null)
        {
            Debug.Log("[Re] destroying stale instance");
            Object.DestroyImmediate(stale);
        }

        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab == null) { Debug.LogError("[Re] prefab missing"); return; }

        // Verify the asset itself
        var assetImg = prefab.transform.Find("imgBG/PanelServer/btnChange/Image")?.GetComponent<Image>();
        if (assetImg != null)
            Debug.Log("[Re] ASSET prefab btnChange/Image: sprite=" + (assetImg.sprite != null ? assetImg.sprite.name : "<NULL>") + " a=" + assetImg.color.a);

        // Spawn fresh
        var inst = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        inst.name = "UILoginServer";
        SceneManager.MoveGameObjectToScene(inst, SceneManager.GetActiveScene());
        var instImg = GameObject.Find("UILoginServer/imgBG/PanelServer/btnChange/Image")?.GetComponent<Image>();
        if (instImg != null)
            Debug.Log("[Re] LIVE instance btnChange/Image: sprite=" + (instImg.sprite != null ? instImg.sprite.name : "<NULL>") + " a=" + instImg.color.a
                + " => " + ((instImg.sprite == null && instImg.color.a == 0f) ? "OK MATCH GOC" : "STILL WRONG"));
    }
}
