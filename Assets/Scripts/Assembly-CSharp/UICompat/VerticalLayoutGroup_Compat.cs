// =============================================================================
// UICompat.VerticalLayoutGroup_Compat — subclass of UnityEngine.UI.VerticalLayoutGroup with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID f18f2cc2fe71a3a6d76a570588d5047c (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has VerticalLayoutGroup in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[VerticalLayoutGroup].guid → f18f2cc2fe71a3a6d76a570588d5047c
//
// DEVIATION: Gốc had real decompiled VerticalLayoutGroup.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in VerticalLayoutGroup in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A VerticalLayoutGroup → Unity treats it as VerticalLayoutGroup → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class VerticalLayoutGroup_Compat : VerticalLayoutGroup { }
}
