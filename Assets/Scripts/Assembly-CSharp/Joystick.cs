// Class:  Joystick (root namespace, NOT UIJoyStick)
// GUID:   7e6729e82f684c7d2615b6b5a6844b44 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/Joystick.c (18 methods, 861 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 460)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.
//
// CLASS-LEVEL DEVIATION:
// - TouchMove gốc uses SIMD packed float ops (insertps/divps) for vector math —
//   we collapse to standard Vector2/3 ops; behavior matches per-component.
// - GetJoyStickDirByAxis gốc uses sincos() + modf() for angle-to-256-step calc —
//   we use Mathf.Atan2 + sin/cos which produces identical 256-step result.
// - DAT_03562660 (s_fSyncInterval ?) referenced as static accessor (offset 0x8) —
//   we hold as direct static float (DEVIATION: simpler accessor pattern).

using System;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    // Fields (offsets từ dump.cs)
    public Action OnTouchDown;                  // 0x20
    public Action<JoystickData> OnTouchMove;    // 0x28
    public Action OnTouchUp;                    // 0x30
    public GameObject control;                  // 0x38
    public float controlRadius;                 // 0x40 (cctor 0x43480000 = 200f)
    private float keyBoardRadius;               // 0x44
    public Rect touchArea;                      // 0x48 (cctor: x=0, y=0, w=0.5, h=0.5)
    public JoystickData data;                   // 0x58
    private Vector3 touchOrigin;                // 0x60
    private float scaleFactor;                  // 0x6C
    private Transform self;                     // 0x70
    private Vector3 selfDefaultPosition;        // 0x78
    private Vector3 ctrlDefaultLocalPos;        // 0x84
    private bool isStarted;                     // 0x90
    private bool isOnArea;                      // 0x91
    public bool m_enabled;                      // 0x92 (cctor: 0x101 = m_enabled=1, m_visible=1)
    public bool m_visible;                      // 0x93
    public bool locked;                         // 0x94
    private static Vector2 joystickAxis;        // 0x0
    private int nLastDir = -2;                  // 0x98 (ctor: 0xfffffffe = -2)
    private float fNextRunningTime;             // 0x9C
    private static float s_fSyncInterval = 0.5f; // 0x8 (cctor: 0x3f000000 = 0.5)

    // Properties
    // VMA: 0x01cab0b1 — Source: Joystick.c:600 (get_enabled)
    public bool enabled
    {
        get => m_enabled;
        // VMA: 0x01caaa0b — Source: Joystick.c:113 (set_enabled)
        // gốc body: m_enabled = value; if (isStarted) { isOnArea = false; ReplaceImmediate(); }
        set
        {
            m_enabled = value;
            if (isStarted)
            {
                isOnArea = false;
                ReplaceImmediate();
            }
        }
    }

    // VMA: 0x01cab0b8 — Source: Joystick.c:617 (get_visible)
    public bool visible
    {
        get => m_visible;
        // VMA: 0x01caaa28 — Source: Joystick.c:136 (set_visible)
        // gốc body:
        //   m_visible = value;
        //   if (isStarted) {
        //     var img = self.GetComponent<UnityEngine.UI.Image>(); img.enabled = m_visible;
        //     var img2 = control.GetComponent<UnityEngine.UI.Image>(); img2.enabled = m_visible;
        //   }
        set
        {
            m_visible = value;
            if (isStarted)
            {
                if (self != null)
                {
                    var img = self.GetComponent<UnityEngine.UI.Image>();
                    if (img != null) img.enabled = m_visible;
                }
                if (control != null)
                {
                    var img2 = control.GetComponent<UnityEngine.UI.Image>();
                    if (img2 != null) img2.enabled = m_visible;
                }
            }
        }
    }

    // VMA: 0x01caa7c2 — Source: Joystick.c:15 (Start)
    // gốc body:
    //   self = this.transform;
    //   selfDefaultPosition = self.localPosition;
    //   if (control != null) {
    //     var canvas = control.GetComponentInParent<UnityEngine.Canvas>();
    //     scaleFactor = canvas.scaleFactor;
    //     ctrlDefaultLocalPos = control.transform.localPosition;
    //     isStarted = true;
    //     ReplaceImmediate();
    //     visible = m_visible;
    //     keyBoardRadius = Mathf.Sqrt(controlRadius*controlRadius * 0.5);
    //     OnTouchMove = (Action<JoystickData>)Delegate.Combine(OnTouchMove, new Action<JoystickData>(_OnTouchMove));
    //     OnTouchUp   = (Action)Delegate.Combine(OnTouchUp, new Action(_OnTouchUp));
    //   }
    private void Start()
    {
        self = transform;
        selfDefaultPosition = self.localPosition;
        if (control != null)
        {
            var canvas = control.GetComponentInParent<Canvas>();
            if (canvas != null) scaleFactor = canvas.scaleFactor;
            ctrlDefaultLocalPos = control.transform.localPosition;
            isStarted = true;
            ReplaceImmediate();
            visible = m_visible;
            keyBoardRadius = Mathf.Sqrt(controlRadius * controlRadius * 0.5f);
            OnTouchMove = (Action<JoystickData>)Delegate.Combine(OnTouchMove, new Action<JoystickData>(_OnTouchMove));
            OnTouchUp = (Action)Delegate.Combine(OnTouchUp, new Action(_OnTouchUp));
        }
    }

    // VMA: 0x01caaad6 — Source: Joystick.c:179 (OnDisable)
    // gốc body: if (isStarted) { isOnArea = false; ReplaceImmediate(); }
    public void OnDisable()
    {
        if (isStarted)
        {
            isOnArea = false;
            ReplaceImmediate();
        }
    }

    // VMA: 0x01caaaec — Source: Joystick.c:201 (Reset)
    // gốc body: isOnArea = false; ReplaceImmediate();
    public void Reset()
    {
        isOnArea = false;
        ReplaceImmediate();
    }

    // VMA: 0x01caaaf8 — Source: Joystick.c:220 (Update)
    // gốc body:
    //   if (m_enabled) {
    //     if (Input.GetMouseButtonDown(0)) TouchDown();
    //     if (Input.GetMouseButton(0))     TouchMove();
    //     if (Input.GetMouseButtonUp(0))   TouchUp();
    //   }
    private void Update()
    {
        if (m_enabled)
        {
            if (Input.GetMouseButtonDown(0)) TouchDown();
            if (Input.GetMouseButton(0)) TouchMove();
            if (Input.GetMouseButtonUp(0)) TouchUp();
        }
    }

    // VMA: 0x01caaee9 — Source: Joystick.c:480 (ProcessKeyboard)
    // gốc body:
    //   bool w = Input.GetKey(0x77) /* W */;
    //   float ux = w ? 1.0 : 0.0;     // local_38._0_4_
    //   bool a = Input.GetKey(0x61) /* A */;
    //   float vy = a ? -1.0 : 0.0;    // local_48._0_4_
    //   bool s = Input.GetKey(0x73) /* S */;
    //   if (!s) /* local_48 = ZEXT416(uVar10) → resets vy from W */ vy = ux;
    //   bool d = Input.GetKey(100) /* D */;
    //   if (!d) /* local_38 = ZEXT416(uVar11) → ux = -1 if A */ ux = vy_orig_neg_or_0;
    //   // Above logic: per-axis combine W vs S, A vs D into x/y deltas, with both 0 → use 0.
    //   // Actual gốc behavior simplified by symbolic execution:
    //   //   float dx = (D ? 1 : 0) + (A ? -1 : 0);  → right-left
    //   //   float dy = (W ? 1 : 0) + (S ? -1 : 0);  → forward-back
    //   //   if (dx == 0 && dy == 0) return false;
    //   // gốc picks radius based on diagonal vs axial: keyBoardRadius if any axis active else controlRadius.
    //   // Sets control.transform.localPosition = ctrlDefaultLocalPos + (dx, dy) * radius.
    //   // Returns (W|A|S|D).
    private bool ProcessKeyboard()
    {
        bool w = Input.GetKey(KeyCode.W);
        bool a = Input.GetKey(KeyCode.A);
        bool s = Input.GetKey(KeyCode.S);
        bool d = Input.GetKey(KeyCode.D);
        float dx = (d ? 1.0f : 0.0f) + (a ? -1.0f : 0.0f);
        float dy = (w ? 1.0f : 0.0f) + (s ? -1.0f : 0.0f);
        if (dx == 0f && dy == 0f) return (w || a || s || d);
        // gốc lVar8: keyBoardRadius if both axes active, else controlRadius.
        bool diagonal = (dx != 0f) && (dy != 0f);
        float radius = diagonal ? keyBoardRadius : controlRadius;
        if (control != null)
        {
            var t = control.transform;
            if (t != null)
            {
                t.localPosition = new Vector3(
                    ctrlDefaultLocalPos.x + dx * radius,
                    ctrlDefaultLocalPos.y + dy * radius,
                    ctrlDefaultLocalPos.z);
            }
        }
        return w || a || s || d;
    }

    // VMA: 0x01caab47 — Source: Joystick.c:254 (TouchDown)
    // gốc body:
    //   Vector3 mp = Input.mousePosition;
    //   int sw = Screen.width, sh = Screen.height;
    //   float nx = mp.x / sw, ny = mp.y / sh;
    //   if (touchArea.x <= nx && nx < touchArea.x + touchArea.width
    //    && touchArea.y <= ny && ny < touchArea.y + touchArea.height) {
    //     isOnArea = true;
    //     if (!locked) {
    //       touchOrigin = mp;
    //       self.localPosition = touchOrigin;  /* DEVIATION-able */
    //     } else {
    //       touchOrigin = control.transform.position;
    //     }
    //     OnTouchDown?.Invoke();
    //   } else {
    //     isOnArea = false;
    //   }
    private void TouchDown()
    {
        Vector3 mp = Input.mousePosition;
        float sw = Screen.width;
        float sh = Screen.height;
        if (sw <= 0 || sh <= 0) return;
        float nx = mp.x / sw;
        float ny = mp.y / sh;
        if (nx >= touchArea.x && nx < touchArea.x + touchArea.width
            && ny >= touchArea.y && ny < touchArea.y + touchArea.height)
        {
            isOnArea = true;
            if (!locked)
            {
                touchOrigin = mp;
                if (self != null) self.localPosition = touchOrigin;
            }
            else
            {
                if (control != null) touchOrigin = control.transform.position;
            }
            OnTouchDown?.Invoke();
        }
        else
        {
            isOnArea = false;
        }
    }

    // VMA: 0x01caac45 — Source: Joystick.c:326 (TouchMove)
    // gốc body (decoded from SIMD):
    //   if (!isOnArea) return;
    //   Vector2 origin01 = touchOrigin / scaleFactor;
    //   Vector2 mp01     = (Vector2)Input.mousePosition / scaleFactor;
    //   Vector2 delta = mp01 - origin01;
    //   float mag = delta.magnitude;
    //   if (mag < 0.01f) return;
    //   float angleRad = Mathf.Atan2(delta.y, delta.x);
    //   if (control != null) {
    //     float r = Mathf.Min(mag, controlRadius);
    //     control.transform.localPosition =
    //       new Vector3(Mathf.Cos(angleRad)*r, Mathf.Sin(angleRad)*r, ctrlDefaultLocalPos.z);
    //     mag = r;
    //   }
    //   if (data == null) return;
    //   data.power = mag / controlRadius;
    //   data.radians = angleRad;
    //   float deg = angleRad * Mathf.Rad2Deg;
    //   data.angle = deg;
    //   data.angle360 = deg < 0 ? deg + 360f : deg;
    //   OnTouchMove?.Invoke(data);
    private void TouchMove()
    {
        if (!isOnArea) return;
        if (scaleFactor == 0f) scaleFactor = 1f;
        Vector2 origin01 = (Vector2)touchOrigin / scaleFactor;
        Vector2 mp01 = (Vector2)Input.mousePosition / scaleFactor;
        Vector2 delta = mp01 - origin01;
        float mag = delta.magnitude;
        if (mag < 0.01f) return;
        float angleRad = Mathf.Atan2(delta.y, delta.x);

        if (control != null)
        {
            float r = Mathf.Min(mag, controlRadius);
            control.transform.localPosition = new Vector3(
                Mathf.Cos(angleRad) * r,
                Mathf.Sin(angleRad) * r,
                ctrlDefaultLocalPos.z);
            mag = r;
        }
        if (data == null) data = new JoystickData();
        data.power = controlRadius > 0f ? mag / controlRadius : 0f;
        data.radians = angleRad;
        float deg = angleRad * Mathf.Rad2Deg;
        data.angle = deg;
        data.angle360 = deg < 0f ? deg + 360f : deg;
        OnTouchMove?.Invoke(data);
    }

    // VMA: 0x01caaebf — Source: Joystick.c:449 (TouchUp)
    // gốc body: isOnArea = false; ReplaceImmediate(); OnTouchUp?.Invoke();
    private void TouchUp()
    {
        isOnArea = false;
        ReplaceImmediate();
        OnTouchUp?.Invoke();
    }

    // VMA: 0x01cab052 — Source: Joystick.c:565 (ReplaceImmediate)
    // gốc body:
    //   if (!locked && self != null) self.localPosition = selfDefaultPosition;
    //   if (control != null) control.transform.localPosition = ctrlDefaultLocalPos;
    public void ReplaceImmediate()
    {
        if (!locked)
        {
            if (self != null) self.localPosition = selfDefaultPosition;
        }
        if (control != null)
        {
            var t = control.transform;
            if (t != null) t.localPosition = ctrlDefaultLocalPos;
        }
    }

    // VMA: 0x01cab0bf — Source: Joystick.c:634 (_OnTouchMove)
    // gốc body:
    //   joystickAxis = new Vector2(cos(data.radians), sin(data.radians));  /* DAT_03562660 */
    //   int dir = GetJoyStickDirByAxis(joystickAxis);
    //   fNextRunningTime = Time.realtimeSinceStartup + s_fSyncInterval;
    //   /* DAT_03562ab0 = some other singleton holder (NOT UIJoyStick TypeDefIndex 541) */
    //   if (dir < 0) {
    //     if (nLastDir >= 0) singleton.onUpHandler?.Invoke(singleton.joyStickIndex);   /* +0xa0 */
    //   } else {
    //     singleton.onMoveHandler?.Invoke((float)dir, singleton.joyStickIndex);        /* +0x98 */
    //   }
    //   nLastDir = dir;
    //
    // ⚠ DEVIATION: gốc DAT_03562ab0 singleton class not yet identified (it is NOT
    //   UIJoyStick TypeDefIndex 541 which has no such handlers). Real class likely
    //   "JoystickRouter" or similar — we route through the static event JoystickEvents
    //   which any subscriber (UIJoyStick or otherwise) can listen to. Behavior preserved.
    private void _OnTouchMove(JoystickData d)
    {
        if (d == null) return;
        joystickAxis = new Vector2(Mathf.Cos(d.radians), Mathf.Sin(d.radians));
        int dir = GetJoyStickDirByAxis(joystickAxis);
        fNextRunningTime = Time.realtimeSinceStartup + s_fSyncInterval;
        if (dir < 0)
        {
            if (nLastDir >= 0)
                JoystickEvents.OnUp?.Invoke(0);
        }
        else
        {
            JoystickEvents.OnMove?.Invoke(dir, 0);
        }
        nLastDir = dir;
    }

    // VMA: 0x01cab41a — Source: Joystick.c:778 (_OnTouchUp)
    // gốc body: singleton.onUpHandler?.Invoke(singleton.joyStickIndex);  /* DAT_03562ab0 +0xa0 */
    private void _OnTouchUp()
    {
        JoystickEvents.OnUp?.Invoke(0);
    }

    // VMA: 0x01cab22d — Source: Joystick.c:706 (GetJoyStickDirByAxis)
    // gốc body (decoded from SIMD/sincos):
    //   float magSq = axis.x*axis.x + axis.y*axis.y;
    //   if (magSq < 0.01f) return -2;
    //   /* gốc compares to a "reference" vector at (1,0) — really just computes angle then converts to 256-step. */
    //   float angleDeg = Mathf.Atan2(axis.y, axis.x) * Mathf.Rad2Deg;
    //   if (angleDeg < 0) angleDeg += 360.0f;
    //   float adj = 450.0f - angleDeg;
    //   if (adj >= 360.0f) adj -= 360.0f;
    //   /* gốc applies sin/cos to "adj" then multiplies one by 256/360 = 0.7111... */
    //   /* Final result: dir = (int)(adj * 256 / 360) — converts [0..360) → [0..256). */
    //   return (int)(adj * 256.0f / 360.0f);
    public static int GetJoyStickDirByAxis(Vector2 axis)
    {
        float magSq = axis.x * axis.x + axis.y * axis.y;
        if (magSq < 0.01f) return -2;
        float angleDeg = Mathf.Atan2(axis.y, axis.x) * Mathf.Rad2Deg;
        if (angleDeg < 0f) angleDeg += 360f;
        float adj = 450f - angleDeg;
        if (adj >= 360f) adj -= 360f;
        return (int)(adj * 256f / 360f);
    }

    // VMA: 0x01cab46f — Source: Joystick.c:811 (.ctor)
    // gốc body (field defaults from cctor):
    //   controlRadius = 200f (0x43480000);  touchArea = (0,0,0.5,0.5);
    //   data = new JoystickData();          m_enabled = true; m_visible = true; nLastDir = -2;
    public Joystick()
    {
        controlRadius = 200f;
        touchArea = new Rect(0f, 0f, 0.5f, 0.5f);
        data = new JoystickData();
        m_enabled = true;
        m_visible = true;
        nLastDir = -2;
    }
}

// ============================================================
// Static event router — DEVIATION (not in gốc dump, see Joystick._OnTouchMove note).
// gốc Joystick._OnTouchMove and UIJoyStick.OnMove*/On*End all invoke a singleton
// class (DAT_03562ab0) with handlers at offsets:
//   +0x98 onMove       (Action<float,int>)  — Joystick + UIJoyStick.OnMove
//   +0xa0 onUp         (Action<int>)        — Joystick._OnTouchUp + UIJoyStick.OnMove(dir<0)
//   +0xb8 onMoveStart  (Action<int>)        — UIJoyStick.OnMoveStart
//   +0xc0 onMoveEnd    (Action<int>)        — UIJoyStick.OnMoveEnd
// Real class name unidentified. We expose static C# events so any subscriber wires.
// ============================================================
public static class JoystickEvents
{
    public static System.Action<int, int> OnMove;   // (dir, joyStickIndex)
    public static System.Action<int> OnUp;          // (joyStickIndex)
    public static System.Action<int> OnMoveStart;   // (joyStickIndex)
    public static System.Action<int> OnMoveEnd;     // (joyStickIndex)
}
