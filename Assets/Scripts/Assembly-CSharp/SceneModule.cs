// Class:  SceneModule
// GUID:   0273467e6072d46cfba18b0a66901d6f (preserved via .meta)
// Source: KTO_DecompiledReference/_root/SceneModule.c (31 methods, 2058 LOC Ghidra)
// Address range: 0x01c9edfd — 0x01ca173f

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

public class SceneModule : MonoBehaviour
{
    // ─── PORT 1-1: SceneModule.BindPlayerObj ───
    // VMA: 0x01c9edfd — Source: decomp_01c9.c:11534
    public void BindPlayerObj(long param_1, long param_2, int param_3)
    {
        // gốc: undefined8 uVar1;
        // gốc: char cVar2;
        // gốc: long lVar3;
        // gốc: if (*(int *)(DAT_035631e8 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9ee47 to 01c9ee4b has its CatchHandler @ 01c9eeb5 */
        // gốc: }
        // gốc: /* try { // try from 01c9ee4c to 01c9ee52 has its CatchHandler @ 01c9eebd */
        // gốc: lVar3 = NpcManager__GetNpc(param_3);
        // → lVar3 = NpcManager.GetNpc(param_3);
        // gốc: if (*(int *)(DAT_03563280 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9ee69 to 01c9ee6d has its CatchHandler @ 01c9eeb3 */
        // gốc: }
        // gốc: /* try { // try from 01c9ee6e to 01c9ee79 has its CatchHandler @ 01c9eebb */
        // gốc: cVar2 = UnityEngine_Object__op_Equality(lVar3,0,0);
        // → cVar2 = UnityEngine_Object.op_Equality(lVar3,0,0);
        // gốc: if (cVar2 == '\0') {
        // gốc: if (lVar3 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01c9eeae to 01c9eeb2 has its CatchHandler @ 01c9eeb7 */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: uVar1 = *(undefined8 *)(lVar3 + 0xa8);
        // gốc: if (*(int *)(DAT_035642c8 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9ee9d to 01c9eeab has its CatchHandler @ 01c9eeb9 */
        // gốc: }
        // gốc: Game_RepresentLogic_SceneCameraController__SetTarget(uVar1,0);
        // → Game_RepresentLogic_SceneCameraController.SetTarget(uVar1,0);
        // gốc: }
        // gốc: return;
        // gốc: }
        // gốc: // ------------------------------------------------------------
    }

