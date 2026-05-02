using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public static class RespawnUILoginServerRoot
{
    public static void Execute()
    {
        // Clean up any existing UILoginServer (may be wrongly parented from prior test)
        var existing = GameObject.Find("UILoginServer");
        if (existing != null)
        {
            Debug.Log("[Respawn] destroying existing UILoginServer parent=" +
                (existing.transform.parent != null ? existing.transform.parent.name : "<root>"));
            Object.DestroyImmediate(existing);
        }

        const string prefabPath = "Assets/game/ui/views/UILoginServer.prefab";
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        if (prefab == null) { Debug.LogError("[Respawn] prefab missing"); return; }

        // Spawn at scene root (matches original UI flow where UILoginServer is a top-level GameObject)
        var inst = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        inst.name = "UILoginServer";
        SceneManager.MoveGameObjectToScene(inst, SceneManager.GetActiveScene());
        Debug.Log("[Respawn] spawned UILoginServer at scene root");

        var img = GameObject.Find("UILoginServer/imgBG/PanelServer/btnChange/Image")?.GetComponent<Image>();
        if (img == null) { Debug.LogError("[Respawn] btnChange/Image not found"); return; }
        string sprName = img.sprite != null ? img.sprite.name : "<NULL>";
        bool ok = (img.sprite == null) && (img.color.a == 0f);
        Debug.Log("[Respawn] btnChange/Image: sprite=" + sprName + " colorA=" + img.color.a + " => " + (ok ? "OK MATCH GOC" : "STILL WRONG"));
    }
}
