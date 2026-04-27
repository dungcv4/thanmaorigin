using UnityEditor;
using UnityEngine;

public static class _CheckPlayMode
{
    public static void Execute()
    {
        Debug.Log($"[STATE] isPlaying={EditorApplication.isPlaying} willChange={EditorApplication.isPlayingOrWillChangePlaymode} compiling={EditorApplication.isCompiling} updating={EditorApplication.isUpdating}");
    }
}
