// =============================================================================
// UICompat.Text_Compat — subclass of UnityEngine.UI.Text with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID 04f84fc2003509a5e7e068ec1271cc40 (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has Text in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[Text].guid → 04f84fc2003509a5e7e068ec1271cc40
//
// DEVIATION: Gốc had real decompiled Text.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in Text in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A Text → Unity treats it as Text → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class Text_Compat : Text { }
}
