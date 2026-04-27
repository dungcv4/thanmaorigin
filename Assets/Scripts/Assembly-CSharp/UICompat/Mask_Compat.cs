// =============================================================================
// UICompat.Mask_Compat — subclass of UnityEngine.UI.Mask with gốc RippedProject GUID
// =============================================================================
// PURPOSE: gốc YAML refs UI class via GUID 16c0ec1e295995dd9a2d2df2d7b6cc7e (extracted by AssetRipper
//          from KTO APK). Tuanjie/Unity 2022 has Mask in built-in
//          UnityEngine.UI.dll with a different runtime GUID. To resolve gốc
//          YAML refs WITHOUT replacing built-in package, this stub claims gốc
//          GUID + inherits behavior.
//
// SOURCE:  KTO_FullExtract/script_map.json[Mask].guid → 16c0ec1e295995dd9a2d2df2d7b6cc7e
//
// DEVIATION: Gốc had real decompiled Mask.cs file at this GUID. Target uses
//   subclass because:
//   1. Tuanjie/Unity 2022 forbids project asmdef same-name as built-in
//      ("Assembly with name 'UnityEngine.UI' already exists" error).
//   2. Built-in Mask in UnityEngine.UI.dll has different GUID than gốc.
//   3. Subclass IS-A Mask → Unity treats it as Mask → renders correctly.
// =============================================================================
namespace UnityEngine.UI
{
    public class Mask_Compat : Mask { }
}
