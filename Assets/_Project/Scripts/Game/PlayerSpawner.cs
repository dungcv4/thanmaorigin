// File: Assets/_Project/Scripts/Game/PlayerSpawner.cs
// Source: KTO_DecompiledReference (gốc spawns Player on CMD_PLAYER_STATE 200).
//
// Receives CMD 200 packet → parse player data → instantiate player prefab at spawn location.
// Phase 6 minimal — full attribute parsing deferred Phase 7.

using System;
using System.Collections.Generic;
using UnityEngine;
using ThanMaOrigin.Network;
using ThanMaOrigin.Lua;

namespace ThanMaOrigin.Game
{
    public class PlayerSpawner : MonoBehaviour
    {
        public static PlayerSpawner Instance { get; private set; } = null!;

        public GameObject? PlayerInstance { get; private set; }
        public PlayerState State = new PlayerState();

        public class PlayerState
        {
            public long RoleId;
            public string Name = "";
            public int Faction;
            public int Level = 1;
            public int Hp = 100, MaxHp = 100;
            public int Mp = 100, MaxMp = 100;
            public long Exp;
            public Vector3 Position;
            public int MapCode;
        }

        void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Subscribe to CMD 200 PlayerState packet.
            CmdRegistry.RegisterCSharpHandler(200, OnPlayerStatePacket);
        }

        private void OnPlayerStatePacket(byte[] payload)
        {
            // gốc binary format: parse via NetReader (deferred Phase 7 — wire-format spec).
            // Phase 6 minimal: trigger spawn with default state if not yet spawned.
            Debug.Log($"[PlayerSpawner] CMD 200 PlayerState received ({payload.Length} bytes)");
            if (PlayerInstance == null)
            {
                Spawn();
            }
        }

        public void Spawn()
        {
            if (PlayerInstance != null) return;

            // Try load player prefab from Resources.
            // gốc path convention: "Player/Player_<faction>".
            var prefabPath = $"Player/Player_{State.Faction}";
            var prefab = Resources.Load<GameObject>(prefabPath);
            if (prefab == null)
            {
                Debug.LogWarning($"[PlayerSpawner] Prefab not found: Resources/{prefabPath} — using empty GameObject for now.");
                PlayerInstance = new GameObject($"Player_{State.RoleId}");
            }
            else
            {
                PlayerInstance = Instantiate(prefab);
                PlayerInstance.name = $"Player_{State.RoleId}";
            }
            PlayerInstance.transform.position = State.Position;
            DontDestroyOnLoad(PlayerInstance);

            Debug.Log($"[PlayerSpawner] Spawned at {State.Position}, faction={State.Faction}, lvl={State.Level}");

            // Notify Lua side via EventNotify.
            LuaEventBridge.FireByLuaEnumName("emNOTIFY_PLAYER_SPAWN", State.RoleId);
        }

        public void Despawn()
        {
            if (PlayerInstance != null)
            {
                Destroy(PlayerInstance);
                PlayerInstance = null;
            }
        }
    }
}
