// Class:  UIPanel
// GUID:   b32429381233c34f85462443e39a6168 (preserved via .meta)
// Source: KTO_DecompiledReference/Game.Ui/UIPanel.c (9883 LOC Ghidra)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (signatures + VMA)
//
// ⚠ HONEST AUDIT (2026-04-26):
// PARTIAL 1-1 PORT — method SIGNATURES + VMA cites are correct (from dump.cs RVA addresses).
// Method BODIES are DERIVED FROM SIGNATURES + COMMON PATTERNS (Unity AudioSource/Resources/etc),
// NOT byte-by-byte verified against gốc Ghidra C decompile.
//
// What's accurate: class structure, field offsets, method signatures, VMA addresses, DEVIATIONs cited.
// What's NOT verified: exact body logic per method. Some methods may diverge from gốc behavior.
//
// VERIFY-NEEDED methods get 1-1 re-port when:
//   (a) runtime test fails
//   (b) integration with gốc Lua flow exposes mismatch
//   (c) per-method audit pass per Phase audit cycle

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using XLua;

public class UIPanel : MonoBehaviour
{
	// Fields (offsets từ dump.cs)
	private Dictionary<string, Transform> m_ObjectList = new Dictionary<string, Transform>();      // 0x20
	private Dictionary<string, Button> m_ButtonList = new Dictionary<string, Button>();            // 0x28
	private Dictionary<string, Text> m_TextList = new Dictionary<string, Text>();                  // 0x30
	private Dictionary<string, Image> m_ImageList = new Dictionary<string, Image>();               // 0x38
	private Dictionary<string, UIAnimation> m_UIAnimationList = new Dictionary<string, UIAnimation>(); // 0x40
	private Dictionary<string, InputField> m_InputList = new Dictionary<string, InputField>();     // 0x48
	private Dictionary<string, PrefabAnchor> m_PrefabAnchorList = new Dictionary<string, PrefabAnchor>(); // 0x50
	private Dictionary<string, bool> m_LocalizeList = new Dictionary<string, bool>();              // 0x58
	[CompilerGenerated]
	private string <UIPath>k__BackingField;                                                        // 0x60

	// thanmaorigin helpers (NOT in gốc — bridge for object map + uiPath internal)
	private string _uiPath;
	private Dictionary<string, GameObject> _objectMap = new Dictionary<string, GameObject>();

	public string UIPath
	{
		get => <UIPath>k__BackingField;
		set => <UIPath>k__BackingField = value;
	}

	// thanmaorigin helpers — gốc resolves child via Hash(szKey) lookup in m_ObjectList.
	// DEVIATION: use transform.Find recursive (Phase 4 build proper hash cache).
	private Transform FindChild(string szKey)
	{
		if (string.IsNullOrEmpty(szKey)) return null;
		if (m_ObjectList.TryGetValue(szKey, out var cached) && cached != null) return cached;
		var t = FindRecursive(transform, szKey);
		if (t != null) m_ObjectList[szKey] = t;
		return t;
	}

	private static Transform FindRecursive(Transform parent, string name)
	{
		for (int i = 0; i < parent.childCount; i++)
		{
			var c = parent.GetChild(i);
			if (c.name == name) return c;
			var deep = FindRecursive(c, name);
			if (deep != null) return deep;
		}
		return null;
	}

	private T FindComp<T>(string szKey) where T : Component
	{
		var t = FindChild(szKey);
		return t != null ? t.GetComponent<T>() : null;
	}

	// gốc UiDef.tbColors lookup — DEVIATION: simple palette stub.
	private static Color ColorById(int id)
	{
		switch (id)
		{
			case 0: return Color.white;
			case 1: return Color.red;
			case 2: return Color.green;
			case 3: return Color.blue;
			case 4: return Color.yellow;
			default: return Color.white;
		}
	}

	private System.Collections.IEnumerator LerpFill(Image img, float start, float end, float dur)
	{
		float t = 0f;
		while (t < dur)
		{
			t += Time.deltaTime;
			img.fillAmount = Mathf.Lerp(start, end, t / dur);
			yield return null;
		}
		img.fillAmount = end;
	}

	private System.Collections.IEnumerator LerpAlpha(Image img, float start, float end, float dur)
	{
		float t = 0f;
		var c = img.color;
		while (t < dur)
		{
			t += Time.deltaTime;
			c.a = Mathf.Lerp(start, end, t / dur);
			img.color = c;
			yield return null;
		}
		c.a = end;
		img.color = c;
	}

	// Methods

	[CompilerGenerated]
	// RVA: 0x1B2B494 Offset: 0x1B27494 VA: 0x1B2B494
	public string get_UIPath() => _uiPath;

	[CompilerGenerated]
	// RVA: 0x1B2B4E5 Offset: 0x1B274E5 VA: 0x1B2B4E5
	public void set_UIPath(string value)
    { _uiPath = value; }

	// RVA: 0x1B2B54D Offset: 0x1B2754D VA: 0x1B2B54D
	public int GetSortingOrder(Transform trans)
    {
        if (trans == null) return 0;
        var c = trans.GetComponent<Canvas>();
        return c != null ? c.sortingOrder : 0;
    }

	// RVA: 0x1B2B6AE Offset: 0x1B276AE VA: 0x1B2B6AE
	public int GetMaxSortingOrderInChildren(Transform trans)
    {
        if (trans == null) return 0;
        int max = 0;
        foreach (var c in trans.GetComponentsInChildren<Canvas>(true))
            if (c.sortingOrder > max) max = c.sortingOrder;
        return max;
    }

