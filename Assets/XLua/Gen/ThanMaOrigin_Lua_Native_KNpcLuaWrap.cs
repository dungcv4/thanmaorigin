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
    public class ThanMaOriginLuaNativeKNpcLuaWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(ThanMaOrigin.Lua.Native.KNpcLua);
			Utils.BeginObjectRegister(type, L, translator, 0, 202, 83, 9);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetEnhanceExpP1", _m_GetEnhanceExpP1);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetDropLucky", _m_GetDropLucky);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetWorldPos", _m_GetWorldPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBodySex", _m_GetBodySex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetBodySex", _m_SetBodySex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetDistance", _m_GetDistance);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddSkill", _m_AddSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveSkill", _m_RemoveSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFightPower", _m_GetFightPower);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttributePower", _m_GetAttributePower);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSkillLevelLimit", _m_SetSkillLevelLimit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetUseAssignAttr", _m_SetUseAssignAttr);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadAndUseAssignAttr", _m_LoadAndUseAssignAttr);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ChangeAttribValue", _m_ChangeAttribValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttribValue", _m_GetAttribValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSkillNextCastTime", _m_GetSkillNextCastTime);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetQingKungNextCastTime", _m_GetQingKungNextCastTime);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTownPortalNextCastTime", _m_GetTownPortalNextCastTime);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetRideHorseNextCastTime", _m_GetRideHorseNextCastTime);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSkillUsePoint", _m_GetSkillUsePoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetQingKungUsePoint", _m_GetQingKungUsePoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTownPortalUsePoint", _m_GetTownPortalUsePoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetRideHorseUsePoint", _m_GetRideHorseUsePoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanDoRideHorse", _m_CanDoRideHorse);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsBaseSkill", _m_IsBaseSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsTargetInDirRange", _m_IsTargetInDirRange);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CheckNpcRelationBySelectType", _m_CheckNpcRelationBySelectType);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearbyNpcListBySkillRelation", _m_GetNearbyNpcListBySkillRelation);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearestNpcIdBySkillRelation", _m_GetNearestNpcIdBySkillRelation);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearestNpcByDirAndSkillRelation", _m_GetNearestNpcByDirAndSkillRelation);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearestNpcByDirAndSkillRelation2", _m_GetNearestNpcByDirAndSkillRelation2);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearbyNpcByPlayerId", _m_GetNearbyNpcByPlayerId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearestNpcByKind", _m_GetNearestNpcByKind);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPosition", _m_SetPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDir", _m_SetDir);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetDir", _m_GetDir);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDirToNpc", _m_SetDirToNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DoCommonAct", _m_DoCommonAct);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearAllSkillCD", _m_ClearAllSkillCD);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPlayer", _m_GetPlayer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsCanSkill", _m_IsCanSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CheckCanSkill", _m_CheckCanSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CheckCanJump", _m_CheckCanJump);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsIgoreSpecilStateSkill", _m_IsIgoreSpecilStateSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UseSkill", _m_UseSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetForceCanSkillOnce", _m_SetForceCanSkillOnce);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddSkillState", _m_AddSkillState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CastSkill", _m_CastSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DelayCastSkill", _m_DelayCastSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveSkillState", _m_RemoveSkillState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ApplyExternAttrib", _m_ApplyExternAttrib);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ModifyPartFeatureEquip", _m_ModifyPartFeatureEquip);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanChangeDoing", _m_CanChangeDoing);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSkillState", _m_GetSkillState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllSkillState", _m_GetAllSkillState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSkillEffectInfo", _m_GetSkillEffectInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsAlone", _m_IsAlone);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsInSpecialState", _m_IsInSpecialState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HaveRefFlag", _m_HaveRefFlag);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Delete", _m_Delete);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartDamageCounter", _m_StartDamageCounter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopDamageCounter", _m_StopDamageCounter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsDamageCounter", _m_IsDamageCounter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetDamageCounter", _m_GetDamageCounter);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AI_AddMovePos", _m_AI_AddMovePos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AI_ClearMovePathPoint", _m_AI_ClearMovePathPoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AI_StartPath", _m_AI_StartPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AI_SetFollowNpc", _m_AI_SetFollowNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AI_SetWaitNpc", _m_AI_SetWaitNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AI_SetTarget", _m_AI_SetTarget);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AI_SetAttackType", _m_AI_SetAttackType);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AI_SetGiveWay", _m_AI_SetGiveWay);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AI_SetFleeByNear", _m_AI_SetFleeByNear);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AI_SetFollowDistance", _m_AI_SetFollowDistance);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAi", _m_SetAi);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAiActive", _m_SetAiActive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddAiLockTarget", _m_AddAiLockTarget);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearAiLockTarget", _m_ClearAiLockTarget);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPkMode", _m_SetPkMode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetState", _m_GetState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ShowFlyChar", _m_ShowFlyChar);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddAnger", _m_AddAnger);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCurLife", _m_SetCurLife);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCurMana", _m_SetCurMana);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetMaxLife", _m_SetMaxLife);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCamp", _m_SetCamp);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetNotifyHpInfo", _m_SetNotifyHpInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetHideNpc", _m_SetHideNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearbyNpcByRelation", _m_GetNearbyNpcByRelation);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearbyNpcByRelationChar", _m_GetNearbyNpcByRelationChar);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCurrentTrapName", _m_GetCurrentTrapName);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTitleID", _m_SetTitleID);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTitle", _m_SetTitle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTitleInfo", _m_SetTitleInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetName", _m_SetName);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BubbleTalk", _m_BubbleTalk);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DoDeath", _m_DoDeath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetBloodType", _m_SetBloodType);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RestoreHP", _m_RestoreHP);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveAllSkillState", _m_RemoveAllSkillState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearSkillStateByMagicType", _m_ClearSkillStateByMagicType);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetMasterNpcId", _m_SetMasterNpcId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAiRadius", _m_SetAiRadius);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetActiveForever", _m_SetActiveForever);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPkMode", _m_GetPkMode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetProtected", _m_SetProtected);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetActionMode", _m_GetActionMode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetFindEnemyNotify", _m_SetFindEnemyNotify);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetNpcRange", _m_SetNpcRange);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttckMePlayersInfo", _m_GetAttckMePlayersInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLastDamageNpcId", _m_GetLastDamageNpcId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DoFlyChar", _m_DoFlyChar);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsDelayDelete", _m_IsDelayDelete);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ApplyMagicAttrib", _m_ApplyMagicAttrib);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveMagicAttrib", _m_RemoveMagicAttrib);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetBaseRunSpeed", _m_SetBaseRunSpeed);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetNoWalk", _m_SetNoWalk);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanDoQingKung", _m_CanDoQingKung);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanDoTownPortal", _m_CanDoTownPortal);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanReachDirectly", _m_CanReachDirectly);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPriStandAct", _m_SetPriStandAct);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopPriStandAct", _m_StopPriStandAct);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanDoAutoPath", _m_CanDoAutoPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RunTo", _m_RunTo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DoSpecicalMove", _m_DoSpecicalMove);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LockDoing", _m_LockDoing);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UnLockDoing", _m_UnLockDoing);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetActFrame", _m_GetActFrame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMapMaxPosForTest", _m_GetMapMaxPosForTest);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DoQingKung", _m_DoQingKung);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetActive", _m_SetActive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDefaultRunActID", _m_SetDefaultRunActID);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetIgnoreResistVByType", _m_GetIgnoreResistVByType);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFightStateByPlayer", _m_GetFightStateByPlayer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFightState", _m_GetFightState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAllSkillInfo", _m_GetAllSkillInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TownPortalHandle", _m_TownPortalHandle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsBoss", _m_IsBoss);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetQingKungCommandCache", _m_SetQingKungCommandCache);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearSkillCommandCache", _m_ClearSkillCommandCache);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetUseMedicineCommandCache", _m_SetUseMedicineCommandCache);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLastActionCommandType", _m_GetLastActionCommandType);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RollBackLastActionCommand", _m_RollBackLastActionCommand);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UseSkillToDir", _m_UseSkillToDir);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UseSkillToNpc", _m_UseSkillToNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetBindNpcId", _m_SetBindNpcId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeathNpc", _m_DeathNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetForceTargetId", _m_SetForceTargetId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMissileSpeed", _m_GetMissileSpeed);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RestoreAction", _m_RestoreAction);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHorseResId", _m_GetHorseResId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IgnoreSkillLimit", _m_IgnoreSkillLimit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetLuaAI", _m_SetLuaAI);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDamageDecrease", _m_SetDamageDecrease);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TestSlow", _m_TestSlow);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetWeakPos", _m_SetWeakPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetKind", _m_SetKind);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasSkill", _m_HasSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHasStartAct", _m_GetHasStartAct);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAction", _m_GetAction);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UseSkill2", _m_UseSkill2);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetIgnoreAttack", _m_SetIgnoreAttack);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBossWeak", _m_GetBossWeak);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetBossWeak", _m_SetBossWeak);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPosHeight", _m_GetPosHeight);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ForceSync", _m_ForceSync);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IgnoreSpecialState", _m_IgnoreSpecialState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeleteNpc", _m_DeleteNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FindNearestTarget", _m_FindNearestTarget);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetIgnoreAttack", _m_GetIgnoreAttack);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetForceSkill", _m_SetForceSkill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UseMask", _m_UseMask);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearVelocity", _m_ClearVelocity);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAct", _m_SetAct);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ChangePartEquip", _m_ChangePartEquip);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ChangeCurFeaturePart", _m_ChangeCurFeaturePart);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNpcFeature", _m_GetNpcFeature);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNpcFashionFeature", _m_GetNpcFashionFeature);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNpcResId", _m_GetNpcResId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetNpcResId", _m_SetNpcResId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ChangeNpcRes", _m_ChangeNpcRes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "NpcHasSkillState", _m_NpcHasSkillState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ChangeRefFlag", _m_ChangeRefFlag);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCanRun", _m_SetCanRun);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearestCat", _m_GetNearestCat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetActionMode", _m_SetActionMode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBloodStyle", _m_GetBloodStyle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetBloodStyle", _m_SetBloodStyle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAIState", _m_GetAIState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMissileLife", _m_GetMissileLife);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFollowNpcId", _m_GetFollowNpcId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsOnGroud", _m_IsOnGroud);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetRelativeHeight", _m_GetRelativeHeight);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFaction", _m_GetFaction);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearNpcState", _m_ClearNpcState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPartnerProtectSkillAdditionLv", _m_GetPartnerProtectSkillAdditionLv);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetMasterId", _m_SetMasterId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetEquipShowState", _m_GetEquipShowState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetEquipShowState", _m_SetEquipShowState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHim", _m_GetHim);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearTempTable", _m_ClearTempTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PushCObj", _m_PushCObj);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Data", _g_get_Data);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AdditionalDamageResistV", _g_get_AdditionalDamageResistV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AdditionalDamageV", _g_get_AdditionalDamageV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AllSpecialStateResistRate", _g_get_AllSpecialStateResistRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AllSpecialStateResistTime", _g_get_AllSpecialStateResistTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Anger", _g_get_Anger);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AttackSpeed", _g_get_AttackSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BlockDamageResistV", _g_get_BlockDamageResistV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BlockV", _g_get_BlockV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Camp", _g_get_Camp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Class", _g_get_Class);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ClassName", _g_get_ClassName);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CurLife", _g_get_CurLife);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CurMana", _g_get_CurMana);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DeadlyStrikeDamageV", _g_get_DeadlyStrikeDamageV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DeadlyStrikeDamageVZhen", _g_get_DeadlyStrikeDamageVZhen);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DeadlyStrikeDamageWeakenV", _g_get_DeadlyStrikeDamageWeakenV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DeadlyStrikeV", _g_get_DeadlyStrikeV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DeadlyStrikeVZhen", _g_get_DeadlyStrikeVZhen);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DefaultDialogInfo", _g_get_DefaultDialogInfo);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DropRateP", _g_get_DropRateP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DropRateV", _g_get_DropRateV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EarthR", _g_get_EarthR);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceExpP", _g_get_EnhanceExpP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageOwnHealthP", _g_get_EnhanceFinalDamageOwnHealthP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EnhanceFinalDamageOwnInjuryP", _g_get_EnhanceFinalDamageOwnInjuryP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ExerciseNpcId", _g_get_ExerciseNpcId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Faction", _g_get_Faction);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FightMode", _g_get_FightMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FireR", _g_get_FireR);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HitRate", _g_get_HitRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HonorLevel", _g_get_HonorLevel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HonorStarLevel", _g_get_HonorStarLevel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Id", _g_get_Id);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreAllResistV", _g_get_IgnoreAllResistV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IgnoreMasterDeath", _g_get_IgnoreMasterDeath);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "KinId", _g_get_KinId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "KinTitle", _g_get_KinTitle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Kind", _g_get_Kind);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LegionId", _g_get_LegionId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LegionTitle", _g_get_LegionTitle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Level", _g_get_Level);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LifeMaxAllP", _g_get_LifeMaxAllP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "LoadFinish", _g_get_LoadFinish);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MapId", _g_get_MapId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MapTemplateId", _g_get_MapTemplateId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MasterNpcId", _g_get_MasterNpcId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaxLife", _g_get_MaxLife);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaxMana", _g_get_MaxMana);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MeleeReturnV", _g_get_MeleeReturnV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MirriorPlayerId", _g_get_MirriorPlayerId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Name", _g_get_Name);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "PartnerId", _g_get_PartnerId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "PlayerID", _g_get_PlayerID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Portrait", _g_get_Portrait);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RangeReturnV", _g_get_RangeReturnV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReduceDamageHealthP", _g_get_ReduceDamageHealthP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReduceDamageInjuryP", _g_get_ReduceDamageInjuryP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ReduceFinalDamageP", _g_get_ReduceFinalDamageP);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RideState", _g_get_RideState);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RunSpeed", _g_get_RunSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RunSpeedOnShow", _g_get_RunSpeedOnShow);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ScriptParam", _g_get_ScriptParam);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Series", _g_get_Series);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SeriesAbate", _g_get_SeriesAbate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SeriesAbateResist", _g_get_SeriesAbateResist);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SeriesEnhance", _g_get_SeriesEnhance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SeriesEnhanceResist", _g_get_SeriesEnhanceResist);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StealLifeRate", _g_get_StealLifeRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StealLifeResistRate", _g_get_StealLifeResistRate);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StealLifeResistV", _g_get_StealLifeResistV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "StealLifeV", _g_get_StealLifeV);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Tag", _g_get_Tag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TeamID", _g_get_TeamID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TemplateId", _g_get_TemplateId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TitleID", _g_get_TitleID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TongId", _g_get_TongId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TotalLevel", _g_get_TotalLevel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WaterR", _g_get_WaterR);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WeakenDSDamageVZhen", _g_get_WeakenDSDamageVZhen);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WeakenDSVZhen", _g_get_WeakenDSVZhen);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WindR", _g_get_WindR);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ZongShiLevel", _g_get_ZongShiLevel);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Data", _s_set_Data);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Camp", _s_set_Camp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ExerciseNpcId", _s_set_ExerciseNpcId);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Faction", _s_set_Faction);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "FightMode", _s_set_FightMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "IgnoreMasterDeath", _s_set_IgnoreMasterDeath);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "KinTitle", _s_set_KinTitle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "LegionTitle", _s_set_LegionTitle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Name", _s_set_Name);
            
			
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
					
					var gen_ret = new ThanMaOrigin.Lua.Native.KNpcLua();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ThanMaOrigin.Lua.Native.KNpcLua constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEnhanceExpP1(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetEnhanceExpP1( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDropLucky(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetDropLucky( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetBodySex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetBodySex( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBodySex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetBodySex( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDistance(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetDistance( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddSkill( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RemoveSkill( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFightPower(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetFightPower( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttributePower(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAttributePower( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSkillLevelLimit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetSkillLevelLimit( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUseAssignAttr(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetUseAssignAttr( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadAndUseAssignAttr(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.LoadAndUseAssignAttr( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeAttribValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ChangeAttribValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttribValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAttribValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillNextCastTime(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetSkillNextCastTime( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetQingKungNextCastTime(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetQingKungNextCastTime( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTownPortalNextCastTime(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetTownPortalNextCastTime( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRideHorseNextCastTime(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetRideHorseNextCastTime( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillUsePoint(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetSkillUsePoint( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetQingKungUsePoint(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetQingKungUsePoint( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTownPortalUsePoint(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetTownPortalUsePoint( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRideHorseUsePoint(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetRideHorseUsePoint( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanDoRideHorse(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CanDoRideHorse( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBaseSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsBaseSkill( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsTargetInDirRange(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsTargetInDirRange( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckNpcRelationBySelectType(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CheckNpcRelationBySelectType( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearbyNpcListBySkillRelation(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNearbyNpcListBySkillRelation( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearestNpcIdBySkillRelation(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNearestNpcIdBySkillRelation( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearestNpcByDirAndSkillRelation(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNearestNpcByDirAndSkillRelation( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearestNpcByDirAndSkillRelation2(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNearestNpcByDirAndSkillRelation2( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearbyNpcByPlayerId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNearbyNpcByPlayerId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearestNpcByKind(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNearestNpcByKind( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_SetDir(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetDir( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDir(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetDir( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDirToNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetDirToNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoCommonAct(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DoCommonAct( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearAllSkillCD(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ClearAllSkillCD( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlayer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPlayer( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsCanSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsCanSkill( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckCanSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CheckCanSkill( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckCanJump(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CheckCanJump( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsIgoreSpecilStateSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsIgoreSpecilStateSkill( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_SetForceCanSkillOnce(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetForceCanSkillOnce( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddSkillState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddSkillState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CastSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CastSkill( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelayCastSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DelayCastSkill( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveSkillState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RemoveSkillState( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_ModifyPartFeatureEquip(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ModifyPartFeatureEquip( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanChangeDoing(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CanChangeDoing( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetSkillState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllSkillState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAllSkillState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillEffectInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetSkillEffectInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsAlone(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsAlone( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInSpecialState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsInSpecialState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HaveRefFlag(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.HaveRefFlag( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Delete(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.Delete( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartDamageCounter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.StartDamageCounter( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopDamageCounter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.StopDamageCounter( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDamageCounter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsDamageCounter( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDamageCounter(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetDamageCounter( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AI_AddMovePos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AI_AddMovePos( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AI_ClearMovePathPoint(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AI_ClearMovePathPoint( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AI_StartPath(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AI_StartPath( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AI_SetFollowNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AI_SetFollowNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AI_SetWaitNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AI_SetWaitNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AI_SetTarget(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AI_SetTarget( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AI_SetAttackType(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AI_SetAttackType( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AI_SetGiveWay(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AI_SetGiveWay( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AI_SetFleeByNear(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AI_SetFleeByNear( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AI_SetFollowDistance(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AI_SetFollowDistance( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAi(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetAi( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAiActive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetAiActive( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddAiLockTarget(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddAiLockTarget( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearAiLockTarget(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ClearAiLockTarget( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPkMode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetPkMode( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ShowFlyChar(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ShowFlyChar( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddAnger(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddAnger( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCurLife(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetCurLife( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCurMana(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetCurMana( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMaxLife(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetMaxLife( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCamp(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetCamp( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNotifyHpInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetNotifyHpInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetHideNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetHideNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearbyNpcByRelation(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNearbyNpcByRelation( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearbyNpcByRelationChar(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNearbyNpcByRelationChar( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCurrentTrapName(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetCurrentTrapName( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTitleID(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetTitleID( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTitle(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetTitle( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTitleInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetTitleInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetName(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetName( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BubbleTalk(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.BubbleTalk( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoDeath(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DoDeath( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBloodType(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetBloodType( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RestoreHP(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RestoreHP( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveAllSkillState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RemoveAllSkillState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearSkillStateByMagicType(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ClearSkillStateByMagicType( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMasterNpcId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetMasterNpcId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAiRadius(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetAiRadius( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetActiveForever(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetActiveForever( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPkMode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPkMode( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetProtected(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetProtected( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_SetFindEnemyNotify(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetFindEnemyNotify( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNpcRange(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetNpcRange( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAttckMePlayersInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAttckMePlayersInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLastDamageNpcId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetLastDamageNpcId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoFlyChar(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DoFlyChar( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsDelayDelete(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsDelayDelete( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_SetBaseRunSpeed(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetBaseRunSpeed( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNoWalk(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetNoWalk( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanDoQingKung(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CanDoQingKung( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanDoTownPortal(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CanDoTownPortal( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanReachDirectly(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CanReachDirectly( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPriStandAct(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetPriStandAct( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopPriStandAct(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.StopPriStandAct( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanDoAutoPath(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CanDoAutoPath( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RunTo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RunTo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoSpecicalMove(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DoSpecicalMove( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LockDoing(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.LockDoing( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UnLockDoing(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.UnLockDoing( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetActFrame( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMapMaxPosForTest(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetMapMaxPosForTest( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoQingKung(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DoQingKung( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetActive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetActive( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDefaultRunActID(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetDefaultRunActID( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetIgnoreResistVByType(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetIgnoreResistVByType( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFightStateByPlayer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetFightStateByPlayer( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFightState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetFightState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllSkillInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAllSkillInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TownPortalHandle(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.TownPortalHandle( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsBoss(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsBoss( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetQingKungCommandCache(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetQingKungCommandCache( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearSkillCommandCache(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ClearSkillCommandCache( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUseMedicineCommandCache(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetUseMedicineCommandCache( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLastActionCommandType(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetLastActionCommandType( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RollBackLastActionCommand(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RollBackLastActionCommand( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_UseSkillToNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.UseSkillToNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBindNpcId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetBindNpcId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeathNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DeathNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetForceTargetId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetForceTargetId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMissileSpeed(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetMissileSpeed( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RestoreAction(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RestoreAction( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHorseResId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetHorseResId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IgnoreSkillLimit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IgnoreSkillLimit( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLuaAI(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetLuaAI( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDamageDecrease(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetDamageDecrease( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TestSlow(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.TestSlow( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetWeakPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetWeakPos( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetKind(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetKind( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.HasSkill( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHasStartAct(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetHasStartAct( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAction(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAction( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UseSkill2(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.UseSkill2( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetIgnoreAttack(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetIgnoreAttack( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBossWeak(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetBossWeak( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBossWeak(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetBossWeak( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPosHeight(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPosHeight( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceSync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ForceSync( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IgnoreSpecialState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IgnoreSpecialState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeleteNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DeleteNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindNearestTarget(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.FindNearestTarget( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetIgnoreAttack(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetIgnoreAttack( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetForceSkill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetForceSkill( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UseMask(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.UseMask( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearVelocity(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ClearVelocity( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAct(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetAct( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangePartEquip(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ChangePartEquip( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeCurFeaturePart(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ChangeCurFeaturePart( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcFeature(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNpcFeature( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcFashionFeature(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNpcFashionFeature( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcResId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNpcResId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNpcResId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetNpcResId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeNpcRes(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ChangeNpcRes( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NpcHasSkillState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.NpcHasSkillState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeRefFlag(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ChangeRefFlag( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCanRun(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetCanRun( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearestCat(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNearestCat( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetActionMode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetActionMode( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBloodStyle(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetBloodStyle( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBloodStyle(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetBloodStyle( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAIState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAIState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMissileLife(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetMissileLife( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFollowNpcId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetFollowNpcId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsOnGroud(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsOnGroud( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRelativeHeight(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetRelativeHeight( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFaction(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetFaction( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearNpcState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ClearNpcState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPartnerProtectSkillAdditionLv(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPartnerProtectSkillAdditionLv( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMasterId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetMasterId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipShowState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetEquipShowState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetEquipShowState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetEquipShowState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHim(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetHim( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_PushCObj(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
            
            
                
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Data);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AdditionalDamageResistV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.AdditionalDamageResistV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AdditionalDamageV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.AdditionalDamageV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AllSpecialStateResistRate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.AllSpecialStateResistRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AllSpecialStateResistTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.AllSpecialStateResistTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Anger(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Anger);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttackSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.AttackSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BlockDamageResistV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.BlockDamageResistV);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.BlockV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Camp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Camp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Class(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Class);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ClassName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.ClassName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurLife(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.CurLife);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurMana(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.CurMana);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeadlyStrikeDamageV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.DeadlyStrikeDamageV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeadlyStrikeDamageVZhen(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.DeadlyStrikeDamageVZhen);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeadlyStrikeDamageWeakenV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.DeadlyStrikeDamageWeakenV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeadlyStrikeV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.DeadlyStrikeV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DeadlyStrikeVZhen(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.DeadlyStrikeVZhen);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DefaultDialogInfo(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.DefaultDialogInfo);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DropRateP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.DropRateP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DropRateV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.DropRateV);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EarthR);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EnhanceExpP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceExpP);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EnhanceFinalDamageOwnInjuryP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExerciseNpcId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.ExerciseNpcId);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Faction);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.HonorStarLevel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Id(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Id);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreAllResistV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IgnoreAllResistV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IgnoreMasterDeath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.IgnoreMasterDeath);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.KinTitle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Kind(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Kind);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.LegionId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LegionTitle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.LegionTitle);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Level);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.LifeMaxAllP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoadFinish(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.LoadFinish);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MapId);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MapTemplateId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MasterNpcId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MasterNpcId);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MaxMana);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MeleeReturnV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MeleeReturnV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MirriorPlayerId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MirriorPlayerId);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Name);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PartnerId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.PartnerId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlayerID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.PlayerID);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Portrait);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RangeReturnV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.RangeReturnV);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ReduceDamageInjuryP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ReduceFinalDamageP(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ReduceFinalDamageP);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.RideState);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RunSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.RunSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RunSpeedOnShow(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.RunSpeedOnShow);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ScriptParam(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ScriptParam);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Series(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Series);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SeriesAbate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.SeriesAbate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SeriesAbateResist(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.SeriesAbateResist);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SeriesEnhance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.SeriesEnhance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SeriesEnhanceResist(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.SeriesEnhanceResist);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.StealLifeResistRate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StealLifeResistV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.StealLifeResistV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_StealLifeV(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.StealLifeV);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Tag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Tag);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TeamID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TemplateId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TemplateId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TitleID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.TitleID);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TotalLevel);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.WaterR);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeakenDSDamageVZhen(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.WeakenDSDamageVZhen);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeakenDSVZhen(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.WeakenDSVZhen);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Data = (ThanMaOrigin.Lua.Native.KNpcLuaData)translator.GetObject(L, 2, typeof(ThanMaOrigin.Lua.Native.KNpcLuaData));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Camp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Camp = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ExerciseNpcId(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ExerciseNpcId = LuaAPI.lua_toboolean(L, 2);
            
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Faction = LuaAPI.xlua_tointeger(L, 2);
            
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.FightMode = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_IgnoreMasterDeath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.IgnoreMasterDeath = LuaAPI.xlua_tointeger(L, 2);
            
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
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.KinTitle = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_LegionTitle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.LegionTitle = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Name(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KNpcLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KNpcLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
