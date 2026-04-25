// AUTO-GENERATED skeleton from gốc IL2CPP dump.
// Class:   UIViewAnimationScale
// GUID:    9f6d8f2be8a7daf7b2d9b65d883fd90c
// Source:  /Users/vsf-user-l/Documents/Test/alo/KTO_Resources/il2cpp_full_dump/dump.cs (dump.cs class block)
// Ghidra:  /Users/vsf-user-l/Documents/Test/alo/KTO_DecompiledReference/_root/UIViewAnimationScale.c
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
using System.Collections.Generic;

public class UIViewAnimationScale : MonoBehaviour
{

	// Fields
	private RectTransform m_rectTrans; // 0x20
	public float _OpenTime; // 0x28
	public float _CloseTime; // 0x2C
	public float _InitScale; // 0x30
	private List<Transform> _ChildTrans; // 0x38
	private List<CanvasGroup> _CanvasGroups; // 0x40
	private UIViewAnimationScale.State m_enumState; // 0x48
	private Sequence _OpenSequence; // 0x50
	private Sequence _CloseSequence; // 0x58
	private Action _CloseComplete; // 0x60

	// Methods

	// RVA: 0x1BD4A7F Offset: 0x1BD0A7F VA: 0x1BD4A7F
	private void Awake() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BD4CAE Offset: 0x1BD0CAE VA: 0x1BD4CAE
	public void PlayShow(Action OnComplete) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BD4FD3 Offset: 0x1BD0FD3 VA: 0x1BD4FD3
	public void PlayHide(Action OnComplete) { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BD52BF Offset: 0x1BD12BF VA: 0x1BD52BF
	public void FinishShowNow() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

	// RVA: 0x1BD52EA Offset: 0x1BD12EA VA: 0x1BD52EA
	public void FinishHideNow() { throw new System.NotImplementedException("TODO: port from Ghidra"); }
	[CompilerGenerated]
	// RVA: 0x1BD53EF Offset: 0x1BD13EF VA: 0x1BD53EF
	private void <PlayShow>b__12_0() { throw new System.NotImplementedException("TODO: port from Ghidra"); }

}
