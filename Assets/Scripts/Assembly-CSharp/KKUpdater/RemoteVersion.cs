// Class:  KKUpdater.RemoteVersion + nested JsonVersionInfo
// GUID:   db83ba24538b91a6c2b0c4e689e4d675 (preserved via .meta)
// Source: KTO_DecompiledReference/KKUpdater/RemoteVersion.c (5 methods, 273 LOC)
//         + KTO_DecompiledReference/KKUpdater.RemoteVersion/{
//             JsonVersionInfo.c, _GetRemoteVersion_d__8.c (243 LOC),
//             _TryGetVersionInfo_d__7.c (210 LOC),
//             __c__DisplayClass8_0.c (62 LOC) }
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1382 + 1378)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.
//
// CLASS-LEVEL DEVIATION:
// - LitJson.JsonMapper.ToObject<JsonVersionInfo>(content) → uses our LitJson facade backed by Newtonsoft.
// - I2.Loc.ScriptLocalization.UnableConnectServer / QuitGame routes through our shim.
// - UIModule.ShowMsgBox already-ported in Phase 5 re-port.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using I2.Loc;
using LitJson;
using UnityEngine;
using UnityEngine.Networking;

namespace KKUpdater
{
    public class RemoteVersion
    {
        // Nested class — Source: KKUpdater.RemoteVersion/JsonVersionInfo.c
        // gốc body: Object__ctor only — fields hold parsed JSON shape from server.
        public class JsonVersionInfo
        {
            public int baseVersion;                              // 0x10
            public int updateVersion;                            // 0x14
            public int kto;                                      // 0x18
            public int waitingDlc;                               // 0x1C
            public string blockMsg;                              // 0x20
            public int newUpdate;                                // 0x28
            public string updateMsg;                             // 0x30
            public Dictionary<string, int[]> downloadConfig;     // 0x38
            public Dictionary<string, string> newPackageUrl;     // 0x40
            public string packageUrl;                            // 0x48

            // VMA: 0x01bc8a6f
            public JsonVersionInfo() { }
        }

        // Fields (offsets từ dump.cs)
        public Dictionary<string, VersionInfo> remoteVersionInfo;   // 0x10
        private const int _MIN_TIME_OUT = 30;
        private string _mainUrl;                                    // 0x18
        private string _backupUrl;                                  // 0x20
        public bool isDone;                                         // 0x28

        // VMA: 0x01bc8174 — Source: RemoteVersion.c:15 (GetPackageUrl)
        // gốc body:
        //   string winner = "";
        //   uint maxVer = 0;
        //   foreach (KeyValuePair<string, VersionInfo> kvp in remoteVersionInfo) {
        //     uint v = kvp.Value.MainVersion2Uint();
        //     if (v > maxVer) { winner = kvp.Value.GetUpdateUrlByIdentifier(); maxVer = v; }
        //   }
        //   return winner;
        public string GetPackageUrl()
        {
            string winner = "";
            uint maxVer = 0;
            if (remoteVersionInfo == null) return winner;
            foreach (var kvp in remoteVersionInfo)
            {
                if (kvp.Value == null) continue;
                uint v;
                try { v = kvp.Value.MainVersion2Uint(); }
                catch { continue; }
                if (v > maxVer)
                {
                    winner = kvp.Value.GetUpdateUrlByIdentifier();
                    maxVer = v;
                }
            }
            return winner;
        }

        // VMA: 0x01bc8325 — Source: RemoteVersion.c:87 (.ctor(string,string))
        // gốc body:
        //   System_Object___ctor(this, 0);
        //   _mainUrl = versionUrl;
        //   _backupUrl = versionBackupUrl;
        //   remoteVersionInfo = new Dictionary<string, VersionInfo>();
        public RemoteVersion(string versionUrl, string versionBackupUrl)
        {
            _mainUrl = versionUrl;
            _backupUrl = versionBackupUrl;
            remoteVersionInfo = new Dictionary<string, VersionInfo>();
        }

