// =============================================================================
// UICompat.Scrollbar_Compat — subclass of UnityEngine.UI.Scrollbar with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID b396737915a223daeea441b269bea1e8 (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has Scrollbar in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[Scrollbar].guid → b396737915a223daeea441b269bea1e8
//
// DEVIATION: Gốc had real decompiled Scrollbar.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in Scrollbar in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A Scrollbar → Unity treats it as Scrollbar → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class Scrollbar_Compat : Scrollbar { }
}
