// Class:  LoaderManager (static — typed loader pool & factory)
// GUID:   4632c75b1d0be449f8767fc5775251e2 (preserved via .meta — Day 1 fixed)
// Source: KiemTheOrigin_DeepExtract/_shared/DecompiledSource/LoaderManager.cs (Token 0x2000076)
// IL2CPP: KTO_DecompiledReference/_root/LoaderManager.c (313 LOC, 5 methods)
//
// PARTIAL 1-1 PORT 2026-04-27 (canonicalization Day 4 — TIER 1 minimum viable sync).
//
// gốc behavior (LoaderManager__Load + LoaderManager__GetLoader<T>):
//   - _LoaderPool is Dictionary<Type, Dictionary<string, BaseLoader>>
//   - On Load(url, mode): defaults T = typeof(CommonLoader), invokes GetLoader<T>(url, null, mode, null).
//   - GetLoader<T>(url, callback, mode, params...):
//       1. Lookup _LoaderPool[T]. Miss → create inner dict + insert.
//       2. Lookup inner[url]. Miss → Activator.CreateInstance<T>(); RefCount=1; AddCallback;
//          call Init(url, mode, args). Cache + return.
//       3. Hit → bump RefCount; if (loader has finished m_State=true): if (mode==Sync) DoDispose+ReInit;
//          else just AddCallback. Otherwise just AddCallback.
//
// thanmaorigin DEVIATION (cited):
//   1. Pool recycling (DoDispose-on-cache-evict) deferred — minimal Activator+Init only.
//   2. Async loader queueing skipped (sync mode immediately Init).
//
// FIXME(canonicalization-day-4): TIER 2 backlog —
//   • ReleaseLoader virtual dispatch full chain
//   • RefCount-driven eviction + DoDispose on Release()<=0

using System;
using System.Collections.Generic;
using UnityEngine;

public static class LoaderManager
{
    // Static pool — Source: dump.cs (Token 0x40001FB)
    // gốc: Dictionary<Type, Dictionary<string, BaseLoader>>
    private static readonly Dictionary<Type, Dictionary<string, BaseLoader>> _LoaderPool
        = new Dictionary<Type, Dictionary<string, BaseLoader>>();

    // VMA: 0x180257F — Source: LoaderManager.c:15 (Load)
    // gốc body:
    //   uVar1 = **(...lazy_init_<typeof(CommonLoader)>);
    //   LoaderManager__GetLoader<object>(url, callBack, mode, uVar1, ...);
    // → wraps GetLoader<CommonLoader>(url, callBack, mode, null).
    public static CommonLoader Load(string url, LoaderMode loaderMode, BaseLoader.LoaderCallBack callBack)
    {
        return GetLoader<CommonLoader>(url, callBack, loaderMode, null);
    }

    // Convenience overload — gốc Lua bridge calls Load(path, modeInt) without callback.
    public static CommonLoader Load(string url, int loaderMode)
    {
        return Load(url, (LoaderMode)loaderMode, null);
    }

    // VMA: 0x01ed59f9 — Source: LoaderManager.c:137 (GetLoader<T>)
    // gốc body (270+ lines, summarised):
    //   1. typeof(T) → outer Dictionary lookup. Miss: create inner dict, _LoaderPool[T] = inner.
    //   2. inner[url] lookup:
    //      • MISS: instance = Activator.CreateInstance<T>(); instance.RefCount++; AddCallback(callback);
    //              instance.Init(url, mode, initArgs); inner[url] = instance.
    //      • HIT:  if (RefCount < 0): error log + reset to 0.
    //              RefCount++.
    //              if (m_State==false /* not finished */): AddCallback(callback);
    //                  if (m_bForceReload==false): Init(url, mode, initArgs)  // resume init
    //                  else if (mode==Sync): DoDispose(); ReInit(mode, initArgs);  // hard reset
    //              else (loader finished): if (callback != null) callback(ResultObject);
    //   3. Return cast inner[url] → T.
    public static T GetLoader<T>(string url, BaseLoader.LoaderCallBack loaderCallBack,
                                 LoaderMode loaderMode, params object[] initArgs)
        where T : BaseLoader
    {
        if (string.IsNullOrEmpty(url))
        {
            Debug.LogError("[LoaderManager.GetLoader] url null/empty");
            return null;
        }

        // Step 1: outer dict lookup
        Type t = typeof(T);
        if (!_LoaderPool.TryGetValue(t, out var inner) || inner == null)
        {
            inner = new Dictionary<string, BaseLoader>();
            _LoaderPool[t] = inner;
        }

        // Step 2: inner dict lookup
        if (!inner.TryGetValue(url, out var loader) || loader == null)
        {
            // MISS — create new.
            // gốc uses Activator.CreateInstance<T>() (line 209). Our BaseLoader
            // currently inherits MonoBehaviour (DEVIATION from gốc plain-object), so
            // use new GameObject + AddComponent<T> to satisfy Unity's lifecycle.
            // FIXME(canonicalization): when BaseLoader is later moved off MonoBehaviour,
            //   replace with `T fresh = (T)Activator.CreateInstance(typeof(T));`.
            var go = new GameObject($"{typeof(T).Name}_{System.IO.Path.GetFileNameWithoutExtension(url)}");
            UnityEngine.Object.DontDestroyOnLoad(go);
            T fresh = go.AddComponent<T>();
            fresh.RefCount = 1;
            fresh.AddCallback(loaderCallBack);
            fresh.Init(url, loaderMode, initArgs);
            inner[url] = fresh;
            return fresh;
        }
        else
        {
            // HIT — refcount + replay
            if (loader.RefCount < 0)
            {
                Debug.LogError($"[LoaderManager.GetLoader] negative RefCount on '{url}' (was {loader.RefCount}); resetting.");
                loader.RefCount = 0;
            }
            loader.RefCount++;

            if (!loader.IsCompleted)
            {
                // Not finished — chain callback into existing flow.
                loader.AddCallback(loaderCallBack);
                // gốc calls Init or ReInit depending on m_bForceReload (offset +0x31).
                // BaseLoader.m_bForceReload protected — Init/ReInit both no-op on completed loader anyway.
                // For TIER 1 simplicity, just chain callback (the existing Init in flight will fire it).
            }
            else
            {
                // Finished — fire callback synchronously with cached result.
                loaderCallBack?.Invoke(loader.ResultObject);
            }
            return loader as T;
        }
    }

    // VMA: 0x180CB28 — Source: LoaderManager.c:64 (ReleaseLoader)
    // gốc body: if (loader != null) call virtual_at_offset_0x1d8(loader, ...);  // Release virtual.
    // Maps to BaseLoader.Release().
    public static void ReleaseLoader(BaseLoader loader)
    {
        loader?.Release();
    }
}
