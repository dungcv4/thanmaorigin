// Class:  BundleLoader (BaseLoader subclass that wraps a single AssetBundle)
// GUID:   45c6742bf42c341819bd256400261265 (preserved via .meta)
// Source: KiemTheOrigin_DeepExtract/_shared/DecompiledSource/BundleLoader.cs (Token 0x200006F)
// IL2CPP: KTO_DecompiledReference/_root/BundleLoader.c (474 LOC, 11 methods)
//
// PARTIAL 1-1 PORT 2026-04-27 (canonicalization Day 4 — TIER 1 minimum viable sync).
//
// gốc behaviour (BundleLoader__Init at 0x0190ce92):
//   url.ToLower() → m_LoaderUrl;
//   m_LoaderMode = mode; m_State = 0; OnProgress(0);
//   _LoadBundle_Priority iterator started via KCoroutine.StartCoroutine.
//   Iterator (state machine) :
//     • for each dep in BundleManager.GetAllDependencies(url):
//         BundleManager.LoadBundle(parent=url, dep, mode, _OnDependentBundleLoadFinish, [index])
//     • wait until _DependentAbLoadedCount == _DependentAbCount
//     • BundleManager.LoadBundle(parent=null, url, mode, _OnBundleLoadFinish, null)
//     • OnFinish(Bundle)
//
// thanmaorigin DEVIATION (cited):
//   1. KCoroutine + iterator absent — Init runs sync; deps resolved by BundleManager.LoadBundle
//      (which itself uses sync AssetBundle.LoadFromFile and ignores async manifest deps in
//      TIER 1 because Day 4.5 hasn't built bundles yet).
//   2. _LoadBundle_Priority body collapsed.

using System;
using UnityEngine;

public class BundleLoader : BaseLoader
{
    // Fields (offsets from dump.cs Token 0x40001D4..0x40001D9)
    private Guid _RequestID;                                   // 0x40
    private BundleInfoEntry[] _DependentAbList;                // 0x50
    private System.Collections.IEnumerator _InitEnumerator;    // 0x58
    private int _DependentAbCount;                             // 0x60
    private int _DependentAbLoadedCount;                       // 0x64
    private bool _LoadingFinished;                             // 0x68

    // Property — Source: dump.cs (Token 0x1700001F)
    // VMA: 0x190CD53 / 0x190CD58 — gốc field offset 0x38
    public AssetBundle Bundle { get; private set; }

    // VMA: 0x190CD5D — Source: BundleLoader.c:50 (Load static)
    // gốc body:
    //   uVar1 = LoaderManager.<typeof(BundleLoader)>.first_init();
    //   LoaderManager__GetLoader<object>(url, 0, mode, uVar1, BundleLoader_typedef);
    public static BundleLoader Load(string url, LoaderMode loaderMode)
    {
        return LoaderManager.GetLoader<BundleLoader>(url, null, loaderMode, null);
    }

    // VMA: 0x190CE36 — Source: BundleLoader.c:99 (.ctor)
    // gốc body: BaseLoader.ctor; zero-init fields.
    public BundleLoader() { }

    // VMA: 0x190CE92 — Source: BundleLoader.c:132 (Init)
    // gốc body (lines 132-178):
    //   url.ToLower() → m_LoaderUrl;
    //   m_LoaderMode = loaderMode; m_State = 0; OnProgress(0);
    //   _InitEnumerator = _LoadBundle_Priority();
    //   KCoroutine.StartCoroutine(_InitEnumerator);
    public override void Init(string url, LoaderMode loaderMode, object[] args)
    {
        if (string.IsNullOrEmpty(url)) { _LoadingFinished = true; IsCompleted = true; return; }
        Url = url.ToLower();
        ResultObject = null;
        IsCompleted = false;
        OnProgress(0f);

        // SYNC collapse — gốc would yield via KCoroutine; we run inline.
        // Step 1: dependent bundles (gốc _LoadBundle_Priority iterates GetAllDependencies)
        var deps = BundleManager.GetAllDependencies(Url);
        if (deps != null && deps.Length > 0)
        {
            _DependentAbCount = deps.Length;
            _DependentAbList = new BundleInfoEntry[deps.Length];
            for (int i = 0; i < deps.Length; i++)
            {
                int idx = i;
                BundleManager.LoadBundle(Url, deps[i], LoaderMode.Sync,
                    (ab, p) => _OnDependentBundleLoadFinish(ab, new object[] { idx }),
                    new object[] { idx });
            }
        }

        // Step 2: main bundle (gốc final LoadBundle in iterator)
        BundleManager.LoadBundle(null, Url, LoaderMode.Sync,
            _OnBundleLoadFinishCallback, null);

        Bundle = BundleManager.GetBundle(Url);
        ResultObject = Bundle;
        _LoadingFinished = true;
        OnFinish(Bundle);
    }

