// =============================================================================
// UICompat.ToggleGroup_Compat — subclass of UnityEngine.UI.ToggleGroup with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID fd15dcd248d61aa7b5dbf8f46b1ba63c (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has ToggleGroup in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[ToggleGroup].guid → fd15dcd248d61aa7b5dbf8f46b1ba63c
//
// DEVIATION: Gốc had real decompiled ToggleGroup.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in ToggleGroup in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A ToggleGroup → Unity treats it as ToggleGroup → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class ToggleGroup_Compat : ToggleGroup { }
}
