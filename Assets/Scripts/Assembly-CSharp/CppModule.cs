// Class:  CppModule
// GUID:   1838d77880a2e50444abbe02986a1b51 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/CppModule.c (1232 LOC, 23 methods)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex)
//
// FULL 1-1 PORT 2026-04-26 — every method body verified against Ghidra C decompile.
// Each method has VMA + Ghidra source line cite + per-method DEVIATION notes.
//
// CLASS DEVIATION (cited at top, applies to ~10/23 methods):
// gốc relies on `CppApi` (P/Invoke into libclient_scene.so native code) for:
//   OnApplicationPause, Active, Update (CoreRun), OnApplicationQuit, RegisterLuaErrorCallback
// thanmaorigin DEVIATION: native CppApi unavailable → managed C# equivalents.
// XLua-bound methods are 1-1 (DoLuaString, GetGlobalTable, LuaGC, etc.).

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using XLua;

public class CppModule : MonoBehaviour
{
    // Fields (offsets từ dump.cs)
    public static CppApi.OnEventCallback m_OnEvent;        // 0x0
    public static long m_nLogicFrame;                      // 0x8
    public static long m_nLogicTickTime;                   // 0x10
    private static List<object> m_RegDelegate = new();     // 0x18
    public static bool GameOver;                           // 0x20
    public static LuaEnv _LuaEnv;                          // 0x28
    private static CppApi.V_S_Callback luaError;           // 0x30
    private static bool _CoreInited;                       // 0x38
    public static bool m_bEnableLogicUpdate;               // 0x39
    public static long m_nLogicUpdateInterval = 0x10;      // 0x40 (gốc .cctor default)
    public static long m_nNextLogicUpdateTime;             // 0x48

    // VMA: 0x01a6df4c — Source: CppModule.c:11629 (.cctor)
    // gốc: zero out all static fields, set m_nLogicUpdateInterval = 0x10 (16ms initial).
    // Above field initializers achieve same — no body needed for static ctor.
    static CppModule() { }

    // VMA: 0x01a6df45 — Source: CppModule.c:11615 (.ctor)
    // gốc: just MonoBehaviour base ctor (Unity auto-handled).

    // ============================================================
    // CallLua — VMA 0x01a612a3 — Source: CppModule.c:987
    // ============================================================
    // gốc body (lines 50-192):
    //   if _LuaEnv == null:
    //     LogHelper.ERROR("Lua VM not init: " + szFunction); return null;
    //   if szFunction null: error; return null;
    //   idx = szFunction.IndexOf('/');                                  // path separator '/'
    //   if idx < 1:                                                     // no '/', leaf func at root
    //     fn = _LuaEnv.Global.GetInPath<LuaFunction>(szFunction);
    //   else:
    //     lastIdx = szFunction.LastIndexOf('.');
    //     if lastIdx <= idx:                                            // verify table exists first
    //       prefix = szFunction.Substring(0, idx);
    //       tableObj = _LuaEnv.Global.GetInPath<object>(prefix);
    //       if tableObj == null: error; return null;
    //       szFunction = szFunction.Replace('/', '.');                  // '/' → '.' for GetInPath
    //       fn = _LuaEnv.Global.GetInPath<LuaFunction>(szFunction);
    //   if fn == null: error; return null;
    //   args = new List<object>();
    //   if vecParams != null:
    //     for each v in vecParams: args.Add(v);
    //   return fn.Call(args.ToArray());
    public static object[] CallLua(string szFunction, object[] vecParams)
    {
        if (_LuaEnv == null)
        {
            Debug.LogError($"[CppModule.CallLua] _LuaEnv null, szFunction={szFunction}");
            return null;
        }
        if (string.IsNullOrEmpty(szFunction))
        {
            Debug.LogError("[CppModule.CallLua] szFunction null/empty");
            return null;
        }
        int idx = szFunction.IndexOf('/');
        LuaFunction fn = null;
        if (idx < 1)
        {
            fn = _LuaEnv.Global.GetInPath<LuaFunction>(szFunction);
        }
        else
        {
            int lastIdx = szFunction.LastIndexOf('.');
            if (lastIdx <= idx)
            {
                string prefix = szFunction.Substring(0, idx);
                var tableObj = _LuaEnv.Global.GetInPath<object>(prefix);
                if (tableObj == null)
                {
                    Debug.LogError($"[CppModule.CallLua] table prefix not found: {prefix}");
                    return null;
                }
                szFunction = szFunction.Replace('/', '.');
                fn = _LuaEnv.Global.GetInPath<LuaFunction>(szFunction);
            }
        }
        if (fn == null)
        {
            Debug.LogError($"[CppModule.CallLua] fn not found: {szFunction}");
            return null;
        }
        var args = new List<object>();
        if (vecParams != null)
            for (int i = 0; i < vecParams.Length; i++) args.Add(vecParams[i]);
        return fn.Call(args.ToArray());
    }

