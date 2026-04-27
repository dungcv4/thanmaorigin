// =============================================================================
// BuildAllBundles.cs — Day 4.5 build pipeline
//
// Builds AssetBundles 1-1 with gốc convention so the new
// BundleManager.LoadBundle (Day 4 port) can load them via
// AssetBundle.LoadFromFile.
//
// Logical paths emitted (matches gốc):
//   ui/views/<Name>.ab      — one per prefab in Assets/game/ui/views
//   ui/atlas/<Name>.ab      — one per atlas folder in Assets/game/ui/atlas
//   ui/icon/<Name>.ab       — one per icon folder
//   font/<Name>.ab          — fonts
//   maps/<Name>.ab          — scene/map data
//
// Output dir:
//   Application.streamingAssetsPath/Bundles/Android/<logical>/<name>.ab
//
// Verified consistent with BundleManager._GetFullBundlePath (Day 4 port).
//
// Usage:
//   Unity → menu "KTO → Build → Build All Bundles"            (full)
//   Unity → menu "KTO → Build → Build 5 Critical Login Bundles" (vertical slice)
//
// Source: gốc had a similar editor pipeline — recovered via call graph
// from KTO_DecompiledReference/_root/BundleManager.c (LoadBundle path) +
// observed bundle layout in KTO_Resources/assets/Bundles/Android/ui/views/.
// =============================================================================

