// Class:  GameEnv  (PARTIAL — only GetPersistent / GetPatchLogPath / GetLogPath ported here)
// GUID:   eafec7236009b9e7f2e5b5433f9516de (preserved via .meta)
// Source: KTO_DecompiledReference/_root/GameEnv.c (TypeDefIndex 185, ~80 methods)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs
//
// PARTIAL PORT 2026-04-25:
// Full GameEnv has 80+ static fields/methods. This file ports only the 3 path helpers
// needed by KKUpdater (GetPersistent, GetLogPath, GetPatchLogPath). Other GameEnv
// statics (ALBUM, IsUseAB, IsUsePack, IsDevMode, AppVersionStr, AppNum, ...) will be
// added incrementally as gameplay subsystems get ported. The fields are declared as
// static defaults to keep the API surface visible.

using System.IO;
using UnityEngine;

// gốc has [LuaCallCSharp(0)] from XLua. We omit attribute since we're not
// generating XLua bindings at this layer (DEVIATION).
public class GameEnv
{
    // Static fields (offsets from dump). Default values match cctor where possible.
    public static string ALBUM = "";              // 0x0
    public static bool IsUseAB = true;            // 0x8
    public static bool IsUsePack = true;          // 0x9
    public static bool IsDevMode = false;         // 0xA
    public static bool EnableSDK = false;         // 0xB
    public static string AppVersionStr = "";      // 0x10
    public static int AppNum = 0;                 // 0x18
    public static bool AllSameAsLastTime = false; // 0x1C
    public static bool EnableAutoTest = false;    // 0x1D
    public static bool EnableFireBase = false;    // 0x1E

    // VMA: ~0x01968581 — Source: dump.cs (GetPersistent)
    // gốc body: returns Application.persistentDataPath  (with cached lookup omitted).
    public static string GetPersistent()
    {
        return Application.persistentDataPath;
    }

    // VMA: 0x019685C1 — Source: dump.cs (GetLogPath)
    // gốc body: GetPersistent() + "/log/"  (path normalization)
    public static string GetLogPath()
    {
        var p = Path.Combine(GetPersistent(), "log");
        if (!Directory.Exists(p)) Directory.CreateDirectory(p);
        return p;
    }

    // VMA: ~0x019685XX — Source: dump.cs (GetPatchLogPath)
    // gốc body: GetPersistent() + "/log/patch/"  (used by KKUpdater.WriteLog)
    public static string GetPatchLogPath()
    {
        var p = Path.Combine(GetLogPath(), "patch");
        if (!Directory.Exists(p)) Directory.CreateDirectory(p);
        return p;
    }
}

