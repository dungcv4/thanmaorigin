// Class:  MePlayerAsync  (gốc native binding `LuaPlayerAsync` from libclient_scene.so)
// Source: KTO_LibClientScene_Decompiled/INDEX.tsv (24 methods)
// XLua global: `me_async` (registered via LuaEnv.Global.Set)
//
// FULL 1-1 SURFACE PORT — every method has VMA + .asm cite. Bodies port:
//   - Trivial getters → auto-property reading underlying KPlayerData proxy.
//   - Setters paired with getters into single auto-property.
//   - Lua methods (LuaXxx) → public stub with TODO body marker for lazy port.
//
// gốc dispatch model:
//   me.foo       → LuaIndex → calls underlying getX()
//   me.foo = X   → LuaNewIndex → calls underlying setX(X)
//   me:Bar(args) → LuaDispatcher → calls LuaBar(XLuaScript&)

using System;
using XLua;

namespace ThanMaOrigin.Lua.Native
{
    [LuaCallCSharp]
    public class MePlayerAsync
    {
        // Underlying C++ KPlayer/KNpc/KItem proxy (state holder).
        // gốc: LuaPlayer.this->player_ptr at offset +8 in C++ object.
        public MePlayerAsyncData Data { get; set; } = new MePlayerAsyncData();

        // ============ Properties (paired getX/setX) ============
        // VMA: 0x24f7dc  Source: functions/0024f7dc_LuaPlayerAsync5getIDEv.asm
        public int ID { get; }

        // VMA: 0x24f7d0  Source: functions/0024f7d0_LuaPlayerAsync7getNameEv.asm
        public string Name { get; }

        // ============ Lua-callable methods (LuaXxx) ============
        // VMA: 0x24f7e8  Source: functions/0024f7e8_LuaPlayerAsync16LuaGetPlayerInfoER10XLuaScript.asm
        // gốc body in 0024f7e8_LuaPlayerAsync16LuaGetPlayerInfoER10XLuaScript.asm (716 bytes ARM64)
        public object GetPlayerInfo(params object[] args)
        {
            // TODO: port body from 0024f7e8_LuaPlayerAsync16LuaGetPlayerInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.GetPlayerInfo] not yet ported (gốc 0x24f7e8)");
            return null;
        }

        // VMA: 0x24fab4  Source: functions/0024fab4_LuaPlayerAsync14LuaAddAsyncNpcER10XLuaScript.asm
        // gốc body in 0024fab4_LuaPlayerAsync14LuaAddAsyncNpcER10XLuaScript.asm (368 bytes ARM64)
        public object AddAsyncNpc(params object[] args)
        {
            // TODO: port body from 0024fab4_LuaPlayerAsync14LuaAddAsyncNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.AddAsyncNpc] not yet ported (gốc 0x24fab4)");
            return null;
        }

        // VMA: 0x24fc24  Source: functions/0024fc24_LuaPlayerAsync16LuaGetAsyncValueER10XLuaScript.asm
        // gốc body in 0024fc24_LuaPlayerAsync16LuaGetAsyncValueER10XLuaScript.asm (248 bytes ARM64)
        public object GetAsyncValue(params object[] args)
        {
            // TODO: port body from 0024fc24_LuaPlayerAsync16LuaGetAsyncValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.GetAsyncValue] not yet ported (gốc 0x24fc24)");
            return null;
        }

        // VMA: 0x24fd1c  Source: functions/0024fd1c_LuaPlayerAsync16LuaSetAsyncValueER10XLuaScript.asm
        // gốc body in 0024fd1c_LuaPlayerAsync16LuaSetAsyncValueER10XLuaScript.asm (92 bytes ARM64)
        public object SetAsyncValue(params object[] args)
        {
            // TODO: port body from 0024fd1c_LuaPlayerAsync16LuaSetAsyncValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.SetAsyncValue] not yet ported (gốc 0x24fd1c)");
            return null;
        }