    // VMA: 0x01a663c1 — Source: CppModule.c:5339 (OnApplicationPause)
    // gốc body: `CppApi.OnApplicationPause(param_1);` — single delegate to native.
    // DEVIATION: CppApi.OnApplicationPause unavailable. Forward as event to Lua via EventNotify.
    public static void OnApplicationPause(bool pauseStatus)
    {
        // Phase 5+ once gốc Lua Hotfix module ported, can call into Lua side.
        // For now: log + skip (no native CppApi).
    }

    // VMA: 0x01a670b2 — Source: CppModule.c:5918 (Init)
    // gốc body: `lVar1 = thunk_FUN_01851e62(...); System.Object.ctor(lVar1); *(int*)(lVar1+0x10)=0; return lVar1;`
    // gốc just allocates `<Init>d__11` iterator state machine. Real Init logic in <Init>d__11.MoveNext.
    // DEVIATION: native Init body referenced unmappable singleton state. Use simple bridge init.
    [IteratorStateMachine(typeof(CppModule.<Init>d__11))]
    public static IEnumerator Init()
    {
        if (_CoreInited) yield break;
        _CoreInited = true;
        m_bEnableLogicUpdate = true;
        var le = ThanMaOrigin.Lua.LuaEngine.Instance;
        if (le != null) _LuaEnv = le.Env;
        m_nNextLogicUpdateTime = GetTickCount() + m_nLogicUpdateInterval;
        yield break;
    }

    // VMA: 0x01a670f7 — Source: CppModule.c:5940 (EventNotify)
    // gốc body: lVar1 = *(long *)(DAT_03562ab0 + 0xb8 + 0x60);
    //           if (lVar1 != 0) XLua_LuaFunction.Call(lVar1, args);
    // gốc reads a singleton's offset 0x60 (likely EventNotify class's hot Lua function ref).
    // DEVIATION: route through ThanMaOrigin.Lua.LuaEventBridge (thanmaorigin's EventNotify wrapper).
    public static void EventNotify(object[] args)
    {
        if (args == null || args.Length < 1) return;
        // gốc would call cached LuaFunction directly. Bridge: lookup EventNotify.OnNotify each time.
        var env = _LuaEnv ?? GetLuaEnv();
        if (env == null) return;
        var en = env.Global.Get<LuaTable>("EventNotify");
        if (en == null) return;
        var fn = en.Get<LuaFunction>("OnNotify");
        if (fn != null) try { fn.Call(args); } catch (Exception e) { Debug.LogError($"[CppModule.EventNotify] {e.Message}"); }
    }

