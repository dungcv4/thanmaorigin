using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class _DumpScene
{
    public static void Execute()
    {
        var scene = SceneManager.GetActiveScene();
        Debug.Log($"[SCENE] active={scene.name} loaded={scene.isLoaded}");
        foreach (var root in scene.GetRootGameObjects())
        {
            DumpGO(root, 0);
        }
        Debug.Log("[SCENE] === DontDestroyOnLoad ===");
        // GetAllScenes
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var s = SceneManager.GetSceneAt(i);
            Debug.Log($"[SCENE] scene[{i}] {s.name} loaded={s.isLoaded}");
            foreach (var r in s.GetRootGameObjects())
            {
                DumpGO(r, 0);
            }
        }
    }
    static void DumpGO(GameObject go, int depth)
    {
        Debug.Log($"[SCENE] {new string(' ', depth*2)}{go.name} active={go.activeSelf} (children={go.transform.childCount})");
        for (int i = 0; i < go.transform.childCount && i < 5; i++)
            DumpGO(go.transform.GetChild(i).gameObject, depth + 1);
    }
}
