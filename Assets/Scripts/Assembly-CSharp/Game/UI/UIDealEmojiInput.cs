// =============================================================================
// Game.UI.UIDealEmojiInput — emoji-aware input field wrapper
// =============================================================================
// Source: AssetRipper extracted as empty stub — gốc IL2CPP body could not be
//   decompiled. Tuanjie game uses this as primary input control wrapping
//   UnityEngine.UI.InputField with extra emoji handling logic.
//
// PORT 2026-04-27: extend UnityEngine.UI.InputField so that
//   UIPanel.FindComp<InputField>(key) resolves UIDealEmojiInput → InputField
//   via inheritance. This unblocks Input_SetText / Input_GetText calls from
//   Lua (e.g. tbWnd:OnOpen on UILoginChannelInner sets InputAccount.text).
// =============================================================================
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIDealEmojiInput : InputField { }
}
