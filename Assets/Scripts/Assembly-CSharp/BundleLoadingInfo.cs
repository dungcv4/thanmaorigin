// Class:  BundleLoadingInfo (data record — entry in BundleManager.s_loadingBundleInfo)
// GUID:   c6dc669f61fcc46bf967fa40047af49b (preserved via .meta)
// Source: KiemTheOrigin_DeepExtract/_shared/DecompiledSource/BundleLoadingInfo.cs (Token 0x2000060)
// IL2CPP: KTO_DecompiledReference/_root/BundleLoadingInfo.c (37 LOC, .ctor only)
//
// FULL 1-1 PORT 2026-04-27 (canonicalization Day 4).
// Field offsets cited from dump.cs Token 0x4000196..0x4000199.

using System.Collections.Generic;
using UnityEngine;

public class BundleLoadingInfo
{
    // Fields (offsets from dump.cs)
    public AssetBundle bundle;                              // 0x10
    public AssetBundleCreateRequest request;                // 0x18
    public List<BundleLoadingCallBackInfo> loadCallBack;    // 0x20
    public bool isRootBundle;                               // 0x28

    // VMA: 0x180650C — Source: BundleLoadingInfo.c (.ctor)
    // gốc body: System_Object___ctor + initialise loadCallBack list.
    public BundleLoadingInfo()
    {
        loadCallBack = new List<BundleLoadingCallBackInfo>();
    }
}
