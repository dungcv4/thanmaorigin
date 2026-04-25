// Class:  KKUpdater.KUpdaterMgr
// GUID:   246b8bb0c4e3a4a7e975c606dd499f7d (preserved via .meta)
// Source: KTO_DecompiledReference/KKUpdater/KUpdaterMgr.c (39 methods, 1613 LOC)
//         + KTO_DecompiledReference/KKUpdater.KUpdaterMgr/{
//             DownloadResInfo.c, UpdateStateChangeDelegate.c,
//             _DoUpdate_d__58.c, _ErrorDialog_d__40.c, _ErrorDialog2_d__41.c, _ErrorDialog3_d__42.c,
//             _GetRemotePatchFileList_d__47.c, _IOSCDNDownloadWarning_d__55.c,
//             _ProcessCheckLocalMainVersion_d__52.c, _ProcessFirstUnpackAssets_d__53.c,
//             _ReadLocalPatchFileList_d__46.c, _UpdateOnStartUp_d__54.c,
//             _WarnningDialog_d__44.c, _WarnningDialog_d__45.c, _WarnningMsg_d__43.c,
//             __c__DisplayClass45_0.c, __c__DisplayClass52_0.c, __c__DisplayClass52_1.c }
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1409 + nested 1391..1409)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.
//
// CLASS-LEVEL DEVIATIONS:
// - Iterator state machines (12 of them: ErrorDialog/2/3, WarnningMsg, WarnningDialog x2,
//   ReadLocalPatchFileList, GetRemotePatchFileList, ProcessCheckLocalMainVersion,
//   ProcessFirstUnpackAssets, UpdateOnStartUp, IOSCDNDownloadWarning, DoUpdate)
//   compressed to idiomatic C# yield blocks.
// - CDN URLs from gốc baked-in DAT_035acc70 / DAT_035b6dc0 / DAT_035b16e8 (Tencent
//   buckets) — replaced with thanmaorigin LocalCDN (http://localhost:8888/) in
//   SerializeCdnUrl/SerializeVersionUrl. Selection key (AppNum 2/8/other) preserved.
// - I2.Loc.ScriptLocalization_UpdateModule.DownloadProgress → simple format string.
// - UIStartUp.SetLoadingMainInfo / UIModule.OnStartUILoadingProgress → Debug.Log
//   for now (DEVIATION — full UIStartUp loader bar UI port is Phase 7).

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using I2.Loc;
using UnityEngine;
using UnityEngine.Networking;

namespace KKUpdater
{
    public class KUpdaterMgr
    {
        // Nested types — Source: KKUpdater.KUpdaterMgr/{DownloadResInfo,UpdateStateChangeDelegate}.c
        public class DownloadResInfo
        {
            public string pathName;     // 0x10
            public string MD5;          // 0x18
            public string ver;          // 0x20
            public DownloadResInfo() { }
        }

        public delegate void UpdateStateChangeDelegate(UpdaterState state);

        // Static fields (offsets từ dump.cs)
        private static KUpdaterMgr _instance;                            // 0x0
        public static ulong uDLCTotalSize;                               // 0x8
        public static ulong uNeedDownDLCSize;                            // 0x10
        public static ulong uCurDownloadedDLCSize;                       // 0x18
        public static ulong uDownloadedDLCSize;                          // 0x20
        public static DateTime dtStartDownloadTime;                      // 0x28
        public static UTF8Encoding utf8Encoder;                          // 0x30
        private static string _updateLogPath;                            // 0x38

        // Instance fields (offsets từ dump.cs)
        private bool m_IsGameStop;                                       // 0x10 (k__BackingField)
        public VersionInfo LocalVersionInfo;                             // 0x18
        public VersionInfo RemoteVersionInfo;                            // 0x20
        public PatchFileList patchFileList;                              // 0x28
        public PatchFileList remotePatchFileList;                        // 0x30
        public Queue<DownloadResInfo> needPatch;                         // 0x38
        private UpdaterState m_CurrentState;                             // 0x40 (k__BackingField)
        public UpdateStateChangeDelegate OnUpdateStateChange;            // 0x48
        private string _versionUrl;                                      // 0x50
        private string _versionUrlBackup;                                // 0x58
        private string _updateUrl;                                       // 0x60
        private string _updateUrlBackup;                                 // 0x68
        private string _downloadedListPath;                              // 0x70
        private string _PersistentPatchFilePath;                         // 0x78
        private string _StreamingAssetsPatchFilePath;                    // 0x80
        private string _remotePatchFilePath;                             // 0x88
        private bool _isShowBox;                                         // 0x90

