// Class:  KKUpdater.UpdaterState (enum)
// Source: KTO_DecompiledReference/_root + KiemTheOrigin_DeepExtract Cpp2IL stub
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1390)
//
// FULL 1-1 PORT 2026-04-25 — verified against Cpp2IL stub.

namespace KKUpdater
{
    public enum UpdaterState
    {
        emDolphin = 0,            // initial idle
        emCheckVersion = 1,       // RemoteVersion.GetRemoteVersion in flight
        emWaitForAgreeUpdate = 2, // dialog asking user to download
        emDownloadFile = 3,       // DoUpdate active (UnityWebRequest streaming)
        emDecompress = 4,         // unpack APK assets (first install)
        emCopyFile = 5,           // first-unpack StreamingAssets → persistent
        emLoading = 6,            // PatchFileList re-load after update
        emDone = 7,               // all done, hand off to KKBoot
        emError = 8,              // fatal — show ErrorDialog
    }
}
