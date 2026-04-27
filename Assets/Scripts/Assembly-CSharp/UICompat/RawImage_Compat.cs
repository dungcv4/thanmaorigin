// =============================================================================
// UICompat.RawImage_Compat — subclass of UnityEngine.UI.RawImage with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID 8b6b0933debec03db3ed40115224c1a8 (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has RawImage in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[RawImage].guid → 8b6b0933debec03db3ed40115224c1a8
//
// DEVIATION: Gốc had real decompiled RawImage.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in RawImage in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A RawImage → Unity treats it as RawImage → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class RawImage_Compat : RawImage { }
}