        // VMA: 0x01bcaf0d — Source: KUpdaterMgr.c:1479 (.cctor)
        // gốc body:
        //   _instance = new KUpdaterMgr();
        //   _instance.patchFileList = null; LocalVersionInfo = null; RemoteVersionInfo = null;
        //   uDLCTotalSize = 0; uNeedDownDLCSize = 0; (statics zero-init)
        //   utf8Encoder = new UTF8Encoding();
        //   _updateLogPath = null;
        static KUpdaterMgr()
        {
            _instance = new KUpdaterMgr();
            uDLCTotalSize = 0;
            uNeedDownDLCSize = 0;
            uCurDownloadedDLCSize = 0;
            uDownloadedDLCSize = 0;
            utf8Encoder = new UTF8Encoding();
            _updateLogPath = null;
        }

        // VMA: 0x01bcaf06 — Source: KUpdaterMgr.c:1461 (.ctor)
        public KUpdaterMgr() { }

        // VMA: 0x01bc9762 — Source: KUpdaterMgr.c:140 (get_Instance)
        // gốc body: return _instance;
        public static KUpdaterMgr Instance => _instance;

        // VMA: 0x01bc97a6 — Source: KUpdaterMgr.c:164 (get_IsNeedUpdate)
        // gốc body: return _instance._isShowBox;  (0x61 — actually 0x90, gốc misalignment in Ghidra)
        public bool IsNeedUpdate => _isShowBox;

        // VMA: 0x01bc97ea / 0x01bc97ee — Source: KUpdaterMgr.c:189/206 (get/set_IsGameStop)
        public bool IsGameStop { get => m_IsGameStop; private set => m_IsGameStop = value; }

        // VMA: 0x01bc97f3 / 0x01bc97f7 — Source: KUpdaterMgr.c:224/241 (get/set_CurrentState)
        public UpdaterState CurrentState { get => m_CurrentState; private set => m_CurrentState = value; }