	// RVA: 0x1B2B898 Offset: 0x1B27898 VA: 0x1B2B898
	public void SetSortingOrder(string szKey, int offset = 1)
    {
        var t = FindChild(szKey);
        if (t == null) return;
        var c = t.GetComponent<Canvas>() ?? t.gameObject.AddComponent<Canvas>();
        c.overrideSorting = true;
        c.sortingOrder += offset;
    }

	// VMA: 0x01b2b9ca — Source: KTO_DecompiledReference/Game.Ui/UIPanel.c (FindChild with bLog flag)
	// gốc: walk transform.Find recursive; if not found AND bLog, log warning.
	private Transform FindChild(string szKey, bool bLog)
	{
		var t = FindChild(szKey);
		if (t == null && bLog) Debug.LogWarning($"[UIPanel:{name}] FindChild({szKey}) not found.");
		return t;
	}

	// RVA: 0x1B2BC55 Offset: 0x1B27C55 VA: 0x1B2BC55
	public void SetActive(string szKey, bool bVisiable)
    {
        var t = FindChild(szKey);
        if (t != null) t.gameObject.SetActive(bVisiable);
    }

	// RVA: 0x1B2BD3E Offset: 0x1B27D3E VA: 0x1B2BD3E
	public bool IsActive(string szKey)
    {
        var t = FindChild(szKey);
        return t != null && t.gameObject.activeSelf;
    }

	// RVA: 0x1B2BE15 Offset: 0x1B27E15 VA: 0x1B2BE15
	public string Label_GetText(string szKey)
    {
        var txt = FindComp<Text>(szKey);
        return txt != null ? txt.text : null;
    }

	// RVA: 0x1B2C3A7 Offset: 0x1B283A7 VA: 0x1B2C3A7
	public void Label_SetText(string szKey, string szText)
    {
        var txt = FindComp<Text>(szKey);
        if (txt != null) txt.text = szText ?? string.Empty;
    }

	// RVA: 0x1B2C62C Offset: 0x1B2862C VA: 0x1B2C62C
	public void Label_SetChildText(string szKey, string szChildKey, string szText)
    {
        var t = FindChild(szKey);
        if (t == null) return;
        var child = t.Find(szChildKey);
        if (child == null) return;
        var txt = child.GetComponent<Text>();
        if (txt != null) txt.text = szText ?? string.Empty;
    }

	// RVA: 0x1B2C744 Offset: 0x1B28744 VA: 0x1B2C744
	public void Label_SetColorByName(string szKey, string szColor)
    {
        var txt = FindComp<Text>(szKey);
        if (txt != null && ColorUtility.TryParseHtmlString(szColor, out var c)) txt.color = c;
    }

	// RVA: 0x1B2C867 Offset: 0x1B28867 VA: 0x1B2C867
	public void Label_SetColorByID(string szKey, int nID)
    {
        // gốc: lookup color in UiDef.tbColors by nID — simplified to Color.white for now.
        var txt = FindComp<Text>(szKey);
        if (txt != null) txt.color = ColorById(nID);
    }

	// RVA: 0x1B2C974 Offset: 0x1B28974 VA: 0x1B2C974
	public void Label_SetColor(string szKey, float r, float g, float b)
    {
        var txt = FindComp<Text>(szKey);
        if (txt != null) txt.color = new Color(r, g, b, txt.color.a);
    }

	// RVA: 0x1B2CA89 Offset: 0x1B28A89 VA: 0x1B2CA89
	public void UESFontOutline_SetEffectDistance(string szKey, float x, float y)
    {
        var o = FindComp<FontOutline>(szKey);
        if (o != null) o.effectDistance = new Vector2(x, y);
    }

	// RVA: 0x1B2CBFB Offset: 0x1B28BFB VA: 0x1B2CBFB
	public void UESFontOutline_SetColor(string szKey, int nID)
    {
        var o = FindComp<FontOutline>(szKey);
        if (o != null) o.effectColor = ColorById(nID);
    }

	// RVA: 0x1B2CCFC Offset: 0x1B28CFC VA: 0x1B2CCFC
	public void UESOutline_SetGlowColor(string szKey, int nID)
    { /* UESOutline custom shader prop — defer */ }

	// RVA: 0x1B2D2BB Offset: 0x1B292BB VA: 0x1B2D2BB
	public void UESOutline_SetOutlineColor(string szKey, int nID)
    { /* UESOutline custom shader prop — defer */ }

	// RVA: 0x1B2D322 Offset: 0x1B29322 VA: 0x1B2D322
	public void Emoji_SetText(string szKey, string szChildKey, string szText)
    {
        var t = FindChild(szKey);
        if (t == null) return;
        var child = t.Find(szChildKey);
        if (child == null) return;
        var em = child.GetComponent<EmojiText>();
        if (em != null) em.text = szText ?? string.Empty;
    }

	// RVA: 0x1B2D4BB Offset: 0x1B294BB VA: 0x1B2D4BB
	public string Input_GetText(string szKey)
    {
        var inp = FindComp<InputField>(szKey);
        return inp != null ? inp.text : null;
    }

	// RVA: 0x1B2DA3C Offset: 0x1B29A3C VA: 0x1B2DA3C
	public void Input_SetText(string szKey, string szText)
    {
        var inp = FindComp<InputField>(szKey);
        if (inp != null) inp.text = szText ?? string.Empty;
    }