    // ─── PORT 1-1: SceneModule.LoadMap ───
    // VMA: 0x01c9ef5b — Source: decomp_01c9.c:11582
    public void LoadMap(long param_1, long param_2, int param_3)
    {
        // gốc: undefined8 uVar1;
        // gốc: char cVar2;
        // gốc: long *plVar3;
        // gốc: long lVar4;
        // gốc: long lVar5;
        // gốc: undefined8 uVar6;
        // gốc: int local_48 [2];
        // gốc: undefined8 local_40;
        // gốc: plVar3 = (long *)FUN_0185f8db(DAT_0355f128,2);
        // gốc: if (plVar3 == (long *)0x0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: if ((param_1 != 0) &&
        // gốc: (lVar4 = thunk_FUN_01851d86(param_1,*(undefined8 *)(*plVar3 + 0x40)), lVar4 == 0)) {
        // gốc: LAB_01c9f75d:
        // gốc: uVar6 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar6,0);
        // gốc: }
        // gốc: if ((int)plVar3[3] != 0) {
        // gốc: plVar3[4] = param_1;
        // gốc: local_48[0] = param_3;
        // gốc: lVar4 = thunk_FUN_01851b32(DAT_035624b0);
        // gốc: if ((lVar4 != 0) &&
        // gốc: (lVar5 = thunk_FUN_01851d86(lVar4,*(undefined8 *)(*plVar3 + 0x40)), lVar5 == 0))
        // gốc: goto LAB_01c9f75d;
        // gốc: if (1 < *(uint *)(plVar3 + 3)) {
        // gốc: plVar3[5] = lVar4;
        // gốc: if (*(int *)(DAT_03562a00 + 0xe0) == 0) {
        // gốc: }
        // gốc: LogHelper__INFO(DAT_035a5af0,DAT_035a2598,plVar3,0);
        // → LogHelper.INFO(DAT_035a5af0,DAT_035a2598,plVar3,0);
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9f18c to 01c9f190 has its CatchHandler @ 01c9f807 */
        // gốc: }
        // gốc: /* try { // try from 01c9f191 to 01c9f195 has its CatchHandler @ 01c9f803 */
        // gốc: cVar2 = SceneModule__IsLoading();
        // → cVar2 = SceneModule.IsLoading();
        // gốc: if (cVar2 != '\0') {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9f1ad to 01c9f1b1 has its CatchHandler @ 01c9f7dd */
        // gốc: }
        // gốc: if (*(int *)(*(long *)(DAT_035642f0 + 0xb8) + 0x18) == param_3) {
        // gốc: return;
        // gốc: }
        // gốc: }
        // gốc: /* try { // try from 01c9f1d1 to 01c9f1da has its CatchHandler @ 01c9f801 */
        // gốc: plVar3 = (long *)FUN_0185f8db(DAT_0355f128,3);
        // gốc: if (plVar3 == (long *)0x0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01c9f76c to 01c9f775 has its CatchHandler @ 01c9f80d */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01c9f1f4 to 01c9f1fb has its CatchHandler @ 01c9f80d */
        // gốc: if ((param_1 != 0) &&
        // gốc: (lVar4 = thunk_FUN_01851d86(param_1,*(undefined8 *)(*plVar3 + 0x40)), lVar4 == 0)) {
        // gốc: /* try { // try from 01c9f785 to 01c9f793 has its CatchHandler @ 01c9f80d */
        // gốc: uVar6 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar6,0);
        // gốc: }
        // gốc: if ((int)plVar3[3] == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
        // gốc: }
        // gốc: plVar3[4] = param_1;
        // gốc: local_48[0] = param_3;
        // gốc: /* try { // try from 01c9f21f to 01c9f23b has its CatchHandler @ 01c9f80b */
        // gốc: lVar4 = thunk_FUN_01851b32(DAT_035624b0);
        // gốc: if ((lVar4 != 0) &&
        // gốc: (lVar5 = thunk_FUN_01851d86(lVar4,*(undefined8 *)(*plVar3 + 0x40)), lVar5 == 0)) {
        // gốc: /* try { // try from 01c9f794 to 01c9f7a2 has its CatchHandler @ 01c9f80b */
        // gốc: uVar6 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar6,0);
        // gốc: }
        // gốc: if (*(uint *)(plVar3 + 3) < 2) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01c9f776 to 01c9f77a has its CatchHandler @ 01c9f80b */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
        // gốc: }
        // gốc: plVar3[5] = lVar4;
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9f266 to 01c9f26a has its CatchHandler @ 01c9f7ef */
        // gốc: }
        // gốc: /* try { // try from 01c9f26b to 01c9f26f has its CatchHandler @ 01c9f7ff */
        // gốc: SceneModule__IsLoading();
        // → SceneModule.IsLoading();
        // gốc: /* try { // try from 01c9f281 to 01c9f2e0 has its CatchHandler @ 01c9f80f */
        // gốc: lVar4 = thunk_FUN_01851b32(DAT_03560040);
        // gốc: if ((lVar4 != 0) &&
        // gốc: (lVar5 = thunk_FUN_01851d86(lVar4,*(undefined8 *)(*plVar3 + 0x40)), lVar5 == 0)) {
        // gốc: /* try { // try from 01c9f7a3 to 01c9f7b1 has its CatchHandler @ 01c9f80f */
        // gốc: uVar6 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar6,0);
        // gốc: }
        // gốc: if (*(uint *)(plVar3 + 3) < 3) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01c9f77b to 01c9f77f has its CatchHandler @ 01c9f80f */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
        // gốc: }
        // gốc: plVar3[6] = lVar4;
        // gốc: if (*(int *)(DAT_035609a0 + 0xe0) == 0) {
        // gốc: }
        // gốc: UnityEngine_Debug__LogFormat(DAT_035a5af8,plVar3,0);
        // → UnityEngine_Debug.LogFormat(DAT_035a5af8,plVar3,0);
        // gốc: *(undefined2 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x24) = 0x100;
        // gốc: /* try { // try from 01c9f2f8 to 01c9f32c has its CatchHandler @ 01c9f805 */
        // gốc: SceneModule__CheckReload();
        // → SceneModule.CheckReload();
        // gốc: *(undefined4 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x68) = 1;
        // gốc: if (*(int *)(DAT_03565798 + 0xe0) == 0) {
        // gốc: }
        // gốc: /* try { // try from 01c9f32d to 01c9f333 has its CatchHandler @ 01c9f7fd */
        // gốc: uVar6 = UtilsHelper__GetTickCount(0);
        // → uVar6 = UtilsHelper.GetTickCount(0);
        // gốc: lVar4 = *(long *)(DAT_035642f0 + 0xb8);
        // gốc: *(undefined8 *)(lVar4 + 0x40) = uVar6;
        // gốc: *(int *)(lVar4 + 0x18) = param_3;
        // gốc: *(undefined2 *)(lVar4 + 0x24) = 1;
        // gốc: /* try { // try from 01c9f353 to 01c9f36c has its CatchHandler @ 01c9f809 */
        // gốc: lVar4 = Game_Common_SceneOcclusion__Instance(0);
        // → lVar4 = Game_Common_SceneOcclusion.Instance(0);
        // gốc: if (lVar4 != 0) {
        // gốc: Game_Common_SceneOcclusion__UnInit(lVar4,0);
        // → Game_Common_SceneOcclusion.UnInit(lVar4,0);
        // gốc: if (*(int *)(DAT_03563870 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9f380 to 01c9f3dc has its CatchHandler @ 01c9f811 */
        // gốc: }
        // gốc: PreloadResource__OnLoadMap(param_3,0);
        // → PreloadResource.OnLoadMap(param_3,0);
        // gốc: if (*(int *)(DAT_03564030 + 0xe0) == 0) {
        // gốc: }
        // gốc: ResourceModule__SetMapLoadingTopPriority(1,0);
        // → ResourceModule.SetMapLoadingTopPriority(1,0);
        // gốc: if (*(int *)(DAT_035631e8 + 0xe0) == 0) {
        // gốc: }
        // gốc: NpcManager__ClearSelectTarget(0);
        // → NpcManager.ClearSelectTarget(0);
        // gốc: NpcManager__ClearSelectTarget(1);
        // → NpcManager.ClearSelectTarget(1);
        // gốc: lVar4 = DAT_035642f0;
        // gốc: *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x58) = param_1;
        // gốc: if (param_3 == 0) {
        // gốc: if (*(int *)(DAT_03564030 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9f669 to 01c9f679 has its CatchHandler @ 01c9f807 */
        // gốc: }
        // gốc: ResourceModule__UnLoadResourceCache(1,0);
        // → ResourceModule.UnLoadResourceCache(1,0);
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9f68d to 01c9f69e has its CatchHandler @ 01c9f7fb */
        // gốc: }
        // gốc: SceneModule___LoadScene(param_1);
        // → SceneModule_.LoadScene(param_1);
        // gốc: SceneModule__PreloadNextSceneResource();
        // → SceneModule.PreloadNextSceneResource();
        // gốc: }
        // gốc: else {
        // gốc: if (*(int *)(lVar4 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9f404 to 01c9f408 has its CatchHandler @ 01c9f807 */
        // gốc: }
        // gốc: /* try { // try from 01c9f409 to 01c9f428 has its CatchHandler @ 01c9f7f9 */
        // gốc: uVar6 = SceneModule__UnloadResourceThenLoadScene();
        // → uVar6 = SceneModule.UnloadResourceThenLoadScene();
        // gốc: if (*(int *)(DAT_035626e8 + 0xe0) == 0) {
        // gốc: }
        // gốc: /* try { // try from 01c9f429 to 01c9f432 has its CatchHandler @ 01c9f7f7 */
        // gốc: uVar6 = KCoroutine__StartCoroutine(uVar6,0);
        // → uVar6 = KCoroutine.StartCoroutine(uVar6,0);
        // gốc: lVar5 = DAT_035642f0;
        // gốc: lVar4 = *(long *)(DAT_035642f0 + 0xb8);
        // gốc: *(undefined8 *)(lVar4 + 0x70) = uVar6;
        // gốc: if (*(int *)(lVar5 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9f451 to 01c9f455 has its CatchHandler @ 01c9f807 */
        // gốc: lVar4 = *(long *)(DAT_035642f0 + 0xb8);
        // gốc: }
        // gốc: if (*(long *)(lVar4 + 0x60) == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01c9f7b2 to 01c9f7b6 has its CatchHandler @ 01c9f7f5 */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01c9f47e to 01c9f485 has its CatchHandler @ 01c9f7f3 */
        // gốc: cVar2 = System_Collections_Generic_Dictionary<int,_SceneModule_MapInfo>__ContainsKey
        // gốc: (*(long *)(lVar4 + 0x60),param_3,DAT_0356bf68);
        // gốc: if (cVar2 != '\0') {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9f4a1 to 01c9f4a5 has its CatchHandler @ 01c9f807 */
        // gốc: }
        // gốc: lVar4 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x60);
        // gốc: if (lVar4 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01c9f7b7 to 01c9f7bb has its CatchHandler @ 01c9f7eb */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01c9f4ce to 01c9f4da has its CatchHandler @ 01c9f7e9 */
        // gốc: System_Collections_Generic_Dictionary<int,_SceneModule_MapInfo>__get_Item
        // gốc: (local_48,lVar4,param_3,DAT_0356bf70);
        // gốc: /* try { // try from 01c9f4f4 to 01c9f50f has its CatchHandler @ 01c9f7f1 */
        // gốc: uVar6 = System_String__Concat(DAT_035a65f8,local_40,DAT_03597f88,0);
        // → uVar6 = System_String.Concat(DAT_035a65f8,local_40,DAT_03597f88,0);
        // gốc: if (*(int *)(DAT_035631e8 + 0xe0) == 0) {
        // gốc: }
        // gốc: uVar1 = *(undefined8 *)(*(long *)(DAT_035631e8 + 0xb8) + 8);
        // gốc: if (*(int *)(DAT_03563280 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9f532 to 01c9f536 has its CatchHandler @ 01c9f7cd */
        // gốc: }
        // gốc: /* try { // try from 01c9f537 to 01c9f542 has its CatchHandler @ 01c9f7e7 */
        // gốc: cVar2 = UnityEngine_Object__op_Inequality(uVar1,0,0);
        // → cVar2 = UnityEngine_Object.op_Inequality(uVar1,0,0);
        // gốc: if (cVar2 != '\0') {
        // gốc: if (*(int *)(DAT_035631e8 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9f554 to 01c9f558 has its CatchHandler @ 01c9f807 */
        // gốc: }
        // gốc: lVar4 = *(long *)(*(long *)(DAT_035631e8 + 0xb8) + 8);
        // gốc: if (lVar4 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01c9f7bc to 01c9f7c0 has its CatchHandler @ 01c9f7e5 */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01c9f571 to 01c9f577 has its CatchHandler @ 01c9f7e5 */
        // gốc: Npc__HeadText_SetNameColorID(lVar4,0);
        // → Npc.HeadText_SetNameColorID(lVar4,0);
        // gốc: lVar4 = *(long *)(*(long *)(DAT_035631e8 + 0xb8) + 8);
        // gốc: if (lVar4 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01c9f7c1 to 01c9f7c5 has its CatchHandler @ 01c9f7db */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01c9f596 to 01c9f59c has its CatchHandler @ 01c9f7d9 */
        // gốc: Npc__BloodBar_SetColorType(lVar4,*(undefined4 *)(lVar4 + 0x22c),0);
        // → Npc.BloodBar_SetColorType(lVar4,*(undefined4 *)(lVar4 + 0x22c),0);
        // gốc: }
        // gốc: /* try { // try from 01c9f59d to 01c9f5a4 has its CatchHandler @ 01c9f7e3 */
        // gốc: cVar2 = RepresentModule__IsResourceExist(uVar6);
        // → cVar2 = RepresentModule.IsResourceExist(uVar6);
        // gốc: lVar4 = DAT_0357a7a8;
        // gốc: if (cVar2 == '\0') {
        // gốc: lVar5 = *(long *)(DAT_0357a7a8 + 0x38);
        // gốc: if (lVar5 == 0) {
        // gốc: /* try { // try from 01c9f6b7 to 01c9f720 has its CatchHandler @ 01c9f7ed */
        // gốc: FUN_017f2a16(DAT_0357a7a8);
        // gốc: lVar5 = *(long *)(lVar4 + 0x38);
        // gốc: }
        // gốc: lVar5 = *(long *)(lVar5 + 0x10);
        // gốc: if ((*(byte *)(lVar5 + 0x135) & 1) == 0) {
        // gốc: lVar5 = FUN_017f29c6();
        // gốc: }
        // gốc: if (*(int *)(lVar5 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar4 = *(long *)(*(long *)(lVar4 + 0x38) + 0x10);
        // gốc: if ((*(byte *)(lVar4 + 0x135) & 1) == 0) {
        // gốc: lVar4 = FUN_017f29c6(lVar4);
        // gốc: }
        // gốc: uVar6 = **(undefined8 **)(lVar4 + 0xb8);
        // gốc: if (*(int *)(DAT_03562a00 + 0xe0) == 0) {
        // gốc: }
        // gốc: /* try { // try from 01c9f735 to 01c9f73e has its CatchHandler @ 01c9f7d5 */
        // gốc: LogHelper__ERROR(DAT_035a5af0,DAT_035a2570,uVar6,0);
        // → LogHelper.ERROR(DAT_035a5af0,DAT_035a2570,uVar6,0);
        // gốc: }
        // gốc: else {
        // gốc: /* try { // try from 01c9f5b7 to 01c9f5c8 has its CatchHandler @ 01c9f7e1 */
        // gốc: lVar4 = thunk_FUN_01851e62(DAT_03562300);
        // gốc: IniFile___ctor(lVar4,0);
        // → IniFile_.ctor(lVar4,0);
        // gốc: if (lVar4 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01c9f7c6 to 01c9f7ca has its CatchHandler @ 01c9f7d7 */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01c9f5d2 to 01c9f5de has its CatchHandler @ 01c9f7d3 */
        // gốc: IniFile__Load(lVar4,uVar6,0);
        // → IniFile.Load(lVar4,uVar6,0);
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: /* try { // try from 01c9f5f2 to 01c9f5f6 has its CatchHandler @ 01c9f7cb */
        // gốc: }
        // gốc: /* try { // try from 01c9f620 to 01c9f62a has its CatchHandler @ 01c9f7d1 */
        // gốc: IniFile__GetInteger(lVar4,DAT_0359ae08,DAT_035a50b0,
        // → IniFile.GetInteger(lVar4,DAT_0359ae08,DAT_035a50b0,
        // gốc: *(long *)(DAT_035642f0 + 0xb8) + 0x1c,0);
        // gốc: /* try { // try from 01c9f64d to 01c9f657 has its CatchHandler @ 01c9f7cf */
        // gốc: IniFile__GetInteger(lVar4,DAT_0359ae08,DAT_035a50b8,
        // → IniFile.GetInteger(lVar4,DAT_0359ae08,DAT_035a50b8,
        // gốc: *(long *)(DAT_035642f0 + 0xb8) + 0x20,0);
        // gốc: }
        // gốc: /* try { // try from 01c9f73f to 01c9f748 has its CatchHandler @ 01c9f7df */
        // gốc: SceneScroll__SetScroll(param_3,0);
        // → SceneScroll.SetScroll(param_3,0);
        // gốc: }
        // gốc: }
        // gốc: return;
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01c9f780 to 01c9f784 has its CatchHandler @ 01c9f809 */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
        // gốc: }
        // gốc: // ------------------------------------------------------------
    }

