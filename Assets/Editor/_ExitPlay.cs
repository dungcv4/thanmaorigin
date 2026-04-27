using UnityEditor;
using UnityEngine;

public static class _ExitPlay
{
    public static void Execute()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExitPlaymode();
            Debug.Log("[EXIT_PLAY] requested");
        }
        else
        {
            Debug.Log("[EXIT_PLAY] not in play mode");
        }
    }
}
