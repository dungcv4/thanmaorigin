// =============================================================================
// UICompat.Shadow_Compat — subclass of UnityEngine.UI.Shadow with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID 76ccfb4bfe5eebba5766d6f50f76ae37 (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has Shadow in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[Shadow].guid → 76ccfb4bfe5eebba5766d6f50f76ae37
//
// DEVIATION: Gốc had real decompiled Shadow.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in Shadow in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A Shadow → Unity treats it as Shadow → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class Shadow_Compat : Shadow { }
}
