// gốc: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 517)
// Source: KTO_DecompiledReference/_root/UIDoubleClick.c
//
// gốc fields: Interval, _clickedCount, _maxClickCount, _lastClickTime,
//             _button, _isButtonNotNull, _isDragging, ScrollView,
//             _callback (LuaFunction)
// gốc base: MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
//
// PORT 2026-05-02: minimal restore + DEVIATION shim for caller compat.
//
// DEVIATION — `OnDoubleClick` Action property NOT in gốc dump.cs.
// Reason: UIPanel.SetDoubleClick (cited port at line 758) assigns
//         `c.OnDoubleClick = () => funcCall.Call()` — gốc would store the
//         LuaFunction directly into private _callback. Kept as Action shim
//         that wraps gốc _callback semantic so UIPanel compiles.
// Approved by user: 2026-05-02 ("fix hết đi" — compile fix pass)
// Future fix: rewrite UIPanel.SetDoubleClick to bind via gốc semantics
//             (store LuaFunction into _callback, no Action wrapper).

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using XLua;

public class UIDoubleClick : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // gốc fields (dump.cs offsets 0x20..0x48)
    public float Interval = 0.3f;
    private int _clickedCount;
    private int _maxClickCount = 2;
    private float _lastClickTime;
    private LuaFunction _callback;

    // DEVIATION shim — UIPanel.cs:758 assigns Action delegate
    public Action OnDoubleClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        float now = Time.time;
        if (now - _lastClickTime <= Interval)
        {
            _clickedCount++;
            if (_clickedCount >= _maxClickCount)
            {
                _clickedCount = 0;
                OnDoubleClick?.Invoke();
                if (_callback != null) _callback.Call();
            }
        }
        else
        {
            _clickedCount = 1;
        }
        _lastClickTime = now;
    }

    public void OnBeginDrag(PointerEventData eventData) { _clickedCount = 0; }
    public void OnDrag(PointerEventData eventData) { }
    public void OnEndDrag(PointerEventData eventData) { }
}
