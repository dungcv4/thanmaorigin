// AUTO-GENERATED skeleton from gốc IL2CPP dump.
// Class:   BundleLoader
// GUID:    45c6742bf42c341819bd256400261265
// Source:  /Users/vsf-user-l/Documents/Test/alo/KTO_Resources/il2cpp_full_dump/dump.cs (dump.cs class block)
// Ghidra:  /Users/vsf-user-l/Documents/Test/alo/KTO_DecompiledReference/_root/BundleLoader.c
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
using System.Collections;

public class BundleLoader : BaseLoader
{

	// Fields
	[CompilerGenerated]
	private AssetBundle <Bundle>k__BackingField; // 0x38
	private Guid _RequestID; // 0x40
	private BundleLoader.BundleInfo[] _DependentAbList; // 0x50
	private IEnumerator _InitEnumerator; // 0x58
	private int _DependentAbCount; // 0x60
	private int _DependentAbLoadedCount; // 0x64
	private bool _LoadingFinished; // 0x68

	// Properties
	public AssetBundle Bundle { get; set; }

	// Methods

	// VMA: 0x0190cd53 — Source: KTO_DecompiledReference/_root/BundleLoader.c:9582
	// gốc: `return *(undefined8 *)(param_1 + 0x38);` — direct field read, no logic.
	[CompilerGenerated]
	public AssetBundle get_Bundle() => <Bundle>k__BackingField;

	// VMA: 0x0190cd58 — Source: BundleLoader.c:9595
	// gốc: `*(undefined8 *)(param_1 + 0x38) = param_2;` — direct field write.
	[CompilerGenerated]
	private void set_Bundle(AssetBundle value) { <Bundle>k__BackingField = value; }

	// RVA: 0x180CD5D Offset: 0x1808D5D VA: 0x180CD5D
	public static BundleLoader Load(string url, LoaderMode loaderMode) { throw new System.NotImplementedException("TODO: port from Ghidra"); }
	// RVA: 0x180CE92 Offset: 0x1808E92 VA: 0x180CE92 Slot: 6
	public override void Init(string url, LoaderMode loaderMode, object[] args) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x180D004 Offset: 0x1809004 VA: 0x180D004 Slot: 7
	public override void ReInit(LoaderMode loaderMode, object[] args) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x180D0FF Offset: 0x18090FF VA: 0x180D0FF Slot: 10
	public override void DoDispose() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// VMA: 0x0190d2d7 — Source: BundleLoader.c:9897
	// gốc: param_1[5] = param_2 (result); set m_bDone=1; call DoCallback(param_2); param_1[0xb] = 0 (clear coroutine ref)
	protected override void OnFinish(object resultObj)
	{
		_LoadingFinished = true;
		// gốc DoCallback in BaseLoader — fires registered callbacks with resultObj
		// (depends on BaseLoader.DoCallback port — see Phase 3.6 BaseLoader)
		base.DoCallback(resultObj);
	}

	[IteratorStateMachine(typeof(BundleLoader.<_LoadBundle_Priority>d__17))]
	// RVA: 0x180CFA5 Offset: 0x1808FA5 VA: 0x180CFA5
	private IEnumerable _LoadBundle_Priority() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x180D341 Offset: 0x1809341 VA: 0x180D341
	private void _OnDependentBundleLoadFinish(AssetBundle bundle, object[] param) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x180D5F3 Offset: 0x18095F3 VA: 0x180D5F3
	private void _OnBundleLoadFinish(AssetBundle bundle, object[] param) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

}
