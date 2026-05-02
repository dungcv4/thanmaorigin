// File: Assets/_Project/Scripts/Network/PlayerSyncHandler.cs
//
// DEVIATION — bridge layer, NOT a gốc 1-1 IL2CPP class.
// Reason: gốc client dispatches CMD packets via libclient_scene.so native
//         binding `_ZN24LuaGlobalScriptNameSpace*` chain (XLuaScript C-funcs
//         registered via lua_register), with parse/cache/event-fire all in
//         Lua-side `Player.lua` / `Bag.lua` / `Equip.lua` / `UserValue.lua`.
//         thanmaorigin uses managed C# (no libclient_scene.so on Mac), so
//         we wire C# handlers via CmdRegistry. Data exposed to Lua via
//         CS.ThanMaOrigin.Network.PlayerSyncHandler.Instance.
// Approved by user: PENDING — match plan doc ENTER_GAME_TO_MAINUI_PLAN.md
//         (which expected PlayerDataSyncHandler to register CMDs 200/204/...).
// Original closest match: gốc `KPlayer:OnSyncPlayerState` (Lua) +
//         libclient_scene.so `KPlayerScriptNameSpace::LuaSyncPlayerData*`
//         (functions/0028823c..00289794 .asm).
// Original body would have done: parse colon-text → set KPlayer fields →
//         fire `emNOTIFY_PLAYER_STATE` event → Lua HUD listeners repaint.
// Future-fix: when libclient_scene.so binding port done, deprecate this
//         class and route CMD 200/204/206/210/220 to Lua via CmdRegistry's
//         `_handlers` (Lua) dict instead of `_csHandlers` (C#).
//
// Wire format MIRROR — server side at GameServer_NET8/.../PlayerSync/PlayerSyncEmitter.cs
// (BuildPlayerState/BuildBagSync/BuildEquipSync/BuildUserValueSync). The
// colon-text wire is itself a DEVIATION from gốc protobuf — server-side
// note in PlayerSyncEmitter.cs:1-13.
//
// PORT 2026-05-02: previously only PlayerDataSyncHandler.cs.meta stub existed.

using System.Collections.Generic;
using UnityEngine;

namespace ThanMaOrigin.Network
{
    public class PlayerSyncHandler : MonoBehaviour
    {
        public static PlayerSyncHandler Instance { get; private set; }

        // ── CMD 200 PLAYER_STATE cache ─────────────────────────────
        public class PlayerState
        {
            public int level, hp, mp, freePoints, str, agi, con, dex, posX, posY, mapCode, factionId, sex, fightPower;
            public long exp, gold, yuanBao, coin, jingHuo;
        }
        public PlayerState State = new PlayerState();
        public bool HasPlayerState { get; private set; }

        // ── CMD 204 BAG_SYNC + 210 BOX_SYNC items ──────────────────
        public class BagItem
        {
            public int slot, tmplId, amount, level, bind;
            public long dwId, expiry;
            public string attribsCsv = "";
        }
        public List<BagItem> Bag = new List<BagItem>();
        public List<BagItem> Box = new List<BagItem>();

        // ── CMD 206 EQUIP_SYNC slots ───────────────────────────────
        public class EquipSlot
        {
            public int equipPos, tmplId, level, gem1, gem2;
            public long dwId;
            public string attribsCsv = "";
        }
        public List<EquipSlot> Equip = new List<EquipSlot>();

        // ── CMD 220 USER_VALUE_SYNC store ──────────────────────────
        // groupId → slot → value
        public Dictionary<int, Dictionary<int, long>> UserValues = new Dictionary<int, Dictionary<int, long>>();
        public Dictionary<int, string> UserValueGroupNames = new Dictionary<int, string>();

        void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            CmdRegistry.RegisterCSharpHandler(200, OnPlayerState);
            CmdRegistry.RegisterCSharpHandler(204, OnBagSync);
            CmdRegistry.RegisterCSharpHandler(206, OnEquipSync);
            CmdRegistry.RegisterCSharpHandler(210, OnBoxSync);
            CmdRegistry.RegisterCSharpHandler(220, OnUserValueSync);

            UnityEngine.Debug.Log("[PlayerSyncHandler] Registered CMD 200/204/206/210/220 handlers.");
        }

        // ── CMD 200 ────────────────────────────────────────────────
        // Format (BuildPlayerState — 19 fields colon-delim):
        //   level:exp:hp:mp:gold:yuanBao:coin:jingHuo:freePoints:str:agi:con:dex:posX:posY:mapCode:factionId:sex:fightPower
        void OnPlayerState(byte[] payload)
        {
            string s = payload != null ? System.Text.Encoding.UTF8.GetString(payload) : "";
            var f = s.Split(':');
            if (f.Length < 19)
            {
                UnityEngine.Debug.LogError($"[PlayerSyncHandler] CMD_PLAYER_STATE bad payload (fields={f.Length}): '{s}'");
                return;
            }
            int i = 0;
            int.TryParse(f[i++], out State.level);
            long.TryParse(f[i++], out State.exp);
            int.TryParse(f[i++], out State.hp);
            int.TryParse(f[i++], out State.mp);
            long.TryParse(f[i++], out State.gold);
            long.TryParse(f[i++], out State.yuanBao);
            long.TryParse(f[i++], out State.coin);
            long.TryParse(f[i++], out State.jingHuo);
            int.TryParse(f[i++], out State.freePoints);
            int.TryParse(f[i++], out State.str);
            int.TryParse(f[i++], out State.agi);
            int.TryParse(f[i++], out State.con);
            int.TryParse(f[i++], out State.dex);
            int.TryParse(f[i++], out State.posX);
            int.TryParse(f[i++], out State.posY);
            int.TryParse(f[i++], out State.mapCode);
            int.TryParse(f[i++], out State.factionId);
            int.TryParse(f[i++], out State.sex);
            int.TryParse(f[i++], out State.fightPower);
            HasPlayerState = true;
            UnityEngine.Debug.Log($"[PlayerSyncHandler] CMD 200 PLAYER_STATE: lv={State.level} hp={State.hp}/{State.mp} faction={State.factionId} fp={State.fightPower}");
        }

