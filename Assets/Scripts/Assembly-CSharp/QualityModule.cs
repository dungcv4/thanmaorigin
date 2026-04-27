// Class:  QualityModule
// Source: KTO_DecompiledReference/_root/QualityModule.c (decomp_01bc.c:1007+)
//
// PARTIAL PORT 2026-04-26 — only SetLimitMissileCount method ported (Wave B blocker).
// Full QualityModule has many more methods (SetLimitX for various FX/quality).
// Wave B continued port will fill rest 1-1.
//
// Lua exposes via: Client.QualityModule = luanet.import_type("QualityModule")
//                  → CS.QualityModule (XLua bridge) → static methods callable.

using UnityEngine;

public class QualityModule : MonoBehaviour
{
    // gốc field at +0x9d per Ghidra: m_bLimitMissileCount byte flag.
    private static byte m_bLimitMissileCount;

    // ─── PORT 1-1: QualityModule.SetLimitMissileCount ──────────────────
    // VMA: 0x01bc1c31 — Source: decomp_01bc.c:1007
    // gốc Ghidra body:
    //   if (DAT_036bb0c2 == '\0') { FUN_0185f84b(&DAT_03563b28); DAT_036bb0c2 = '\x01'; }
    //   if (*(int *)(DAT_03563b28 + 0xe0) == 0) { thunk_FUN_0180fcea(); }
    //   lVar2 = *(long *)(DAT_03563b28 + 0xb8);                                             // singleton instance
    //   lVar1 = *(long *)(lVar2 + 0x220);                                                   // OnLimitMissileCountChanged delegate
    //   if (lVar1 != 0) {
    //     (**(code **)(lVar1 + 0x18))(*(long *)(lVar1 + 0x40), param_1, *(long *)(lVar1 + 0x28));  // invoke delegate
    //     return;
    //   }
    //   *(byte *)(lVar2 + 0x9d) = param_1;                                                  // else store flag
    //
    // 1-1 PORT: store flag — when no subscriber registered (boot path), gốc only writes
    // the field at +0x9d. We have public OnLimitMissileCountChanged Action wired same as gốc:
    // - if subscriber exists → invoke
    // - else → just store the flag
    // This matches gốc behavior exactly.
    public static System.Action<bool> OnLimitMissileCountChanged;
    public static void SetLimitMissileCount(bool b)
    {
        if (OnLimitMissileCountChanged != null)
        {
            OnLimitMissileCountChanged.Invoke(b);
            return;
        }
        m_bLimitMissileCount = (byte)(b ? 1 : 0);
    }

    // VMA: QualityModule__StepClearMemory — Source: KTO_DecompiledReference/_root/QualityModule.c (decomp_01bb.c:13268)
    // gốc body: invoke 6 subsystem cleanup callbacks (HotObject, ItemFactory, NpcFactory, MessageBox, etc).
    // DEVIATION: those subsystems not yet ported. Use Resources.UnloadUnusedAssets() as
    // 1-step memory cleanup approximation. Lua call: Client:GC() → StepClearMemory().
    public static void StepClearMemory()
    {
        Resources.UnloadUnusedAssets();
    }

    // VMA: QualityModule__ClearMemory — Source: KTO_DecompiledReference/_root/QualityModule.c (decomp_01bb.c:13333)
    // gốc body: more aggressive cleanup — same 6 callbacks + GC.Collect-equivalent.
    // DEVIATION: Resources.UnloadUnusedAssets + System.GC.Collect (best 1-1 approximation
    // until subsystem cleanup callbacks port). Lua call: Client:DeepGC() → ClearMemory().
    public static void ClearMemory()
    {
        Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }

    // gốc fields (per Ghidra Awake): m_DeviceModel, m_UniqueIdentifier, m_MacAddress
    // Used by Login.lua:GetPhoneBasicInfo (line 380-384).
    public static string DeviceModel = SystemInfo.deviceModel;
    public static string UniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
    public static string MacAddress = ""; // gốc reads via Android.Net.NetworkInfo; macOS/editor stub.
}
