// =============================================================================
// UICompat.RectMask2D_Compat — subclass of UnityEngine.UI.RectMask2D with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID 69dacd7a039c12e90cde90bbae65247a (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has RectMask2D in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[RectMask2D].guid → 69dacd7a039c12e90cde90bbae65247a
//
// DEVIATION: Gốc had real decompiled RectMask2D.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in RectMask2D in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A RectMask2D → Unity treats it as RectMask2D → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class RectMask2D_Compat : RectMask2D { }
}