    // ─── PORT 1-1: SceneModule.IsLoading ───
    // VMA: 0x01c9f8cf — Source: decomp_01c9.c:11917
    public int IsLoading()
    {
        // gốc: int iVar1;
        // gốc: undefined4 uVar2;
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: iVar1 = *(int *)(*(long *)(DAT_035642f0 + 0xb8) + 0x68);
        // gốc: if (iVar1 == 0) {
        // gốc: uVar2 = 0;
        // gốc: }
        // gốc: else {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: iVar1 = *(int *)(*(long *)(DAT_035642f0 + 0xb8) + 0x68);
        // gốc: }
        // gốc: uVar2 = CONCAT31((int3)((uint)iVar1 >> 8),iVar1 != 4);
        // gốc: }
        // gốc: return uVar2;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.Init ───
    // VMA: 0x01c9f93c — Source: decomp_01c9.c:11951
    public long Init()
    {
        // gốc: undefined8 uVar1;
        // gốc: uVar1 = thunk_FUN_01851e62(DAT_03568408);
        // gốc: SceneModule_<Init>d__24___ctor(uVar1,0,0);
        // → SceneModule_<Init>d__24_.ctor(uVar1,0,0);
        // gốc: return uVar1;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.MapPos2LogicPos ───
    // VMA: 0x01c9f97c — Source: decomp_01c9.c:11972
    public long MapPos2LogicPos(float param_1)
    {
        // gốc: int iVar1;
        // gốc: int iVar2;
        // gốc: undefined1 in_XMM0 [16];
        // gốc: undefined1 auVar3 [16];
        // gốc: in_XMM0 = ZEXT416(in_XMM0._0_4_);
        // gốc: if (*(int *)(DAT_035606b0 + 0xe0) == 0) {
        // gốc: in_XMM0 = ZEXT416(in_XMM0._0_4_);
        // gốc: }
        // gốc: auVar3._4_12_ = in_XMM0._4_12_;
        // gốc: auVar3._0_4_ = in_XMM0._0_4_ / 0.00125;
        // gốc: iVar1 = System_Convert__ToInt32(auVar3._0_8_,0);
        // → iVar1 = System_Convert.ToInt32(auVar3._0_8_,0);
        // gốc: iVar2 = System_Convert__ToInt32(param_1 / 0.00125,0);
        // → iVar2 = System_Convert.ToInt32(param_1 / 0.00125,0);
        // gốc: auVar3 = insertps(ZEXT416((uint)(float)iVar1),ZEXT416((uint)(float)(iVar2 * 2)),0x10);
        // gốc: return auVar3._0_8_;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.MapPosToLogicPos3D ───
    // VMA: 0x01c9fa15 — Source: decomp_01c9.c:12004
    public long MapPosToLogicPos3D(float param_1)
    {
        // gốc: int iVar1;
        // gốc: int iVar2;
        // gốc: undefined1 in_XMM0 [16];
        // gốc: undefined1 auVar3 [16];
        // gốc: in_XMM0 = ZEXT416(in_XMM0._0_4_);
        // gốc: if (*(int *)(DAT_035606b0 + 0xe0) == 0) {
        // gốc: in_XMM0 = ZEXT416(in_XMM0._0_4_);
        // gốc: }
        // gốc: auVar3._4_12_ = in_XMM0._4_12_;
        // gốc: auVar3._0_4_ = in_XMM0._0_4_ / 0.00125;
        // gốc: iVar1 = System_Convert__ToInt32(auVar3._0_8_,0);
        // → iVar1 = System_Convert.ToInt32(auVar3._0_8_,0);
        // gốc: iVar2 = System_Convert__ToInt32(param_1 / 0.00125,0);
        // → iVar2 = System_Convert.ToInt32(param_1 / 0.00125,0);
        // gốc: auVar3 = insertps(ZEXT416((uint)(float)iVar1),ZEXT416((uint)(float)(iVar2 * 2)),0x10);
        // gốc: return auVar3._0_8_;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.GetMapPos3D ───
    // VMA: 0x01c9fab1 — Source: decomp_01c9.c:12036
    public long GetMapPos3D(long param_1)
    {
        // gốc: undefined1 in_XMM0 [16];
        // gốc: undefined1 auVar1 [16];
        // gốc: undefined1 auVar2 [16];
        // gốc: undefined4 in_XMM1_Dc;
        // gốc: undefined4 in_XMM1_Dd;
        // gốc: auVar1._4_12_ = in_XMM0._4_12_;
        // gốc: auVar1._0_4_ = in_XMM0._0_4_ * 0.00125;
        // gốc: auVar2._4_4_ = (int)((ulong)param_1 >> 0x20);
        // gốc: auVar2._0_4_ = (float)param_1 * 0.00125 * 0.5;
        // gốc: auVar2._8_4_ = in_XMM1_Dc;
        // gốc: auVar2._12_4_ = in_XMM1_Dd;
        // gốc: auVar2 = insertps(auVar1,auVar2,0x10);
        // gốc: return auVar2._0_8_;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.Logic2MapX ───
    // VMA: 0x01c9faf9 — Source: decomp_01c9.c:12091
    public float Logic2MapX(int param_1)
    {
        // gốc: return (float)param_1 * 0.00125;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.Logic2MapY ───
    // VMA: 0x01c9fb06 — Source: decomp_01c9.c:12104
    public float Logic2MapY(int param_1)
    {
        // gốc: return (float)param_1 * 0.00125 * 0.5;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.Logic2MapZ ───
    // VMA: 0x01c9fb1b — Source: decomp_01c9.c:12117
    public float Logic2MapZ(int param_1)
    {
        // gốc: return (float)param_1 * 0.00125 * 0.5;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.IsLogicPointValid ───
    // VMA: 0x01c9fb30 — Source: decomp_01c9.c:12130
    public int IsLogicPointValid(int param_1, int param_2)
    {
        // gốc: int iVar1;
        // gốc: undefined4 uVar2;
        // gốc: long lVar3;
        // gốc: if (param_1 < 0) {
        // gốc: uVar2 = 0;
        // gốc: }
        // gốc: else {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: uVar2 = 0;
        // gốc: if (-1 < param_2) {
        // gốc: lVar3 = *(long *)(DAT_035642f0 + 0xb8);
        // gốc: if (param_1 < *(int *)(lVar3 + 0x1c) * 0x2000) {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: lVar3 = *(long *)(DAT_035642f0 + 0xb8);
        // gốc: }
        // gốc: iVar1 = *(int *)(lVar3 + 0x20) * 0x2000;
        // gốc: uVar2 = CONCAT31((int3)((uint)iVar1 >> 8),param_2 < iVar1);
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: return uVar2;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.ChangeDynObst ───
    // VMA: 0x01c9fbb6 — Source: decomp_01c9.c:12171
    public void ChangeDynObst()
    {
        // gốc: return;
    }

    // ─── PORT 1-1: SceneModule.ClearDynObst ───
    // VMA: 0x01c9fbb7 — Source: decomp_01c9.c:12184
    public void ClearDynObst()
    {
        // gốc: return;
    }

    // ─── PORT 1-1: SceneModule.IsLoadScene ───
    // VMA: 0x01c9fbb8 — Source: decomp_01c9.c:12197
    public long IsLoadScene()
    {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: return CONCAT71((int7)((ulong)*(long *)(DAT_035642f0 + 0xb8) >> 8),
        // gốc: *(undefined1 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x24));
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.IsLoad3DSceneFinished ───
    // VMA: 0x01c9fbfc — Source: decomp_01c9.c:12218
    public long IsLoad3DSceneFinished()
    {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: return CONCAT71((int7)((ulong)*(long *)(DAT_035642f0 + 0xb8) >> 8),
        // gốc: *(undefined1 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x25));
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.CheckReload ───
    // VMA: 0x01c9fc40 — Source: decomp_01c9.c:12239
    public void CheckReload()
    {
        // gốc: char cVar1;
        // gốc: long lVar2;
        // gốc: long lVar3;
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar2 = *(long *)(DAT_035642f0 + 0xb8);
        // gốc: *(undefined1 *)(lVar2 + 0x6c) = 0;
        // gốc: *(undefined1 *)(lVar2 + 0x80) = 0;
        // gốc: cVar1 = SceneModule__IsLoading();
        // → cVar1 = SceneModule.IsLoading();
        // gốc: if (cVar1 != '\0') {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar3 = DAT_035642f0;
        // gốc: lVar2 = *(long *)(DAT_035642f0 + 0xb8);
        // gốc: *(undefined1 *)(lVar2 + 0x6c) = 1;
        // gốc: if (*(int *)(lVar2 + 0x68) == 2) {
        // gốc: if (*(int *)(lVar3 + 0xe0) == 0) {
        // gốc: lVar2 = *(long *)(DAT_035642f0 + 0xb8);
        // gốc: lVar3 = DAT_035642f0;
        // gốc: }
        // gốc: *(undefined1 *)(lVar2 + 0x80) = 1;
        // gốc: }
        // gốc: if (*(int *)(lVar3 + 0xe0) == 0) {
        // gốc: lVar3 = DAT_035642f0;
        // gốc: }
        // gốc: lVar2 = *(long *)(*(long *)(lVar3 + 0xb8) + 0x70);
        // gốc: if (lVar2 != 0) {
        // gốc: if (*(int *)(lVar3 + 0xe0) == 0) {
        // gốc: lVar2 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x70);
        // gốc: }
        // gốc: if (*(int *)(DAT_035626e8 + 0xe0) == 0) {
        // gốc: }
        // gốc: KCoroutine__StopCoroutine(lVar2,0);
        // → KCoroutine.StopCoroutine(lVar2,0);
        // gốc: lVar3 = DAT_035642f0;
        // gốc: *(undefined8 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x70) = 0;
        // gốc: }
        // gốc: if (*(int *)(lVar3 + 0xe0) == 0) {
        // gốc: lVar3 = DAT_035642f0;
        // gốc: }
        // gốc: lVar2 = *(long *)(*(long *)(lVar3 + 0xb8) + 0x78);
        // gốc: if (lVar2 != 0) {
        // gốc: if (*(int *)(lVar3 + 0xe0) == 0) {
        // gốc: lVar2 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x78);
        // gốc: }
        // gốc: if (*(int *)(DAT_035626e8 + 0xe0) == 0) {
        // gốc: }
        // gốc: KCoroutine__StopCoroutine(lVar2,0);
        // → KCoroutine.StopCoroutine(lVar2,0);
        // gốc: *(undefined8 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x78) = 0;
        // gốc: }
        // gốc: }
        // gốc: return;
    }

    // ─── PORT 1-1: SceneModule._LoadScene ───
    // VMA: 0x01c9fdd4 — Source: decomp_01c9.c:12317
    public void _LoadScene(long param_1)
    {
        // gốc: long lVar1;
        // gốc: undefined8 uVar2;
        // gốc: long *plVar3;
        // gốc: undefined8 uVar4;
        // gốc: if (*(int *)(DAT_03561688 + 0xe0) == 0) {
        // gốc: }
        // gốc: if (*(char *)(*(long *)(DAT_03561688 + 0xb8) + 0x65) != '\0') {
        // gốc: if (*(int *)(DAT_035615e8 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar1 = GPM_GPMFPSMeasureTimer__get_Instance(0);
        // → lVar1 = GPM_GPMFPSMeasureTimer.get_Instance(0);
        // gốc: if (lVar1 == 0) goto LAB_01ca00f5;
        // gốc: GPM_GPMFPSMeasureTimer__EndScene(lVar1,0);
        // → GPM_GPMFPSMeasureTimer.EndScene(lVar1,0);
        // gốc: lVar1 = GPM_GPMFPSMeasureTimer__get_Instance(0);
        // → lVar1 = GPM_GPMFPSMeasureTimer.get_Instance(0);
        // gốc: if (lVar1 == 0) goto LAB_01ca00f5;
        // gốc: GPM_GPMFPSMeasureTimer__BeginScene(lVar1,param_1,0);
        // → GPM_GPMFPSMeasureTimer.BeginScene(lVar1,param_1,0);
        // gốc: lVar1 = GPM_GPMFPSMeasureTimer__get_Instance(0);
        // → lVar1 = GPM_GPMFPSMeasureTimer.get_Instance(0);
        // gốc: if (lVar1 == 0) goto LAB_01ca00f5;
        // gốc: GPM_GPMFPSMeasureTimer__BeginLoadScene(lVar1,0);
        // → GPM_GPMFPSMeasureTimer.BeginLoadScene(lVar1,0);
        // gốc: }
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: *(undefined4 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x68) = 2;
        // gốc: if (*(int *)(DAT_03565798 + 0xe0) == 0) {
        // gốc: }
        // gốc: uVar2 = UtilsHelper__GetTickCount(0);
        // → uVar2 = UtilsHelper.GetTickCount(0);
        // gốc: *(undefined8 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x48) = uVar2;
        // gốc: plVar3 = (long *)FUN_0185f8db(DAT_0355f128,1);
        // gốc: if (plVar3 != (long *)0x0) {
        // gốc: if (param_1 != 0) {
        // gốc: lVar1 = thunk_FUN_01851d86(param_1,*(undefined8 *)(*plVar3 + 0x40));
        // gốc: if (lVar1 == 0) {
        // gốc: uVar2 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar2,0);
        // gốc: }
        // gốc: }
        // gốc: if ((int)plVar3[3] == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
        // gốc: }
        // gốc: plVar3[4] = param_1;
        // gốc: if (*(int *)(DAT_03562a00 + 0xe0) == 0) {
        // gốc: }
        // gốc: LogHelper__INFO(DAT_035a5af0,DAT_035ab930,plVar3,0);
        // → LogHelper.INFO(DAT_035a5af0,DAT_035ab930,plVar3,0);
        // gốc: if (*(int *)(DAT_03561688 + 0xe0) == 0) {
        // gốc: }
        // gốc: if (*(char *)(*(long *)(DAT_03561688 + 0xb8) + 8) != '\0') {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: plVar3 = *(long **)(*(long *)(DAT_035642f0 + 0xb8) + 0x38);
        // gốc: if (plVar3 != (long *)0x0) {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: plVar3 = *(long **)(*(long *)(DAT_035642f0 + 0xb8) + 0x38);
        // gốc: if (plVar3 == (long *)0x0) goto LAB_01ca00f5;
        // gốc: }
        // gốc: (**(code **)(*plVar3 + 0x1b8))(plVar3,*(undefined8 *)(*plVar3 + 0x1c0));
        // gốc: *(undefined8 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x38) = 0;
        // gốc: }
        // gốc: uVar2 = System_String__Format(DAT_035b28a8,param_1,param_1,0);
        // → uVar2 = System_String.Format(DAT_035b28a8,param_1,param_1,0);
        // gốc: uVar4 = thunk_FUN_01851e62(DAT_03566420);
        // gốc: BaseLoader_LoaderCallBack___ctor(uVar4,0,DAT_03588048,0);
        // → BaseLoader_LoaderCallBack_.ctor(uVar4,0,DAT_03588048,0);
        // gốc: uVar2 = SceneLoader__Load(uVar2,0,uVar4,0);
        // → uVar2 = SceneLoader.Load(uVar2,0,uVar4,0);
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: *(undefined8 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x38) = uVar2;
        // gốc: }
        // gốc: return;
        // gốc: }
        // gốc: LAB_01ca00f5:
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
    }

    // ─── PORT 1-1: SceneModule.PreloadNextSceneResource ───
    // VMA: 0x01ca010e — Source: decomp_01ca.c:1
    public void PreloadNextSceneResource()
    {
        // gốc: long *plVar1;
        // gốc: long lVar2;
        // gốc: long lVar3;
        // gốc: undefined8 uVar4;
        // gốc: plVar1 = (long *)FUN_0185f8db(DAT_0355f128,1);
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar2 = thunk_FUN_01851b32(DAT_035624b0);
        // gốc: if (plVar1 == (long *)0x0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: if (lVar2 != 0) {
        // gốc: lVar3 = thunk_FUN_01851d86(lVar2,*(undefined8 *)(*plVar1 + 0x40));
        // gốc: if (lVar3 == 0) {
        // gốc: uVar4 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar4,0);
        // gốc: }
        // gốc: }
        // gốc: if ((int)plVar1[3] != 0) {
        // gốc: plVar1[4] = lVar2;
        // gốc: if (*(int *)(DAT_03560738 + 0xe0) == 0) {
        // gốc: }
        // gốc: CppModule__CallLua(DAT_035a4890,plVar1,0);
        // → CppModule.CallLua(DAT_035a4890,plVar1,0);
        // gốc: return;
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
    }

    // ─── PORT 1-1: SceneModule.UnloadResourceThenLoadScene ───
    // VMA: 0x01ca0229 — Source: decomp_01ca.c:53
    public long UnloadResourceThenLoadScene()
    {
        // gốc: undefined8 uVar1;
        // gốc: uVar1 = thunk_FUN_01851e62(DAT_03568410);
        // gốc: SceneModule_<UnloadResourceThenLoadScene>d__41___ctor(uVar1,0xfffffffe,0);
        // → SceneModule_<UnloadResourceThenLoadScene>d__41_.ctor(uVar1,0xfffffffe,0);
        // gốc: return uVar1;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.OnLoaderCallBack ───
    // VMA: 0x01ca026c — Source: decomp_01ca.c:74
    public void OnLoaderCallBack(long param_1)
    {
        // gốc: long *plVar1;
        // gốc: long lVar2;
        // gốc: long lVar3;
        // gốc: undefined8 uVar4;
        // gốc: if (param_1 == 0) {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar2 = *(long *)(DAT_035642f0 + 0xb8);
        // gốc: *(undefined2 *)(lVar2 + 0x24) = 0x100;
        // gốc: *(undefined4 *)(lVar2 + 0x68) = 0;
        // gốc: plVar1 = (long *)FUN_0185f8db(DAT_0355f128,1);
        // gốc: lVar2 = thunk_FUN_01851b32(DAT_035624b0);
        // gốc: if (plVar1 == (long *)0x0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: if (lVar2 != 0) {
        // gốc: lVar3 = thunk_FUN_01851d86(lVar2,*(undefined8 *)(*plVar1 + 0x40));
        // gốc: if (lVar3 == 0) {
        // gốc: uVar4 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar4,0);
        // gốc: }
        // gốc: }
        // gốc: if ((int)plVar1[3] == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
        // gốc: }
        // gốc: plVar1[4] = lVar2;
        // gốc: if (*(int *)(DAT_03560738 + 0xe0) == 0) {
        // gốc: }
        // gốc: CppModule__CallLua(DAT_035a2578,plVar1,0);
        // → CppModule.CallLua(DAT_035a2578,plVar1,0);
        // gốc: }
        // gốc: return;
    }

    // ─── PORT 1-1: SceneModule.OnLevelWasLoaded ───
    // VMA: 0x01ca03aa — Source: decomp_01ca.c:131
    public void OnLevelWasLoaded(long param_1)
    {
        // gốc: int iVar1;
        // gốc: long *plVar2;
        // gốc: long lVar3;
        // gốc: long lVar4;
        // gốc: undefined8 uVar5;
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: if (param_1 != 0) {
        // gốc: iVar1 = System_String__CompareTo
        // gốc: (param_1,*(undefined8 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x58),0);
        // gốc: if (iVar1 != 0) {
        // gốc: return;
        // gốc: }
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: *(undefined1 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x25) = 1;
        // gốc: if (*(int *)(DAT_03565798 + 0xe0) == 0) {
        // gốc: }
        // gốc: UtilsHelper__GetTickCount(0);
        // → UtilsHelper.GetTickCount(0);
        // gốc: plVar2 = (long *)FUN_0185f8db(DAT_0355f128,2);
        // gốc: lVar3 = thunk_FUN_01851b32(DAT_035624b0);
        // gốc: if (plVar2 != (long *)0x0) {
        // gốc: if ((lVar3 != 0) &&
        // gốc: (lVar4 = thunk_FUN_01851d86(lVar3,*(undefined8 *)(*plVar2 + 0x40)), lVar4 == 0)) {
        // gốc: LAB_01ca05c8:
        // gốc: uVar5 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar5,0);
        // gốc: }
        // gốc: if ((int)plVar2[3] != 0) {
        // gốc: plVar2[4] = lVar3;
        // gốc: lVar3 = thunk_FUN_01851b32(DAT_03564628);
        // gốc: if ((lVar3 != 0) &&
        // gốc: (lVar4 = thunk_FUN_01851d86(lVar3,*(undefined8 *)(*plVar2 + 0x40)), lVar4 == 0))
        // gốc: goto LAB_01ca05c8;
        // gốc: if (1 < *(uint *)(plVar2 + 3)) {
        // gốc: plVar2[5] = lVar3;
        // gốc: if (*(int *)(DAT_03562a00 + 0xe0) == 0) {
        // gốc: }
        // gốc: LogHelper__INFO(DAT_035a5af0,DAT_035b7c50,plVar2,0);
        // → LogHelper.INFO(DAT_035a5af0,DAT_035b7c50,plVar2,0);
        // gốc: SceneModule___OnLoadSceneFinished();
        // → SceneModule_.OnLoadSceneFinished();
        // gốc: return;
        // gốc: }
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
        // gốc: }
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
    }

    // ─── PORT 1-1: SceneModule._OnLoadSceneFinished ───
    // VMA: 0x01ca05d7 — Source: decomp_01ca.c:209
    public void _OnLoadSceneFinished()
    {
        // gốc: long *plVar1;
        // gốc: long lVar2;
        // gốc: long lVar3;
        // gốc: undefined8 uVar4;
        // gốc: long lVar5;
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: *(undefined1 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x24) = 0;
        // gốc: if (*(int *)(DAT_035615c0 + 0xe0) == 0) {
        // gốc: }
        // gốc: System_GC__Collect(0);
        // → System_GC.Collect(0);
        // gốc: if (*(int *)(DAT_03561688 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar2 = DAT_035642f0;
        // gốc: if (*(char *)(*(long *)(DAT_03561688 + 0xb8) + 8) == '\0') {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar2 = DAT_035642f0;
        // gốc: *(undefined8 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x30) = 0;
        // gốc: }
        // gốc: if (*(int *)(lVar2 + 0xe0) == 0) {
        // gốc: lVar2 = DAT_035642f0;
        // gốc: }
        // gốc: if (*(int *)(*(long *)(lVar2 + 0xb8) + 0x18) == 0) {
        // gốc: plVar1 = (long *)FUN_0185f8db(DAT_0355f128,1);
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar2 = thunk_FUN_01851b32(DAT_035624b0);
        // gốc: if (plVar1 == (long *)0x0) goto LAB_01ca0a39;
        // gốc: if (lVar2 != 0) {
        // gốc: lVar3 = thunk_FUN_01851d86(lVar2,*(undefined8 *)(*plVar1 + 0x40));
        // gốc: if (lVar3 == 0) goto LAB_01ca0a43;
        // gốc: }
        // gốc: if ((int)plVar1[3] == 0) goto LAB_01ca0a3e;
        // gốc: plVar1[4] = lVar2;
        // gốc: if (*(int *)(DAT_03560738 + 0xe0) == 0) {
        // gốc: }
        // gốc: CppModule__CallLua(DAT_035a2580,plVar1,0);
        // → CppModule.CallLua(DAT_035a2580,plVar1,0);
        // gốc: }
        // gốc: if (*(int *)(DAT_03563fa0 + 0xe0) == 0) {
        // gốc: }
        // gốc: RepresentEvent__OnLogicReptEvent(1,0,0,0,0);
        // → RepresentEvent.OnLogicReptEvent(1,0,0,0,0);
        // gốc: if (*(int *)(DAT_03564030 + 0xe0) == 0) {
        // gốc: }
        // gốc: ResourceModule__SetMapLoadingTopPriority(0,0);
        // → ResourceModule.SetMapLoadingTopPriority(0,0);
        // gốc: if (*(int *)(DAT_03565798 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar2 = UtilsHelper__GetTickCount(0);
        // → lVar2 = UtilsHelper.GetTickCount(0);
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar5 = DAT_035642f0;
        // gốc: lVar3 = *(long *)(DAT_035642f0 + 0xb8);
        // gốc: *(long *)(lVar3 + 0x40) = lVar2 - *(long *)(lVar3 + 0x40);
        // gốc: *(undefined8 *)(lVar3 + 0x48) = 0;
        // gốc: *(undefined8 *)(lVar3 + 0x50) = 0;
        // gốc: if (*(int *)(lVar3 + 0x18) != 0) {
        // gốc: lVar2 = Game_Common_SceneOcclusion__Instance(0);
        // → lVar2 = Game_Common_SceneOcclusion.Instance(0);
        // gốc: if (lVar2 == 0) goto LAB_01ca0a39;
        // gốc: *(undefined1 *)(lVar2 + 0x52) = 1;
        // gốc: lVar2 = Game_Common_SceneOcclusion__Instance(0);
        // → lVar2 = Game_Common_SceneOcclusion.Instance(0);
        // gốc: if (lVar2 == 0) goto LAB_01ca0a39;
        // gốc: Game_Common_SceneOcclusion__Init(lVar2,0);
        // → Game_Common_SceneOcclusion.Init(lVar2,0);
        // gốc: lVar5 = DAT_035642f0;
        // gốc: }
        // gốc: if (*(int *)(lVar5 + 0xe0) == 0) {
        // gốc: lVar5 = DAT_035642f0;
        // gốc: }
        // gốc: *(undefined4 *)(*(long *)(lVar5 + 0xb8) + 0x68) = 4;
        // gốc: plVar1 = (long *)FUN_0185f8db(DAT_0355f128,1);
        // gốc: lVar2 = thunk_FUN_01851b32(DAT_035624b0);
        // gốc: if (plVar1 != (long *)0x0) {
        // gốc: if (lVar2 != 0) {
        // gốc: lVar3 = thunk_FUN_01851d86(lVar2,*(undefined8 *)(*plVar1 + 0x40));
        // gốc: if (lVar3 == 0) {
        // gốc: LAB_01ca0a43:
        // gốc: uVar4 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar4,0);
        // gốc: }
        // gốc: }
        // gốc: if ((int)plVar1[3] == 0) {
        // gốc: LAB_01ca0a3e:
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
        // gốc: }
        // gốc: plVar1[4] = lVar2;
        // gốc: if (*(int *)(DAT_035609a0 + 0xe0) == 0) {
        // gốc: }
        // gốc: UnityEngine_Debug__LogFormat(DAT_035a5b00,plVar1,0);
        // → UnityEngine_Debug.LogFormat(DAT_035a5b00,plVar1,0);
        // gốc: NavigationModule_AStar__Init(0);
        // → NavigationModule_AStar.Init(0);
        // gốc: plVar1 = *(long **)(*(long *)(DAT_035642f0 + 0xb8) + 0x38);
        // gốc: if (plVar1 != (long *)0x0) {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: plVar1 = *(long **)(*(long *)(DAT_035642f0 + 0xb8) + 0x38);
        // gốc: if (plVar1 == (long *)0x0) goto LAB_01ca0a39;
        // gốc: }
        // gốc: (**(code **)(*plVar1 + 0x1b8))(plVar1,*(undefined8 *)(*plVar1 + 0x1c0));
        // gốc: *(undefined8 *)(*(long *)(DAT_035642f0 + 0xb8) + 0x38) = 0;
        // gốc: }
        // gốc: if (*(int *)(DAT_03561688 + 0xe0) == 0) {
        // gốc: }
        // gốc: if (*(char *)(*(long *)(DAT_03561688 + 0xb8) + 0x65) != '\0') {
        // gốc: if (*(int *)(DAT_035615e8 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar2 = GPM_GPMFPSMeasureTimer__get_Instance(0);
        // → lVar2 = GPM_GPMFPSMeasureTimer.get_Instance(0);
        // gốc: if (lVar2 == 0) goto LAB_01ca0a39;
        // gốc: GPM_GPMFPSMeasureTimer__EndLoadScene(lVar2,0);
        // → GPM_GPMFPSMeasureTimer.EndLoadScene(lVar2,0);
        // gốc: }
        // gốc: return;
        // gốc: }
        // gốc: LAB_01ca0a39:
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
    }

    // ─── PORT 1-1: SceneModule.GetLoadingProgress ───
    // VMA: 0x01ca0a52 — Source: decomp_01ca.c:367
    public long GetLoadingProgress()
    {
        // gốc: char cVar1;
        // gốc: code *UNRECOVERED_JUMPTABLE;
        // gốc: long *plVar2;
        // gốc: long lVar3;
        // gốc: undefined8 uVar4;
        // gốc: if (*(int *)(DAT_03561688 + 0xe0) == 0) {
        // gốc: }
        // gốc: cVar1 = *(char *)(*(long *)(DAT_03561688 + 0xb8) + 8);
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: if (cVar1 == '\0') {
        // gốc: lVar3 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x30);
        // gốc: if (lVar3 != 0) {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: lVar3 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x30);
        // gốc: if (lVar3 == 0) goto LAB_01ca0b56;
        // gốc: }
        // gốc: uVar4 = UnityEngine_AsyncOperation__get_progress(lVar3,0);
        // → uVar4 = UnityEngine_AsyncOperation.get_progress(lVar3,0);
        // gốc: return uVar4;
        // gốc: }
        // gốc: }
        // gốc: else {
        // gốc: plVar2 = *(long **)(*(long *)(DAT_035642f0 + 0xb8) + 0x38);
        // gốc: if (plVar2 != (long *)0x0) {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: plVar2 = *(long **)(*(long *)(DAT_035642f0 + 0xb8) + 0x38);
        // gốc: if (plVar2 == (long *)0x0) {
        // gốc: LAB_01ca0b56:
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: }
        // gốc: UNRECOVERED_JUMPTABLE = *(code **)(*plVar2 + 0x178);
        // gốc: /* WARNING: Could not recover jumptable at 0x01ca0b0e. Too many branches */
        // gốc: /* WARNING: Treating indirect jump as call */
        // gốc: uVar4 = (*UNRECOVERED_JUMPTABLE)
        // gốc: (plVar2,*(undefined8 *)(*plVar2 + 0x180),UNRECOVERED_JUMPTABLE);
        // gốc: return uVar4;
        // gốc: }
        // gốc: }
        // gốc: return 0;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.LoadMapSetting ───
    // VMA: 0x01ca0b5b — Source: decomp_01ca.c:430
    public void LoadMapSetting()
    {
        // gốc: char cVar1;
        // gốc: undefined4 uVar2;
        // gốc: long *plVar3;
        // gốc: undefined8 *puVar4;
        // gốc: long lVar5;
        // gốc: long lVar6;
        // gốc: long lVar7;
        // gốc: undefined1 local_40 [16];
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar5 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x60);
        // gốc: if (lVar5 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: System_Collections_Generic_Dictionary<int,_SceneModule_MapInfo>__Clear(lVar5,DAT_0356bf60);
        // gốc: local_40 = TabLoader__Load(DAT_035a6600,0);
        // → local_40 = TabLoader.Load(DAT_035a6600,0);
        // gốc: plVar3 = (long *)TabLoader_Shell__GetEnumerator(local_40,0);
        // → plVar3 = (long *)TabLoader_Shell.GetEnumerator(local_40,0);
        // gốc: if (plVar3 == (long *)0x0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01ca0e3a to 01ca0e3e has its CatchHandler @ 01ca0e3f */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: do {
        // gốc: lVar5 = *plVar3;
        // gốc: if ((ulong)*(ushort *)(lVar5 + 0x12e) != 0) {
        // gốc: lVar7 = 0;
        // gốc: do {
        // gốc: if (*(long *)(*(long *)(lVar5 + 0xb0) + lVar7) == DAT_03561cb0) {
        // gốc: puVar4 = (undefined8 *)
        // gốc: ((long)*(int *)(*(long *)(lVar5 + 0xb0) + 8 + lVar7) * 0x10 + lVar5 + 0x138);
        // gốc: goto LAB_01ca0cd5;
        // gốc: }
        // gốc: lVar7 = lVar7 + 0x10;
        // gốc: } while ((ulong)*(ushort *)(lVar5 + 0x12e) << 4 != lVar7);
        // gốc: }
        // gốc: /* try { // try from 01ca0cb3 to 01ca0cdd has its CatchHandler @ 01ca0e5d */
        // gốc: puVar4 = (undefined8 *)FUN_017f2cac(plVar3,DAT_03561cb0,0);
        // gốc: LAB_01ca0cd5:
        // gốc: cVar1 = (*(code *)*puVar4)(plVar3,puVar4[1]);
        // gốc: if (cVar1 == '\0') {
        // gốc: if (plVar3 == (long *)0x0) {
        // gốc: return;
        // gốc: }
        // gốc: lVar5 = *plVar3;
        // gốc: if ((ulong)*(ushort *)(lVar5 + 0x12e) == 0) goto LAB_01ca0eb9;
        // gốc: lVar7 = 0;
        // gốc: break;
        // gốc: }
        // gốc: lVar5 = *plVar3;
        // gốc: if ((ulong)*(ushort *)(lVar5 + 0x12e) != 0) {
        // gốc: lVar7 = 0;
        // gốc: do {
        // gốc: if (*(long *)(*(long *)(lVar5 + 0xb0) + lVar7) == DAT_0355d220) {
        // gốc: puVar4 = (undefined8 *)
        // gốc: ((long)*(int *)(*(long *)(lVar5 + 0xb0) + 8 + lVar7) * 0x10 + lVar5 + 0x138);
        // gốc: goto LAB_01ca0d3e;
        // gốc: }
        // gốc: lVar7 = lVar7 + 0x10;
        // gốc: } while ((ulong)*(ushort *)(lVar5 + 0x12e) << 4 != lVar7);
        // gốc: }
        // gốc: /* try { // try from 01ca0d1c to 01ca0d46 has its CatchHandler @ 01ca0e5b */
        // gốc: puVar4 = (undefined8 *)FUN_017f2cac(plVar3,DAT_0355d220,0);
        // gốc: LAB_01ca0d3e:
        // gốc: lVar5 = (*(code *)*puVar4)(plVar3,puVar4[1]);
        // gốc: if (lVar5 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01ca0e26 to 01ca0e2a has its CatchHandler @ 01ca0e45 */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01ca0d5d to 01ca0d7b has its CatchHandler @ 01ca0e59 */
        // gốc: uVar2 = TabLoader_Row__GetInt(lVar5,DAT_035a7770,0);
        // → uVar2 = TabLoader_Row.GetInt(lVar5,DAT_035a7770,0);
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar7 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x60);
        // gốc: /* try { // try from 01ca0d95 to 01ca0d9e has its CatchHandler @ 01ca0e47 */
        // gốc: lVar6 = TabLoader_Row__GetStr(lVar5,DAT_035a55a0,0);
        // → lVar6 = TabLoader_Row.GetStr(lVar5,DAT_035a55a0,0);
        // gốc: if (lVar6 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01ca0e2b to 01ca0e2f has its CatchHandler @ 01ca0e43 */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01ca0da8 to 01ca0db1 has its CatchHandler @ 01ca0e49 */
        // gốc: System_String__ToLower(lVar6,0);
        // → System_String.ToLower(lVar6,0);
        // gốc: /* try { // try from 01ca0dbf to 01ca0dc8 has its CatchHandler @ 01ca0e4b */
        // gốc: TabLoader_Row__GetStr(lVar5,DAT_035a0640,0);
        // → TabLoader_Row.GetStr(lVar5,DAT_035a0640,0);
        // gốc: /* try { // try from 01ca0dd6 to 01ca0ddf has its CatchHandler @ 01ca0e4d */
        // gốc: TabLoader_Row__GetStr(lVar5,DAT_035a5bf8,0);
        // → TabLoader_Row.GetStr(lVar5,DAT_035a5bf8,0);
        // gốc: if (lVar7 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01ca0e30 to 01ca0e34 has its CatchHandler @ 01ca0e41 */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01ca0dfe to 01ca0e1b has its CatchHandler @ 01ca0e4f */
        // gốc: System_Collections_Generic_Dictionary<int,_SceneModule_MapInfo>__set_Item
        // gốc: (lVar7,uVar2,DAT_0356bf78);
        // gốc: } while( true );
        // gốc: while (lVar7 = lVar7 + 0x10, (ulong)*(ushort *)(lVar5 + 0x12e) << 4 != lVar7) {
        // gốc: if (*(long *)(*(long *)(lVar5 + 0xb0) + lVar7) == DAT_03561c58) {
        // gốc: puVar4 = (undefined8 *)
        // gốc: (lVar5 + (long)*(int *)(*(long *)(lVar5 + 0xb0) + 8 + lVar7) * 0x10 + 0x138);
        // gốc: goto LAB_01ca0ed7;
        // gốc: }
        // gốc: }
        // gốc: LAB_01ca0eb9:
        // gốc: puVar4 = (undefined8 *)FUN_017f2cac(plVar3,DAT_03561c58,0);
        // gốc: LAB_01ca0ed7:
        // gốc: (*(code *)*puVar4)(plVar3,puVar4[1]);
        // gốc: return;
        // gốc: }
        // gốc: // ------------------------------------------------------------
    }

    // ─── PORT 1-1: SceneModule.UpdateMapDownloadProgress ───
    // VMA: 0x01ca0f99 — Source: decomp_01ca.c:570
    public void UpdateMapDownloadProgress(int param_1, long param_2, byte param_3, int param_4)
    {
        // gốc: long *plVar1;
        // gốc: long lVar2;
        // gốc: long lVar3;
        // gốc: undefined8 uVar4;
        // gốc: plVar1 = (long *)FUN_0185f8db(DAT_0355f128,4);
        // gốc: if (plVar1 == (long *)0x0) {
        // gốc: LAB_01ca124b:
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: if (param_2 != 0) {
        // gốc: lVar2 = thunk_FUN_01851d86(param_2,*(undefined8 *)(*plVar1 + 0x40));
        // gốc: if (lVar2 == 0) goto LAB_01ca1255;
        // gốc: }
        // gốc: if ((int)plVar1[3] != 0) {
        // gốc: plVar1[4] = param_2;
        // gốc: lVar2 = thunk_FUN_01851b32(DAT_03560040);
        // gốc: if (lVar2 != 0) {
        // gốc: lVar3 = thunk_FUN_01851d86(lVar2,*(undefined8 *)(*plVar1 + 0x40));
        // gốc: if (lVar3 == 0) goto LAB_01ca1255;
        // gốc: }
        // gốc: if (*(uint *)(plVar1 + 3) < 2) goto LAB_01ca1250;
        // gốc: plVar1[5] = lVar2;
        // gốc: lVar2 = thunk_FUN_01851b32(DAT_03564628);
        // gốc: if (lVar2 != 0) {
        // gốc: lVar3 = thunk_FUN_01851d86(lVar2,*(undefined8 *)(*plVar1 + 0x40));
        // gốc: if (lVar3 == 0) goto LAB_01ca1255;
        // gốc: }
        // gốc: if (2 < *(uint *)(plVar1 + 3)) {
        // gốc: plVar1[6] = lVar2;
        // gốc: lVar2 = thunk_FUN_01851b32(DAT_035624b0);
        // gốc: if (lVar2 != 0) {
        // gốc: lVar3 = thunk_FUN_01851d86(lVar2,*(undefined8 *)(*plVar1 + 0x40));
        // gốc: if (lVar3 == 0) {
        // gốc: LAB_01ca1255:
        // gốc: uVar4 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar4,0);
        // gốc: }
        // gốc: }
        // gốc: if (3 < *(uint *)(plVar1 + 3)) {
        // gốc: plVar1[7] = lVar2;
        // gốc: if (*(int *)(DAT_03562a00 + 0xe0) == 0) {
        // gốc: }
        // gốc: LogHelper__INFO(DAT_035a5af0,DAT_035a9890,plVar1,0);
        // → LogHelper.INFO(DAT_035a5af0,DAT_035a9890,plVar1,0);
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: SceneModule__CreateMapInfoIfNeed(param_2);
        // → SceneModule.CreateMapInfoIfNeed(param_2);
        // gốc: lVar2 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: if (lVar2 != 0) {
        // gốc: lVar2 = System_Collections_Generic_Dictionary<object,_object>__get_Item
        // gốc: (lVar2,param_2,DAT_0356d4d8);
        // gốc: if (lVar2 != 0) {
        // gốc: *(undefined1 *)(lVar2 + 0x10) = param_3;
        // gốc: lVar2 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: if (lVar2 != 0) {
        // gốc: lVar2 = System_Collections_Generic_Dictionary<object,_object>__get_Item
        // gốc: (lVar2,param_2,DAT_0356d4d8);
        // gốc: if (lVar2 != 0) {
        // gốc: *(undefined4 *)(lVar2 + 0x18) = param_1;
        // gốc: lVar2 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: if (lVar2 != 0) {
        // gốc: lVar2 = System_Collections_Generic_Dictionary<object,_object>__get_Item
        // gốc: (lVar2,param_2,DAT_0356d4d8);
        // gốc: if (lVar2 != 0) {
        // gốc: *(undefined4 *)(lVar2 + 0x1c) = param_4;
        // gốc: return;
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: goto LAB_01ca124b;
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: LAB_01ca1250:
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
    }

    // ─── PORT 1-1: SceneModule.CreateMapInfoIfNeed ───
    // VMA: 0x01ca1264 — Source: decomp_01ca.c:678
    public void CreateMapInfoIfNeed(long param_1)
    {
        // gốc: long lVar1;
        // gốc: char cVar2;
        // gốc: undefined8 uVar3;
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar1 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: if (lVar1 != 0) {
        // gốc: cVar2 = System_Collections_Generic_Dictionary<object,_object>__ContainsKey
        // gốc: (lVar1,param_1,DAT_0356d4d0);
        // gốc: if (cVar2 != '\0') {
        // gốc: return;
        // gốc: }
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar1 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: uVar3 = thunk_FUN_01851e62(DAT_03568420);
        // gốc: SceneModule_MapDownloadInfo___ctor(uVar3,0);
        // → SceneModule_MapDownloadInfo_.ctor(uVar3,0);
        // gốc: if (lVar1 != 0) {
        // gốc: System_Collections_Generic_Dictionary<object,_object>__Add(lVar1,param_1,uVar3,DAT_0356d4c8);
        // gốc: return;
        // gốc: }
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
    }

    // ─── PORT 1-1: SceneModule.InitMapDownloadInfo ───
    // VMA: 0x01ca135b — Source: decomp_01ca.c:724
    public void InitMapDownloadInfo(long param_1)
    {
        // gốc: char cVar1;
        // gốc: byte bVar2;
        // gốc: undefined4 uVar3;
        // gốc: undefined8 uVar4;
        // gốc: long lVar5;
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: uVar4 = SceneModule__GetFixedPathFromMapName(param_1);
        // → uVar4 = SceneModule.GetFixedPathFromMapName(param_1);
        // gốc: lVar5 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: if (lVar5 != 0) {
        // gốc: cVar1 = System_Collections_Generic_Dictionary<object,_object>__ContainsKey
        // gốc: (lVar5,uVar4,DAT_0356d4d0);
        // gốc: if (cVar1 != '\0') {
        // gốc: return;
        // gốc: }
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: SceneModule__CreateMapInfoIfNeed(uVar4);
        // → SceneModule.CreateMapInfoIfNeed(uVar4);
        // gốc: if (*(int *)(DAT_03560e60 + 0xe0) == 0) {
        // gốc: }
        // gốc: bVar2 = DlcModule__IsBundleDownloaded(uVar4,0);
        // → bVar2 = DlcModule.IsBundleDownloaded(uVar4,0);
        // gốc: lVar5 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: if ((lVar5 != 0) &&
        // gốc: (lVar5 = System_Collections_Generic_Dictionary<object,_object>__get_Item
        // gốc: (lVar5,uVar4,DAT_0356d4d8), lVar5 != 0)) {
        // gốc: *(byte *)(lVar5 + 0x10) = bVar2 ^ 1;
        // gốc: if (bVar2 != 0) {
        // gốc: return;
        // gốc: }
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar5 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: if (lVar5 != 0) {
        // gốc: lVar5 = System_Collections_Generic_Dictionary<object,_object>__get_Item
        // gốc: (lVar5,uVar4,DAT_0356d4d8);
        // gốc: if (*(int *)(DAT_03560e60 + 0xe0) == 0) {
        // gốc: }
        // gốc: uVar3 = DlcModule__GetDownloadSize(uVar4,0);
        // → uVar3 = DlcModule.GetDownloadSize(uVar4,0);
        // gốc: if (lVar5 != 0) {
        // gốc: *(undefined4 *)(lVar5 + 0x14) = uVar3;
        // gốc: return;
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
    }

    // ─── PORT 1-1: SceneModule.GetFixedPathFromMapName ───
    // VMA: 0x01ca14e4 — Source: decomp_01ca.c:796
    public void GetFixedPathFromMapName(long param_1)
    {
        // gốc: undefined8 uVar1;
        // gốc: uVar1 = System_String__Format(DAT_035b28a8,param_1,param_1,0);
        // → uVar1 = System_String.Format(DAT_035b28a8,param_1,param_1,0);
        // gốc: if (*(int *)(DAT_03560120 + 0xe0) == 0) {
        // gốc: }
        // gốc: uVar1 = BundleManager__GetBundlePathFromAssetPath(uVar1,0);
        // → uVar1 = BundleManager.GetBundlePathFromAssetPath(uVar1,0);
        // gốc: if (*(int *)(DAT_03560e60 + 0xe0) == 0) {
        // gốc: }
        // gốc: DlcModule__GetFixedPath(uVar1,0);
        // → DlcModule.GetFixedPath(uVar1,0);
        // gốc: return;
    }

    // ─── PORT 1-1: SceneModule.NeedDownloadMap ───
    // VMA: 0x01ca157e — Source: decomp_01ca.c:826
    public bool NeedDownloadMap(long param_1)
    {
        // gốc: char cVar1;
        // gốc: undefined8 uVar2;
        // gốc: long lVar3;
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: uVar2 = SceneModule__GetFixedPathFromMapName(param_1);
        // → uVar2 = SceneModule.GetFixedPathFromMapName(param_1);
        // gốc: lVar3 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: if (lVar3 != 0) {
        // gốc: cVar1 = System_Collections_Generic_Dictionary<object,_object>__ContainsKey
        // gốc: (lVar3,uVar2,DAT_0356d4d0);
        // gốc: if (cVar1 == '\0') {
        // gốc: uVar2 = System_String__Concat(DAT_035aa820,uVar2,0);
        // → uVar2 = System_String.Concat(DAT_035aa820,uVar2,0);
        // gốc: if (*(int *)(DAT_035609a0 + 0xe0) == 0) {
        // gốc: }
        // gốc: UnityEngine_Debug__LogError(uVar2,0);
        // → UnityEngine_Debug.LogError(uVar2,0);
        // gốc: return true;
        // gốc: }
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar3 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: if ((lVar3 != 0) &&
        // gốc: (lVar3 = System_Collections_Generic_Dictionary<object,_object>__get_Item
        // gốc: (lVar3,uVar2,DAT_0356d4d8), lVar3 != 0)) {
        // gốc: return *(char *)(lVar3 + 0x10) != '\0';
        // gốc: }
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.GetMapTotalSize ───
    // VMA: 0x01ca16b3 — Source: decomp_01ca.c:878
    public int GetMapTotalSize(long param_1)
    {
        // gốc: undefined8 uVar1;
        // gốc: long lVar2;
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: uVar1 = SceneModule__GetFixedPathFromMapName(param_1);
        // → uVar1 = SceneModule.GetFixedPathFromMapName(param_1);
        // gốc: lVar2 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: if (lVar2 != 0) {
        // gốc: lVar2 = System_Collections_Generic_Dictionary<object,_object>__get_Item
        // gốc: (lVar2,uVar1,DAT_0356d4d8);
        // gốc: if (lVar2 != 0) {
        // gốc: return *(undefined4 *)(lVar2 + 0x14);
        // gốc: }
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: SceneModule.GetDownloadedSize ───
    // VMA: 0x01ca173f — Source: decomp_01ca.c:912
    public int GetDownloadedSize(long param_1)
    {
        // gốc: char cVar1;
        // gốc: undefined8 uVar2;
        // gốc: long lVar3;
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: uVar2 = SceneModule__GetFixedPathFromMapName(param_1);
        // → uVar2 = SceneModule.GetFixedPathFromMapName(param_1);
        // gốc: lVar3 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: if (lVar3 != 0) {
        // gốc: cVar1 = System_Collections_Generic_Dictionary<object,_object>__ContainsKey
        // gốc: (lVar3,uVar2,DAT_0356d4d0);
        // gốc: if (cVar1 == '\0') {
        // gốc: uVar2 = System_String__Concat(DAT_035aa820,uVar2,0);
        // → uVar2 = System_String.Concat(DAT_035aa820,uVar2,0);
        // gốc: if (*(int *)(DAT_035609a0 + 0xe0) == 0) {
        // gốc: }
        // gốc: UnityEngine_Debug__LogError(uVar2,0);
        // → UnityEngine_Debug.LogError(uVar2,0);
        // gốc: return 0;
        // gốc: }
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar3 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x88);
        // gốc: if ((lVar3 != 0) &&
        // gốc: (lVar3 = System_Collections_Generic_Dictionary<object,_object>__get_Item
        // gốc: (lVar3,uVar2,DAT_0356d4d8), lVar3 != 0)) {
        // gốc: if (*(char *)(lVar3 + 0x10) == '\0') {
        // gốc: return *(int *)(lVar3 + 0x14);
        // gốc: }
        // gốc: return (int)((float)*(int *)(lVar3 + 0x14) * *(float *)(lVar3 + 0x18));
        // gốc: }
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