    // VMA: 0x190D004 — Source: BundleLoader.c:221 (ReInit)
    // gốc body (lines 221-266):
    //   m_LoaderMode = mode; m_bForceReload = 1;
    //   if (_InitEnumerator running) KCoroutine.StopCoroutine; null it.
    //   _InitEnumerator = _LoadBundle_Priority(); KCoroutine.StartCoroutine.
    public override void ReInit(LoaderMode loaderMode, object[] args)
    {
        Init(Url, loaderMode, args);
    }

    // VMA: 0x190D0FF — Source: BundleLoader.c:279 (DoDispose)
    // gốc body (lines 279-348):
    //   m_Result=null; m_State=0; OnProgress(0);
    //   for each (BundleInfo in _DependentAbList): BundleManager.ReleaseBundle(...);
    //   _DependentAbList = null;
    //   if (Bundle != null) BundleManager.ReleaseBundle(parent=null, Url, Bundle, _RequestID);
    //   if (_InitEnumerator running) KCoroutine.StopCoroutine.
    public override void DoDispose()
    {
        ResultObject = null;
        IsCompleted = false;
        OnProgress(0f);

        if (_DependentAbList != null)
        {
            for (int i = 0; i < _DependentAbList.Length; i++)
            {
                var entry = _DependentAbList[i];
                if (entry == null) continue;
                BundleManager.ReleaseBundle(Url, entry.bundlePath, entry.bundle, entry.requestId);
            }
            _DependentAbList = null;
        }

        if (Bundle != null)
        {
            BundleManager.ReleaseBundle(null, Url, Bundle, _RequestID);
            Bundle = null;
        }

        _InitEnumerator = null;
        _LoadingFinished = false;
    }

    // VMA: 0x190D2D7 — Source: BundleLoader.c:362 (OnFinish)
    // gốc body:
    //   m_Result = resultObj; m_State = 1; OnProgress(1.0f); BaseLoader.DoCallback(resultObj);
    //   _InitEnumerator = null;
    protected override void OnFinish(object resultObj)
    {
        ResultObject = resultObj;
        IsCompleted = true;
        OnProgress(1.0f);
        base.DoCallback(resultObj);
        _InitEnumerator = null;
    }

    // VMA: 0x190CFA5 — Source: BundleLoader.c:191 (_LoadBundle_Priority iterator factory)
    // gốc body: builds <_LoadBundle_Priority>d__17 state machine.
    // DEVIATION: not used — Init runs sync.

    // VMA: 0x190D341 — Source: BundleLoader.c:384 (_OnDependentBundleLoadFinish)
    // gốc body (lines 384-452):
    //   if (param[0] is int idx && _DependentAbList[idx] != null):
    //     _DependentAbList[idx].bundle = bundle;  // store handle
    //     _DependentAbLoadedCount++;
    //   else: LogHelper.ERROR.
    private void _OnDependentBundleLoadFinish(AssetBundle bundle, object[] param)
    {
        if (param == null || param.Length < 1 || _DependentAbList == null) return;
        if (!(param[0] is int idx) || idx < 0 || idx >= _DependentAbList.Length) return;
        if (_DependentAbList[idx] == null) _DependentAbList[idx] = new BundleInfoEntry();
        _DependentAbList[idx].bundle = bundle;
        _DependentAbLoadedCount++;
    }

    // VMA: 0x190D5F3 — Source: BundleLoader.c:465 (_OnBundleLoadFinish)
    // gốc body: *(undefined1*)(param_1 + 0x68) = 1;  // _LoadingFinished = true.
    private void _OnBundleLoadFinishCallback(AssetBundle bundle, object[] param)
    {
        _LoadingFinished = true;
    }

    // Nested type — Source: BundleLoader.cs (Token 0x2000070, private class BundleInfo)
    //   gốc fields: bundle (0x10), bundlePath (0x18), requestId (0x20).
    // Renamed to BundleInfoEntry to avoid ambiguity with top-level BundleInfo.
    private class BundleInfoEntry
    {
        public AssetBundle bundle;     // 0x10
        public string bundlePath;      // 0x18
        public Guid requestId;         // 0x20

        public BundleInfoEntry() { }
    }
}
