// Class:  ResourceModule
// GUID:   f108f4a34467646acb0028586ec0806d (preserved via .meta)
// Source: KTO_DecompiledReference/_root/ResourceModule.c (25 methods, 1658 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs
//
// 1-1 port với DEVIATIONs cited.
// gốc dùng ResourceCache + ResourceTask + CppApi.OpenPack chain (complex pack0.dat reader).
// thanmaorigin DEVIATION: pack0.dat đã extract sẵn (KTO_Extracted_Pack/) → load từ Resources/Setting/.
//
// Counter getters fully ported (trivial). Async chain methods have minimal DEVIATION bodies.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Object = UnityEngine.Object;

public class ResourceModule : MonoBehaviour
{
    // Fields (offsets từ dump.cs)
    private static int _OnceLoadResCount = 5;                                   // 0x0 (gốc init via Init coroutine)
    public static int CacheRecycleLine = 100;                                   // 0x4
    private static Dictionary<string, ResourceTask> _RuningTask = new Dictionary<string, ResourceTask>();   // 0x8
    private static List<object> _AsyncLoadCmdCache = new List<object>();        // 0x10
    private static List<string> _WaitLoadRes = new List<string>();              // 0x18
    private static List<string> _LoadingRes = new List<string>();               // 0x20
    private static string _FileText;                                            // 0x28

    // VMA: 0x01814c7d — Source: ResourceModule.c (Init coroutine)
    // gốc: coroutine initializes _OnceLoadResCount + warms ResourceCache.
    // DEVIATION: simple init without ResourceCache (deferred).
    [System.Runtime.CompilerServices.IteratorStateMachine(typeof(ResourceModule.<Init>d__0))]
    public static IEnumerator Init()
    {
        _OnceLoadResCount = 5;
        CacheRecycleLine = 100;
        yield break;
    }

    // VMA: 0x01814cdb — Source: ResourceModule.c (LateUpdate)
    // gốc: pump async load queue — process up to _OnceLoadResCount items per frame from _WaitLoadRes.
    // DEVIATION: deferred (we don't use async queue yet).
    private void LateUpdate()
    {
        // Async pump deferred to Phase 4 when ResourceTask ported.
    }

    // VMA: 0x01814daa — Source: ResourceModule.c (OpenPackFile)
    // gốc: CppApi.OpenPack(pack0.dat path) — opens encrypted pack archive.
    // DEVIATION: pack0.dat đã được extract sẵn vào KTO_Extracted_Pack/. No-op.
    public static void OpenPackFile()
    {
        // Pack data already extracted to Resources/Setting/.
    }

    // VMA: 0x01814e36 — Source: ResourceModule.c (ClosePackFile)
    public static void ClosePackFile()
    {
        // Pack data already extracted. No-op.
    }

    // VMA: 0x01814e73 — Source: ResourceModule.c (SetMapLoadingTopPriority)
    // gốc: toggle priority flag in async loader to prioritize map bundles.
    public static void SetMapLoadingTopPriority(bool bStart)
    {
        // Priority queue not yet implemented — defer to Phase 4.
    }

    // VMA: 0x0190b34d — Source: ResourceModule.c:8041 (LoadResourceAsync)
    // gốc: complex pipeline: check cache → if exist, AddCallBack to existing task; else create new ResourceTask, queue.
    // DEVIATION: synchronous Resources.Load + immediate callback.
    public static void LoadResourceAsync(bool isUI, string szPath, OnResourceFinishEventHandler finish, object param)
    {
        if (string.IsNullOrEmpty(szPath))
        {
            finish?.Invoke(null, param);
            return;
        }
        var obj = LoadResourceSync(szPath);
        finish?.Invoke(obj, param);
    }

    // VMA: 0x01815166 — Source: ResourceModule.c:8298 (LoadResourceSync)
    // gốc: check ResourceCache first → if miss, BundleLoader.Load + LoadAssetAsync + cache.
    // DEVIATION: try Resources.Load (Editor + Resources/) first; AssetBundle path deferred.
    public static Object LoadResourceSync(string szPath)
    {
        if (string.IsNullOrEmpty(szPath)) return null;
        // Strip "Assets/" prefix and file extension if present (gốc convention).
        var p = szPath;
        if (p.StartsWith("Assets/")) p = p.Substring(7);
        var ext = Path.GetExtension(p);
        if (!string.IsNullOrEmpty(ext)) p = p.Substring(0, p.Length - ext.Length);
        return Resources.Load(p);
    }

    // VMA: 0x0181549b — Source: ResourceModule.c (OnCollectFinish)
    // gốc: clear loading state when batch async load completes.
    public static void OnCollectFinish()
    {
        _LoadingRes.Clear();
    }

    // VMA: 0x0181568f — Source: ResourceModule.c (CheckAllResourceLoadFinish)
    // gốc: return _RuningTask.Count==0 && _WaitLoadRes.Count==0 && _LoadingRes.Count==0.
    public static bool CheckAllResourceLoadFinish()
    {
        return _RuningTask.Count == 0 && _WaitLoadRes.Count == 0 && _LoadingRes.Count == 0;
    }

