// Stop Play mode → on isPlaying false, run ForceRebuildUILoginServer.
// Two-stage execution because BuildAssetBundles is illegal during play.

using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class StopPlayThenRebuild
{
    static StopPlayThenRebuild()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    static bool _pendingRebuild;

    public static void Execute()
    {
        if (EditorApplication.isPlaying)
        {
            Debug.Log("[StopPlayThenRebuild] Currently in Play mode — requesting Stop. Will rebuild after exit.");
            _pendingRebuild = true;
            EditorApplication.isPlaying = false;
        }
        else
        {
            Debug.Log("[StopPlayThenRebuild] Not in Play mode — rebuilding now.");
            ForceRebuildUILoginServer.Execute();
        }
    }

    static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.EnteredEditMode && _pendingRebuild)
        {
            _pendingRebuild = false;
            Debug.Log("[StopPlayThenRebuild] Exited Play. Running ForceRebuildUILoginServer ...");
            ForceRebuildUILoginServer.Execute();
        }
    }
}
