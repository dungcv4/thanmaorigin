// Class:  BaseLoader (abstract base for all asset loaders)
// GUID:   8b1bf4d7fad6d436dbbfebec93fe4ac7 (preserved via .meta)
// Source: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 109) +
//         KTO_DecompiledReference/_root/BaseLoader.c
//
// FULL 1-1 PORT 2026-04-25 — fields/properties/virtuals match dump.cs.
//
// Inheritance: BundleLoader, SceneLoader, AssetLoader (and others) inherit BaseLoader.

using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLoader : MonoBehaviour
{
    // Nested delegate type — Source: dump.cs (TypeDefIndex 108)
    // gốc: MulticastDelegate. Invoke(object resultObject).
    public delegate void LoaderCallBack(object resultObject);

    // Fields (offsets từ dump.cs)
    private readonly List<LoaderCallBack> _FinishCallBacks = new List<LoaderCallBack>(); // 0x10
    protected LoaderMode _LoaderMode;                                                   // 0x18

    // Properties (auto-properties — gốc <X>k__BackingField at appropriate offsets)
    // VMA: 0x180C9BE / 0x180C9C2 — get/set_RefCount      (0x1C)
    public int RefCount { get; set; }
    // VMA: 0x180C9C6 / 0x180C9CB — get/set_Url           (0x20)
    public string Url { get; protected set; }
    // VMA: 0x180C9D0 / 0x180C9D5 — get/set_ResultObject  (0x28)
    public object ResultObject { get; protected set; }
    // VMA: 0x180C9DA / 0x180C9DE — get/set_IsCompleted   (0x30)
    public bool IsCompleted { get; protected set; }
    // VMA: 0x180C9E3 / 0x180C9E7 — get/set_IsLoading     (0x31)
    public bool IsLoading { get; protected set; }
    // VMA: 0x180C9EC / 0x180C9F2 — get/set_Progress      (0x34) — virtual
    public virtual float Progress { get; protected set; }

    // ====== Bridge fields used by SceneLoader/BundleLoader sub-class ports ======
    // gốc places m_LoaderUrl/m_LoaderMode/m_Result/m_State at specific offsets.
    // Our port uses these convenience aliases that map onto BaseLoader auto-properties.
    protected string m_LoaderUrl { get => Url; set => Url = value; }
    protected LoaderMode m_LoaderMode { get => _LoaderMode; set => _LoaderMode = value; }
    protected object m_Result { get => ResultObject; set => ResultObject = value; }
    protected int m_State;          // 0xC (offset varies per subclass — preserved as alias)
    protected bool m_bForceReload;  // 0x31

    // VMA: 0x180C94D — Source: BaseLoader.c (.ctor)
    // gốc body: System_Object___ctor; Initialize _FinishCallBacks list.
    protected BaseLoader() { }

    // VMA: 0x180C9F8 — Source: BaseLoader.c (Init virtual)
    // gốc body: empty (virtual stub for subclass).
    public virtual void Init(string url, LoaderMode loaderMode, object[] args) { }

    // VMA: 0x180CA23 — Source: BaseLoader.c (ReInit virtual)
    // gốc body: empty (virtual stub for subclass).
    public virtual void ReInit(LoaderMode loaderMode, object[] args) { }

    // VMA: 0x180CA2B — Source: BaseLoader.c (AddCallback)
    // gốc body: _FinishCallBacks.Add(callback).
    public void AddCallback(LoaderCallBack callback)
    {
        if (callback != null) _FinishCallBacks.Add(callback);
    }

    // VMA: 0x180CAB4 — Source: BaseLoader.c (Release virtual)
    // gốc body: RefCount--; if (RefCount <= 0) DoDispose().
    public virtual void Release()
    {
        RefCount--;
        if (RefCount <= 0) DoDispose();
    }

    // VMA: 0x180CB41 — Source: BaseLoader.c (DoCallback)
    // gốc body: foreach cb in _FinishCallBacks: cb(resultObj); _FinishCallBacks.Clear();
    protected void DoCallback(object resultObj)
    {
        for (int i = 0; i < _FinishCallBacks.Count; i++)
        {
            try { _FinishCallBacks[i]?.Invoke(resultObj); } catch { }
        }
        _FinishCallBacks.Clear();
    }

    // VMA: 0x180CBF8 — Source: BaseLoader.c (OnFinish virtual)
    // gốc body: empty (virtual stub for subclass to fill).
    protected virtual void OnFinish(object resultObj) { }

    // VMA: 0x180C924 — Source: BaseLoader.c (DoDispose virtual)
    // gốc body: empty (virtual stub for subclass).
    public virtual void DoDispose() { }

    // ====== Bridge for OnProgress callback used by SceneLoader/BundleLoader ports ======
    protected virtual void OnProgress(float p)
    {
        // gốc subclasses set Progress via this protected virtual hook.
        // Default impl just stores the value via property setter.
        if (p >= 0f && p <= 1f) Progress = p;
    }

    // VMA: 0x180CC36 — Source: dump.cs (Token 0x60001C4) — virtual NeedUnload (slot 11)
    // gốc body: returns false by default; CommonLoader overrides with BundleType check.
    public virtual bool NeedUnload() { return false; }
}
