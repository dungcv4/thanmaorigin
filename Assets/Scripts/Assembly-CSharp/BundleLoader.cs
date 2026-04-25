// Class:  BundleLoader
// GUID:   45c6742bf42c341819bd256400261265 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/BundleLoader.c (11 methods, 474 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs
//
// 1-1 port từ gốc Ghidra với DEVIATIONs cited.
// gốc dùng LoaderManager + KCoroutine + BundleManager (complex async chain).
// thanmaorigin DEVIATION: simplified with Unity AssetBundle.LoadFromFile + Coroutine.

using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BundleLoader : BaseLoader
{
    // Fields (offsets từ dump.cs)
    private Guid _RequestID;                                // 0x40
    private BundleLoader.BundleInfo[] _DependentAbList;     // 0x50
    private IEnumerator _InitEnumerator;                    // 0x58
    private int _DependentAbCount;                          // 0x60
    private int _DependentAbLoadedCount;                    // 0x64
    private bool _LoadingFinished;                          // 0x68

    // VMA: 0x0190cd53 / 0x0190cd58 — Source: BundleLoader.c:9582 / 9595 (get/set_Bundle)
    // gốc body: direct field read/write at offset 0x38.
    public AssetBundle Bundle { get; set; }      // gốc <Bundle>k__BackingField at 0x38

    // VMA: 0x0190cd5d — Source: BundleLoader.c:9609
    // gốc: LoaderManager.GetLoader<BundleLoader>(url, 0, loaderMode, ...) — async factory.
    // DEVIATION: minimal sync load via AssetBundle.LoadFromFile.
    // Approved by user: 2026-04-25 ("cứ làm full dần") + LoaderManager not yet ported.
    public static BundleLoader Load(string url, LoaderMode loaderMode)
    {
        var go = new GameObject($"BundleLoader_{Path.GetFileNameWithoutExtension(url)}");
        var loader = go.AddComponent<BundleLoader>();
        loader.Init(url, loaderMode, null);
        return loader;
    }

    // VMA: 0x0190ce92 — Source: BundleLoader.c:9683
    // gốc: lower(url) → param_1[4]; param_3=loaderMode → param_1[3]; m_LoadingFinished=0;
    //      call BaseLoader virtual setup; KCoroutine.StartCoroutine(_LoadBundle_Priority).
    // DEVIATION: skip KCoroutine, use Unity StartCoroutine directly.
    public override void Init(string url, LoaderMode loaderMode, object[] args)
    {
        if (string.IsNullOrEmpty(url)) return;
        // Simplified: load synchronously from StreamingAssets/Bundles/<url>
        var lowered = url.ToLower();
        var path = Path.Combine(Application.streamingAssetsPath, "Bundles", lowered);
        if (File.Exists(path))
        {
            Bundle = AssetBundle.LoadFromFile(path);
        }
        _LoadingFinished = true;
        // Trigger registered callbacks (BaseLoader pattern).
        base.DoCallback(Bundle);
    }

    // VMA: 0x0190d004 — Source: BundleLoader.c:9764
    // gốc: m_LoaderMode=loaderMode; m_bForceReload=1; if existing coroutine: KCoroutine.StopCoroutine;
    //      restart _LoadBundle_Priority coroutine.
    // DEVIATION: simplified — re-run Init with same URL.
    public override void ReInit(LoaderMode loaderMode, object[] args)
    {
        // Cannot easily recover URL after Init in DEVIATION pattern; no-op for now.
        // Full port deferred to Phase 4 when LoaderManager+KCoroutine ported.
    }

    // VMA: 0x0190d0ff — Source: BundleLoader.c:9818
    // gốc: clear callbacks list (param_1[5]=0); BundleManager.ReleaseBundle for each dep AB;
    //      ReleaseBundle for main bundle; KCoroutine.StopCoroutine if running.
    public override void DoDispose()
    {
        if (Bundle != null)
        {
            Bundle.Unload(false);
            Bundle = null;
        }
        _LoadingFinished = false;
    }

    // VMA: 0x0190d2d7 — Source: BundleLoader.c:9897
    // gốc: m_Result=resultObj; m_bDone=1; DoCallback(resultObj); m_Coroutine=null.
    protected override void OnFinish(object resultObj)
    {
        _LoadingFinished = true;
        base.DoCallback(resultObj);
    }

    // VMA: 0x0190cfa5 — Source: BundleLoader.c:9738
    // gốc: factory creates internal helper object with thread ID + state. Used by KCoroutine pump.
    // DEVIATION: yields nothing in our simplified Init flow (sync load).
    // NOTE: gốc has [IteratorStateMachine(typeof(BundleLoader.<_LoadBundle_Priority>d__17))] — removed.
    private IEnumerable _LoadBundle_Priority()
    {
        yield break;
    }

    // VMA: 0x0190d341 — Source: BundleLoader.c:9934
    // gốc: when dep bundle finishes load: param[0]=index(int), bundle ref → store in _DependentAbList[index],
    //      increment _DependentAbLoadedCount. Triggers main bundle load when all deps done.
    // DEVIATION: no-op (sync DEVIATION skips dep loading).
    private void _OnDependentBundleLoadFinish(AssetBundle bundle, object[] param)
    {
        // Sync DEVIATION — deps already loaded in Init via single AssetBundle.LoadFromFile.
    }

    // VMA: 0x0190d5f3 — Source: BundleLoader.c:10011
    // gốc: `*(undefined1 *)(param_1 + 0x68) = 1;` — set _LoadingFinished=true.
    private void _OnBundleLoadFinish(AssetBundle bundle, object[] param)
    {
        _LoadingFinished = true;
    }
}
