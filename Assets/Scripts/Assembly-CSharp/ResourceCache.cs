// Class:  ResourceCache (static — in-memory asset cache for ResourceModule)
// GUID:   (preserved via .meta — see ResourceCache.cs.meta)
// Source: KiemTheOrigin_DeepExtract/_shared/DecompiledSource/ResourceCache.cs (Token 0x2000064)
// IL2CPP: KTO_DecompiledReference/_root/ResourceCache.c (494 LOC, 5 methods)
//
// PARTIAL 1-1 PORT 2026-04-27 (canonicalization Day 4 — TIER 1 minimal).
// gốc body uses gameObject ref-count pruning, async coroutine collect,
// fnCollectFinish callback, and WeakReference temp cache.
// thanmaorigin DEVIATION: simplified to plain Dictionary cache without LRU/coroutine.
//
// FIXME(canonicalization-day-4): full port deferred to TIER 2 backlog
//   (CollectMemory iterator + WeakReference + lastUseTime LRU prune).

using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public static class ResourceCache
{
    // Nested type — Source: dump.cs (Token 0x2000065)
    // gốc fields: resPath (0x10), loader (0x18), lastUseTime (0x20)
    public class ResourceCacheInfo : System.IComparable<ResourceCacheInfo>
    {
        public string resPath;       // 0x10
        public CommonLoader loader;  // 0x18
        public long lastUseTime;     // 0x20

        // VMA: 0x1809F46 — Source: ResourceCache.c (ResourceCacheInfo.CompareTo)
        // PARTIAL — IL2CPP body unclear (Ghidra stub returns default(int)).
        public int CompareTo(ResourceCacheInfo other)
        {
            if (other == null) return -1;
            return this.lastUseTime.CompareTo(other.lastUseTime);
        }

        // VMA: 0x1809641 — Source: ResourceCache.c (.ctor)
        public ResourceCacheInfo() { }
    }

    // Delegate — Source: dump.cs (Token 0x2000066)
    public delegate void OnCollectFinish();

    // Static fields (offsets from dump.cs)
    public static OnCollectFinish fnCollectFinish;                                  // 0x0
    private static bool m_isCollecting;                                              // 0x8
    private static bool m_isNeedRecollecting;                                        // 0x9
    public static Dictionary<string, ResourceCacheInfo> m_cacheResource              // 0x10
        = new Dictionary<string, ResourceCacheInfo>();
    private static Dictionary<string, System.WeakReference> m_tempCacheRes           // 0x18
        = new Dictionary<string, System.WeakReference>();

    // VMA: 0x18093E5 — Source: ResourceCache.c (DoCache)
    // gốc body (lines 15-114): build ResourceCacheInfo with lastUseTime = DateTime.Now.Ticks,
    //   m_cacheResource[szPath] = info; if exists, replace + RemoveRef on old loader.
    // PARTIAL — keeping minimal upsert. Loader ref-count semantics deferred.
    public static void DoCache(string szPath, CommonLoader loader)
    {
        if (string.IsNullOrEmpty(szPath) || loader == null) return;
        var info = new ResourceCacheInfo
        {
            resPath = szPath,
            loader = loader,
            lastUseTime = System.DateTime.Now.Ticks,
        };
        m_cacheResource[szPath] = info;
    }

    // VMA: 0x1809648 — Source: ResourceCache.c (GetCache)
    // gốc body (lines 115-370): TryGetValue m_cacheResource → bump lastUseTime →
    //   return loader.Asset (CommonLoader+0x38). If miss, check m_tempCacheRes (WeakRef);
    //   on hit, promote to m_cacheResource.
    // PARTIAL — promote-from-temp + WeakRef revival deferred.
    public static Object GetCache(string szPath)
    {
        if (string.IsNullOrEmpty(szPath)) return null;
        if (m_cacheResource.TryGetValue(szPath, out var info) && info != null && info.loader != null)
        {
            info.lastUseTime = System.DateTime.Now.Ticks;
            return info.loader.Asset;
        }
        return null;
    }

    // VMA: 0x1809BE4 — Source: ResourceCache.c (IsCollect)
    // gốc body: return m_isCollecting.
    public static bool IsCollect() { return m_isCollecting; }

    // VMA: 0x1809CA7 — Source: ResourceCache.c (UnloadUnusedAssets)
    // gốc body (lines 371-435): if (m_isCollecting) m_isNeedRecollecting=true; return;
    //   start CollectMemory(bGC) coroutine; m_isCollecting=true.
    // DEVIATION: synchronous Resources.UnloadUnusedAssets + optional GC.Collect.
    public static void UnloadUnusedAssets(bool bGC)
    {
        Resources.UnloadUnusedAssets();
        if (bGC) System.GC.Collect();
    }

    // VMA: 0x1809E0A — Source: ResourceCache.c (GetCacheCount)
    // gốc body (lines 436-468): return m_cacheResource.Count.
    public static int GetCacheCount()
    {
        return m_cacheResource?.Count ?? 0;
    }
}
