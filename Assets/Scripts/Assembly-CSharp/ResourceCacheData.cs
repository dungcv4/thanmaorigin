// Class:  ResourceCacheData (asset cache entry with refcount)
// GUID:   da212345e887548caa0a55e3057ff5a4 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/ResourceCacheData.c (5 methods, 100 LOC)
//
// FULL 1-1 PORT 2026-04-27 (canonicalization Day 4).
// Field offsets inferred from IL2CPP body access patterns:
//   +0x18: long timestamp (int64) — used by CompareTo
//   +0x20: int refCount       — incremented by AddRef, decremented by RemoveRef

using System;

public class ResourceCacheData : IComparable<ResourceCacheData>
{
    // Fields — inferred from IL2CPP offsets (gốc has no public DecompiledSource for this)
    public string resPath;       // 0x10 — convention (string handle slot)
    public long lastUseTime;     // 0x18 — System_Int64 (used by CompareTo)
    public int refCount;         // 0x20 — int (used by AddRef/RemoveRef/GetRefCount)
    public object loader;        // 0x28 — CommonLoader / generic loader handle

    // VMA: 0x019037ba — Source: ResourceCacheData.c (.ctor)
    // gốc body: System_Object___ctor — empty.
    public ResourceCacheData() { }

    // VMA: 0x01900fb1 — Source: ResourceCacheData.c (CompareTo)
    // gốc body:
    //   if (other != null) return Int64.CompareTo(this+0x18, other+0x18);
    //   return 0xffffffff (-1).
    public int CompareTo(ResourceCacheData other)
    {
        if (other == null) return -1;
        return this.lastUseTime.CompareTo(other.lastUseTime);
    }

    // VMA: 0x01913bf8 — Source: ResourceCacheData.c (AddRef)
    // gốc body: *(int*)(this+0x20) = *(int*)(this+0x20) + 1;
    public void AddRef() { refCount++; }

    // VMA: 0x01913bfc — Source: ResourceCacheData.c (RemoveRef)
    // gốc body: *(int*)(this+0x20) = *(int*)(this+0x20) - 1;
    public void RemoveRef() { refCount--; }

    // VMA: 0x01913c00 — Source: ResourceCacheData.c (GetRefCount)
    // gốc body: return *(int*)(this+0x20);
    public int GetRefCount() { return refCount; }
}