        // VMA: 0x01bc83a7 — Source: RemoteVersion.c:117 (TryGetVersionInfo factory)
        // <TryGetVersionInfo>d__7.MoveNext (KKUpdater.RemoteVersion/_TryGetVersionInfo_d__7.c:51):
        //   isDone = false;
        //   KUpdaterMgr.WriteLog("RemoteVersion", "url=" + url);
        //   UnityWebRequest req = UnityWebRequest.Get(url);
        //   req.timeout = 30 (_MIN_TIME_OUT);
        //   yield return req.SendWebRequest();
        //   if (req.result == ConnectionError || req.result == ProtocolError) {
        //     KUpdaterMgr.WriteLog("RemoteVersion", string.Format("err={0} url={1}", req.error, url));
        //     req.Abort();
        //     yield break;
        //   }
        //   if (req.isDone) {
        //     byte[] data = req.downloadHandler.data;
        //     string content = Encoding.UTF8.GetString(data);
        //     req.Dispose();
        //     if (ParseRemoteVersion(content)) isDone = true;
        //   }
        private IEnumerator TryGetVersionInfo(string url)
        {
            isDone = false;
            KUpdaterMgr.WriteLog("RemoteVersion", "url=" + url);
            using (var req = UnityWebRequest.Get(url))
            {
                req.timeout = _MIN_TIME_OUT;
                yield return req.SendWebRequest();
                if (req.result == UnityWebRequest.Result.ConnectionError
                    || req.result == UnityWebRequest.Result.ProtocolError)
                {
                    KUpdaterMgr.WriteLog("RemoteVersion",
                        string.Format("err={0} url={1}", req.error, url));
                    req.Abort();
                    yield break;
                }
                if (req.isDone)
                {
                    byte[] data = req.downloadHandler != null ? req.downloadHandler.data : null;
                    string content = data != null ? Encoding.UTF8.GetString(data) : null;
                    if (!string.IsNullOrEmpty(content))
                    {
                        if (ParseRemoteVersion(content)) isDone = true;
                    }
                }
            }
        }

        // VMA: 0x01bc841b — Source: RemoteVersion.c:145 (GetRemoteVersion factory)
        // <GetRemoteVersion>d__8.MoveNext (KKUpdater.RemoteVersion/_GetRemoteVersion_d__8.c:51):
        //   STATE 0:
        //     KUpdaterMgr.WriteLog("RemoteVersion", "GetRemoteVersion start");
        //     if (Application.internetReachability == NotReachable)
        //         KUpdaterMgr.WriteLog("RemoteVersion", "no internet");
        //     timeStamp = TimeHelper.GetTimeStampSeconds();
        //     yield return CoroutineManager.StartCor(TryGetVersionInfo(_mainUrl + "?_=" + timeStamp));
        //   STATE 1:
        //     if (!isDone)
        //         yield return CoroutineManager.StartCor(TryGetVersionInfo(_backupUrl + "?_=" + timeStamp));
        //   STATE 2:
        //     if (!isDone) {
        //       <>c__DisplayClass8_0 dc = new ();
        //       dc.waiting = true;
        //       KUpdaterMgr.WriteLog("RemoteVersion", "Both urls failed — show error");
        //       UIModule.ShowMsgBox(I2.Loc.ScriptLocalization.UnableConnectServer,
        //                           I2.Loc.ScriptLocalization.QuitGame, dc.<GetRemoteVersion>b__0);
        //     }
        //   STATE 3 (loop while waiting):
        //     while (dc.waiting) yield return null;
        //
        // The state machine mixes states 0/1/2/3 — we collapse into idiomatic C# yield block.
        public IEnumerator GetRemoteVersion()
        {
            KUpdaterMgr.WriteLog("RemoteVersion", "GetRemoteVersion start");
            if (Application.internetReachability == NetworkReachability.NotReachable)
                KUpdaterMgr.WriteLog("RemoteVersion", "no internet");

            int timeStamp = TimeHelper.GetTimeStampSeconds();

            // gốc fmt: "?_={0}"  (DAT_03599ca8 = "?_={0}")
            string mainQ = _mainUrl + string.Format("?_={0}", timeStamp);
            // STATE 0 — issue main request
            // gốc uses CoroutineManager.StartCor + yield return result (which is null since StartCor returns void).
            // We yield directly the IEnumerator so behavior matches: yield-return-coroutine waits until inner finishes.
            yield return TryGetVersionInfo(mainQ);

            if (!isDone)
            {
                // STATE 1 — backup request
                string backupQ = _backupUrl + string.Format("?_={0}", timeStamp);
                yield return TryGetVersionInfo(backupQ);
            }

            if (!isDone)
            {
                // STATE 2 — both URLs failed → modal dialog
                bool waiting = true;
                KUpdaterMgr.WriteLog("RemoteVersion", "Both urls failed — show error");
                UIModule.ShowMsgBox(
                    ScriptLocalization.UnableConnectServer,
                    ScriptLocalization.QuitGame,
                    () => { waiting = false; KUpdaterMgr.Instance.Quit(); });

                // STATE 3 — wait until dialog clicked
                while (waiting) yield return null;
            }
        }

