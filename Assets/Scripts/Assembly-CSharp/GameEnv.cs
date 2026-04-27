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
    // Used by Login UI to pre-populate account input. dump.cs lists as static field.
    // gốc value blank in release; testers fill at runtime.
    public static string TestAccount = "";

    // Debug gateway override fields (gốc Script_Login_LoginZoneList.lua:2-9 reads these).
    // gốc populates from debug.ini commandline arg. Set TRUE here so local thanmaorigin
    // server (GameServer_NET8 on port 3001) becomes the default zone for direct testing.
    // Removed when zone-fetch CMD pipeline is wired Phase C.
    // 1-1 cite: Login.lua:GetZoneList branch checks bHasDebugParam + szDebugGatewayAddr.
    public static bool bHasDebugParam = true;
    public static string szDebugGatewayAddr = "127.0.0.1:3001";

    // Source: GameEnv.c GameEnv__get_InPlatform_PC
    // gốc body: returns Application.platform == StandaloneOSX/Windows/Linux check.
    // DEVIATION: thanmaorigin returns RuntimePlatform-based check.
    public static bool InPlatform_PC =>
        Application.platform == RuntimePlatform.OSXEditor ||
        Application.platform == RuntimePlatform.OSXPlayer ||
        Application.platform == RuntimePlatform.WindowsEditor ||
        Application.platform == RuntimePlatform.WindowsPlayer ||
        Application.platform == RuntimePlatform.LinuxEditor ||
        Application.platform == RuntimePlatform.LinuxPlayer;

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

    // VMA: 0x01a69... — Source: KTO_DecompiledReference/_root/GameEnv.c GameEnv__GetAppVersionStr3
    // gốc body:
    //   var v = AppVersion._Version;
    //   if (v != null) return v.ToVersion3();   // "X.Y.Z" format
    //   throw;
    // Used by Script_Ui_Window_UILoginChannelInner.lua:118 to render version label.
    // DEVIATION: AppVersion class not yet ported (TypeDefIndex needs separate port).
    //   Returns ALBUM-baked AppVersionStr (which we leave default empty for now), or "1.0.0".
    //   When SDK login flow is wired, AppVersion gets populated from server response.
    public static string GetAppVersionStr3()
    {
        if (!string.IsNullOrEmpty(AppVersionStr))
        {
            // Take first 3 components if available, else as-is
            var parts = AppVersionStr.Split('.');
            if (parts.Length >= 3) return parts[0] + "." + parts[1] + "." + parts[2];
            return AppVersionStr;
        }
        return "1.0.0";
    }

    // Source: KTO_DecompiledReference/_root/GameEnv.c GameEnv__GetUpdateVersion
    // gốc body:
    //   if (NetClient.<+0x61> == 0) return 0;             // not connected
    //   var head = (*(LoginHead*)NetClient.list_head);
    //   if (head == null || head.+0x28 == null) throw;
    //   return *(int*)(head.+0x28 + 0x18);                // server-pushed update version
    // DEVIATION: NetClient + LoginHead not yet ported. Return 0 (matches "not connected" branch).
    //   Once Phase B server connection is wired, this will read from server response.
    public static int GetUpdateVersion()
    {
        return 0;
    }

    // Source: KTO_DecompiledReference/_root/GameEnv.c GameEnv__GetVersionType
    // gốc body:
    //   var v = AppVersion._Version;
    //   if (v != null) return v.+0x28;        // version type string field
    //   throw;
    // DEVIATION: AppVersion class not ported → return "release" default.
    //   Used by UILoginChannelInner.OnOpen to gate btnSelectZone visibility for alpha/beta builds.
    //   Returning "release" hides selectZone button (matches production builds).
    public static string GetVersionType()
    {
        return "release";
    }

    // Source: KTO_DecompiledReference/_root/GameEnv.c GameEnv__SetPlatform
    // gốc body: empty no-op (literally `void SetPlatform(int) { return; }`).
    public static void SetPlatform(int nIndex)
    {
        // gốc no-op
    }
}

