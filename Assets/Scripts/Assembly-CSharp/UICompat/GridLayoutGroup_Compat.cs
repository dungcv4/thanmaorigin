// =============================================================================
// UICompat.GridLayoutGroup_Compat — subclass of UnityEngine.UI.GridLayoutGroup with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID 8ffc7d923b31b10e81b381e1325ae677 (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has GridLayoutGroup in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[GridLayoutGroup].guid → 8ffc7d923b31b10e81b381e1325ae677
//
// DEVIATION: Gốc had real decompiled GridLayoutGroup.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in GridLayoutGroup in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A GridLayoutGroup → Unity treats it as GridLayoutGroup → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class GridLayoutGroup_Compat : GridLayoutGroup { }
}