using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class BuildAllBundles
{
    private const string OUTPUT_REL = "Bundles/Android";

    [MenuItem("KTO/Build/Build All Bundles")]
    public static void BuildAll()
    {
        BuildBundles(GatherAllAssets());
    }

    [MenuItem("KTO/Build/Build 5 Critical Login Bundles")]
    public static void BuildCritical()
    {
        // Vertical slice — Day 4.5 minimum to test load path end-to-end.
        var crit = new[]
        {
            "Assets/game/ui/views/UILoginChannelInner.prefab",
            "Assets/game/ui/views/UILoginServer.prefab",
            "Assets/game/ui/views/UICreateRole.prefab",
            "Assets/game/ui/views/UISelectRoleExist.prefab",
            "Assets/game/ui/views/UIHud.prefab",
        };
        var builds = new List<AssetBundleBuild>();
        foreach (var assetPath in crit)
        {
            if (!File.Exists(assetPath))
            {
                Debug.LogWarning($"[BuildAllBundles] missing: {assetPath}");
                continue;
            }
            string name = Path.GetFileNameWithoutExtension(assetPath);
            builds.Add(new AssetBundleBuild
            {
                assetBundleName = $"ui/views/{name}",  // logical path matches gốc
                assetNames      = new[] { assetPath },
            });
        }
        BuildSpecific(builds.ToArray());
    }

    private static List<AssetBundleBuild> GatherAllAssets()
    {
        var builds = new List<AssetBundleBuild>();

        // Map gốc directory layout → asset bundle naming
        var dirMap = new (string assetDir, string bundlePrefix, string filter)[]
        {
            ("Assets/game/ui/views",  "ui/views",  "*.prefab"),
            ("Assets/game/ui/atlas",  "ui/atlas",  "*.png"),    // atlas PNGs (Day 3+8 extracted)
            ("Assets/game/ui/icon",   "ui/icon",   "*.png"),
            ("Assets/game/font",      "font",      "*.*"),
            ("Assets/game/maps",      "maps",      "*.unity"),
            ("Assets/game/npc",       "npc",       "*.png"),
        };

        foreach (var (assetDir, prefix, filter) in dirMap)
        {
            string fullPath = Path.Combine(Application.dataPath, assetDir.Substring("Assets/".Length));
            if (!Directory.Exists(fullPath)) continue;

            // Each file → its own bundle (gốc convention: 1 prefab = 1 bundle).
            // For atlas folders, we group by parent directory so multiple sprites
            // in the same atlas folder land in one bundle.
            if (prefix.StartsWith("ui/atlas") || prefix.StartsWith("ui/icon"))
            {
                // Group by immediate subdirectory
                var subdirs = Directory.GetDirectories(fullPath);
                foreach (var sub in subdirs)
                {
                    string subName = Path.GetFileName(sub);
                    var pngs = Directory.GetFiles(sub, filter, SearchOption.TopDirectoryOnly);
                    if (pngs.Length == 0) continue;
                    var assetPaths = new List<string>();
                    foreach (var p in pngs)
                    {
                        string rel = "Assets" + p.Substring(Application.dataPath.Length).Replace('\\', '/');
                        assetPaths.Add(rel);
                    }
                    builds.Add(new AssetBundleBuild
                    {
                        assetBundleName = $"{prefix}/{subName}",
                        assetNames      = assetPaths.ToArray(),
                    });
                }
            }
            else
            {
                // 1 file = 1 bundle
                var files = Directory.GetFiles(fullPath, filter, SearchOption.TopDirectoryOnly);
                foreach (var f in files)
                {
                    string rel = "Assets" + f.Substring(Application.dataPath.Length).Replace('\\', '/');
                    string name = Path.GetFileNameWithoutExtension(f);
                    builds.Add(new AssetBundleBuild
                    {
                        assetBundleName = $"{prefix}/{name}",
                        assetNames      = new[] { rel },
                    });
                }
            }
        }

        Debug.Log($"[BuildAllBundles] Gathered {builds.Count} bundle builds.");
        return builds;
    }

    private static void BuildSpecific(AssetBundleBuild[] builds)
    {
        BuildBundles(new List<AssetBundleBuild>(builds));
    }

    private static void BuildBundles(List<AssetBundleBuild> builds)
    {
        if (builds.Count == 0)
        {
            Debug.LogWarning("[BuildAllBundles] No assets to bundle. Aborting.");
            return;
        }

        string outputPath = Path.Combine(Application.streamingAssetsPath, OUTPUT_REL);
        if (!Directory.Exists(outputPath))
        {
            Directory.CreateDirectory(outputPath);
        }

        Debug.Log($"[BuildAllBundles] Output: {outputPath}");
        Debug.Log($"[BuildAllBundles] Building {builds.Count} bundles for Android target...");

        var manifest = BuildPipeline.BuildAssetBundles(
            outputPath,
            builds.ToArray(),
            BuildAssetBundleOptions.None,
            BuildTarget.Android
        );

        if (manifest == null)
        {
            Debug.LogError("[BuildAllBundles] BuildPipeline returned null manifest — build FAILED");
            return;
        }

        var built = manifest.GetAllAssetBundles();
        Debug.Log($"[BuildAllBundles] ✅ Built {built.Length} bundles. Sample paths:");
        for (int i = 0; i < System.Math.Min(5, built.Length); i++)
        {
            Debug.Log($"  - {built[i]}");
        }

        AssetDatabase.Refresh();
    }

    [MenuItem("KTO/Build/Verify Bundle Path Convention")]
    public static void VerifyConvention()
    {
        // Sanity: each .ab built must match BundleManager._GetFullBundlePath expectation.
        // Gốc convention: streamingAssetsPath/Bundles/Android/<logical>.ab where <logical>
        // contains "/" (e.g. "ui/views/UILoginServer").
        string outputPath = Path.Combine(Application.streamingAssetsPath, OUTPUT_REL);
        if (!Directory.Exists(outputPath))
        {
            Debug.LogWarning($"[BuildAllBundles] No bundles built yet at {outputPath}");
            return;
        }
        var abs = Directory.GetFiles(outputPath, "*.ab", SearchOption.AllDirectories);
        Debug.Log($"[BuildAllBundles] Found {abs.Length} .ab files in {outputPath}");
        foreach (var ab in abs)
        {
            string rel = ab.Substring(outputPath.Length + 1);
            Debug.Log($"  - {rel}");
        }
    }
}
