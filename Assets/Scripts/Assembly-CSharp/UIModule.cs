// AUTO-GENERATED skeleton from gốc IL2CPP dump.
// Class:   UIModule
// GUID:    1320eebfe218493bcae8457b6ad9fb3f
// Source:  /Users/vsf-user-l/Documents/Test/alo/KTO_Resources/il2cpp_full_dump/dump.cs (dump.cs class block)
// Ghidra:  /Users/vsf-user-l/Documents/Test/alo/KTO_DecompiledReference/_root/UIModule.c
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
using System.Collections;
using UnityEngine.UI;

public class UIModule : MonoBehaviour
{

	// Fields
	public const string UI_VIEW_PATH = "UI/views/";
	public static UIModule _Instance; // 0x0
	private static Camera _Camera; // 0x8
	public static UIStartUp _StartUI; // 0x10
	public static GameObject _MsgBox; // 0x18
	private static Dictionary<string, UIView> _UIViewMap; // 0x20
	private static Stack<string> _UIViewStack; // 0x28
	private static EventReference _EventReference; // 0x30
	private static Transform _UIGroup1; // 0x38
	private static Transform _UIGroup2; // 0x40
	private static int m_PopUoWindowBegin; // 0x48
	private static int m_EachWindowInterval; // 0x4C
	private Dictionary<string, Coroutine> _DestroyCoroutine; // 0x20
	private HashSet<string> DestroyCoroutineWhiteList; // 0x28
	public static bool _isShowBeforeBox; // 0x50	private static __XLua_Gen_Delegate3 _c__Hotfix0_ctor; // 0x180

	// Methods

	[IteratorStateMachine(typeof(UIModule.<Init>d__15))]
	// RVA: 0x1BC66AB Offset: 0x1BC26AB VA: 0x1BC66AB
	public static IEnumerator Init() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC6731 Offset: 0x1BC2731 VA: 0x1BC6731
	private void Awake() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC6827 Offset: 0x1BC2827 VA: 0x1BC6827
	public static void ShowStartUI() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC6ABB Offset: 0x1BC2ABB VA: 0x1BC6ABB
	public static void CloseStartUI() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC6BD0 Offset: 0x1BC2BD0 VA: 0x1BC6BD0
	public static void ShowMsgBox(string szMsg, string szCenterText, Action fnCenter) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC6F20 Offset: 0x1BC2F20 VA: 0x1BC6F20
	public static void ShowMsgBox2(string szMsg, string szOKText, string szCancerText, Action fnOK, Action fnCancer) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC7293 Offset: 0x1BC3293 VA: 0x1BC7293
	public static void CloseMsgBox() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC73C4 Offset: 0x1BC33C4 VA: 0x1BC73C4
	public static bool IsMsgBoxShow() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC74B8 Offset: 0x1BC34B8 VA: 0x1BC74B8
	public static void OnStartUILoadingProgress(int nProgress) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC7555 Offset: 0x1BC3555 VA: 0x1BC7555
	public static void OnStartUILoadingProgress(float fProgress) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC75FB Offset: 0x1BC35FB VA: 0x1BC75FB
	public static void OnStartUILoadingFinished() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC7683 Offset: 0x1BC3683 VA: 0x1BC7683
	public static void OnStartUIUpdateStateChange(UpdaterState state) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC7778 Offset: 0x1BC3778 VA: 0x1BC7778
	private static UIView GetUI(string uiName) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC787C Offset: 0x1BC387C VA: 0x1BC787C
	private Coroutine GetDestoryCoroutine(string uiName) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC794F Offset: 0x1BC394F VA: 0x1BC794F
	public static void PreloadUIAsync(string uiName, LuaFunction funcCall, object[] vecParams) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC7F50 Offset: 0x1BC3F50 VA: 0x1BC7F50
	public static void PreloadUI(string uiName, LuaFunction funcCall, object[] vecParams) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC7BDC Offset: 0x1BC3BDC VA: 0x1BC7BDC
	public static void SetUISortingOrder(GameObject go, string uiName, bool bFirstLoad) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC8CF1 Offset: 0x1BC4CF1 VA: 0x1BC8CF1
	public static string GetTopWindow() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC8DC7 Offset: 0x1BC4DC7 VA: 0x1BC8DC7
	public static void Close(string uiName) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC7ACE Offset: 0x1BC3ACE VA: 0x1BC7ACE
	private static void UnRegisteAutoDestroy(string uiName) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// VMA: 0x01cc8f28 — Source: KTO_DecompiledReference/_root/UIModule.c:7603
	// gốc: hotfix check → QualityModule.CheckUseAutoDestroyUI → schedule destroy coroutine.
	// MINIMAL PORT (Phase 3.4 partial): empty body — defer auto-destroy to Phase 3.6.
	public void OnCloseUI(string uiName) {
		// Auto-destroy deferred. UI persists in memory until scene unload.
	}

