// AUTO-GENERATED skeleton from gốc IL2CPP dump.
// Class:   ResourceModule
// GUID:    f108f4a34467646acb0028586ec0806d
// Source:  /Users/vsf-user-l/Documents/Test/alo/KTO_Resources/il2cpp_full_dump/dump.cs (dump.cs class block)
// Ghidra:  /Users/vsf-user-l/Documents/Test/alo/KTO_DecompiledReference/_root/ResourceModule.c
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
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class ResourceModule : MonoBehaviour
{

	// Fields
	private static int _OnceLoadResCount; // 0x0
	public static int CacheRecycleLine; // 0x4
	private static Dictionary<string, ResourceTask> _RuningTask; // 0x8
	private static List<object> _AsyncLoadCmdCache; // 0x10
	private static List<string> _WaitLoadRes; // 0x18
	private static List<string> _LoadingRes; // 0x20
	private static string _FileText; // 0x28

	// Methods

	[IteratorStateMachine(typeof(ResourceModule.<Init>d__0))]
	// RVA: 0x1814C7D Offset: 0x1810C7D VA: 0x1814C7D
	public static IEnumerator Init() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1814CDB Offset: 0x1810CDB VA: 0x1814CDB
	private void LateUpdate() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1814DAA Offset: 0x1810DAA VA: 0x1814DAA
	public static void OpenPackFile() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1814E36 Offset: 0x1810E36 VA: 0x1814E36
	public static void ClosePackFile() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1814E73 Offset: 0x1810E73 VA: 0x1814E73
	public static void SetMapLoadingTopPriority(bool bStart) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x180B34D Offset: 0x180734D VA: 0x180B34D
	public static void LoadResourceAsync(bool isUI, string szPath, OnResourceFinishEventHandler finish, object param) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1815166 Offset: 0x1811166 VA: 0x1815166
	public static Object LoadResourceSync(string szPath) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x181549B Offset: 0x181149B VA: 0x181549B
	public static void OnCollectFinish() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x181568F Offset: 0x181168F VA: 0x181568F
	public static bool CheckAllResourceLoadFinish() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x18156FE Offset: 0x18116FE VA: 0x18156FE
	public static void UnLoadResourceCache(bool bGC) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x181573E Offset: 0x181173E VA: 0x181573E
	public static void SetOnceLoadResCount(int count) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x181578C Offset: 0x181178C VA: 0x181578C
	private static void _OnResourceLoadFinished(object obj, object param) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1815ECF Offset: 0x1811ECF VA: 0x1815ECF
	private static bool _CheckResourceLoadFinished(object obj, object param) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1815FA8 Offset: 0x1811FA8 VA: 0x1815FA8
	public static void RemoveWaitLoadRes(string szPath) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x18160A3 Offset: 0x18120A3 VA: 0x18160A3
	public static int GetResourceCacheCount() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x18160DE Offset: 0x18120DE VA: 0x18160DE
	public static int GetResourceWaitCount() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x181613C Offset: 0x181213C VA: 0x181613C
	public static int GetResourceRuningCount() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x18161A5 Offset: 0x18121A5 VA: 0x18161A5
	public static int GetResourceLoadingCount() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	[MonoPInvokeCallback(typeof(CppApi.OnLoadFileCallback))]
	// RVA: 0x1814AE2 Offset: 0x1810AE2 VA: 0x1814AE2
	private static void OnLoadUtf8File(string szText) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1816203 Offset: 0x1812203 VA: 0x1816203
	public static string LoadText(string szPath, Encoding encoding) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1816638 Offset: 0x1812638 VA: 0x1816638
	private static byte[] LoadTextSync(string url) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x18167FB Offset: 0x18127FB VA: 0x18167FB
	public static byte[] LoadByte(string szPath, Encoding encoding) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1816A90 Offset: 0x1812A90 VA: 0x1816A90
	public static bool IsStreamingAssetsExists(string path) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x18167BA Offset: 0x18127BA VA: 0x18167BA
	public static byte[] LoadBytesFromStreamingAssets(string path) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

}
