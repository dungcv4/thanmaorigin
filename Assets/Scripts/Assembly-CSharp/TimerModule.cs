// Class:  TimerModule
// GUID:   eadda1f87195ca5393dd8d66563a968b (preserved via .meta)
// Source: KTO_DecompiledReference/_root/TimerModule.c (3 methods, 76 LOC Ghidra)
// dump.cs: TypeDefIndex 430
// Address range: 0x01ca429e — 0x01ca433f
//
// FULL 1-1 PORT 2026-04-26 — every method body verified against Ghidra C decompile.

using System.Collections;
using KTV;
using UnityEngine;

public class TimerModule : MonoBehaviour
{
    // ─── Field (dump.cs offset 0x0) ───
    // gốc: private static KTimerScheduler _TimerScheduler
    private static KTimerScheduler _TimerScheduler;

    // ─── PORT 1-1: TimerModule.Init ─────────────────────────────────────
    // VMA: 0x01ca429e — Source: TimerModule.c:3227
    //
    // gốc body (state-machine wrapped, dump.cs marks IteratorStateMachine):
    //   lVar1 = new KTimerScheduler();
    //   System.Object.__ctor(lVar1, 0);  // base ctor
    //   *(undefined4 *)(lVar1 + 0x10) = 0;  // initial state = 0
    //   return lVar1;  // returns IEnumerator state machine instance
    //
    // dump.cs signature: public static IEnumerator Init() — coroutine.
    public static IEnumerator Init()
    {
        // gốc: instantiate KTimerScheduler + set state field 0x10 = 0
        _TimerScheduler = new KTimerScheduler();
        // State machine has 1 yield (gốc returns enumerator with 0-1 iterations)
        yield break;
    }

    // ─── PORT 1-1: TimerModule.Update ───────────────────────────────────
    // VMA: 0x01ca42fc — Source: TimerModule.c:3264
    //
    // gốc body:
    //   if (DAT_03565038 + 0xb8 != null) {  // _TimerScheduler != null check
    //     KTimerScheduler.Active(_TimerScheduler, 0);
    //     return;
    //   }
    //   FUN_0185fa41();  // throw NullReference
    private void Update()
    {
        if (_TimerScheduler != null)
        {
            // gốc: KTV_KTimerScheduler__Active(this, 0) — second arg is IL2CPP method_info ptr, NOT a real param.
            // Active() takes 0 args per gốc signature: `undefined KTV.KTimerScheduler$$Active()`.
            _TimerScheduler.Active();
            return;
        }
        throw new System.NullReferenceException();
    }

    // ─── PORT 1-1: TimerModule..ctor ────────────────────────────────────
    // VMA: 0x01ca433f — Source: TimerModule.c:3286
    // gốc body: UnityEngine.MonoBehaviour.__ctor(this, 0)
    public TimerModule() { }
}
// Touch to force recompile Sun Apr 26 13:20:29 +07 2026
