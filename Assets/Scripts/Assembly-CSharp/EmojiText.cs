// Class:  EmojiText
// Source: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 78)
//
// PARTIAL PORT 2026-04-25 — inherits UnityEngine.UI.Text. Full body (regex parsing,
// emoji vertex modifier, click-link tracking) deferred to dedicated session — UIPanel
// only references the .text property which is inherited from Text.

using System;
using UnityEngine.UI;

public class EmojiText : Text
{
    // gốc has many fields/methods (regex emoji parser + click-link). Stubbed here for
    // UIPanel compile-time usage — the runtime falls through to Text.text.

    public delegate void ClickLinkAction(string link);
    public ClickLinkAction onClickLink;

    public EmojiText() : base() { }
}
