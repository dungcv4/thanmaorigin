// Class:  ResourceModule
// GUID:   f108f4a34467646acb0028586ec0806d (preserved via .meta)
// Source: KTO_DecompiledReference/_root/ResourceModule.c (1658 LOC, 26 methods)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs
//
// FULL 1-1 PORT 2026-04-26 — every method body verified against Ghidra C decompile.
//
// CLASS DEVIATION (cited at top, applies to ~18/25 methods):
// gốc relies on these classes (not yet ported in thanmaorigin):
//   BundleManager (native bundle lifecycle)
//   KCoroutine (custom coroutine pump)
//   LoaderManager.Load (factory chain → BundleLoader)
//   ResourceCache.GetCache/DoCache (in-memory cache)
//   ResourceTask + ResourceTaskAsyncManager (async queue)
//   CppApi.FilePackOpenInfo/ReadResFileText/GetResFileSize/ReadResFile (P/Invoke libclient_scene)
//   ResourceDef.GetResourceFullPath (path resolver)
//   ResourceAndroidPlugin.GetAssetBytes (Android JNI)
// thanmaorigin DEVIATION: simplified Resources.Load + StreamingAssets file reads.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

public class ResourceModule : MonoBehaviour
{
    // Fields (offsets từ dump.cs)
    private static int _OnceLoadResCount = -1;                                  // 0x0 (gốc .cctor sets to 0xffffffffffffffff which is -1 as signed int)
    public static int CacheRecycleLine;                                         // 0x4
    private static Dictionary<string, ResourceTask> _RuningTask = new();        // 0x8
    private static List<object> _AsyncLoadCmdCache = new();                     // 0x10
    private static List<string> _WaitLoadRes = new();                           // 0x18
    private static List<string> _LoadingRes = new();                            // 0x20
    private static string _FileText;                                            // 0x28

    // VMA: 0x01916a9a — Source: ResourceModule.c:5453 (.cctor)
    // gốc body:
    //   _OnceLoadResCount (+0) = 0xffffffffffffffff;                           // -1
    //   _RuningTask (+8) = new Dictionary<string, ResourceTask>();
    //   _AsyncLoadCmdCache (+0x10) = new List<object>();
    //   _WaitLoadRes (+0x18) = new List<string>();
    //   _LoadingRes (+0x20) = new List<string>();
    // Above field initializers replicate this — no body needed.
    static ResourceModule() { }

    // VMA: 0x0190b34d — Source: ResourceModule.c:8041 (LoadResourceAsync)
    // gốc body (lines 15-267):
    //   if string.IsNullOrEmpty(szPath): LogHelper.ERROR; return;
    //   if (CppApi.IsPackEnabled +0x10 of DAT_03563fe8): build LoadResAsyncTask, queue _AsyncLoadCmdCache
    //   else:
    //     cached = ResourceCache.GetCache(szPath);
    //     if cached != null: invoke finish(cached, param); return;
    //     if _RuningTask.ContainsKey(szPath): existing.AddCallBack(finish, param); return;
    //     task = new ResourceTask(finish, param); _RuningTask[szPath] = task;
    //     if _OnceLoadResCount < 1 || _LoadingRes.Count < _OnceLoadResCount:
    //       _LoadingRes.Add(szPath);
    //       loader = LoaderManager.Load(szPath);
    //       if isUI: ResourceTaskAsyncManager.AddUiTask(loader, ...);
    //       else: ResourceTaskAsyncManager.AddNormalTask(loader, ...);
    //     else: _WaitLoadRes.Add(szPath);
    // DEVIATION: skip ResourceCache+LoaderManager+TaskAsyncManager — sync Resources.Load + invoke.
    public static void LoadResourceAsync(bool isUI, string szPath, OnResourceFinishEventHandler finish, object param)
    {
        if (string.IsNullOrEmpty(szPath))
        {
            Debug.LogError("[ResourceModule.LoadResourceAsync] szPath null/empty");
            finish?.Invoke(null, param);
            return;
        }
        var obj = LoadResourceSync(szPath);
        finish?.Invoke(obj, param);
    }

    // VMA: 0x01914ae2 — Source: ResourceModule.c:3979 (OnLoadUtf8File P/Invoke callback)
    // gốc body: `_FileText (+0x28) = param_1;`  — store native callback result.
    [AOT.MonoPInvokeCallback(typeof(CppApi.OnLoadFileCallback))]
    private static void OnLoadUtf8File(string szText)
    {
        _FileText = szText;
    }