        // VMA: 0x01bc8489 — Source: RemoteVersion.c:174 (ParseRemoteVersion)
        // gốc body:
        //   Dictionary<string, JsonVersionInfo> dict =
        //       LitJson.JsonMapper.ToObject<Dictionary<string, JsonVersionInfo>>(szContent);
        //   foreach (KeyValuePair<string, JsonVersionInfo> kvp in dict) {
        //     VersionInfo vi = new VersionInfo();
        //     vi.MainVersion = kvp.Value.<key>;             // gốc auVar4._0_8_ (kvp.Key)
        //     vi.UdpateVersion = kvp.Value.updateVersion;   // 0x14
        //     vi.IsShenhe = (kvp.Value.kto == 1);           // 0x18
        //     vi.WaitingDlc = (kvp.Value.waitingDlc == 1);  // 0x1C
        //     vi.BlockMsg = kvp.Value.blockMsg;             // 0x20
        //     vi.PackageUrl = kvp.Value.packageUrl;         // 0x48
        //     vi.NewPackageUrl = kvp.Value.newPackageUrl;   // 0x40
        //     vi.DownloadConfig = kvp.Value.downloadConfig; // 0x38
        //     vi.NewUpdate = kvp.Value.newUpdate;           // 0x28
        //     vi.UpdateMsg = kvp.Value.updateMsg;           // 0x30
        //     remoteVersionInfo[kvp.Key] = vi;
        //   }
        //   return true;
        // ⚠ gốc bug: vi.MainVersion (0x10) is set from kvp.Key (the dictionary key, e.g. "android")
        //     and not from any version-string field. Preserved.
        public bool ParseRemoteVersion(string szContent)
        {
            var dict = JsonMapper.ToObject<Dictionary<string, JsonVersionInfo>>(szContent);
            if (dict == null) return false;
            foreach (var kvp in dict)
            {
                var v = kvp.Value;
                if (v == null) continue;
                var vi = new VersionInfo
                {
                    MainVersion = kvp.Key, // gốc preserved
                    UdpateVersion = v.updateVersion,
                    IsShenhe = (v.kto == 1),
                    WaitingDlc = (v.waitingDlc == 1),
                    BlockMsg = v.blockMsg,
                    PackageUrl = v.packageUrl,
                    NewPackageUrl = v.newPackageUrl,
                    DownloadConfig = v.downloadConfig,
                    NewUpdate = v.newUpdate,
                    UpdateMsg = v.updateMsg,
                };
                if (remoteVersionInfo == null)
                    remoteVersionInfo = new Dictionary<string, VersionInfo>();
                remoteVersionInfo[kvp.Key] = vi;
            }
            return true;
        }
    }
}
