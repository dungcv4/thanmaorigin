// AUTO-GENERATED skeleton from gốc IL2CPP dump.
// Class:   UIPanel
// GUID:    b32429381233c34f85462443e39a6168
// Source:  /Users/vsf-user-l/Documents/Test/alo/KTO_Resources/il2cpp_full_dump/dump.cs (dump.cs class block)
// Ghidra:  /Users/vsf-user-l/Documents/Test/alo/KTO_DecompiledReference/Game.Ui/UIPanel.c
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
using System.Collections.Generic;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{

	// Fields
	private Dictionary<string, Transform> m_ObjectList; // 0x20
	private Dictionary<string, Button> m_ButtonList; // 0x28
	private Dictionary<string, Text> m_TextList; // 0x30
	private Dictionary<string, Image> m_ImageList; // 0x38
	private Dictionary<string, UIAnimation> m_UIAnimationList; // 0x40
	private Dictionary<string, InputField> m_InputList; // 0x48
	private Dictionary<string, PrefabAnchor> m_PrefabAnchorList; // 0x50
	private Dictionary<string, bool> m_LocalizeList; // 0x58
	[CompilerGenerated]
	private string <UIPath>k__BackingField; // 0x60	private static __XLua_Gen_Delegate3 _c__Hotfix0_ctor; // 0x468

	// Properties
	public string UIPath { get; set; }

	// Methods

	[CompilerGenerated]
	// RVA: 0x1B2B494 Offset: 0x1B27494 VA: 0x1B2B494
	public string get_UIPath() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	[CompilerGenerated]
	// RVA: 0x1B2B4E5 Offset: 0x1B274E5 VA: 0x1B2B4E5
	public void set_UIPath(string value) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2B54D Offset: 0x1B2754D VA: 0x1B2B54D
	public int GetSortingOrder(Transform trans) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2B6AE Offset: 0x1B276AE VA: 0x1B2B6AE
	public int GetMaxSortingOrderInChildren(Transform trans) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2B898 Offset: 0x1B27898 VA: 0x1B2B898
	public void SetSortingOrder(string szKey, int offset = 1) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2B9CA Offset: 0x1B279CA VA: 0x1B2B9CA
	private Transform FindChild(string szKey, bool bLog = True) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2BC55 Offset: 0x1B27C55 VA: 0x1B2BC55
	public void SetActive(string szKey, bool bVisiable) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2BD3E Offset: 0x1B27D3E VA: 0x1B2BD3E
	public bool IsActive(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2BE15 Offset: 0x1B27E15 VA: 0x1B2BE15
	public string Label_GetText(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2C3A7 Offset: 0x1B283A7 VA: 0x1B2C3A7
	public void Label_SetText(string szKey, string szText) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2C62C Offset: 0x1B2862C VA: 0x1B2C62C
	public void Label_SetChildText(string szKey, string szChildKey, string szText) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2C744 Offset: 0x1B28744 VA: 0x1B2C744
	public void Label_SetColorByName(string szKey, string szColor) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2C867 Offset: 0x1B28867 VA: 0x1B2C867
	public void Label_SetColorByID(string szKey, int nID) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2C974 Offset: 0x1B28974 VA: 0x1B2C974
	public void Label_SetColor(string szKey, float r, float g, float b) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2CA89 Offset: 0x1B28A89 VA: 0x1B2CA89
	public void UESFontOutline_SetEffectDistance(string szKey, float x, float y) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2CBFB Offset: 0x1B28BFB VA: 0x1B2CBFB
	public void UESFontOutline_SetColor(string szKey, int nID) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2CCFC Offset: 0x1B28CFC VA: 0x1B2CCFC
	public void UESOutline_SetGlowColor(string szKey, int nID) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2D2BB Offset: 0x1B292BB VA: 0x1B2D2BB
	public void UESOutline_SetOutlineColor(string szKey, int nID) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2D322 Offset: 0x1B29322 VA: 0x1B2D322
	public void Emoji_SetText(string szKey, string szChildKey, string szText) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2D4BB Offset: 0x1B294BB VA: 0x1B2D4BB
	public string Input_GetText(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2DA3C Offset: 0x1B29A3C VA: 0x1B2DA3C
	public void Input_SetText(string szKey, string szText) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2DB04 Offset: 0x1B29B04 VA: 0x1B2DB04
	public void Input_SetPlaceHolderText(string szKey, string szText) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2DC1B Offset: 0x1B29C1B VA: 0x1B2DC1B
	public void Input_SetEnable(string szKey, bool bEnable) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2DCE1 Offset: 0x1B29CE1 VA: 0x1B2DCE1
	public void ToggleGroup_SetAllowSwitchOff(string szKey, bool bAllow) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2DF9F Offset: 0x1B29F9F VA: 0x1B2DF9F
	public void Toggle_SetChecked(string szKey, bool bChecked) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2E26B Offset: 0x1B2A26B VA: 0x1B2E26B
	public bool Toggle_GetChecked(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2E32D Offset: 0x1B2A32D VA: 0x1B2E32D
	public void Toggle_SetEnable(string szKey, bool bEnable) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2E3F3 Offset: 0x1B2A3F3 VA: 0x1B2E3F3
	public void Sprite_SetEnable(string szKey, bool bEnable) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2E4B9 Offset: 0x1B2A4B9 VA: 0x1B2E4B9
	public void ClearCamera() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2E5F0 Offset: 0x1B2A5F0 VA: 0x1B2E5F0
	public void ResetCamera() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2E737 Offset: 0x1B2A737 VA: 0x1B2E737
	public void UIAnimation_Clear(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2EB30 Offset: 0x1B2AB30 VA: 0x1B2EB30
	public void Sprite_SetSprite(string szKey, string szPath, bool bOverride) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2ED95 Offset: 0x1B2AD95 VA: 0x1B2ED95
	private void _SetSprite(Image c, bool o, Sprite s) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2EE9A Offset: 0x1B2AE9A VA: 0x1B2EE9A
	public Animator GetAnimator(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2F2AA Offset: 0x1B2B2AA VA: 0x1B2F2AA
	public Animator FindAnimator(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2F52B Offset: 0x1B2B52B VA: 0x1B2F52B
	public void Animator_SetEnable(string szKey, bool bEnable) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2F5F1 Offset: 0x1B2B5F1 VA: 0x1B2F5F1
	public Animation GetAnimation(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2FA01 Offset: 0x1B2BA01 VA: 0x1B2FA01
	public void PlayAnimation(string szKey, string szAniName) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2FAE1 Offset: 0x1B2BAE1 VA: 0x1B2FAE1
	public void UIAnimation_SetSprites(string szKey, string szPathPrefix, int nPathPostfixLength, int nStartNum, int nEndNum, string szType, float fInterval = 0,05, bool bLoop = True) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2FF47 Offset: 0x1B2BF47 VA: 0x1B2FF47
	private void _AddAnimationSprite(Sprite s, UIAnimation ani) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30022 Offset: 0x1B2C022 VA: 0x1B30022
	public void Sprite_SetSpriteImage(string szKey, Sprite sprite, bool bOverride) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30112 Offset: 0x1B2C112 VA: 0x1B30112
	public void Sprite_SetFill(string szKey, float fValue) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B301EE Offset: 0x1B2C1EE VA: 0x1B301EE
	public void Sprite_SetFillAmount(string szKey, float startValue, float endValue, float duration, bool isDelay) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3038B Offset: 0x1B2C38B VA: 0x1B3038B
	public void Sprite_SetNativeSize(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3045B Offset: 0x1B2C45B VA: 0x1B3045B
	public void Sprite_SetSize(string szKey, float fWidth, float fHeight) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30558 Offset: 0x1B2C558 VA: 0x1B30558
	public void RawImage_SetImage(string szKey, Texture tex) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30826 Offset: 0x1B2C826 VA: 0x1B30826
	public void Object_SetSize(string szKey, float fWidth, float fHeight) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3099B Offset: 0x1B2C99B VA: 0x1B3099B
	public void Sprite_SetColor(string szKey, float nR, float nG, float nB, float nA) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30ACD Offset: 0x1B2CACD VA: 0x1B30ACD
	public void Sprite_SetColorByName(string szKey, string szColor) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30BF3 Offset: 0x1B2CBF3 VA: 0x1B30BF3
	public void Sprite_SetColorByID(string szKey, int nID) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30D03 Offset: 0x1B2CD03 VA: 0x1B30D03
	public void Sprite_SetAlphaAnimation(string szKey, float nStart, float nEnd, float nDuration) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30E1C Offset: 0x1B2CE1C VA: 0x1B30E1C
	public void Button_SetText(string szKey, string szText, string szTextPath) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3162D Offset: 0x1B2D62D VA: 0x1B3162D
	public void Button_SetEnable(string szKey, bool bEnable) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B316F3 Offset: 0x1B2D6F3 VA: 0x1B316F3
	public void Button_BindEvent(string szKey, LuaFunction funcCall, object[] vecParams) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3186A Offset: 0x1B2D86A VA: 0x1B3186A
	public void Button_BindLongPressUp(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B31970 Offset: 0x1B2D970 VA: 0x1B31970
	public void Button_BindLongPressEnd(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B31A76 Offset: 0x1B2DA76 VA: 0x1B31A76
	public void Button_BindLongPressLoop(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B31B7C Offset: 0x1B2DB7C VA: 0x1B31B7C
	public void SetLongPressEndTime(string szKey, float enterTime) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B31C2B Offset: 0x1B2DC2B VA: 0x1B31C2B
	public void SetLongPressLoopTime(string szKey, float startTime, float gapTime) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B31CF3 Offset: 0x1B2DCF3 VA: 0x1B31CF3
	public void SetDoubleClick(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B31DF9 Offset: 0x1B2DDF9 VA: 0x1B31DF9
	public void SetDragBegin(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B31EFF Offset: 0x1B2DEFF VA: 0x1B31EFF
	public void Swipe_BindEvent(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B32005 Offset: 0x1B2E005 VA: 0x1B32005
	public void SetDragEnd(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3210B Offset: 0x1B2E10B VA: 0x1B3210B
	public void DragInit(string szKey, string[] szContainerKeys, string szTargetKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B32289 Offset: 0x1B2E289 VA: 0x1B32289
	public void ButtonGroup_SetSelect(string szKey, bool bSelect) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B323A2 Offset: 0x1B2E3A2 VA: 0x1B323A2
	public void ButtonGroup_SetSprite(string szKey, int index, string szSelectedPath, string szNormalPath) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B327FE Offset: 0x1B2E7FE VA: 0x1B327FE
	public void BindAnimationEvent(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B32904 Offset: 0x1B2E904 VA: 0x1B32904
	public void Scroll_BindEvent(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3296E Offset: 0x1B2E96E VA: 0x1B3296E
	public void Slider_BindEvent(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B32B7B Offset: 0x1B2EB7B VA: 0x1B32B7B
	public void Toggle_BindEvent(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B32D75 Offset: 0x1B2ED75 VA: 0x1B32D75
	public void ToggleGroup_SetSelect(string szKey, bool bSelect) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B32E8E Offset: 0x1B2EE8E VA: 0x1B32E8E
	public void Input_BindEvent(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B33014 Offset: 0x1B2F014 VA: 0x1B33014
	public void Input_OnEndEdit(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3319A Offset: 0x1B2F19A VA: 0x1B3319A
	public void Button_ClearEvent(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B33267 Offset: 0x1B2F267 VA: 0x1B33267
	public void ScrollRect_SetVerticalNormalizedPosition(string szKey, float fValue) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3338B Offset: 0x1B2F38B VA: 0x1B3338B
	public float ScrollRect_GetVerticalNormalizedPosition(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B33410 Offset: 0x1B2F410 VA: 0x1B33410
	public void Object_SetLocalPosition(string szKey, Vector3 pos) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B334D8 Offset: 0x1B2F4D8 VA: 0x1B334D8
	public void Object_SetPosition(string szKey, Vector3 pos) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B335A0 Offset: 0x1B2F5A0 VA: 0x1B335A0
	public Vector3 Object_GetPosition(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3367E Offset: 0x1B2F67E VA: 0x1B3367E
	public Vector3 GetSelfPosition() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3373A Offset: 0x1B2F73A VA: 0x1B3373A
	public float Slider_GetValue(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3380D Offset: 0x1B2F80D VA: 0x1B3380D
	public void Slider_SetValue(string szKey, float fValue) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B338F5 Offset: 0x1B2F8F5 VA: 0x1B338F5
	public void Slider_SetRange(string szKey, float fMinValue, float fMaxValue) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B339F4 Offset: 0x1B2F9F4 VA: 0x1B339F4
	public void Slider_SetEnable(string szKey, bool bEnable) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B33ABA Offset: 0x1B2FABA VA: 0x1B33ABA
	public void Dropdown_BindEvent(string szKey, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B33CB5 Offset: 0x1B2FCB5 VA: 0x1B33CB5
	public void Dropdown_SetValue(string szKey, int nValue) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B33D79 Offset: 0x1B2FD79 VA: 0x1B33D79
	public int Dropdown_GetValue(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B33E37 Offset: 0x1B2FE37 VA: 0x1B33E37
	public void Dropdown_ResetOptions(string szKey, string[] szOptions) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B33F27 Offset: 0x1B2FF27 VA: 0x1B33F27
	public void AddObject(string szKey, GameObject obj) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B34120 Offset: 0x1B30120 VA: 0x1B34120
	private bool CheckContain(string str1, string str2) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B341EE Offset: 0x1B301EE VA: 0x1B341EE
	public void DeleteObject(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B34D39 Offset: 0x1B30D39 VA: 0x1B34D39
	public void DeleteObjectListPath(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B357CE Offset: 0x1B317CE VA: 0x1B357CE
	public bool IsObjectExist(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2FE80 Offset: 0x1B2BE80 VA: 0x1B2FE80
	public GameObject GetObject(string szKey, bool bLog = True) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B358FA Offset: 0x1B318FA VA: 0x1B358FA
	public string CloneObject(string szKey, string szName = "", string szNewObjectKey = "") { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B35D13 Offset: 0x1B31D13 VA: 0x1B35D13
	public string CloneObjectAsSamePosition(string szKey, string szName = "", string szNewObjectKey = "") { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B35A4A Offset: 0x1B31A4A VA: 0x1B35A4A
	private string PrivateObjectCommon(string szKey, string szName, Action<Transform> setPosition, string szNewObjectKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30914 Offset: 0x1B2C914 VA: 0x1B30914
	public RectTransform GetRectTransform(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B35E35 Offset: 0x1B31E35 VA: 0x1B35E35
	public Transform GetTransform(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3117E Offset: 0x1B2D17E VA: 0x1B3117E
	public Button GetButton(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2BEF8 Offset: 0x1B27EF8 VA: 0x1B2BEF8
	public Text GetText(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2D434 Offset: 0x1B29434 VA: 0x1B2D434
	public EmojiText GetEmojiText(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2CB74 Offset: 0x1B28B74 VA: 0x1B2CB74
	public FontOutline GetUESFontOutline(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2CE0C Offset: 0x1B28E0C VA: 0x1B2CE0C
	public Image GetImage(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2D58D Offset: 0x1B2958D VA: 0x1B2D58D
	public InputField GetInput(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2DD99 Offset: 0x1B29D99 VA: 0x1B2DD99
	public ToggleGroup GetToggleGroup(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2E065 Offset: 0x1B2A065 VA: 0x1B2E065
	public Toggle GetToggle(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30620 Offset: 0x1B2C620 VA: 0x1B30620
	public RawImage GetRawImage(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B32AF4 Offset: 0x1B2EAF4 VA: 0x1B32AF4
	public Slider GetSlider(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B35F00 Offset: 0x1B31F00 VA: 0x1B35F00
	public UISlider GetUISlider(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B33304 Offset: 0x1B2F304 VA: 0x1B33304
	public ScrollRect GetScrollRect(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B35F87 Offset: 0x1B31F87 VA: 0x1B35F87
	public GridLayoutGroup GetGridLayoutGroup(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3600E Offset: 0x1B3200E VA: 0x1B3600E
	public UILongPressEnd GetLongPressEnd(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B36095 Offset: 0x1B32095 VA: 0x1B36095
	public UILongPressLoop GetLongPressLoop(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B33C2E Offset: 0x1B2FC2E VA: 0x1B33C2E
	public Dropdown GetDropdown(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3611C Offset: 0x1B3211C VA: 0x1B3611C
	public UIDoubleClick GetDoubleClick(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B361A3 Offset: 0x1B321A3 VA: 0x1B361A3
	public UIDrag GetDrag(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3622A Offset: 0x1B3222A VA: 0x1B3622A
	public UISwipe GetSwipe(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B362B1 Offset: 0x1B322B1 VA: 0x1B362B1
	public AnimationEventDispatcher GetAnimationEventDispatcher(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2E807 Offset: 0x1B2A807 VA: 0x1B2E807
	public UIAnimation GetUIAnimation(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: -1 Offset: -1
	private T TryGetComponent<T>(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }
	/* GenericInstMethod :
	|
	|-RVA: 0x1E638C1 Offset: 0x1E5F8C1 VA: 0x1E638C1
	|-UIPanel.TryGetComponent<object>
	|
	|-RVA: 0x1E63B12 Offset: 0x1E5FB12 VA: 0x1E63B12
	|-UIPanel.TryGetComponent<__Il2CppFullySharedGenericType>
	*/

	// RVA: 0x1B36338 Offset: 0x1B32338 VA: 0x1B36338
	public void SetScale(string szKey, float fScale) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B36452 Offset: 0x1B32452 VA: 0x1B36452
	public void ContentSizeFitter_Refresh(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3659D Offset: 0x1B3259D VA: 0x1B3659D
	public int GetPanelSortingOrder() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B366A2 Offset: 0x1B326A2 VA: 0x1B366A2
	public void SetPanelSortingOrder(int nOrder) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B367A3 Offset: 0x1B327A3 VA: 0x1B367A3
	public void SetDealEmojiInputLimit(string szKey, int nLimitNum) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B369E1 Offset: 0x1B329E1 VA: 0x1B369E1
	public PrefabAnchor GetPrefabAnchor(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B36E90 Offset: 0x1B32E90 VA: 0x1B36E90
	public void CreatePrefabByAnchor(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B36F15 Offset: 0x1B32F15 VA: 0x1B36F15
	public void ShowUrl(string key, string url, int pageIndex, int type) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B37072 Offset: 0x1B33072 VA: 0x1B37072
	public void SetAsLastSibling(string key) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2C483 Offset: 0x1B28483 VA: 0x1B2C483
	private void AdjustLocalize(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B370F7 Offset: 0x1B330F7 VA: 0x1B370F7
	public string DynamicLoadGameObject(string szKey, string szPath, string szName) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3737C Offset: 0x1B3337C VA: 0x1B3737C
	public void DynamicLoadGameObjectAsync(string szKey, string szPath, string szName, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B374CA Offset: 0x1B334CA VA: 0x1B374CA
	public void AddObjectInDict(string szKey, GameObject obj) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B375A5 Offset: 0x1B335A5 VA: 0x1B375A5
	public void RemoveObjectInDict(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3766A Offset: 0x1B3366A VA: 0x1B3766A
	public void SuperScrollView_InitGridView(string szKey, int nItemTotalCount, LuaTable self, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B37849 Offset: 0x1B33849 VA: 0x1B37849
	public void SuperScrollView_InitListView(string szKey, int nItemTotalCount, LuaTable self, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B37A25 Offset: 0x1B33A25 VA: 0x1B37A25
	public void SuperScrollView_InitStaggeredGridView(string szKey, int nItemTotalCount, LuaTable self, LuaFunction funcCall, object layoutParam) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B37C62 Offset: 0x1B33C62 VA: 0x1B37C62
	public void SuperScrollView_BindSnapChangeEvent(string szKey, LuaTable self, LuaFunction funcCall) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B37E1B Offset: 0x1B33E1B VA: 0x1B37E1B
	public void SuperScrollView_ClearSnapChangeEvent(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B37F47 Offset: 0x1B33F47 VA: 0x1B37F47
	public void ShowObjectList() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B3818C Offset: 0x1B3418C VA: 0x1B3818C
	public void ChangeIosSafeArea(int nLayout, float v1, float v2) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

}