	// RVA: 0x1B2DB04 Offset: 0x1B29B04 VA: 0x1B2DB04
	public void Input_SetPlaceHolderText(string szKey, string szText)
    {
        var inp = FindComp<InputField>(szKey);
        if (inp != null && inp.placeholder is Text t) t.text = szText ?? string.Empty;
    }

	// RVA: 0x1B2DC1B Offset: 0x1B29C1B VA: 0x1B2DC1B
	public void Input_SetEnable(string szKey, bool bEnable)
    {
        var inp = FindComp<InputField>(szKey);
        if (inp != null) inp.interactable = bEnable;
    }

	// RVA: 0x1B2DCE1 Offset: 0x1B29CE1 VA: 0x1B2DCE1
	public void ToggleGroup_SetAllowSwitchOff(string szKey, bool bAllow)
    {
        var tg = FindComp<ToggleGroup>(szKey);
        if (tg != null) tg.allowSwitchOff = bAllow;
    }

	// RVA: 0x1B2DF9F Offset: 0x1B29F9F VA: 0x1B2DF9F
	public void Toggle_SetChecked(string szKey, bool bChecked)
    {
        var tg = FindComp<Toggle>(szKey);
        if (tg != null) tg.isOn = bChecked;
    }

	// RVA: 0x1B2E26B Offset: 0x1B2A26B VA: 0x1B2E26B
	public bool Toggle_GetChecked(string szKey)
    {
        var tg = FindComp<Toggle>(szKey);
        return tg != null && tg.isOn;
    }

	// RVA: 0x1B2E32D Offset: 0x1B2A32D VA: 0x1B2E32D
	public void Toggle_SetEnable(string szKey, bool bEnable)
    {
        var tg = FindComp<Toggle>(szKey);
        if (tg != null) tg.interactable = bEnable;
    }

	// RVA: 0x1B2E3F3 Offset: 0x1B2A3F3 VA: 0x1B2E3F3
	public void Sprite_SetEnable(string szKey, bool bEnable)
    {
        var img = FindComp<Image>(szKey);
        if (img != null) img.enabled = bEnable;
    }

	// RVA: 0x1B2E4B9 Offset: 0x1B2A4B9 VA: 0x1B2E4B9
	public void ClearCamera()
    { /* defer */ }

	// RVA: 0x1B2E5F0 Offset: 0x1B2A5F0 VA: 0x1B2E5F0
	public void ResetCamera()
    { /* defer */ }

	// RVA: 0x1B2E737 Offset: 0x1B2A737 VA: 0x1B2E737
	public void UIAnimation_Clear(string szKey)
    {
        var a = FindComp<UIAnimation>(szKey);
        if (a != null) Destroy(a);
    }

	// RVA: 0x1B2EB30 Offset: 0x1B2AB30 VA: 0x1B2EB30
	public void Sprite_SetSprite(string szKey, string szPath, bool bOverride)
    {
        var img = FindComp<Image>(szKey);
        if (img == null) return;
        var s = ResourceModule.LoadResourceSync(szPath) as Sprite;
        if (s != null) img.sprite = s;
    }

	// RVA: 0x1B2ED95 Offset: 0x1B2AD95 VA: 0x1B2ED95
	private void _SetSprite(Image c, bool o, Sprite s) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B2EE9A Offset: 0x1B2AE9A VA: 0x1B2EE9A
	public Animator GetAnimator(string szKey) => FindComp<Animator>(szKey);

	// RVA: 0x1B2F2AA Offset: 0x1B2B2AA VA: 0x1B2F2AA
	public Animator FindAnimator(string szKey) => FindComp<Animator>(szKey);

	// RVA: 0x1B2F52B Offset: 0x1B2B52B VA: 0x1B2F52B
	public void Animator_SetEnable(string szKey, bool bEnable)
    {
        var an = FindComp<Animator>(szKey);
        if (an != null) an.enabled = bEnable;
    }

	// RVA: 0x1B2F5F1 Offset: 0x1B2B5F1 VA: 0x1B2F5F1
	public Animation GetAnimation(string szKey) => FindComp<Animation>(szKey);

	// RVA: 0x1B2FA01 Offset: 0x1B2BA01 VA: 0x1B2FA01
	public void PlayAnimation(string szKey, string szAniName)
    {
        var an = FindComp<Animation>(szKey);
        if (an != null && !string.IsNullOrEmpty(szAniName)) an.Play(szAniName);
    }

	// RVA: 0x1B2FAE1 Offset: 0x1B2BAE1 VA: 0x1B2FAE1
	public void UIAnimation_SetSprites(string szKey, string szPathPrefix, int nPathPostfixLength, int nStartNum, int nEndNum, string szType, float fInterval = 0,05, bool bLoop = true)
    { /* sprite frame anim — defer Phase 3.9 */ }

	// RVA: 0x1B2FF47 Offset: 0x1B2BF47 VA: 0x1B2FF47
	private void _AddAnimationSprite(Sprite s, UIAnimation ani) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30022 Offset: 0x1B2C022 VA: 0x1B30022
	public void Sprite_SetSpriteImage(string szKey, Sprite sprite, bool bOverride)
    {
        var img = FindComp<Image>(szKey);
        if (img != null) img.sprite = sprite;
    }

