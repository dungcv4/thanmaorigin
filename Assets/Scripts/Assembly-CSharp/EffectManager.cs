// Class:  EffectManager
// GUID:   9a8e04050779e497b7f4a13a3e01001c (preserved via .meta)
// Source: KTO_DecompiledReference/_root/EffectManager.c (2 methods, 254 LOC Ghidra)
// Address range: 0x01c72eeb — 0x01c73090

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

public class EffectManager : MonoBehaviour
{
    // ─── PORT 1-1: EffectManager.PlayWorldEffect ───
    // VMA: 0x01c72eeb — Source: decomp_01c7.c:2210
    public void PlayWorldEffect(int param_1, int param_2)
    {
        // gốc: long lVar1;
        // gốc: long *plVar2;
        // gốc: long lVar3;
        // gốc: undefined8 uVar4;
        // gốc: if (*(int *)(DAT_03563fb0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar1 = RepresentSetting__GetEffectResInfo(param_2,0);
        // → lVar1 = RepresentSetting.GetEffectResInfo(param_2,0);
        // gốc: if (lVar1 == 0) {
        // gốc: plVar2 = (long *)FUN_0185f8db(DAT_0355f128,1);
        // gốc: lVar1 = thunk_FUN_01851b32(DAT_035624b0);
        // gốc: if (plVar2 != (long *)0x0) {
        // gốc: if (lVar1 != 0) {
        // gốc: lVar3 = thunk_FUN_01851d86(lVar1,*(undefined8 *)(*plVar2 + 0x40));
        // gốc: if (lVar3 == 0) {
        // gốc: uVar4 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar4,0);
        // gốc: }
        // gốc: }
        // gốc: if ((int)plVar2[3] != 0) {
        // gốc: plVar2[4] = lVar1;
        // gốc: if (*(int *)(DAT_03562a00 + 0xe0) == 0) {
        // gốc: }
        // gốc: LogHelper__ERROR(DAT_0359db98,DAT_035a46d8,plVar2,0);
        // → LogHelper.ERROR(DAT_0359db98,DAT_035a46d8,plVar2,0);
        // gốc: return;
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
        // gốc: }
        // gốc: }
        // gốc: else if (*(long *)(lVar1 + 0x10) != 0) {
        // gốc: uVar4 = *(undefined8 *)(*(long *)(lVar1 + 0x10) + 0x10);
        // gốc: if (*(int *)(DAT_0355fb68 + 0xe0) == 0) {
        // gốc: }
        // gốc: AssetResourceModule__AddWorldEffectResRequest(uVar4,CONCAT44(param_1,param_2),0);
        // → AssetResourceModule.AddWorldEffectResRequest(uVar4,CONCAT44(param_1,param_2),0);
        // gốc: return;
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
    }

