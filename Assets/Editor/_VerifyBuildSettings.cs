using UnityEditor;
using UnityEngine;

public static class _VerifyBuildSettings
{
    public static void Execute()
    {
        AssetDatabase.Refresh();
        var scenes = EditorBuildSettings.scenes;
        Debug.Log($"[BUILD_SETTINGS] Total scenes: {scenes.Length}");
        for (int i = 0; i < scenes.Length; i++)
        {
            Debug.Log($"  [{i}] enabled={scenes[i].enabled} path={scenes[i].path}");
        }
    }
}