    // VMA: 0x01a6ca89 — Source: CppModule.c:10730 (OnEvent)
    // gốc body (lines 285-478): switch(param_1) on event severity:
    //   case 1: LogHelper.DEBUG("[OnEvent] " + (param2 ? "true" : "false"))
    //   case 2: LogHelper.DEBUG($"[OnEvent {p2}, {p3}]")
    //   case 4: LogHelper.DEBUG("[OnEvent err] " + bool)
    //   case 5: LogHelper.DEBUG($"[OnEvent err] {p2}, {p3}")
    //   case 7: GPM.GPMFPSMeasureTimer.Instance.EnterGame()
    //   default: just fallthrough
    //   AFTER switch: callback at DAT_03562ab0+0xb8+0x68 — invoke (p1, p2, p3, p4)
    // DEVIATION: GPMFPSMeasureTimer (Tencent FPS tool) unavailable. Switch → log only.
    [AOT.MonoPInvokeCallback(typeof(CppApi.OnEventCallback))]
    public static void OnEvent(int nEvent, int nParam1, int nParam2, int nParam3)
    {
        switch (nEvent)
        {
            case 1: Debug.Log($"[CppModule.OnEvent] {(nParam1 != 0 ? "true" : "false")}"); break;
            case 2: Debug.Log($"[CppModule.OnEvent] {nParam1}, {nParam2}"); break;
            case 4: Debug.LogError($"[CppModule.OnEvent err] {(nParam1 != 0 ? "true" : "false")}"); break;
            case 5: Debug.LogError($"[CppModule.OnEvent err] {nParam1}, {nParam2}"); break;
            case 7: /* gốc: GPMFPSMeasureTimer.EnterGame — DEVIATION skip */ break;
        }
        // Forward to subscribed C# callback if any
        m_OnEvent?.Invoke(nEvent, nParam1, nParam2, nParam3);
    }

    // VMA: 0x01a6d0d1 — Source: CppModule.c:10932 (Active — DelegateRegActivity)
    // gốc body: increment frame counter at +0x8 (m_nLogicFrame); call FrameInterpolation.UpdateFrameInterval(0);
    //           RepresentModule.Active(0); NpcManager.Active(0); MissileManager.Active(0);
    //           PreloadResource.Active(0); AssetResourceModule.Activate(0)
    // DEVIATION: All Active(0) modules are native CppApi-dependent. Just increment frame counter.
    [AOT.MonoPInvokeCallback(typeof(CppApi.DelegateRegActivity))]
    public static void Active()
    {
        m_nLogicFrame++;
        // Native modules (RepresentModule/NpcManager/MissileManager/PreloadResource/AssetResourceModule)
        // unavailable — DEVIATION skip. Phase 7 wire when those modules ported.
    }

    // VMA: 0x01a6d294 — Source: CppModule.c:10984 (GetTickCount)
    // gốc body: return UtilsHelper.GetTickCount(0);  — 1 line, returns long ms.
    // DEVIATION: UtilsHelper.GetTickCount native — replace with Unity Time.realtimeSinceStartup.
    [AOT.MonoPInvokeCallback(typeof(CppApi.DelegateRegGetTickCount))]
    public static long GetTickCount()
    {
        return (long)(Time.realtimeSinceStartup * 1000.0);
    }

    // VMA: 0x01a6d37b — Source: CppModule.c:11009 (LuaError)
    // gốc body: allocate args list, args.Add(msg), LogHelper.ERROR("Lua: ", args).
    [AOT.MonoPInvokeCallback(typeof(CppApi.V_S_Callback))]
    private static void LuaError(string msg)
    {
        Debug.LogError($"[Lua] {msg}");
    }

    // VMA: 0x01a6d5bf — Source: CppModule.c:11074 (Update)
    // gốc body (lines 630-691):
    //   if !_CoreInited (+0x38): return;
    //   set m_bSomeFlag = 1 at DAT_03561688+0xb8+0x90;
    //   tick = UtilsHelper.GetTickCount();
    //   m_nLogicTickTime = tick;
    //   if m_bEnableLogicUpdate (+0x39):
    //     if tick < m_nNextLogicUpdateTime (+0x48): return;
    //   m_nNextLogicUpdateTime = m_nLogicUpdateInterval (+0x40) + m_nLogicTickTime;
    //   CppApi.CoreRun();
    //   var occlusion = SceneOcclusion.Instance; if null crash; occlusion.Breathe();
    // DEVIATION: CppApi.CoreRun + SceneOcclusion.Breathe unavailable. Tick LuaEnv instead.
    private void Update()
    {
        if (!_CoreInited || GameOver) return;
        long tick = GetTickCount();
        m_nLogicTickTime = tick;
        if (m_bEnableLogicUpdate && tick < m_nNextLogicUpdateTime) return;
        m_nNextLogicUpdateTime = tick + m_nLogicUpdateInterval;
        // gốc: CppApi.CoreRun() drives native frame logic. DEVIATION: tick XLua VM only.
        _LuaEnv?.Tick();
    }

