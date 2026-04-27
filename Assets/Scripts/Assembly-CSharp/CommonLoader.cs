// Class:  CommonLoader (orchestrates BundleLoader + AssetLoader for one logical asset path)
// GUID:   (preserved via .meta)
// Source: KiemTheOrigin_DeepExtract/_shared/DecompiledSource/CommonLoader.cs (Token 0x2000072)
// IL2CPP: KTO_DecompiledReference/_root/CommonLoader.c (387 LOC, 14 methods)
//
// PARTIAL 1-1 PORT 2026-04-27 (canonicalization Day 4 — TIER 1 minimum viable sync).
//
// gốc behavior summary:
//   - CommonLoader.Init(url, mode) →
//       BundlePath = BundleManager.GetBundlePathFromAssetPath(url);
//       BundleType = BundleManager.GetBundleType(BundlePath);
//       KCoroutine.StartCoroutine(_Init iterator):
//         1. yield WaitAllAbInDisk(BundlePath)  // ensure dependent .ab on disk
//         2. m_assetBundleLoader = LoaderManager.GetLoader<BundleLoader>(BundlePath, ...)
//         3. yield m_assetBundleLoader (wait for IsCompleted)
//         4. assetName = file-name-without-ext(url);
//            req = bundle.LoadAssetAsync(assetName);
//            yield req
//         5. m_asset = req.asset; OnFinish(m_asset)
//
// thanmaorigin DEVIATION (cited):
//   1. KCoroutine + iterators not ported (Phase X) — Init runs synchronously.
//   2. WaitAllAbInDisk + DlcModule download skipped (no DLC layer in thanmaorigin).
//   3. m_assetBundleLoader / m_assetLoader fields kept for layout faithfulness but unused
//      in the sync collapse — bundle held by BundleManager pool instead.

using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

public class CommonLoader : BaseLoader
{
    // Fields (offsets from dump.cs Token 0x40001E1..0x40001E6)
    private Object m_asset;                     // 0x38 — held via Asset property
    private BundleLoader m_assetBundleLoader;   // 0x50
    private AssetLoader m_assetLoader;          // 0x58
    private System.Collections.IEnumerator m_initEnumerator; // 0x60 — unused in sync collapse

    // Property — Source: dump.cs (Token 0x17000022)
    // VMA: 0x190DA94 get / 0x1909BDB set
    // gốc set body (lines 14-21): both +0x38 and +0x28 (= ResultObject) are set.
    public Object Asset
    {
        get { return m_asset; }
        set
        {
            m_asset = value;
            ResultObject = value;
        }
    }

    // Property — Source: dump.cs (Token 0x17000023)
    // VMA: 0x190DA99 get / 0x190DA9E set — gốc field offset 0x40
    public string BundlePath { get; private set; }

    // Property — Source: dump.cs (Token 0x17000024)
    // VMA: 0x190DAA3 get / 0x190DAA7 set — gốc field offset 0x48
    public AbType BundleType { get; private set; }

    // VMA: 0x190DAAB — Source: CommonLoader.c:121 (.ctor)
    // gốc body: BaseLoader.ctor; zero out fields 0x38..0x60.
    public CommonLoader() { }

    // VMA: 0x190DAD0 — Source: CommonLoader.c:145 (Init)
    // gốc body (lines 145-195):
    //   m_LoaderUrl = url;
    //   m_LoaderMode = mode;
    //   m_Result = null;
    //   m_State = 0; m_bForceReload = 0;
    //   OnProgress(0);
    //   BundlePath = BundleManager.GetBundlePathFromAssetPath(url);
    //   BundleType = BundleManager.GetBundleType(BundlePath);
    //   m_initEnumerator = _Init();
    //   KCoroutine.StartCoroutine(m_initEnumerator);
    public override void Init(string url, LoaderMode loaderMode, object[] args)
    {
        if (string.IsNullOrEmpty(url)) { IsCompleted = true; return; }

        Url = url;
        // m_LoaderMode is protected on BaseLoader — set via reflection-free helper not needed:
        // Init flow only uses loaderMode local. We'll just respect it inline.
        ResultObject = null;
        IsCompleted = false;
        OnProgress(0f);

        // Resolve metadata (gốc lines 184-187)
        BundlePath = BundleManager.GetBundlePathFromAssetPath(url);
        BundleType = BundleManager.GetBundleType(BundlePath);

        // SYNC collapse — gốc would yield a coroutine; we run inline.
        // 1. Ensure bundle is loaded.
        var bundle = BundleManager.GetBundle(BundlePath);
        if (bundle == null)
        {
            BundleManager.LoadBundle(null, BundlePath, LoaderMode.Sync, null, null);
            bundle = BundleManager.GetBundle(BundlePath);
        }

        // 2. Load asset by file-name-without-ext (gốc convention).
        if (bundle != null)
        {
            string assetName = Path.GetFileNameWithoutExtension(url);
            // Try the literal name first; if that fails, fall back to the first asset of the bundle.
            Object asset = bundle.LoadAsset(assetName);
            if (asset == null)
            {
                // Some bundles store the asset under a different name (e.g. atlas SpriteAtlas).
                var all = bundle.LoadAllAssets();
                if (all != null && all.Length > 0) asset = all[0];
            }
            Asset = asset;  // setter also updates ResultObject (gốc behaviour)
        }
        else
        {
            Debug.LogWarning($"[CommonLoader.Init] no bundle for '{url}' (BundlePath='{BundlePath}')");
        }

        OnFinish(m_asset);
    }

