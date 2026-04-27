// =============================================================================
// InputModule — gốc Tuanjie game's custom input handler
// =============================================================================
// Source: KiemTheOrigin_DeepExtract/_shared/DecompiledSource/InputModule.cs
//   Class extends MonoBehaviour, integrates with HedgehogTeam.EasyTouch +
//   XLua callbacks. Has TouchHotKeyParser inner class for hotkey → Lua param
//   conversion. Full IL2CPP body 419 lines.
//
// Source ref: RippedProject_APK/.../Resources/internalres/EventSystem.prefab
//   GameObject "EventSystem" has 2 MonoBehaviour:
//   - guid ba2c49586942b2c63eaf5232b4e93bc3 = UnityEngine.EventSystems.EventSystem
//   - guid 2a84a6bd90c7eb594e110c389d93f072 = THIS InputModule
//
// PORT 2026-04-27 (canonicalization Day 9.9): extend StandaloneInputModule so
//   that EventSystem.UpdateModules() picks it up + processes pointer/touch
//   events (clicks, drag, scroll). HotKey + EasyTouch features deferred —
//   minimum viable for click-through to work in Editor PlayMode.
//
// DEVIATION: gốc extends MonoBehaviour directly + implements own touch loop
//   via EasyTouch. Subclass-from-StandaloneInputModule deviates in INHERITANCE
//   only — gives us EventSystem-compatible pointer/touch click handling for
//   free while preserving the gốc MonoScript GUID (2a84a6bd...) so prefab refs
//   resolve naturally.
//
// FIXME(canonicalization-day-10): port full TouchHotKeyParser + EasyTouch
//   integration when gameplay needs hotkey/swipe. For login flow (mouse click
//   only), StandaloneInputModule covers it.
// =============================================================================
using UnityEngine.EventSystems;

public class InputModule : StandaloneInputModule { }
