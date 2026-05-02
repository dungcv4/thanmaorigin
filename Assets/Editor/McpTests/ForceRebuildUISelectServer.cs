// Same as ForceRebuildUILoginServer but for res_p_191.ab (UISelectServer popup).
using System.IO;
using UnityEngine;
using UnityEditor;

public static class ForceRebuildUISelectServer
{
    public static void Execute()
    {
        const string prefabPath = "Assets/game/ui/views/UISelectServer.prefab";
        const string bundleName = "ui/views/res_p_191.ab";
        const string realBundlePath = "/Users/vsf-user-l/Documents/Test/alo/KTO_Resources/assets/Bundles/Android/ui/views/res_p_191.ab";

        if (!File.Exists(prefabPath)) { Debug.LogError("prefab missing"); return; }

        string outputDir = Path.Combine(Path.GetTempPath(), "ar_bundle_" + System.Guid.NewGuid().ToString("N").Substring(0, 8));
        Directory.CreateDirectory(Path.Combine(outputDir, "ui/views"));

        var build = new AssetBundleBuild
        {
            assetBundleName = bundleName,
            assetNames = new[] { prefabPath },
        };

        var target = EditorUserBuildSettings.activeBuildTarget;
        Debug.Log($"[Force191] target={target} → {outputDir}");

        var manifest = BuildPipeline.BuildAssetBundles(
            outputDir,
            new[] { build },
            BuildAssetBundleOptions.ForceRebuildAssetBundle |
            BuildAssetBundleOptions.ChunkBasedCompression |
            BuildAssetBundleOptions.AssetBundleStripUnityVersion,
            target);

        if (manifest == null) { Debug.LogError("[Force191] null manifest"); return; }

        string bundleFile = Path.Combine(outputDir, bundleName);
        if (!File.Exists(bundleFile)) { Debug.LogError($"[Force191] bundle file not found at {bundleFile}"); return; }

        var fi = new FileInfo(bundleFile);
        Debug.Log($"[Force191] BUILT TEMP — {bundleFile} {fi.Length} bytes mtime={fi.LastWriteTime}");
        File.Copy(bundleFile, realBundlePath, overwrite: true);
        var fi2 = new FileInfo(realBundlePath);
        Debug.Log($"[Force191] COPIED → {realBundlePath} {fi2.Length} bytes mtime={fi2.LastWriteTime}");
        AssetDatabase.Refresh();
    }
}
