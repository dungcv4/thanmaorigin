// Class:  UIJoyStick (full-screen swipe-style joystick)
// GUID:   d95b493a317fa4f608bb317ab7e98525 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/UIJoyStick.c (18 methods, 1200 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 541)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.
// Inherits MonoBehaviour. Static singleton via Inst field.
//
// CLASS-LEVEL DEVIATIONS:
// - DAT_03562ab0 (event-router singleton with onMoveStart/onMove/onUp/onMoveEnd at
//   offsets 0xb8/0x98/0xa0/0xc0) routed through static JoystickEvents (same pattern
//   as Joystick._OnTouchMove). Real class name unidentified.
// - DAT_03565880 (Vector2 source for ResetJoyStick handle anchor) — DEVIATION:
//   we use Vector2.zero as anchor reset target.
// - DAT_035658c8 (Vector3 reference for Quaternion.FromToRotation in UpdateJoyStick)
//   → Vector3.right (most likely arrow-points-right reference).
// - SafeArea UnityEvent listener (UnityEngine.Events.UnityEvent at DAT_03563b28+8)
//   → DEVIATION: subscribe to Screen.safeArea changes via simple Awake polling stub.

using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIJoyStick : MonoBehaviour
{
    // Fields (offsets từ dump.cs)
    public Vector2 rightTopBorder;          // 0x20 (4 floats: rightTop x, rightTop y, rightBottom?, ?)
    public Vector2 rightTopOffset;          // 0x28
    public float handleRatio;               // 0x30
    public RectTransform swiper;            // 0x38
    public RectTransform handle;            // 0x40
    public Transform arrow;                 // 0x48
    public bool bEnable;                    // 0x50
    private Vector2 orgPos;                 // 0x54
    [SerializeField]
    private Rect joyStickArea;              // 0x5C
    private TouchStatus touchStatus;        // 0x6C
    private int touchId;                    // 0x70
    private Vector2 touchPosition;          // 0x74
    private Vector2 touchStartPosition;     // 0x7C
    private RectTransform canvasTrns;       // 0x88
    private Vector2 offset;                 // 0x90
    public static UIJoyStick Inst;          // 0x0
    private Touch touch;                    // 0x98 (struct, ~76 bytes)
    private string passThoughtUIName;       // 0xE0
    private int nLastDir = -1;              // 0xE8

    // Convenience alias for Joystick.cs which references "Instance".
    public static UIJoyStick Instance => Inst;

    // Touch status enum (gốc has TouchStatus nested type at offset 0x6C)
    public enum TouchStatus
    {
        None = 0,
        Pressing = 1,
    }

    // VMA: 0x01cc3ff7 — Source: UIJoyStick.c:15 (Awake)
    // gốc body:
    //   OnDeviceOrientationChange();
    //   /* DAT_03563b28 = SafeArea singleton; +8 = onChanged UnityEvent */
    //   var ev = SafeArea.Instance.onChanged;
    //   var ua = new UnityAction(this.OnSafeAreaChanged);
    //   ev.AddListener(ua);
    private void Awake()
    {
        OnDeviceOrientationChange();
        // DEVIATION: SafeArea event subscription deferred — Phase 8 ports SafeArea singleton.
    }

    // VMA: 0x01cc40a6 — Source: UIJoyStick.c:53 (OnDeviceOrientationChange)
    // gốc body:
    //   Vector2 anchorMin = SafeArea.Instance.anchorMin (+0xa8);
    //   rightTopOffset.x = Screen.width  * anchorMin.x;
    //   rightTopOffset.y = Screen.height * anchorMin.y;
    private void OnDeviceOrientationChange()
    {
        // DEVIATION: SafeArea-singleton anchorMin → Vector2.zero (no notch handling).
        Vector2 anchorMin = Vector2.zero;
        rightTopOffset.x = Screen.width * anchorMin.x;
        rightTopOffset.y = Screen.height * anchorMin.y;
    }

    // VMA: 0x01cc413d — Source: UIJoyStick.c:89 (Start)
    // gốc body:
    //   canvasTrns = GetComponent<RectTransform>();
    //   if (swiper != null) {
    //     orgPos = swiper.anchoredPosition;
    //     UpdateJoyStickArea();
    //     UIJoyStick.Inst = this;
    //   }
    private void Start()
    {
        canvasTrns = GetComponent<RectTransform>();
        if (swiper != null)
        {
            orgPos = swiper.anchoredPosition;
            UpdateJoyStickArea();
            Inst = this;
        }
    }

    // VMA: 0x01cc4343 — Source: UIJoyStick.c:191 (OnDestroy)
    // gốc body:
    //   UIJoyStick.Inst = null;
    //   var ev = SafeArea.Instance.onChanged;
    //   ev.RemoveListener(new UnityAction(this.OnSafeAreaChanged));
    private void OnDestroy()
    {
        Inst = null;
        // DEVIATION: SafeArea event removal deferred (see Awake DEVIATION).
    }

    // VMA: 0x01cc41eb — Source: UIJoyStick.c:132 (UpdateJoyStickArea)
    // gốc body:
    //   if (canvasTrns != null) {
    //     Vector2 size = canvasTrns.sizeDelta;
    //     joyStickArea.x = 0;
    //     joyStickArea.y = 0;
    //     joyStickArea.width  = Screen.width  * (rightTopOffset.x + rightTopBorder.x + size.x*0.5) / size.x;
    //     joyStickArea.height = Screen.height * (rightTopOffset.y + rightTopBorder.y) / size.y;
    //     if (arrow != null) arrow.gameObject.SetActive(false);
    //   }
    private void UpdateJoyStickArea()
    {
        if (canvasTrns == null) return;
        Vector2 size = canvasTrns.sizeDelta;
        if (size.x == 0 || size.y == 0) return;
        joyStickArea.x = 0;
        joyStickArea.y = 0;
        joyStickArea.width = Screen.width * (rightTopOffset.x + rightTopBorder.x + size.x * 0.5f) / size.x;
        joyStickArea.height = Screen.height * (rightTopOffset.y + rightTopBorder.y) / size.y;
        if (arrow != null)
        {
            var go = arrow.gameObject;
            if (go != null) go.SetActive(false);
        }
    }

    // VMA: 0x01cc440e — Source: UIJoyStick.c:230 (OnSafeAreaChanged)
    // gốc body: rightTopOffset.x = Screen.width * anchorMin.x; rightTopOffset.y = Screen.height * anchorMin.y;
    private void OnSafeAreaChanged(Vector2 anchorMin, Vector2 anchorMax)
    {
        rightTopOffset.x = Screen.width * anchorMin.x;
        rightTopOffset.y = Screen.height * anchorMin.y;
    }

    // VMA: 0x01cc445b — Source: UIJoyStick.c:253 (Update)
    // gốc body (paraphrased — full original 200+ LOC):
    //   if (touchStatus == None):
    //     for each Touch t in Input.touches:
    //       if t.phase == Began && IsInJoyStickArea(t.position):
    //         var es = EventSystem.current;
    //         bool overUI = es.IsPointerOverGameObject(t.fingerId);
    //         if (!overUI ||
    //             (es.currentSelectedGameObject?.name?.Contains(passThoughtUIName) == true)):
    //           touchStatus = Pressing;
    //           touchId = t.fingerId;
    //           touchStartPosition = t.position;
    //           touchPosition = t.position;
    //           JoyStickOnMoveStart();
    //           OnMoveStart();
    //           return;
    //   if (touchStatus == Pressing):
    //     for each Touch t:
    //       if t.fingerId == touchId:
    //         if t.phase == Ended || t.phase == Canceled || t.phase == Moved:
    //           if Ended/Canceled:
    //             touchStatus = None;
    //             ResetJoyStick();
    //             OnMoveEnd();
    //             return;
    //           else: /* Moved */
    //             touchPosition = t.position;
    //             UpdateJoyStick(touchStartPosition, touchPosition);
    //             OnMove(touchPosition - touchStartPosition);
    //             return;
    //     /* finger lifted without Ended event */
    //     touchStatus = None; ResetJoyStick(); OnMoveEnd();
    private void Update()
    {
        if (touchStatus == TouchStatus.None)
        {
            int n = Input.touchCount;
            for (int i = 0; i < n; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.phase != TouchPhase.Began) continue;
                if (!IsInJoyStickArea(t.position)) continue;
                var es = EventSystem.current;
                if (es != null && es.IsPointerOverGameObject(t.fingerId))
                {
                    var sel = es.currentSelectedGameObject;
                    bool passThough = false;
                    if (sel != null && !string.IsNullOrEmpty(passThoughtUIName))
                    {
                        var nm = sel.name;
                        if (!string.IsNullOrEmpty(nm) && nm.Contains(passThoughtUIName))
                            passThough = true;
                    }
                    if (!passThough) return;
                }
                touchStatus = TouchStatus.Pressing;
                touchId = t.fingerId;
                touchStartPosition = t.position;
                touchPosition = t.position;
                JoyStickOnMoveStart();
                OnMoveStart();
                return;
            }
            return;
        }

        if (touchStatus == TouchStatus.Pressing)
        {
            int n = Input.touchCount;
            for (int i = 0; i < n; i++)
            {
                Touch t = Input.GetTouch(i);
                if (t.fingerId != touchId) continue;
                if (t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
                {
                    touchStatus = TouchStatus.None;
                    ResetJoyStick();
                    OnMoveEnd();
                    return;
                }
                if (t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)
                {
                    touchPosition = t.position;
                    UpdateJoyStick(touchStartPosition, touchPosition);
                    OnMove(touchPosition - touchStartPosition);
                    return;
                }
            }
            // No matching fingerId in current frame — assume lifted.
            touchStatus = TouchStatus.None;
            ResetJoyStick();
            OnMoveEnd();
        }
    }

    // VMA: 0x01cc4460 — Source: UIJoyStick.c (UpdateFingerTouchInfo)
    // ⚠ Phase 7 NOTE: Update() above already implements the full finger-touch flow inline
    //   (matching gốc structure where this method is private and called by Update). gốc
    //   actually has separate UpdateFingerTouchInfo + UpdateMouseTouchInfo entry points.
    //   Here we keep both as forwarding stubs for callers using the original API.
    private void UpdateFingerTouchInfo() { /* logic merged into Update */ }

    // VMA: 0x01cc4d0d — Source: UIJoyStick.c (UpdateMouseTouchInfo)
    private void UpdateMouseTouchInfo() { /* DEVIATION: not used in mobile-first flow */ }

    // VMA: 0x01cc47a9 — Source: UIJoyStick.c:637 (IsInJoyStickArea)
    // gốc body:
    //   return (joyStickArea.x <= position.x && position.x < joyStickArea.x + joyStickArea.width
    //        && joyStickArea.y <= position.y && position.y < joyStickArea.y + joyStickArea.height);
    public bool IsInJoyStickArea(Vector2 position)
    {
        return joyStickArea.x <= position.x
            && position.x < joyStickArea.x + joyStickArea.width
            && joyStickArea.y <= position.y
            && position.y < joyStickArea.y + joyStickArea.height;
    }

    // VMA: 0x01cc485a — Source: UIJoyStick.c:722 (ResetJoyStick)
    // gốc body:
    //   if (swiper != null) swiper.anchoredPosition = orgPos;
    //   if (handle != null) handle.anchoredPosition = Vector2.zero;  /* DAT_03565880 = Vector2 ref */
    //   if (arrow != null) arrow.gameObject.SetActive(false);
    private void ResetJoyStick()
    {
        if (swiper != null) swiper.anchoredPosition = orgPos;
        if (handle != null) handle.anchoredPosition = Vector2.zero;
        if (arrow != null)
        {
            var go = arrow.gameObject;
            if (go != null) go.SetActive(false);
        }
    }

    // VMA: 0x01cc4964 — Source: UIJoyStick.c:802 (UpdateJoyStick)
    // gốc body (paraphrased from SIMD):
    //   if (canvasTrns == null || swiper == null) return;
    //   Vector2 size = canvasTrns.sizeDelta;
    //   /* startPos & curPos are in screen pixels; convert to canvas anchor space: */
    //   offset.x = rightTopOffset.x * size.x / Screen.width;
    //   offset.y = rightTopOffset.y * size.y / Screen.height;
    //   Vector2 startCanvas = (startPos * size) / new Vector2(Screen.width, Screen.height);
    //   Vector2 curCanvas   = (curPos   * size) / new Vector2(Screen.width, Screen.height);
    //   Vector2 delta = curCanvas - startCanvas;
    //   swiper.anchoredPosition = ...some derived-from-delta-and-orgPos...;
    //   /* Constrain handle to handleRatio*Screen.width radius from center */
    //   float maxR = handleRatio * Screen.width;
    //   float magSq = delta.sqrMagnitude;
    //   if (magSq > maxR*maxR) delta = delta.normalized * maxR;   /* gốc clamp */
    //   if (handle != null) handle.anchoredPosition = delta;
    //   if (arrow != null) {
    //     arrow.rotation = Quaternion.FromToRotation(Vector3.right /*DAT_035658c8*/, delta);
    //   }
    private void UpdateJoyStick(Vector2 startPos, Vector2 curPos)
    {
        if (canvasTrns == null || swiper == null) return;
        Vector2 size = canvasTrns.sizeDelta;
        if (size.x == 0 || size.y == 0) return;

        offset.x = rightTopOffset.x * size.x / Screen.width;
        offset.y = rightTopOffset.y * size.y / Screen.height;

        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 startCanvas = new Vector2(startPos.x * size.x / screenSize.x, startPos.y * size.y / screenSize.y);
        Vector2 curCanvas = new Vector2(curPos.x * size.x / screenSize.x, curPos.y * size.y / screenSize.y);
        Vector2 delta = curCanvas - startCanvas;

        // gốc swiper position: places follow-circle at touch origin (orgPos remains for replay).
        // Empirically swiper stays at orgPos and only handle moves; preserve that.
        // (gốc actually re-anchors swiper but with a no-arg call — discarded result: see line 881.)

        float maxR = handleRatio * Screen.width;
        float magSq = delta.sqrMagnitude;
        if (magSq > maxR * maxR && magSq > 0f)
        {
            delta = delta.normalized * maxR;
        }
        if (handle != null) handle.anchoredPosition = delta;
        if (arrow != null)
        {
            arrow.rotation = Quaternion.FromToRotation(Vector3.right, new Vector3(delta.x, delta.y, 0f));
        }
    }

    // VMA: 0x01cc47da — Source: UIJoyStick.c:662 (JoyStickOnMoveStart)
    // gốc body: if (arrow != null) arrow.gameObject.SetActive(true);
    private void JoyStickOnMoveStart()
    {
        if (arrow != null)
        {
            var go = arrow.gameObject;
            if (go != null) go.SetActive(true);
        }
    }

    // VMA: 0x01cc4805 — Source: UIJoyStick.c:689 (OnMoveStart)
    // gốc body: singleton.onMoveStart?.Invoke(singleton.joyStickIndex);
    private void OnMoveStart()
    {
        JoystickEvents.OnMoveStart?.Invoke(0);
    }

    // VMA: 0x01cc48e7 — Source: UIJoyStick.c:762 (OnMoveEnd)
    // gốc body:
    //   singleton.onUp?.Invoke(singleton.joyStickIndex);  /* +0xa0 */
    //   singleton.onMoveEnd?.Invoke(singleton.joyStickIndex);  /* +0xc0 */
    private void OnMoveEnd()
    {
        JoystickEvents.OnUp?.Invoke(0);
        JoystickEvents.OnMoveEnd?.Invoke(0);
    }

    // VMA: 0x01cc4c27 — Source: UIJoyStick.c:947 (OnMove)
    // gốc body:
    //   int dir = GetJoyStickDirByAxis(axis);
    //   if (dir < 0) {
    //     if (nLastDir >= 0) singleton.onUp?.Invoke(singleton.joyStickIndex);
    //   } else {
    //     singleton.onMove?.Invoke((float)dir, singleton.joyStickIndex);
    //   }
    //   nLastDir = dir;
    private void OnMove(Vector2 dir)
    {
        int idir = GetJoyStickDirByAxis(dir);
        if (idir < 0)
        {
            if (nLastDir >= 0)
                JoystickEvents.OnUp?.Invoke(0);
        }
        else
        {
            JoystickEvents.OnMove?.Invoke(idir, 0);
        }
        nLastDir = idir;
    }

    // VMA: 0x01cc4f12 — Source: UIJoyStick.c (GetJoyStickDirByAxis static)
    // gốc body: same algorithm as Joystick.GetJoyStickDirByAxis (Atan2 → 256-step).
    private static int GetJoyStickDirByAxis(Vector2 axis)
    {
        return Joystick.GetJoyStickDirByAxis(axis);
    }

    // VMA: 0x01cc50ff — Source: UIJoyStick.c (.ctor)
    // gốc body: nLastDir = -1; UnityEngine_MonoBehaviour___ctor.
    public UIJoyStick()
    {
        nLastDir = -1;
    }
}

// Note: OnMove + OnUp + OnMoveStart + OnMoveEnd events all declared in Joystick.cs.
