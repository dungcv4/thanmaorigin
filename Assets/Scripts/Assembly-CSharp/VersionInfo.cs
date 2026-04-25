// Class:  KKUpdater.VersionInfo
// GUID:   (no existing .meta — new file)
// Source: KTO_DecompiledReference/KKUpdater/VersionInfo.c (10 methods, 290 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1377)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.
// Includes nested NewUpdateType enum (TypeDefIndex 1376).

using System;
using System.Collections.Generic;
using UnityEngine;

namespace KKUpdater
{
    public class VersionInfo
    {
        public enum NewUpdateType
        {
            None = 0,
            Optional = 1,
            Forced = 2,
        }

        // Fields (offsets từ dump.cs)
        public string MainVersion;                            // 0x10
        public int UdpateVersion;                             // 0x18 (sic: gốc misspelling preserved)
        public bool IsShenhe;                                 // 0x1C
        public bool WaitingDlc;                               // 0x1D
        public string BlockMsg;                               // 0x20
        public int NewUpdate;                                 // 0x28
        public string UpdateMsg;                              // 0x30
        public Dictionary<string, int[]> DownloadConfig;      // 0x38
        public Dictionary<string, string> NewPackageUrl;      // 0x40
        public string PackageUrl;                             // 0x48

        // VMA: 0x01bc7ec0 — Source: KTO_DecompiledReference/KKUpdater/VersionInfo.c:15 (Reset)
        // gốc body: this.UdpateVersion = 0;
        public void Reset()
        {
            UdpateVersion = 0;
        }

        // VMA: 0x01bc7ec8 — Source: KTO_DecompiledReference/KKUpdater/VersionInfo.c:33 (ToString)
        // gốc body: return string.Format(DAT_035a9ce8 ("{0}.{1}"), MainVersion, UdpateVersion);
        public override string ToString()
        {
            return string.Format("{0}.{1}", MainVersion, UdpateVersion);
        }

        // VMA: 0x01bc7f33 — Source: KTO_DecompiledReference/KKUpdater/VersionInfo.c:66 (MainVersion2Uint)
        // gốc body:
        //   string[] parts = MainVersion.Split('.');
        //   if (parts.Length == 0) throw;
        //   uint major = uint.Parse(parts[0]);
        //   uint minor = parts.Length > 1 ? uint.Parse(parts[1]) : 0;
        //   uint patch = parts.Length > 2 ? uint.Parse(parts[2]) : 0;
        //   return AppVersion.ToInt(major, minor, patch, 0);
        public uint MainVersion2Uint()
        {
            if (MainVersion == null) throw new NullReferenceException("MainVersion");
            string[] parts = MainVersion.Split('.');
            if (parts.Length == 0) throw new IndexOutOfRangeException();
            uint major = uint.Parse(parts[0]);
            if (parts.Length <= 1) throw new IndexOutOfRangeException();
            uint minor = uint.Parse(parts[1]);
            if (parts.Length <= 2) throw new IndexOutOfRangeException();
            uint patch = uint.Parse(parts[2]);
            return AppVersion.ToInt(major, minor, patch, 0);
        }

        // VMA: 0x01bc7fad — Source: KTO_DecompiledReference/KKUpdater/VersionInfo.c:107 (MainVersionGreaterThan)
        // gốc body:
        //   uint a = this.MainVersion2Uint();
        //   if (rhs == null) throw;
        //   uint b = rhs.MainVersion2Uint();
        //   return b < a;
        public bool MainVersionGreaterThan(VersionInfo rhs)
        {
            uint a = this.MainVersion2Uint();
            if (rhs == null) throw new NullReferenceException(nameof(rhs));
            uint b = rhs.MainVersion2Uint();
            return b < a;
        }

        // VMA: 0x01bc7fd8 — Source: KTO_DecompiledReference/KKUpdater/VersionInfo.c:133 (GetDownloadConfig)
        // gốc body:
        //   if (DownloadConfig == null) return null;
        //   if (!DownloadConfig.ContainsKey(key)) return null;
        //   return DownloadConfig[key];
        public int[] GetDownloadConfig(string key)
        {
            if (DownloadConfig == null) return null;
            if (!DownloadConfig.ContainsKey(key)) return null;
            return DownloadConfig[key];
        }

        // VMA: 0x01bc805a — Source: KTO_DecompiledReference/KKUpdater/VersionInfo.c:171 (GetBlockMsg)
        public string GetBlockMsg() => BlockMsg;

        // VMA: 0x01bc805f — Source: KTO_DecompiledReference/KKUpdater/VersionInfo.c:188 (GetUpdateMsg)
        public string GetUpdateMsg() => UpdateMsg;

        // VMA: 0x01bc8064 — Source: KTO_DecompiledReference/KKUpdater/VersionInfo.c:205 (GetNewUdpateType)
        public int GetNewUdpateType() => NewUpdate;

        // VMA: 0x01bc8068 — Source: KTO_DecompiledReference/KKUpdater/VersionInfo.c:222 (GetUpdateUrlByIdentifier)
        // gốc body:
        //   if (PackageUrl != "") return PackageUrl;
        //   if (NewPackageUrl != null) {
        //     string id = Application.identifier;
        //     if (NewPackageUrl.ContainsKey(id)) return NewPackageUrl[id];
        //   }
        //   return "";
        public string GetUpdateUrlByIdentifier()
        {
            if (!string.IsNullOrEmpty(PackageUrl)) return PackageUrl;
            if (NewPackageUrl != null)
            {
                string id = Application.identifier;
                if (NewPackageUrl.ContainsKey(id)) return NewPackageUrl[id];
            }
            return "";
        }

        // VMA: 0x01bc816d — Source: KTO_DecompiledReference/KKUpdater/VersionInfo.c:281 (.ctor)
        // gốc body: System_Object___ctor(this, 0); — chain to base.
        public VersionInfo() { }
    }
}
