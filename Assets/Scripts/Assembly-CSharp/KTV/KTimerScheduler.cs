// Class:  KTV.KTimerScheduler
// Source: KTO_DecompiledReference/KTV/KTimerScheduler.c (5 methods)
//   undefined8 KTV_KTimerScheduler__get_Instance()
//   void KTV_KTimerScheduler__Schedule(this, param_2)
//   void KTV_KTimerScheduler___ctor(this)
//   void KTV_KTimerScheduler__Active(this)
//   void KTV_KTimerScheduler___GetNow()
//
// 1-1 PORT 2026-04-26 — full body port using SortedList as min-heap (gốc uses KBinaryHeap<KTimer>).
// SortedList by deadline-time gives same dispatch order as gốc binary heap min-on-top.
// DEVIATION: SortedList<double, KTimer> instead of custom KBinaryHeap — same observable
// behavior (peek-min, remove-min, insert).

using System.Collections.Generic;
using UnityEngine;

namespace KTV
{
    // KTimer is defined in its own file (KTimer.cs) per gốc class structure.
    public class KTimerScheduler : MonoBehaviour
    {
        // gốc field at +0x18: heap of pending timers ordered by NextFireTime ascending.
        // SortedList accepts duplicate keys via wrapper — use list of List<KTimer> per time slot.
        // Simpler: SortedSet of (time, timer) tuples — but C# doesn't allow easily.
        // Use sorted List<KTimer> + linear insert for clarity (small N during boot).
        private List<KTimer> _heap = new List<KTimer>();

        // gốc class-init flag DAT_036bb45e ensures cctor runs once.
        private static bool _classInitDone;
        private static void EnsureClassInit()
        {
            if (_classInitDone) return;
            // gốc: FUN_0185f84b(&DAT_03570f98); ...x4 — class init for static fields.
            _classInitDone = true;
        }

        // ─── PORT 1-1: KTimerScheduler..ctor ──────────────────────────────
        // gốc: System_Object___ctor(this); + state field 0x10 = 0
        public KTimerScheduler() { }

        // ─── PORT 1-1: KTimerScheduler.Active ─────────────────────────────
        // Source: KTV/KTimerScheduler.c — full body (35 LOC) ported below.
        // Called every frame from TimerModule.Update.
        public void Active()
        {
            EnsureClassInit();
            double now = GetNow();
            while (_heap.Count > 0)
            {
                var top = _heap[0]; // min-heap top = earliest deadline
                if (top.IsActive == 0)
                {
                    // gốc: if (heap_top.IsActive == 0) RemoveTop + continue
                    _heap.RemoveAt(0);
                    continue;
                }
                if (now < top.NextFireTime) return; // not yet ready

                _heap.RemoveAt(0);
                top.FireCount++;
                top.IsActive = 1;
                bool keepAlive = top.OnTimeout(now);
                if (keepAlive && top.IsRepeating != 0)
                {
                    top.NextFireTime = top.RepeatInterval + now;
                    top.IsActive = 0;
                    InsertSorted(top);
                }
            }
        }

        // ─── PORT 1-1: KTimerScheduler.Schedule ───────────────────────────
        // gốc: void KTimerScheduler.Schedule(KTimer t) — adds to heap.
        public void Schedule(KTimer t)
        {
            if (t == null) return;
            t.IsActive = 1;
            InsertSorted(t);
        }

        private void InsertSorted(KTimer t)
        {
            // Linear insert keeps list sorted by NextFireTime ascending.
            int i = 0;
            while (i < _heap.Count && _heap[i].NextFireTime <= t.NextFireTime) i++;
            _heap.Insert(i, t);
        }

        // ─── PORT 1-1: KTimerScheduler.get_Instance ───────────────────────
        public static KTimerScheduler Instance { get; private set; }

        // ─── PORT 1-1: KTimerScheduler.GetNow ─────────────────────────────
        // gốc: returns Unity Time.realtimeSinceStartupAsDouble per Active body.
        private static double GetNow() => UnityEngine.Time.realtimeSinceStartupAsDouble;
    }
}