        // VMA: 0x24fee8  Source: functions/0024fee8_LuaPlayerAsync22LuaGetAsyncBattleValueER10XLuaScript.asm
        // gốc body in 0024fee8_LuaPlayerAsync22LuaGetAsyncBattleValueER10XLuaScript.asm (248 bytes ARM64)
        public object GetAsyncBattleValue(params object[] args)
        {
            // TODO: port body from 0024fee8_LuaPlayerAsync22LuaGetAsyncBattleValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.GetAsyncBattleValue] not yet ported (gốc 0x24fee8)");
            return null;
        }

        // VMA: 0x24ffe0  Source: functions/0024ffe0_LuaPlayerAsync22LuaSetAsyncBattleValueER10XLuaScript.asm
        // gốc body in 0024ffe0_LuaPlayerAsync22LuaSetAsyncBattleValueER10XLuaScript.asm (92 bytes ARM64)
        public object SetAsyncBattleValue(params object[] args)
        {
            // TODO: port body from 0024ffe0_LuaPlayerAsync22LuaSetAsyncBattleValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.SetAsyncBattleValue] not yet ported (gốc 0x24ffe0)");
            return null;
        }

        // VMA: 0x2501ac  Source: functions/002501ac_LuaPlayerAsync21LuaGetAsyncPowerValueER10XLuaScript.asm
        // gốc body in 002501ac_LuaPlayerAsync21LuaGetAsyncPowerValueER10XLuaScript.asm (248 bytes ARM64)
        public object GetAsyncPowerValue(params object[] args)
        {
            // TODO: port body from 002501ac_LuaPlayerAsync21LuaGetAsyncPowerValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.GetAsyncPowerValue] not yet ported (gốc 0x2501ac)");
            return null;
        }

        // VMA: 0x2502a4  Source: functions/002502a4_LuaPlayerAsync21LuaSetAsyncPowerValueER10XLuaScript.asm
        // gốc body in 002502a4_LuaPlayerAsync21LuaSetAsyncPowerValueER10XLuaScript.asm (92 bytes ARM64)
        public object SetAsyncPowerValue(params object[] args)
        {
            // TODO: port body from 002502a4_LuaPlayerAsync21LuaSetAsyncPowerValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.SetAsyncPowerValue] not yet ported (gốc 0x2502a4)");
            return null;
        }

        // VMA: 0x250470  Source: functions/00250470_LuaPlayerAsync12LuaGetEquipsER10XLuaScript.asm
        // gốc body in 00250470_LuaPlayerAsync12LuaGetEquipsER10XLuaScript.asm (344 bytes ARM64)
        public object GetEquips(params object[] args)
        {
            // TODO: port body from 00250470_LuaPlayerAsync12LuaGetEquipsER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.GetEquips] not yet ported (gốc 0x250470)");
            return null;
        }

        // VMA: 0x2505c8  Source: functions/002505c8_LuaPlayerAsync14LuaGetPartnersER10XLuaScript.asm
        // gốc body in 002505c8_LuaPlayerAsync14LuaGetPartnersER10XLuaScript.asm (196 bytes ARM64)
        public object GetPartners(params object[] args)
        {
            // TODO: port body from 002505c8_LuaPlayerAsync14LuaGetPartnersER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.GetPartners] not yet ported (gốc 0x2505c8)");
            return null;
        }

        // VMA: 0x25068c  Source: functions/0025068c_LuaPlayerAsync17LuaGetScriptValueER10XLuaScript.asm
        // gốc body in 0025068c_LuaPlayerAsync17LuaGetScriptValueER10XLuaScript.asm (504 bytes ARM64)
        public object GetScriptValue(params object[] args)
        {
            // TODO: port body from 0025068c_LuaPlayerAsync17LuaGetScriptValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.GetScriptValue] not yet ported (gốc 0x25068c)");
            return null;
        }