	[IteratorStateMachine(typeof(UIModule.<DestroyByTime>d__36))]
	// RVA: 0x1BC905F Offset: 0x1BC505F VA: 0x1BC905F
	private IEnumerator DestroyByTime(string uiName) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC9113 Offset: 0x1BC5113 VA: 0x1BC9113
	public static void DestroyUI(string uiName) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC92A0 Offset: 0x1BC52A0 VA: 0x1BC92A0
	public void Clear() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC7DCE Offset: 0x1BC3DCE VA: 0x1BC7DCE
	private static void LoadResourceAsync(string uiName, LuaFunction funcCall, object[] vecParams) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC80D3 Offset: 0x1BC40D3 VA: 0x1BC80D3
	private static bool LoadResource(string uiName, LuaFunction funcCall, object[] vecParams) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC970C Offset: 0x1BC570C VA: 0x1BC970C
	public static Vector2 ScreenPointToLocalPointInRectangle(RectTransform trans, Vector2 screenPoint) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// VMA: 0x01bbecc1 — Source: KTO_DecompiledReference/_root/UIModule.c (PlaySound section)
	// gốc: hotfix check → AudioModule.PlaySound(soundEvent, gameObject, ...).
	// MINIMAL PORT: empty no-op. Full audio routing deferred to Phase 3.6 full AudioModule + EventReference port.
	public static void PlaySound(int nSoundID) {
		// Audio playback deferred. UIView.Show calls UIViewAnimationScale.PlayShow → UIModule.PlaySound;
		// no-op để runtime path không crash khi Show gọi anim.
	}

	// VMA: 0x01bc982b — Source: KTO_DecompiledReference/_root/UIModule.c (StopSound section)
	// MINIMAL PORT: empty no-op. Same pattern as PlaySound.
	public static void StopSound(int nSoundID) {
		// no-op (deferred Phase 3.6).
	}

	// VMA: 0x01cc9902 — Source: KTO_DecompiledReference/_root/UIModule.c (SetGroup section)
	// gốc: forward gameObject + nGroup to UIModule sorting stack management.
	// MINIMAL PORT: parent obj under _UIGroup1 (nGroup=1) hoặc _UIGroup2 (nGroup=2).
	// Full sorting-stack port deferred to Phase 3.6.
	public static void SetGroup(GameObject obj, int nGroup) {
		if (obj == null) return;
		if (nGroup == 1 && _UIGroup1 != null) obj.transform.SetParent(_UIGroup1, false);
		else if (nGroup == 2 && _UIGroup2 != null) obj.transform.SetParent(_UIGroup2, false);
	}

	// RVA: 0x1BC9A0F Offset: 0x1BC5A0F VA: 0x1BC9A0F
	public static void SetGroupActive(int nGroup, bool bActive) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC8928 Offset: 0x1BC4928 VA: 0x1BC8928
	public static void ResetCanvasLayer(GameObject go, int nNewSortOrder) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC85A9 Offset: 0x1BC45A9 VA: 0x1BC85A9
	public static void PushGOFront(string uiName) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC9AEB Offset: 0x1BC5AEB VA: 0x1BC9AEB
	public static UIDlcDebug CreateDlcDebugUI() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC9C34 Offset: 0x1BC5C34 VA: 0x1BC9C34
	public static void ShowMsgBox_BeforeStart(Action fnCenter) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	[IteratorStateMachine(typeof(UIModule.<WarnningDialogBeforeStart>d__51))]
	// RVA: 0x1BC9F1C Offset: 0x1BC5F1C VA: 0x1BC9F1C
	public static IEnumerator WarnningDialogBeforeStart() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BC9FA5 Offset: 0x1BC5FA5 VA: 0x1BC9FA5
	public static void DestroyMsgBoxBeforeStart() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

}