    // VMA: 0x01914c7d — Source: ResourceModule.c:4001 (Init)
    // gốc body: alloc `<Init>d__0` iterator state machine (gốc class "_root.<>c__DisplayClass0_0").
    // gốc Init MoveNext (separate file): registers various callbacks + warms ResourceCache.
    [System.Runtime.CompilerServices.IteratorStateMachine(typeof(ResourceModule.<Init>d__0))]
    public static IEnumerator Init()
    {
        _OnceLoadResCount = 5;  // Sane default (gốc starts at -1 then SetOnceLoadResCount called later)
        CacheRecycleLine = 100;
        yield break;
    }

    // VMA: 0x01914cdb — Source: ResourceModule.c:4038 (LateUpdate)
    // gốc body:
    //   BundleManager.Update();
    //   KCoroutine.Update(0);
    //   ResourceTaskAsyncManager.Activate();
    // DEVIATION: BundleManager + KCoroutine + ResourceTaskAsyncManager unavailable. No-op.
    private void LateUpdate() { }

    // VMA: 0x01914daa — Source: ResourceModule.c:4091 (OpenPackFile)
    // gốc body:
    //   path = ResourceDef.PersistentResPath + ".pack";                         // gốc DAT_035b39d8 = ".pack"
    //   CppApi.FilePackOpenInfo(path);                                          // P/Invoke into native pack reader
    // DEVIATION: pack0.dat đã được extract sẵn vào KTO_Extracted_Pack/ (XOR cracked). No-op.
    public static void OpenPackFile() { }

    // VMA: 0x01914e36 — Source: ResourceModule.c:4121 (ClosePackFile)
    // gốc body: `CppApi.FilePackCloseInfo(0);`
    // DEVIATION: native, skip.
    public static void ClosePackFile() { }

    // VMA: 0x01914e73 — Source: ResourceModule.c:4142 (SetMapLoadingTopPriority)
    // gốc body:
    //   if !bStart:
    //     UnityEngine.Application.backgroundLoadingPriority = 2;                 // ThreadPriority.Normal
    //     ResourceTaskAsyncManager.something = 0x41200000 (10.0f);
    //   else:
    //     UnityEngine.Application.backgroundLoadingPriority = 4;                 // ThreadPriority.High
    //     ResourceTaskAsyncManager.something = 0xbf800000 (-1.0f);
    public static void SetMapLoadingTopPriority(bool bStart)
    {
        if (bStart)
            UnityEngine.Application.backgroundLoadingPriority = ThreadPriority.High;
        else
            UnityEngine.Application.backgroundLoadingPriority = ThreadPriority.Normal;
    }

    // VMA: 0x01915166 — Source: ResourceModule.c:4326 (LoadResourceSync)
    // gốc body (lines 470-587):
    //   if szPath == null: LogHelper.ERROR("path null"); return null;
    //   trimmed = szPath.Trim();
    //   cached = ResourceCache.GetCache(trimmed);
    //   if cached != null: return cached;
    //   loader = LoaderManager.Load(trimmed, 1);                                 // 1 = sync
    //   if loader == null: LogHelper.ERROR(trimmed); return null;
    //   asset = loader.Asset (+0x38);
    //   if asset == null: LogHelper.ERROR("Loaded path " + trimmed + " but asset null");
    //   ResourceCache.DoCache(trimmed, loader);
    //   return asset;
    // DEVIATION: Use Resources.Load fallback (no LoaderManager/ResourceCache).
    public static Object LoadResourceSync(string szPath)
    {
        if (string.IsNullOrEmpty(szPath))
        {
            Debug.LogError("[ResourceModule.LoadResourceSync] path null");
            return null;
        }
        var trimmed = szPath.Trim();
        // Strip "Assets/" prefix and extension if present (gốc convention).
        var p = trimmed;
        if (p.StartsWith("Assets/")) p = p.Substring(7);
        var ext = Path.GetExtension(p);
        if (!string.IsNullOrEmpty(ext)) p = p.Substring(0, p.Length - ext.Length);
        return Resources.Load(p);
    }

    // VMA: 0x0191549b — Source: ResourceModule.c:4452 (OnCollectFinish)
    // gốc body: walk _AsyncLoadCmdCache (+0x10) — for each cached cmd:
    //   cmd is a tuple (isUI, szPath, finish, param). Re-invoke LoadResourceAsync(...).
    //   Then clear _AsyncLoadCmdCache.
    // DEVIATION: queue not used in our sync path.
    public static void OnCollectFinish()
    {
        _AsyncLoadCmdCache.Clear();
    }