	// RVA: 0x1B30112 Offset: 0x1B2C112 VA: 0x1B30112
	public void Sprite_SetFill(string szKey, float fValue)
    {
        var img = FindComp<Image>(szKey);
        if (img != null) img.fillAmount = fValue;
    }

	// RVA: 0x1B301EE Offset: 0x1B2C1EE VA: 0x1B301EE
	public void Sprite_SetFillAmount(string szKey, float startValue, float endValue, float duration, bool isDelay)
    {
        var img = FindComp<Image>(szKey);
        if (img == null) return;
        if (duration <= 0f) { img.fillAmount = endValue; return; }
        StartCoroutine(LerpFill(img, startValue, endValue, duration));
    }

	// RVA: 0x1B3038B Offset: 0x1B2C38B VA: 0x1B3038B
	public void Sprite_SetNativeSize(string szKey)
    {
        var img = FindComp<Image>(szKey);
        if (img != null) img.SetNativeSize();
    }

	// RVA: 0x1B3045B Offset: 0x1B2C45B VA: 0x1B3045B
	public void Sprite_SetSize(string szKey, float fWidth, float fHeight)
    {
        var rt = FindComp<RectTransform>(szKey);
        if (rt != null) rt.sizeDelta = new Vector2(fWidth, fHeight);
    }

	// RVA: 0x1B30558 Offset: 0x1B2C558 VA: 0x1B30558
	public void RawImage_SetImage(string szKey, Texture tex) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30826 Offset: 0x1B2C826 VA: 0x1B30826
	public void Object_SetSize(string szKey, float fWidth, float fHeight)
    {
        var rt = FindComp<RectTransform>(szKey);
        if (rt != null) rt.sizeDelta = new Vector2(fWidth, fHeight);
    }

	// RVA: 0x1B3099B Offset: 0x1B2C99B VA: 0x1B3099B
	public void Sprite_SetColor(string szKey, float nR, float nG, float nB, float nA)
    {
        var img = FindComp<Image>(szKey);
        if (img != null) img.color = new Color(nR, nG, nB, nA);
    }

	// RVA: 0x1B30ACD Offset: 0x1B2CACD VA: 0x1B30ACD
	public void Sprite_SetColorByName(string szKey, string szColor)
    {
        var img = FindComp<Image>(szKey);
        if (img != null && ColorUtility.TryParseHtmlString(szColor, out var c)) img.color = c;
    }

	// RVA: 0x1B30BF3 Offset: 0x1B2CBF3 VA: 0x1B30BF3
	public void Sprite_SetColorByID(string szKey, int nID)
    {
        var img = FindComp<Image>(szKey);
        if (img != null) img.color = ColorById(nID);
    }

	// RVA: 0x1B30D03 Offset: 0x1B2CD03 VA: 0x1B30D03
	public void Sprite_SetAlphaAnimation(string szKey, float nStart, float nEnd, float nDuration)
    {
        var img = FindComp<Image>(szKey);
        if (img == null) return;
        StartCoroutine(LerpAlpha(img, nStart, nEnd, nDuration));
    }

	// RVA: 0x1B30E1C Offset: 0x1B2CE1C VA: 0x1B30E1C
	public void Button_SetText(string szKey, string szText, string szTextPath)
    {
        var t = FindChild(szKey);
        if (t == null) return;
        var label = string.IsNullOrEmpty(szTextPath) ? t.GetComponentInChildren<Text>() : t.Find(szTextPath)?.GetComponent<Text>();
        if (label != null) label.text = szText ?? string.Empty;
    }

	// RVA: 0x1B3162D Offset: 0x1B2D62D VA: 0x1B3162D
	public void Button_SetEnable(string szKey, bool bEnable)
    {
        var btn = FindComp<Button>(szKey);
        if (btn != null) btn.interactable = bEnable;
    }

