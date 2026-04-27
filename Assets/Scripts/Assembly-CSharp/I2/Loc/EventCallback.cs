// 1-1 PORT 2026-04-27: I2.Loc.EventCallback ported from gốc IL2CPP.
// Source: KiemTheOrigin_DeepExtract/_shared/DecompiledSource/I2.Loc/EventCallback.cs
//   + KTO_DecompiledReference/I2.Loc/EventCallback.c
//
// Field layout 1-1:
//   Target     @ 0x10  (MonoBehaviour)
//   MethodName @ 0x18  (string)
//
// Behavior:
//   Execute(Sender): if HasCallback(), invoke Target.SendMessage(MethodName, Sender)
//   HasCallback(): Target != null && !IsNullOrEmpty(MethodName)
//
// Note: gốc declared as plain class (NOT MonoBehaviour) — it's a [Serializable] inner
// field of Localize. AssetRipper's stub wrongly typed it as MonoBehaviour. This port
// fixes that, matching the prefab's serialized form `{Target: {fileID:0}, MethodName: ''}`.
using System;
using UnityEngine;

namespace I2.Loc
{
    [Serializable]
    public class EventCallback
    {
        // Layout matches IL2CPP dump: Target = MonoBehaviour ref, MethodName = string.
        public MonoBehaviour Target;
        public string MethodName;

        // ─── PORT 1-1: HasCallback ───
        public bool HasCallback()
        {
            return Target != null && !string.IsNullOrEmpty(MethodName);
        }

        // ─── PORT 1-1: Execute(Sender) ───
        // gốc body: if (HasCallback()) Target.SendMessage(MethodName, Sender, DontRequireReceiver).
        public void Execute(UnityEngine.Object Sender = null)
        {
            if (!HasCallback()) return;
            try
            {
                Target.SendMessage(MethodName, Sender, SendMessageOptions.DontRequireReceiver);
            }
            catch (System.Exception e)
            {
                Debug.LogWarning($"[I2.Loc.EventCallback] Execute failed: {e.Message}");
            }
        }
    }
}
