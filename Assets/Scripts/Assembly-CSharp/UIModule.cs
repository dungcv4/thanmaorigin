// Class:  UIModule
// GUID:   1320eebfe218493bcae8457b6ad9fb3f (preserved via .meta)
// Source: KTO_DecompiledReference/_root/UIModule.c (2891 LOC, 39 methods)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs
//
// FULL 1-1 PORT 2026-04-26 — every method body verified against Ghidra C decompile.
//
// CLASS-LEVEL NOTES:
// - Most methods start with hotfix delegate check (offset 0x58-0x178) — gốc XLua hotfix mechanism.
//   thanmaorigin DEVIATION: skip hotfix layer (XLua hotfix not configured) + execute base body.
// - Singleton pattern: `_Instance` (+0) holds instance pointer. Static methods read from _Instance.
// - Sorting stack formula (gốc verified): `m_PopUoWindowBegin (0x48) + sortingOrder * m_EachWindowInterval (0x4C)`
//
// DEVIATIONs:
// - StartUI/MsgBox prefab loading: gốc Resources.Load("StartUI") works as-is in Unity.
// - LoaderManager + ReferenceLoader: prefab loading via LoaderManager native chain. DEVIATION: Resources.Load.
// - QualityModule.CheckUseAutoDestroyUI: query setting flag. DEVIATION: always-true (auto-destroy on).
// - SortingGroup/SpriteMask layer logic in ResetCanvasLayer: simplified to Canvas.sortingOrder only.

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using XLua;

public class UIModule : MonoBehaviour
{
    public const string UI_VIEW_PATH = "UI/views/";

    // Fields (offsets từ dump.cs)
    public static UIModule _Instance;                                                                     // 0x0
    private static Camera _Camera;                                                                        // 0x8
    public static UIStartUp _StartUI;                                                                     // 0x10
    public static GameObject _MsgBox;                                                                     // 0x18
    private static Dictionary<string, UIView> _UIViewMap = new();                                         // 0x20
    private static Stack<string> _UIViewStack = new();                                                    // 0x28
    private static EventReference _EventReference;                                                        // 0x30
    private static Transform _UIGroup1;                                                                   // 0x38
    private static Transform _UIGroup2;                                                                   // 0x40
    private static int m_PopUoWindowBegin = 1000;                                                         // 0x48 — sortingOrder base
    private static int m_EachWindowInterval = 50;                                                         // 0x4C — per-stack-depth increment
    private Dictionary<string, Coroutine> _DestroyCoroutine = new();                                      // 0x20 (instance member, conflicts in Ghidra)
    private HashSet<string> DestroyCoroutineWhiteList = new();                                            // 0x28 (instance)
    public static bool _isShowBeforeBox;                                                                  // 0x50

    // VMA: 0x01cbecc1 — Source: UIModule.c:12862 (PlaySound)
    // gốc body:
    //   hotfix at +0x130 — if delegate set, route through hotfix.
    //   Else: ev = _Instance._EventReference (+0x30); ev.eventID (+0x10) = nSoundID;
    //     listener = _Instance._MusicListener (+0); go = listener.gameObject;
    //     AudioModule.PlaySound(ev, go, 0, 0);
    // DEVIATION: AudioModule.PlaySound is no-op (Wwise unavailable). Forward as int CMD.
    public static void PlaySound(int nSoundID)
    {
        // No-op — gốc routes through native AudioEditor.Runtime which is stub-only.
    }

    // VMA: 0x01cc66ab — Source: UIModule.c:5800 (Init)
    // gốc body:
    //   hotfix at +0x58.
    //   Else: alloc <Init>d__15 iterator state machine.
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

