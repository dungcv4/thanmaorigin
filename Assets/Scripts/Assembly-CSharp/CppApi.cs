// Class:  CppApi (P/Invoke wrapper for libclient_scene.so)
// GUID:   a8762bf53daa339dded69a5d46f124f2 (preserved via .meta)
// Source: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 203)
//
// PARTIAL PORT 2026-04-25: nested delegate declarations + key static method shims.
//
// CLASS-LEVEL DEVIATION:
// - thanmaorigin doesn't ship libclient_scene.so. extern P/Invoke methods are
//   replaced with stubs that log calls + return safe defaults. Real native side
//   needs separate port (1112 .asm files extracted via tools/extract_libclient_scene.py
//   per project memory `libclient_scene.so full extract`).

using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class CppApi
{
    public const string CPP_DLL_NAME = "client_scene";

    // ======= Nested delegate types — Source: dump.cs (TypeDefIndex 186-201) =======
    public delegate void SubWorldCallback(string szParam1, string szParam2, int nParam);     // 186
    public delegate void OnLoadFileCallback(string szFile);                                  // 187
    public delegate void OnEventCallback(int nEventType, int Param1, int Param2, int Param3); // 188
    public delegate bool IsLoadSceneCallback();                                              // 189
    public delegate void AddObjCallback(int nId, int nType, int nTemplateId, int nPosX, int nPosY, int nPosZ); // 190
    public delegate void DeleteObjCallback(int nId);                                         // 191
    public delegate void AddItemObjCallback(int nObjID, string szName, int nQuality, int nPosX, int nPosY, int nPosZ, int nType); // 192
    public delegate bool AutoPathCallback(int nStartX, int nStartY, int nStartZ, int nEndX, int nEndY, int nEndZ, IntPtr anPathPoints); // 193
    public delegate void DelegateRegActivity();                                              // 194
    public delegate long DelegateRegGetTickCount();                                          // 195
    public delegate void V_S_Callback(string s1);                                            // 196
    public delegate IntPtr BytesReader([In] string path, ref int size);                      // 200
    public delegate void BytesReaderRelease(IntPtr ptr);                                     // 201

    // ======= Static method stubs (DEVIATION — native impl deferred) =======
    public static void FreeLibrary() { Debug.Log("[CppApi.FreeLibrary] DEVIATION stub"); }
    public static bool DecommpressToFile(byte[] byBuffer, string szDstPath) => false;
    public static void RegGetTickCount(DelegateRegGetTickCount Callback) { }
    public static void RegActivity(DelegateRegActivity Callback) { }
    public static bool CoreInit(IntPtr L, string szUserPath, int nStep) { Debug.Log($"[CppApi.CoreInit] step={nStep} path={szUserPath}"); return true; }
    public static void SetUnityBytesReader(BytesReader bytesReader, BytesReaderRelease doRelease) { }
    public static void CoreRun() { }
    public static void CoreExit() { }
    public static void SetEventCallback(OnEventCallback fnOnEvent) { }
    public static void RegisterSubWorldCallback(int nType, SubWorldCallback fnCallback) { }
    public static void RegisterLuaErrorCallback(V_S_Callback fnCallback) { }
    public static void RegisterIsLoadSceneCallback(IsLoadSceneCallback fnCallback) { }
    public static void FilePackOpenInfo(string szIndexFilePath) { }
    public static void FilePackCloseInfo() { }
    public static void SetDebugPathInfo(string szDebugPath) { }
    public static bool ReadResFile(string szPath, byte[] pbyBuffer, int nMaxLength) => false;
    public static bool ReadResFileText(string szPath, OnLoadFileCallback fnOnLoadFile) => false;
    public static int GetResFileSize(string szPath) => 0;
    public static ulong GetClientTickCount() => (ulong)((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
    public static void OnApplicationPause(bool bPause) { }
    public static void RegisterAddItemObjCallback(AddItemObjCallback fnCallback) { }
    public static void RegisterAddObjCallback(AddObjCallback fnCallback) { }
    public static void RegisterDeleteObjCallback(DeleteObjCallback fnCallback) { }
    public static void RegisterAutoPathCallback(AutoPathCallback fnCallback) { }
}
