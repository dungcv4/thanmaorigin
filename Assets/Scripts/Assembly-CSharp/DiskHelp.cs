// Class:  KKUpdater.DiskHelp
// GUID:   740526081cebddf3579e9e42ce5d5359 (preserved via .meta)
// Source: KTO_DecompiledReference/KKUpdater/DiskHelp.c (2 methods, 100 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1389)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.
//
// CLASS-LEVEL DEVIATION:
// - Android: AndroidJavaClass("android.os.StatFs") → CallStatic<long>("getAvailableBytes",
//   environment.getDataDirectory().getAbsolutePath()).  Direct port.
// - Non-Android (Editor / iOS / Standalone): DEVIATION — System.IO.DriveInfo.AvailableFreeSpace
//   on the persistent path, since AndroidJavaClass throws on these platforms.

using System;
using System.IO;
using UnityEngine;

namespace KKUpdater
{
    public class DiskHelp
    {
        // VMA: 0x01bc94a6 — Source: KTO_DecompiledReference/KKUpdater/DiskHelp.c:15 (GetFreeDiskSpaceMB)
        // gốc body:
        //   AndroidJavaClass envCls = new AndroidJavaClass("android.os.Environment");
        //   AndroidJavaClass statFsCls = new AndroidJavaClass("android.os.StatFs");
        //   string dataDir = envCls.CallStatic<AndroidJavaObject>("getDataDirectory")
        //                          .Call<string>("getAbsolutePath");
        //   long bytes = statFsCls.CallStatic<long>("getAvailableBytes", dataDir);
        //   KUpdaterMgr.WriteLog("DiskHelp", $"FreeDiskSpaceMB={bytes}");
        //   return bytes;   // gốc inconsistency preserved: returns BYTES despite "MB" in name.
        public static long GetFreeDiskSpaceMB()
        {
            long bytes = 0;
#if UNITY_ANDROID && !UNITY_EDITOR
            try
            {
                using (var envCls = new AndroidJavaClass("android.os.Environment"))
                using (var statFsCls = new AndroidJavaClass("android.os.StatFs"))
                {
                    string dataDir = envCls.CallStatic<AndroidJavaObject>("getDataDirectory")
                                           .Call<string>("getAbsolutePath");
                    bytes = statFsCls.CallStatic<long>("getAvailableBytes", dataDir);
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"[DiskHelp] AndroidJavaClass failed: {e.Message}");
            }
#else
            // DEVIATION (non-Android): use DriveInfo against persistentDataPath.
            try
            {
                var di = new DriveInfo(Path.GetPathRoot(Application.persistentDataPath) ?? "/");
                bytes = di.AvailableFreeSpace;
            }
            catch (Exception e)
            {
                Debug.LogError($"[DiskHelp] DriveInfo failed: {e.Message}");
            }
#endif
            try { KUpdaterMgr.WriteLog("DiskHelp", "FreeDiskSpaceMB=" + bytes.ToString()); } catch { }
            return bytes;
        }

        // VMA: 0x01bc975b — Source: KTO_DecompiledReference/KKUpdater/DiskHelp.c:91 (.ctor)
        // gốc body: System_Object___ctor(this, 0); — chain to base.
        public DiskHelp() { }
    }
}