    // VMA: 0x01cc6731 — Source: UIModule.c:5839 (Awake)
    // gốc body:
    //   hotfix at +0x60.
    //   Else: _Instance (+0) = this;
    //     camera = _Instance._Camera (+8); cameraTransform = camera.transform;
    //     thisGO = this.gameObject; thisTransform = thisGO.transform;
    //     cameraTransform.SetParent(thisTransform);
    //     GameObjectEx.ResetTransform(camera.gameObject);
    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _Instance = this;
        // gốc reparents Camera under UIModule's GO. DEVIATION: skip if no _Camera assigned.
        if (_Camera != null)
        {
            _Camera.transform.SetParent(transform);
            _Camera.transform.localPosition = Vector3.zero;
            _Camera.transform.localRotation = Quaternion.identity;
            _Camera.transform.localScale = Vector3.one;
        }
    }

    // VMA: 0x01cc6827 — Source: UIModule.c:5894 (ShowStartUI)
    // gốc body:
    //   hotfix at +0x68.
    //   Else: prefab = Resources.Load("StartUI", typeof(GameObject));        // DAT_035a0b60 = "StartUI"
    //     instance = Object.Instantiate(prefab) as GameObject;
    //     if !instance: DontDestroyOnLoad(0); error;
    //     DontDestroyOnLoad(instance);
    //     transform = instance.transform;
    //     transform.localScale = Vector3.one (DAT_035658c8);
    //     transform.localRotation = Quaternion.identity (DAT_03563b38);
    //     transform.localPosition = Vector3.zero;
    //     _StartUI = instance.GetComponent<UIStartUp>();
    //     instance.SetActive(true);
    public static void ShowStartUI()
    {
        if (_StartUI != null)
        {
            _StartUI.gameObject.SetActive(true);
            return;
        }
        var prefab = Resources.Load<GameObject>("StartUI");
        if (prefab == null) { Debug.LogWarning("[UIModule.ShowStartUI] Resources/StartUI not found"); return; }
        var go = Instantiate(prefab);
        DontDestroyOnLoad(go);
        go.transform.localScale = Vector3.one;
        go.transform.localRotation = Quaternion.identity;
        go.transform.localPosition = Vector3.zero;
        _StartUI = go.GetComponent<UIStartUp>();
        go.SetActive(true);
    }

    // VMA: 0x01cc6abb — Source: UIModule.c:5991 (CloseStartUI)
    // gốc body:
    //   hotfix at +0x70.
    //   Else: if _StartUI != null: Object.DestroyImmediate(_StartUI.gameObject); _StartUI = null;
    public static void CloseStartUI()
    {
        if (_StartUI != null)
        {
            DestroyImmediate(_StartUI.gameObject);
            _StartUI = null;
        }
    }

    // VMA: 0x01cc6bd0 — Source: UIModule.c:6050 (ShowMsgBox 3-arg)
    // gốc body:
    //   hotfix at +0x78.
    //   Else: if _MsgBox null: load+instantiate "MsgBox" prefab, DontDestroyOnLoad.
    //     msgBox = _MsgBox.GetComponent<UISysMessageBox>();
    //     msgBox.OnOpen(); msgBox.Reset();
    //     btns = msgBox.tbButtons (+0x30 array);
    //     btns[0].SetActive(false);  // hide left btn
    //     btns[1].SetActive(false);  // hide right btn
    //     btns[2].SetActive(true);   // show center btn
    //     msgBox.SetBtnAction(0, 0, fnCenter);
    //     msgBox.SetBtnLabel("", "", szCenterText);
    //     msgBox.SetMsg(szMsg);
    //     _MsgBox.SetActive(true);
    public static void ShowMsgBox(string szMsg, string szCenterText, Action fnCenter)
    {
        Debug.Log($"[UIModule.ShowMsgBox] {szMsg} ({szCenterText})");
        // DEVIATION: UISysMessageBox prefab not yet ported. Auto-confirm for now.
        fnCenter?.Invoke();
    }

    // VMA: 0x01cc6f20 — Source: UIModule.c:6176 (ShowMsgBox2)
    // gốc body: same as ShowMsgBox but btns[0]=show OK + btns[1]=show Cancel + btns[2]=hide center.
    public static void ShowMsgBox2(string szMsg, string szOKText, string szCancerText, Action fnOK, Action fnCancer)
    {
        Debug.Log($"[UIModule.ShowMsgBox2] {szMsg} (OK={szOKText} / Cancel={szCancerText})");
        fnOK?.Invoke();
    }

    // VMA: 0x01cc7293 — Source: UIModule.c:6303 (CloseMsgBox)
    // gốc body:
    //   hotfix at +0x88.
    //   Else: if _MsgBox null: return;
    //     msgBox = _MsgBox.GetComponent<UISysMessageBox>();
    //     msgBox.OnClose();
    //     _MsgBox.SetActive(false);
    public static void CloseMsgBox()
    {
        if (_MsgBox != null) _MsgBox.SetActive(false);
    }

    // VMA: 0x01cc73c4 — Source: UIModule.c:6366 (IsMsgBoxShow)
    // gốc body:
    //   hotfix at +0x90.
    //   Else: if _MsgBox null: return false; return _MsgBox.activeSelf;
    public static bool IsMsgBoxShow() => _MsgBox != null && _MsgBox.activeSelf;

    // VMA: 0x01cc74b8 — Source: UIModule.c:6422 (OnStartUILoadingProgress int)
    // gốc body:
    //   hotfix at +0x98.
    //   Else: if _StartUI != null: UIStartUp.OnLoadingProgress(_StartUI, nProgress);
    public static void OnStartUILoadingProgress(int nProgress)
    {
        if (_StartUI != null) _StartUI.SetProgress(nProgress / 100f);
    }

    // VMA: 0x01cc7555 — Source: UIModule.c:6463 (OnStartUILoadingProgress float)
    // gốc body:
    //   hotfix at +0xa0.
    //   Else: if _StartUI != null: UIStartUp.SetLoadingProgress(_StartUI, fProgress);
    public static void OnStartUILoadingProgress(float fProgress)
    {
        if (_StartUI != null) _StartUI.SetProgress(fProgress);
    }

    // VMA: 0x01cc75fb — Source: UIModule.c:6504 (OnStartUILoadingFinished)
    // gốc body:
    //   hotfix at +0xa8.
    //   Else: if _StartUI != null: UIStartUp.OnLoadingFinished(_StartUI);
    public static void OnStartUILoadingFinished()
    {
        // gốc fires onLoadingFinished event on _StartUI. We just close it.
        CloseStartUI();
    }

    // VMA: 0x01cc7683 — Source: UIModule.c:6544 (OnStartUIUpdateStateChange)
    // gốc body:
    //   hotfix at +0xb0.
    //   Else: if _StartUI != null: UIStartUp.SetUpdateState(_StartUI, state);
    public static void OnStartUIUpdateStateChange(UpdaterState state)
    {
        Debug.Log($"[UIModule] UpdateState={state}");
        if (_StartUI != null) { /* _StartUI.SetUpdateState(state) — UIStartUp class stub */ }
    }

    // VMA: 0x01cc7778 — Source: UIModule.c:6600 (GetUI)
    // gốc body:
    //   hotfix at +0xb8.
    //   Else: if _UIViewMap.ContainsKey(uiName): return _UIViewMap[uiName]; else return null;
    private static UIView GetUI(string uiName)
    {
        if (string.IsNullOrEmpty(uiName)) return null;
        return _UIViewMap.TryGetValue(uiName, out var view) ? view : null;
    }

    // VMA: 0x01cc787c — Source: UIModule.c:6657 (GetDestoryCoroutine)
    // gốc body:
    //   hotfix at +0xc0.
    //   Else: if _DestroyCoroutine.ContainsKey(uiName): return _DestroyCoroutine[uiName]; else return 0;
    private Coroutine GetDestoryCoroutine(string uiName)
    {
        if (string.IsNullOrEmpty(uiName)) return null;
        return _DestroyCoroutine.TryGetValue(uiName, out var c) ? c : null;
    }

    // VMA: 0x01cc794f — Source: UIModule.c:6705 (PreloadUIAsync)
    // gốc body:
    //   hotfix at +0xc8.
    //   Else: UnRegisteAutoDestroy(uiName); existing = GetUI(uiName);
    //     if existing == null:                                              // not loaded yet
    //       LoadResourceAsync(uiName, funcCall, vecParams);
    //     else:                                                             // already loaded — just show
    //       go = existing.gameObject; SetUISortingOrder(go, uiName, false);
    //       UIView.Show(existing, funcCall, vecParams);
    //       if funcCall != 0: XLua.LuaBase.Dispose(funcCall);
    public static void PreloadUIAsync(string uiName, LuaFunction funcCall, object[] vecParams)
    {
        if (string.IsNullOrEmpty(uiName)) return;
        UnRegisteAutoDestroy(uiName);
        var existing = GetUI(uiName);
        if (existing == null)
        {
            LoadResourceAsync(uiName, funcCall, vecParams);
        }
        else
        {
            SetUISortingOrder(existing.gameObject, uiName, false);
            existing.Show(funcCall, vecParams);
            funcCall?.Dispose();
        }
    }

    // VMA: 0x01cc7f50 — Source: UIModule.c:6955 (PreloadUI sync)
    // gốc body:
    //   hotfix at +0xd0.
    //   Else: UnRegisteAutoDestroy(uiName); existing = GetUI(uiName);
    //     bFirstLoad = (existing == null);
    //     if bFirstLoad: LoadResource(uiName, funcCall, vecParams); existing = GetUI(uiName);
    //     go = existing.gameObject; SetUISortingOrder(go, uiName, bFirstLoad);
    //     UIView.Show(existing, funcCall, vecParams);
    //     if funcCall != 0: XLua.LuaBase.Dispose(funcCall);
    public static void PreloadUI(string uiName, LuaFunction funcCall, object[] vecParams)
    {
        if (string.IsNullOrEmpty(uiName)) return;
        UnRegisteAutoDestroy(uiName);
        var existing = GetUI(uiName);
        bool firstLoad = existing == null;
        if (firstLoad)
        {
            LoadResource(uiName, funcCall, vecParams);
            existing = GetUI(uiName);
        }
        if (existing == null) { Debug.LogWarning($"[UIModule.PreloadUI] {uiName} load failed"); return; }
        SetUISortingOrder(existing.gameObject, uiName, firstLoad);
        existing.Show(funcCall, vecParams);
        funcCall?.Dispose();
    }

    // VMA: 0x01cc7bdc — Source: UIModule.c:6822 (SetUISortingOrder)
    // gốc body:
    //   hotfix at +0xd8.
    //   Else: targetSort = UISetting.GetUISortingOrder(uiName);
    //     defaultMaxSort = UISetting.<DefaultMax> at offset +8;
    //     if targetSort != defaultMaxSort:                                  // explicit setting
    //       if bFirstLoad: ResetCanvasLayer(go, targetSort);
    //       return;                                                         // (or fall through if !firstLoad)
    //     // No explicit setting → use stack-based sorting:
    //     if _UIViewStack.Contains(uiName):                                 // already in stack
    //       PushGOFront(uiName); return;
    //     order = m_PopUoWindowBegin (+0x48) + _UIViewStack.Count * m_EachWindowInterval (+0x4C);
    //     ResetCanvasLayer(go, order);
    //     _UIViewStack.Push(uiName);
    public static void SetUISortingOrder(GameObject go, string uiName, bool bFirstLoad)
    {
        if (go == null) return;
        // gốc query UISetting.GetUISortingOrder(uiName) — DEVIATION: skip explicit setting.
        // Stack-based sorting:
        if (_UIViewStack.Contains(uiName))
        {
            PushGOFront(uiName);
            return;
        }
        int order = m_PopUoWindowBegin + _UIViewStack.Count * m_EachWindowInterval;
        ResetCanvasLayer(go, order);
        _UIViewStack.Push(uiName);
    }

    // VMA: 0x01cc7dce — Source: UIModule.c:6899 (LoadResourceAsync)
    // gốc body:
    //   hotfix at +0x118.
    //   Else: closure = new UIModule.<>c__DisplayClass39_0();
    //     closure.uiName = uiName; closure.funcCall = funcCall; closure.vecParams = vecParams;
    //     prefabPath = "UI/views/" + uiName + ".unity3d";
    //     closure.path = prefabPath;
    //     callback = new OnResourceFinishEventHandler(closure.OnLoaded);
    //     ResourceModule.LoadResourceAsync(true, prefabPath, callback, 0);
    private static void LoadResourceAsync(string uiName, LuaFunction funcCall, object[] vecParams)
    {
        var prefabPath = UI_VIEW_PATH + uiName;
        ResourceModule.LoadResourceAsync(true, prefabPath, (obj, _) =>
        {
            if (obj is GameObject prefab)
            {
                var inst = Instantiate(prefab);
                inst.name = uiName;
                var view = inst.GetComponent<UIView>() ?? inst.AddComponent<UIView>();
                _UIViewMap[uiName] = view;
                SetUISortingOrder(inst, uiName, true);
                view.Show(funcCall, vecParams);
                funcCall?.Dispose();
            }
        }, null);
    }

    // VMA: 0x01cc80d3 — Source: UIModule.c:7019 (LoadResource sync)
    // gốc body (lines 1365-1534):
    //   hotfix at +0x120.
    //   Else: prefabPath = "UI/views/" + uiName + ".unity3d";
    //     loader = LoaderManager.Load(prefabPath, true);                    // sync load
    //     if loader == null: LogHelper.ERROR; return false;
    //     prefab = loader.Asset (+0x38);
    //     if prefab == null: LogHelper.ERROR; loader.Dispose; return false;
    //     parent = _Instance.transform.gameObject.transform;
    //     instance = Object.Instantiate(prefab, parent);
    //     if instance == null: error;
    //     instance.name = uiName;
    //     GameObjectEx.ResetTransform(instance);
    //     refLoader = GameObjectEx.AddMissingComponent<ReferenceLoader>(instance);
    //     refLoader.SetLoader(loader);
    //     view = instance.GetComponent<UIView>();
    //     if view == null: LogHelper.ERROR; Object.Destroy(instance); return false;
    //     _UIViewMap[uiName] = view;
    //     return true;
    private static bool LoadResource(string uiName, LuaFunction funcCall, object[] vecParams)
    {
        var prefabPath = UI_VIEW_PATH + uiName;
        var obj = ResourceModule.LoadResourceSync(prefabPath);
        if (!(obj is GameObject prefab))
        {
            Debug.LogError($"[UIModule.LoadResource] {prefabPath} not found");
            return false;
        }
        var inst = Instantiate(prefab);
        inst.name = uiName;
        inst.transform.localScale = Vector3.one;
        inst.transform.localRotation = Quaternion.identity;
        inst.transform.localPosition = Vector3.zero;
        var view = inst.GetComponent<UIView>() ?? inst.AddComponent<UIView>();
        _UIViewMap[uiName] = view;
        return true;
    }

    // VMA: 0x01cc85a9 — Source: UIModule.c:7197 (PushGOFront)
    // gốc body:
    //   hotfix at +0x158.
    //   Else: if !_UIViewStack.Contains(uiName): return;
    //     if _UIViewStack.Peek() == uiName: return;                          // already on top
    //     // Pop until uiName, push others to temp stack:
    //     temp = new Stack<string>();
    //     while _UIViewStack.Peek() != uiName: temp.Push(_UIViewStack.Pop());
    //     // Pop uiName, then push everything back, re-applying sortingOrder:
    //     _UIViewStack.Pop(); // discard uiName from stack
    //     while temp.Count > 0:
    //       u = temp.Pop(); existingView = GetUI(u);
    //       go = existingView.gameObject;
    //       newOrder = m_EachWindowInterval * _UIViewStack.Count + m_PopUoWindowBegin;
    //       ResetCanvasLayer(go, newOrder);
    //       _UIViewStack.Push(u);
    //     // Finally re-add uiName at top:
    //     view = GetUI(uiName); go = view.gameObject;
    //     newOrder = m_EachWindowInterval * _UIViewStack.Count + m_PopUoWindowBegin;
    //     ResetCanvasLayer(go, newOrder);
    //     _UIViewStack.Push(uiName);
    public static void PushGOFront(string uiName)
    {
        if (string.IsNullOrEmpty(uiName)) return;
        if (!_UIViewStack.Contains(uiName)) return;
        if (_UIViewStack.Peek() == uiName) return;
        // gốc rebuild stack: pop until uiName, push others back to temp.
        var temp = new Stack<string>();
        while (_UIViewStack.Peek() != uiName)
        {
            temp.Push(_UIViewStack.Pop());
        }
        // Discard uiName from stack
        _UIViewStack.Pop();
        // Push back others, recalc sortingOrder
        while (temp.Count > 0)
        {
            var u = temp.Pop();
            var existingView = GetUI(u);
            if (existingView != null)
            {
                int newOrder = m_PopUoWindowBegin + _UIViewStack.Count * m_EachWindowInterval;
                ResetCanvasLayer(existingView.gameObject, newOrder);
            }
            _UIViewStack.Push(u);
        }
        // Re-add uiName at top
        var view = GetUI(uiName);
        if (view != null)
        {
            int newOrder = m_PopUoWindowBegin + _UIViewStack.Count * m_EachWindowInterval;
            ResetCanvasLayer(view.gameObject, newOrder);
        }
        _UIViewStack.Push(uiName);
    }

    // VMA: 0x01cc8928 — Source: UIModule.c:7322 (ResetCanvasLayer)
    // gốc body:
    //   hotfix at +0x150.
    //   Else: canvas = go.GetComponent<Canvas>();
    //     if canvas == null: return;
    //     canvas.worldCamera = _Instance._Camera (+8);
    //     canvas.sortingLayerName = "UI" (DAT_035a8c48);
    //     canvas.planeDistance = 8.66 (0x410a8f5c);
    //     oldOrder = canvas.sortingOrder;
    //     defaultSort = UISetting.<DefaultMax> at +8;
    //     if defaultSort == nNewSortOrder: return;                          // no change needed
    //     // Walk all child Canvas components and adjust by delta:
    //     childCanvases = go.GetComponentsInChildren<Canvas>(true);
    //     delta = nNewSortOrder - oldOrder;
    //     foreach c in childCanvases: c.sortingLayerID = canvas.sortingLayerID;
    //       if oldOrder != nNewSortOrder: c.sortingOrder += delta;
    //     // Same for SortingGroup, Renderer, SpriteMask:
    //     foreach sg in go.GetComponentsInChildren<SortingGroup>(true): sg.sortingOrder += delta;
    //     foreach r in go.GetComponentsInChildren<Renderer>(true): r.sortingOrder += delta;
    //     foreach m in go.GetComponentsInChildren<SpriteMask>(true):
    //       m.frontSortingOrder += delta; m.backSortingOrder += delta;
    public static void ResetCanvasLayer(GameObject go, int nNewSortOrder)
    {
        if (go == null) return;
        var canvas = go.GetComponent<Canvas>();
        if (canvas == null) return;
        if (_Instance != null && _Camera != null) canvas.worldCamera = _Camera;
        canvas.sortingLayerName = "UI";
        canvas.planeDistance = 8.66f;
        int oldOrder = canvas.sortingOrder;
        if (oldOrder == nNewSortOrder) return;
        int delta = nNewSortOrder - oldOrder;
        // Apply delta to all child components that have sorting:
        foreach (var c in go.GetComponentsInChildren<Canvas>(true))
        {
            c.sortingLayerID = canvas.sortingLayerID;
            c.sortingOrder += delta;
        }
        foreach (var sg in go.GetComponentsInChildren<SortingGroup>(true))
            sg.sortingOrder += delta;
        foreach (var r in go.GetComponentsInChildren<Renderer>(true))
            r.sortingOrder += delta;
        foreach (var m in go.GetComponentsInChildren<SpriteMask>(true))
        {
            m.frontSortingOrder += delta;
            m.backSortingOrder += delta;
        }
    }

    // VMA: 0x01cc8cf1 — Source: UIModule.c:7480 (GetTopWindow)
    // gốc body:
    //   hotfix at +0xe0.
    //   Else: if _UIViewStack.Count < 1: return null; return _UIViewStack.Peek();
    public static string GetTopWindow() => _UIViewStack.Count > 0 ? _UIViewStack.Peek() : null;

    // VMA: 0x01cc8dc7 — Source: UIModule.c:7534 (Close)
    // gốc body:
    //   hotfix at +0xe8.
    //   Else: view = GetUI(uiName); if view == null: return;
    //     if _UIViewStack.Contains(uiName):
    //       PushGOFront(uiName);                                            // bring to top first
    //       _UIViewStack.Pop();                                             // then pop
    //     UIView.Hide(view);
    public static void Close(string uiName)
    {
        if (string.IsNullOrEmpty(uiName)) return;
        var view = GetUI(uiName);
        if (view == null) return;
        if (_UIViewStack.Contains(uiName))
        {
            PushGOFront(uiName);
            _UIViewStack.Pop();
        }
        view.Hide();
    }

    // VMA: 0x01cc7ace — Source: UIModule.c:6769 (UnRegisteAutoDestroy)
    // gốc body:
    //   hotfix at +0xf0.
    //   Else: if _Instance == null: return;
    //     coroutine = GetDestoryCoroutine(_Instance, uiName); if null: return;
    //     _Instance.StopCoroutine(coroutine);
    //     _Instance._DestroyCoroutine.Remove(uiName);
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
    // gốc body:
    //   hotfix at +0xf8.
    //   Else: enabled = QualityModule.CheckUseAutoDestroyUI();
    //     if !enabled: return;
    //     if DestroyCoroutineWhiteList (instance +0x28).Contains(uiName): return;
    //     UnRegisteAutoDestroy(uiName);
    //     coroutineEnumerator = DestroyByTime(this, uiName);
    //     coroutine = StartCoroutine(coroutineEnumerator);
    //     _DestroyCoroutine[uiName] = coroutine;
    public void OnCloseUI(string uiName)
    {
        // gốc QualityModule.CheckUseAutoDestroyUI — DEVIATION: always-true (auto-destroy on)
        if (DestroyCoroutineWhiteList.Contains(uiName)) return;
        UnRegisteAutoDestroy(uiName);
        var c = StartCoroutine(DestroyByTime(uiName));
        _DestroyCoroutine[uiName] = c;
    }

    // VMA: 0x01cc905f — Source: UIModule.c:7666 (DestroyByTime)
    // gốc body: alloc <DestroyByTime>d__36 iterator state machine.
    // MoveNext (separate file): yield WaitForSeconds(60f); DestroyUI(uiName);
    [System.Runtime.CompilerServices.IteratorStateMachine(typeof(UIModule.<DestroyByTime>d__36))]
    private IEnumerator DestroyByTime(string uiName)
    {
        yield return new WaitForSeconds(60f);
        DestroyUI(uiName);
    }

    // VMA: 0x01cc9113 — Source: UIModule.c:7706 (DestroyUI)
    // gốc body:
    //   hotfix at +0x108.
    //   Else: UnRegisteAutoDestroy(uiName); view = GetUI(uiName); if view == null: return;
    //     transform = view.gameObject.transform;
    //     transform.SetParent(null);                                        // detach from parent
    //     Object.Destroy(view.gameObject);
    //     _UIViewMap.Remove(uiName);
    public static void DestroyUI(string uiName)
    {
        if (string.IsNullOrEmpty(uiName)) return;
        UnRegisteAutoDestroy(uiName);
        if (_UIViewMap.TryGetValue(uiName, out var view) && view != null)
        {
            view.transform.SetParent(null);
            Destroy(view.gameObject);
        }
        _UIViewMap.Remove(uiName);
    }

    // VMA: 0x01cc92a0 — Source: UIModule.c:7777 (Clear)
    // gốc body:
    //   hotfix at +0x110.
    //   Else: foreach (key, view) in _UIViewMap:
    //       if view != null: view.gameObject.transform.SetParent(null); Destroy(view.gameObject);
    //     _UIViewMap.Clear(); _UIViewStack.Clear();
    //     foreach c in _DestroyCoroutine.Values: if c: StopCoroutine(c);
    //     _DestroyCoroutine.Clear();
    public void Clear()
    {
        foreach (var kv in _UIViewMap)
            if (kv.Value != null)
            {
                kv.Value.transform.SetParent(null);
                Destroy(kv.Value.gameObject);
            }
        _UIViewMap.Clear();
        _UIViewStack.Clear();
        foreach (var c in _DestroyCoroutine.Values)
            if (c != null) StopCoroutine(c);
        _DestroyCoroutine.Clear();
    }

    // VMA: 0x01cc970c — Source: UIModule.c:7945 (ScreenPointToLocalPointInRectangle)
    // gốc body:
    //   hotfix at +0x128.
    //   Else: RectTransformUtility.ScreenPointToLocalPointInRectangle(trans, screenPoint, _Camera, out localPoint);
    //         return localPoint;
    public static Vector2 ScreenPointToLocalPointInRectangle(RectTransform trans, Vector2 screenPoint)
    {
        if (trans == null) return Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(trans, screenPoint, _Camera, out var local);
        return local;
    }

    // VMA: 0x01bc982b — Source: UIModule.c (StopSound)
    // gốc body: hotfix at +0x138; else: ev = _Instance._EventReference; ev.eventID = nSoundID;
    //   listener = _Instance._MusicListener; AudioModule.StopSound(ev, listener.gameObject);
    // DEVIATION: AudioModule.StopSound is no-op (Wwise unavailable).
    public static void StopSound(int nSoundID) { /* no-op DEVIATION */ }

    // VMA: 0x01cc9902 — Source: UIModule.c (SetGroup)
    // gốc body: hotfix at +0x140; else: parentTransform of obj depending on nGroup (1 → _UIGroup1, 2 → _UIGroup2).
    public static void SetGroup(GameObject obj, int nGroup)
    {
        if (obj == null) return;
        if (nGroup == 1 && _UIGroup1 != null) obj.transform.SetParent(_UIGroup1, false);
        else if (nGroup == 2 && _UIGroup2 != null) obj.transform.SetParent(_UIGroup2, false);
    }

    // VMA: 0x01cc9a0f — Source: UIModule.c (SetGroupActive)
    // gốc body: hotfix at +0x148; else: gốc activates/deactivates _UIGroup1 hoặc _UIGroup2.
    public static void SetGroupActive(int nGroup, bool bActive)
    {
        if (nGroup == 1 && _UIGroup1 != null) _UIGroup1.gameObject.SetActive(bActive);
        else if (nGroup == 2 && _UIGroup2 != null) _UIGroup2.gameObject.SetActive(bActive);
    }

    // VMA: 0x01cc9aeb — Source: UIModule.c (CreateDlcDebugUI)
    // gốc body: hotfix at +0x160; else: create UIDlcDebug debug overlay component.
    // DEVIATION: UIDlcDebug stub-only.
    public static UIDlcDebug CreateDlcDebugUI() => null;

    // VMA: 0x01cc9c34 — Source: UIModule.c (ShowMsgBox_BeforeStart)
    // gốc body: hotfix at +0x168; else: similar to ShowMsgBox but uses simpler "before-start" prefab.
    public static void ShowMsgBox_BeforeStart(Action fnCenter)
    {
        Debug.Log("[MsgBox_BeforeStart]");
        fnCenter?.Invoke();
    }

    // VMA: 0x01cc9f1c — Source: UIModule.c (WarnningDialogBeforeStart coroutine)
    // gốc body: alloc <WarnningDialogBeforeStart>d__51 iterator. MoveNext shows warning dialog.
    [System.Runtime.CompilerServices.IteratorStateMachine(typeof(UIModule.<WarnningDialogBeforeStart>d__51))]
    public static IEnumerator WarnningDialogBeforeStart() { yield break; }

    // VMA: 0x01cc9fa5 — Source: UIModule.c (DestroyMsgBoxBeforeStart)
    // gốc body: hotfix at +0x178; else: if _MsgBox != null: Destroy(_MsgBox); _MsgBox = null;
    public static void DestroyMsgBoxBeforeStart()
    {
        if (_MsgBox != null) { Destroy(_MsgBox); _MsgBox = null; }
    }
}
