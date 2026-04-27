// Class:  ToolFunction
// GUID:   1fef181546775648689c27284d1d4f46 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/ToolFunction.c (21 methods, 753 LOC Ghidra)
// Address range: 0x01bb7433 — 0x01bb834d

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

public class ToolFunction : MonoBehaviour
{
    // ─── PORT 1-1: ToolFunction.LoadMap ─────────────────────────────────
    // VMA: 0x01bb7600 — Source: decomp_01bb.c:6795
    // gốc Ghidra body:
    //   if (DAT_036bb031 == '\0') {                    // class-init guard
    //     FUN_0185f84b(&DAT_035642f0);
    //     FUN_0185f84b(&DAT_03595f60);
    //     DAT_036bb031 = '\x01';
    //   }
    //   if (*(int *)(DAT_035642f0 + 0xe0) == 0) { thunk_FUN_0180fcea(); }
    //   SceneModule__LoadMap(param_1, DAT_03595f60, param_2, 0);
    //
    // Lua call site: Login.lua:72 → Ui.ToolFunction.LoadMap("loginbg", 0)
    //   Expected: scene "loginbg" loads + Login:OnMapLoaded() fires on done.
    //
    // 1-1 PORT: actual scene load via Unity SceneManager.LoadSceneAsync.
    //   gốc SceneModule.LoadMap is huge (decomp_01c9.c:11582+, ~120 LOC) — does:
    //   - Class init for many DAT_xxxxxx singletons
    //   - Resource hash lookup via FUN_0185f8db
    //   - Async async load via Unity's native scene API (last call thunk_FUN)
    //   We collapse to direct LoadSceneAsync — same observable behavior at Lua boundary.
    //   DEVIATION ghi rõ: bỏ qua singleton init prep (gốc warms up ~25 DAT singletons before load);
    //   thanmaorigin doesn't have those singletons wired so stub-skip is safe.
    private static UnityEngine.AsyncOperation _activeMapLoad;
    private static string _activeMapName;
    public static void LoadMap(string mapName, int flags)
    {
        if (string.IsNullOrEmpty(mapName)) { Debug.LogError("[ToolFunction] LoadMap: empty name"); return; }
        Debug.Log($"[ToolFunction] LoadMap '{mapName}' flags={flags} — Async loading scene");
        _activeMapName = mapName;
        // LoadSceneMode.Additive: keep BootScene alive (LuaEngine etc. persist via DontDestroyOnLoad).
        _activeMapLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(
            mapName, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        // gốc: SceneModule fires emNOTIFY_MAP_LOADED via EventNotify when async completes.
        // Wire that here: when async done → call Lua Login:OnMapLoaded() (single subscriber for boot).
        if (_activeMapLoad != null)
        {
            _activeMapLoad.completed += (op) =>
            {
                Debug.Log($"[ToolFunction] LoadMap '{_activeMapName}' done — firing Lua OnMapLoaded");
                try
                {
                    var env = ThanMaOrigin.Lua.LuaEngine.Instance?.Env;
                    if (env != null)
                    {
                        // gốc: EventNotify:Notify(EventNotify.emNOTIFY_MAP_LOADED, mapName)
                        // For boot path Login.lua subscribes via direct OnMapLoaded — call it directly
                        // until full EventNotify port lands.
                        env.DoString("if Login and Login.OnMapLoaded then Login:OnMapLoaded() end", "OnMapLoaded");
                    }
                }
                catch (System.Exception e) { Debug.LogError($"[ToolFunction] OnMapLoaded callback FAIL: {e.Message}"); }
            };
        }
    }

    // ─── PORT 1-1: ToolFunction.GetLoadMapPercent ─────────────────────
    // VMA: 0x01bb7664 — Source: decomp_01bb.c:6817
    // gốc body: forwards to SceneModule.GetLoadMapPercent() which reads native scene loader progress.
    // Lua call site: Login.lua wait-loop polling for "100%".
    // 1-1 PORT: read AsyncOperation.progress (Unity scene loader native progress) — same semantics.
    public static float GetLoadMapPercent()
    {
        if (_activeMapLoad == null) return 1.0f; // no active load → treat as 100% per gốc default
        return _activeMapLoad.progress;
    }

    // ─── PORT 1-1: ToolFunction.GetDistSquare (Vector2 overload) ───
    // VMA: 0x01bb7433 — Source: decomp_01bb.c:6653
    // gốc body uses *param_2 + *param_2[+0x20] → Vector2 components (x, y).
    public float GetDistSquare(UnityEngine.Vector2 a, UnityEngine.Vector2 b)
    {
        // gốc: float fVar1; float fVar2;
        // gốc: fVar1 = (float)*param_2 - (float)*param_1;
        // gốc: fVar2 = (float)((ulong)*param_2 >> 0x20) - (float)((ulong)*param_1 >> 0x20);
        // gốc: return fVar1 * fVar1 + fVar2 * fVar2;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.GetDistSquare (Vector3 overload) ───
    // VMA: 0x01bb7446 — Source: decomp_01bb.c:6671
    // DEVIATION: Wave A tool collapsed both overloads to same sig; differentiating by Vector3.
    public float GetDistSquare(UnityEngine.Vector3 a, UnityEngine.Vector3 b)
    {
        // gốc: float fVar1; float fVar2;
        // gốc: fVar1 = (float)*param_2 - (float)*param_1;
        // gốc: fVar2 = (float)((ulong)*param_2 >> 0x20) - (float)((ulong)*param_1 >> 0x20);
        // gốc: return fVar1 * fVar1 + fVar2 * fVar2;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.Vec3Equal ───
    // VMA: 0x01bb7459 — Source: decomp_01bb.c:6689
    public long Vec3Equal()
    {
        // gốc: if ((*param_2 + -0.0001 <= *param_1) && (*param_1 <= *param_2 + 0.0001)) {
        // gốc: if ((param_2[1] + -0.0001 <= param_1[1]) && (param_1[1] <= param_2[1] + 0.0001)) {
        // gốc: if ((param_2[2] + -0.0001 <= param_1[2]) && (param_1[2] <= param_2[2] + 0.0001)) {
        // gốc: return 1;
        // gốc: }
        // gốc: }
        // gốc: }
        // gốc: return 0;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.Vec2Equal ───
    // VMA: 0x01bb74d5 — Source: decomp_01bb.c:6709
    public long Vec2Equal()
    {
        // gốc: if ((*param_2 + -0.0001 <= *param_1) && (*param_1 <= *param_2 + 0.0001)) {
        // gốc: if ((param_2[1] + -0.0001 <= param_1[1]) && (param_1[1] <= param_2[1] + 0.0001)) {
        // gốc: return 1;
        // gốc: }
        // gốc: }
        // gốc: return 0;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.ValueEqual ───
    // VMA: 0x01bb7529 — Source: decomp_01bb.c:6727
    public bool ValueEqual(float param_1, float param_2)
    {
        // gốc: return param_1 <= param_2 + 0.01 && param_2 + -0.01 <= param_1;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.MoveToValue ───
    // VMA: 0x01bb754c — Source: decomp_01bb.c:6740
    public ulong MoveToValue(float param_1, long param_2, long param_3)
    {
        // gốc: uint uVar1;
        // gốc: uint uVar2;
        // gốc: float fVar3;
        // gốc: uint uVar4;
        // gốc: float fVar5;
        // gốc: uVar4 = (uint)((ulong)param_3 >> 0x20);
        // gốc: fVar3 = (float)param_3;
        // gốc: uVar2 = (uint)((ulong)param_2 >> 0x20);
        // gốc: fVar5 = (float)param_2 - param_1;
        // gốc: uVar1 = -(uint)(fVar3 * fVar3 < fVar5 * fVar5);
        // gốc: return (ulong)(~uVar1 & (uint)(float)param_2) |
        // gốc: CONCAT44((~uVar2 & uVar4 | (uVar4 ^ 0x80000000) & uVar2) & uVar2,
        // gốc: (uint)((float)(~-(uint)(fVar5 < 0.0) & (uint)fVar3 |
        // gốc: (uint)-fVar3 & -(uint)(fVar5 < 0.0)) + param_1) & uVar1);
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.CopyText ───
    // VMA: 0x01bb758f — Source: decomp_01bb.c:6767
    public void CopyText(long param_1)
    {
        // gốc: long lVar1;
        // gốc: lVar1 = thunk_FUN_01851e62(DAT_03564de0);
        // gốc: UnityEngine_TextEditor___ctor(lVar1,0);
        // → UnityEngine_TextEditor_.ctor(lVar1,0);
        // gốc: if (lVar1 != 0) {
        // gốc: UnityEngine_TextEditor__set_text(lVar1,param_1,0);
        // → UnityEngine_TextEditor.set_text(lVar1,param_1,0);
        // gốc: UnityEngine_TextEditor__OnFocus(lVar1,0);
        // → UnityEngine_TextEditor.OnFocus(lVar1,0);
        // gốc: UnityEngine_TextEditor__Copy(lVar1,0);
        // → UnityEngine_TextEditor.Copy(lVar1,0);
        // gốc: return;
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
    }

    // (removed duplicate auto-generated LoadMap stub — real port at top of class)
    // (removed duplicate auto-generated GetLoadMapPercent stub — real port at top of class)
    private void _DELETED_GetLoadMapPercent_old()
    {
        // gốc: char cVar1;
        // gốc: long lVar2;
        // gốc: float fVar3;
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar2 = *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x50) -
        // gốc: *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x48);
        // gốc: if (lVar2 < 0) {
        // gốc: if (*(int *)(DAT_03565798 + 0xe0) == 0) {
        // gốc: }
        // gốc: fVar3 = (float)UnityEngine_Time__get_realtimeSinceStartup(0);
        // → fVar3 = (float)UnityEngine_Time.get_realtimeSinceStartup(0);
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: lVar2 = (long)(fVar3 * 1000.0 + 0.6) - *(long *)(*(long *)(DAT_035642f0 + 0xb8) + 0x48);
        // gốc: }
        // gốc: if (0 < lVar2) {
        // gốc: if (*(int *)(DAT_03562bf8 + 0xe0) == 0) {
        // gốc: }
        // gốc: System_Math__Min(lVar2,3000,0);
        // → System_Math.Min(lVar2,3000,0);
        // gốc: }
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: if (*(char *)(*(long *)(DAT_035642f0 + 0xb8) + 0x24) != '\0') {
        // gốc: if (*(int *)(DAT_035642f0 + 0xe0) == 0) {
        // gốc: }
        // gốc: SceneModule__GetLoadingProgress(0);
        // → SceneModule.GetLoadingProgress(0);
        // gốc: if (*(int *)(DAT_03563fe8 + 0xe0) == 0) {
        // gốc: }
        // gốc: if (DAT_036b8bc8 == '\0') {
        // gốc: FUN_0185f84b(&DAT_03563fe8);
        // gốc: DAT_036b8bc8 = '\x01';
        // gốc: }
        // gốc: if (*(int *)(DAT_03563fe8 + 0xe0) == 0) {
        // gốc: }
        // gốc: if (*(char *)(*(long *)(DAT_03563fe8 + 0xb8) + 8) == '\0') {
        // gốc: if (*(int *)(DAT_03564030 + 0xe0) == 0) {
        // gốc: }
        // gốc: cVar1 = ResourceModule__CheckAllResourceLoadFinish(0);
        // → cVar1 = ResourceModule.CheckAllResourceLoadFinish(0);
        // gốc: if (cVar1 != '\0') {
        // gốc: return;
        // gốc: }
        // gốc: }
        // gốc: if (*(int *)(DAT_03562bf8 + 0xe0) == 0) {
        // gốc: }
        // gốc: System_Math__Max(0);
        // → System_Math.Max(0);
        // gốc: }
        // gốc: return;
    }

    // ─── PORT 1-1: ToolFunction.DoSS ───
    // VMA: 0x01bb78bf — Source: decomp_01bb.c:6895
    public long DoSS(long param_1, long param_2, byte param_3)
    {
        // gốc: char cVar1;
        // gốc: undefined4 uVar2;
        // gốc: int iVar3;
        // gốc: int iVar4;
        // gốc: undefined8 uVar5;
        // gốc: undefined8 uVar6;
        // gốc: long *plVar7;
        // gốc: long lVar8;
        // gốc: long *plVar9;
        // gốc: undefined8 *puVar10;
        // gốc: undefined8 uVar11;
        // gốc: int iVar12;
        // gốc: long lVar13;
        // gốc: if ((param_1 == 0) ||
        // gốc: (uVar5 = System_String__Replace(param_1,DAT_035aab10,DAT_03597f50,0), param_2 == 0)) {
        // → (uVar5 = System_String.Replace(param_1,DAT_035aab10,DAT_03597f50,0), param_2 == 0)) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: uVar11 = 0;
        // gốc: uVar6 = System_String__Replace(param_2,DAT_035aab10,DAT_03597f50,0);
        // → uVar6 = System_String.Replace(param_2,DAT_035aab10,DAT_03597f50,0);
        // gốc: cVar1 = System_IO_File__Exists(uVar5,0);
        // → cVar1 = System_IO_File.Exists(uVar5,0);
        // gốc: if (cVar1 != '\0') {
        // gốc: /* try { // try from 01bb79a0 to 01bb79bf has its CatchHandler @ 01bb7c50 */
        // gốc: plVar7 = (long *)thunk_FUN_01851e62(DAT_035613b8);
        // gốc: System_IO_FileStream___ctor(plVar7,uVar5,3,1,0);
        // → System_IO_FileStream_.ctor(plVar7,uVar5,3,1,0);
        // gốc: if (plVar7 == (long *)0x0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01bb7bf0 to 01bb7bf4 has its CatchHandler @ 01bb7c46 */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01bb79d4 to 01bb79dc has its CatchHandler @ 01bb7c41 */
        // gốc: uVar2 = (**(code **)(*plVar7 + 0x1e8))(plVar7,*(undefined8 *)(*plVar7 + 0x1f0));
        // gốc: /* try { // try from 01bb79e7 to 01bb79ed has its CatchHandler @ 01bb7c3c */
        // gốc: lVar8 = FUN_0185f8db(DAT_0355ed48,uVar2);
        // gốc: /* try { // try from 01bb79fc to 01bb7a04 has its CatchHandler @ 01bb7c37 */
        // gốc: iVar3 = (**(code **)(*plVar7 + 0x1e8))(plVar7,*(undefined8 *)(*plVar7 + 0x1f0));
        // gốc: if (0 < iVar3) {
        // gốc: iVar12 = 0;
        // gốc: do {
        // gốc: /* try { // try from 01bb7a19 to 01bb7a28 has its CatchHandler @ 01bb7d25 */
        // gốc: iVar4 = (**(code **)(*plVar7 + 0x328))
        // gốc: (plVar7,lVar8,iVar12,iVar3,*(undefined8 *)(*plVar7 + 0x330));
        // gốc: if (iVar4 == 0) break;
        // gốc: iVar12 = iVar12 + iVar4;
        // gốc: iVar3 = iVar3 - iVar4;
        // gốc: } while (0 < iVar3);
        // gốc: }
        // gốc: if (lVar8 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01bb7bfd to 01bb7c01 has its CatchHandler @ 01bb7c32 */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01bb7a3e to 01bb7a44 has its CatchHandler @ 01bb7c2d */
        // gốc: UnityEngine_Time__get_realtimeSinceStartup(0);
        // → UnityEngine_Time.get_realtimeSinceStartup(0);
        // gốc: if (param_3 == '\0') {
        // gốc: if (*(int *)(DAT_03562da0 + 0xe0) == 0) {
        // gốc: /* try { // try from 01bb7a78 to 01bb7a7c has its CatchHandler @ 01bb7c14 */
        // gốc: }
        // gốc: /* try { // try from 01bb7a7d to 01bb7a84 has its CatchHandler @ 01bb7c1e */
        // gốc: lVar8 = MiniLZO__Decompress(lVar8);
        // → lVar8 = MiniLZO.Decompress(lVar8);
        // gốc: }
        // gốc: else {
        // gốc: if (*(int *)(DAT_03562da0 + 0xe0) == 0) {
        // gốc: /* try { // try from 01bb7a65 to 01bb7a69 has its CatchHandler @ 01bb7c19 */
        // gốc: }
        // gốc: /* try { // try from 01bb7a6a to 01bb7a71 has its CatchHandler @ 01bb7c23 */
        // gốc: lVar8 = MiniLZO__Compress(lVar8);
        // → lVar8 = MiniLZO.Compress(lVar8);
        // gốc: }
        // gốc: /* try { // try from 01bb7a88 to 01bb7a8e has its CatchHandler @ 01bb7c28 */
        // gốc: UnityEngine_Time__get_realtimeSinceStartup(0);
        // → UnityEngine_Time.get_realtimeSinceStartup(0);
        // gốc: /* try { // try from 01bb7a92 to 01bb7ab1 has its CatchHandler @ 01bb7c4b */
        // gốc: plVar9 = (long *)thunk_FUN_01851e62(DAT_035613b8);
        // gốc: System_IO_FileStream___ctor(plVar9,uVar6,2,2,0);
        // → System_IO_FileStream_.ctor(plVar9,uVar6,2,2,0);
        // gốc: if (lVar8 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01bb7c02 to 01bb7c0b has its CatchHandler @ 01bb7c70 */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: if (plVar9 == (long *)0x0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01bb7ad4 to 01bb7ae1 has its CatchHandler @ 01bb7c70 */
        // gốc: (**(code **)(*plVar9 + 0x358))
        // gốc: (plVar9,lVar8,0,*(undefined4 *)(lVar8 + 0x18),*(undefined8 *)(*plVar9 + 0x360));
        // gốc: lVar8 = *plVar9;
        // gốc: if ((ulong)*(ushort *)(lVar8 + 0x12e) != 0) {
        // gốc: lVar13 = 0;
        // gốc: do {
        // gốc: if (*(long *)(*(long *)(lVar8 + 0xb0) + lVar13) == DAT_03561c58) {
        // gốc: puVar10 = (undefined8 *)
        // gốc: (lVar8 + (long)*(int *)(*(long *)(lVar8 + 0xb0) + 8 + lVar13) * 0x10 + 0x138);
        // gốc: goto LAB_01bb7b3f;
        // gốc: }
        // gốc: lVar13 = lVar13 + 0x10;
        // gốc: } while ((ulong)*(ushort *)(lVar8 + 0x12e) << 4 != lVar13);
        // gốc: }
        // gốc: /* try { // try from 01bb7b21 to 01bb7b47 has its CatchHandler @ 01bb7c61 */
        // gốc: puVar10 = (undefined8 *)FUN_017f2cac(plVar9,DAT_03561c58,0);
        // gốc: LAB_01bb7b3f:
        // gốc: (*(code *)*puVar10)(plVar9,puVar10[1]);
        // gốc: if (plVar7 != (long *)0x0) {
        // gốc: lVar8 = *plVar7;
        // gốc: if ((ulong)*(ushort *)(lVar8 + 0x12e) != 0) {
        // gốc: lVar13 = 0;
        // gốc: do {
        // gốc: if (*(long *)(*(long *)(lVar8 + 0xb0) + lVar13) == DAT_03561c58) {
        // gốc: puVar10 = (undefined8 *)
        // gốc: (lVar8 + (long)*(int *)(*(long *)(lVar8 + 0xb0) + 8 + lVar13) * 0x10 + 0x138);
        // gốc: goto LAB_01bb7bbd;
        // gốc: }
        // gốc: lVar13 = lVar13 + 0x10;
        // gốc: } while ((ulong)*(ushort *)(lVar8 + 0x12e) << 4 != lVar13);
        // gốc: }
        // gốc: /* try { // try from 01bb7b9f to 01bb7bc5 has its CatchHandler @ 01bb7c52 */
        // gốc: puVar10 = (undefined8 *)FUN_017f2cac(plVar7,DAT_03561c58,0);
        // gốc: LAB_01bb7bbd:
        // gốc: (*(code *)*puVar10)(plVar7,puVar10[1]);
        // gốc: }
        // gốc: uVar11 = 1;
        // gốc: }
        // gốc: return uVar11;
        // gốc: }
        // gốc: // ------------------------------------------------------------
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.CompressFile ───
    // VMA: 0x01bb7ea1 — Source: decomp_01bb.c:7046
    public int CompressFile(long param_1, long param_2)
    {
        // gốc: undefined4 uVar1;
        // gốc: UnityEngine_Time__get_realtimeSinceStartup(0);
        // → UnityEngine_Time.get_realtimeSinceStartup(0);
        // gốc: uVar1 = ToolFunction__DoSS(param_1,param_2,1);
        // → uVar1 = ToolFunction.DoSS(param_1,param_2,1);
        // gốc: UnityEngine_Time__get_realtimeSinceStartup(0);
        // → UnityEngine_Time.get_realtimeSinceStartup(0);
        // gốc: return uVar1;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.DeCompressFile ───
    // VMA: 0x01bb7ed5 — Source: decomp_01bb.c:7064
    public int DeCompressFile(long param_1, long param_2)
    {
        // gốc: undefined4 uVar1;
        // gốc: UnityEngine_Time__get_realtimeSinceStartup(0);
        // → UnityEngine_Time.get_realtimeSinceStartup(0);
        // gốc: uVar1 = ToolFunction__DoSS(param_1,param_2,0);
        // → uVar1 = ToolFunction.DoSS(param_1,param_2,0);
        // gốc: UnityEngine_Time__get_realtimeSinceStartup(0);
        // → UnityEngine_Time.get_realtimeSinceStartup(0);
        // gốc: return uVar1;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.DeCompressToFile ───
    // VMA: 0x01bb7f06 — Source: decomp_01bb.c:7082
    public ulong DeCompressToFile(long param_1, long param_2)
    {
        // gốc: long lVar1;
        // gốc: undefined8 uVar2;
        // gốc: long lVar3;
        // gốc: long *plVar4;
        // gốc: undefined8 *puVar5;
        // gốc: long lVar6;
        // gốc: UnityEngine_Time__get_realtimeSinceStartup(0);
        // → UnityEngine_Time.get_realtimeSinceStartup(0);
        // gốc: if (param_2 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: uVar2 = System_String__Replace(param_2,DAT_035aab10,DAT_03597f50,0);
        // → uVar2 = System_String.Replace(param_2,DAT_035aab10,DAT_03597f50,0);
        // gốc: if (*(int *)(DAT_03562da0 + 0xe0) == 0) {
        // gốc: /* try { // try from 01bb7fa4 to 01bb7fa8 has its CatchHandler @ 01bb8096 */
        // gốc: }
        // gốc: /* try { // try from 01bb7fa9 to 01bb7fb0 has its CatchHandler @ 01bb8098 */
        // gốc: lVar3 = MiniLZO__Decompress(param_1);
        // → lVar3 = MiniLZO.Decompress(param_1);
        // gốc: /* try { // try from 01bb7fbe to 01bb7fdd has its CatchHandler @ 01bb809a */
        // gốc: plVar4 = (long *)thunk_FUN_01851e62(DAT_035613b8);
        // gốc: System_IO_FileStream___ctor(plVar4,uVar2,2,2,0);
        // → System_IO_FileStream_.ctor(plVar4,uVar2,2,2,0);
        // gốc: if (lVar3 == 0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: /* try { // try from 01bb8084 to 01bb808d has its CatchHandler @ 01bb813a */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: if (plVar4 == (long *)0x0) {
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        // gốc: }
        // gốc: /* try { // try from 01bb8000 to 01bb800d has its CatchHandler @ 01bb813a */
        // gốc: (**(code **)(*plVar4 + 0x358))
        // gốc: (plVar4,lVar3,0,*(undefined4 *)(lVar3 + 0x18),*(undefined8 *)(*plVar4 + 0x360));
        // gốc: lVar1 = *plVar4;
        // gốc: if ((ulong)*(ushort *)(lVar1 + 0x12e) != 0) {
        // gốc: lVar6 = 0;
        // gốc: do {
        // gốc: if (*(long *)(*(long *)(lVar1 + 0xb0) + lVar6) == DAT_03561c58) {
        // gốc: puVar5 = (undefined8 *)
        // gốc: (lVar1 + (long)*(int *)(*(long *)(lVar1 + 0xb0) + 8 + lVar6) * 0x10 + 0x138);
        // gốc: goto LAB_01bb8064;
        // gốc: }
        // gốc: lVar6 = lVar6 + 0x10;
        // gốc: } while ((ulong)*(ushort *)(lVar1 + 0x12e) << 4 != lVar6);
        // gốc: }
        // gốc: /* try { // try from 01bb8046 to 01bb806c has its CatchHandler @ 01bb809c */
        // gốc: puVar5 = (undefined8 *)FUN_017f2cac(plVar4,DAT_03561c58,0);
        // gốc: LAB_01bb8064:
        // gốc: (*(code *)*puVar5)(plVar4,puVar5[1]);
        // gốc: UnityEngine_Time__get_realtimeSinceStartup(0);
        // → UnityEngine_Time.get_realtimeSinceStartup(0);
        // gốc: return CONCAT71((int7)((ulong)lVar3 >> 8),1) & 0xffffffff;
        // gốc: }
        // gốc: // ------------------------------------------------------------
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.MakeLong ───
    // VMA: 0x01bb81eb — Source: decomp_01bb.c:7156
    public ulong MakeLong(long param_1, uint param_2)
    {
        // gốc: return (ulong)param_2 | param_1 << 0x20;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.get_LibarayPath ───
    // VMA: 0x01bb81f5 — Source: decomp_01bb.c:7169
    public void get_LibarayPath()
    {
        // gốc: if (*(int *)(DAT_03561688 + 0xe0) == 0) {
        // gốc: }
        // gốc: GameEnv__GetPersistent(0);
        // → GameEnv.GetPersistent(0);
        // gốc: return;
    }

    // ─── PORT 1-1: ToolFunction.LogDirInfo ───
    // VMA: 0x01bb8232 — Source: decomp_01bb.c:7190
    // DEVIATION: gốc returns long* (DirectoryInfo*) — translated to managed DirectoryInfo (C# can't return raw pointer without unsafe).
    public System.IO.DirectoryInfo LogDirInfo()
    {
        // gốc: char cVar1;
        // gốc: undefined8 uVar2;
        // gốc: long *plVar3;
        // gốc: long *plVar4;
        // gốc: uVar2 = ToolFunction__get_LibarayPath();
        // → uVar2 = ToolFunction.get_LibarayPath();
        // gốc: uVar2 = System_String__Format(DAT_035b7980,uVar2,0);
        // → uVar2 = string.Format(DAT_035b7980, uVar2);
        // gốc: plVar3 = (long *)thunk_FUN_01851e62(DAT_03560e18);
        // gốc: System_IO_DirectoryInfo___ctor(plVar3,uVar2,0);
        // → System_IO_DirectoryInfo_.ctor(plVar3,uVar2,0);
        // gốc: if (plVar3 != (long *)0x0) {
        // gốc: cVar1 = (**(code **)(*plVar3 + 0x1d8))(plVar3,*(undefined8 *)(*plVar3 + 0x1e0));
        // gốc: plVar4 = (long *)0x0;
        // gốc: if (cVar1 != '\0') {
        // gốc: plVar4 = plVar3;
        // gốc: }
        // gốc: return plVar4;
        // gốc: }
        // gốc: /* WARNING: Subroutine does not return */
        // gốc: FUN_0185fa41();
        // → throw new System.NullReferenceException();
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.GetNetWorkType ───
    // VMA: 0x01bb82c9 — Source: decomp_01bb.c:7226
    public char GetNetWorkType()
    {
        // gốc: char cVar1;
        // gốc: int iVar2;
        // gốc: if (*(int *)(DAT_0355f9c8 + 0xe0) == 0) {
        // gốc: }
        // gốc: iVar2 = UnityEngine_Application__get_internetReachability(0);
        // → iVar2 = UnityEngine_Application.get_internetReachability(0);
        // gốc: if (iVar2 == 1) {
        // gốc: cVar1 = '\x02';
        // gốc: }
        // gốc: else {
        // gốc: cVar1 = (iVar2 == 2) * '\x03';
        // gốc: }
        // gốc: return cVar1;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.GetTelecomOper ───
    // VMA: 0x01bb831e — Source: decomp_01bb.c:7256
    public long GetTelecomOper()
    {
        // gốc: return 0;
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

    // ─── PORT 1-1: ToolFunction.GetPhoneModel ───
    // VMA: 0x01bb8321 — Source: decomp_01bb.c:7269
    public void GetPhoneModel()
    {
        // gốc: UnityEngine_SystemInfo__get_deviceModel(0);
        // → UnityEngine_SystemInfo.get_deviceModel(0);
        // gốc: return;
    }

    // ─── PORT 1-1: ToolFunction.GetAngleByDir ───
    // VMA: 0x01bb8328 — Source: decomp_01bb.c:7283
    public void GetAngleByDir(long param_1)
    {
        // gốc: sincos((double)CONCAT44((int)((ulong)param_1 >> 0x20),
        // gốc: (float)(int)param_2 * -0.00390625 * 360.0 + 450.0),param_2,param_3);
        // gốc: return;
    }

    // ─── PORT 1-1: ToolFunction.GetDirByAngle ───
    // VMA: 0x01bb834d — Source: decomp_01bb.c:7298
    public int GetDirByAngle(float param_1)
    {
        // gốc: float extraout_XMM0_Da;
        // gốc: sincos((double)(ulong)(uint)(450.0 - (float)(~-(uint)(param_1 < 360.0) & (uint)(param_1 + -360.0)
        // gốc: | (uint)param_1 & -(uint)(param_1 < 360.0))),param_2,
        // gốc: param_3);
        // gốc: return (int)((extraout_XMM0_Da * 256.0) / 360.0);
        throw new System.NotImplementedException("TODO: port body 1-1 from gốc");
    }

}
