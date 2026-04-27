// =============================================================================
// UICompat.LayoutElement_Compat — subclass of UnityEngine.UI.LayoutElement with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID 4293fd42559bc8bb1c81715179adf536 (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has LayoutElement in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[LayoutElement].guid → 4293fd42559bc8bb1c81715179adf536
//
// DEVIATION: Gốc had real decompiled LayoutElement.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in LayoutElement in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A LayoutElement → Unity treats it as LayoutElement → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class LayoutElement_Compat : LayoutElement { }
}
