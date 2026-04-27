// Class:  KTV.KTimer
// Source: KTO_DecompiledReference/KTV/KTimer.c (port from Active() body field-offset reads)
//
// 1-1 PORT 2026-04-26 — fields match gốc heap-entry layout per KTimerScheduler.Active body.
// Used by KTimerScheduler.

using UnityEngine;

namespace KTV
{
    /// <summary>Single-shot or repeating timer object scheduled by KTimerScheduler.</summary>
    public class KTimer
    {
        // Fields at gốc offsets per KTimerScheduler.Active Ghidra body:
        //   +0x18 = double m_NextFireTime
        //   +0x28 = double m_RepeatInterval (0 = single-shot)
        //   +0x30 = long   m_FireCount
        //   +0x38 = Action m_Callback
        //   +0x40 = byte   m_bRepeating  (1 = repeat)
        //   +0x41 = byte   m_bActive     (1 = currently in heap)
        public double NextFireTime;
        public double RepeatInterval;
        public long FireCount;
        public System.Action OnFire;
        public byte IsRepeating;
        public byte IsActive;

        // gốc: KTimer__OnTimeout(dVar4, this) — invokes callback, returns whether to keep alive.
        public bool OnTimeout(double now)
        {
            try { OnFire?.Invoke(); }
            catch (System.Exception e) { Debug.LogError($"[KTimer] OnFire: {e.Message}"); }
            return IsRepeating != 0;
        }
    }
}
