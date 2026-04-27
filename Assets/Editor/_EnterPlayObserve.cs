// Enter Play mode and let runtime observe what happens.
// Logs all warnings/errors during boot. After 30 seconds we exit.
using UnityEditor;
using UnityEngine;

public static class _EnterPlayObserve
{
    public static void Execute()
    {
        Debug.Log("[ENTER_PLAY] BEGIN");
        if (EditorApplication.isPlaying)
        {
            Debug.Log("[ENTER_PLAY] Already in play mode");
            return;
        }
        // Open BootScene first
        var scenePath = "Assets/_Project/Scenes/BootScene.unity";
        var scene = UnityEditor.SceneManagement.EditorSceneManager.OpenScene(scenePath, UnityEditor.SceneManagement.OpenSceneMode.Single);
        Debug.Log($"[ENTER_PLAY] Opened {scene.name}");
        // Enter play
        EditorApplication.EnterPlaymode();
        Debug.Log("[ENTER_PLAY] EnterPlaymode requested");
    }
}
