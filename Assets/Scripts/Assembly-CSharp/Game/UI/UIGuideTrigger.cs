// gốc: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1610)
//      KTO_DecompiledReference/_root/UIGuideTrigger.c
//
// 3 methods (OnEnable/OnDisable/.ctor) — all empty bodies in gốc IL2CPP
// (RVAs 0x1B2AE15 / 0x1B2AE80 / 0x1B2AEEC).
// Static Action delegates fire UI show/hide events for guide system.
//
// PORT 2026-05-02: replace AR Cpp2IL dummy stub. Field layout preserved.

using System;
using UnityEngine;

namespace Game.UI
{
    public class UIGuideTrigger : MonoBehaviour
    {
        // Static event hooks (matches dump.cs offsets 0x0, 0x8 — class-static fields)
        public static Action<string, GameObject> OnUIShow;
        public static Action<string, GameObject> OnUIHide;

        // Instance field (offset 0x20)
        public string m_uiName;

        // gốc methods — empty bodies
        private void OnEnable() { }
        private void OnDisable() { }
    }
}
