// Class:  FontOutline
// Source: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 451)
//
// FULL 1-1 PORT 2026-04-25 — inherits UnityEngine.UI.Shadow (provides effectColor +
// effectDistance properties used by UIPanel.Outline_*).

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FontOutline : Shadow
{
    // VMA: 0x01BA6AE6 — Source: dump.cs (.ctor)
    // gốc body: Shadow base ctor (no body in subclass).
    protected FontOutline() { }

    // VMA: 0x01BA6AED — Source: dump.cs (ModifyMesh override)
    // gốc body: text-specific outline mesh modification (4-direction outline corners).
    // DEVIATION: defer to base UnityEngine.UI.Shadow.ModifyMesh impl (we don't override).
}