	// RVA: 0x1B316F3 Offset: 0x1B2D6F3 VA: 0x1B316F3
	public void Button_BindEvent(string szKey, LuaFunction funcCall, object[] vecParams)
    {
        var btn = FindComp<Button>(szKey);
        if (btn == null || funcCall == null) return;
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() => {
            if (vecParams != null) funcCall.Call(vecParams);
            else funcCall.Call();
        });
    }

	// RVA: 0x1B3186A Offset: 0x1B2D86A VA: 0x1B3186A
	public void Button_BindLongPressUp(string szKey, LuaFunction funcCall)
    {
        // VMA: 0x01c318c0 — UILongPressEnd custom component (Phase 3 stub — defer full press chain)
        var btn = FindComp<Button>(szKey);
        if (btn == null || funcCall == null) return;
    }

	// RVA: 0x1B31970 Offset: 0x1B2D970 VA: 0x1B31970
	public void Button_BindLongPressEnd(string szKey, LuaFunction funcCall)
    {
        // VMA: 0x01c31970 — UILongPressEnd component
        var btn = FindComp<Button>(szKey);
        if (btn == null || funcCall == null) return;
    }

	// RVA: 0x1B31A76 Offset: 0x1B2DA76 VA: 0x1B31A76
	public void Button_BindLongPressLoop(string szKey, LuaFunction funcCall)
    {
        // VMA: 0x01c31a76 — UILongPressLoop component
        var btn = FindComp<Button>(szKey);
        if (btn == null || funcCall == null) return;
    }

	// RVA: 0x1B31B7C Offset: 0x1B2DB7C VA: 0x1B31B7C
	public void SetLongPressEndTime(string szKey, float enterTime)
    { /* defer */ }

	// RVA: 0x1B31C2B Offset: 0x1B2DC2B VA: 0x1B31C2B
	public void SetLongPressLoopTime(string szKey, float startTime, float gapTime)
    { /* defer */ }

	// RVA: 0x1B31CF3 Offset: 0x1B2DCF3 VA: 0x1B31CF3
	public void SetDoubleClick(string szKey, LuaFunction funcCall)
    { /* UIDoubleClick custom — defer */ }

	// RVA: 0x1B31DF9 Offset: 0x1B2DDF9 VA: 0x1B31DF9
	public void SetDragBegin(string szKey, LuaFunction funcCall)
    { /* UIDrag custom — defer */ }

	// RVA: 0x1B31EFF Offset: 0x1B2DEFF VA: 0x1B31EFF
	public void Swipe_BindEvent(string szKey, LuaFunction funcCall)
    { /* UISwipe custom — defer */ }

	// RVA: 0x1B32005 Offset: 0x1B2E005 VA: 0x1B32005
	public void SetDragEnd(string szKey, LuaFunction funcCall)
    { /* UIDrag custom — defer */ }

	// RVA: 0x1B3210B Offset: 0x1B2E10B VA: 0x1B3210B
	public void DragInit(string szKey, string[] szContainerKeys, string szTargetKey)
    { /* UIDrag config — defer */ }

	// RVA: 0x1B32289 Offset: 0x1B2E289 VA: 0x1B32289
	public void ButtonGroup_SetSelect(string szKey, bool bSelect)
    {
        var bg = FindComp<ButtonGroup>(szKey);
        if (bg != null) bg.SetSelect(bSelect);
    }

	// RVA: 0x1B323A2 Offset: 0x1B2E3A2 VA: 0x1B323A2
	public void ButtonGroup_SetSprite(string szKey, int index, string szSelectedPath, string szNormalPath)
    { /* ButtonGroup sprite swap — defer */ }

	// RVA: 0x1B327FE Offset: 0x1B2E7FE VA: 0x1B327FE
	public void BindAnimationEvent(string szKey, LuaFunction funcCall)
    {
        var d = FindComp<AnimationEventDispatcher>(szKey);
        if (d != null && funcCall != null) d.OnEvent = (e) => funcCall.Call(e);
    }

	// RVA: 0x1B32904 Offset: 0x1B2E904 VA: 0x1B32904
	public void Scroll_BindEvent(string szKey, LuaFunction funcCall)
    {
        var sr = FindComp<ScrollRect>(szKey);
        if (sr != null && funcCall != null) sr.onValueChanged.AddListener(v => funcCall.Call(v.x, v.y));
    }

	// RVA: 0x1B3296E Offset: 0x1B2E96E VA: 0x1B3296E
	public void Slider_BindEvent(string szKey, LuaFunction funcCall)
    {
        var sl = FindComp<Slider>(szKey);
        if (sl != null && funcCall != null) {
            sl.onValueChanged.AddListener(v => funcCall.Call(v));
        }
    }

	// RVA: 0x1B32B7B Offset: 0x1B2EB7B VA: 0x1B32B7B
	public void Toggle_BindEvent(string szKey, LuaFunction funcCall)
    {
        var tg = FindComp<Toggle>(szKey);
        if (tg != null && funcCall != null) {
            tg.onValueChanged.AddListener(v => funcCall.Call(v));
        }
    }

	// RVA: 0x1B32D75 Offset: 0x1B2ED75 VA: 0x1B32D75
	public void ToggleGroup_SetSelect(string szKey, bool bSelect)
    {
        // gốc: select first/none toggle in group based on bSelect.
        var tg = FindComp<ToggleGroup>(szKey);
        if (tg == null) return;
        if (!bSelect) tg.SetAllTogglesOff();
    }

	// RVA: 0x1B32E8E Offset: 0x1B2EE8E VA: 0x1B32E8E
	public void Input_BindEvent(string szKey, LuaFunction funcCall)
    {
        var inp = FindComp<InputField>(szKey);
        if (inp != null && funcCall != null) {
            inp.onValueChanged.AddListener(v => funcCall.Call(v));
        }
    }

	// RVA: 0x1B33014 Offset: 0x1B2F014 VA: 0x1B33014
	public void Input_OnEndEdit(string szKey, LuaFunction funcCall)
    {
        var inp = FindComp<InputField>(szKey);
        if (inp != null && funcCall != null) {
            inp.onEndEdit.AddListener(v => funcCall.Call(v));
        }
    }

	// RVA: 0x1B3319A Offset: 0x1B2F19A VA: 0x1B3319A
	public void Button_ClearEvent(string szKey)
    {
        var btn = FindComp<Button>(szKey);
        if (btn != null) btn.onClick.RemoveAllListeners();
    }

	// RVA: 0x1B33267 Offset: 0x1B2F267 VA: 0x1B33267
	public void ScrollRect_SetVerticalNormalizedPosition(string szKey, float fValue)
    {
        var sr = FindComp<ScrollRect>(szKey);
        if (sr != null) sr.verticalNormalizedPosition = fValue;
    }

	// RVA: 0x1B3338B Offset: 0x1B2F38B VA: 0x1B3338B
	public float ScrollRect_GetVerticalNormalizedPosition(string szKey)
    {
        var sr = FindComp<ScrollRect>(szKey);
        return sr != null ? sr.verticalNormalizedPosition : 0f;
    }

	// RVA: 0x1B33410 Offset: 0x1B2F410 VA: 0x1B33410
	public void Object_SetLocalPosition(string szKey, Vector3 pos)
    {
        var t = FindChild(szKey);
        if (t != null) t.localPosition = pos;
    }

	// RVA: 0x1B334D8 Offset: 0x1B2F4D8 VA: 0x1B334D8
	public void Object_SetPosition(string szKey, Vector3 pos)
    {
        var t = FindChild(szKey);
        if (t != null) t.position = pos;
    }

	// RVA: 0x1B335A0 Offset: 0x1B2F5A0 VA: 0x1B335A0
	public Vector3 Object_GetPosition(string szKey)
    {
        var t = FindChild(szKey);
        return t != null ? t.position : Vector3.zero;
    }

	// RVA: 0x1B3367E Offset: 0x1B2F67E VA: 0x1B3367E
	public Vector3 GetSelfPosition() => transform.position;

	// RVA: 0x1B3373A Offset: 0x1B2F73A VA: 0x1B3373A
	public float Slider_GetValue(string szKey)
    {
        var sl = FindComp<Slider>(szKey);
        return sl != null ? sl.value : 0f;
    }

	// RVA: 0x1B3380D Offset: 0x1B2F80D VA: 0x1B3380D
	public void Slider_SetValue(string szKey, float fValue)
    {
        var sl = FindComp<Slider>(szKey);
        if (sl != null) sl.value = fValue;
    }

	// RVA: 0x1B338F5 Offset: 0x1B2F8F5 VA: 0x1B338F5
	public void Slider_SetRange(string szKey, float fMinValue, float fMaxValue)
    {
        var sl = FindComp<Slider>(szKey);
        if (sl != null) { sl.minValue = fMinValue; sl.maxValue = fMaxValue; }
    }

	// RVA: 0x1B339F4 Offset: 0x1B2F9F4 VA: 0x1B339F4
	public void Slider_SetEnable(string szKey, bool bEnable)
    {
        var sl = FindComp<Slider>(szKey);
        if (sl != null) sl.interactable = bEnable;
    }

	// RVA: 0x1B33ABA Offset: 0x1B2FABA VA: 0x1B33ABA
	public void Dropdown_BindEvent(string szKey, LuaFunction funcCall)
    {
        var dd = FindComp<Dropdown>(szKey);
        if (dd != null && funcCall != null) dd.onValueChanged.AddListener(v => funcCall.Call(v));
    }

	// RVA: 0x1B33CB5 Offset: 0x1B2FCB5 VA: 0x1B33CB5
	public void Dropdown_SetValue(string szKey, int nValue)
    {
        var dd = FindComp<Dropdown>(szKey);
        if (dd != null) dd.value = nValue;
    }

	// RVA: 0x1B33D79 Offset: 0x1B2FD79 VA: 0x1B33D79
	public int Dropdown_GetValue(string szKey)
    {
        var dd = FindComp<Dropdown>(szKey);
        return dd != null ? dd.value : 0;
    }

	// RVA: 0x1B33E37 Offset: 0x1B2FE37 VA: 0x1B33E37
	public void Dropdown_ResetOptions(string szKey, string[] szOptions)
    {
        var dd = FindComp<Dropdown>(szKey);
        if (dd == null) return;
        dd.ClearOptions();
        if (szOptions != null) {
            foreach (var o in szOptions) dd.options.Add(new Dropdown.OptionData(o));
        }
        dd.RefreshShownValue();
    }

	// RVA: 0x1B33F27 Offset: 0x1B2FF27 VA: 0x1B33F27
	public void AddObject(string szKey, GameObject obj)
    {
        if (obj != null) _objectMap[szKey] = obj;
    }

	// RVA: 0x1B34120 Offset: 0x1B30120 VA: 0x1B34120
	private bool CheckContain(string str1, string str2) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B341EE Offset: 0x1B301EE VA: 0x1B341EE
	public void DeleteObject(string szKey)
    {
        if (_objectMap.TryGetValue(szKey, out var o) && o != null) Destroy(o);
        _objectMap.Remove(szKey);
    }

	// RVA: 0x1B34D39 Offset: 0x1B30D39 VA: 0x1B34D39
	public void DeleteObjectListPath(string szKey)
    {
        // Remove all entries with prefix szKey
        var keys = new List<string>();
        foreach (var k in _objectMap.Keys) if (k.StartsWith(szKey)) keys.Add(k);
        foreach (var k in keys) DeleteObject(k);
    }

	// RVA: 0x1B357CE Offset: 0x1B317CE VA: 0x1B357CE
	public bool IsObjectExist(string szKey)
    {
        return _objectMap.ContainsKey(szKey) || FindChild(szKey) != null;
    }

	// RVA: 0x1B2FE80 Offset: 0x1B2BE80 VA: 0x1B2FE80
	public GameObject GetObject(string szKey, bool bLog = true)
    {
        if (_objectMap.TryGetValue(szKey, out var o)) return o;
        var t = FindChild(szKey);
        return t != null ? t.gameObject : null;
    }

	// RVA: 0x1B358FA Offset: 0x1B318FA VA: 0x1B358FA
	public string CloneObject(string szKey, string szName = "", string szNewObjectKey = "")
    {
        var src = GetObject(szKey, false);
        if (src == null) return null;
        var clone = Instantiate(src, src.transform.parent);
        if (!string.IsNullOrEmpty(szName)) clone.name = szName;
        var newKey = string.IsNullOrEmpty(szNewObjectKey) ? clone.name : szNewObjectKey;
        _objectMap[newKey] = clone;
        return newKey;
    }

	// RVA: 0x1B35D13 Offset: 0x1B31D13 VA: 0x1B35D13
	public string CloneObjectAsSamePosition(string szKey, string szName = "", string szNewObjectKey = "")
    {
        var newKey = CloneObject(szKey, szName, szNewObjectKey);
        return newKey;
    }

	// RVA: 0x1B35A4A Offset: 0x1B31A4A VA: 0x1B35A4A
	private string PrivateObjectCommon(string szKey, string szName, Action<Transform> setPosition, string szNewObjectKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B30914 Offset: 0x1B2C914 VA: 0x1B30914
	public RectTransform GetRectTransform(string szKey) => FindComp<RectTransform>(szKey);

	// RVA: 0x1B35E35 Offset: 0x1B31E35 VA: 0x1B35E35
	public Transform GetTransform(string szKey) => FindChild(szKey);

	// RVA: 0x1B3117E Offset: 0x1B2D17E VA: 0x1B3117E
	public Button GetButton(string szKey) => FindComp<Button>(szKey);

	// RVA: 0x1B2BEF8 Offset: 0x1B27EF8 VA: 0x1B2BEF8
	public Text GetText(string szKey) => FindComp<Text>(szKey);

	// RVA: 0x1B2D434 Offset: 0x1B29434 VA: 0x1B2D434
	public EmojiText GetEmojiText(string szKey) => FindComp<EmojiText>(szKey);

	// RVA: 0x1B2CB74 Offset: 0x1B28B74 VA: 0x1B2CB74
	public FontOutline GetUESFontOutline(string szKey) => FindComp<FontOutline>(szKey);

	// RVA: 0x1B2CE0C Offset: 0x1B28E0C VA: 0x1B2CE0C
	public Image GetImage(string szKey) => FindComp<Image>(szKey);

	// RVA: 0x1B2D58D Offset: 0x1B2958D VA: 0x1B2D58D
	public InputField GetInput(string szKey) => FindComp<InputField>(szKey);

	// RVA: 0x1B2DD99 Offset: 0x1B29D99 VA: 0x1B2DD99
	public ToggleGroup GetToggleGroup(string szKey) => FindComp<ToggleGroup>(szKey);

	// RVA: 0x1B2E065 Offset: 0x1B2A065 VA: 0x1B2E065
	public Toggle GetToggle(string szKey) => FindComp<Toggle>(szKey);

	// RVA: 0x1B30620 Offset: 0x1B2C620 VA: 0x1B30620
	public RawImage GetRawImage(string szKey) => FindComp<RawImage>(szKey);

	// RVA: 0x1B32AF4 Offset: 0x1B2EAF4 VA: 0x1B32AF4
	public Slider GetSlider(string szKey) => FindComp<Slider>(szKey);

	// RVA: 0x1B35F00 Offset: 0x1B31F00 VA: 0x1B35F00
	public UISlider GetUISlider(string szKey) => FindComp<UISlider>(szKey);

	// RVA: 0x1B33304 Offset: 0x1B2F304 VA: 0x1B33304
	public ScrollRect GetScrollRect(string szKey) => FindComp<ScrollRect>(szKey);

	// RVA: 0x1B35F87 Offset: 0x1B31F87 VA: 0x1B35F87
	public GridLayoutGroup GetGridLayoutGroup(string szKey) => FindComp<GridLayoutGroup>(szKey);

	// RVA: 0x1B3600E Offset: 0x1B3200E VA: 0x1B3600E
	public UILongPressEnd GetLongPressEnd(string szKey) => FindComp<UILongPressEnd>(szKey);

	// RVA: 0x1B36095 Offset: 0x1B32095 VA: 0x1B36095
	public UILongPressLoop GetLongPressLoop(string szKey) => FindComp<UILongPressLoop>(szKey);

	// RVA: 0x1B33C2E Offset: 0x1B2FC2E VA: 0x1B33C2E
	public Dropdown GetDropdown(string szKey) => FindComp<Dropdown>(szKey);

	// RVA: 0x1B3611C Offset: 0x1B3211C VA: 0x1B3611C
	public UIDoubleClick GetDoubleClick(string szKey) => FindComp<UIDoubleClick>(szKey);

	// RVA: 0x1B361A3 Offset: 0x1B321A3 VA: 0x1B361A3
	public UIDrag GetDrag(string szKey) => FindComp<UIDrag>(szKey);

	// RVA: 0x1B3622A Offset: 0x1B3222A VA: 0x1B3622A
	public UISwipe GetSwipe(string szKey) => FindComp<UISwipe>(szKey);

	// RVA: 0x1B362B1 Offset: 0x1B322B1 VA: 0x1B362B1
	public AnimationEventDispatcher GetAnimationEventDispatcher(string szKey) => FindComp<AnimationEventDispatcher>(szKey);

	// RVA: 0x1B2E807 Offset: 0x1B2A807 VA: 0x1B2E807
	public UIAnimation GetUIAnimation(string szKey) => FindComp<UIAnimation>(szKey);

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
	public void SetScale(string szKey, float fScale)
    {
        var t = FindChild(szKey);
        if (t != null) t.localScale = Vector3.one * fScale;
    }

	// RVA: 0x1B36452 Offset: 0x1B32452 VA: 0x1B36452
	public void ContentSizeFitter_Refresh(string szKey)
    {
        var f = FindComp<ContentSizeFitter>(szKey);
        if (f != null) LayoutRebuilder.ForceRebuildLayoutImmediate(f.transform as RectTransform);
    }

	// RVA: 0x1B3659D Offset: 0x1B3259D VA: 0x1B3659D
	public int GetPanelSortingOrder()
    {
        var c = GetComponent<Canvas>();
        return c != null ? c.sortingOrder : 0;
    }

	// RVA: 0x1B366A2 Offset: 0x1B326A2 VA: 0x1B366A2
	public void SetPanelSortingOrder(int nOrder)
    {
        var c = GetComponent<Canvas>() ?? gameObject.AddComponent<Canvas>();
        c.overrideSorting = true;
        c.sortingOrder = nOrder;
    }

	// RVA: 0x1B367A3 Offset: 0x1B327A3 VA: 0x1B367A3
	public void SetDealEmojiInputLimit(string szKey, int nLimitNum)
    { /* emoji input limit — defer */ }

	// RVA: 0x1B369E1 Offset: 0x1B329E1 VA: 0x1B369E1
	public PrefabAnchor GetPrefabAnchor(string szKey) => FindComp<PrefabAnchor>(szKey);

	// RVA: 0x1B36E90 Offset: 0x1B32E90 VA: 0x1B36E90
	public void CreatePrefabByAnchor(string szKey)
    {
        var pa = FindComp<PrefabAnchor>(szKey);
        if (pa != null) pa.CreatePrefab();
    }

	// RVA: 0x1B36F15 Offset: 0x1B32F15 VA: 0x1B36F15
	public void ShowUrl(string key, string url, int pageIndex, int type)
    { /* WebView — defer */ }

	// RVA: 0x1B37072 Offset: 0x1B33072 VA: 0x1B37072
	public void SetAsLastSibling(string key)
    {
        var t = FindChild(key);
        if (t != null) t.SetAsLastSibling();
    }

	// RVA: 0x1B2C483 Offset: 0x1B28483 VA: 0x1B2C483
	private void AdjustLocalize(string szKey) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1B370F7 Offset: 0x1B330F7 VA: 0x1B370F7
	public string DynamicLoadGameObject(string szKey, string szPath, string szName)
    {
        var src = ResourceModule.LoadResourceSync(szPath) as GameObject;
        if (src == null) return null;
        var anchor = FindChild(szKey);
        var clone = Instantiate(src, anchor != null ? anchor : transform);
        if (!string.IsNullOrEmpty(szName)) clone.name = szName;
        var newKey = string.IsNullOrEmpty(szName) ? clone.name : szName;
        _objectMap[newKey] = clone;
        return newKey;
    }

	// RVA: 0x1B3737C Offset: 0x1B3337C VA: 0x1B3737C
	public void DynamicLoadGameObjectAsync(string szKey, string szPath, string szName, LuaFunction funcCall)
    {
        var newKey = DynamicLoadGameObject(szKey, szPath, szName);
        funcCall?.Call(newKey);
    }

	// RVA: 0x1B374CA Offset: 0x1B334CA VA: 0x1B374CA
	public void AddObjectInDict(string szKey, GameObject obj)
    {
        if (obj != null) _objectMap[szKey] = obj;
    }

	// RVA: 0x1B375A5 Offset: 0x1B335A5 VA: 0x1B375A5
	public void RemoveObjectInDict(string szKey)
    {
        _objectMap.Remove(szKey);
    }

	// RVA: 0x1B3766A Offset: 0x1B3366A VA: 0x1B3766A
	public void SuperScrollView_InitGridView(string szKey, int nItemTotalCount, LuaTable self, LuaFunction funcCall)
    { /* SuperScrollView — defer */ }

	// RVA: 0x1B37849 Offset: 0x1B33849 VA: 0x1B37849
	public void SuperScrollView_InitListView(string szKey, int nItemTotalCount, LuaTable self, LuaFunction funcCall)
    { /* SuperScrollView — defer */ }

	// RVA: 0x1B37A25 Offset: 0x1B33A25 VA: 0x1B37A25
	public void SuperScrollView_InitStaggeredGridView(string szKey, int nItemTotalCount, LuaTable self, LuaFunction funcCall, object layoutParam)
    { /* SuperScrollView — defer */ }

	// RVA: 0x1B37C62 Offset: 0x1B33C62 VA: 0x1B37C62
	public void SuperScrollView_BindSnapChangeEvent(string szKey, LuaTable self, LuaFunction funcCall)
    { /* SuperScrollView — defer */ }

	// RVA: 0x1B37E1B Offset: 0x1B33E1B VA: 0x1B37E1B
	public void SuperScrollView_ClearSnapChangeEvent(string szKey)
    { /* SuperScrollView — defer */ }

	// RVA: 0x1B37F47 Offset: 0x1B33F47 VA: 0x1B37F47
	public void ShowObjectList()
    {
        Debug.Log($"[UIPanel] ObjectList ({_objectMap.Count} entries):");
        foreach (var kv in _objectMap) Debug.Log($"  {kv.Key}");
    }

	// RVA: 0x1B3818C Offset: 0x1B3418C VA: 0x1B3818C
	public void ChangeIosSafeArea(int nLayout, float v1, float v2)
    { /* iOS safe area adjust — defer */ }

}
