// Force rebuild res_p_137.ab (UILoginServer) with ForceRebuildAssetBundle flag
// to bypass Unity's "no changes detected" cache.

using System.IO;
using UnityEngine;
using UnityEditor;

public static class ForceRebuildUILoginServer
{
    public static void Execute()
    {
        const string prefabPath = "Assets/game/ui/views/UILoginServer.prefab";
        const string bundleName = "ui/views/res_p_137.ab";
        // Build to TEMP outside Assets/, then copy to bundle path. Avoids
        // "build to symlinked StreamingAssets" issue + Play-mode lock.
        string outputDir = Path.Combine(Path.GetTempPath(), "ar_bundle_" + System.Guid.NewGuid().ToString("N").Substring(0, 8));
        const string realBundlePath = "/Users/vsf-user-l/Documents/Test/alo/KTO_Resources/assets/Bundles/Android/ui/views/res_p_137.ab";

        if (!File.Exists(prefabPath)) { Debug.LogError("prefab missing"); return; }

        Directory.CreateDirectory(outputDir);
        Directory.CreateDirectory(Path.Combine(outputDir, "ui/views"));

        var build = new AssetBundleBuild
        {
            assetBundleName = bundleName,
            assetNames = new[] { prefabPath },
        };

        Debug.Log($"[Force] Rebuilding {bundleName} from {prefabPath} to {outputDir}");

        // Use ACTIVE build target (not hardcoded Android — may not be installed)
        var target = EditorUserBuildSettings.activeBuildTarget;
        Debug.Log($"[Force] Active BuildTarget = {target}");

        var manifest = BuildPipeline.BuildAssetBundles(
            outputDir,
            new[] { build },
            BuildAssetBundleOptions.ForceRebuildAssetBundle |
            BuildAssetBundleOptions.ChunkBasedCompression |
            BuildAssetBundleOptions.AssetBundleStripUnityVersion,
            target);

        if (manifest == null)
        {
            Debug.LogError("[Force] Build returned null manifest");
            return;
        }

        // Verify bundle file produced in TEMP
        string bundleFile = Path.Combine(outputDir, bundleName);
        if (File.Exists(bundleFile))
        {
            var fi = new FileInfo(bundleFile);
            Debug.Log($"[Force] BUILT TEMP — {bundleFile} {fi.Length} bytes mtime={fi.LastWriteTime}");
            // Copy over the real bundle path
            File.Copy(bundleFile, realBundlePath, overwrite: true);
            var fi2 = new FileInfo(realBundlePath);
            Debug.Log($"[Force] COPIED → {realBundlePath} {fi2.Length} bytes mtime={fi2.LastWriteTime}");
        }
        else
        {
            Debug.LogError($"[Force] bundle file not found at {bundleFile}");
        }

        AssetDatabase.Refresh();
    }
}
