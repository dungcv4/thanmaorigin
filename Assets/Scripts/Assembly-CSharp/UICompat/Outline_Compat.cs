// =============================================================================
// UICompat.Outline_Compat — subclass of UnityEngine.UI.Outline with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID 598ca59b26b303be9752bcc87e36626e (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has Outline in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[Outline].guid → 598ca59b26b303be9752bcc87e36626e
//
// DEVIATION: Gốc had real decompiled Outline.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in Outline in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A Outline → Unity treats it as Outline → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class Outline_Compat : Outline { }
}
