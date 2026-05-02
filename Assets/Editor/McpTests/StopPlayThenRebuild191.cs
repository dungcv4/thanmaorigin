// Stop Play → wait for EnteredEditMode → run ForceRebuildUISelectServer.
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class StopPlayThenRebuild191
{
    static StopPlayThenRebuild191()
    {
        EditorApplication.playModeStateChanged += OnState;
    }
    static bool _pending;
    public static void Execute()
    {
        if (EditorApplication.isPlaying)
        {
            Debug.Log("[StopPlay191] Stopping Play. Will rebuild after exit.");
            _pending = true;
            EditorApplication.isPlaying = false;
        }
        else
        {
            Debug.Log("[StopPlay191] Not in Play. Rebuilding now.");
            ForceRebuildUISelectServer.Execute();
        }
    }
    static void OnState(PlayModeStateChange s)
    {
        if (s == PlayModeStateChange.EnteredEditMode && _pending)
        {
            _pending = false;
            Debug.Log("[StopPlay191] Exited Play. Running rebuild ...");
            ForceRebuildUISelectServer.Execute();
        }
    }
}
