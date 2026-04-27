// Class:  BundleInfo (data record — entry in BundleManager.s_bundlePool)
// GUID:   345ff6ffb146a43e28effea75a18aa31 (preserved via .meta)
// Source: KiemTheOrigin_DeepExtract/_shared/DecompiledSource/BundleInfo.cs (Token 0x200005D)
// IL2CPP: KTO_DecompiledReference/_root/BundleInfo.c (47 LOC, CompareTo only)
//
// FULL 1-1 PORT 2026-04-27 (canonicalization Day 4).
// Field order + offsets cited from dump.cs.

using System;
using UnityEngine;

public class BundleInfo : IComparable<BundleInfo>
{
    // Fields (offsets from dump.cs — Token 0x400018D..0x4000192)
    public string bundlePath;       // 0x10
    public AssetBundle bundle;      // 0x18
    public AbType type;             // 0x20
    public int refCount;            // 0x24
    public float lastUnUseTime;     // 0x28
    public bool isRootBundle;       // 0x2C

    // VMA: 0x18063BB — Source: KTO_DecompiledReference/_root/BundleInfo.c (CompareTo)
    // gốc body: WARNING — Ghidra produced a default(int) stub. Implementing
    //   conventional ordering on bundlePath since CompareTo<BundleInfo> in gốc
    //   isn't actually called from any reachable site (was generated for
    //   IComparable<T> interface satisfaction only).
    // PARTIAL — IL2CPP body unclear (Ghidra stub). Implementing string-based
    //   comparison so SortedSet/SortedDictionary callers behave deterministically.
    public int CompareTo(BundleInfo other)
    {
        if (other == null) return 1;
        if (object.ReferenceEquals(this, other)) return 0;
        return string.Compare(this.bundlePath, other.bundlePath, StringComparison.Ordinal);
    }

    // VMA: 0x18063D6 — Source: BundleInfo.c (.ctor)
    // gốc body: System_Object___ctor — empty.
    public BundleInfo() { }
}
