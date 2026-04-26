// Class:  Game.UI.UIView
// GUID:   6a98f571046d3cc308aa727550752507 (preserved via .meta)
// Source: KTO_DecompiledReference/Game.Ui/UIView.c (22 methods, 1176 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs
//
// 1-1 port từ gốc Ghidra IL2CPP decompile. Mỗi method có VMA cite.
// CLAUDE.md: 100% từ gốc, KHÔNG chế cháo.
//
// UIView = base component on every UI window prefab.
// Drives lifecycle:  Awake → Init Lua class binding → callbacks Update/Show/Hide/OnDestroy.
// Lua callbacks looked up from `Ui.tbClass[m_luaClassName]` table (set by Lua scripts).

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class UIView : MonoBehaviour
{
    // Fields (offsets từ dump.cs)
    public string m_luaClassName;                       // 0x20
    private LuaEnv m_luaState;                          // 0x28
    private LuaTable m_luaObj;                          // 0x30
    private LuaFunction m_funcOnAwake;                  // 0x38
    private LuaFunction m_funcOnStart;                  // 0x40
    private LuaFunction m_funcOnUpdate;                 // 0x48
    private LuaFunction m_funcOnLateUpdate;             // 0x50
    private LuaFunction m_funcOnFixedUpdate;            // 0x58
    private LuaFunction m_funcOnDestroy;                // 0x60
    private LuaFunction m_funcOnWillRenderCanvas;       // 0x68
    private LuaFunction m_funcOnEnable;                 // 0x70
    private LuaFunction m_funcOnDisable;                // 0x78
    private LuaFunction m_funcOnPause;                  // 0x80
    private LuaFunction m_funcDoDestroy;                // 0x88
    private UIViewAnimationScale m_ScaleAnim;           // 0x90
    private UIViewAnimationController m_animCtrl;       // 0x98
    private bool m_Opening;                             // 0xA0
    private bool m_Closing;                             // 0xA1

    // Property — VMA: 0x01c39836 / 0x01c3983e
    public LuaFunction FuncDoDestroy
    {
        get => m_funcDoDestroy;
        set => m_funcDoDestroy = value;
    }

    // ========= Lifecycle =========

    // VMA: 0x01c39846 — Source: UIView.c:7024
    // gốc: GetComponent<UIViewAnimationScale> + UIViewAnimationController, Init(luaClassName), call OnAwake.
    private void Awake()
    {
        m_ScaleAnim = GetComponent<UIViewAnimationScale>();
        m_animCtrl  = GetComponent<UIViewAnimationController>();
        if (string.IsNullOrEmpty(m_luaClassName)) return;
        m_luaState = CppModule.GetLuaEnv();
        if (Init(m_luaClassName))
        {
            // gốc: if Init succeeded + m_funcOnAwake exists, invoke it with self.
            InvokeLua(m_funcOnAwake);
        }
    }

    // VMA: 0x01c39e98 — Source: UIView.c:7278
    private void Start() => InvokeLua(m_funcOnStart);

    // VMA: 0x01c39f39 — Source: UIView.c:7325
    private void Update() => InvokeLua(m_funcOnUpdate);

    // VMA: 0x01c39fda — Source: UIView.c:7372
    private void LateUpdate() => InvokeLua(m_funcOnLateUpdate);

    // VMA: 0x01c3a07b — Source: UIView.c:7419
    private void FixedUpdate() => InvokeLua(m_funcOnFixedUpdate);

    // VMA: 0x01c3a11c — Source: UIView.c:7466
    // gốc: invoke OnDestroy callback + cleanup all Image sprites in children.
    private void OnDestroy()
    {
        InvokeLua(m_funcOnDestroy);
        // Cleanup: clear sprite refs to release atlas hold.
        var images = GetComponentsInChildren<Image>(true);
        if (images != null)
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i] != null) images[i].sprite = null;
            }
        }
    }

    // VMA: 0x01c3a216 — Source: UIView.c:7528
    // gốc: if m_funcOnWillRenderCanvas exists → register Canvas.willRenderCanvases callback.
    //      Then invoke m_funcOnEnable.
    private void OnEnable()
    {
        if (m_funcOnWillRenderCanvas != null)
        {
            Canvas.willRenderCanvases += OnWillRenderCanvas;
        }
        InvokeLua(m_funcOnEnable);
    }

    // VMA: 0x01c3a309 — Source: UIView.c:7582
    // gốc: unregister Canvas.willRenderCanvases + invoke m_funcOnDisable.
    private void OnDisable()
    {
        if (m_funcOnWillRenderCanvas != null)
        {
            Canvas.willRenderCanvases -= OnWillRenderCanvas;
        }
        InvokeLua(m_funcOnDisable);
    }

    // VMA: 0x01c3a3fc — Source: UIView.c:7636
    // gốc: invoke m_funcOnPause(self, pause).
    private void OnApplicationPause(bool pause)
    {
        if (m_funcOnPause != null && m_luaObj != null)
        {
            m_funcOnPause.Call(m_luaObj, pause);
        }
    }

    // VMA: 0x01c3a4fb — Source: UIView.c:7703
    private void OnWillRenderCanvas() => InvokeLua(m_funcOnWillRenderCanvas);

    // ========= Init & Lookup =========

    // VMA: 0x01c39a7a — Source: UIView.c:7117
    // gốc: lookup Ui.tbClass[luaClassName] → m_luaObj, then bind 11 callback functions.
    private bool Init(string luaClassName)
    {
        // gốc: CppModule.GetGlobalTable() → luaTable, then luaTable.Get<LuaTable>("Ui").Get<LuaTable>("tbClass").Get<LuaTable>(luaClassName)
        // gốc: GetGlobalTable() returns root globals; chain Ui.tbClass[luaClassName]
        var uiTable = CppModule.GetGlobalTable("Ui");
        if (uiTable == null) return false;

        var tbClass = uiTable.Get<LuaTable>("tbClass");
        if (tbClass == null) return false;

        m_luaObj = tbClass.Get<LuaTable>(luaClassName);
        if (m_luaObj == null) return false;

        // Bind callbacks (offsets 0x38..0x88) — gốc reads each via XLua_LuaTable__Get<LuaFunction>.
        m_funcOnAwake             = m_luaObj.Get<LuaFunction>("OnAwake");
        m_funcOnStart             = m_luaObj.Get<LuaFunction>("OnStart");
        m_funcOnUpdate            = m_luaObj.Get<LuaFunction>("OnUpdate");
        m_funcOnLateUpdate        = m_luaObj.Get<LuaFunction>("OnLateUpdate");
        m_funcOnFixedUpdate       = m_luaObj.Get<LuaFunction>("OnFixedUpdate");
        m_funcOnDestroy           = m_luaObj.Get<LuaFunction>("OnDestroy");
        m_funcOnWillRenderCanvas  = m_luaObj.Get<LuaFunction>("OnWillRenderCanvas");
        m_funcOnEnable            = m_luaObj.Get<LuaFunction>("OnEnable");
        m_funcOnDisable           = m_luaObj.Get<LuaFunction>("OnDisable");
        m_funcOnPause             = m_luaObj.Get<LuaFunction>("OnPause");
        m_funcDoDestroy           = m_luaObj.Get<LuaFunction>("DoDestroy");
        return true;
    }

    // VMA: 0x01c3a4f6 — Source: UIView.c:7690
    public LuaTable GetScriptObject() => m_luaObj;

    // ========= Show/Hide =========

    // VMA: 0x01c3a59c — Source: UIView.c:7750
    // gốc: 3 branches based on which animation component exists:
    //   (a) m_animCtrl exists → SetActive(true), animCtrl.PlayShow(callback to invoke funcCall(vecParams))
    //   (b) m_ScaleAnim exists → if was Closing: ScaleAnim.FinishHideNow first; if not Opening: m_Opening=1, ScaleAnim.PlayShow
    //   (c) Neither → SetActive(true) + invoke funcCall(vecParams)
    public void Show(LuaFunction funcCall, object[] vecParams)
    {
        Action onComplete = () =>
        {
            if (gameObject != null) gameObject.SetActive(true);
            if (funcCall != null && vecParams != null) funcCall.Call(vecParams);
            else if (funcCall != null) funcCall.Call();
        };

        if (m_animCtrl != null)
        {
            // path (a): Animator-driven show
            if (gameObject != null) gameObject.SetActive(true);
            m_animCtrl.PlayShow(onComplete);
            return;
        }
        if (m_ScaleAnim != null)
        {
            // path (b): ScaleAnim-driven show with re-entry guard
            if (m_Closing)
            {
                m_ScaleAnim.FinishHideNow();
            }
            if (m_Opening) return;
            m_Opening = true;
            m_ScaleAnim.PlayShow(onComplete);
            return;
        }
        // path (c): no animation, plain activate + callback
        if (gameObject != null) gameObject.SetActive(true);
        if (funcCall != null && vecParams != null) funcCall.Call(vecParams);
        else if (funcCall != null) funcCall.Call();
    }

    // VMA: 0x01c3a7eb — Source: UIView.c:7856
    // gốc: SetActive(false) + UIModule.Instance.OnCloseUI(m_luaClassName)
    public void HideAtOnce()
    {
        if (gameObject != null) gameObject.SetActive(false);
        UIModule._Instance?.OnCloseUI(m_luaClassName);
    }

    // VMA: 0x01c3a86a — Source: UIView.c:7887
    // gốc: 3 branches like Show but for Hide:
    //   (a) m_animCtrl: animCtrl.PlayHide(SetActive(false) callback)
    //   (b) m_ScaleAnim: m_Closing=1, ScaleAnim.PlayHide(SetActive(false) + m_Closing=0)
    //   (c) Neither: SetActive(false)
    // After all paths: UIModule.Instance.OnCloseUI(m_luaClassName).
    public void Hide()
    {
        if (m_animCtrl != null)
        {
            // <Hide>b__35_0: callback chỉ SetActive(false). VMA: 0x01c3ab3a / UIView.c:8050
            Action onCompleteAnimCtrl = () =>
            {
                if (gameObject != null) gameObject.SetActive(false);
            };
            m_animCtrl.PlayHide(onCompleteAnimCtrl);
        }
        else if (m_ScaleAnim != null)
        {
            m_Closing = true;
            // <Hide>b__35_1: SetActive(false) + clear m_Closing. VMA: 0x01c3ab59 / UIView.c:8071
            Action onCompleteScale = () =>
            {
                if (gameObject != null) gameObject.SetActive(false);
                m_Closing = false;
            };
            m_ScaleAnim.PlayHide(onCompleteScale);
        }
        else
        {
            if (gameObject != null) gameObject.SetActive(false);
        }
        UIModule._Instance?.OnCloseUI(m_luaClassName);
    }

    // ========= Misc =========

    // VMA: 0x01c3aa06 — Source: UIView.c:7953
    // gốc: invoke m_funcDoDestroy(self, uiName).
    public void CallLuaDestroyUI(string uiName)
    {
        if (m_funcDoDestroy != null && m_luaObj != null)
        {
            m_funcDoDestroy.Call(m_luaObj, uiName);
        }
    }

    // VMA: 0x01c3aad8 — Source: UIView.c:8012
    // gốc: forward gameObject + nGroup to UIModule.SetGroup.
    public void SetGroup(int nGroup)
    {
        UIModule.SetGroup(gameObject, nGroup);
    }

    // ========= Helper =========

    // gốc IL2CPP pattern: every callback invoked as `func.Call(m_luaObj)` (self as 1st arg).
    // Inline method để giảm boilerplate.
    private void InvokeLua(LuaFunction func)
    {
        if (func != null && m_luaObj != null) func.Call(m_luaObj);
    }
}
