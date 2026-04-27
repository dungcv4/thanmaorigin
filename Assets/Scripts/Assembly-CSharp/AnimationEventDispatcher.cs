using Game.UI;
// Class: AnimationEventDispatcher
// GUID:  3df1ac184255105608adcea2b214143b (preserved via .meta)
// Source: KTO_FullExtract — Animator.OnEvent → C# delegate forward
//
// PARTIAL PORT 2026-04-25: API surface for UIPanel.BindAnimationEvent.

using System;
using UnityEngine;

public class AnimationEventDispatcher : MonoBehaviour
{
    // Set by UIPanel.BindAnimationEvent(key, luaFunc) — invoked from Animator events.
    public Action<string> OnEvent;
}
