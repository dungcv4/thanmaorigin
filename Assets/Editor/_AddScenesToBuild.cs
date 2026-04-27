using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public static class _AddScenesToBuild
{
    public static void Execute()
    {
        var current = EditorBuildSettings.scenes;
        var existing = new HashSet<string>();
        foreach (var s in current) existing.Add(s.path);

        var toAdd = new List<string>
        {
            "Assets/_Project/Scenes/BootScene.unity",
            "Assets/game/Maps/loginbg/loginbg.unity",
        };
        var newList = new List<EditorBuildSettingsScene>(current);
        int added = 0;
        foreach (var p in toAdd)
        {
            if (existing.Contains(p)) continue;
            if (!System.IO.File.Exists(p)) { Debug.LogWarning("Scene not found: " + p); continue; }
            newList.Add(new EditorBuildSettingsScene(p, true));
            added++;
            Debug.Log("Added scene: " + p);
        }
        EditorBuildSettings.scenes = newList.ToArray();
        Debug.Log($"[AddScenesToBuild] Added {added} scenes. Total now: {newList.Count}");
    }
}