    // VMA: 0x190DC07 — Source: CommonLoader.c:208 (_Init iterator)
    // gốc body: builds <_Init>d__23 state machine — wraps WaitAllAbInDisk + bundle-load
    //   + AssetBundle.LoadAssetAsync flow.
    // DEVIATION: not implemented (sync collapse). Kept here as a stub for layout faithfulness.

    // VMA: 0x190DC66 — Source: CommonLoader.c:238 (ReInit)
    // gốc body:
    //   m_LoaderMode = mode;
    //   m_bForceReload = 1;
    //   if (m_initEnumerator running) KCoroutine.StopCoroutine; null it.
    //   m_initEnumerator = _Init(); KCoroutine.StartCoroutine.
    // DEVIATION: rerun sync Init (same TIER 1 reasoning).
    public override void ReInit(LoaderMode loaderMode, object[] args)
    {
        Init(Url, loaderMode, args);
    }

    // VMA: 0x190DCFB — Source: CommonLoader.c:278 (DoDispose)
    // gốc body (lines 278-311):
    //   m_Result = null; m_State = 0; m_bForceReload = 0; OnProgress(0);
    //   if (m_assetLoader != null) Release(); null;
    //   if (m_assetBundleLoader != null) Release(); null;
    //   m_asset = null;
    //   if (m_initEnumerator running) KCoroutine.StopCoroutine; null.
    public override void DoDispose()
    {
        ResultObject = null;
        IsCompleted = false;
        OnProgress(0f);

        if (m_assetLoader != null)
        {
            m_assetLoader.Release();
            m_assetLoader = null;
        }
        if (m_assetBundleLoader != null)
        {
            m_assetBundleLoader.Release();
            m_assetBundleLoader = null;
        }
        m_asset = null;
        m_initEnumerator = null;
    }

    // VMA: 0x190DDC7 — Source: CommonLoader.c:324 (NeedUnload override)
    // gốc body:
    //   uVar1 = (BundleType - 1);
    //   return (1 < uVar1);
    //   → returns true for BundleType > 2 (i.e. not none/shader/font; load-anytime types).
    //
    // FIXME(canonicalization-day-4): semantics interpretation —
    //   AbType numeric: none=0, shader=1, font=2, atlas=3, prefab=4, unity=5, common=6,
    //                   sound=7, sprite=8.
    //   uVar1 = type-1 → for type in {0,1,2}: uVar1 in {-1, 0, 1} → 1 < uVar1 == false.
    //   For type ≥ 3 (atlas+): uVar1 ≥ 2 → true. So `font` and `shader` keep loaded; rest
    //   eligible for unload sweep.
    public override bool NeedUnload()
    {
        int u = (int)BundleType - 1;
        return 1 < u;
    }

    // VMA: 0x190DDD3 — Source: CommonLoader.c:344 (OnFinish override)
    // gốc body (lines 344-353):
    //   m_Result = resultObj; m_State = 1; OnProgress(1.0f);
    //   BaseLoader.DoCallback(resultObj);
    //   m_initEnumerator = null;
    protected override void OnFinish(object resultObj)
    {
        ResultObject = resultObj;
        IsCompleted = true;
        OnProgress(1.0f);
        base.DoCallback(resultObj);
        m_initEnumerator = null;
    }
}