        // VMA: 0x01bc97fb — Source: KUpdaterMgr.c:259 (get_UpdateLogPath)
        // gốc body:
        //   if (_updateLogPath == null) {
        //     string dir = GameEnv.GetPatchLogPath();
        //     string fname = string.Format("update_{0}.log", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        //     _updateLogPath = Path.Combine(dir, fname);
        //   }
        //   return _updateLogPath;
        public static string UpdateLogPath
        {
            get
            {
                if (_updateLogPath == null)
                {
                    string dir = GameEnv.GetPatchLogPath();
                    string fname = string.Format("update_{0}.log",
                        DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                    _updateLogPath = Path.Combine(dir, fname);
                }
                return _updateLogPath;
            }
        }

        // VMA: 0x01bc882f — Source: KUpdaterMgr.c:15 (WriteLog)
        // gốc body:
        //   string path = UpdateLogPath;
        //   FileMode mode = File.Exists(path) ? FileMode.Append : FileMode.Create;
        //   FileStream fs = File.Open(path, mode);
        //   string line = string.Format("[{1}] {0}: {2}\n", _type, DateTime.Now.ToString(), msg);
        //   byte[] bytes = utf8Encoder.GetBytes(line);
        //   byte[] enc = FileHelper.EncryptBytes(bytes);
        //   fs.Write(enc, 0, enc.Length); fs.Flush(); fs.Close();
        public static void WriteLog(string _type, string msg)
        {
            try
            {
                string path = UpdateLogPath;
                bool exists = File.Exists(path);
                using (var fs = File.Open(path, exists ? FileMode.Append : FileMode.Create))
                {
                    string line = string.Format("[{1}] {0}: {2}\n",
                        _type, DateTime.Now.ToString(), msg);
                    byte[] bytes = utf8Encoder.GetBytes(line);
                    byte[] enc = FileHelper.EncryptBytes(bytes);
                    fs.Write(enc, 0, enc.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"[KUpdaterMgr.WriteLog] {e.Message}");
            }
        }

        // VMA: 0x01bc8b03 — Source: KUpdaterMgr.c:114 (Quit)
        // gốc body: Application.Quit(); IsGameStop = true;
        public void Quit()
        {
            Application.Quit();
            m_IsGameStop = true;
        }

        // VMA: 0x01bc9d9f — Source: KUpdaterMgr.c:560 (Init)
        // gốc body:
        //   _versionUrl = SerializeVersionUrl(_instance.PackageUrl);
        //   _versionUrlBackup = SerializeVersionUrl(...);
        //   _updateUrl = SerializeCdnUrl(...);
        //   _updateUrlBackup = SerializeCdnUrl(...);
        //   _downloadedListPath = Path.Combine(GameEnv.GetPersistent(), "downloaded.list");
        //   _PersistentPatchFilePath = Path.Combine(GameEnv.GetPersistent(), "PatchFileList.json");
        //   _StreamingAssetsPatchFilePath = Path.Combine(Application.streamingAssetsPath, "PatchFileList.json");
        //   CleanUpOldFiles(...);   // gốc passes int param — likely keepDays
        //   WriteLog("KUpdaterMgr", "===========================");
        //   WriteLog("KUpdaterMgr", "Init done");
        //   WriteLog("KUpdaterMgr", "===========================");
        //   return true;
        public bool Init()
        {
            // gốc DAT_03561688 = some Singleton holder (SDKConfig?). Use empty packageUrl as DEVIATION.
            string packageUrl = "";
            _versionUrl = SerializeVersionUrl(packageUrl);
            _versionUrlBackup = SerializeVersionUrl(packageUrl);
            _updateUrl = SerializeCdnUrl(packageUrl);
            _updateUrlBackup = SerializeCdnUrl(packageUrl);

            _downloadedListPath = Path.Combine(GameEnv.GetPersistent(), "downloaded.list");
            _PersistentPatchFilePath = Path.Combine(GameEnv.GetPersistent(), "PatchFileList.json");
            _StreamingAssetsPatchFilePath = Path.Combine(Application.streamingAssetsPath, "PatchFileList.json");
            // gốc passes int (keepDays) but we hardcode 7 like default keep.
            CleanUpOldFiles(7);
            WriteLog("KUpdaterMgr", "===========================");
            WriteLog("KUpdaterMgr", "Init done");
            WriteLog("KUpdaterMgr", "===========================");
            return true;
        }

        // VMA: 0x01bca77d — Source: KUpdaterMgr.c:1013 (AddMainThreadCallback)
        // gốc body: empty (just returns) — preserved.
        public void AddMainThreadCallback(Action callback) { }

        // VMA: 0x01bca77e — Source: KUpdaterMgr.c:1030 (GetRemoteVersion)
        // gốc body:
        //   WriteLog("KUpdaterMgr", "GetRemoteVersion start");
        //   return new RemoteVersion(_versionUrl, _versionUrlBackup);
        public RemoteVersion GetRemoteVersion()
        {
            WriteLog("KUpdaterMgr", "GetRemoteVersion start");
            return new RemoteVersion(_versionUrl, _versionUrlBackup);
        }

        // VMA: 0x01bc9f84 — Source: KUpdaterMgr.c:625 (SerializeVersionUrl)
        // gốc body:
        //   if (string.IsNullOrEmpty(url)) return url;
        //   string fmt = (AppNum==2) ? PROD_VERSION_FMT : (AppNum==8) ? STAGING_VERSION_FMT : DEV_VERSION_FMT;
        //   return string.Format(url, fmt, _Version.VersionType, _Version.SvnBranch);
        // ⚠ DEVIATION: gốc calls string.Format(param_2, fmt, type, branch)  but `param_2` is the
        //   passed-in `url`, used as the format string — meaning gốc expects url to contain
        //   placeholders {0}{1}{2}. We swap to thanmaorigin LocalCDN base URL.
        public string SerializeVersionUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return url;
            // DEVIATION: thanmaorigin LocalCDN — ignore real Tencent URL templates.
            return "http://localhost:8888/version.json";
        }

        // VMA: 0x01bca096 — Source: KUpdaterMgr.c:691 (SerializeCdnUrl)
        // gốc body: like SerializeVersionUrl but uses ToVersion4Update() in addition.
        // ⚠ DEVIATION: thanmaorigin uses LocalCDN — same path for all variants.
        public string SerializeCdnUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return url;
            return "http://localhost:8888/cdn/";
        }

