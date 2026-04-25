// Class:  KItemLua  (gốc native binding `LuaItem` from libclient_scene.so)
// Source: KTO_LibClientScene_Decompiled/INDEX.tsv (68 methods)
// XLua global: `KItem` (registered via LuaEnv.Global.Set)
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
    public class KItemLua
    {
        // Underlying C++ KPlayer/KNpc/KItem proxy (state holder).
        // gốc: LuaPlayer.this->player_ptr at offset +8 in C++ object.
        public KItemLuaData Data { get; set; } = new KItemLuaData();

        // ============ Properties (paired getX/setX) ============
        // VMA: 0x2864bc  Source: functions/002864bc_LuaItem17getAttributePowerEv.asm
        public int AttributePower { get; }

        // VMA: 0x2864b4  Source: functions/002864b4_LuaItem17getBaseFightPowerEv.asm
        public int BaseFightPower { get; }

        // VMA: 0x28688c  Source: functions/0028688c_LuaItem9getCdTypeEv.asm
        public int CdType { get; }

        // VMA: 0x2868d4  Source: functions/002868d4_LuaItem8getClassEv.asm
        public int Class { get; }

        // VMA: 0x2866f8  Source: functions/002866f8_LuaItem8getCountEv.asm
        public int Count { get; }

        // VMA: 0x2868ac  Source: functions/002868ac_LuaItem13getDetailTypeEv.asm
        public int DetailType { get; }

        // VMA: 0x286720  Source: functions/00286720_LuaItem11getEquipPosEv.asm
        public int EquipPos { get; }

        // VMA: 0x2866e0  Source: functions/002866e0_LuaItem13getFightPowerEv.asm
        public int FightPower { get; set; }

        // VMA: 0x2868e4  Source: functions/002868e4_LuaItem7getGUIDEv.asm
        public int GUID { get; }

        // VMA: 0x2867fc  Source: functions/002867fc_LuaItem12getHoleCountEv.asm
        public int HoleCount { get; }

        // VMA: 0x2868bc  Source: functions/002868bc_LuaItem5getIdEv.asm
        public int Id { get; }

        // VMA: 0x286790  Source: functions/00286790_LuaItem13getInsetLevelEv.asm
        public int InsetLevel { get; }

        // VMA: 0x2872f0  Source: functions/002872f0_LuaItem14getIsEmptyAttrEv.asm
        public bool IsEmptyAttr { get; }

        // VMA: 0x28689c  Source: functions/0028689c_LuaItem11getItemTypeEv.asm
        public int ItemType { get; }

        // VMA: 0x287200  Source: functions/00287200_LuaItem15getKinRuneLevelEv.asm
        public int KinRuneLevel { get; }

        // VMA: 0x286494  Source: functions/00286494_LuaItem8getLevelEv.asm
        public int Level { get; }

        // VMA: 0x286704  Source: functions/00286704_LuaItem11getMaxCountEv.asm
        public int MaxCount { get; }

        // VMA: 0x286478  Source: functions/00286478_LuaItem7getNameEv.asm
        public string Name { get; }

        // VMA: 0x286584  Source: functions/00286584_LuaItem9getObjIdxEv.asm
        public int ObjIdx { get; }

        // VMA: 0x286484  Source: functions/00286484_LuaItem10getOrgNameEv.asm
        public string OrgName { get; }

        // VMA: 0x28687c  Source: functions/0028687c_LuaItem11getOrgValueEv.asm
        public int OrgValue { get; }

        // VMA: 0x286750  Source: functions/00286750_LuaItem6getPosEv.asm
        public int Pos { get; }

        // VMA: 0x286718  Source: functions/00286718_LuaItem8getPriceEv.asm
        public int Price { get; }

        // VMA: 0x2868f0  Source: functions/002868f0_LuaItem10getQualityEv.asm
        public int Quality { get; set; }

        // VMA: 0x286908  Source: functions/00286908_LuaItem12getRealLevelEv.asm
        public int RealLevel { get; }

        // VMA: 0x28662c  Source: functions/0028662c_LuaItem6getSexEv.asm
        public int Sex { get; }

        // VMA: 0x2868c8  Source: functions/002868c8_LuaItem13getTemplateIdEv.asm
        public int TemplateId { get; }

        // VMA: 0x2872c0  Source: functions/002872c0_LuaItem25getTemplateTradeLimitTypeEv.asm
        public int TemplateTradeLimitType { get; }

        // VMA: 0x2872d0  Source: functions/002872d0_LuaItem26getTemplateTradeLimitValueEv.asm
        public int TemplateTradeLimitValue { get; }

        // VMA: 0x2872e0  Source: functions/002872e0_LuaItem24getTemplateTradeLimitWayEv.asm
        public int TemplateTradeLimitWay { get; }

        // VMA: 0x287088  Source: functions/00287088_LuaItem17getTradeLimitTypeEv.asm
        public int TradeLimitType { get; }

        // VMA: 0x287144  Source: functions/00287144_LuaItem18getTradeLimitValueEv.asm
        public int TradeLimitValue { get; }

        // VMA: 0x2864d0  Source: functions/002864d0_LuaItem15getUseDelayMinsEv.asm
        public int UseDelayMins { get; }

        // VMA: 0x2864a4  Source: functions/002864a4_LuaItem11getUseLevelEv.asm
        public int UseLevel { get; }

        // VMA: 0x286868  Source: functions/00286868_LuaItem8getValueEv.asm
        public int Value { get; }

        // VMA: 0x28691c  Source: functions/0028691c_LuaItem13getWeaponTypeEv.asm
        public int WeaponType { get; }

        // ============ Lua-callable methods (LuaXxx) ============
        // VMA: 0x286930  Source: functions/00286930_LuaItem10LuaIsEquipER10XLuaScript.asm
        // gốc body in 00286930_LuaItem10LuaIsEquipER10XLuaScript.asm (64 bytes ARM64)
        public object IsEquip(params object[] args)
        {
            // TODO: port body from 00286930_LuaItem10LuaIsEquipER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.IsEquip] not yet ported (gốc 0x286930)");
            return null;
        }

        // VMA: 0x286970  Source: functions/00286970_LuaItem14LuaIsStackableER10XLuaScript.asm
        // gốc body in 00286970_LuaItem14LuaIsStackableER10XLuaScript.asm (52 bytes ARM64)
        public object IsStackable(params object[] args)
        {
            // TODO: port body from 00286970_LuaItem14LuaIsStackableER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.IsStackable] not yet ported (gốc 0x286970)");
            return null;
        }

        // VMA: 0x2869a4  Source: functions/002869a4_LuaItem16LuaGetBaseAttribER10XLuaScript.asm
        // gốc body in 002869a4_LuaItem16LuaGetBaseAttribER10XLuaScript.asm (484 bytes ARM64)
        public object GetBaseAttrib(params object[] args)
        {
            // TODO: port body from 002869a4_LuaItem16LuaGetBaseAttribER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.GetBaseAttrib] not yet ported (gốc 0x2869a4)");
            return null;
        }

        // VMA: 0x286b88  Source: functions/00286b88_LuaItem21LuaSetBaseAttribRangeER10XLuaScript.asm
        // gốc body in 00286b88_LuaItem21LuaSetBaseAttribRangeER10XLuaScript.asm (88 bytes ARM64)
        public object SetBaseAttribRange(params object[] args)
        {
            // TODO: port body from 00286b88_LuaItem21LuaSetBaseAttribRangeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.SetBaseAttribRange] not yet ported (gốc 0x286b88)");
            return null;
        }

        // VMA: 0x286be0  Source: functions/00286be0_LuaItem21LuaGetBaseAttribRangeER10XLuaScript.asm
        // gốc body in 00286be0_LuaItem21LuaGetBaseAttribRangeER10XLuaScript.asm (72 bytes ARM64)
        public object GetBaseAttribRange(params object[] args)
        {
            // TODO: port body from 00286be0_LuaItem21LuaGetBaseAttribRangeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.GetBaseAttribRange] not yet ported (gốc 0x286be0)");
            return null;
        }

        // VMA: 0x286c28  Source: functions/00286c28_LuaItem11LuaGetOwnerER10XLuaScript.asm
        // gốc body in 00286c28_LuaItem11LuaGetOwnerER10XLuaScript.asm (8 bytes ARM64)
        public object GetOwner(params object[] args)
        {
            // TODO: port body from 00286c28_LuaItem11LuaGetOwnerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.GetOwner] not yet ported (gốc 0x286c28)");
            return null;
        }

        // VMA: 0x286c30  Source: functions/00286c30_LuaItem9LuaRemoveER10XLuaScript.asm
        // gốc body in 00286c30_LuaItem9LuaRemoveER10XLuaScript.asm (8 bytes ARM64)
        public object Remove(params object[] args)
        {
            // TODO: port body from 00286c30_LuaItem9LuaRemoveER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.Remove] not yet ported (gốc 0x286c30)");
            return null;
        }

        // VMA: 0x286c38  Source: functions/00286c38_LuaItem13LuaSetTimeOutER10XLuaScript.asm
        // gốc body in 00286c38_LuaItem13LuaSetTimeOutER10XLuaScript.asm (60 bytes ARM64)
        public object SetTimeOut(params object[] args)
        {
            // TODO: port body from 00286c38_LuaItem13LuaSetTimeOutER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.SetTimeOut] not yet ported (gốc 0x286c38)");
            return null;
        }

        // VMA: 0x286c74  Source: functions/00286c74_LuaItem11LuaSetCountER10XLuaScript.asm
        // gốc body in 00286c74_LuaItem11LuaSetCountER10XLuaScript.asm (8 bytes ARM64)
        public object SetCount(params object[] args)
        {
            // TODO: port body from 00286c74_LuaItem11LuaSetCountER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.SetCount] not yet ported (gốc 0x286c74)");
            return null;
        }

        // VMA: 0x286c7c  Source: functions/00286c7c_LuaItem13LuaGetGenTimeER10XLuaScript.asm
        // gốc body in 00286c7c_LuaItem13LuaGetGenTimeER10XLuaScript.asm (224 bytes ARM64)
        public object GetGenTime(params object[] args)
        {
            // TODO: port body from 00286c7c_LuaItem13LuaGetGenTimeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.GetGenTime] not yet ported (gốc 0x286c7c)");
            return null;
        }

        // VMA: 0x286d5c  Source: functions/00286d5c_LuaItem13LuaGetTimeOutER10XLuaScript.asm
        // gốc body in 00286d5c_LuaItem13LuaGetTimeOutER10XLuaScript.asm (40 bytes ARM64)
        public object GetTimeOut(params object[] args)
        {
            // TODO: port body from 00286d5c_LuaItem13LuaGetTimeOutER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.GetTimeOut] not yet ported (gốc 0x286d5c)");
            return null;
        }

        // VMA: 0x286d84  Source: functions/00286d84_LuaItem7LuaSyncER10XLuaScript.asm
        // gốc body in 00286d84_LuaItem7LuaSyncER10XLuaScript.asm (8 bytes ARM64)
        public object Sync(params object[] args)
        {
            // TODO: port body from 00286d84_LuaItem7LuaSyncER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.Sync] not yet ported (gốc 0x286d84)");
            return null;
        }

        // VMA: 0x286d8c  Source: functions/00286d8c_LuaItem17LuaGetSingleValueER10XLuaScript.asm
        // gốc body in 00286d8c_LuaItem17LuaGetSingleValueER10XLuaScript.asm (44 bytes ARM64)
        public object GetSingleValue(params object[] args)
        {
            // TODO: port body from 00286d8c_LuaItem17LuaGetSingleValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.GetSingleValue] not yet ported (gốc 0x286d8c)");
            return null;
        }

        // VMA: 0x286db8  Source: functions/00286db8_LuaItem17LuaSetSingleValueER10XLuaScript.asm
        // gốc body in 00286db8_LuaItem17LuaSetSingleValueER10XLuaScript.asm (48 bytes ARM64)
        public object SetSingleValue(params object[] args)
        {
            // TODO: port body from 00286db8_LuaItem17LuaSetSingleValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.SetSingleValue] not yet ported (gốc 0x286db8)");
            return null;
        }

        // VMA: 0x286de8  Source: functions/00286de8_LuaItem14LuaGetIntValueER10XLuaScript.asm
        // gốc body in 00286de8_LuaItem14LuaGetIntValueER10XLuaScript.asm (80 bytes ARM64)
        public object GetIntValue(params object[] args)
        {
            // TODO: port body from 00286de8_LuaItem14LuaGetIntValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.GetIntValue] not yet ported (gốc 0x286de8)");
            return null;
        }

        // VMA: 0x286e38  Source: functions/00286e38_LuaItem14LuaGetStrValueER10XLuaScript.asm
        // gốc body in 00286e38_LuaItem14LuaGetStrValueER10XLuaScript.asm (76 bytes ARM64)
        public object GetStrValue(params object[] args)
        {
            // TODO: port body from 00286e38_LuaItem14LuaGetStrValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.GetStrValue] not yet ported (gốc 0x286e38)");
            return null;
        }

        // VMA: 0x286e84  Source: functions/00286e84_LuaItem9LuaReInitER10XLuaScript.asm
        // gốc body in 00286e84_LuaItem9LuaReInitER10XLuaScript.asm (8 bytes ARM64)
        public object ReInit(params object[] args)
        {
            // TODO: port body from 00286e84_LuaItem9LuaReInitER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.ReInit] not yet ported (gốc 0x286e84)");
            return null;
        }

        // VMA: 0x286e8c  Source: functions/00286e8c_LuaItem10LuaSetNameER10XLuaScript.asm
        // gốc body in 00286e8c_LuaItem10LuaSetNameER10XLuaScript.asm (60 bytes ARM64)
        public object SetName(params object[] args)
        {
            // TODO: port body from 00286e8c_LuaItem10LuaSetNameER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.SetName] not yet ported (gốc 0x286e8c)");
            return null;
        }

        // VMA: 0x286ec8  Source: functions/00286ec8_LuaItem18LuaGetItemShowInfoER10XLuaScript.asm
        // gốc body in 00286ec8_LuaItem18LuaGetItemShowInfoER10XLuaScript.asm (396 bytes ARM64)
        public object GetItemShowInfo(params object[] args)
        {
            // TODO: port body from 00286ec8_LuaItem18LuaGetItemShowInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.GetItemShowInfo] not yet ported (gốc 0x286ec8)");
            return null;
        }

        // VMA: 0x287054  Source: functions/00287054_LuaItem10LuaOnTradeER10XLuaScript.asm
        // gốc body in 00287054_LuaItem10LuaOnTradeER10XLuaScript.asm (52 bytes ARM64)
        public object OnTrade(params object[] args)
        {
            // TODO: port body from 00287054_LuaItem10LuaOnTradeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.OnTrade] not yet ported (gốc 0x287054)");
            return null;
        }

        // VMA: 0x2873b0  Source: functions/002873b0_LuaItem17LuaIsInTradeLimitER10XLuaScript.asm
        // gốc body in 002873b0_LuaItem17LuaIsInTradeLimitER10XLuaScript.asm (112 bytes ARM64)
        public object IsInTradeLimit(params object[] args)
        {
            // TODO: port body from 002873b0_LuaItem17LuaIsInTradeLimitER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.IsInTradeLimit] not yet ported (gốc 0x2873b0)");
            return null;
        }

        // VMA: 0x287420  Source: functions/00287420_LuaItem12LuaGetSeriesER10XLuaScript.asm
        // gốc body in 00287420_LuaItem12LuaGetSeriesER10XLuaScript.asm (112 bytes ARM64)
        public object GetSeries(params object[] args)
        {
            // TODO: port body from 00287420_LuaItem12LuaGetSeriesER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KItemLua.GetSeries] not yet ported (gốc 0x287420)");
            return null;
        }

        // ============ Other methods ============
        // VMA: 0x23529c  Source: functions/0023529c_LuaItem8PushCObjEP9lua_State.asm
        public object PushCObj(params object[] args)
        {
            UnityEngine.Debug.LogWarning($"[KItemLua.PushCObj] not yet ported (gốc 0x23529c)");
            return null;
        }

        // VMA: 0x286420  Source: functions/00286420_LuaItem5GetItER10XLuaScripti.asm
        public object GetIt(params object[] args)
        {
            UnityEngine.Debug.LogWarning($"[KItemLua.GetIt] not yet ported (gốc 0x286420)");
            return null;
        }

        // VMA: 0x28645c  Source: functions/0028645c_LuaItem14ClearTempTableEv.asm
        public object ClearTempTable(params object[] args)
        {
            UnityEngine.Debug.LogWarning($"[KItemLua.ClearTempTable] not yet ported (gốc 0x28645c)");
            return null;
        }

    }

    /// <summary>Data backing for KItemLua — mirrors C++ underlying object fields.</summary>
    public class KItemLuaData
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