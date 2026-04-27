// Class:  BundleManager (static — central AssetBundle pool & loader)
// GUID:   8233c5db221f3492f90c732b3c4a3b4a (preserved via .meta — Day 1 fixed)
// Source: KiemTheOrigin_DeepExtract/_shared/DecompiledSource/BundleManager.cs (Token 0x2000061)
// IL2CPP: KTO_DecompiledReference/_root/BundleManager.c (1779 LOC, 15 methods)
//
// PARTIAL 1-1 PORT 2026-04-27 (canonicalization Day 4 — TIER 1 minimum viable sync path).
//
// gốc relies on:
//   TabStr.Loader (FileAbInfo.tab path-name index — maps assetPath→bundlePath)
//   TabLoader (general .tab reader)
//   AssetBundleManifest (Unity manifest for dependencies)
//   ResourceDef.GetResourceFullPath / GetBuildPlatformName
//   AssetBundle.LoadFromFileAsync (we use sync LoadFromFile)
//
// thanmaorigin DEVIATION (cited per method):
//   1. _LoadFileAbInfo: TabStr.Loader/TabLoader unavailable → s_fileAbInfo stays empty.
//   2. _PreLoadManifest: AssetBundleManifest load deferred (no .ab built yet — Day 4.5).
//   3. LoadBundle async path: only sync (LoaderMode.Sync) implemented.
//   4. ReleaseBundle: simplified ref-count + Unload — no async-loading queue handling.
//
// FIXME(canonicalization-day-4): TIER 2 backlog —
//   • Async LoadBundle path with BundleLoadingInfo + AssetBundleCreateRequest
//   • _LoadFileAbInfo full TabStr port (filepath dictionary)
//   • _PreLoadManifest + GetAllDependencies (manifest-based dep loading)
//   • s_loadingFinishBundle update queue (Update method body)

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class BundleManager
{
    // Nested types — Source: dump.cs (Token 0x2000062 / 0x2000063)
    private class FileAbInfo
    {
        public int abNamen;        // 0x10
        public ABFilePath abFilePath; // 0x14
    }

    private struct ABFilePath
    {
        public int pathn;  // 0x0
        public int filen;  // 0x4

        // VMA: 0x18093DC — Source: BundleManager.c (GetHashCode override)
        // PARTIAL — IL2CPP body unclear. Standard pair-hash.
        public override int GetHashCode()
        {
            unchecked { return (pathn * 397) ^ filen; }
        }
    }

    // Static fields (offsets from dump.cs — Token 0x400019A..0x40001A5)
    private static string s_fileAbInfoPath;                                  // 0x0
    private static string s_fileAbStrPath;                                   // 0x8
    // s_fileAbStr (0x10) is TabStr.Loader — type unavailable; tracked as object.
    private static object s_fileAbStr;                                       // 0x10
    private static Dictionary<ABFilePath, FileAbInfo> s_fileAbInfo           // 0x18
        = new Dictionary<ABFilePath, FileAbInfo>();
    private static Dictionary<int, AbType> s_abTypeInfo                      // 0x20
        = new Dictionary<int, AbType>();
    private static bool s_isLoadBundleManifest;                              // 0x28
    private static AssetBundleManifest s_assetBundleManifest;                // 0x30
    private static HashSet<string> s_tempDependencies                        // 0x38
        = new HashSet<string>();
    private static Dictionary<string, BundleInfo> s_bundlePool               // 0x40
        = new Dictionary<string, BundleInfo>();
    private static HashSet<string> s_loadingBundle                           // 0x48
        = new HashSet<string>();
    private static Dictionary<string, BundleLoadingInfo> s_loadingBundleInfo // 0x50
        = new Dictionary<string, BundleLoadingInfo>();
    private static List<string> s_loadingFinishBundle                        // 0x58
        = new List<string>();

    // VMA: 0x1806582 — Source: BundleManager.c:4572 (Init)
    // gốc body:
    //   if (QualityModule.IsAvailable +8): _LoadFileAbInfo();
    // DEVIATION: QualityModule pack-mode check skipped — always run init.
    public static void Init()
    {
        _LoadFileAbInfo();
    }

    // VMA: 0x1806C8C — Source: BundleManager.c:4604 (Update)
    // gốc body: drain s_loadingFinishBundle each frame —
    //   for each finished BundleLoadingInfo: invoke each BundleLoadingCallBackInfo.callBackFunc;
    //   move from s_loadingBundleInfo → s_bundlePool with BundleInfo entry.
    // DEVIATION: sync path doesn't queue. No-op.
    public static void Update() { }

    // VMA: 0x18065F3 — Source: BundleManager.c:4600 (_LoadFileAbInfo)
    // gốc body (lines 49-280): load FileAbInfo.{platform}.tab + FileAbInfo.{platform}.str.tab,
    //   populate s_fileAbInfo (ABFilePath → abName index) + s_abTypeInfo (abName → AbType).
    // DEVIATION: TabStr.Loader / TabLoader not yet ported (Phase X) — leave empty maps.
    private static void _LoadFileAbInfo()
    {
        // No-op for thanmaorigin TIER 1: s_fileAbInfo + s_abTypeInfo stay empty.
        // Bundle path lookup falls back to convention-based path resolution
        // (see _GetFullBundlePath below).
    }

    // VMA: 0x18075FF — Source: BundleManager.c:5193 (LoadBundle)
    // gốc signature (dump.cs):
    //   public static Guid LoadBundle(string parentBundlePath, string bundlePath,
    //                                  LoaderMode loaderMode, OnFinishLoadBundle callBack,
    //                                  object[] param);
    // gốc body (lines 652-1027 — large):
    //   1. cVar5 = String.IsNullOrEmpty(parentBundlePath);                  // root flag
    //   2. lookup s_bundlePool[bundlePath]:
    //      • hit → bump refCount, clear isRootBundle if non-root, invoke callback, return Guid.Empty
    //   3. if (loaderMode != Sync /* == 1 */):  ASYNC path
    //      • lookup s_loadingBundleInfo[bundlePath]:
    //        - miss: build BundleLoadingInfo, AssetBundle.LoadFromFileAsync(_GetFullBundlePath),
    //                set isRootBundle=cVar5, store
    //        - hit:  if non-root, clear isRootBundle
    //      • register CallBackInfo (NewGuid, callBack, param) into loadCallBack list
    //      • return generated Guid
    //   4. else: SYNC path
    //      • if (s_loadingBundleInfo contains bundlePath): pop it (was async-pending)
    //      • full = _GetFullBundlePath(bundlePath); ab = AssetBundle.LoadFromFile(full)
    //      • if (ab != null):
    //         lookup s_bundlePool: miss → new BundleInfo{bundlePath, bundle=ab,
    //                                                       type=_GetAbType(bundlePath),
    //                                                       refCount=loadingCount+1,
    //                                                       isRootBundle=cVar5}
    //         hit → refCount += loadingCount+1
    //      • else: LogHelper.ERROR
    //      • drain pending async callbacks for this path (CallBackInfo list)
    //      • invoke supplied callBack(ab, param)
    //      • return s_loadingBundleInfo guid (or local 16-byte buffer)
    //
    // thanmaorigin TIER 1: SYNC path only. Async-flow plumbing simplified.
    public static Guid LoadBundle(string parentBundlePath, string bundlePath,
                                  LoaderMode loaderMode, OnFinishLoadBundle callBack,
                                  object[] param)
    {
        if (string.IsNullOrEmpty(bundlePath))
        {
            Debug.LogError("[BundleManager.LoadBundle] bundlePath null/empty");
            callBack?.Invoke(null, param);
            return Guid.Empty;
        }
        bool isRoot = string.IsNullOrEmpty(parentBundlePath);

        // 1. Cache hit?
        if (s_bundlePool.TryGetValue(bundlePath, out var existing) && existing != null)
        {
            existing.refCount++;
            if (!isRoot && existing.isRootBundle) existing.isRootBundle = false;
            callBack?.Invoke(existing.bundle, param);
            return Guid.Empty;
        }

        // 2. SYNC path — gốc takes loaderMode==1 branch (line 859 onward)
        if (loaderMode == LoaderMode.Sync)
        {
            // Drop any pending async loading info for this path (gốc Remove at line 886).
            int pendingLoadingCount = 0;
            if (s_loadingBundleInfo.TryGetValue(bundlePath, out var pending) && pending != null)
            {
                pendingLoadingCount = pending.loadCallBack?.Count ?? 0;
                s_loadingBundleInfo.Remove(bundlePath);
            }

            string full = _GetFullBundlePath(bundlePath);
            AssetBundle ab = null;
            if (!string.IsNullOrEmpty(full) && File.Exists(full))
            {
                // gốc: UnityEngine.AssetBundle.LoadFromFile(full)  (line 897)
                ab = AssetBundle.LoadFromFile(full);
            }
            else
            {
                Debug.LogError($"[BundleManager.LoadBundle] full path missing for '{bundlePath}' (computed='{full}')");
            }

            if (ab != null)
            {
                // Insert into pool (gốc lines 921-942)
                var info = new BundleInfo
                {
                    bundlePath = bundlePath,
                    bundle = ab,
                    type = _GetAbType(bundlePath),
                    refCount = pendingLoadingCount + 1,
                    isRootBundle = isRoot,
                };
                s_bundlePool[bundlePath] = info;
            }
            else
            {
                Debug.LogError($"[BundleManager.LoadBundle] AssetBundle.LoadFromFile NULL for '{bundlePath}'");
            }

            // Drain pending async callbacks (gốc lines 998-1018)
            if (pending != null && pending.loadCallBack != null)
            {
                for (int i = 0; i < pending.loadCallBack.Count; i++)
                {
                    var cb = pending.loadCallBack[i];
                    cb?.callBackFunc?.Invoke(ab, cb.callBackParam);
                }
            }

            // Final supplied callback (gốc lines 1021-1023)
            callBack?.Invoke(ab, param);
            return Guid.Empty;
        }

        // 3. ASYNC path — DEVIATION: not implemented in TIER 1.
        // FIXME(canonicalization-day-4): port AssetBundleCreateRequest path
        Debug.LogWarning($"[BundleManager.LoadBundle] async path NOT IMPLEMENTED (TIER 2). Falling back to sync for '{bundlePath}'.");
        return LoadBundle(parentBundlePath, bundlePath, LoaderMode.Sync, callBack, param);
    }

    // VMA: 0x18081C3 — Source: BundleManager.c:5611 (ReleaseBundle)
    // gốc body (lines 1078-1224): TryGetValue s_bundlePool → refCount-- ;
    //   if (refCount<=0 && !isRootBundle) Unload(false) + Remove from pool.
    //   Also drops pending loadCallBack with matching requestId from s_loadingBundleInfo.
    // PARTIAL — drop async unsubscribe (no async pool yet); sync ref-count + Unload only.
    public static void ReleaseBundle(string parentBundlePath, string bundlePath, AssetBundle bundle, Guid requestId)
    {
        if (string.IsNullOrEmpty(bundlePath)) return;
        if (s_bundlePool.TryGetValue(bundlePath, out var info) && info != null)
        {
            info.refCount--;
            if (info.refCount <= 0 && !info.isRootBundle)
            {
                if (info.bundle != null) info.bundle.Unload(false);
                s_bundlePool.Remove(bundlePath);
            }
        }
    }

    // VMA: 0x1808569 — Source: BundleManager.c:5773 (GetBundle)
    // gốc body (lines 1224-1257):
    //   if (s_bundlePool.TryGetValue(bundlePath, out info)) return info.bundle;
    //   return null;
    public static AssetBundle GetBundle(string bundlePath)
    {
        if (string.IsNullOrEmpty(bundlePath)) return null;
        if (s_bundlePool.TryGetValue(bundlePath, out var info) && info != null)
            return info.bundle;
        return null;
    }

    // VMA: 0x1808602 — Source: BundleManager.c:5795 (GetAllDependencies)
    // gốc body (lines 1270-1352): _PreLoadManifest(); if (url is empty) return null;
    //   Clear s_tempDependencies; _CollectDependencies(url); Remove(url);
    //   convert HashSet → string[] and return.
    // DEVIATION: AssetBundleManifest not loaded (Day 4.5 builds bundles). Returns empty.
    public static string[] GetAllDependencies(string url)
    {
        _PreLoadManifest();
        if (string.IsNullOrEmpty(url)) return null;
        s_tempDependencies.Clear();
        _CollectDependencies(url);
        s_tempDependencies.Remove(url);
        if (s_tempDependencies.Count < 1) return null;
        var arr = new string[s_tempDependencies.Count];
        s_tempDependencies.CopyTo(arr);
        return arr;
    }

    // VMA: 0x1808C18 — Source: BundleManager.c:5851 (GetBundlePathFromAssetPath)
    // gốc body (lines 1563-1660): split assetPath by '/' → lookup ABFilePath{pathn,filen} via
    //   s_fileAbStr.FindStr → s_fileAbInfo.TryGetValue → return abName via s_fileAbStr.Get(abNamen).
    // DEVIATION: TabStr unavailable. We assume convention: assetPath IS the bundlePath
    //   (e.g. "ui/views/UILoginServer" → "ui/views/UILoginServer").
    public static string GetBundlePathFromAssetPath(string assetPath)
    {
        return assetPath; // identity — assetPath = bundlePath in our pipeline
    }

    // VMA: 0x1808E67 — Source: BundleManager.c:5912 (GetBundleType)
    // gốc body (lines 1662-1713): hash bundlePath → lookup s_abTypeInfo TryGetValue → return AbType.
    // DEVIATION: s_abTypeInfo empty (no FileAbInfo.tab). Inspect path prefix to infer type.
    public static AbType GetBundleType(string bundlePath)
    {
        if (string.IsNullOrEmpty(bundlePath)) return AbType.none;
        // Path-prefix heuristic — matches gốc bundle layout under Bundles/Android/<type>/
        if (bundlePath.StartsWith("ui/atlas/") || bundlePath.StartsWith("atlas/")) return AbType.atlas;
        if (bundlePath.StartsWith("ui/views/") || bundlePath.StartsWith("ui/")) return AbType.prefab;
        if (bundlePath.StartsWith("font/")) return AbType.font;
        if (bundlePath.StartsWith("shader/")) return AbType.shader;
        if (bundlePath.StartsWith("scene/") || bundlePath.StartsWith("maps/")) return AbType.unity;
        if (bundlePath.StartsWith("sound/")) return AbType.sound;
        if (bundlePath.StartsWith("npc/") || bundlePath.StartsWith("character/")) return AbType.sprite;
        return AbType.common;
    }

    // VMA: 0x1807558 — Source: BundleManager.c:5184 (_GetAbType private)
    // gốc body (lines 609-639): hash → s_abTypeInfo TryGetValue → return.
    // DEVIATION: same as GetBundleType (uses s_abTypeInfo if populated, else heuristic).
    private static AbType _GetAbType(string bundlePath)
    {
        return GetBundleType(bundlePath);
    }

    // VMA: 0x180811C — Source: BundleManager.c:5578 (_GetFullBundlePath)
    // gốc body (lines 1041-1065):
    //   uVar1 = String.Format(s_fileAbInfoPath_template, *(s_fileAbStr+0x38), bundlePath);
    //   ResourceDef.GetResourceFullPath(uVar1) → walks streamingAssets / persistentDataPath.
    // DEVIATION: ResourceDef.GetResourceFullPath not yet ported. Direct convention:
    //   streamingAssetsPath/Bundles/Android/{bundlePath}.ab
    private static string _GetFullBundlePath(string bundlePath)
    {
        if (string.IsNullOrEmpty(bundlePath)) return null;
        // Convention from CLAUDE.md "Bundle locations" + verified Day 0:
        //   KTO_Resources/assets/Bundles/Android/<logical>.ab
        // → at runtime: Application.streamingAssetsPath/Bundles/Android/<logical>.ab
        return Path.Combine(Application.streamingAssetsPath, "Bundles", "Android", bundlePath + ".ab");
    }

    // VMA: 0x180880A — Source: BundleManager.c:5886 (_PreLoadManifest)
    // gốc body (lines 1365-1477): if (s_isLoadBundleManifest) return;
    //   load AssetBundleManifest .ab from platform path; LoadAsset<AssetBundleManifest>("AssetBundleManifest");
    //   set s_isLoadBundleManifest=true.
    // DEVIATION: Manifest .ab not built yet (Day 4.5). No-op.
    private static void _PreLoadManifest()
    {
        if (s_isLoadBundleManifest) return;
        s_isLoadBundleManifest = true;
        // FIXME(canonicalization-day-4.5): load AssetBundleManifest after bundles built.
    }

    // VMA: 0x1808AA7 — Source: BundleManager.c:5837 (_CollectDependencies recursive)
    // gốc body (lines 1478-1562): manifest.GetDirectDependencies(url); for each dep
    //   not in s_tempDependencies, add then recurse.
    // DEVIATION: no manifest → no deps to collect.
    private static void _CollectDependencies(string url)
    {
        if (s_assetBundleManifest == null) return;
        var deps = s_assetBundleManifest.GetDirectDependencies(url);
        if (deps == null) return;
        foreach (var dep in deps)
        {
            if (string.IsNullOrEmpty(dep)) continue;
            if (s_tempDependencies.Add(dep))
                _CollectDependencies(dep);
        }
    }
}