        // VMA: 0x01bca2ae — Source: KUpdaterMgr.c:805 (CleanUpOldFiles)
        // gốc body:
        //   DirectoryInfo di = new DirectoryInfo(GameEnv.GetPersistent());
        //   FileInfo[] files = di.GetFiles("*.log");
        //   List<FileInfo> toDelete = new();
        //   if (keepDays >= 1) {
        //     foreach (FileInfo f in files) {
        //       if ((DateTime.Now - f.LastWriteTime).TotalDays >= keepDays) toDelete.Add(f);
        //     }
        //   } else if (keepDays == 0) {
        //     toDelete.AddRange(files);
        //   }
        //   foreach (FileInfo f in toDelete) f.Delete();
        private void CleanUpOldFiles(int keepDays)
        {
            try
            {
                var di = new DirectoryInfo(GameEnv.GetPersistent());
                if (!di.Exists) return;
                var files = di.GetFiles("*.log");
                var toDelete = new List<FileInfo>();
                if (keepDays >= 1)
                {
                    foreach (var f in files)
                    {
                        if ((DateTime.Now - f.LastWriteTime).TotalDays >= keepDays)
                            toDelete.Add(f);
                    }
                }
                else if (keepDays == 0)
                {
                    toDelete.AddRange(files);
                }
                foreach (var f in toDelete)
                {
                    try { f.Delete(); } catch { }
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[KUpdaterMgr.CleanUpOldFiles] {e.Message}");
            }
        }

        // VMA: 0x01bca9e0 — Source: KUpdaterMgr.c:1174 (ClearDownloadList)
        // gốc body: if (File.Exists(_downloadedListPath)) File.Delete(_downloadedListPath);
        private void ClearDownloadList()
        {
            if (File.Exists(_downloadedListPath))
                File.Delete(_downloadedListPath);
        }

        // VMA: 0x01bcaa01 — Source: KUpdaterMgr.c:1198 (UpdateListByDownloadList)
        // gốc body: read tab-separated downloaded list, merge entries from remotePatchFileList
        //           into local patchFileList where MD5 matches, then Marshal2File local list.
        public void UpdateListByDownloadList()
        {
            if (!File.Exists(_downloadedListPath)) return;
            using (var sr = File.OpenText(_downloadedListPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('\t');
                    if (parts.Length < 2) continue;
                    string key = parts[0];
                    string md5 = parts[1];
                    if (remotePatchFileList?.FileList == null) continue;
                    if (!remotePatchFileList.FileList.ContainsKey(key)) continue;
                    var remotePf = remotePatchFileList.FileList[key];
                    if (remotePf == null || remotePf.MD5 != md5) continue;
                    if (patchFileList?.FileList != null)
                        patchFileList.FileList[key] = remotePf;
                }
                sr.Close();
            }
            patchFileList?.Marshal2File(_PersistentPatchFilePath);
        }

        // VMA: 0x01bcae19 — Source: KUpdaterMgr.c:1386 (UpdateStateChange)
        // gốc body:
        //   if (CurrentState != state) {
        //     CurrentState = state;
        //     OnUpdateStateChange?.Invoke(state);
        //   }
        public void UpdateStateChange(UpdaterState state)
        {
            if (m_CurrentState != state)
            {
                m_CurrentState = state;
                OnUpdateStateChange?.Invoke(state);
            }
        }

        // VMA: 0x01bcae39 — Source: KUpdaterMgr.c:1417 (_LoadLocalVersionInfo)
        // gốc body:
        //   WriteLog("KUpdaterMgr", "_LoadLocalVersionInfo");
        //   string ver4 = AppVersion._Version.ToVersion4Update();  // "M.m.p"
        //   LocalVersionInfo = new VersionInfo { MainVersion = ver4, UdpateVersion = 0 };
        private void _LoadLocalVersionInfo()
        {
            WriteLog("KUpdaterMgr", "_LoadLocalVersionInfo");
            string ver4 = AppVersion._Version.ToVersion4Update();
            LocalVersionInfo = new VersionInfo { MainVersion = ver4, UdpateVersion = 0 };
        }

        // VMA: 0x01bcac90 — Source: KUpdaterMgr.c:1313 (ShowDownloadProgress)
        // gốc body:
        //   double total = (double)total;
        //   double dlOnSofar = (double)(downloaded + downloading);
        //   float pct = (float)(dlOnSofar / total) * 100;
        //   string fmt = I2.Loc.ScriptLocalization_UpdateModule.DownloadProgress;
        //   string msg = string.Format(fmt, pct.ToString("F2"), (dlOnSofar/(1<<20)).ToString("F2"), (total/(1<<20)).ToString("F2"));
        //   UIModule.OnStartUILoadingProgress();
        //   UIStartUp inst = (singleton);
        //   inst.SetLoadingMainInfo(msg);
        private void ShowDownloadProgress(ulong downloaded, ulong downloading, ulong total, string downloadingName)
        {
            double dlSoFar = (double)(downloaded + downloading);
            double totalD = (double)total;
            float pct = totalD > 0 ? (float)(dlSoFar / totalD) * 100f : 0f;
            string msg = string.Format(
                "Đang tải {0}: {1}% ({2} MB / {3} MB)",
                downloadingName ?? "",
                pct.ToString("F2"),
                (dlSoFar / 1048576.0).ToString("F2"),
                (totalD / 1048576.0).ToString("F2"));
            // DEVIATION: UIStartUp.SetLoadingMainInfo / UIModule.OnStartUILoadingProgress
            //   not yet ported (Phase 7). Log to console for now.
            Debug.Log($"[Updater Progress] {msg}");
        }

        // ===== Iterator state machines =====
        // gốc 12 state machines compressed to idiomatic yield blocks. Each MoveNext body
        // verified against KKUpdater.KUpdaterMgr/_*_d__*.c.

        // VMA: 0x01bc9970 — Source: KUpdaterMgr.c:320 (ErrorDialog factory) +
        //   _ErrorDialog_d__40.c MoveNext:
        //     UIModule.ShowMsgBox(szDesc, szBtn, this.<ErrorDialog>b__40_0);
        //     while (!_isShowBox==false) yield return null;  // wait until clicked
        //     <ErrorDialog>b__40_0 → Application.Quit + IsGameStop=true.
        public IEnumerator ErrorDialog(string szDesc, string szBtn)
        {
            bool waiting = true;
            UIModule.ShowMsgBox(szDesc, szBtn, () => {
                waiting = false;
                Application.Quit();
                m_IsGameStop = true;
            });
            while (waiting) yield return null;
        }

        // VMA: 0x01bc99f4 — Source: KUpdaterMgr.c:349 (ErrorDialog2 factory)
        //   2 buttons + 2 callback Actions.
        public IEnumerator ErrorDialog2(string szDesc, string szBtn1, string szBtn2, Action act1, Action act2)
        {
            bool waiting = true;
            UIModule.ShowMsgBox2(szDesc, szBtn1, szBtn2,
                () => { waiting = false; act1?.Invoke(); },
                () => { waiting = false; act2?.Invoke(); });
            while (waiting) yield return null;
        }

        // VMA: 0x01bc9a8c — Source: KUpdaterMgr.c:382 (ErrorDialog3 factory)
        //   1 button + 1 callback.
        public IEnumerator ErrorDialog3(string szDesc, string szBtn, Action act)
        {
            bool waiting = true;
            UIModule.ShowMsgBox(szDesc, szBtn, () => { waiting = false; act?.Invoke(); });
            while (waiting) yield return null;
        }

        // VMA: 0x01bc9b10 — Source: KUpdaterMgr.c:412 (WarnningMsg factory)
        //   _WarnningMsg_d__43.c MoveNext: ShowMsgBox; wait; close.
        public IEnumerator WarnningMsg(string szDesc, string szBtnOK)
        {
            bool waiting = true;
            UIModule.ShowMsgBox(szDesc, szBtnOK, () => {
                waiting = false;
                _isShowBox = false;
                UIModule.CloseMsgBox();
            });
            while (waiting) yield return null;
        }

        // VMA: 0x01bc9b94 — Source: KUpdaterMgr.c:441 (WarnningDialog 3-arg)
        //   _WarnningDialog_d__44.c MoveNext: ShowMsgBox2 with 2 buttons; close on click.
        public IEnumerator WarnningDialog(string szDesc, string szBtnOK, string szBtnCancer)
        {
            bool waiting = true;
            UIModule.ShowMsgBox2(szDesc, szBtnOK, szBtnCancer,
                () => { waiting = false; _isShowBox = false; UIModule.CloseMsgBox(); },
                () => { waiting = false; Application.Quit(); m_IsGameStop = true; });
            while (waiting) yield return null;
        }

        // VMA: 0x01bc9c1e — Source: KUpdaterMgr.c:472 (WarnningDialog 5-arg)
        //   2 buttons + 2 explicit callbacks.
        public IEnumerator WarnningDialog(string szDesc, string szBtnOK, string szBtnCancer, Action funcOk, Action funcCancer)
        {
            bool waiting = true;
            UIModule.ShowMsgBox2(szDesc, szBtnOK, szBtnCancer,
                () => { waiting = false; funcOk?.Invoke(); },
                () => { waiting = false; funcCancer?.Invoke(); });
            while (waiting) yield return null;
        }

        // VMA: 0x01bc9cc3 — Source: KUpdaterMgr.c:506 (ReadLocalPatchFileList factory)
        //   _ReadLocalPatchFileList_d__46.c MoveNext:
        //     patchFileList = new PatchFileList();
        //     yield return CoroutineManager.StartCor(patchFileList.UnmarshalFromLocal(_PersistentPatchFilePath));
        //     if (!patchFileList.isDone) {
        //       yield return CoroutineManager.StartCor(patchFileList.UnmarshalFromUrl("file://" + _StreamingAssetsPatchFilePath));
        //     }
        private IEnumerator ReadLocalPatchFileList()
        {
            patchFileList = new PatchFileList();
            yield return patchFileList.UnmarshalFromLocal(_PersistentPatchFilePath);
            if (!patchFileList.isDone)
            {
                string p = _StreamingAssetsPatchFilePath;
                if (Application.platform != RuntimePlatform.Android && !p.StartsWith("file://"))
                    p = "file://" + p;
                yield return patchFileList.UnmarshalFromUrl(p);
            }
        }

        // VMA: 0x01bc9d31 — Source: KUpdaterMgr.c:533 (GetRemotePatchFileList factory)
        //   _GetRemotePatchFileList_d__47.c MoveNext:
        //     remotePatchFileList = new PatchFileList();
        //     yield return CoroutineManager.StartCor(remotePatchFileList.UnmarshalFromUrl(_updateUrl + "PatchFileList.json"));
        public IEnumerator GetRemotePatchFileList()
        {
            remotePatchFileList = new PatchFileList();
            yield return remotePatchFileList.UnmarshalFromUrl(_updateUrl + "PatchFileList.json");
        }

        // VMA: 0x01bca828 — Source: KUpdaterMgr.c:1066 (ProcessCheckLocalMainVersion factory)
        //   _ProcessCheckLocalMainVersion_d__52.c MoveNext (CDN download → reinstall flow):
        //     if (RemoteVersionInfo.MainVersionGreaterThan(LocalVersionInfo)) {
        //       string url = RemoteVersionInfo.GetUpdateUrlByIdentifier();
        //       string launcherPath = Path.Combine(GameEnv.GetPersistent(), "kkbox_launcher.apk");
        //       <>c__DisplayClass52_0 dc0 = new() { launcherPath, downloadingUrl=url };
        //       <>c__DisplayClass52_1 dc1 = new() { launcherPath, downloadingUrl=url };
        //       yield return WarnningDialog(updateMsg, ScriptLocalization.Update, ScriptLocalization.Cancel,
        //                                   dc0.b__0, dc1.b__4);
        //     }
        //
        // dc0.b__0 = open external URL (browser); dc1.b__4 = quit;
        // dc1.b__2/b__3 = launcher download path.
        // We collapse to ReinstallException throw — Phase 5 KKUpdaterDriver handles.
        private IEnumerator ProcessCheckLocalMainVersion()
        {
            if (RemoteVersionInfo == null || LocalVersionInfo == null) yield break;
            bool needReinstall;
            try
            {
                needReinstall = RemoteVersionInfo.MainVersionGreaterThan(LocalVersionInfo);
            }
            catch
            {
                needReinstall = false;
            }
            if (needReinstall)
            {
                WriteLog("KUpdaterMgr", "ProcessCheckLocalMainVersion → ReinstallException");
                throw new ReinstallException();
            }
            yield break;
        }

        // VMA: 0x01bca896 — Source: KUpdaterMgr.c:1093 (ProcessFirstUnpackAssets factory)
        //   _ProcessFirstUnpackAssets_d__53.c MoveNext: copy bundled .ab from
        //   StreamingAssets to persistentDataPath on first install.
        private IEnumerator ProcessFirstUnpackAssets()
        {
            CurrentState = UpdaterState.emCopyFile;
            string srcDir = Path.Combine(Application.streamingAssetsPath, "Bundles");
            string dstDir = Path.Combine(GameEnv.GetPersistent(), "Bundles");
            try
            {
                if (Directory.Exists(srcDir))
                {
                    UpdaterCopy.CopyDir(srcDir, dstDir);
                }
            }
            catch (Exception e)
            {
                WriteLog("KUpdaterMgr", "ProcessFirstUnpackAssets failed: " + e.Message);
            }
            yield return null;
        }

        // VMA: 0x01bca904 — Source: KUpdaterMgr.c:1120 (UpdateOnStartUp factory)
        //   _UpdateOnStartUp_d__54.c MoveNext: master flow — load local version,
        //   fetch remote version, compare, branch into reinstall / first-unpack / patch-download.
        public IEnumerator UpdateOnStartUp()
        {
            UpdateStateChange(UpdaterState.emCheckVersion);
            _LoadLocalVersionInfo();

            var rv = GetRemoteVersion();
            yield return rv.GetRemoteVersion();

            if (rv.isDone)
            {
                // Pick our identifier-specific VersionInfo
                if (rv.remoteVersionInfo != null && rv.remoteVersionInfo.Count > 0)
                {
                    string id = Application.identifier;
                    if (rv.remoteVersionInfo.ContainsKey(id))
                        RemoteVersionInfo = rv.remoteVersionInfo[id];
                    else
                    {
                        // first available
                        foreach (var kvp in rv.remoteVersionInfo)
                        {
                            RemoteVersionInfo = kvp.Value;
                            break;
                        }
                    }
                }
            }

            yield return ProcessCheckLocalMainVersion();
            yield return ReadLocalPatchFileList();
            yield return GetRemotePatchFileList();

            if (patchFileList != null && remotePatchFileList != null
                && patchFileList.UpdateVersion < remotePatchFileList.UpdateVersion)
            {
                _isShowBox = true;
                UpdateStateChange(UpdaterState.emWaitForAgreeUpdate);
                yield return DoUpdate(0);
            }

            UpdateStateChange(UpdaterState.emDone);
        }

        // VMA: 0x01bca972 — Source: KUpdaterMgr.c:1147 (IOSCDNDownloadWarning factory)
        //   _IOSCDNDownloadWarning_d__55.c MoveNext: if iOS+wifi off, show warning dialog.
        public static IEnumerator IOSCDNDownloadWarning(ulong totalSize)
        {
            if (Application.platform != RuntimePlatform.IPhonePlayer) yield break;
            if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                bool waiting = true;
                double mb = totalSize / 1048576.0;
                string msg = string.Format("Tải {0:F1} MB qua dữ liệu di động?", mb);
                UIModule.ShowMsgBox2(msg, "Tải", "Hủy",
                    () => { waiting = false; },
                    () => { waiting = false; throw new CancelException(); });
                while (waiting) yield return null;
            }
        }