        // ── CMD 204 BAG_SYNC ───────────────────────────────────────
        // Format: numItems[:slot:dwId:tmplId:amount:lvl:bind:expiry:attribsCsv]*
        void OnBagSync(byte[] payload)
        {
            ParseBagOrBox(payload, Bag, "BAG_SYNC");
        }

        // ── CMD 210 BOX_SYNC ───────────────────────────────────────
        void OnBoxSync(byte[] payload)
        {
            ParseBagOrBox(payload, Box, "BOX_SYNC");
        }

        void ParseBagOrBox(byte[] payload, List<BagItem> dest, string tag)
        {
            string s = payload != null ? System.Text.Encoding.UTF8.GetString(payload) : "";
            var f = s.Split(':');
            if (f.Length < 1) { UnityEngine.Debug.LogError($"[PlayerSyncHandler] CMD {tag} empty"); return; }
            int.TryParse(f[0], out int n);
            dest.Clear();
            const int FIELDS_PER = 8;
            int expected = 1 + n * FIELDS_PER;
            if (f.Length < expected)
            {
                UnityEngine.Debug.LogError($"[PlayerSyncHandler] CMD {tag} truncated: numItems={n} expected={expected} got={f.Length}");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                int b = 1 + i * FIELDS_PER;
                var it = new BagItem();
                int.TryParse(f[b + 0], out it.slot);
                long.TryParse(f[b + 1], out it.dwId);
                int.TryParse(f[b + 2], out it.tmplId);
                int.TryParse(f[b + 3], out it.amount);
                int.TryParse(f[b + 4], out it.level);
                int.TryParse(f[b + 5], out it.bind);
                long.TryParse(f[b + 6], out it.expiry);
                it.attribsCsv = f[b + 7] ?? "";
                dest.Add(it);
            }
            UnityEngine.Debug.Log($"[PlayerSyncHandler] CMD {tag}: {n} items");
        }

        // ── CMD 206 EQUIP_SYNC ─────────────────────────────────────
        // Format: numSlots[:equipPos:dwId:tmplId:level:gem1:gem2:attribsCsv]*
        void OnEquipSync(byte[] payload)
        {
            string s = payload != null ? System.Text.Encoding.UTF8.GetString(payload) : "";
            var f = s.Split(':');
            if (f.Length < 1) { UnityEngine.Debug.LogError("[PlayerSyncHandler] CMD EQUIP_SYNC empty"); return; }
            int.TryParse(f[0], out int n);
            Equip.Clear();
            const int FIELDS_PER = 7;
            int expected = 1 + n * FIELDS_PER;
            if (f.Length < expected)
            {
                UnityEngine.Debug.LogError($"[PlayerSyncHandler] CMD EQUIP_SYNC truncated: numSlots={n} expected={expected} got={f.Length}");
                return;
            }
            for (int i = 0; i < n; i++)
            {
                int b = 1 + i * FIELDS_PER;
                var e = new EquipSlot();
                int.TryParse(f[b + 0], out e.equipPos);
                long.TryParse(f[b + 1], out e.dwId);
                int.TryParse(f[b + 2], out e.tmplId);
                int.TryParse(f[b + 3], out e.level);
                int.TryParse(f[b + 4], out e.gem1);
                int.TryParse(f[b + 5], out e.gem2);
                e.attribsCsv = f[b + 6] ?? "";
                Equip.Add(e);
            }
            UnityEngine.Debug.Log($"[PlayerSyncHandler] CMD 206 EQUIP_SYNC: {n} slots");
        }

        // ── CMD 220 USER_VALUE_SYNC ────────────────────────────────
        // Format: numGroups[:groupId:groupName:numSlots[:slot:value]*]*
        void OnUserValueSync(byte[] payload)
        {
            string s = payload != null ? System.Text.Encoding.UTF8.GetString(payload) : "";
            var f = s.Split(':');
            if (f.Length < 1) { UnityEngine.Debug.LogError("[PlayerSyncHandler] CMD USER_VALUE_SYNC empty"); return; }
            int.TryParse(f[0], out int numGroups);
            UserValues.Clear();
            UserValueGroupNames.Clear();
            int idx = 1;
            for (int g = 0; g < numGroups && idx + 2 < f.Length; g++)
            {
                int.TryParse(f[idx++], out int groupId);
                string groupName = f[idx++];
                int.TryParse(f[idx++], out int numSlots);
                var slots = new Dictionary<int, long>();
                for (int sl = 0; sl < numSlots && idx + 1 < f.Length; sl++)
                {
                    int.TryParse(f[idx++], out int slot);
                    long.TryParse(f[idx++], out long value);
                    slots[slot] = value;
                }
                UserValues[groupId] = slots;
                UserValueGroupNames[groupId] = groupName;
            }
            UnityEngine.Debug.Log($"[PlayerSyncHandler] CMD 220 USER_VALUE_SYNC: {numGroups} groups");
        }
    }
}
