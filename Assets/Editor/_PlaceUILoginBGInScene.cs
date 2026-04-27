using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class _PlaceUILoginBGInScene
{
    public static void Execute()
    {
        Debug.Log("[PLACE_TEST] BEGIN");
        Debug.Log($"[PLACE_TEST] isPlaying={Application.isPlaying} isPlayingOrWillChange={EditorApplication.isPlayingOrWillChangePlaymode}");

        // Stop play mode if needed
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
            Debug.Log("[PLACE_TEST] Requested ExitPlaymode (script will need to be re-run)");
            return;
        }

        // Load UILoginBG prefab
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/game/ui/views/UILoginBG.prefab");
        if (prefab == null)
        {
            Debug.LogError("[PLACE_TEST] UILoginBG prefab NULL");
            return;
        }
        Debug.Log($"[PLACE_TEST] Loaded prefab: {prefab.name}");

        var scene = SceneManager.GetActiveScene();
        Debug.Log($"[PLACE_TEST] Active scene: {scene.name}");

        var existing = GameObject.Find("UILoginBG");
        if (existing != null)
        {
            Object.DestroyImmediate(existing);
            Debug.Log("[PLACE_TEST] Destroyed existing UILoginBG");
        }

        var instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        Debug.Log($"[PLACE_TEST] Instantiated: {instance.name}");
        instance.transform.SetParent(null, false);

        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(scene);
        Debug.Log("[PLACE_TEST] DONE — Check Hierarchy and Game view");
        Debug.Log("[PLACE_TEST] END");
    }
}
