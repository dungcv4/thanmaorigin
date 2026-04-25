// File: Assets/_Project/Scripts/Game/SceneLoadManager.cs
// Source: KTO_DecompiledReference/_root/SceneLoadManager.c (1-1 port pattern)
//
// Manages scene transitions + fires emNOTIFY_MAP_LOADED to gốc Lua EventNotify.
// Replicates gốc chain: SceneLoadManager.LoadMapAsync → EventNotify.OnNotify(28, mapCode)
// → Ui:OnMapLoaded → UpdateMainUi → Timer:Register → _UpdateMainUi → UpdateHomeScreenState
// → Ui:OpenWindow("UIHud") × 10.

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using ThanMaOrigin.Lua;

namespace ThanMaOrigin.Game
{
    public class SceneLoadManager : MonoBehaviour
    {
        public static SceneLoadManager Instance { get; private set; } = null!;

        public string CurrentMap { get; private set; } = "";
        public int CurrentMapCode { get; private set; }

        void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Load map asynchronously. Fires emNOTIFY_MAP_LOADED when done.
        /// Source: KTO_DecompiledReference/_root/SceneLoadManager.c (LoadMapAsync).
        /// </summary>
        public IEnumerator LoadMapAsync(string mapName, int mapCode)
        {
            Debug.Log($"[SceneLoadManager] LoadMapAsync: {mapName} (code={mapCode})");
            CurrentMap = mapName;
            CurrentMapCode = mapCode;

            // Try load Unity scene if exists; else just simulate map switch.
            if (!string.IsNullOrEmpty(mapName))
            {
                var scenePath = $"maps/{mapName}/{mapName}";
                var scene = SceneManager.GetSceneByName(mapName);
                if (!scene.isLoaded)
                {
                    var loadOp = SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Additive);
                    if (loadOp != null)
                    {
                        while (!loadOp.isDone) yield return null;
                    }
                    else
                    {
                        Debug.LogWarning($"[SceneLoadManager] Scene not in build: {scenePath} (skip)");
                    }
                }
            }

            // Wait one frame để scene init done.
            yield return null;

            // Fire gốc emNOTIFY_MAP_LOADED (= 28 in gốc Lua per session 2026-04-24 handoff).
            // Use FireByLuaEnumName to lookup Lua-side enum value at call time (avoids C# enum drift).
            Debug.Log($"[SceneLoadManager] Firing emNOTIFY_MAP_LOADED ({mapCode})");
            LuaEventBridge.FireByLuaEnumName("emNOTIFY_MAP_LOADED", mapCode);
        }

        /// <summary>Synchronous variant — fires event immediately without scene load.</summary>
        public void OnMapLoadedNow(int mapCode)
        {
            CurrentMapCode = mapCode;
            LuaEventBridge.FireByLuaEnumName("emNOTIFY_MAP_LOADED", mapCode);
        }
    }
}
