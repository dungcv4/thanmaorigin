// File: Assets/_Project/Scripts/Game/HudSpawner.cs
// HUD pre-spawn helper for Phase 6 — directly opens 10 HUD windows
// when Lua-side gốc Ui module is not loaded yet.
//
// Source: alo handoff 2026-04-24 — gốc chain spawns 10 HUDs:
//   UIHud, UIHudMinimap, UIHudRightBottom, UIHudRightSkill,
//   UIHudRightCenter, UIHudRightTopWelfare, UIHudLeftPanelTask,
//   UIHudChat, ... (8-10 total per session log "HudRoot children = 10")
//
// Phase 6 uses C# direct spawn for testability.
// Phase 7+ when full gốc Lua Ui module loaded, this can be removed
// (gốc chain Ui:UpdateHomeScreenState handles spawn).

using System.Collections.Generic;
using UnityEngine;

namespace ThanMaOrigin.Game
{
    public static class HudSpawner
    {
        // gốc HUD bundle map (per CLAUDE.md "Known HUD bundles" table):
        // res_p_91 → UIHud
        // res_p_92 → UIHudChat
        // res_p_98 → UIHudLeftPanelTask
        // res_p_100 → UIHudMinimap
        // res_p_102 → UIHudRightBottom
        // res_p_103 → UIHudRightCenter
        // res_p_104 → UIHudRightSkill
        // res_p_105 → UIHudRightTopWelfare
        public static readonly string[] HudWindows = new[]
        {
            "UIHud", "UIHudChat", "UIHudLeftPanelTask",
            "UIHudMinimap", "UIHudRightBottom", "UIHudRightCenter",
            "UIHudRightSkill", "UIHudRightTopWelfare",
        };

        public static GameObject? HudRoot { get; private set; }

        /// <summary>Spawn all 8-10 HUD windows under HudRoot canvas.</summary>
        public static void SpawnAll()
        {
            if (HudRoot == null)
            {
                HudRoot = new GameObject("[HudRoot]");
                var canvas = HudRoot.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.sortingOrder = 0;
                HudRoot.AddComponent<UnityEngine.UI.CanvasScaler>();
                HudRoot.AddComponent<UnityEngine.UI.GraphicRaycaster>();
                Object.DontDestroyOnLoad(HudRoot);
            }

            int spawned = 0;
            foreach (var name in HudWindows)
            {
                if (TrySpawnHud(name)) spawned++;
            }
            Debug.Log($"[HudSpawner] Spawned {spawned}/{HudWindows.Length} HUD windows under HudRoot");
        }

        private static bool TrySpawnHud(string uiName)
        {
            // Try Resources first.
            var prefab = Resources.Load<GameObject>($"UI/views/{uiName}");
            if (prefab == null)
            {
                Debug.LogWarning($"[HudSpawner] {uiName} prefab not in Resources/UI/views — skip (need bundle import for runtime, deferred Phase 7)");
                return false;
            }
            var go = Object.Instantiate(prefab, HudRoot!.transform, false);
            go.name = uiName;
            // UIView Awake will lookup Lua class binding automatically.
            return true;
        }

        public static void ClearAll()
        {
            if (HudRoot != null)
            {
                Object.Destroy(HudRoot);
                HudRoot = null;
            }
        }
    }
}
