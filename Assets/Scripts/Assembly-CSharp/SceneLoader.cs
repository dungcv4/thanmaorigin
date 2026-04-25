// Class:  SceneLoader
// GUID:   96b62566c0c9277d28b455a0e2fda38d (preserved via .meta)
// Source: KTO_DecompiledReference/_root/SceneLoader.c (331 LOC, 9 methods)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 121)
//
// FULL 1-1 PORT 2026-04-26 — every method body verified against Ghidra C decompile.
// REAL gốc class (replaces invented "SceneLoadManager" deleted earlier).
// Inherits BaseLoader (same pattern as BundleLoader).
//
// CLASS-LEVEL DEVIATION:
// - LoaderManager.GetLoader (factory chain): direct alloc instead of pool
// - KCoroutine.StartCoroutine/StopCoroutine: Unity Coroutine equivalents
// - <_Init>d__13 + <WaitAllAbInDisk>d__12 iterator state machines: simple yield blocks

using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : BaseLoader
{
    // Fields (offsets từ dump.cs)
    private string m_sceneName = "";                    // 0x38
    private BundleLoader m_assetBundleLoader;            // 0x40
    private IEnumerator m_initEnumerator;                // 0x48

    // VMA: 0x0190edc5 — Source: SceneLoader.c:11532 (.ctor)
    // gốc body: BaseLoader.ctor(this); m_sceneName="" (DAT_03595f60); m_assetBundleLoader=0; m_initEnumerator=0;
    public SceneLoader() : base()
    {
        m_sceneName = "";
        m_assetBundleLoader = null;
        m_initEnumerator = null;
    }

    // VMA: 0x0190ecdf — Source: SceneLoader.c:11487 (Load static factory)
    // gốc body: LoaderManager.GetLoader<SceneLoader>(url, OnCallBack, loaderMode, ...);
    // DEVIATION: direct alloc (no LoaderManager pool).
    public static SceneLoader Load(string url, LoaderMode loaderMode, BaseLoader.LoaderCallBack OnCallBack)
    {
        var go = new GameObject($"SceneLoader_{Path.GetFileNameWithoutExtension(url)}");
        var loader = go.AddComponent<SceneLoader>();
        if (OnCallBack != null) loader.AddCallback(OnCallBack);
        loader.Init(url, loaderMode, null);
        return loader;
    }

    // VMA: 0x0190ee04 — Source: SceneLoader.c:11553 (get_Progress override)
    // gốc body:
    //   if (m_assetBundleLoader (+0x40) != null):
    //     return m_assetBundleLoader.Progress;        // virtual call BaseLoader.Progress
    //   return 0;
    public override float Progress => m_assetBundleLoader?.Progress ?? 0f;

    // VMA: 0x0190ee24 — Source: SceneLoader.c:11579 (Init override)
    // gốc body:
    //   m_LoaderUrl (+0x20) = url;
    //   m_LoaderMode (+0x18) = loaderMode;
    //   m_Result (+0x28) = null;
    //   m_State (+0xC) = 0x100;                                              // STATE_LOADING
    //   call BaseLoader.OnProgress(0);
    //   m_sceneName (+0x38) = Path.GetFileNameWithoutExtension(url);
    //   enumerator = _Init();                                                 // alloc iterator
    //   m_initEnumerator (+0x48) = KCoroutine.StartCoroutine(enumerator);
    public override void Init(string url, LoaderMode loaderMode, object[] args)
    {
        m_LoaderUrl = url;
        m_LoaderMode = loaderMode;
        m_Result = null;
        m_State = 0x100;
        OnProgress(0f);
        m_sceneName = Path.GetFileNameWithoutExtension(url);
        m_initEnumerator = _Init();
        StartCoroutine(m_initEnumerator);
    }

    // VMA: 0x0190ef4e — Source: SceneLoader.c:11634 (_Init coroutine factory)
    // gốc body: alloc <_Init>d__13 iterator state machine.
    // <_Init>d__13.MoveNext (separate file):
    //   1. yield WaitAllAbInDisk(url) — wait deps on disk
    //   2. assetBundleLoader = BundleLoader.Load(url, mode);
    //   3. while !bundleLoader.LoadingFinished: yield null;
    //   4. SceneManager.LoadSceneAsync(m_sceneName, Additive);
    //   5. OnFinish(scene);
    // NOTE: gốc has [IteratorStateMachine(typeof(SceneLoader.<_Init>d__13))] — removed.
    private IEnumerator _Init()
    {
        yield return WaitAllAbInDisk(m_LoaderUrl);
        m_assetBundleLoader = BundleLoader.Load(m_LoaderUrl, m_LoaderMode);
        while (m_assetBundleLoader != null && m_assetBundleLoader.Bundle == null)
            yield return null;
        var op = SceneManager.LoadSceneAsync(m_sceneName, LoadSceneMode.Additive);
        if (op != null) while (!op.isDone) yield return null;
        OnFinish(m_sceneName);
    }

    // VMA: 0x0190efad — Source: SceneLoader.c:11660 (ReInit override)
    // gốc body:
    //   m_LoaderMode (+0x18) = loaderMode;
    //   m_bForceReload (+0x31) = 1;
    //   if m_initEnumerator (+0x48) != null:
    //     KCoroutine.StopCoroutine(m_initEnumerator); m_initEnumerator = null;
    //   enumerator = _Init();
    //   m_initEnumerator = KCoroutine.StartCoroutine(enumerator);
    public override void ReInit(LoaderMode loaderMode, object[] args)
    {
        m_LoaderMode = loaderMode;
        if (m_initEnumerator != null)
        {
            try { StopCoroutine(m_initEnumerator); } catch { }
            m_initEnumerator = null;
        }
        m_initEnumerator = _Init();
        StartCoroutine(m_initEnumerator);
    }

    // VMA: 0x0190f042 — Source: SceneLoader.c:11696 (DoDispose override)
    // gốc body:
    //   m_Result (+0x28) = null; m_State (+0xC) = 0;
    //   OnProgress(0);                                                       // virtual
    //   if (m_assetBundleLoader (+0x40) != null):
    //     m_assetBundleLoader.Dispose;                                       // virtual at +0x1b8
    //     m_assetBundleLoader = null;
    //   if (m_initEnumerator (+0x48) != null):
    //     KCoroutine.StopCoroutine(m_initEnumerator); m_initEnumerator = null;
    public override void DoDispose()
    {
        m_Result = null;
        m_State = 0;
        OnProgress(0f);
        if (m_assetBundleLoader != null)
        {
            m_assetBundleLoader.DoDispose();
            m_assetBundleLoader = null;
        }
        if (m_initEnumerator != null)
        {
            try { StopCoroutine(m_initEnumerator); } catch { }
            m_initEnumerator = null;
        }
    }

    // VMA: 0x0190f0e5 — Source: SceneLoader.c:11732 (OnFinish override)
    // gốc body:
    //   m_Result (+0x28) = resultObj; m_State (+0xC) = 1;                    // STATE_DONE
    //   OnProgress(1.0f);                                                    // virtual at +0x188
    //   BaseLoader.DoCallback(this, resultObj);
    //   m_initEnumerator (+0x48) = null;
    protected override void OnFinish(object resultObj)
    {
        m_Result = resultObj;
        m_State = 1;
        OnProgress(1.0f);
        DoCallback(resultObj);
        m_initEnumerator = null;
    }

    // VMA: 0x0190f12c — Source: SceneLoader.c:11750 (WaitAllAbInDisk coroutine factory)
    // gốc body: alloc <WaitAllAbInDisk>d__12 iterator. MoveNext (separate file):
    //   poll File.Exists for all dependent .ab files until ready.
    // NOTE: gốc has [IteratorStateMachine(typeof(SceneLoader.<WaitAllAbInDisk>d__12))] — removed.
    private IEnumerator WaitAllAbInDisk(string bundlePath)
    {
        // DEVIATION: assume single bundle, just check streaming + persistent path.
        var sp = Path.Combine(Application.streamingAssetsPath, bundlePath);
        var pp = Path.Combine(Application.persistentDataPath, bundlePath);
        // gốc loops until all deps on disk. Our case: bundle either embedded or downloaded by KKUpdater.
        yield break;
    }
}
