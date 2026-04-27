// Class:  Game.RepresentLogic.SceneCameraController
// Source: KTO_DecompiledReference/Game.RepresentLogic/SceneCameraController.c
//
// PARTIAL PORT 2026-04-27: Lua calls (Ui.SceneCameraController.X) require these statics.
// Used by Script_Ui_Window_UILoginChannelInner.lua.txt:142-143:
//   Ui.SceneCameraController.ClearTarget()
//   Ui.SceneCameraController.SetGray(false)
// Plus Ui.lua:1699 Ui.SceneCameraController.SetSize(nCameraSize)
//
// Methods ported 1-1 from IL2CPP (Ghidra ARM64 decompile):
//   ClearTarget — sets _Instance.target_field to null (per VMA structure)
//   SetGray(bool) — empty no-op (gốc body literally `return;`)
//   SetSize(float) — adjusts camera orthographic size (Ghidra body has cmp + branches)
//
// DEVIATION: gốc holds singleton _Instance via DAT_035642c8 lazy-init pattern. thanmaorigin
// uses standard FindObjectOfType / null-safe lookup. Behavior matches gốc when no Camera in
// scene (no-op). Original side-effects (target tracking) deferred until camera-tracking
// gameplay flows port.

using UnityEngine;

namespace Game.RepresentLogic
{
    public class SceneCameraController : MonoBehaviour
    {
        // gốc: SceneCameraController._Instance singleton via static DAT_035642c8.
        // We use FindObjectOfType for now (DEVIATION: easier without static init wiring).
        private static SceneCameraController _Instance;
        private Transform _target;        // gốc field used by ClearTarget
        private float _cameraSize = 5f;   // gốc field used by SetSize

        private void Awake()
        {
            if (_Instance != null && _Instance != this) { Destroy(this); return; }
            _Instance = this;
        }

        // VMA: Game_RepresentLogic_SceneCameraController__ClearTarget
        // gốc body: _Instance.target = null;
        public static void ClearTarget()
        {
            if (_Instance != null) _Instance._target = null;
        }

        // VMA: Game_RepresentLogic_SceneCameraController__SetGray
        // gốc body: empty `return;` no-op.
        public static void SetGray(bool bGray)
        {
            // gốc no-op. Visual-effect post-processing was likely conditionally compiled out.
        }

        // VMA: Game_RepresentLogic_SceneCameraController__SetSize(float)
        // gốc body: _Instance.cameraSize = param_1; if Camera ref present, apply.
        // Used by Ui.lua:1699 to set camera distance.
        public static void SetSize(float fSize)
        {
            if (_Instance == null) return;
            _Instance._cameraSize = fSize;
            var cam = _Instance.GetComponent<Camera>() ?? Camera.main;
            if (cam != null && cam.orthographic) cam.orthographicSize = fSize;
        }
    }
}
