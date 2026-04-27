// =============================================================================
// UICompat.ContentSizeFitter_Compat — subclass of UnityEngine.UI.ContentSizeFitter with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID 21c7954052da7655d96bff866c2b7662 (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has ContentSizeFitter in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[ContentSizeFitter].guid → 21c7954052da7655d96bff866c2b7662
//
// DEVIATION: Gốc had real decompiled ContentSizeFitter.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in ContentSizeFitter in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A ContentSizeFitter → Unity treats it as ContentSizeFitter → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class ContentSizeFitter_Compat : ContentSizeFitter { }
}
