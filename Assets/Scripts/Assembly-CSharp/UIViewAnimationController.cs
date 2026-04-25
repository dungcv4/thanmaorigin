// Class:  UIViewAnimationController
// GUID:   4075e8bbfab68b5a9db35613e8414b06 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/UIViewAnimationController.c (5 methods, 128 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs
//
// 1-1 port từ gốc Ghidra IL2CPP decompile. Mỗi method có VMA cite.
// CLAUDE.md: 100% từ gốc, KHÔNG chế cháo. Mọi DEVIATION cite + ask user trước.

using System;
using UnityEngine;

public class UIViewAnimationController : MonoBehaviour
{
    // Fields (offsets từ dump.cs)
    public Animator animator;       // 0x20
    private Action onClose;         // 0x28

    // Cached Animator parameter hash for "State" (gốc DAT_035b2f28).
    // gốc lazy-inits via FUN_0185f84b on first PlayShow/PlayHide call.
    // C# equivalent: static lazy-init on first access.
    private static int s_stateParam = -1;
    private static int GetStateParam()
    {
        if (s_stateParam == -1) s_stateParam = Animator.StringToHash("State");
        return s_stateParam;
    }

    // VMA: 0x01cd49a5 — Source: UIViewAnimationController.c:4343
    // gốc body: empty `return;` (likely AnimationEvent callback hook).
    public void OnOpenComplete()
    {
        return;
    }

    // VMA: 0x01cd49a6 — Source: UIViewAnimationController.c:4356
    // gốc: if (onClose != null) invoke onClose() — fires after close anim done.
    public void OnCloseComplete()
    {
        if (onClose != null) onClose();
    }

    // VMA: 0x01cd49be — Source: UIViewAnimationController.c:4380
    // gốc: lazy-init "State" param, animator.SetInteger("State", 1), invoke OnComplete sync.
    // gốc null-fallback: FUN_0185fa41() ("Subroutine does not return" — IL2CPP null-deref).
    // DEVIATION: C# silently no-ops on null animator (idiomatic Unity safety).
    public void PlayShow(Action OnComplete)
    {
        if (animator != null)
        {
            animator.SetInteger(GetStateParam(), 1);
            if (OnComplete != null) OnComplete();
        }
    }

    // VMA: 0x01cd4a22 — Source: UIViewAnimationController.c:4408
    // gốc: animator.SetInteger("State", 2), STORE OnComplete to onClose field
    //      (fired later by OnCloseComplete via AnimationEvent).
    // DEVIATION: C# silently no-ops on null animator (same as PlayShow).
    public void PlayHide(Action OnComplete)
    {
        if (animator != null)
        {
            animator.SetInteger(GetStateParam(), 2);
            onClose = OnComplete;
        }
    }

    // VMA: 0x01cd4a78 — Source: UIViewAnimationController.c:4431
    // gốc .ctor: just calls MonoBehaviour base ctor. Unity auto-handles.
}
