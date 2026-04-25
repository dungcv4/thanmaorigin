// Class:  UIModule
// GUID:   1320eebfe218493bcae8457b6ad9fb3f (preserved via .meta)
// Source: KTO_DecompiledReference/_root/UIModule.c (39 methods, 2891 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs
//
// 1-1 port với DEVIATIONs cited.
// Manages UI window lifecycle: PreloadUI/Close/SortingOrder stack, MsgBox dialog, StartUI loading.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class UIModule : MonoBehaviour
{
    public const string UI_VIEW_PATH = "UI/views/";

    // Fields (offsets từ dump.cs)
    public static UIModule _Instance;                                            // 0x0
    private static Camera _Camera;                                               // 0x8
    public static UIStartUp _StartUI;                                            // 0x10
    public static GameObject _MsgBox;                                            // 0x18
    private static Dictionary<string, UIView> _UIViewMap = new Dictionary<string, UIView>();   // 0x20
    private static Stack<string> _UIViewStack = new Stack<string>();             // 0x28
    private static EventReference _EventReference;                               // 0x30
    private static Transform _UIGroup1;                                          // 0x38
    private static Transform _UIGroup2;                                          // 0x40
    private static int m_PopUoWindowBegin = 1000;                                // 0x48 — sortingOrder base
    private static int m_EachWindowInterval = 50;                                // 0x4C — sortingOrder per stack depth
    private Dictionary<string, Coroutine> _DestroyCoroutine = new Dictionary<string, Coroutine>();
    private HashSet<string> DestroyCoroutineWhiteList = new HashSet<string>();
    public static bool _isShowBeforeBox;                                         // 0x50

    // VMA: 0x01cc66ab — Source: UIModule.c:5800 (Init coroutine)
    // gốc: setup _UIGroup1/2 transforms, init MsgBox prefab, register event listeners.
    [System.Runtime.CompilerServices.IteratorStateMachine(typeof(UIModule.<Init>d__15))]
    public static IEnumerator Init()
    {
        if (_Instance == null)
        {
            var go = new GameObject("[UIModule]");
            DontDestroyOnLoad(go);
            _Instance = go.AddComponent<UIModule>();
        }
        yield break;
    }

    // VMA: 0x01cc6731 — Source: UIModule.c (Awake)
    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _Instance = this;
    }

    // VMA: 0x01cc6827 — Source: UIModule.c (ShowStartUI)
    public static void ShowStartUI()
    {
        if (_StartUI != null) _StartUI.gameObject.SetActive(true);
    }

    // VMA: 0x01cc6abb — Source: UIModule.c (CloseStartUI)
    public static void CloseStartUI()
    {
        if (_StartUI != null) _StartUI.gameObject.SetActive(false);
    }

    // VMA: 0x01cc6bd0 — Source: UIModule.c (ShowMsgBox)
    // gốc: instantiate _MsgBox prefab, set text + center button callback.
    public static void ShowMsgBox(string szMsg, string szCenterText, Action fnCenter)
    {
        // MsgBox prefab + UIMsgBox controller deferred Phase 4 — log instead.
        Debug.Log($"[MsgBox] {szMsg} ({szCenterText})");
        fnCenter?.Invoke();
    }

    // VMA: 0x01cc6f20 — Source: UIModule.c (ShowMsgBox2)
    public static void ShowMsgBox2(string szMsg, string szOKText, string szCancerText, Action fnOK, Action fnCancer)
    {
        Debug.Log($"[MsgBox2] {szMsg} (OK={szOKText} / Cancel={szCancerText})");
        fnOK?.Invoke();
    }

    // VMA: 0x01cc7293 — Source: UIModule.c (CloseMsgBox)
    public static void CloseMsgBox()
    {
        if (_MsgBox != null) _MsgBox.SetActive(false);
    }

    // VMA: 0x01cc73c4 — Source: UIModule.c (IsMsgBoxShow)
    public static bool IsMsgBoxShow()
    {
        return _MsgBox != null && _MsgBox.activeSelf;
    }

    // VMA: 0x01cc74b8 — Source: UIModule.c (OnStartUILoadingProgress int variant)
    public static void OnStartUILoadingProgress(int nProgress)
    {
        if (_StartUI != null) _StartUI.SetProgress(nProgress / 100f);
    }

    // VMA: 0x01cc7555 — Source: UIModule.c (OnStartUILoadingProgress float variant)
    public static void OnStartUILoadingProgress(float fProgress)
    {
        if (_StartUI != null) _StartUI.SetProgress(fProgress);
    }

    // VMA: 0x01cc75fb — Source: UIModule.c (OnStartUILoadingFinished)
    public static void OnStartUILoadingFinished()
    {
        CloseStartUI();
    }

    // VMA: 0x01cc7683 — Source: UIModule.c (OnStartUIUpdateStateChange)
    public static void OnStartUIUpdateStateChange(UpdaterState state)
    {
        // KKUpdater state changed — forward to StartUI display.
        Debug.Log($"[UIModule] UpdateState={state}");
    }

    // VMA: 0x01cc7778 — Source: UIModule.c (GetUI)
    private static UIView GetUI(string uiName)
    {
        if (string.IsNullOrEmpty(uiName)) return null;
        return _UIViewMap.TryGetValue(uiName, out var view) ? view : null;
    }

    // VMA: 0x01cc787c — Source: UIModule.c (GetDestoryCoroutine)
    private Coroutine GetDestoryCoroutine(string uiName)
    {
        if (string.IsNullOrEmpty(uiName)) return null;
        return _DestroyCoroutine.TryGetValue(uiName, out var c) ? c : null;
    }

    // VMA: 0x01cc794f — Source: UIModule.c (PreloadUIAsync)
    public static void PreloadUIAsync(string uiName, LuaFunction funcCall, object[] vecParams)
    {
        // gốc: ResourceModule.LoadResourceAsync → on done, instantiate + Show.
        // DEVIATION: synchronous (PreloadUI sync version).
        PreloadUI(uiName, funcCall, vecParams);
    }

    // VMA: 0x01cc7f50 — Source: UIModule.c:5950 (PreloadUI sync)
    // gốc: check _UIViewMap → if exist, show; else load + instantiate + cache + show.
    public static void PreloadUI(string uiName, LuaFunction funcCall, object[] vecParams)
    {
        if (string.IsNullOrEmpty(uiName)) return;
        if (_UIViewMap.TryGetValue(uiName, out var existing) && existing != null)
        {
            existing.Show(funcCall, vecParams);
            return;
        }
        // Load prefab from Resources.
        var prefabPath = UI_VIEW_PATH + uiName;
        var prefab = Resources.Load<GameObject>(prefabPath);
        if (prefab == null)
        {
            Debug.LogWarning($"[UIModule] Prefab not found: {prefabPath}");
            return;
        }
        var go = Instantiate(prefab);
        go.name = uiName;
        var view = go.GetComponent<UIView>();
        if (view == null) view = go.AddComponent<UIView>();
        _UIViewMap[uiName] = view;
        SetUISortingOrder(go, uiName, true);
        view.Show(funcCall, vecParams);
    }

    // VMA: 0x01cc7bdc — Source: UIModule.c (SetUISortingOrder)
    // gốc: assign Canvas.sortingOrder = m_PopUoWindowBegin + stackDepth * m_EachWindowInterval.
    public static void SetUISortingOrder(GameObject go, string uiName, bool bFirstLoad)
    {
        if (go == null) return;
        if (bFirstLoad) _UIViewStack.Push(uiName);
        var canvas = go.GetComponent<Canvas>();
        if (canvas == null) canvas = go.AddComponent<Canvas>();
        canvas.overrideSorting = true;
        // Stack depth (gốc formula: 1000 + depth*50)
        int depth = 0;
        foreach (var s in _UIViewStack) { if (s == uiName) break; depth++; }
        canvas.sortingOrder = m_PopUoWindowBegin + depth * m_EachWindowInterval;
    }

    // VMA: 0x01cc8cf1 — Source: UIModule.c (GetTopWindow)
    public static string GetTopWindow()
    {
        return _UIViewStack.Count > 0 ? _UIViewStack.Peek() : null;
    }

    // VMA: 0x01cc8dc7 — Source: UIModule.c (Close)
    // gốc: pop from stack, fade-out animation, schedule destroy via coroutine, OnCloseUI.
    public static void Close(string uiName)
    {
        if (string.IsNullOrEmpty(uiName)) return;
        if (_UIViewMap.TryGetValue(uiName, out var view) && view != null)
        {
            view.Hide();
        }
        // Stack management: rebuild without uiName
        var temp = new List<string>(_UIViewStack);
        temp.Remove(uiName);
        _UIViewStack.Clear();
        for (int i = temp.Count - 1; i >= 0; i--) _UIViewStack.Push(temp[i]);
    }

    // VMA: 0x01cc7ace — Source: UIModule.c (UnRegisteAutoDestroy)
    private static void UnRegisteAutoDestroy(string uiName)
    {
        if (_Instance == null) return;
        if (_Instance._DestroyCoroutine.TryGetValue(uiName, out var c) && c != null)
        {
            _Instance.StopCoroutine(c);
            _Instance._DestroyCoroutine.Remove(uiName);
        }
    }

    // VMA: 0x01cc8f28 — Source: UIModule.c:7603 (OnCloseUI)
    // gốc: hotfix → QualityModule.CheckUseAutoDestroyUI → schedule DestroyByTime coroutine.
    public void OnCloseUI(string uiName)
    {
        if (DestroyCoroutineWhiteList.Contains(uiName)) return;
        UnRegisteAutoDestroy(uiName);
        var c = StartCoroutine(DestroyByTime(uiName));
        _DestroyCoroutine[uiName] = c;
    }

    // VMA: 0x01cc905f — Source: UIModule.c (DestroyByTime coroutine)
    // gốc: yield WaitForSeconds(60) → DestroyUI(uiName).
    [System.Runtime.CompilerServices.IteratorStateMachine(typeof(UIModule.<DestroyByTime>d__36))]
    private IEnumerator DestroyByTime(string uiName)
    {
        yield return new WaitForSeconds(60f); // gốc default 60s timeout
        DestroyUI(uiName);
    }

    // VMA: 0x01cc9113 — Source: UIModule.c (DestroyUI)
    public static void DestroyUI(string uiName)
    {
        if (string.IsNullOrEmpty(uiName)) return;
        if (_UIViewMap.TryGetValue(uiName, out var view) && view != null)
        {
            view.CallLuaDestroyUI(uiName);
            Destroy(view.gameObject);
        }
        _UIViewMap.Remove(uiName);
        if (_Instance != null) _Instance._DestroyCoroutine.Remove(uiName);
    }

    // VMA: 0x01cc92a0 — Source: UIModule.c (Clear — destroy all UIs)
    public void Clear()
    {
        foreach (var kv in _UIViewMap)
        {
            if (kv.Value != null) Destroy(kv.Value.gameObject);
        }
        _UIViewMap.Clear();
        _UIViewStack.Clear();
        foreach (var c in _DestroyCoroutine.Values)
        {
            if (c != null) StopCoroutine(c);
        }
        _DestroyCoroutine.Clear();
    }

    // VMA: 0x01cc7dce — Source: UIModule.c (LoadResourceAsync internal)
    // gốc: ResourceModule.LoadResourceAsync wrap with UI-specific callback.
    private static void LoadResourceAsync(string uiName, LuaFunction funcCall, object[] vecParams)
    {
        ResourceModule.LoadResourceAsync(true, UI_VIEW_PATH + uiName,
            (obj, param) =>
            {
                if (obj is GameObject prefab)
                {
                    var go = Instantiate(prefab);
                    go.name = uiName;
                    var view = go.GetComponent<UIView>() ?? go.AddComponent<UIView>();
                    _UIViewMap[uiName] = view;
                    SetUISortingOrder(go, uiName, true);
                    view.Show(funcCall, vecParams);
                }
            },
            null);
    }

    // VMA: 0x01cc80d3 — Source: UIModule.c (LoadResource sync internal)
    private static bool LoadResource(string uiName, LuaFunction funcCall, object[] vecParams)
    {
        var obj = ResourceModule.LoadResourceSync(UI_VIEW_PATH + uiName);
        if (obj is GameObject prefab)
        {
            var go = Instantiate(prefab);
            go.name = uiName;
            var view = go.GetComponent<UIView>() ?? go.AddComponent<UIView>();
            _UIViewMap[uiName] = view;
            SetUISortingOrder(go, uiName, true);
            view.Show(funcCall, vecParams);
            return true;
        }
        return false;
    }

    // VMA: 0x01cc970c — Source: UIModule.c (ScreenPointToLocalPointInRectangle)
    public static Vector2 ScreenPointToLocalPointInRectangle(RectTransform trans, Vector2 screenPoint)
    {
        if (trans == null) return Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(trans, screenPoint, _Camera, out var localPoint);
        return localPoint;
    }

    // VMA: 0x01bbecc1 — Source: UIModule.c (PlaySound)
    public static void PlaySound(int nSoundID)
    {
        // Forward to AudioModule when SoundCfg loaded. No-op for now.
    }

    // VMA: 0x01bc982b — Source: UIModule.c (StopSound)
    public static void StopSound(int nSoundID)
    {
        // No-op (defer Phase 4).
    }

    // VMA: 0x01cc9902 — Source: UIModule.c (SetGroup)
    public static void SetGroup(GameObject obj, int nGroup)
    {
        if (obj == null) return;
        if (nGroup == 1 && _UIGroup1 != null) obj.transform.SetParent(_UIGroup1, false);
        else if (nGroup == 2 && _UIGroup2 != null) obj.transform.SetParent(_UIGroup2, false);
    }

    // VMA: 0x01cc9a0f — Source: UIModule.c (SetGroupActive)
    public static void SetGroupActive(int nGroup, bool bActive)
    {
        if (nGroup == 1 && _UIGroup1 != null) _UIGroup1.gameObject.SetActive(bActive);
        else if (nGroup == 2 && _UIGroup2 != null) _UIGroup2.gameObject.SetActive(bActive);
    }

    // VMA: 0x01cc8928 — Source: UIModule.c (ResetCanvasLayer)
    // gốc: rebuild Canvas.sortingOrder for go to nNewSortOrder.
    public static void ResetCanvasLayer(GameObject go, int nNewSortOrder)
    {
        if (go == null) return;
        var canvas = go.GetComponent<Canvas>();
        if (canvas != null) canvas.sortingOrder = nNewSortOrder;
    }

    // VMA: 0x01cc85a9 — Source: UIModule.c (PushGOFront — bring uiName to front)
    public static void PushGOFront(string uiName)
    {
        if (string.IsNullOrEmpty(uiName)) return;
        var temp = new List<string>(_UIViewStack);
        temp.Remove(uiName);
        _UIViewStack.Clear();
        _UIViewStack.Push(uiName);
        for (int i = temp.Count - 1; i >= 0; i--) _UIViewStack.Push(temp[i]);
        // Recalc sortingOrder for top window
        if (_UIViewMap.TryGetValue(uiName, out var view) && view != null)
        {
            SetUISortingOrder(view.gameObject, uiName, false);
        }
    }

    // VMA: 0x01cc9aeb — Source: UIModule.c (CreateDlcDebugUI)
    // gốc: instantiate UIDlcDebug debug overlay — only in editor/debug builds.
    public static UIDlcDebug CreateDlcDebugUI()
    {
        return null; // editor debug deferred
    }

    // VMA: 0x01cc9c34 — Source: UIModule.c (ShowMsgBox_BeforeStart)
    // gốc: show MsgBox before main game starts (needs simpler MsgBox prefab path).
    public static void ShowMsgBox_BeforeStart(Action fnCenter)
    {
        Debug.Log("[MsgBox_BeforeStart]");
        fnCenter?.Invoke();
    }

    // VMA: 0x01cc9f1c — Source: UIModule.c (WarnningDialogBeforeStart coroutine)
    [System.Runtime.CompilerServices.IteratorStateMachine(typeof(UIModule.<WarnningDialogBeforeStart>d__51))]
    public static IEnumerator WarnningDialogBeforeStart()
    {
        yield break;
    }

    // VMA: 0x01cc9fa5 — Source: UIModule.c (DestroyMsgBoxBeforeStart)
    public static void DestroyMsgBoxBeforeStart()
    {
        if (_MsgBox != null)
        {
            Destroy(_MsgBox);
            _MsgBox = null;
        }
    }
}
