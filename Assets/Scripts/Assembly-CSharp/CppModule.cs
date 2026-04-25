// AUTO-GENERATED skeleton from gốc IL2CPP dump.
// Class:   CppModule
// GUID:    1838d77880a2e50444abbe02986a1b51
// Source:  /Users/vsf-user-l/Documents/Test/alo/KTO_Resources/il2cpp_full_dump/dump.cs (dump.cs class block)
// Ghidra:  /Users/vsf-user-l/Documents/Test/alo/KTO_DecompiledReference/_root/CppModule.c
// VMA cites embedded in method comments below.
//
// PORTING WORKFLOW:
//   1. Each method has VMA cite (RVA: 0x...).
//   2. Body currently throws NotImplementedException.
//   3. Look up VMA in Ghidra file → port body 1-1.
//   4. After port: remove `throw new ...` + add `// VMA: 0x...` cite at method start.
//
// RULES (CLAUDE.md):
//   - 100% từ gốc, KHÔNG chế cháo.
//   - Mọi method PHẢI có comment // Source: <file>:<line> hoặc // VMA: 0x...
//   - Nếu DEVIATION (Cpp2IL stub trống / server-side / Unity API gone): ASK USER trước.

using System;
using UnityEngine;
using XLua;
using System.Collections.Generic;
using System.Collections;

public class CppModule : MonoBehaviour
{

	// Fields
	public static CppApi.OnEventCallback m_OnEvent; // 0x0
	public static long m_nLogicFrame; // 0x8
	public static long m_nLogicTickTime; // 0x10
	private static List<object> m_RegDelegate; // 0x18
	public static bool GameOver; // 0x20
	public static LuaEnv _LuaEnv; // 0x28
	private static CppApi.V_S_Callback luaError; // 0x30
	private static bool _CoreInited; // 0x38
	public static bool m_bEnableLogicUpdate; // 0x39
	public static long m_nLogicUpdateInterval; // 0x40
	public static long m_nNextLogicUpdateTime; // 0x48

	// Methods

	[IteratorStateMachine(typeof(CppModule.<Init>d__11))]
	// RVA: 0x19670B2 Offset: 0x19630B2 VA: 0x19670B2
	public static IEnumerator Init() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196D5BF Offset: 0x19695BF VA: 0x196D5BF
	private void Update() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196D72C Offset: 0x196972C VA: 0x196D72C
	private void OnApplicationQuit() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196D7A4 Offset: 0x19697A4 VA: 0x196D7A4
	private void OnDestroy() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x19670F7 Offset: 0x19630F7 VA: 0x19670F7
	public static void EventNotify(object[] args) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	[MonoPInvokeCallback(typeof(CppApi.OnEventCallback))]
	// RVA: 0x196CA89 Offset: 0x1968A89 VA: 0x196CA89
	public static void OnEvent(int nEvent, int nParam1, int nParam2, int nParam3) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	[MonoPInvokeCallback(typeof(CppApi.DelegateRegActivity))]
	// RVA: 0x196D0D1 Offset: 0x19690D1 VA: 0x196D0D1
	public static void Active() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	[MonoPInvokeCallback(typeof(CppApi.DelegateRegGetTickCount))]
	// RVA: 0x196D294 Offset: 0x1969294 VA: 0x196D294
	public static long GetTickCount() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x19663C1 Offset: 0x19623C1 VA: 0x19663C1
	public static void OnApplicationPause(bool pauseStatus) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196D8C9 Offset: 0x19698C9 VA: 0x196D8C9
	public static void GameWorldTimeScale(float fScale) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196D8E8 Offset: 0x19698E8 VA: 0x196D8E8
	public static void RegisterLuaErrorCallback() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196D958 Offset: 0x1969958 VA: 0x196D958
	public static void LuaGC() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	[MonoPInvokeCallback(typeof(CppApi.V_S_Callback))]
	// RVA: 0x196D37B Offset: 0x196937B VA: 0x196D37B
	private static void LuaError(string msg) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x19612A3 Offset: 0x195D2A3 VA: 0x19612A3
	public static object[] CallLua(string szFunction, object[] vecParams) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196D9BE Offset: 0x19699BE VA: 0x196D9BE
	public static void DumpLuaStack(LuaEnv LEnv) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196DC27 Offset: 0x1969C27 VA: 0x196DC27
	public static void DumpProcStack() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196DC78 Offset: 0x1969C78 VA: 0x196DC78
	public static void DoLuaString(string szChunk) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196DCF5 Offset: 0x1969CF5 VA: 0x196DCF5
	public static LuaTable GetGlobalTable(string szName) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196DD76 Offset: 0x1969D76 VA: 0x196DD76
	public static int CheckLuaTop() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196DDD5 Offset: 0x1969DD5 VA: 0x196DDD5
	public static void OnLocalizeEvent() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x196DED2 Offset: 0x1969ED2 VA: 0x196DED2
	public static void SetLogicUpdate(int nFPS) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

}
