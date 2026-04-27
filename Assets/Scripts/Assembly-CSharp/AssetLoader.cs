// Class:  AssetLoader (loads a single Asset out of a bundle by full asset path)
// GUID:   (preserved via .meta)
// Source: KiemTheOrigin_DeepExtract/_shared/DecompiledSource/AssetLoader.cs (Token 0x200006C)
// IL2CPP: KTO_DecompiledReference/_root/AssetLoader.c (174 LOC, 7 methods)
//
// PARTIAL 1-1 PORT 2026-04-27 (canonicalization Day 4 — TIER 1 minimum viable sync).
//
// gốc behavior:
//   - AssetLoader.Load(url) → LoaderManager.GetLoader<object>(url, null, Sync, ...)
//     Note: gốc passes object literal — actually CommonLoader; the Ghidra typename is
//     opaque here. The DecompiledSource signature returns `AssetLoader` — keep that shape.
//   - Init/ReInit: empty in gốc (just stubs).
//   - DoDispose: clears _Result / m_State / OnProgress(0).
//
// thanmaorigin DEVIATION (cited per method):
//   1. Init/ReInit not stubs in our impl — we synchronously load AssetBundle + LoadAsset,
//      because BaseLoader's protected sync helpers from KCoroutine are absent.
//      Approved by canonicalization-day-4 plan: "Editor PlayMode: ResourceModule.LoadResourceSync
//      → ... → AssetBundle.LoadFromFile" pipeline must work in TIER 1.

using UnityEngine;
using Object = UnityEngine.Object;

public class AssetLoader : BaseLoader
{
    // Property — Source: dump.cs (Token 0x17000018)
    // VMA: 0x180C80A get / 0x180C80F set — gốc field offset 0x38
    public Object AssetObj { get; private set; }

    // VMA: 0x180C814 — Source: AssetLoader.c:50 (Load)
    // gốc body:
    //   uVar1 = LoaderManager.{<typeof(object)>}.first_init();
    //   LoaderManager__GetLoader<object>(url, 0, 1, uVar1, AssetLoader_typedef);
    // → equivalent C# call:
    //   LoaderManager.GetLoader<AssetLoader>(url, null, LoaderMode.Sync, null);
    public static AssetLoader Load(string url)
    {
        return LoaderManager.GetLoader<AssetLoader>(url, null, LoaderMode.Sync, null);
    }

    // VMA: 0x190C948 — Source: AssetLoader.c:154 (.ctor)
    // gốc body: BaseLoader chain ctor (initialise _FinishCallBacks list).
    public AssetLoader() { }

    // VMA: 0x190C8EF — Source: AssetLoader.c:99 (Init)
    // gốc body: empty (return).
    // DEVIATION TIER 1: synchronous AssetBundle.LoadFromFile → LoadAsset(name) so that
    //   ResourceModule.LoadResourceSync can resolve to a non-null asset in editor + player
    //   without LoaderManager+KCoroutine async chain.
    // Original "do nothing here" body relied on LoaderManager.GetLoader callers to attach a
    //   callback that the Async coroutine would fire — we collapse the flow to sync.
    public override void Init(string url, LoaderMode loaderMode, object[] args)
    {
        if (string.IsNullOrEmpty(url)) { IsCompleted = true; return; }
        Url = url;
        IsLoading = true;

        // Resolve bundle path from asset path (gốc BundleManager.GetBundlePathFromAssetPath).
        string bundlePath = BundleManager.GetBundlePathFromAssetPath(url);
        var bundle = BundleManager.GetBundle(bundlePath);
        if (bundle == null)
        {
            BundleManager.LoadBundle(null, bundlePath, LoaderMode.Sync, null, null);
            bundle = BundleManager.GetBundle(bundlePath);
        }

        if (bundle != null)
        {
            // gốc: AssetLoader holds the asset via setter on +0x38; Use file-name as asset key.
            string assetName = System.IO.Path.GetFileNameWithoutExtension(url);
            AssetObj = bundle.LoadAsset(assetName);
            ResultObject = AssetObj;
        }
        else
        {
            Debug.LogWarning($"[AssetLoader.Init] no bundle found for url='{url}' (bundlePath='{bundlePath}')");
        }

        IsLoading = false;
        IsCompleted = true;
        OnFinish(ResultObject);
    }

    // VMA: 0x190C8F0 — Source: AssetLoader.c:116 (ReInit)
    // gốc body: empty (return). DEVIATION: re-run sync Init (same TIER 1 reasoning).
    public override void ReInit(LoaderMode loaderMode, object[] args)
    {
        // gốc body is empty — but for our sync-collapsed Init, no-op is correct
        // because the asset is already loaded. Higher layer can call DoDispose then Init again.
    }

    // VMA: 0x190C8F1 — Source: AssetLoader.c:133 (DoDispose)
    // gốc body:
    //   param_1[5] = 0;          // m_Result = null
    //   *(short*)(param_1+6) = 0; // m_State = false; m_bForceReload = false
    //   call OnProgress(0)
    //   param_1[7] = 0;          // m_AssetObj = null
    public override void DoDispose()
    {
        AssetObj = null;
        ResultObject = null;
        IsCompleted = false;
        IsLoading = false;
        OnProgress(0f);
    }

    // OnFinish hook — gốc inherits BaseLoader__OnFinish indirectly via subclass DoCallback.
    // Source: BundleLoader__OnFinish (0x0190d2d7) sets m_Result/m_State/Progress=1.0 + DoCallback.
    protected override void OnFinish(object resultObj)
    {
        ResultObject = resultObj;
        IsCompleted = true;
        OnProgress(1.0f);
        base.DoCallback(resultObj);
    }
}