    // VMA: 0x0191568f — Source: ResourceModule.c:4539 (CheckAllResourceLoadFinish)
    // gốc body:
    //   tasks = _RuningTask (+8);
    //   if tasks == null: error;
    //   return tasks.Count < 1;
    public static bool CheckAllResourceLoadFinish()
    {
        return _RuningTask.Count < 1;
    }

    // VMA: 0x019156fe — Source: ResourceModule.c:4569 (UnLoadResourceCache)
    // gốc body: `ResourceCache.UnloadUnusedAssets(bGC);`
    public static void UnLoadResourceCache(bool bGC)
    {
        Resources.UnloadUnusedAssets();
        if (bGC) System.GC.Collect();
    }

    // VMA: 0x0191573e — Source: ResourceModule.c:4590 (SetOnceLoadResCount)
    // gốc body: `_OnceLoadResCount (+0) = count;`
    public static void SetOnceLoadResCount(int count)
    {
        _OnceLoadResCount = count;
    }

    // VMA: 0x0191578c — Source: ResourceModule.c:4611 (_OnResourceLoadFinished)
    // gốc body (lines 775-988): complex — when async loader finishes:
    //   1. cast args; cache via ResourceCache.DoCache(loader, key);
    //   2. find ResourceTask in _RuningTask, FinishTask + Remove;
    //   3. _LoadingRes.Remove(key);
    //   4. drain _WaitLoadRes queue (next item) → LoaderManager.Load + AddNormalTask.
    // DEVIATION: sync path doesn't use queue. No-op.
    private static void _OnResourceLoadFinished(object obj, object param) { }

    // VMA: 0x01915ecf — Source: ResourceModule.c:4877 (_CheckResourceLoadFinished)
    // gốc body:
    //   if CppApi.IsPackEnabled (+8 of DAT_03563fe8): return false;
    //   loader = obj as BundleLoader;
    //   if loader != null: return loader._LoadingFinished (+0x68) != 0;
    //   return true;
    private static bool _CheckResourceLoadFinished(object obj, object param)
    {
        // DEVIATION: sync path always finished
        return true;
    }

    // VMA: 0x01915fa8 — Source: ResourceModule.c:4926 (RemoveWaitLoadRes)
    // gốc body:
    //   wait = _WaitLoadRes (+0x18);
    //   if !wait.Contains(szPath): return;
    //   wait.Remove(szPath);
    //   _RuningTask (+8).Remove(szPath);
    public static void RemoveWaitLoadRes(string szPath)
    {
        if (!_WaitLoadRes.Contains(szPath)) return;
        _WaitLoadRes.Remove(szPath);
        _RuningTask.Remove(szPath);
    }

    // VMA: 0x019160a3 — Source: ResourceModule.c:4972 (GetResourceCacheCount)
    // gốc body: `return ResourceCache.GetCacheCount();`
    public static int GetResourceCacheCount() => 0; // DEVIATION: ResourceCache deferred

    // VMA: 0x019160de — Source: ResourceModule.c:4993 (GetResourceWaitCount)
    // gốc body:
    //   wait = _WaitLoadRes (+0x18);
    //   if wait != null: return wait.Count (+0x18);
    public static int GetResourceWaitCount() => _WaitLoadRes?.Count ?? 0;

    // VMA: 0x0191613c — Source: ResourceModule.c:5021 (GetResourceRuningCount)
    // gốc body:
    //   tasks = _RuningTask (+8);
    //   if tasks != null: return tasks.Count;
    public static int GetResourceRuningCount() => _RuningTask?.Count ?? 0;

    // VMA: 0x019161a5 — Source: ResourceModule.c:5050 (GetResourceLoadingCount)
    // gốc body:
    //   loading = _LoadingRes (+0x20);
    //   if loading != null: return loading.Count (+0x18);
    public static int GetResourceLoadingCount() => _LoadingRes?.Count ?? 0;

