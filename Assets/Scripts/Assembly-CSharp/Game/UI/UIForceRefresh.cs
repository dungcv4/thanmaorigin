// gốc: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1609)
//      KTO_DecompiledReference/_root/UIForceRefresh.c
//
// 8 methods + IteratorStateMachine for UpdateContentCoroutine.
// All bodies empty in gốc IL2CPP (RVAs 0x1B2AAC8..0x1B2AD17).
//
// PORT 2026-05-02: replace AR Cpp2IL dummy stub. Field types preserved.
//
// NOTE: GameEventArgs ref is local namespace. UpdateContent signature kept
// for prefab event-binding compat — body intentionally empty matching gốc.

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIForceRefresh : MonoBehaviour
    {
        // Fields (matches dump.cs offsets 0x20, 0x28)
        public ScrollRect ChatScrollRect;
        private WaitForEndOfFrame _waitForEndOfFrame;

        // gốc methods — all empty bodies
        private void OnEnable() { }
        private void Awake() { }
        private void RegisterEvent() { }
        private void UnRegisterEvent() { }
        // gốc UpdateContent(object sender, GameEventArgs e) — local-type GameEventArgs
        // omitted here (no caller in current codebase). When server-event wiring lands,
        // re-add with proper sig.
        private IEnumerator UpdateContentCoroutine() { yield break; }
        private void OnDisable() { }
        private void OnDestroy() { }
    }
}
