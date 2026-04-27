using UnityEditor;
using UnityEditor.Compilation;
using UnityEngine;

public static class _ForceRecompile
{
    public static void Execute()
    {
        Debug.Log("[ForceRecompile] Refreshing + RequestScriptCompilation...");
        AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        CompilationPipeline.RequestScriptCompilation(RequestScriptCompilationOptions.CleanBuildCache);
        Debug.Log("[ForceRecompile] Done");
    }
}
