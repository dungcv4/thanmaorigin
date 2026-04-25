// Class:  CppModule
// GUID:   1838d77880a2e50444abbe02986a1b51 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/CppModule.c (22 methods, 1232 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs
//
// 1-1 port với DEVIATIONs cited.
// gốc dùng CppApi (libclient_scene.so) cho native event/tick/Lua bindings.
// thanmaorigin DEVIATION: skip native CppApi, dùng C# managed equivalent.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using XLua;

public class CppModule : MonoBehaviour
{
    // Fields (offsets từ dump.cs)
    public static CppApi.OnEventCallback m_OnEvent;       // 0x0
    public static long m_nLogicFrame;                     // 0x8
    public static long m_nLogicTickTime;                  // 0x10
    private static List<object> m_RegDelegate = new List<object>();   // 0x18
    public static bool GameOver;                          // 0x20
    public static LuaEnv _LuaEnv;                         // 0x28
    private static CppApi.V_S_Callback luaError;          // 0x30
    private static bool _CoreInited;                      // 0x38
    public static bool m_bEnableLogicUpdate = true;       // 0x39
    public static long m_nLogicUpdateInterval = 56;       // 0x40 — gốc default ~18Hz (1000ms/18=56ms)
    public static long m_nNextLogicUpdateTime;            // 0x48

    // VMA: 0x019670b2 — Source: CppModule.c (Init coroutine)
    // gốc: register CppApi callbacks, init Lua VM, RegisterLuaErrorCallback, set _CoreInited=1.
    // DEVIATION: native CppApi skip. Bridge to thanmaorigin LuaEngine.
    [IteratorStateMachine(typeof(CppModule.<Init>d__11))]
    public static IEnumerator Init()
    {
        if (_CoreInited) yield break;
        _CoreInited = true;
        var le = ThanMaOrigin.Lua.LuaEngine.Instance;
        if (le != null) _LuaEnv = le.Env;
        m_nNextLogicUpdateTime = GetTickCount() + m_nLogicUpdateInterval;
        yield break;
    }

    // VMA: 0x0196d5bf — Source: CppModule.c (Update tick)
    // gốc: increment m_nLogicFrame; pump LuaGC periodically; flush deferred events.
    private void Update()
    {
        if (!m_bEnableLogicUpdate || GameOver) return;
        long now = GetTickCount();
        if (now >= m_nNextLogicUpdateTime)
        {
            m_nLogicFrame++;
            m_nLogicTickTime = now;
            m_nNextLogicUpdateTime = now + m_nLogicUpdateInterval;
        }
        _LuaEnv?.Tick();
    }

    // VMA: 0x0196d72c — Source: CppModule.c (OnApplicationQuit)
    private void OnApplicationQuit()
    {
        GameOver = true;
    }

    // VMA: 0x0196d7a4 — Source: CppModule.c (OnDestroy)
    private void OnDestroy()
    {
        // Don't dispose LuaEnv here — owned by LuaEngine singleton.
        m_RegDelegate?.Clear();
    }

    // VMA: 0x019670f7 — Source: CppModule.c (EventNotify)
    // gốc: dispatch event to subscribed Lua/C# handlers via m_OnEvent.
    // DEVIATION: simple invoke.
    public static void EventNotify(object[] args)
    {
        if (args == null || args.Length < 1) return;
        if (m_OnEvent != null)
        {
            // gốc forwards to native CppApi event bus.
            // DEVIATION: invoke if int args available.
            int nEvent = args.Length > 0 ? Convert.ToInt32(args[0]) : 0;
            int p1 = args.Length > 1 ? Convert.ToInt32(args[1]) : 0;
            int p2 = args.Length > 2 ? Convert.ToInt32(args[2]) : 0;
            int p3 = args.Length > 3 ? Convert.ToInt32(args[3]) : 0;
            m_OnEvent(nEvent, p1, p2, p3);
        }
    }

    // VMA: 0x0196ca89 — Source: CppModule.c (OnEvent — P/Invoke callback from native CppApi)
    [AOT.MonoPInvokeCallback(typeof(CppApi.OnEventCallback))]
    public static void OnEvent(int nEvent, int nParam1, int nParam2, int nParam3)
    {
        // Forward to Lua via EventNotify chain — gốc dispatches to subscribed Lua tables.
        // Bridge to LuaEngine event system (deferred Phase 3.9).
    }

    // VMA: 0x0196d0d1 — Source: CppModule.c (Active — DelegateRegActivity)
    [AOT.MonoPInvokeCallback(typeof(CppApi.DelegateRegActivity))]
    public static void Active() { /* native callback no-op in DEVIATION */ }