    // VMA: 0x018156fe — Source: ResourceModule.c (UnLoadResourceCache)
    // gốc: ResourceCache.Clear + GC.Collect if bGC.
    public static void UnLoadResourceCache(bool bGC)
    {
        Resources.UnloadUnusedAssets();
        if (bGC) System.GC.Collect();
    }

    // VMA: 0x0181573e — Source: ResourceModule.c (SetOnceLoadResCount)
    // gốc: `_OnceLoadResCount = count;`
    public static void SetOnceLoadResCount(int count)
    {
        _OnceLoadResCount = count;
    }

    // VMA: 0x0181578c — Source: ResourceModule.c (_OnResourceLoadFinished)
    // gốc: callback when ResourceTask completes — pop task from _RuningTask, fire user callbacks.
    private static void _OnResourceLoadFinished(object obj, object param)
    {
        // Async chain deferred.
    }

    // VMA: 0x01815ecf — Source: ResourceModule.c (_CheckResourceLoadFinished)
    // gốc: predicate for List.RemoveAll — checks if specific task done.
    private static bool _CheckResourceLoadFinished(object obj, object param)
    {
        return false;
    }

    // VMA: 0x01815fa8 — Source: ResourceModule.c (RemoveWaitLoadRes)
    // gốc: `_WaitLoadRes.Remove(szPath);`
    public static void RemoveWaitLoadRes(string szPath)
    {
        _WaitLoadRes.Remove(szPath);
    }

    // VMA: 0x018160a3 — Source: ResourceModule.c (GetResourceCacheCount)
    // gốc: return ResourceCache.GetCount() — number of currently cached resources.
    // DEVIATION: ResourceCache deferred → return 0 placeholder.
    public static int GetResourceCacheCount() => 0;

    // VMA: 0x018160de — Source: ResourceModule.c (GetResourceWaitCount)
    public static int GetResourceWaitCount() => _WaitLoadRes.Count;

    // VMA: 0x0181613c — Source: ResourceModule.c (GetResourceRuningCount)
    public static int GetResourceRuningCount() => _RuningTask.Count;

    // VMA: 0x018161a5 — Source: ResourceModule.c (GetResourceLoadingCount)
    public static int GetResourceLoadingCount() => _LoadingRes.Count;

    // VMA: 0x01814ae2 — Source: ResourceModule.c (OnLoadUtf8File)
    // gốc: native CppApi callback when pack0 file loaded → store text in _FileText for LoadText.
    [AOT.MonoPInvokeCallback(typeof(CppApi.OnLoadFileCallback))]
    private static void OnLoadUtf8File(string szText)
    {
        _FileText = szText;
    }

    // VMA: 0x01816203 — Source: ResourceModule.c:9000 (LoadText)
    // gốc: CppApi.LoadFile(path, OnLoadUtf8File callback) → return _FileText.
    // DEVIATION: read directly from Resources/ + StreamingAssets/.
    public static string LoadText(string szPath, Encoding encoding)
    {
        if (string.IsNullOrEmpty(szPath)) return null;
        // Strip ext
        var p = szPath;
        var ext = Path.GetExtension(p);
        if (!string.IsNullOrEmpty(ext)) p = p.Substring(0, p.Length - ext.Length);
        // Try Resources first
        var ta = Resources.Load<TextAsset>(p);
        if (ta != null) return ta.text;
        // Fallback: StreamingAssets
        var bytes = LoadBytesFromStreamingAssets(szPath);
        if (bytes != null && encoding != null) return encoding.GetString(bytes);
        if (bytes != null) return Encoding.UTF8.GetString(bytes);
        return null;
    }

    // VMA: 0x01816638 — Source: ResourceModule.c (LoadTextSync internal byte loader)
    // gốc: WWW or UnityWebRequest blocking get from streamingAssets.
    private static byte[] LoadTextSync(string url)
    {
        if (string.IsNullOrEmpty(url)) return null;
        if (File.Exists(url)) return File.ReadAllBytes(url);
        return null;
    }

    // VMA: 0x018167fb — Source: ResourceModule.c (LoadByte)
    // gốc: similar to LoadText but returns raw bytes.
    public static byte[] LoadByte(string szPath, Encoding encoding)
    {
        if (string.IsNullOrEmpty(szPath)) return null;
        var p = szPath;
        var ext = Path.GetExtension(p);
        if (!string.IsNullOrEmpty(ext)) p = p.Substring(0, p.Length - ext.Length);
        var ta = Resources.Load<TextAsset>(p);
        if (ta != null) return ta.bytes;
        return LoadBytesFromStreamingAssets(szPath);
    }

    // VMA: 0x01816a90 — Source: ResourceModule.c (IsStreamingAssetsExists)
    public static bool IsStreamingAssetsExists(string path)
    {
        if (string.IsNullOrEmpty(path)) return false;
        var fp = Path.Combine(Application.streamingAssetsPath, path);
        return File.Exists(fp);
    }

    // VMA: 0x018167ba — Source: ResourceModule.c (LoadBytesFromStreamingAssets)
    public static byte[] LoadBytesFromStreamingAssets(string path)
    {
        if (string.IsNullOrEmpty(path)) return null;
        var fp = Path.Combine(Application.streamingAssetsPath, path);
        if (File.Exists(fp)) return File.ReadAllBytes(fp);
        return null;
    }
}