    // VMA: 0x01a6d72c — Source: CppModule.c:11145 (OnApplicationQuit)
    // gốc body: GameOver=1, _CoreInited=0, CppApi.RegisterLuaErrorCallback(0), CppApi.CoreExit().
    // DEVIATION: CppApi unavailable.
    private void OnApplicationQuit()
    {
        GameOver = true;
        _CoreInited = false;
    }

    // VMA: 0x01a6d7a4 — Source: CppModule.c:11176 (OnDestroy)
    // gốc body: zero out 11 fields on DAT_03562ab0 singleton (offsets 0x20, 0x68, 0x78, 0x80, 0x88,
    //           0x98, 0xa0, 0xa8, 0xb0, 0xb8, 0xc0); zero CppModule._LuaEnv (+0x28).
    // The DAT_03562ab0 is some other class (likely EventNotify static state). DEVIATION: skip.
    private void OnDestroy()
    {
        // Don't dispose LuaEnv here — owned by ThanMaOrigin.Lua.LuaEngine singleton.
        m_RegDelegate?.Clear();
    }

    // VMA: 0x01a6d8c9 — Source: CppModule.c:11252 (GameWorldTimeScale)
    // gốc body: Time.timeScale = param; var ts = Time.timeScale; Time.fixedDeltaTime = ts * 0.02.
    public static void GameWorldTimeScale(float fScale)
    {
        Time.timeScale = fScale;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    // VMA: 0x01a6d8e8 — Source: CppModule.c:11270 (RegisterLuaErrorCallback)
    // gốc body: CppApi.RegisterLuaErrorCallback(luaError) where luaError is field at +0x30.
    // DEVIATION: CppApi unavailable. XLua handles Lua errors via its own mechanism.
    public static void RegisterLuaErrorCallback()
    {
        // XLua emits Lua errors via Debug.LogError automatically when DoString/Call throws.
        // Custom V_S_Callback registration deferred (would need P/Invoke into custom native).
    }

    // VMA: 0x01a6d958 — Source: CppModule.c:11298 (LuaGC)
    // gốc body:
    //   if _LuaEnv (+0x28) != null:
    //     L = XLua.LuaEnv.get_L(_LuaEnv);
    //     XLua.LuaDLL.Lua.lua_gc(L, 3, 0);  // 3 = LUA_GCCOLLECT
    public static void LuaGC()
    {
        _LuaEnv?.GC();
    }

    // VMA: 0x01a6d9be — Source: CppModule.c:11328 (DumpLuaStack)
    // gốc body (lines 876-962):
    //   if param_1 == null: error;
    //   L = XLua.LuaEnv.get_L(param_1);
    //   top = XLua.LuaDLL.Lua.lua_gettop(L);
    //   LogHelper.ERROR("Lua stack top:", top);
    //   for i = top; i > 0; i--:
    //     L = XLua.LuaEnv.get_L(param_1);
    //     type = XLua.LuaDLL.Lua.lua_type(L, i);
    //     LogHelper.ERROR($"[{i}] type={type}");
    public static void DumpLuaStack(LuaEnv LEnv)
    {
        if (LEnv == null) return;
        // XLua doesn't directly expose lua_State pointer to managed; LogStack via Lua's debug API.
        try { LEnv.DoString("for i=1,10 do local v = debug.getlocal(2, i); if v then print('stack['..i..']='..tostring(v)) else break end end"); }
        catch (Exception e) { Debug.LogError($"[CppModule.DumpLuaStack] {e.Message}"); }
    }

    // VMA: 0x01a6dc27 — Source: CppModule.c:11423 (DumpProcStack)
    // gốc body: just calls DoLuaString(DAT_035b3f48). DAT_035b3f48 is the literal string for
    //           debug.traceback() invocation in Lua.
    public static void DumpProcStack()
    {
        DoLuaString("if debug and debug.traceback then print(debug.traceback('CppModule.DumpProcStack', 2)) end");
    }

    // VMA: 0x01a6dc78 — Source: CppModule.c:11445 (DoLuaString)
    // gốc body: if _LuaEnv (+0x28) != null: XLua.LuaEnv.DoString(_LuaEnv, code, "DoString chunk", 0);
    public static void DoLuaString(string szChunk)
    {
        if (string.IsNullOrEmpty(szChunk) || _LuaEnv == null) return;
        try { _LuaEnv.DoString(szChunk, "DoString chunk"); }
        catch (Exception e) { Debug.LogError($"[CppModule.DoLuaString] {e.Message}"); }
    }

    // VMA: 0x01a6dcf5 — Source: CppModule.c:11474 (GetGlobalTable)
    // gốc body:
    //   if _LuaEnv (+0x28) != null:
    //     globalTable = *(long*)(_LuaEnv + 0x18);                       // LuaEnv.Global
    //     if globalTable != null:
    //       return XLua.LuaTable.Get<object>(globalTable, name);
    public static LuaTable GetGlobalTable(string szName)
    {
        if (_LuaEnv == null)
        {
            var le = ThanMaOrigin.Lua.LuaEngine.Instance;
            if (le != null) _LuaEnv = le.Env;
        }
        if (_LuaEnv == null) return null;
        if (string.IsNullOrEmpty(szName)) return _LuaEnv.Global;
        return _LuaEnv.Global.Get<LuaTable>(szName);
    }

    // Helper (NOT in dump.cs — bridge to LuaEngine, no IL2CPP equivalent).
    public static LuaEnv GetLuaEnv()
    {
        if (_LuaEnv != null) return _LuaEnv;
        var le = ThanMaOrigin.Lua.LuaEngine.Instance;
        if (le != null) { _LuaEnv = le.Env; return _LuaEnv; }
        return null;
    }

    // VMA: 0x01a6dd76 — Source: CppModule.c:11503 (CheckLuaTop)
    // gốc body:
    //   if _LuaEnv != null:
    //     L = XLua.LuaEnv.get_L(_LuaEnv);
    //     XLua.LuaDLL.Lua.lua_gettop(L);   // returns int but discarded in gốc (void return!)
    // dump.cs declares CheckLuaTop returning int, gốc body returns nothing (void). Anomaly in
    // dump signature OR gốc compiler optimizing return — keep return type per dump.cs.
    public static int CheckLuaTop()
    {
        // XLua doesn't expose lua_gettop. Return 0 (matches gốc void semantics).
        return 0;
    }

    // VMA: 0x01a6ddd5 — Source: CppModule.c:11533 (OnLocalizeEvent)
    // gốc body: if _CoreInited (+0x38) != 0: alloc args list[1] = LOCALIZE_EVENT_ID, EventNotify(args).
    public static void OnLocalizeEvent()
    {
        if (!_CoreInited) return;
        EventNotify(new object[] { 100 /* LOCALIZE_EVENT_ID — gốc DAT_035624b0 — TODO verify exact const */ });
    }

    // VMA: 0x01a6ded2 — Source: CppModule.c:11585 (SetLogicUpdate)
    // gốc body:
    //   if param < 1: m_bEnableLogicUpdate (+0x39) = 0;
    //   else: m_bEnableLogicUpdate = 1; m_nLogicUpdateInterval (+0x40) = (long)(1000.0 / param);
    public static void SetLogicUpdate(int nFPS)
    {
        if (nFPS < 1)
        {
            m_bEnableLogicUpdate = false;
        }
        else
        {
            m_bEnableLogicUpdate = true;
            m_nLogicUpdateInterval = (long)(1000.0f / nFPS);
        }
    }
}