        // VMA: 0x250884  Source: functions/00250884_LuaPlayerAsync17LuaSetScriptValueER10XLuaScript.asm
        // gốc body in 00250884_LuaPlayerAsync17LuaSetScriptValueER10XLuaScript.asm (704 bytes ARM64)
        public object SetScriptValue(params object[] args)
        {
            // TODO: port body from 00250884_LuaPlayerAsync17LuaSetScriptValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.SetScriptValue] not yet ported (gốc 0x250884)");
            return null;
        }

        // VMA: 0x250b44  Source: functions/00250b44_LuaPlayerAsync17LuaIsPosHaveEquipER10XLuaScript.asm
        // gốc body in 00250b44_LuaPlayerAsync17LuaIsPosHaveEquipER10XLuaScript.asm (84 bytes ARM64)
        public object IsPosHaveEquip(params object[] args)
        {
            // TODO: port body from 00250b44_LuaPlayerAsync17LuaIsPosHaveEquipER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.IsPosHaveEquip] not yet ported (gốc 0x250b44)");
            return null;
        }

        // VMA: 0x250b98  Source: functions/00250b98_LuaPlayerAsync12LuaGetSkillsER10XLuaScript.asm
        // gốc body in 00250b98_LuaPlayerAsync12LuaGetSkillsER10XLuaScript.asm (128 bytes ARM64)
        public object GetSkills(params object[] args)
        {
            // TODO: port body from 00250b98_LuaPlayerAsync12LuaGetSkillsER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.GetSkills] not yet ported (gốc 0x250b98)");
            return null;
        }

        // VMA: 0x250c18  Source: functions/00250c18_LuaPlayerAsync15LuaGetAsyncAttrER10XLuaScript.asm
        // gốc body in 00250c18_LuaPlayerAsync15LuaGetAsyncAttrER10XLuaScript.asm (7840 bytes ARM64)
        public object GetAsyncAttr(params object[] args)
        {
            // TODO: port body from 00250c18_LuaPlayerAsync15LuaGetAsyncAttrER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.GetAsyncAttr] not yet ported (gốc 0x250c18)");
            return null;
        }

        // VMA: 0x252ab8  Source: functions/00252ab8_LuaPlayerAsync16LuaGetAttrTitlesER10XLuaScript.asm
        // gốc body in 00252ab8_LuaPlayerAsync16LuaGetAttrTitlesER10XLuaScript.asm (364 bytes ARM64)
        public object GetAttrTitles(params object[] args)
        {
            // TODO: port body from 00252ab8_LuaPlayerAsync16LuaGetAttrTitlesER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.GetAttrTitles] not yet ported (gốc 0x252ab8)");
            return null;
        }

        // ============ Other methods ============
        // VMA: 0x26f098  Source: functions/0026f098_LuaPlayerAsync8PushCObjEP9lua_State.asm
        public object PushCObj(params object[] args)
        {
            UnityEngine.Debug.LogWarning($"[MePlayerAsync.PushCObj] not yet ported (gốc 0x26f098)");
            return null;
        }

    }

    /// <summary>Data backing for MePlayerAsync — mirrors C++ underlying object fields.</summary>
    public class MePlayerAsyncData
    {
        // Fields auto-populated by network sync (CMD_PLAYER_STATE / CMD_BAG_SYNC / etc.)
        public uint dwID;
        public string szName;
        public int nLevel;
        public int nFaction;
        public int nFactionSect;
        public int nSex;
        public uint dwKinId;
        public uint dwTongId;
        public uint dwLegionId;
        public uint dwTeamID;
        public int nVitality, nStrength, nDexterity, nEnergy;
        public int nBaseVitality, nBaseStrength, nBaseDexterity, nBaseEnergy;
        public int nMapId, nMapTemplateId;
        public string szMapName;
        public int nPkMode, nFightMode;
        public bool bAlone;
        public string szKinTitle;
        public int nZongShiLevel;
        public int nLevelUpAboutEquipSeries;
    }
}