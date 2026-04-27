#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class ThanMaOriginLuaNativeMePlayerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(ThanMaOrigin.Lua.Native.MePlayer);
			Utils.BeginObjectRegister(type, L, translator, 0, 94, 145, 14);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetScriptTable", _m_GetScriptTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SaveScriptTable", _m_SaveScriptTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSaveScriptVersion", _m_GetSaveScriptVersion);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearItems", _m_ClearItems);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllItemsInBag", _m_GetAllItemsInBag);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetEquips", _m_GetEquips);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetEquipByPos", _m_GetEquipByPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetActionMode", _m_GetActionMode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetExp", _m_GetExp);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNextLevelExp", _m_GetNextLevelExp);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemListInBag", _m_GetItemListInBag);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemListInBox", _m_GetItemListInBox);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemListInBagEx", _m_GetItemListInBagEx);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemListInBoxEx", _m_GetItemListInBoxEx);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemListInMedicineBag", _m_GetItemListInMedicineBag);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBagUsedCount", _m_GetBagUsedCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFreeBagCount", _m_GetFreeBagCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBagCount", _m_GetBagCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetBagCount", _m_SetBagCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFreeBoxCount", _m_GetFreeBoxCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBoxCount", _m_GetBoxCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetBoxCount", _m_SetBoxCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemInBag", _m_GetItemInBag);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetOneItemByTypeInBag", _m_GetOneItemByTypeInBag);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemInAllSpace", _m_GetItemInAllSpace);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FindItem", _m_FindItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UseSkill", _m_UseSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UseSkillToDir", _m_UseSkillToDir);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetWellNetwork", _m_SetWellNetwork);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetWorldPos", _m_GetWorldPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNpc", _m_GetNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAction", _m_SetAction);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopGoto", _m_StopGoto);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GotoPosition", _m_GotoPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GoDirection", _m_GoDirection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartDirection", _m_StartDirection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopDirection", _m_StopDirection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPosition", _m_SetPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTargetPosition", _m_GetTargetPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanCastSkill", _m_CanCastSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Revive", _m_Revive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "EnterClientMap", _m_EnterClientMap);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BindNpc", _m_BindNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HaveNpc", _m_HaveNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPortrait", _m_SetPortrait);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBaseDamage", _m_GetBaseDamage);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartProgress", _m_StartProgress);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUserValue", _m_GetUserValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DropItemInPos", _m_DropItemInPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSkillLevel", _m_GetSkillLevel);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPartnerObj", _m_GetPartnerObj);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllPartner", _m_GetAllPartner);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPartnerPosInfo", _m_GetPartnerPosInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetValueItem", _m_GetValueItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllValueItem", _m_GetAllValueItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNpcResInfo", _m_GetNpcResInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFactionPotencyByLevel", _m_GetFactionPotencyByLevel);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNextLevelFactionPotency", _m_GetNextLevelFactionPotency);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CheckSkillAvailable2Npc", _m_CheckSkillAvailable2Npc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CheckRelationSkillAvailable", _m_CheckRelationSkillAvailable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetDoing", _m_GetDoing);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBaseAwardExp", _m_GetBaseAwardExp);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ModifyFeatureEquip", _m_ModifyFeatureEquip);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ApplyWLZExAttrib", _m_ApplyWLZExAttrib);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearLinkSkill", _m_ClearLinkSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ApplyExternAttrib", _m_ApplyExternAttrib);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveExternAttrib", _m_RemoveExternAttrib);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCanMoveDistance", _m_GetCanMoveDistance);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ApplyMagicAttrib", _m_ApplyMagicAttrib);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveMagicAttrib", _m_RemoveMagicAttrib);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBarrier", _m_GetBarrier);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DoSpecicalMoveStep", _m_DoSpecicalMoveStep);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPlayerSkillCD", _m_SetPlayerSkillCD);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddItem", _m_AddItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddItemUnsafe", _m_AddItemUnsafe);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UseEquip", _m_UseEquip);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnuseEquip", _m_UnuseEquip);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnuseEquipById", _m_UnuseEquipById);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddAttrTitles", _m_AddAttrTitles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddAttrTitle", _m_AddAttrTitle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DelTitle", _m_DelTitle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttrTitles", _m_GetAttrTitles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddTitlesAttr", _m_AddTitlesAttr);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddTitleAttr", _m_AddTitleAttr);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveTitleAttr", _m_RemoveTitleAttr);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsCanPath", _m_IsCanPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetFaction", _m_SetFaction);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BackToNavigation", _m_BackToNavigation);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCaptainFalg", _m_SetCaptainFalg);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateZongShiLevelData", _m_UpdateZongShiLevelData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMe", _m_GetMe);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearTempTable", _m_ClearTempTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearScriptTable", _m_ClearScriptTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PushCObj", _m_PushCObj);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Data", _g_get_Data);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ActiveSkillsReduceCdtimeP", _g_get_ActiveSkillsReduceCdtimeP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Alone", _g_get_Alone);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AttackSpeedV", _g_get_AttackSpeedV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BaseDexterity", _g_get_BaseDexterity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BaseEnergy", _g_get_BaseEnergy);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BaseStrength", _g_get_BaseStrength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BaseVitality", _g_get_BaseVitality);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BlockP", _g_get_BlockP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BlockV", _g_get_BlockV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BurnAttackRate", _g_get_BurnAttackRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BurnAttackTime", _g_get_BurnAttackTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BurnResistRate", _g_get_BurnResistRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BurnResistTime", _g_get_BurnResistTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CreateTime", _g_get_CreateTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DSDefense", _g_get_DSDefense);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DeadlyStrikeDamagePercent", _g_get_DeadlyStrikeDamagePercent);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Dexterity", _g_get_Dexterity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EarthR", _g_get_EarthR);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Energy", _g_get_Energy);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceDamageP", _g_get_EnhanceDamageP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEarthP", _g_get_EnhanceFinalDamageEarthP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyBurnP", _g_get_EnhanceFinalDamageEnemyBurnP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyConfuseP", _g_get_EnhanceFinalDamageEnemyConfuseP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyControlP", _g_get_EnhanceFinalDamageEnemyControlP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyDragP", _g_get_EnhanceFinalDamageEnemyDragP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyFixedP", _g_get_EnhanceFinalDamageEnemyFixedP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyFreezeP", _g_get_EnhanceFinalDamageEnemyFreezeP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyHealthP", _g_get_EnhanceFinalDamageEnemyHealthP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyHurtP", _g_get_EnhanceFinalDamageEnemyHurtP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyInjuryP", _g_get_EnhanceFinalDamageEnemyInjuryP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyKnockP", _g_get_EnhanceFinalDamageEnemyKnockP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyPalsyP", _g_get_EnhanceFinalDamageEnemyPalsyP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemySlowallP", _g_get_EnhanceFinalDamageEnemySlowallP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyStunP", _g_get_EnhanceFinalDamageEnemyStunP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageEnemyWeakP", _g_get_EnhanceFinalDamageEnemyWeakP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageFireP", _g_get_EnhanceFinalDamageFireP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageMeleeP", _g_get_EnhanceFinalDamageMeleeP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageMetalP", _g_get_EnhanceFinalDamageMetalP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageNpcBossP", _g_get_EnhanceFinalDamageNpcBossP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageOwnHealthP", _g_get_EnhanceFinalDamageOwnHealthP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageOwnInjuryP", _g_get_EnhanceFinalDamageOwnInjuryP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageRemoteP", _g_get_EnhanceFinalDamageRemoteP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageSkillTagBaseP", _g_get_EnhanceFinalDamageSkillTagBaseP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageSkillTagKernelP", _g_get_EnhanceFinalDamageSkillTagKernelP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageSkillTagMechanismP", _g_get_EnhanceFinalDamageSkillTagMechanismP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageSkillTagSpecialP", _g_get_EnhanceFinalDamageSkillTagSpecialP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageWaterP", _g_get_EnhanceFinalDamageWaterP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageWoodP", _g_get_EnhanceFinalDamageWoodP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Faction", _g_get_Faction);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FactionSect", _g_get_FactionSect);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FightMode", _g_get_FightMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FireR", _g_get_FireR);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HitRate", _g_get_HitRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HonorLevel", _g_get_HonorLevel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HonorStarLevel", _g_get_HonorStarLevel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HurtAttackRate", _g_get_HurtAttackRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HurtAttackTime", _g_get_HurtAttackTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HurtResistRate", _g_get_HurtResistRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HurtResistTime", _g_get_HurtResistTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ID", _g_get_ID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreAllResist", _g_get_IgnoreAllResist);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreDefense", _g_get_IgnoreDefense);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreEarth", _g_get_IgnoreEarth);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreEarthRV", _g_get_IgnoreEarthRV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreFire", _g_get_IgnoreFire);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreFireRV", _g_get_IgnoreFireRV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreMetal", _g_get_IgnoreMetal);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreMetalRV", _g_get_IgnoreMetalRV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreWater", _g_get_IgnoreWater);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreWaterRV", _g_get_IgnoreWaterRV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreWood", _g_get_IgnoreWood);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreWoodRV", _g_get_IgnoreWoodRV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "InBattleState", _g_get_InBattleState);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsP2PTrading", _g_get_IsP2PTrading);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "KinId", _g_get_KinId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "KinTitle", _g_get_KinTitle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LeftPotentialPoint", _g_get_LeftPotentialPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LegionId", _g_get_LegionId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Level", _g_get_Level);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LevelUpAboutEquipSeries", _g_get_LevelUpAboutEquipSeries);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LifeMaxAllP", _g_get_LifeMaxAllP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LifeMaxEnhanceW", _g_get_LifeMaxEnhanceW);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LifeRecoverTotal", _g_get_LifeRecoverTotal);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LifeReplenish", _g_get_LifeReplenish);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MainStreetEnabled", _g_get_MainStreetEnabled);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ManaRecoverTotal", _g_get_ManaRecoverTotal);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ManaReplenish", _g_get_ManaReplenish);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MapId", _g_get_MapId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MapName", _g_get_MapName);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MapTemplateId", _g_get_MapTemplateId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaskFactSkillState", _g_get_MaskFactSkillState);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaskPlayerAttrState", _g_get_MaskPlayerAttrState);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaxLife", _g_get_MaxLife);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaxMana", _g_get_MaxMana);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MetalR", _g_get_MetalR);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Miss", _g_get_Miss);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Name", _g_get_Name);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "PhysicsPotentialDamage", _g_get_PhysicsPotentialDamage);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "PkMode", _g_get_PkMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Portrait", _g_get_Portrait);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReduceDamageAllP", _g_get_ReduceDamageAllP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReduceDamageBossP", _g_get_ReduceDamageBossP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReduceDamageControlP", _g_get_ReduceDamageControlP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReduceDamageHealthP", _g_get_ReduceDamageHealthP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReduceDamageInjuryP", _g_get_ReduceDamageInjuryP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReduceDamageMeleeP", _g_get_ReduceDamageMeleeP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReduceDamageP", _g_get_ReduceDamageP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReduceDamageRemoteP", _g_get_ReduceDamageRemoteP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ResistEnhanceDamageP", _g_get_ResistEnhanceDamageP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ResistReduceDamageP", _g_get_ResistReduceDamageP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReturnResistMeleeV", _g_get_ReturnResistMeleeV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReturnResistRangeV", _g_get_ReturnResistRangeV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RideState", _g_get_RideState);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ServerId", _g_get_ServerId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Sex", _g_get_Sex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SlowAllAttackRate", _g_get_SlowAllAttackRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SlowAllAttckTime", _g_get_SlowAllAttckTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SlowAllResistRate", _g_get_SlowAllResistRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SlowAllResistTime", _g_get_SlowAllResistTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StealLifeRate", _g_get_StealLifeRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StealLifeResistRate", _g_get_StealLifeResistRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StealLifeResistValue", _g_get_StealLifeResistValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StealLifeValue", _g_get_StealLifeValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StealManaRate", _g_get_StealManaRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StealManaResistRate", _g_get_StealManaResistRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StealManaResistValue", _g_get_StealManaResistValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StealManaValue", _g_get_StealManaValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Strength", _g_get_Strength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StunAttackRate", _g_get_StunAttackRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StunAttackTime", _g_get_StunAttackTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StunResistRate", _g_get_StunResistRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StunResistTime", _g_get_StunResistTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TeamID", _g_get_TeamID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TongId", _g_get_TongId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TotalLevel", _g_get_TotalLevel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Vitality", _g_get_Vitality);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WaterR", _g_get_WaterR);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WeakAttackRate", _g_get_WeakAttackRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WeakAttackTime", _g_get_WeakAttackTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WeakResistRate", _g_get_WeakResistRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WeakResistTime", _g_get_WeakResistTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WeakenDS", _g_get_WeakenDS);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WindR", _g_get_WindR);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ZongShiLevel", _g_get_ZongShiLevel);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Data", _s_set_Data);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Faction", _s_set_Faction);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "FactionSect", _s_set_FactionSect);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "FightMode", _s_set_FightMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ID", _s_set_ID);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "IsP2PTrading", _s_set_IsP2PTrading);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "KinId", _s_set_KinId);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "KinTitle", _s_set_KinTitle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LegionId", _s_set_LegionId);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LevelUpAboutEquipSeries", _s_set_LevelUpAboutEquipSeries);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "MainStreetEnabled", _s_set_MainStreetEnabled);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "MaskFactSkillState", _s_set_MaskFactSkillState);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "MaskPlayerAttrState", _s_set_MaskPlayerAttrState);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "TongId", _s_set_TongId);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new ThanMaOrigin.Lua.Native.MePlayer();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ThanMaOrigin.Lua.Native.MePlayer constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetScriptTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetScriptTable( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SaveScriptTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SaveScriptTable( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSaveScriptVersion(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetSaveScriptVersion( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearItems(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ClearItems( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllItemsInBag(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAllItemsInBag( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquips(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetEquips( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipByPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetEquipByPos( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActionMode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetActionMode( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetExp(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetExp( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNextLevelExp(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNextLevelExp( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemListInBag(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemListInBag( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemListInBox(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemListInBox( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemListInBagEx(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemListInBagEx( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemListInBoxEx(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemListInBoxEx( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemListInMedicineBag(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemListInMedicineBag( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagUsedCount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetBagUsedCount( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFreeBagCount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetFreeBagCount( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBagCount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetBagCount( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBagCount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetBagCount( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFreeBoxCount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetFreeBoxCount( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBoxCount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetBoxCount( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBoxCount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetBoxCount( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemInBag(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemInBag( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOneItemByTypeInBag(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetOneItemByTypeInBag( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemInAllSpace(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemInAllSpace( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindItem(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.FindItem( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UseSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.UseSkill( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UseSkillToDir(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.UseSkillToDir( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetWellNetwork(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetWellNetwork( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWorldPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetWorldPos( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAction(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetAction( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopGoto(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.StopGoto( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GotoPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GotoPosition( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoDirection(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GoDirection( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartDirection(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.StartDirection( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopDirection(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.StopDirection( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetPosition( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTargetPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetTargetPosition( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanCastSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CanCastSkill( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Revive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.Revive( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnterClientMap(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.EnterClientMap( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BindNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.BindNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HaveNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.HaveNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPortrait(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetPortrait( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBaseDamage(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetBaseDamage( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartProgress(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.StartProgress( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUserValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetUserValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DropItemInPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DropItemInPos( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillLevel(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetSkillLevel( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPartnerObj(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPartnerObj( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllPartner(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAllPartner( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPartnerPosInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPartnerPosInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetValueItem(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetValueItem( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllValueItem(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAllValueItem( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcResInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNpcResInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFactionPotencyByLevel(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetFactionPotencyByLevel( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNextLevelFactionPotency(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNextLevelFactionPotency( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckSkillAvailable2Npc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CheckSkillAvailable2Npc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckRelationSkillAvailable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CheckRelationSkillAvailable( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDoing(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetDoing( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBaseAwardExp(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetBaseAwardExp( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ModifyFeatureEquip(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ModifyFeatureEquip( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ApplyWLZExAttrib(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ApplyWLZExAttrib( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearLinkSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ClearLinkSkill( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ApplyExternAttrib(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ApplyExternAttrib( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveExternAttrib(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RemoveExternAttrib( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCanMoveDistance(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetCanMoveDistance( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ApplyMagicAttrib(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ApplyMagicAttrib( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveMagicAttrib(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RemoveMagicAttrib( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBarrier(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetBarrier( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoSpecicalMoveStep(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DoSpecicalMoveStep( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPlayerSkillCD(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetPlayerSkillCD( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddItem(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddItem( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddItemUnsafe(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddItemUnsafe( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UseEquip(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.UseEquip( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnuseEquip(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.UnuseEquip( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnuseEquipById(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.UnuseEquipById( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddAttrTitles(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddAttrTitles( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddAttrTitle(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddAttrTitle( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelTitle(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DelTitle( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttrTitles(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAttrTitles( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddTitlesAttr(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddTitlesAttr( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddTitleAttr(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddTitleAttr( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveTitleAttr(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RemoveTitleAttr( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsCanPath(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsCanPath( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFaction(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetFaction( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BackToNavigation(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.BackToNavigation( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCaptainFalg(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetCaptainFalg( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateZongShiLevelData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.UpdateZongShiLevelData( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMe(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetMe( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearTempTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ClearTempTable( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearScriptTable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ClearScriptTable( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushCObj(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.PushCObj( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Data);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActiveSkillsReduceCdtimeP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.ActiveSkillsReduceCdtimeP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Alone(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Alone);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttackSpeedV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.AttackSpeedV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseDexterity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.BaseDexterity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseEnergy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.BaseEnergy);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.BaseStrength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseVitality(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.BaseVitality);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BlockP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.BlockP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BlockV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.BlockV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BurnAttackRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.BurnAttackRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BurnAttackTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.BurnAttackTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BurnResistRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.BurnResistRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BurnResistTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.BurnResistTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CreateTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.CreateTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DSDefense(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.DSDefense);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeadlyStrikeDamagePercent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.DeadlyStrikeDamagePercent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Dexterity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Dexterity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EarthR(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EarthR);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Energy(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Energy);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceDamageP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceDamageP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEarthP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEarthP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyBurnP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyBurnP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyConfuseP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyConfuseP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyControlP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyControlP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyDragP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyDragP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyFixedP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyFixedP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyFreezeP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyFreezeP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyHealthP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyHealthP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyHurtP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyHurtP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyInjuryP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyInjuryP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyKnockP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyKnockP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyPalsyP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyPalsyP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemySlowallP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemySlowallP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyStunP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyStunP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageEnemyWeakP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageEnemyWeakP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageFireP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageFireP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageMeleeP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageMeleeP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageMetalP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageMetalP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageNpcBossP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageNpcBossP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageOwnHealthP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageOwnHealthP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageOwnInjuryP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageOwnInjuryP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageRemoteP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageRemoteP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageSkillTagBaseP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageSkillTagBaseP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageSkillTagKernelP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageSkillTagKernelP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageSkillTagMechanismP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.EnhanceFinalDamageSkillTagMechanismP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageSkillTagSpecialP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageSkillTagSpecialP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageWaterP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageWaterP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceFinalDamageWoodP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageWoodP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Faction(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Faction);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FactionSect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.FactionSect);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FightMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.FightMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FireR(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.FireR);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HitRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.HitRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HonorLevel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.HonorLevel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HonorStarLevel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.HonorStarLevel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HurtAttackRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.HurtAttackRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HurtAttackTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.HurtAttackTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HurtResistRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.HurtResistRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HurtResistTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.HurtResistTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreAllResist(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IgnoreAllResist);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreDefense(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.IgnoreDefense);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreEarth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.IgnoreEarth);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreEarthRV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.IgnoreEarthRV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreFire(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.IgnoreFire);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreFireRV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.IgnoreFireRV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreMetal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.IgnoreMetal);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreMetalRV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.IgnoreMetalRV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreWater(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.IgnoreWater);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreWaterRV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.IgnoreWaterRV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreWood(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.IgnoreWood);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreWoodRV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.IgnoreWoodRV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InBattleState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.InBattleState);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsP2PTrading(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsP2PTrading);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_KinId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.KinId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_KinTitle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.KinTitle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LeftPotentialPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.LeftPotentialPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LegionId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.LegionId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Level(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Level);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LevelUpAboutEquipSeries(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.LevelUpAboutEquipSeries);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LifeMaxAllP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.LifeMaxAllP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LifeMaxEnhanceW(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.LifeMaxEnhanceW);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LifeRecoverTotal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.LifeRecoverTotal);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LifeReplenish(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.LifeReplenish);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MainStreetEnabled(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.MainStreetEnabled);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ManaRecoverTotal(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ManaRecoverTotal);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ManaReplenish(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.ManaReplenish);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MapId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MapId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MapName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.MapName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MapTemplateId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MapTemplateId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaskFactSkillState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MaskFactSkillState);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaskPlayerAttrState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MaskPlayerAttrState);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxLife(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MaxLife);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxMana(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MaxMana);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MetalR(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MetalR);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Miss(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.Miss);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Name(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Name);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PhysicsPotentialDamage(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.PhysicsPotentialDamage);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PkMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.PkMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Portrait(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Portrait);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReduceDamageAllP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ReduceDamageAllP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReduceDamageBossP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ReduceDamageBossP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReduceDamageControlP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ReduceDamageControlP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReduceDamageHealthP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ReduceDamageHealthP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReduceDamageInjuryP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ReduceDamageInjuryP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReduceDamageMeleeP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ReduceDamageMeleeP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReduceDamageP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ReduceDamageP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReduceDamageRemoteP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ReduceDamageRemoteP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ResistEnhanceDamageP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.ResistEnhanceDamageP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ResistReduceDamageP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.ResistReduceDamageP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReturnResistMeleeV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.ReturnResistMeleeV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReturnResistRangeV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.ReturnResistRangeV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RideState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.RideState);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ServerId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ServerId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Sex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Sex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SlowAllAttackRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.SlowAllAttackRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SlowAllAttckTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.SlowAllAttckTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SlowAllResistRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.SlowAllResistRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SlowAllResistTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.SlowAllResistTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StealLifeRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.StealLifeRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StealLifeResistRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.StealLifeResistRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StealLifeResistValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.StealLifeResistValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StealLifeValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.StealLifeValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StealManaRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.StealManaRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StealManaResistRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.StealManaResistRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StealManaResistValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.StealManaResistValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StealManaValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.StealManaValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Strength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Strength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StunAttackRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.StunAttackRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StunAttackTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.StunAttackTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StunResistRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.StunResistRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StunResistTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.StunResistTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TeamID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TeamID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TongId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TongId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TotalLevel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TotalLevel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Vitality(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Vitality);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WaterR(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.WaterR);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeakAttackRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.WeakAttackRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeakAttackTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.WeakAttackTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeakResistRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.WeakResistRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeakResistTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.WeakResistTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeakenDS(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.WeakenDS);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WindR(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.WindR);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ZongShiLevel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ZongShiLevel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Data = (ThanMaOrigin.Lua.Native.MePlayerData)translator.GetObject(L, 2, typeof(ThanMaOrigin.Lua.Native.MePlayerData));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Faction(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Faction = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FactionSect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.FactionSect = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FightMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.FightMode = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ID = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IsP2PTrading(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.IsP2PTrading = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_KinId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.KinId = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_KinTitle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.KinTitle = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LegionId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LegionId = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LevelUpAboutEquipSeries(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LevelUpAboutEquipSeries = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MainStreetEnabled(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MainStreetEnabled = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaskFactSkillState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MaskFactSkillState = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MaskPlayerAttrState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MaskPlayerAttrState = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_TongId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.MePlayer gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayer)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.TongId = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
