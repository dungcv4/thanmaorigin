// =============================================================================
// UICompat.HorizontalLayoutGroup_Compat — subclass of UnityEngine.UI.HorizontalLayoutGroup with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID 19fbb4a32b59286cd89b624f52ff7943 (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has HorizontalLayoutGroup in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[HorizontalLayoutGroup].guid → 19fbb4a32b59286cd89b624f52ff7943
//
// DEVIATION: Gốc had real decompiled HorizontalLayoutGroup.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in HorizontalLayoutGroup in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A HorizontalLayoutGroup → Unity treats it as HorizontalLayoutGroup → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class HorizontalLayoutGroup_Compat : HorizontalLayoutGroup { }
}
