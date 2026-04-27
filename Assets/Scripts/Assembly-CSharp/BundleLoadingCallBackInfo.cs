// Class:  BundleLoadingCallBackInfo (data record — entry in BundleLoadingInfo.loadCallBack)
// Source: KiemTheOrigin_DeepExtract/_shared/DecompiledSource/BundleLoadingCallBackInfo.cs (Token 0x200005F)
//
// FULL 1-1 PORT 2026-04-27 (canonicalization Day 4).
// Field offsets cited from dump.cs Token 0x4000193..0x4000195.

using System;

public class BundleLoadingCallBackInfo
{
    // Fields (offsets from dump.cs)
    public Guid requestId;                    // 0x10
    public OnFinishLoadBundle callBackFunc;   // 0x20
    public object[] callBackParam;            // 0x28

    // VMA: 0x1806505 — Source: dump.cs (.ctor)
    // gốc body: System_Object___ctor — empty.
    public BundleLoadingCallBackInfo() { }
}