    // ─── PORT 1-1: EffectManager.OnWorldEffectLoadFinish ───
    // VMA: 0x01c73090 — Source: decomp_01c7.c:2275
    public void OnWorldEffectLoadFinish(int param_1, long param_2, ulong param_3)
    {
        // gốc: undefined4 uVar1;
        // gốc: char cVar2;
        // gốc: long lVar3;
        // gốc: long lVar4;
        // gốc: long *plVar5;
        // gốc: undefined8 uVar6;
        // gốc: long *plVar7;
        // gốc: undefined1 auVar8 [16];
        // gốc: lVar3 = thunk_FUN_01851e62(DAT_035670c0);
        // gốc: System_Object___ctor(lVar3,0);
        // → System_Object_.ctor(lVar3,0);
        // gốc: if (param_2 == 0) goto LAB_01c734d9;
        // gốc: if (*(long *)(param_2 + 0x10) == 0) {
        // gốc: return;
        // gốc: }
        // gốc: uVar6 = *(undefined8 *)(*(long *)(param_2 + 0x10) + 0x38);
        // gốc: if (*(int *)(DAT_03563280 + 0xe0) == 0) {
        // gốc: }
        // gốc: cVar2 = UnityEngine_Object__op_Equality(uVar6,0,0);
        // → cVar2 = UnityEngine_Object.op_Equality(uVar6,0,0);
        // gốc: if (cVar2 != '\0') {
        // gốc: return;
        // gốc: }
        // gốc: if (*(int *)(DAT_03563fb0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar4 = RepresentSetting__GetEffectResInfo(param_3 & 0xffffffff,0);
        // → lVar4 = RepresentSetting.GetEffectResInfo(param_3 & 0xffffffff,0);
        // gốc: if (lVar4 == 0) {
        // gốc: plVar5 = (long *)FUN_0185f8db(DAT_0355f128,1);
        // gốc: lVar3 = thunk_FUN_01851b32(DAT_035624b0);
        // gốc: if (plVar5 != (long *)0x0) {
        // gốc: if ((lVar3 != 0) &&
        // gốc: (lVar4 = thunk_FUN_01851d86(lVar3,*(undefined8 *)(*plVar5 + 0x40)), lVar4 == 0)) {
        // gốc: uVar6 = thunk_FUN_01868420();
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185f94e(uVar6,0);
        // gốc: }
        // gốc: if ((int)plVar5[3] != 0) {
        // gốc: plVar5[4] = lVar3;
        // gốc: if (*(int *)(DAT_03562a00 + 0xe0) == 0) {
        // gốc: }
        // gốc: LogHelper__ERROR(DAT_0359db98,DAT_035a46d8,plVar5,0);
        // → LogHelper.ERROR(DAT_0359db98,DAT_035a46d8,plVar5,0);
        // gốc: return;
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa47();
        // → throw new System.IndexOutOfRangeException();
        // gốc: }
        // gốc: goto LAB_01c734d9;
        // gốc: }
        // gốc: lVar4 = SkillAnimatorPool__Spawn(0);
        // → lVar4 = SkillAnimatorPool.Spawn(0);
        // gốc: if (lVar3 == 0) goto LAB_01c734d9;
        // gốc: *(long *)(lVar3 + 0x10) = lVar4;
        // gốc: if ((*(long *)(param_2 + 0x10) == 0) || (lVar4 == 0)) goto LAB_01c734d9;
        // gốc: plVar5 = *(long **)(*(long *)(param_2 + 0x10) + 0x38);
        // gốc: if (plVar5 == (long *)0x0) {
        // gốc: LAB_01c7322e:
        // gốc: plVar7 = (long *)0x0;
        // gốc: }
        // gốc: else {
        // gốc: if (*(byte *)(*plVar5 + 0x130) < *(byte *)(DAT_03564658 + 0x130)) goto LAB_01c7322e;
        // gốc: plVar7 = (long *)0x0;
        // gốc: if (*(long *)(*(long *)(*plVar5 + 200) + -8 + (ulong)*(byte *)(DAT_03564658 + 0x130) * 8) ==
        // gốc: DAT_03564658) {
        // gốc: plVar7 = plVar5;
        // gốc: }
        // gốc: }
        // gốc: SkillAnimator__SetAsset(lVar4,plVar7,param_2,0);
        // → SkillAnimator.SetAsset(lVar4,plVar7,param_2,0);
        // gốc: if (DAT_036b8a9d == '\0') {
        // gốc: FUN_0185f84b(&DAT_035658c8);
        // gốc: DAT_036b8a9d = '\x01';
        // gốc: }
        // gốc: if (*(long *)(lVar3 + 0x10) != 0) {
        // gốc: uVar1 = *(undefined4 *)(*(long *)(DAT_035658c8 + 0xb8) + 8);
        // gốc: lVar4 = UnityEngine_Component__get_transform(*(long *)(lVar3 + 0x10),0);
        // → lVar4 = UnityEngine_Component.get_transform(*(long *)(lVar3 + 0x10),0);
        // gốc: if (lVar4 != 0) {
        // gốc: UnityEngine_Transform__SetParent(lVar4,0,0);
        // → UnityEngine_Transform.SetParent(lVar4,0,0);
        // gốc: if ((*(long *)(lVar3 + 0x10) != 0) &&
        // gốc: (lVar4 = UnityEngine_Component__get_transform(*(long *)(lVar3 + 0x10),0), lVar4 != 0)) {
        // → (lVar4 = UnityEngine_Component.get_transform(*(long *)(lVar3 + 0x10),0), lVar4 != 0)) {
        // gốc: auVar8 = insertps(ZEXT416((uint)(param_3 >> 0x20)),param_1,0x10);
        // gốc: UnityEngine_Transform__set_position(auVar8._0_8_,uVar1,lVar4,0);
        // → UnityEngine_Transform.set_position(auVar8._0_8_,uVar1,lVar4,0);
        // gốc: uVar6 = *(undefined8 *)(lVar3 + 0x10);
        // gốc: if (*(int *)(DAT_03563280 + 0xe0) == 0) {
        // gốc: }
        // gốc: cVar2 = UnityEngine_Object__op_Inequality(uVar6,0,0);
        // → cVar2 = UnityEngine_Object.op_Inequality(uVar6,0,0);
        // gốc: if (cVar2 == '\0') {
        // gốc: return;
        // gốc: }
        // gốc: if (*(long *)(lVar3 + 0x10) != 0) {
        // gốc: SkillAnimator__SetSpeed(*(long *)(lVar3 + 0x10),0);
        // → SkillAnimator.SetSpeed(*(long *)(lVar3 + 0x10),0);
        // gốc: lVar4 = *(long *)(lVar3 + 0x10);
        // gốc: if (lVar4 != 0) {
        // gốc: *(undefined4 *)(lVar4 + 0x44) = 0;
        // gốc: *(undefined1 *)(lVar4 + 0x28) = 0;
        // gốc: uVar6 = *(undefined8 *)(lVar4 + 0x30);
        // gốc: if (*(int *)(DAT_03563280 + 0xe0) == 0) {
        // gốc: }
        // gốc: cVar2 = UnityEngine_Object__op_Inequality(uVar6,0,0);
        // → cVar2 = UnityEngine_Object.op_Inequality(uVar6,0,0);
        // gốc: if (cVar2 != '\0') {
        // gốc: if (*(long *)(lVar3 + 0x10) == 0) goto LAB_01c734d9;
        // gốc: lVar4 = *(long *)(*(long *)(lVar3 + 0x10) + 0x30);
        // gốc: if (*(int *)(DAT_03561680 + 0xe0) == 0) {
        // gốc: }
        // gốc: if (lVar4 == 0) goto LAB_01c734d9;
        // gốc: UnityEngine_Renderer__set_sortingLayerID
        // gốc: (lVar4,*(undefined4 *)(*(long *)(DAT_03561680 + 0xb8) + 8),0);
        // gốc: }
        // gốc: lVar4 = *(long *)(lVar3 + 0x10);
        // gốc: uVar6 = thunk_FUN_01851e62(DAT_0355f788);
        // gốc: System_Action___ctor(uVar6,lVar3,DAT_03591330,0);
        // → System_Action_.ctor(uVar6,lVar3,DAT_03591330,0);
        // gốc: if (lVar4 != 0) {
        // gốc: *(undefined8 *)(lVar4 + 0x50) = uVar6;
        // gốc: if ((*(long *)(lVar3 + 0x10) != 0) &&
        // gốc: (lVar3 = UnityEngine_Component__get_gameObject(*(long *)(lVar3 + 0x10),0),
        // → (lVar3 = UnityEngine_Component.get_gameObject(*(long *)(lVar3 + 0x10),0),
        // gốc: lVar3 != 0)) {
        // gốc: UnityEngine_GameObject__SetActive(lVar3,1,0);
        // → UnityEngine_GameObject.SetActive(lVar3,1,0);
        // gốc: return;
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: LAB_01c734d9:
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
    }

}