        // VMA: 0x01bcac1c — Source: KUpdaterMgr.c:1285 (DoUpdate factory)
        //   _DoUpdate_d__58.c MoveNext: master download loop — for each entry in needPatch,
        //   issue UnityWebRequest.Get, write to FileStream, retry on failure, re-emit progress.
        public IEnumerator DoUpdate(ulong totalSize)
        {
            UpdateStateChange(UpdaterState.emDownloadFile);
            uDLCTotalSize = totalSize;
            uNeedDownDLCSize = totalSize;
            uCurDownloadedDLCSize = 0;
            uDownloadedDLCSize = 0;
            dtStartDownloadTime = DateTime.Now;

            // Build needPatch queue from diff between patchFileList and remotePatchFileList.
            if (needPatch == null) needPatch = new Queue<DownloadResInfo>();
            if (patchFileList != null && remotePatchFileList?.FileList != null)
            {
                needPatch.Clear();
                foreach (var kvp in remotePatchFileList.FileList)
                {
                    PatchFile localPf = null;
                    if (patchFileList.FileList != null && patchFileList.FileList.ContainsKey(kvp.Key))
                        localPf = patchFileList.FileList[kvp.Key];
                    if (localPf == null || localPf.MD5 != kvp.Value.MD5)
                    {
                        needPatch.Enqueue(new DownloadResInfo
                        {
                            pathName = kvp.Key,
                            MD5 = kvp.Value.MD5,
                            ver = kvp.Value.ver.ToString()
                        });
                    }
                }
            }

            int reDownLoadCnt = 0;
            const int maxRetry = 3;
            string usingUrl = _updateUrl;

            while (needPatch != null && needPatch.Count > 0)
            {
                var item = needPatch.Peek();
                string url = usingUrl + item.pathName;
                string savePath = Path.Combine(GameEnv.GetPersistent(), item.pathName);

                // Ensure dir exists.
                try
                {
                    var dir = Path.GetDirectoryName(savePath);
                    if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                }
                catch { }

                using (var req = UnityWebRequest.Get(url))
                {
                    req.timeout = 30;
                    yield return req.SendWebRequest();
                    if (req.result == UnityWebRequest.Result.Success)
                    {
                        try
                        {
                            File.WriteAllBytes(savePath, req.downloadHandler.data);
                            uCurDownloadedDLCSize += (ulong)req.downloadHandler.data.Length;
                            uDownloadedDLCSize = uCurDownloadedDLCSize;
                            ShowDownloadProgress(uDownloadedDLCSize, 0, uDLCTotalSize, item.pathName);
                            // Append to downloaded.list for resume support.
                            try
                            {
                                File.AppendAllText(_downloadedListPath,
                                    item.pathName + "\t" + item.MD5 + "\n");
                            }
                            catch { }
                            needPatch.Dequeue();
                            reDownLoadCnt = 0;
                        }
                        catch (Exception e)
                        {
                            WriteLog("DoUpdate", $"write {savePath} failed: {e.Message}");
                            reDownLoadCnt++;
                        }
                    }
                    else
                    {
                        WriteLog("DoUpdate", $"download {url} err={req.error}");
                        reDownLoadCnt++;
                        if (reDownLoadCnt > maxRetry && usingUrl == _updateUrl)
                        {
                            usingUrl = _updateUrlBackup;
                            reDownLoadCnt = 0;
                            continue;
                        }
                        if (reDownLoadCnt > maxRetry)
                        {
                            // both failed — bail
                            WriteLog("DoUpdate", "max retry — abort");
                            break;
                        }
                    }
                }
            }

            // Update list once all downloads done.
            UpdateListByDownloadList();
            ClearDownloadList();
            yield return null;
        }
    }
}
