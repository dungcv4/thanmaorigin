// Class:  ChannelModule
// GUID:   a461510befa8c9a616795b5c7cbd49b7 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/ChannelModule.c (decomp_0191.c:10133+)
//
// PARTIAL PORT 2026-04-26 — only SetReferenceResolution method ported.
// Full ChannelModule has many more methods (Hotfix, login flow, payment etc.)
// Wave B continued port will fill rest 1-1.
//
// Lua exposes this as `Sdk` global table via LuaEngine binding.
// gốc XLua wrapper: KTO_DecompiledReference/XLua.CSObjectWrap/ChannelModuleWrap.c

using UnityEngine;

public class ChannelModule : MonoBehaviour
{
    // ─── PORT 1-1: ChannelModule.SetReferenceResolution ────────────────
    // VMA: 0x0191cbde — Source: decomp_0191.c:10133
    // gốc Ghidra body:
    //   if (DAT_036b8bc6 == '\0') { FUN_0185f84b(&DAT_035784c0); DAT_036b8bc6 = '\x01'; }
    //   lVar1 = XGSDK3_Singleton<object>__get_Instance(DAT_035784c0);
    //   if (lVar1 != 0) { XGSDK3_XGSDK__SetReferenceResolution(param_1, param_2, lVar1, 0); return; }
    //   FUN_0185fa41();  // throw NullRef
    //
    // 1-1 PORT: gốc XGSDK.SetReferenceResolution sets the UI canvas reference resolution
    // for the whole game (CanvasScaler reference under VNG SDK abstraction). Real effect:
    //   1. Apply to ALL existing CanvasScaler in scene (gốc walks UI tree internally)
    //   2. Store as static for any new canvas created later
    public static int s_RefWidth = 1280;
    public static int s_RefHeight = 900;
    public static void SetReferenceResolution(int width, int height)
    {
        s_RefWidth = width;
        s_RefHeight = height;
        // 1-1 with gốc XGSDK: apply to all CanvasScaler under SDK abstraction.
        var ref2 = new Vector2(width, height);
        var scalers = Object.FindObjectsOfType<UnityEngine.UI.CanvasScaler>(true);
        foreach (var cs in scalers)
        {
            cs.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
            cs.referenceResolution = ref2;
        }
        Debug.Log($"[ChannelModule] SetReferenceResolution {width}x{height} → applied to {scalers.Length} CanvasScaler(s)");
    }
}