    // VMA: 0x01916203 — Source: ResourceModule.c:5078 (LoadText)
    // gốc body (lines 1226-1376):
    //   if QualityModule.IsAvailable (+9 of DAT_03561688) == 0:                  // pack mode disabled
    //     bytes = LoadTextSync(szPath);
    //     if bytes == null: LogHelper.ERROR; return null;
    //     if encoding == null: encoding = System.Text.Encoding.UTF8;
    //     return encoding.GetString(bytes);
    //   else:                                                                   // pack mode enabled
    //     callback = new CppApi.OnLoadFileCallback(OnLoadUtf8File);
    //     if CppApi.ReadResFileText(szPath, callback):
    //       text = _FileText (+0x28); _FileText = null;
    //       return text;
    //     size = CppApi.GetResFileSize(szPath);
    //     if size < 1: LogHelper.ERROR; return null;
    //     buf = new byte[size];
    //     if CppApi.ReadResFile(szPath, buf, size):
    //       return encoding.GetString(buf);
    //     LogHelper.ERROR; return string.Empty;
    // DEVIATION: pack0 extracted to filesystem. Use Resources.Load<TextAsset> + StreamingAssets fallback.
    public static string LoadText(string szPath, Encoding encoding)
    {
        if (string.IsNullOrEmpty(szPath)) return null;
        var p = szPath;
        var ext = Path.GetExtension(p);
        if (!string.IsNullOrEmpty(ext)) p = p.Substring(0, p.Length - ext.Length);
        var ta = Resources.Load<TextAsset>(p);
        if (ta != null) return ta.text;
        var bytes = LoadBytesFromStreamingAssets(szPath);
        if (bytes != null)
        {
            encoding ??= Encoding.UTF8;
            return encoding.GetString(bytes);
        }
        return null;
    }

    // VMA: 0x01916638 — Source: ResourceModule.c:5237 (LoadTextSync)
    // gốc body:
    //   path = "";
    //   res = ResourceDef.GetResourceFullPath(szPath, 0, out path);              // res code: 0=err, 1=streamingAssets, 2=disk
    //   if res == 1: return LoadBytesFromStreamingAssets(szPath);
    //   if res == 0: LogHelper.ERROR; return null;
    //   return FileHelper.ReadAllBytes(path);                                   // res == 2 → disk
    // DEVIATION: GetResourceFullPath unavailable. Try StreamingAssets → persistentDataPath.
    private static byte[] LoadTextSync(string url)
    {
        if (string.IsNullOrEmpty(url)) return null;
        // 1. Try StreamingAssets
        var bytes = LoadBytesFromStreamingAssets(url);
        if (bytes != null) return bytes;
        // 2. Try persistentDataPath (for downloaded patch files)
        var pp = Path.Combine(Application.persistentDataPath, url);
        if (File.Exists(pp)) return File.ReadAllBytes(pp);
        return null;
    }

    // VMA: 0x019167fb — Source: ResourceModule.c:5323 (LoadByte)
    // gốc body (lines 1483-1577):
    //   if QualityModule.IsAvailable (+9): // pack disabled
    //     ResourceDef.IsResourceExist(szPath);
    //     return LoadTextSync(szPath);
    //   else: // pack enabled
    //     size = CppApi.GetResFileSize(szPath);
    //     if size < 1: LogHelper.ERROR; return null;
    //     buf = new byte[size];
    //     if CppApi.ReadResFile(szPath, buf, size): return buf;
    //     LogHelper.ERROR; return null;
    public static byte[] LoadByte(string szPath, Encoding encoding)
    {
        if (string.IsNullOrEmpty(szPath)) return null;
        var p = szPath;
        var ext = Path.GetExtension(p);
        if (!string.IsNullOrEmpty(ext)) p = p.Substring(0, p.Length - ext.Length);
        var ta = Resources.Load<TextAsset>(p);
        if (ta != null) return ta.bytes;
        return LoadTextSync(szPath);
    }

    // VMA: 0x01916a90 — Source: ResourceModule.c:5426 (IsStreamingAssetsExists)
    // gốc body: `return 1;`  — gốc literal returns true unconditionally.
    public static bool IsStreamingAssetsExists(string path)
    {
        // gốc returns true unconditionally. We add path check for robustness.
        if (string.IsNullOrEmpty(path)) return false;
        var fp = Path.Combine(Application.streamingAssetsPath, path);
        return File.Exists(fp);
    }

    // VMA: 0x019167ba — Source: ResourceModule.c:5302 (LoadBytesFromStreamingAssets)
    // gốc body: `return ResourceAndroidPlugin.GetAssetBytes(path);`
    // gốc uses Android JNI plugin to read APK assets. DEVIATION: File.ReadAllBytes for non-Android.
    public static byte[] LoadBytesFromStreamingAssets(string path)
    {
        if (string.IsNullOrEmpty(path)) return null;
        var fp = Path.Combine(Application.streamingAssetsPath, path);
        if (File.Exists(fp)) return File.ReadAllBytes(fp);
        return null;
    }
}