    // VMA: 0x0196d294 — Source: CppModule.c (GetTickCount — DelegateRegGetTickCount)
    // gốc: Time.realtimeSinceStartup * 1000.
    [AOT.MonoPInvokeCallback(typeof(CppApi.DelegateRegGetTickCount))]
    public static long GetTickCount()
    {
        return (long)(Time.realtimeSinceStartup * 1000.0);
    }

    // VMA: 0x019663c1 — Source: CppModule.c (OnApplicationPause)
    public static void OnApplicationPause(bool pauseStatus)
    {
        // Forward to Lua via EventNotify.
        EventNotify(new object[] { 1 /* PAUSE_EVENT_ID */, pauseStatus ? 1 : 0 });
    }

    // VMA: 0x0196d8c9 — Source: CppModule.c (GameWorldTimeScale)
    public static void GameWorldTimeScale(float fScale)
    {
        Time.timeScale = fScale;
    }

    // VMA: 0x0196d8e8 — Source: CppModule.c (RegisterLuaErrorCallback)
    // gốc: register C# delegate as Lua error handler via XLua.
    public static void RegisterLuaErrorCallback()
    {
        // XLua handles Lua errors via Lua_State error mechanism.
        // Custom callback registration deferred Phase 3.9.
    }

    // VMA: 0x0196d958 — Source: CppModule.c (LuaGC)
    public static void LuaGC()
    {
        _LuaEnv?.GC();
    }

    // VMA: 0x0196d37b — Source: CppModule.c (LuaError — V_S_Callback for Lua errors)
    [AOT.MonoPInvokeCallback(typeof(CppApi.V_S_Callback))]
    private static void LuaError(string msg)
    {
        Debug.LogError($"[Lua] {msg}");
    }

    // VMA: 0x019612a3 — Source: CppModule.c:987 (CallLua)
    // gốc: navigate global table by szFunction (path "Ui.tbClass.UIBag.OnOpen" style),
    //      call resolved function with vecParams. Returns array of return values.
    public static object[] CallLua(string szFunction, object[] vecParams)
    {
        if (string.IsNullOrEmpty(szFunction) || _LuaEnv == null) return null;
        var fn = _LuaEnv.Global.GetInPath<LuaFunction>(szFunction);
        if (fn == null) return null;
        return fn.Call(vecParams ?? new object[0]);
    }

    // VMA: 0x0196d9be — Source: CppModule.c (DumpLuaStack)
    public static void DumpLuaStack(LuaEnv LEnv)
    {
        if (LEnv != null)
        {
            // XLua exposes some debug API but stack dump is internal — limited port.
            Debug.Log("[Lua] Stack dump requested (full impl Phase 3.9).");
        }
    }

    // VMA: 0x0196dc27 — Source: CppModule.c (DumpProcStack)
    public static void DumpProcStack()
    {
        Debug.Log(System.Environment.StackTrace);
    }

    // VMA: 0x0196dc78 — Source: CppModule.c (DoLuaString)
    // gốc: LuaEnv.DoString(szChunk).
    public static void DoLuaString(string szChunk)
    {
        if (string.IsNullOrEmpty(szChunk) || _LuaEnv == null) return;
        try { _LuaEnv.DoString(szChunk); }
        catch (Exception e) { Debug.LogError($"[Lua DoString] {e.Message}"); }
    }

    // VMA: 0x0196dcf5 — Source: CppModule.c (GetGlobalTable)
    // gốc: lookup table via global path.
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

    // Helper (NOT in dump.cs — bridge to LuaEngine).
    public static LuaEnv GetLuaEnv()
    {
        if (_LuaEnv != null) return _LuaEnv;
        var le = ThanMaOrigin.Lua.LuaEngine.Instance;
        if (le != null) { _LuaEnv = le.Env; return _LuaEnv; }
        return null;
    }

    // VMA: 0x0196dd76 — Source: CppModule.c (CheckLuaTop)
    // gốc: native Lua API lua_gettop check.
    // DEVIATION: XLua doesn't expose lua_gettop directly — return 0.
    public static int CheckLuaTop() => 0;

    // VMA: 0x0196ddd5 — Source: CppModule.c (OnLocalizeEvent)
    // gốc: fire localization update event when system locale changes.
    public static void OnLocalizeEvent()
    {
        EventNotify(new object[] { 100 /* LOCALIZE_EVENT_ID */ });
    }

    // VMA: 0x0196ded2 — Source: CppModule.c (SetLogicUpdate)
    // gốc: configure tick interval based on nFPS.
    public static void SetLogicUpdate(int nFPS)
    {
        if (nFPS <= 0) { m_bEnableLogicUpdate = false; return; }
        m_bEnableLogicUpdate = true;
        m_nLogicUpdateInterval = 1000 / nFPS;
    }
}
