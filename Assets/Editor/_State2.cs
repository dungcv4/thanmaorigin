using UnityEditor;
using UnityEngine;

public static class _State2
{
    public static void Execute()
    {
        Debug.Log($"[STATE2] isPlaying={EditorApplication.isPlaying} willChange={EditorApplication.isPlayingOrWillChangePlaymode} compiling={EditorApplication.isCompiling} updating={EditorApplication.isUpdating}");
    }
}
