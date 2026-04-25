// Class:  CoroutineManager (root namespace, NOT I2.Loc)
// GUID:   cfe55115cf4785d94ab9b152631a83fa (preserved via .meta)
// Source: KTO_DecompiledReference/_root/CoroutineManager.c (3 methods, 128 LOC)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.
// Note: I2.Loc.CoroutineManager is a SEPARATE class (TypeDefIndex 1547) ported elsewhere if needed.

using System.Collections;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    private static CoroutineManager _instance;

    // VMA: 0x01a6474b — Source: CoroutineManager.c:15 (StartCor)
    // gốc body:
    //   if (Object.op_Equality(_instance, null)) {
    //     GameObject go = new GameObject("CoroutineManager");
    //     Object.DontDestroyOnLoad(go);
    //     _instance = go.AddComponent<CoroutineManager>();
    //   }
    //   _instance.StartCoroutine(coroutine);
    public static void StartCor(IEnumerator coroutine)
    {
        if (_instance == null)
        {
            var go = new GameObject("CoroutineManager");
            DontDestroyOnLoad(go);
            _instance = go.AddComponent<CoroutineManager>();
        }
        _instance.StartCoroutine(coroutine);
    }

    // VMA: 0x01a75329 — Source: CoroutineManager.c:66 (CreateCoroutine)
    // gốc body:
    //   if (Object.op_Equality(_instance, null)) {
    //     GameObject go = new GameObject("CoroutineManager");
    //     Object.DontDestroyOnLoad(go);
    //     _instance = go.AddComponent<CoroutineManager>();
    //   }
    //   CoroutineState state = new CoroutineState();
    //   state.coroutine = coroutine;  // gốc field at offset 0x18
    //   return state;
    public static CoroutineState CreateCoroutine(IEnumerator coroutine)
    {
        if (_instance == null)
        {
            var go = new GameObject("CoroutineManager");
            DontDestroyOnLoad(go);
            _instance = go.AddComponent<CoroutineManager>();
        }
        var state = new CoroutineState { coroutine = coroutine };
        return state;
    }

    // VMA: 0x01a75480 — Source: CoroutineManager.c:118 (.ctor)
    // gốc body: UnityEngine_MonoBehaviour___ctor(this, 0); — chain to base.
}

// Inner state class referenced by CreateCoroutine.
// Source: KTO_DecompiledReference/CoroutineManager.CoroutineState/* (separate folder).
public class CoroutineState
{
    public IEnumerator coroutine;     // 0x18
}
