// Class:  ProfileModule
// GUID:   86c3b4a014080214339c03499242a1c5 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/ProfileModule.c (14 methods, 418 LOC Ghidra)
// Address range: 0x01bbd544 — 0x01bbd963

// AUTO-GENERATED template — REVIEW + HAND-FIX before commit.
// gốc Ghidra body lines preserved as // gốc: comments. Translate each line 1-1.
//
// TODO REVIEW CHECKLIST:
//   1. Verify field offsets match dump.cs (re-check class block for exact types)
//   2. Translate each `// gốc:` line to working C#
//   3. Test compile + smoke test boot
//   4. Remove TODO markers when done; commit per pattern Re-port <X> 1-1 from Ghidra

using System;
using System.Collections.Generic;
using UnityEngine;

public class ProfileModule : MonoBehaviour
{
    // ─── PORT 1-1: ProfileModule.BeginSample (overload 1, no-arg) ───
    // VMA: 0x01bbd544 — Source: decomp_01bb.c:12109
    // gốc has 2 BeginSample overloads — Wave A tool collapsed signatures.
    // Hand-disambig pending: dump.cs TypeDefIndex needed for proper params.
    public long BeginSample()
    {
        // gốc: undefined8 in_RAX;
        // gốc: undefined8 uVar1;
        // gốc: if (*(int *)(DAT_035638f8 + 0xe0) != 0) {
        // gốc: return in_RAX;
        // gốc: }
        // gốc: return uVar1;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ProfileModule.BeginSample (overload 2, name arg) ───
    // VMA: 0x01bbd57c — Source: decomp_01bb.c:12133
    // DEVIATION: Wave A tool generated identical sig to overload 1; using string param
    // as placeholder until dump.cs read confirms gốc params (likely BeginSample(string name)).
    public long BeginSample(string name)
    {
        // gốc: undefined8 in_RAX;
        // gốc: undefined8 uVar1;
        // gốc: if (*(int *)(DAT_035638f8 + 0xe0) != 0) {
        // gốc: return in_RAX;
        // gốc: }
        // gốc: return uVar1;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ProfileModule.EndSample ───
    // VMA: 0x01bbd5b4 — Source: decomp_01bb.c:12157
    public long EndSample()
    {
        // gốc: undefined8 in_RAX;
        // gốc: undefined8 uVar1;
        // gốc: if (*(int *)(DAT_035638f8 + 0xe0) != 0) {
        // gốc: return in_RAX;
        // gốc: }
        // gốc: return uVar1;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ProfileModule.GetMonoHeapSize ───
    // VMA: 0x01bbd5ec — Source: decomp_01bb.c:12181
    public void GetMonoHeapSize()
    {
        // gốc: UnityEngine_Profiling_Profiler__GetMonoHeapSizeLong(0);
        // → UnityEngine_Profiling_Profiler.GetMonoHeapSizeLong(0);
        // gốc: return;
    }

    // ─── PORT 1-1: ProfileModule.GetMonoUsedSize ───
    // VMA: 0x01bbd5f3 — Source: decomp_01bb.c:12195
    public void GetMonoUsedSize()
    {
        // gốc: UnityEngine_Profiling_Profiler__GetMonoUsedSizeLong(0);
        // → UnityEngine_Profiling_Profiler.GetMonoUsedSizeLong(0);
        // gốc: return;
    }

    // ─── PORT 1-1: ProfileModule.GetRuntimeMemorySize ───
    // VMA: 0x01bbd5fa — Source: decomp_01bb.c:12209
    public void GetRuntimeMemorySize(long param_1)
    {
        // gốc: UnityEngine_Profiling_Profiler__GetRuntimeMemorySizeLong(param_1,0);
        // → UnityEngine_Profiling_Profiler.GetRuntimeMemorySizeLong(param_1,0);
        // gốc: return;
    }

    // ─── PORT 1-1: ProfileModule.GetTotalAllocatedMemory ───
    // VMA: 0x01bbd601 — Source: decomp_01bb.c:12223
    public void GetTotalAllocatedMemory()
    {
        // gốc: UnityEngine_Profiling_Profiler__GetTotalAllocatedMemoryLong(0);
        // → UnityEngine_Profiling_Profiler.GetTotalAllocatedMemoryLong(0);
        // gốc: return;
    }

    // ─── PORT 1-1: ProfileModule.GetTotalReservedMemory ───
    // VMA: 0x01bbd608 — Source: decomp_01bb.c:12237
    public void GetTotalReservedMemory()
    {
        // gốc: UnityEngine_Profiling_Profiler__GetTotalReservedMemoryLong(0);
        // → UnityEngine_Profiling_Profiler.GetTotalReservedMemoryLong(0);
        // gốc: return;
    }

    // ─── PORT 1-1: ProfileModule.GetTotalUnusedReservedMemory ───
    // VMA: 0x01bbd60f — Source: decomp_01bb.c:12251
    public void GetTotalUnusedReservedMemory()
    {
        // gốc: UnityEngine_Profiling_Profiler__GetTotalUnusedReservedMemoryLong(0);
        // → UnityEngine_Profiling_Profiler.GetTotalUnusedReservedMemoryLong(0);
        // gốc: return;
    }

    // ─── PORT 1-1: ProfileModule.GetTempAllocatorSize ───
    // VMA: 0x01bbd616 — Source: decomp_01bb.c:12265
    public void GetTempAllocatorSize()
    {
        // gốc: UnityEngine_Profiling_Profiler__GetTempAllocatorSize(0);
        // → UnityEngine_Profiling_Profiler.GetTempAllocatorSize(0);
        // gốc: return;
    }

    // ─── PORT 1-1: ProfileModule.SetTempAllocatorRequestedSize ───
    // VMA: 0x01bbd61d — Source: decomp_01bb.c:12279
    public void SetTempAllocatorRequestedSize(long param_1)
    {
        // gốc: UnityEngine_Profiling_Profiler__SetTempAllocatorRequestedSize(param_1,0);
        // → UnityEngine_Profiling_Profiler.SetTempAllocatorRequestedSize(param_1,0);
        // gốc: return;
    }

    // ─── PORT 1-1: ProfileModule.GetPSS ───
    // VMA: 0x01bbd624 — Source: decomp_01bb.c:12293
    public int GetPSS()
    {
        // gốc: long lVar1;
        // gốc: long lVar2;
        // gốc: long *plVar3;
        // gốc: long lVar4;
        // gốc: undefined8 uVar5;
        // gốc: float fVar6;
        // gốc: /* try { // try from 01bbd6a3 to 01bbd6be has its CatchHandler @ 01bbd79e */
        // gốc: lVar1 = thunk_FUN_01851e62(DAT_0355f8a0);
        // gốc: UnityEngine_AndroidJavaClass___ctor(lVar1,DAT_035ae330,0);
        // → UnityEngine_AndroidJavaClass_.ctor(lVar1,DAT_035ae330,0);
        // gốc: if (lVar1 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01bbd773 to 01bbd777 has its CatchHandler @ 01bbd79e */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01bbd6dc to 01bbd6e3 has its CatchHandler @ 01bbd79a */
        // gốc: lVar1 = UnityEngine_AndroidJavaObject__GetStatic<object>(lVar1,DAT_035ae8a0,DAT_0357a640);
        // gốc: /* try { // try from 01bbd6ea to 01bbd705 has its CatchHandler @ 01bbd79c */
        // gốc: lVar2 = thunk_FUN_01851e62(DAT_0355f8a0);
        // gốc: UnityEngine_AndroidJavaClass___ctor(lVar2,DAT_035ae358,0);
        // → UnityEngine_AndroidJavaClass_.ctor(lVar2,DAT_035ae358,0);
        // gốc: /* try { // try from 01bbd710 to 01bbd719 has its CatchHandler @ 01bbd798 */
        // gốc: plVar3 = (long *)FUN_0185f8db(DAT_0355f128,1);
        // gốc: if (plVar3 == (long *)0x0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01bbd778 to 01bbd795 has its CatchHandler @ 01bbd7a0 */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: if (lVar1 != 0) {
        // gốc: /* try { // try from 01bbd72e to 01bbd735 has its CatchHandler @ 01bbd7a0 */
        // gốc: lVar4 = thunk_FUN_01851d86(lVar1,*(undefined8 *)(*plVar3 + 0x40));
        // gốc: if (lVar4 == 0) {
        // gốc: uVar5 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar5,0);
        // gốc: }
        // gốc: }
        // gốc: if ((int)plVar3[3] != 0) {
        // gốc: plVar3[4] = lVar1;
        // gốc: if (lVar2 != 0) {
        // gốc: /* try { // try from 01bbd75e to 01bbd768 has its CatchHandler @ 01bbd796 */
        // gốc: fVar6 = (float)UnityEngine_AndroidJavaObject__CallStatic<float>
        // gốc: (lVar2,DAT_0359f638,plVar3,DAT_0357a610);
        // gốc: return (int)fVar6;
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
        // gốc: }
        // gốc: // ------------------------------------------------------------
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ProfileModule.GetIosUsedMemory ───
    // VMA: 0x01bbd905 — Source: decomp_01bb.c:12365
    public int GetIosUsedMemory()
    {
        // gốc: undefined4 local_10;
        // gốc: undefined4 local_c;
        // gốc: local_c = 0;
        // gốc: local_10 = 0;
        // gốc: if (*(int *)(DAT_03560728 + 0xe0) == 0) {
        // gốc: }
        // gốc: CppApi__IOSGetMemInfo(&local_c,&local_10,0);
        // → CppApi.IOSGetMemInfo(&local_c,&local_10,0);
        // gốc: return local_c;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ProfileModule.GetIosFreeMemory ───
    // VMA: 0x01bbd963 — Source: decomp_01bb.c:12391
    public int GetIosFreeMemory()
    {
        // gốc: undefined4 local_10;
        // gốc: undefined4 local_c;
        // gốc: local_c = 0;
        // gốc: local_10 = 0;
        // gốc: if (*(int *)(DAT_03560728 + 0xe0) == 0) {
        // gốc: }
        // gốc: CppApi__IOSGetMemInfo(&local_c,&local_10,0);
        // → CppApi.IOSGetMemInfo(&local_c,&local_10,0);
        // gốc: return local_10;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

}
