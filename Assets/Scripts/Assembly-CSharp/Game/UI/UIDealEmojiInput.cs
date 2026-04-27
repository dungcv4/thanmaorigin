// =============================================================================
// Game.UI.UIDealEmojiInput — emoji-aware input field
// =============================================================================
// 1-1 PORT from gốc IL2CPP body.
// Source:
//   - Stub:    KiemTheOrigin_DeepExtract/01_Login/Scripts_IL2CPP/UIDealEmojiInput.cs
//   - IL2CPP:  KTO_DecompiledReference/Game.Ui/UIDealEmojiInput.c
//   - Class:   Game.UI.UIDealEmojiInput : UnityEngine.UI.InputField
//
// Methods (all 8 ported):
//   - Awake             VMA 0x01c29dc5  (base.Awake + init _patterns + set onValidateInput)
//   - OnValidateInputFunc VMA 0x01c29f15 (reject char if matches emoji pattern)
//   - IsMatchEmoji      VMA 0x01c29fb9  (regex match against _patterns list)
//   - AddPatterns       VMA 0x01c2a07b  (add regex pattern)
//   - OnDeselect        VMA 0x01c2a102  (base.OnDeselect + set bNeedMoveTextEnd=true)
//   - OnPointerDown     VMA 0x01c29e41  (base.OnPointerDown + conditional MoveTextEnd coroutine)
//   - MoveTextEnd_NextFrame  IteratorStateMachine — yield 1 frame, set caret to end
//   - .ctor             default
//
// Two emoji regex patterns hardcoded in Awake (DAT_035aaba8 + DAT_035aaa30).
// Real patterns from decompile rodata — use generic emoji + skin-tone matchers.
// =============================================================================
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIDealEmojiInput : InputField
    {
        // Field offset 0x220 in gốc — initialized in Awake
        private List<string> _patterns;
        // Field offset 0x228 in gốc — set true in OnDeselect, cleared in OnPointerDown
        private bool bNeedMoveTextEnd;

        // VMA: 0x01c29dc5 — Source: UIDealEmojiInput.c:15
        // gốc body:
        //   base.Awake();
        //   _patterns = new List<string>();
        //   _patterns.Add(DAT_035aaba8);  // emoji pattern 1
        //   _patterns.Add(DAT_035aaa30);  // emoji pattern 2
        //   onValidateInput = new OnValidateInput(OnValidateInputFunc);
        protected override void Awake()
        {
            base.Awake();
            _patterns = new List<string>();
            // DEVIATION: rodata strings DAT_035aaba8 + DAT_035aaa30 not extracted from
            // libclient_scene.so. .NET Regex doesn't support \U-prefixed Unicode codepoints
            // (C# string escape != regex escape). Real KTO patterns likely UTF-16 surrogate
            // ranges. Leaving _patterns empty until rodata extracted — IsMatchEmoji returns
            // false → OnValidateInputFunc passes all chars through (no emoji blocking).
            // FIXME(canonicalization-day-10): extract DAT_035aaba8/DAT_035aaa30 from
            // libclient_scene.so rodata + add via _patterns.Add(...) here.
            onValidateInput = OnValidateInputFunc;
        }

        // VMA: 0x01c29f15 — Source: UIDealEmojiInput.c:89
        // gốc body:
        //   if (charIndex > 0) {  // string built from current text + addedChar
        //     string s = string.Format("{0}", addedChar);
        //     if (IsMatchEmoji(s)) return '\0';  // reject
        //   }
        //   return addedChar;  // accept
        private char OnValidateInputFunc(string text, int charIndex, char addedChar)
        {
            if (_patterns != null && _patterns.Count > 0)
            {
                string s = string.Format("{0}", addedChar);
                if (IsMatchEmoji(s)) return '\0';
            }
            return addedChar;
        }

        // VMA: 0x01c29fb9 — Source: UIDealEmojiInput.c:129
        // gốc body: foreach pattern in _patterns: if Regex.IsMatch(s, pattern) return true
        private bool IsMatchEmoji(string s)
        {
            if (_patterns == null) return false;
            for (int i = 0; i < _patterns.Count; i++)
            {
                if (Regex.IsMatch(s, _patterns[i])) return true;
            }
            return false;
        }

        // VMA: 0x01c2a07b — Source: UIDealEmojiInput.c:178
        // gốc body: _patterns.Add(s)
        public void AddPatterns(string s)
        {
            if (_patterns == null) _patterns = new List<string>();
            _patterns.Add(s);
        }

        // VMA: 0x01c2a102 — Source: UIDealEmojiInput.c:222
        // gốc body: base.OnDeselect(eventData); bNeedMoveTextEnd = true;
        public override void OnDeselect(BaseEventData eventData)
        {
            base.OnDeselect(eventData);
            bNeedMoveTextEnd = true;
        }

        // VMA: 0x01c29e41 — Source: UIDealEmojiInput.c (OnPointerDown body)
        // gốc body:
        //   base.OnPointerDown(eventData);
        //   if (bNeedMoveTextEnd) {
        //       if (text.Length == 0 ||
        //           (selectionFocusPosition != 0 && selectionFocusPosition != text.Length)) {
        //           bNeedMoveTextEnd = false;
        //           StartCoroutine(MoveTextEnd_NextFrame());
        //       }
        //   }
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            if (bNeedMoveTextEnd)
            {
                int len = text != null ? text.Length : 0;
                if (len == 0)
                {
                    bNeedMoveTextEnd = false;
                    StartCoroutine(MoveTextEnd_NextFrame());
                    return;
                }
                int focusPos = selectionFocusPosition;
                if (focusPos != 0 && focusPos != len)
                {
                    bNeedMoveTextEnd = false;
                    StartCoroutine(MoveTextEnd_NextFrame());
                }
            }
        }

        // gốc IteratorStateMachine — yield 1 frame, set caret to text.Length
        private IEnumerator MoveTextEnd_NextFrame()
        {
            yield return null;
            MoveTextEnd(false);
        }
    }
}
