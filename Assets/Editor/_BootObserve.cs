// Phase A.1 — observe Lua boot in Editor without Play mode.
// Open BootScene (only) and DON'T enter Play. Just check that prefab refs / scene refs
// resolve correctly. Then user/we enter Play manually + watch log.
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class _BootObserve
{
    public static void Execute()
    {
        Debug.Log("[BOOT_OBS] BEGIN");
        // Make sure not in Play mode
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
            Debug.Log("[BOOT_OBS] Not yet — in Play mode, requested exit, re-run");
            return;
        }
        var scene = EditorSceneManager.OpenScene("Assets/_Project/Scenes/BootScene.unity", OpenSceneMode.Single);
        Debug.Log($"[BOOT_OBS] Opened scene: {scene.name}, isLoaded={scene.isLoaded}");
        // Iterate all root GameObjects + components
        var roots = scene.GetRootGameObjects();
        Debug.Log($"[BOOT_OBS] Root objects: {roots.Length}");
        foreach (var go in roots)
        {
            var comps = go.GetComponents<Component>();
            Debug.Log($"[BOOT_OBS]   {go.name}: {comps.Length} components");
            foreach (var c in comps)
            {
                if (c == null)
                {
                    Debug.LogWarning($"[BOOT_OBS]     - <missing script>");
                }
                else
                {
                    Debug.Log($"[BOOT_OBS]     - {c.GetType().FullName}");
                }
            }
        }
        Debug.Log("[BOOT_OBS] END");
    }
}
