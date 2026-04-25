// AUTO-GENERATED skeleton from gốc IL2CPP dump.
// Class:   UIView
// GUID:    6a98f571046d3cc308aa727550752507
// Source:  /Users/vsf-user-l/Documents/Test/alo/KTO_Resources/il2cpp_full_dump/dump.cs (dump.cs class block)
// Ghidra:  /Users/vsf-user-l/Documents/Test/alo/KTO_DecompiledReference/Game.Ui/UIView.c
// VMA cites embedded in method comments below.
//
// PORTING WORKFLOW:
//   1. Each method has VMA cite (RVA: 0x...).
//   2. Body currently throws NotImplementedException.
//   3. Look up VMA in Ghidra file → port body 1-1.
//   4. After port: remove `throw new ...` + add `// VMA: 0x...` cite at method start.
//
// RULES (CLAUDE.md):
//   - 100% từ gốc, KHÔNG chế cháo.
//   - Mọi method PHẢI có comment // Source: <file>:<line> hoặc // VMA: 0x...
//   - Nếu DEVIATION (Cpp2IL stub trống / server-side / Unity API gone): ASK USER trước.

using System;
using UnityEngine;
using XLua;

public class UIView : MonoBehaviour
{

	// Fields
	public string m_luaClassName; // 0x20
	private LuaEnv m_luaState; // 0x28
	private LuaTable m_luaObj; // 0x30
	private LuaFunction m_funcOnAwake; // 0x38
	private LuaFunction m_funcOnStart; // 0x40
	private LuaFunction m_funcOnUpdate; // 0x48
	private LuaFunction m_funcOnLateUpdate; // 0x50
	private LuaFunction m_funcOnFixedUpdate; // 0x58
	private LuaFunction m_funcOnDestroy; // 0x60
	private LuaFunction m_funcOnWillRenderCanvas; // 0x68
	private LuaFunction m_funcOnEnable; // 0x70
	private LuaFunction m_funcOnDisable; // 0x78
	private LuaFunction m_funcOnPause; // 0x80
	private LuaFunction m_funcDoDestroy; // 0x88
	private UIViewAnimationScale m_ScaleAnim; // 0x90
	private UIViewAnimationController m_animCtrl; // 0x98
	private bool m_Opening; // 0xA0
	private bool m_Closing; // 0xA1

	// Properties
	public LuaFunction FuncDoDestroy { get; set; }

	// Methods

	// RVA: 0x1B39836 Offset: 0x1B35836 VA: 0x1B39836
	public LuaFunction get_FuncDoDestroy() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3983E Offset: 0x1B3583E VA: 0x1B3983E
	public void set_FuncDoDestroy(LuaFunction value) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B39846 Offset: 0x1B35846 VA: 0x1B39846
	private void Awake() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B39E98 Offset: 0x1B35E98 VA: 0x1B39E98
	private void Start() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B39F39 Offset: 0x1B35F39 VA: 0x1B39F39
	private void Update() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B39FDA Offset: 0x1B35FDA VA: 0x1B39FDA
	private void LateUpdate() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3A07B Offset: 0x1B3607B VA: 0x1B3A07B
	private void FixedUpdate() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3A11C Offset: 0x1B3611C VA: 0x1B3A11C
	private void OnDestroy() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3A216 Offset: 0x1B36216 VA: 0x1B3A216
	private void OnEnable() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3A309 Offset: 0x1B36309 VA: 0x1B3A309
	private void OnDisable() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3A3FC Offset: 0x1B363FC VA: 0x1B3A3FC
	private void OnApplicationPause(bool pause) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B39A7A Offset: 0x1B35A7A VA: 0x1B39A7A
	private bool Init(string luaClassName) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3A4F6 Offset: 0x1B364F6 VA: 0x1B3A4F6
	public LuaTable GetScriptObject() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3A4FB Offset: 0x1B364FB VA: 0x1B3A4FB
	private void OnWillRenderCanvas() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3A59C Offset: 0x1B3659C VA: 0x1B3A59C
	public void Show(LuaFunction funcCall, object[] vecParams) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3A7EB Offset: 0x1B367EB VA: 0x1B3A7EB
	public void HideAtOnce() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3A86A Offset: 0x1B3686A VA: 0x1B3A86A
	public void Hide() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3AA06 Offset: 0x1B36A06 VA: 0x1B3AA06
	public void CallLuaDestroyUI(string uiName) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3AAD8 Offset: 0x1B36AD8 VA: 0x1B3AAD8
	public void SetGroup(int nGroup) { throw new System.NotImplementedException("TODO: port from Ghidra"); }
	[CompilerGenerated]
	// RVA: 0x1B3AB3A Offset: 0x1B36B3A VA: 0x1B3AB3A
	private void <Hide>b__35_0() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	[CompilerGenerated]
	// RVA: 0x1B3AB59 Offset: 0x1B36B59 VA: 0x1B3AB59
	private void <Hide>b__35_1() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

}
