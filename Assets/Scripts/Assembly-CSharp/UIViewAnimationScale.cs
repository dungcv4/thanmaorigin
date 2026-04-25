// Class:  UIViewAnimationScale
// GUID:   9f6d8f2be8a7daf7b2d9b65d883fd90c (preserved via .meta)
// Source: KTO_DecompiledReference/_root/UIViewAnimationScale.c (7 methods, 439 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs
//
// 1-1 port từ gốc Ghidra. Mỗi method có VMA cite.
// Animation library: DG.Tweening (DOTween Free 1.0.327 từ github.com/Demigiant/dotween).
// Default ease = Ease.OutQuad (DOTween default — matches gốc IL2CPP behavior).

using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIViewAnimationScale : MonoBehaviour
{
    // States (gốc m_enumState at offset 0x48)
    private enum State { Idle = 0, Show = 1, Hide = 2 }

    // Fields (offsets từ dump.cs)
    private RectTransform m_rectTrans;       // 0x20
    public float _OpenTime  = 0.3f;          // 0x28 — gốc default 0x3e99999a
    public float _CloseTime = 0.1f;          // 0x2C — gốc default 0x3dcccccd
    public float _InitScale = 0.8f;          // 0x30 — gốc default 0x3f4ccccd
    private List<Transform> _ChildTrans;     // 0x38
    private List<CanvasGroup> _CanvasGroups; // 0x40
    private State m_enumState = State.Idle;  // 0x48
    private Sequence _OpenSequence;          // 0x50
    private Sequence _CloseSequence;         // 0x58
    private Action _CloseComplete;           // 0x60

    // VMA: 0x01cd5331 — Source: UIViewAnimationScale.c:4817
    // gốc .ctor: init lists. Defaults from field init match gốc 0x3e99999a / 0x3dcccccd / 0x3f4ccccd.
    public UIViewAnimationScale()
    {
        _ChildTrans = new List<Transform>();
        _CanvasGroups = new List<CanvasGroup>();
    }

    // VMA: 0x01cd4a7f — Source: UIViewAnimationScale.c:4445
    // gốc: GetComponent<RectTransform> + walk children → add Transform to _ChildTrans + CanvasGroup
    //      (AddComponent if missing) to _CanvasGroups.
    private void Awake()
    {
        m_rectTrans = GetComponent<RectTransform>();
        if (m_rectTrans == null) return;
        for (int i = 0; i < m_rectTrans.childCount; i++)
        {
            var t = m_rectTrans.GetChild(i);
            _ChildTrans.Add(t);
            var cg = t.GetComponent<CanvasGroup>();
            if (cg == null) cg = t.gameObject.AddComponent<CanvasGroup>();
            _CanvasGroups.Add(cg);
        }
    }

    // VMA: 0x01cd4cae — Source: UIViewAnimationScale.c:4380
    // gốc: PlaySound("OpenWindow") → if _OpenTime==0: invoke OnComplete + state=0 + return.
    //      Else state=1, build Sequence: SetLocalScale(_InitScale*Vector3.one), DOScale to (1,1,1) over _OpenTime.
    //      CanvasGroup alpha 0→1 (DOFade). Join all in sequence. Play. Invoke OnComplete sync.
    //      Set OnKill callback to b__12_0 (state=0 if was 1).
    public void PlayShow(Action OnComplete)
    {
        UIModule.PlaySound(AudioModule.GetSoundID("OpenWindow"));

        if (_OpenTime == 0f)
        {
            OnComplete?.Invoke();
            m_enumState = State.Idle;
            return;
        }

        m_enumState = State.Show;
        _OpenSequence = DOTween.Sequence();

        if (_ChildTrans != null)
        {
            for (int i = 0; i < _ChildTrans.Count; i++)
            {
                var t = _ChildTrans[i];
                if (t == null) return;
                t.localScale = Vector3.one * _InitScale;
                _OpenSequence.Join(t.DOScale(Vector3.one, _OpenTime));
                if (_CanvasGroups == null || i >= _CanvasGroups.Count) return;
                var cg = _CanvasGroups[i];
                if (cg == null) return;
                cg.alpha = 0f;
                // DEVIATION: DOTween Free has no CanvasGroup.DOFade shortcut — use DOTween.To.
                var cgRef0 = cg;
                _OpenSequence.Join(DOTween.To(() => cgRef0.alpha, v => cgRef0.alpha = v, 1f, _OpenTime));
            }
            _OpenSequence.Play();
            OnComplete?.Invoke();
            // gốc: OnKill = b__12_0 (state=Idle if was Show)
            _OpenSequence.OnKill(() =>
            {
                if (m_enumState == State.Show) m_enumState = State.Idle;
            });
        }
    }

    // VMA: 0x01cd4fd3 — Source: UIViewAnimationScale.c:4652
    // gốc: if _CloseTime==0: invoke OnComplete + state=0 + return.
    //      Else state=2, Sequence: scale (1,1,1)→_InitScale, alpha 1→0. Store _CloseComplete = OnComplete.
    //      Play. Set OnKill callback fires _CloseComplete.
    public void PlayHide(Action OnComplete)
    {
        if (_CloseTime == 0f)
        {
            OnComplete?.Invoke();
            m_enumState = State.Idle;
            return;
        }

        m_enumState = State.Hide;
        _CloseSequence = DOTween.Sequence();

        if (_ChildTrans != null)
        {
            for (int i = 0; i < _ChildTrans.Count; i++)
            {
                var t = _ChildTrans[i];
                if (t == null) return;
                t.localScale = Vector3.one;
                _CloseSequence.Join(t.DOScale(Vector3.one * _InitScale, _CloseTime));
                if (_CanvasGroups == null || i >= _CanvasGroups.Count) return;
                var cg = _CanvasGroups[i];
                if (cg == null) return;
                cg.alpha = 1f;
                // DEVIATION: DOTween Free has no CanvasGroup.DOFade shortcut — use DOTween.To.
                var cgRef1 = cg;
                _CloseSequence.Join(DOTween.To(() => cgRef1.alpha, v => cgRef1.alpha = v, 0f, _CloseTime));
            }
            _CloseComplete = OnComplete;
            _CloseSequence.Play();
            // gốc: OnKill closure invokes _CloseComplete.
            _CloseSequence.OnKill(() =>
            {
                _CloseComplete?.Invoke();
            });
        }
    }

    // VMA: 0x01cd52bf — Source: UIViewAnimationScale.c:4770
    // gốc: if _OpenSequence != null: Complete it, clear ref, if state==Show → state=Idle.
    public void FinishShowNow()
    {
        if (_OpenSequence != null)
        {
            _OpenSequence.Complete();
            _OpenSequence = null;
            if (m_enumState == State.Show) m_enumState = State.Idle;
        }
    }

    // VMA: 0x01cd52ea — Source: UIViewAnimationScale.c:4790
    // gốc: if _CloseSequence != null: Complete it, if state==Hide: state=Idle + invoke _CloseComplete + clear.
    public void FinishHideNow()
    {
        if (_CloseSequence != null)
        {
            _CloseSequence.Complete();
            if (m_enumState == State.Hide)
            {
                m_enumState = State.Idle;
                _CloseComplete?.Invoke();
                _CloseComplete = null;
            }
            _CloseSequence = null;
        }
    }
}
