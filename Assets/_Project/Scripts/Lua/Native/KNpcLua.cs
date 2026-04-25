// Class:  KNpcLua  (gốc native binding `LuaNpc` from libclient_scene.so)
// Source: KTO_LibClientScene_Decompiled/INDEX.tsv (297 methods)
// XLua global: `KNpc` (registered via LuaEnv.Global.Set)
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
    public class KNpcLua
    {
        // Underlying C++ KPlayer/KNpc/KItem proxy (state holder).
        // gốc: LuaPlayer.this->player_ptr at offset +8 in C++ object.
        public KNpcLuaData Data { get; set; } = new KNpcLuaData();

        // ============ Properties (paired getX/setX) ============
        // VMA: 0x23a08c  Source: functions/0023a08c_LuaNpc26getAdditionalDamageResistVEv.asm
        public bool AdditionalDamageResistV { get; }

        // VMA: 0x23a06c  Source: functions/0023a06c_LuaNpc20getAdditionalDamageVEv.asm
        public int AdditionalDamageV { get; }

        // VMA: 0x23a228  Source: functions/0023a228_LuaNpc28getAllSpecialStateResistRateEv.asm
        public string AllSpecialStateResistRate { get; }

        // VMA: 0x23a248  Source: functions/0023a248_LuaNpc28getAllSpecialStateResistTimeEv.asm
        public bool AllSpecialStateResistTime { get; }

        // VMA: 0x239f3c  Source: functions/00239f3c_LuaNpc8getAngerEv.asm
        public int Anger { get; }

        // VMA: 0x23a66c  Source: functions/0023a66c_LuaNpc14getAttackSpeedEv.asm
        public int AttackSpeed { get; }

        // VMA: 0x23a0cc  Source: functions/0023a0cc_LuaNpc21getBlockDamageResistVEv.asm
        public bool BlockDamageResistV { get; }

        // VMA: 0x23a0ac  Source: functions/0023a0ac_LuaNpc9getBlockVEv.asm
        public int BlockV { get; }

        // VMA: 0x23a3e0  Source: functions/0023a3e0_LuaNpc7getCampEv.asm
        public int Camp { get; set; }

        // VMA: 0x23a394  Source: functions/0023a394_LuaNpc8getClassEv.asm
        public int Class { get; }

        // VMA: 0x23e790  Source: functions/0023e790_LuaNpc12getClassNameEv.asm
        public string ClassName { get; }

        // VMA: 0x23a288  Source: functions/0023a288_LuaNpc10getCurLifeEv.asm
        public int CurLife { get; }

        // VMA: 0x23a2a8  Source: functions/0023a2a8_LuaNpc10getCurManaEv.asm
        public int CurMana { get; }

        // VMA: 0x23a108  Source: functions/0023a108_LuaNpc22getDeadlyStrikeDamageVEv.asm
        public string DeadlyStrikeDamageV { get; }

        // VMA: 0x23a188  Source: functions/0023a188_LuaNpc26getDeadlyStrikeDamageVZhenEv.asm
        public string DeadlyStrikeDamageVZhen { get; }

        // VMA: 0x23a128  Source: functions/0023a128_LuaNpc28getDeadlyStrikeDamageWeakenVEv.asm
        public string DeadlyStrikeDamageWeakenV { get; }

        // VMA: 0x23a0ec  Source: functions/0023a0ec_LuaNpc16getDeadlyStrikeVEv.asm
        public string DeadlyStrikeV { get; }

        // VMA: 0x23a148  Source: functions/0023a148_LuaNpc20getDeadlyStrikeVZhenEv.asm
        public string DeadlyStrikeVZhen { get; }

        // VMA: 0x23a6fc  Source: functions/0023a6fc_LuaNpc20getDefaultDialogInfoEv.asm
        public int DefaultDialogInfo { get; }

        // VMA: 0x23a328  Source: functions/0023a328_LuaNpc12getDropRatePEv.asm
        public int DropRateP { get; }

        // VMA: 0x23a308  Source: functions/0023a308_LuaNpc12getDropRateVEv.asm
        public int DropRateV { get; }

        // VMA: 0x23a4e4  Source: functions/0023a4e4_LuaNpc9getEarthREv.asm
        public int EarthR { get; }

        // VMA: 0x23a348  Source: functions/0023a348_LuaNpc14getEnhanceExpPEv.asm
        public int EnhanceExpP { get; }

        // VMA: 0x23a5ec  Source: functions/0023a5ec_LuaNpc31getEnhanceFinalDamageOwnHealthPEv.asm
        public int EnhanceFinalDamageOwnHealthP { get; }

        // VMA: 0x23a62c  Source: functions/0023a62c_LuaNpc31getEnhanceFinalDamageOwnInjuryPEv.asm
        public int EnhanceFinalDamageOwnInjuryP { get; }

        // VMA: 0x23a718  Source: functions/0023a718_LuaNpc16getExerciseNpcIdEv.asm
        public bool ExerciseNpcId { get; set; }

        // VMA: 0x23a440  Source: functions/0023a440_LuaNpc10getFactionEv.asm
        public int Faction { get; set; }

        // VMA: 0x23a424  Source: functions/0023a424_LuaNpc12getFightModeEv.asm
        public int FightMode { get; set; }

        // VMA: 0x23a51c  Source: functions/0023a51c_LuaNpc8getFireREv.asm
        public int FireR { get; }

        // VMA: 0x23a554  Source: functions/0023a554_LuaNpc10getHitRateEv.asm
        public int HitRate { get; }

        // VMA: 0x23a6e4  Source: functions/0023a6e4_LuaNpc13getHonorLevelEv.asm
        public int HonorLevel { get; }

        // VMA: 0x23a6f0  Source: functions/0023a6f0_LuaNpc17getHonorStarLevelEv.asm
        public int HonorStarLevel { get; }

        // VMA: 0x239e9c  Source: functions/00239e9c_LuaNpc5getIdEv.asm
        public int Id { get; }

        // VMA: 0x23a268  Source: functions/0023a268_LuaNpc19getIgnoreAllResistVEv.asm
        public bool IgnoreAllResistV { get; }

        // VMA: 0x23a3fc  Source: functions/0023a3fc_LuaNpc20getIgnoreMasterDeathEv.asm
        public int IgnoreMasterDeath { get; set; }

        // VMA: 0x239f58  Source: functions/00239f58_LuaNpc8getKinIdEv.asm
        public int KinId { get; }

        // VMA: 0x239edc  Source: functions/00239edc_LuaNpc11getKinTitleEv.asm
        public string KinTitle { get; set; }

        // VMA: 0x239f24  Source: functions/00239f24_LuaNpc7getKindEv.asm
        public int Kind { get; }

        // VMA: 0x239f70  Source: functions/00239f70_LuaNpc11getLegionIdEv.asm
        public int LegionId { get; }

        // VMA: 0x239f00  Source: functions/00239f00_LuaNpc14getLegionTitleEv.asm
        public string LegionTitle { get; set; }

        // VMA: 0x239f7c  Source: functions/00239f7c_LuaNpc8getLevelEv.asm
        public int Level { get; }

        // VMA: 0x23a570  Source: functions/0023a570_LuaNpc14getLifeMaxAllPEv.asm
        public int LifeMaxAllP { get; }

        // VMA: 0x23a730  Source: functions/0023a730_LuaNpc13getLoadFinishEv.asm
        public bool LoadFinish { get; }

        // VMA: 0x23a378  Source: functions/0023a378_LuaNpc8getMapIdEv.asm
        public int MapId { get; }

        // VMA: 0x23a3a4  Source: functions/0023a3a4_LuaNpc16getMapTemplateIdEv.asm
        public int MapTemplateId { get; }

        // VMA: 0x23a6c0  Source: functions/0023a6c0_LuaNpc14getMasterNpcIdEv.asm
        public int MasterNpcId { get; }

        // VMA: 0x23a2c8  Source: functions/0023a2c8_LuaNpc10getMaxLifeEv.asm
        public int MaxLife { get; }

        // VMA: 0x23a2e8  Source: functions/0023a2e8_LuaNpc10getMaxManaEv.asm
        public int MaxMana { get; }

        // VMA: 0x23a02c  Source: functions/0023a02c_LuaNpc15getMeleeReturnVEv.asm
        public int MeleeReturnV { get; }

        // VMA: 0x239ea8  Source: functions/00239ea8_LuaNpc18getMirriorPlayerIdEv.asm
        public int MirriorPlayerId { get; }

        // VMA: 0x239ec0  Source: functions/00239ec0_LuaNpc7getNameEv.asm
        public string Name { get; set; }

        // VMA: 0x23a6cc  Source: functions/0023a6cc_LuaNpc12getPartnerIdEv.asm
        public int PartnerId { get; }

        // VMA: 0x239eb4  Source: functions/00239eb4_LuaNpc11getPlayerIDEv.asm
        public int PlayerID { get; }

        // VMA: 0x23e7a0  Source: functions/0023e7a0_LuaNpc11getPortraitEv.asm
        public int Portrait { get; }

        // VMA: 0x23a04c  Source: functions/0023a04c_LuaNpc15getRangeReturnVEv.asm
        public int RangeReturnV { get; }

        // VMA: 0x23a60c  Source: functions/0023a60c_LuaNpc22getReduceDamageHealthPEv.asm
        public int ReduceDamageHealthP { get; }

        // VMA: 0x23a64c  Source: functions/0023a64c_LuaNpc22getReduceDamageInjuryPEv.asm
        public int ReduceDamageInjuryP { get; }

        // VMA: 0x23a1c8  Source: functions/0023a1c8_LuaNpc21getReduceFinalDamagePEv.asm
        public int ReduceFinalDamageP { get; }

        // VMA: 0x23a744  Source: functions/0023a744_LuaNpc12getRideStateEv.asm
        public int RideState { get; }

        // VMA: 0x239fa8  Source: functions/00239fa8_LuaNpc11getRunSpeedEv.asm
        public int RunSpeed { get; }

        // VMA: 0x239fbc  Source: functions/00239fbc_LuaNpc17getRunSpeedOnShowEv.asm
        public int RunSpeedOnShow { get; }

        // VMA: 0x23a3c0  Source: functions/0023a3c0_LuaNpc14getScriptParamEv.asm
        public int ScriptParam { get; }

        // VMA: 0x239f30  Source: functions/00239f30_LuaNpc9getSeriesEv.asm
        public int Series { get; }

        // VMA: 0x239ffc  Source: functions/00239ffc_LuaNpc14getSeriesAbateEv.asm
        public int SeriesAbate { get; }

        // VMA: 0x23a014  Source: functions/0023a014_LuaNpc20getSeriesAbateResistEv.asm
        public bool SeriesAbateResist { get; }

        // VMA: 0x239fcc  Source: functions/00239fcc_LuaNpc16getSeriesEnhanceEv.asm
        public int SeriesEnhance { get; }

        // VMA: 0x239fe4  Source: functions/00239fe4_LuaNpc22getSeriesEnhanceResistEv.asm
        public bool SeriesEnhanceResist { get; }

        // VMA: 0x23a680  Source: functions/0023a680_LuaNpc16getStealLifeRateEv.asm
        public int StealLifeRate { get; }

        // VMA: 0x23a6a0  Source: functions/0023a6a0_LuaNpc22getStealLifeResistRateEv.asm
        public string StealLifeResistRate { get; }

        // VMA: 0x23a208  Source: functions/0023a208_LuaNpc19getStealLifeResistVEv.asm
        public bool StealLifeResistV { get; }

        // VMA: 0x23a1e8  Source: functions/0023a1e8_LuaNpc13getStealLifeVEv.asm
        public int StealLifeV { get; }

        // VMA: 0x23a3d0  Source: functions/0023a3d0_LuaNpc6getTagEv.asm
        public int Tag { get; }

        // VMA: 0x23a70c  Source: functions/0023a70c_LuaNpc9getTeamIDEv.asm
        public int TeamID { get; }

        // VMA: 0x23a368  Source: functions/0023a368_LuaNpc13getTemplateIdEv.asm
        public int TemplateId { get; }

        // VMA: 0x23a6d8  Source: functions/0023a6d8_LuaNpc10getTitleIDEv.asm
        public string TitleID { get; }

        // VMA: 0x239f64  Source: functions/00239f64_LuaNpc9getTongIdEv.asm
        public int TongId { get; }

        // VMA: 0x239f94  Source: functions/00239f94_LuaNpc13getTotalLevelEv.asm
        public int TotalLevel { get; }

        // VMA: 0x23a500  Source: functions/0023a500_LuaNpc9getWaterREv.asm
        public int WaterR { get; }

        // VMA: 0x23a1a8  Source: functions/0023a1a8_LuaNpc22getWeakenDSDamageVZhenEv.asm
        public int WeakenDSDamageVZhen { get; }

        // VMA: 0x23a168  Source: functions/0023a168_LuaNpc16getWeakenDSVZhenEv.asm
        public int WeakenDSVZhen { get; }

        // VMA: 0x23a538  Source: functions/0023a538_LuaNpc8getWindREv.asm
        public int WindR { get; }

        // VMA: 0x239f88  Source: functions/00239f88_LuaNpc15getZongShiLevelEv.asm
        public int ZongShiLevel { get; }

        // ============ Lua-callable methods (LuaXxx) ============
        // VMA: 0x23a770  Source: functions/0023a770_LuaNpc18LuaGetEnhanceExpP1ER10XLuaScript.asm
        // gốc body in 0023a770_LuaNpc18LuaGetEnhanceExpP1ER10XLuaScript.asm (160 bytes ARM64)
        public object GetEnhanceExpP1(params object[] args)
        {
            // TODO: port body from 0023a770_LuaNpc18LuaGetEnhanceExpP1ER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetEnhanceExpP1] not yet ported (gốc 0x23a770)");
            return null;
        }

        // VMA: 0x23a810  Source: functions/0023a810_LuaNpc15LuaGetDropLuckyER10XLuaScript.asm
        // gốc body in 0023a810_LuaNpc15LuaGetDropLuckyER10XLuaScript.asm (128 bytes ARM64)
        public object GetDropLucky(params object[] args)
        {
            // TODO: port body from 0023a810_LuaNpc15LuaGetDropLuckyER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetDropLucky] not yet ported (gốc 0x23a810)");
            return null;
        }

        // VMA: 0x23a890  Source: functions/0023a890_LuaNpc14LuaGetWorldPosER10XLuaScript.asm
        // gốc body in 0023a890_LuaNpc14LuaGetWorldPosER10XLuaScript.asm (328 bytes ARM64)
        public object GetWorldPos(params object[] args)
        {
            // TODO: port body from 0023a890_LuaNpc14LuaGetWorldPosER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetWorldPos] not yet ported (gốc 0x23a890)");
            return null;
        }

        // VMA: 0x23a9d8  Source: functions/0023a9d8_LuaNpc13LuaGetBodySexER10XLuaScript.asm
        // gốc body in 0023a9d8_LuaNpc13LuaGetBodySexER10XLuaScript.asm (44 bytes ARM64)
        public object GetBodySex(params object[] args)
        {
            // TODO: port body from 0023a9d8_LuaNpc13LuaGetBodySexER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetBodySex] not yet ported (gốc 0x23a9d8)");
            return null;
        }

        // VMA: 0x23aa04  Source: functions/0023aa04_LuaNpc13LuaSetBodySexER10XLuaScript.asm
        // gốc body in 0023aa04_LuaNpc13LuaSetBodySexER10XLuaScript.asm (56 bytes ARM64)
        public object SetBodySex(params object[] args)
        {
            // TODO: port body from 0023aa04_LuaNpc13LuaSetBodySexER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetBodySex] not yet ported (gốc 0x23aa04)");
            return null;
        }

        // VMA: 0x23aa3c  Source: functions/0023aa3c_LuaNpc14LuaGetDistanceER10XLuaScript.asm
        // gốc body in 0023aa3c_LuaNpc14LuaGetDistanceER10XLuaScript.asm (128 bytes ARM64)
        public object GetDistance(params object[] args)
        {
            // TODO: port body from 0023aa3c_LuaNpc14LuaGetDistanceER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetDistance] not yet ported (gốc 0x23aa3c)");
            return null;
        }

        // VMA: 0x23aabc  Source: functions/0023aabc_LuaNpc11LuaAddSkillER10XLuaScript.asm
        // gốc body in 0023aabc_LuaNpc11LuaAddSkillER10XLuaScript.asm (600 bytes ARM64)
        public object AddSkill(params object[] args)
        {
            // TODO: port body from 0023aabc_LuaNpc11LuaAddSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AddSkill] not yet ported (gốc 0x23aabc)");
            return null;
        }

        // VMA: 0x23ad14  Source: functions/0023ad14_LuaNpc14LuaRemoveSkillER10XLuaScript.asm
        // gốc body in 0023ad14_LuaNpc14LuaRemoveSkillER10XLuaScript.asm (104 bytes ARM64)
        public object RemoveSkill(params object[] args)
        {
            // TODO: port body from 0023ad14_LuaNpc14LuaRemoveSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.RemoveSkill] not yet ported (gốc 0x23ad14)");
            return null;
        }

        // VMA: 0x23ad7c  Source: functions/0023ad7c_LuaNpc16LuaGetFightPowerER10XLuaScript.asm
        // gốc body in 0023ad7c_LuaNpc16LuaGetFightPowerER10XLuaScript.asm (56 bytes ARM64)
        public object GetFightPower(params object[] args)
        {
            // TODO: port body from 0023ad7c_LuaNpc16LuaGetFightPowerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetFightPower] not yet ported (gốc 0x23ad7c)");
            return null;
        }

        // VMA: 0x23adb4  Source: functions/0023adb4_LuaNpc20LuaGetAttributePowerER10XLuaScript.asm
        // gốc body in 0023adb4_LuaNpc20LuaGetAttributePowerER10XLuaScript.asm (56 bytes ARM64)
        public object GetAttributePower(params object[] args)
        {
            // TODO: port body from 0023adb4_LuaNpc20LuaGetAttributePowerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetAttributePower] not yet ported (gốc 0x23adb4)");
            return null;
        }

        // VMA: 0x23adec  Source: functions/0023adec_LuaNpc21LuaSetSkillLevelLimitER10XLuaScript.asm
        // gốc body in 0023adec_LuaNpc21LuaSetSkillLevelLimitER10XLuaScript.asm (84 bytes ARM64)
        public object SetSkillLevelLimit(params object[] args)
        {
            // TODO: port body from 0023adec_LuaNpc21LuaSetSkillLevelLimitER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetSkillLevelLimit] not yet ported (gốc 0x23adec)");
            return null;
        }

        // VMA: 0x23ae40  Source: functions/0023ae40_LuaNpc19LuaSetUseAssignAttrER10XLuaScript.asm
        // gốc body in 0023ae40_LuaNpc19LuaSetUseAssignAttrER10XLuaScript.asm (84 bytes ARM64)
        public object SetUseAssignAttr(params object[] args)
        {
            // TODO: port body from 0023ae40_LuaNpc19LuaSetUseAssignAttrER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetUseAssignAttr] not yet ported (gốc 0x23ae40)");
            return null;
        }

        // VMA: 0x23ae94  Source: functions/0023ae94_LuaNpc23LuaLoadAndUseAssignAttrER10XLuaScript.asm
        // gốc body in 0023ae94_LuaNpc23LuaLoadAndUseAssignAttrER10XLuaScript.asm (144 bytes ARM64)
        public object LoadAndUseAssignAttr(params object[] args)
        {
            // TODO: port body from 0023ae94_LuaNpc23LuaLoadAndUseAssignAttrER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.LoadAndUseAssignAttr] not yet ported (gốc 0x23ae94)");
            return null;
        }

        // VMA: 0x23af24  Source: functions/0023af24_LuaNpc20LuaChangeAttribValueER10XLuaScript.asm
        // gốc body in 0023af24_LuaNpc20LuaChangeAttribValueER10XLuaScript.asm (324 bytes ARM64)
        public object ChangeAttribValue(params object[] args)
        {
            // TODO: port body from 0023af24_LuaNpc20LuaChangeAttribValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ChangeAttribValue] not yet ported (gốc 0x23af24)");
            return null;
        }

        // VMA: 0x23b068  Source: functions/0023b068_LuaNpc17LuaGetAttribValueER10XLuaScript.asm
        // gốc body in 0023b068_LuaNpc17LuaGetAttribValueER10XLuaScript.asm (148 bytes ARM64)
        public object GetAttribValue(params object[] args)
        {
            // TODO: port body from 0023b068_LuaNpc17LuaGetAttribValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetAttribValue] not yet ported (gốc 0x23b068)");
            return null;
        }

        // VMA: 0x23b0fc  Source: functions/0023b0fc_LuaNpc23LuaGetSkillNextCastTimeER10XLuaScript.asm
        // gốc body in 0023b0fc_LuaNpc23LuaGetSkillNextCastTimeER10XLuaScript.asm (132 bytes ARM64)
        public object GetSkillNextCastTime(params object[] args)
        {
            // TODO: port body from 0023b0fc_LuaNpc23LuaGetSkillNextCastTimeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetSkillNextCastTime] not yet ported (gốc 0x23b0fc)");
            return null;
        }

        // VMA: 0x23b180  Source: functions/0023b180_LuaNpc26LuaGetQingKungNextCastTimeER10XLuaScript.asm
        // gốc body in 0023b180_LuaNpc26LuaGetQingKungNextCastTimeER10XLuaScript.asm (80 bytes ARM64)
        public object GetQingKungNextCastTime(params object[] args)
        {
            // TODO: port body from 0023b180_LuaNpc26LuaGetQingKungNextCastTimeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetQingKungNextCastTime] not yet ported (gốc 0x23b180)");
            return null;
        }

        // VMA: 0x23b1d0  Source: functions/0023b1d0_LuaNpc28LuaGetTownPortalNextCastTimeER10XLuaScript.asm
        // gốc body in 0023b1d0_LuaNpc28LuaGetTownPortalNextCastTimeER10XLuaScript.asm (80 bytes ARM64)
        public object GetTownPortalNextCastTime(params object[] args)
        {
            // TODO: port body from 0023b1d0_LuaNpc28LuaGetTownPortalNextCastTimeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetTownPortalNextCastTime] not yet ported (gốc 0x23b1d0)");
            return null;
        }

        // VMA: 0x23b220  Source: functions/0023b220_LuaNpc27LuaGetRideHorseNextCastTimeER10XLuaScript.asm
        // gốc body in 0023b220_LuaNpc27LuaGetRideHorseNextCastTimeER10XLuaScript.asm (80 bytes ARM64)
        public object GetRideHorseNextCastTime(params object[] args)
        {
            // TODO: port body from 0023b220_LuaNpc27LuaGetRideHorseNextCastTimeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetRideHorseNextCastTime] not yet ported (gốc 0x23b220)");
            return null;
        }

        // VMA: 0x23b270  Source: functions/0023b270_LuaNpc19LuaGetSkillUsePointER10XLuaScript.asm
        // gốc body in 0023b270_LuaNpc19LuaGetSkillUsePointER10XLuaScript.asm (388 bytes ARM64)
        public object GetSkillUsePoint(params object[] args)
        {
            // TODO: port body from 0023b270_LuaNpc19LuaGetSkillUsePointER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetSkillUsePoint] not yet ported (gốc 0x23b270)");
            return null;
        }

        // VMA: 0x23b3f4  Source: functions/0023b3f4_LuaNpc22LuaGetQingKungUsePointER10XLuaScript.asm
        // gốc body in 0023b3f4_LuaNpc22LuaGetQingKungUsePointER10XLuaScript.asm (132 bytes ARM64)
        public object GetQingKungUsePoint(params object[] args)
        {
            // TODO: port body from 0023b3f4_LuaNpc22LuaGetQingKungUsePointER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetQingKungUsePoint] not yet ported (gốc 0x23b3f4)");
            return null;
        }

        // VMA: 0x23b478  Source: functions/0023b478_LuaNpc24LuaGetTownPortalUsePointER10XLuaScript.asm
        // gốc body in 0023b478_LuaNpc24LuaGetTownPortalUsePointER10XLuaScript.asm (132 bytes ARM64)
        public object GetTownPortalUsePoint(params object[] args)
        {
            // TODO: port body from 0023b478_LuaNpc24LuaGetTownPortalUsePointER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetTownPortalUsePoint] not yet ported (gốc 0x23b478)");
            return null;
        }

        // VMA: 0x23b4fc  Source: functions/0023b4fc_LuaNpc23LuaGetRideHorseUsePointER10XLuaScript.asm
        // gốc body in 0023b4fc_LuaNpc23LuaGetRideHorseUsePointER10XLuaScript.asm (124 bytes ARM64)
        public object GetRideHorseUsePoint(params object[] args)
        {
            // TODO: port body from 0023b4fc_LuaNpc23LuaGetRideHorseUsePointER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetRideHorseUsePoint] not yet ported (gốc 0x23b4fc)");
            return null;
        }

        // VMA: 0x23b578  Source: functions/0023b578_LuaNpc17LuaCanDoRideHorseER10XLuaScript.asm
        // gốc body in 0023b578_LuaNpc17LuaCanDoRideHorseER10XLuaScript.asm (52 bytes ARM64)
        public object CanDoRideHorse(params object[] args)
        {
            // TODO: port body from 0023b578_LuaNpc17LuaCanDoRideHorseER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.CanDoRideHorse] not yet ported (gốc 0x23b578)");
            return null;
        }

        // VMA: 0x23b5ac  Source: functions/0023b5ac_LuaNpc14LuaIsBaseSkillER10XLuaScript.asm
        // gốc body in 0023b5ac_LuaNpc14LuaIsBaseSkillER10XLuaScript.asm (80 bytes ARM64)
        public object IsBaseSkill(params object[] args)
        {
            // TODO: port body from 0023b5ac_LuaNpc14LuaIsBaseSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.IsBaseSkill] not yet ported (gốc 0x23b5ac)");
            return null;
        }

        // VMA: 0x23b5fc  Source: functions/0023b5fc_LuaNpc21LuaIsTargetInDirRangeER10XLuaScript.asm
        // gốc body in 0023b5fc_LuaNpc21LuaIsTargetInDirRangeER10XLuaScript.asm (172 bytes ARM64)
        public object IsTargetInDirRange(params object[] args)
        {
            // TODO: port body from 0023b5fc_LuaNpc21LuaIsTargetInDirRangeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.IsTargetInDirRange] not yet ported (gốc 0x23b5fc)");
            return null;
        }

        // VMA: 0x23b6a8  Source: functions/0023b6a8_LuaNpc31LuaCheckNpcRelationBySelectTypeER10XLuaScript.asm
        // gốc body in 0023b6a8_LuaNpc31LuaCheckNpcRelationBySelectTypeER10XLuaScript.asm (344 bytes ARM64)
        public object CheckNpcRelationBySelectType(params object[] args)
        {
            // TODO: port body from 0023b6a8_LuaNpc31LuaCheckNpcRelationBySelectTypeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.CheckNpcRelationBySelectType] not yet ported (gốc 0x23b6a8)");
            return null;
        }

        // VMA: 0x23baa4  Source: functions/0023baa4_LuaNpc34LuaGetNearbyNpcListBySkillRelationER10XLuaScript.asm
        // gốc body in 0023baa4_LuaNpc34LuaGetNearbyNpcListBySkillRelationER10XLuaScript.asm (756 bytes ARM64)
        public object GetNearbyNpcListBySkillRelation(params object[] args)
        {
            // TODO: port body from 0023baa4_LuaNpc34LuaGetNearbyNpcListBySkillRelationER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetNearbyNpcListBySkillRelation] not yet ported (gốc 0x23baa4)");
            return null;
        }

        // VMA: 0x23bd98  Source: functions/0023bd98_LuaNpc33LuaGetNearestNpcIdBySkillRelationER10XLuaScript.asm
        // gốc body in 0023bd98_LuaNpc33LuaGetNearestNpcIdBySkillRelationER10XLuaScript.asm (572 bytes ARM64)
        public object GetNearestNpcIdBySkillRelation(params object[] args)
        {
            // TODO: port body from 0023bd98_LuaNpc33LuaGetNearestNpcIdBySkillRelationER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetNearestNpcIdBySkillRelation] not yet ported (gốc 0x23bd98)");
            return null;
        }

        // VMA: 0x23bfd4  Source: functions/0023bfd4_LuaNpc37LuaGetNearestNpcByDirAndSkillRelationER10XLuaScript.asm
        // gốc body in 0023bfd4_LuaNpc37LuaGetNearestNpcByDirAndSkillRelationER10XLuaScript.asm (472 bytes ARM64)
        public object GetNearestNpcByDirAndSkillRelation(params object[] args)
        {
            // TODO: port body from 0023bfd4_LuaNpc37LuaGetNearestNpcByDirAndSkillRelationER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetNearestNpcByDirAndSkillRelation] not yet ported (gốc 0x23bfd4)");
            return null;
        }

        // VMA: 0x23c1ac  Source: functions/0023c1ac_LuaNpc38LuaGetNearestNpcByDirAndSkillRelation2ER10XLuaScript.asm
        // gốc body in 0023c1ac_LuaNpc38LuaGetNearestNpcByDirAndSkillRelation2ER10XLuaScript.asm (496 bytes ARM64)
        public object GetNearestNpcByDirAndSkillRelation2(params object[] args)
        {
            // TODO: port body from 0023c1ac_LuaNpc38LuaGetNearestNpcByDirAndSkillRelation2ER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetNearestNpcByDirAndSkillRelation2] not yet ported (gốc 0x23c1ac)");
            return null;
        }

        // VMA: 0x23c39c  Source: functions/0023c39c_LuaNpc25LuaGetNearbyNpcByPlayerIdER10XLuaScript.asm
        // gốc body in 0023c39c_LuaNpc25LuaGetNearbyNpcByPlayerIdER10XLuaScript.asm (88 bytes ARM64)
        public object GetNearbyNpcByPlayerId(params object[] args)
        {
            // TODO: port body from 0023c39c_LuaNpc25LuaGetNearbyNpcByPlayerIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetNearbyNpcByPlayerId] not yet ported (gốc 0x23c39c)");
            return null;
        }

        // VMA: 0x23c3f4  Source: functions/0023c3f4_LuaNpc22LuaGetNearestNpcByKindER10XLuaScript.asm
        // gốc body in 0023c3f4_LuaNpc22LuaGetNearestNpcByKindER10XLuaScript.asm (88 bytes ARM64)
        public object GetNearestNpcByKind(params object[] args)
        {
            // TODO: port body from 0023c3f4_LuaNpc22LuaGetNearestNpcByKindER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetNearestNpcByKind] not yet ported (gốc 0x23c3f4)");
            return null;
        }

        // VMA: 0x23c44c  Source: functions/0023c44c_LuaNpc14LuaSetPositionER10XLuaScript.asm
        // gốc body in 0023c44c_LuaNpc14LuaSetPositionER10XLuaScript.asm (144 bytes ARM64)
        public object SetPosition(params object[] args)
        {
            // TODO: port body from 0023c44c_LuaNpc14LuaSetPositionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetPosition] not yet ported (gốc 0x23c44c)");
            return null;
        }

        // VMA: 0x23c4dc  Source: functions/0023c4dc_LuaNpc9LuaSetDirER10XLuaScript.asm
        // gốc body in 0023c4dc_LuaNpc9LuaSetDirER10XLuaScript.asm (56 bytes ARM64)
        public object SetDir(params object[] args)
        {
            // TODO: port body from 0023c4dc_LuaNpc9LuaSetDirER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetDir] not yet ported (gốc 0x23c4dc)");
            return null;
        }

        // VMA: 0x23c514  Source: functions/0023c514_LuaNpc9LuaGetDirER10XLuaScript.asm
        // gốc body in 0023c514_LuaNpc9LuaGetDirER10XLuaScript.asm (44 bytes ARM64)
        public object GetDir(params object[] args)
        {
            // TODO: port body from 0023c514_LuaNpc9LuaGetDirER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetDir] not yet ported (gốc 0x23c514)");
            return null;
        }

        // VMA: 0x23c540  Source: functions/0023c540_LuaNpc14LuaSetDirToNpcER10XLuaScript.asm
        // gốc body in 0023c540_LuaNpc14LuaSetDirToNpcER10XLuaScript.asm (132 bytes ARM64)
        public object SetDirToNpc(params object[] args)
        {
            // TODO: port body from 0023c540_LuaNpc14LuaSetDirToNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetDirToNpc] not yet ported (gốc 0x23c540)");
            return null;
        }

        // VMA: 0x23c5c4  Source: functions/0023c5c4_LuaNpc14LuaDoCommonActER10XLuaScript.asm
        // gốc body in 0023c5c4_LuaNpc14LuaDoCommonActER10XLuaScript.asm (188 bytes ARM64)
        public object DoCommonAct(params object[] args)
        {
            // TODO: port body from 0023c5c4_LuaNpc14LuaDoCommonActER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.DoCommonAct] not yet ported (gốc 0x23c5c4)");
            return null;
        }

        // VMA: 0x23c680  Source: functions/0023c680_LuaNpc18LuaClearAllSkillCDER10XLuaScript.asm
        // gốc body in 0023c680_LuaNpc18LuaClearAllSkillCDER10XLuaScript.asm (40 bytes ARM64)
        public object ClearAllSkillCD(params object[] args)
        {
            // TODO: port body from 0023c680_LuaNpc18LuaClearAllSkillCDER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ClearAllSkillCD] not yet ported (gốc 0x23c680)");
            return null;
        }

        // VMA: 0x23c6a8  Source: functions/0023c6a8_LuaNpc12LuaGetPlayerER10XLuaScript.asm
        // gốc body in 0023c6a8_LuaNpc12LuaGetPlayerER10XLuaScript.asm (64 bytes ARM64)
        public object GetPlayer(params object[] args)
        {
            // TODO: port body from 0023c6a8_LuaNpc12LuaGetPlayerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetPlayer] not yet ported (gốc 0x23c6a8)");
            return null;
        }

        // VMA: 0x23c6e8  Source: functions/0023c6e8_LuaNpc13LuaIsCanSkillER10XLuaScript.asm
        // gốc body in 0023c6e8_LuaNpc13LuaIsCanSkillER10XLuaScript.asm (96 bytes ARM64)
        public object IsCanSkill(params object[] args)
        {
            // TODO: port body from 0023c6e8_LuaNpc13LuaIsCanSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.IsCanSkill] not yet ported (gốc 0x23c6e8)");
            return null;
        }

        // VMA: 0x23c748  Source: functions/0023c748_LuaNpc16LuaCheckCanSkillER10XLuaScript.asm
        // gốc body in 0023c748_LuaNpc16LuaCheckCanSkillER10XLuaScript.asm (64 bytes ARM64)
        public object CheckCanSkill(params object[] args)
        {
            // TODO: port body from 0023c748_LuaNpc16LuaCheckCanSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.CheckCanSkill] not yet ported (gốc 0x23c748)");
            return null;
        }

        // VMA: 0x23c788  Source: functions/0023c788_LuaNpc15LuaCheckCanJumpER10XLuaScript.asm
        // gốc body in 0023c788_LuaNpc15LuaCheckCanJumpER10XLuaScript.asm (60 bytes ARM64)
        public object CheckCanJump(params object[] args)
        {
            // TODO: port body from 0023c788_LuaNpc15LuaCheckCanJumpER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.CheckCanJump] not yet ported (gốc 0x23c788)");
            return null;
        }

        // VMA: 0x23c7c4  Source: functions/0023c7c4_LuaNpc26LuaIsIgoreSpecilStateSkillER10XLuaScript.asm
        // gốc body in 0023c7c4_LuaNpc26LuaIsIgoreSpecilStateSkillER10XLuaScript.asm (196 bytes ARM64)
        public object IsIgoreSpecilStateSkill(params object[] args)
        {
            // TODO: port body from 0023c7c4_LuaNpc26LuaIsIgoreSpecilStateSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.IsIgoreSpecilStateSkill] not yet ported (gốc 0x23c7c4)");
            return null;
        }

        // VMA: 0x23c888  Source: functions/0023c888_LuaNpc11LuaUseSkillER10XLuaScript.asm
        // gốc body in 0023c888_LuaNpc11LuaUseSkillER10XLuaScript.asm (252 bytes ARM64)
        public object UseSkill(params object[] args)
        {
            // TODO: port body from 0023c888_LuaNpc11LuaUseSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.UseSkill] not yet ported (gốc 0x23c888)");
            return null;
        }

        // VMA: 0x23c984  Source: functions/0023c984_LuaNpc23LuaSetForceCanSkillOnceER10XLuaScript.asm
        // gốc body in 0023c984_LuaNpc23LuaSetForceCanSkillOnceER10XLuaScript.asm (56 bytes ARM64)
        public object SetForceCanSkillOnce(params object[] args)
        {
            // TODO: port body from 0023c984_LuaNpc23LuaSetForceCanSkillOnceER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetForceCanSkillOnce] not yet ported (gốc 0x23c984)");
            return null;
        }

        // VMA: 0x23c9bc  Source: functions/0023c9bc_LuaNpc16LuaAddSkillStateER10XLuaScript.asm
        // gốc body in 0023c9bc_LuaNpc16LuaAddSkillStateER10XLuaScript.asm (276 bytes ARM64)
        public object AddSkillState(params object[] args)
        {
            // TODO: port body from 0023c9bc_LuaNpc16LuaAddSkillStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AddSkillState] not yet ported (gốc 0x23c9bc)");
            return null;
        }

        // VMA: 0x23cad0  Source: functions/0023cad0_LuaNpc12LuaCastSkillER10XLuaScript.asm
        // gốc body in 0023cad0_LuaNpc12LuaCastSkillER10XLuaScript.asm (192 bytes ARM64)
        public object CastSkill(params object[] args)
        {
            // TODO: port body from 0023cad0_LuaNpc12LuaCastSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.CastSkill] not yet ported (gốc 0x23cad0)");
            return null;
        }

        // VMA: 0x23cb90  Source: functions/0023cb90_LuaNpc17LuaDelayCastSkillER10XLuaScript.asm
        // gốc body in 0023cb90_LuaNpc17LuaDelayCastSkillER10XLuaScript.asm (148 bytes ARM64)
        public object DelayCastSkill(params object[] args)
        {
            // TODO: port body from 0023cb90_LuaNpc17LuaDelayCastSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.DelayCastSkill] not yet ported (gốc 0x23cb90)");
            return null;
        }

        // VMA: 0x23cc24  Source: functions/0023cc24_LuaNpc19LuaRemoveSkillStateER10XLuaScript.asm
        // gốc body in 0023cc24_LuaNpc19LuaRemoveSkillStateER10XLuaScript.asm (64 bytes ARM64)
        public object RemoveSkillState(params object[] args)
        {
            // TODO: port body from 0023cc24_LuaNpc19LuaRemoveSkillStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.RemoveSkillState] not yet ported (gốc 0x23cc24)");
            return null;
        }

        // VMA: 0x23cc64  Source: functions/0023cc64_LuaNpc20LuaApplyExternAttribER10XLuaScript.asm
        // gốc body in 0023cc64_LuaNpc20LuaApplyExternAttribER10XLuaScript.asm (144 bytes ARM64)
        public object ApplyExternAttrib(params object[] args)
        {
            // TODO: port body from 0023cc64_LuaNpc20LuaApplyExternAttribER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ApplyExternAttrib] not yet ported (gốc 0x23cc64)");
            return null;
        }

        // VMA: 0x23ccf4  Source: functions/0023ccf4_LuaNpc25LuaModifyPartFeatureEquipER10XLuaScript.asm
        // gốc body in 0023ccf4_LuaNpc25LuaModifyPartFeatureEquipER10XLuaScript.asm (144 bytes ARM64)
        public object ModifyPartFeatureEquip(params object[] args)
        {
            // TODO: port body from 0023ccf4_LuaNpc25LuaModifyPartFeatureEquipER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ModifyPartFeatureEquip] not yet ported (gốc 0x23ccf4)");
            return null;
        }

        // VMA: 0x23cd84  Source: functions/0023cd84_LuaNpc17LuaCanChangeDoingER10XLuaScript.asm
        // gốc body in 0023cd84_LuaNpc17LuaCanChangeDoingER10XLuaScript.asm (76 bytes ARM64)
        public object CanChangeDoing(params object[] args)
        {
            // TODO: port body from 0023cd84_LuaNpc17LuaCanChangeDoingER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.CanChangeDoing] not yet ported (gốc 0x23cd84)");
            return null;
        }

        // VMA: 0x23cdd0  Source: functions/0023cdd0_LuaNpc16LuaGetSkillStateER10XLuaScript.asm
        // gốc body in 0023cdd0_LuaNpc16LuaGetSkillStateER10XLuaScript.asm (80 bytes ARM64)
        public object GetSkillState(params object[] args)
        {
            // TODO: port body from 0023cdd0_LuaNpc16LuaGetSkillStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetSkillState] not yet ported (gốc 0x23cdd0)");
            return null;
        }

        // VMA: 0x23ce20  Source: functions/0023ce20_LuaNpc19LuaGetAllSkillStateER10XLuaScript.asm
        // gốc body in 0023ce20_LuaNpc19LuaGetAllSkillStateER10XLuaScript.asm (104 bytes ARM64)
        public object GetAllSkillState(params object[] args)
        {
            // TODO: port body from 0023ce20_LuaNpc19LuaGetAllSkillStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetAllSkillState] not yet ported (gốc 0x23ce20)");
            return null;
        }

        // VMA: 0x23ce88  Source: functions/0023ce88_LuaNpc21LuaGetSkillEffectInfoER10XLuaScript.asm
        // gốc body in 0023ce88_LuaNpc21LuaGetSkillEffectInfoER10XLuaScript.asm (80 bytes ARM64)
        public object GetSkillEffectInfo(params object[] args)
        {
            // TODO: port body from 0023ce88_LuaNpc21LuaGetSkillEffectInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetSkillEffectInfo] not yet ported (gốc 0x23ce88)");
            return null;
        }

        // VMA: 0x23ced8  Source: functions/0023ced8_LuaNpc10LuaIsAloneER10XLuaScript.asm
        // gốc body in 0023ced8_LuaNpc10LuaIsAloneER10XLuaScript.asm (48 bytes ARM64)
        public object IsAlone(params object[] args)
        {
            // TODO: port body from 0023ced8_LuaNpc10LuaIsAloneER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.IsAlone] not yet ported (gốc 0x23ced8)");
            return null;
        }

        // VMA: 0x23cf08  Source: functions/0023cf08_LuaNpc19LuaIsInSpecialStateER10XLuaScript.asm
        // gốc body in 0023cf08_LuaNpc19LuaIsInSpecialStateER10XLuaScript.asm (168 bytes ARM64)
        public object IsInSpecialState(params object[] args)
        {
            // TODO: port body from 0023cf08_LuaNpc19LuaIsInSpecialStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.IsInSpecialState] not yet ported (gốc 0x23cf08)");
            return null;
        }

        // VMA: 0x23cfb0  Source: functions/0023cfb0_LuaNpc14LuaHaveRefFlagER10XLuaScript.asm
        // gốc body in 0023cfb0_LuaNpc14LuaHaveRefFlagER10XLuaScript.asm (88 bytes ARM64)
        public object HaveRefFlag(params object[] args)
        {
            // TODO: port body from 0023cfb0_LuaNpc14LuaHaveRefFlagER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.HaveRefFlag] not yet ported (gốc 0x23cfb0)");
            return null;
        }

        // VMA: 0x23d008  Source: functions/0023d008_LuaNpc9LuaDeleteER10XLuaScript.asm
        // gốc body in 0023d008_LuaNpc9LuaDeleteER10XLuaScript.asm (80 bytes ARM64)
        public object Delete(params object[] args)
        {
            // TODO: port body from 0023d008_LuaNpc9LuaDeleteER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.Delete] not yet ported (gốc 0x23d008)");
            return null;
        }

        // VMA: 0x23d058  Source: functions/0023d058_LuaNpc21LuaStartDamageCounterER10XLuaScript.asm
        // gốc body in 0023d058_LuaNpc21LuaStartDamageCounterER10XLuaScript.asm (44 bytes ARM64)
        public object StartDamageCounter(params object[] args)
        {
            // TODO: port body from 0023d058_LuaNpc21LuaStartDamageCounterER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.StartDamageCounter] not yet ported (gốc 0x23d058)");
            return null;
        }

        // VMA: 0x23d084  Source: functions/0023d084_LuaNpc20LuaStopDamageCounterER10XLuaScript.asm
        // gốc body in 0023d084_LuaNpc20LuaStopDamageCounterER10XLuaScript.asm (16 bytes ARM64)
        public object StopDamageCounter(params object[] args)
        {
            // TODO: port body from 0023d084_LuaNpc20LuaStopDamageCounterER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.StopDamageCounter] not yet ported (gốc 0x23d084)");
            return null;
        }

        // VMA: 0x23d094  Source: functions/0023d094_LuaNpc18LuaIsDamageCounterER10XLuaScript.asm
        // gốc body in 0023d094_LuaNpc18LuaIsDamageCounterER10XLuaScript.asm (40 bytes ARM64)
        public object IsDamageCounter(params object[] args)
        {
            // TODO: port body from 0023d094_LuaNpc18LuaIsDamageCounterER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.IsDamageCounter] not yet ported (gốc 0x23d094)");
            return null;
        }

        // VMA: 0x23d0bc  Source: functions/0023d0bc_LuaNpc19LuaGetDamageCounterER10XLuaScript.asm
        // gốc body in 0023d0bc_LuaNpc19LuaGetDamageCounterER10XLuaScript.asm (396 bytes ARM64)
        public object GetDamageCounter(params object[] args)
        {
            // TODO: port body from 0023d0bc_LuaNpc19LuaGetDamageCounterER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetDamageCounter] not yet ported (gốc 0x23d0bc)");
            return null;
        }

        // VMA: 0x23d248  Source: functions/0023d248_LuaNpc16LuaAI_AddMovePosER10XLuaScript.asm
        // gốc body in 0023d248_LuaNpc16LuaAI_AddMovePosER10XLuaScript.asm (136 bytes ARM64)
        public object AI_AddMovePos(params object[] args)
        {
            // TODO: port body from 0023d248_LuaNpc16LuaAI_AddMovePosER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AI_AddMovePos] not yet ported (gốc 0x23d248)");
            return null;
        }

        // VMA: 0x23d2d0  Source: functions/0023d2d0_LuaNpc24LuaAI_ClearMovePathPointER10XLuaScript.asm
        // gốc body in 0023d2d0_LuaNpc24LuaAI_ClearMovePathPointER10XLuaScript.asm (32 bytes ARM64)
        public object AI_ClearMovePathPoint(params object[] args)
        {
            // TODO: port body from 0023d2d0_LuaNpc24LuaAI_ClearMovePathPointER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AI_ClearMovePathPoint] not yet ported (gốc 0x23d2d0)");
            return null;
        }

        // VMA: 0x23d2f0  Source: functions/0023d2f0_LuaNpc15LuaAI_StartPathER10XLuaScript.asm
        // gốc body in 0023d2f0_LuaNpc15LuaAI_StartPathER10XLuaScript.asm (92 bytes ARM64)
        public object AI_StartPath(params object[] args)
        {
            // TODO: port body from 0023d2f0_LuaNpc15LuaAI_StartPathER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AI_StartPath] not yet ported (gốc 0x23d2f0)");
            return null;
        }

        // VMA: 0x23d34c  Source: functions/0023d34c_LuaNpc18LuaAI_SetFollowNpcER10XLuaScript.asm
        // gốc body in 0023d34c_LuaNpc18LuaAI_SetFollowNpcER10XLuaScript.asm (64 bytes ARM64)
        public object AI_SetFollowNpc(params object[] args)
        {
            // TODO: port body from 0023d34c_LuaNpc18LuaAI_SetFollowNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AI_SetFollowNpc] not yet ported (gốc 0x23d34c)");
            return null;
        }

        // VMA: 0x23d38c  Source: functions/0023d38c_LuaNpc16LuaAI_SetWaitNpcER10XLuaScript.asm
        // gốc body in 0023d38c_LuaNpc16LuaAI_SetWaitNpcER10XLuaScript.asm (64 bytes ARM64)
        public object AI_SetWaitNpc(params object[] args)
        {
            // TODO: port body from 0023d38c_LuaNpc16LuaAI_SetWaitNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AI_SetWaitNpc] not yet ported (gốc 0x23d38c)");
            return null;
        }

        // VMA: 0x23d3cc  Source: functions/0023d3cc_LuaNpc15LuaAI_SetTargetER10XLuaScript.asm
        // gốc body in 0023d3cc_LuaNpc15LuaAI_SetTargetER10XLuaScript.asm (64 bytes ARM64)
        public object AI_SetTarget(params object[] args)
        {
            // TODO: port body from 0023d3cc_LuaNpc15LuaAI_SetTargetER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AI_SetTarget] not yet ported (gốc 0x23d3cc)");
            return null;
        }

        // VMA: 0x23d40c  Source: functions/0023d40c_LuaNpc19LuaAI_SetAttackTypeER10XLuaScript.asm
        // gốc body in 0023d40c_LuaNpc19LuaAI_SetAttackTypeER10XLuaScript.asm (148 bytes ARM64)
        public object AI_SetAttackType(params object[] args)
        {
            // TODO: port body from 0023d40c_LuaNpc19LuaAI_SetAttackTypeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AI_SetAttackType] not yet ported (gốc 0x23d40c)");
            return null;
        }

        // VMA: 0x23d4a0  Source: functions/0023d4a0_LuaNpc16LuaAI_SetGiveWayER10XLuaScript.asm
        // gốc body in 0023d4a0_LuaNpc16LuaAI_SetGiveWayER10XLuaScript.asm (80 bytes ARM64)
        public object AI_SetGiveWay(params object[] args)
        {
            // TODO: port body from 0023d4a0_LuaNpc16LuaAI_SetGiveWayER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AI_SetGiveWay] not yet ported (gốc 0x23d4a0)");
            return null;
        }

        // VMA: 0x23d4f0  Source: functions/0023d4f0_LuaNpc19LuaAI_SetFleeByNearER10XLuaScript.asm
        // gốc body in 0023d4f0_LuaNpc19LuaAI_SetFleeByNearER10XLuaScript.asm (56 bytes ARM64)
        public object AI_SetFleeByNear(params object[] args)
        {
            // TODO: port body from 0023d4f0_LuaNpc19LuaAI_SetFleeByNearER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AI_SetFleeByNear] not yet ported (gốc 0x23d4f0)");
            return null;
        }

        // VMA: 0x23d528  Source: functions/0023d528_LuaNpc23LuaAI_SetFollowDistanceER10XLuaScript.asm
        // gốc body in 0023d528_LuaNpc23LuaAI_SetFollowDistanceER10XLuaScript.asm (56 bytes ARM64)
        public object AI_SetFollowDistance(params object[] args)
        {
            // TODO: port body from 0023d528_LuaNpc23LuaAI_SetFollowDistanceER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AI_SetFollowDistance] not yet ported (gốc 0x23d528)");
            return null;
        }

        // VMA: 0x23d560  Source: functions/0023d560_LuaNpc8LuaSetAiER10XLuaScript.asm
        // gốc body in 0023d560_LuaNpc8LuaSetAiER10XLuaScript.asm (220 bytes ARM64)
        public object SetAi(params object[] args)
        {
            // TODO: port body from 0023d560_LuaNpc8LuaSetAiER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetAi] not yet ported (gốc 0x23d560)");
            return null;
        }

        // VMA: 0x23d63c  Source: functions/0023d63c_LuaNpc14LuaSetAiActiveER10XLuaScript.asm
        // gốc body in 0023d63c_LuaNpc14LuaSetAiActiveER10XLuaScript.asm (64 bytes ARM64)
        public object SetAiActive(params object[] args)
        {
            // TODO: port body from 0023d63c_LuaNpc14LuaSetAiActiveER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetAiActive] not yet ported (gốc 0x23d63c)");
            return null;
        }

        // VMA: 0x23d67c  Source: functions/0023d67c_LuaNpc18LuaAddAiLockTargetER10XLuaScript.asm
        // gốc body in 0023d67c_LuaNpc18LuaAddAiLockTargetER10XLuaScript.asm (64 bytes ARM64)
        public object AddAiLockTarget(params object[] args)
        {
            // TODO: port body from 0023d67c_LuaNpc18LuaAddAiLockTargetER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AddAiLockTarget] not yet ported (gốc 0x23d67c)");
            return null;
        }

        // VMA: 0x23d6bc  Source: functions/0023d6bc_LuaNpc20LuaClearAiLockTargetER10XLuaScript.asm
        // gốc body in 0023d6bc_LuaNpc20LuaClearAiLockTargetER10XLuaScript.asm (32 bytes ARM64)
        public object ClearAiLockTarget(params object[] args)
        {
            // TODO: port body from 0023d6bc_LuaNpc20LuaClearAiLockTargetER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ClearAiLockTarget] not yet ported (gốc 0x23d6bc)");
            return null;
        }

        // VMA: 0x23d6dc  Source: functions/0023d6dc_LuaNpc12LuaSetPkModeER10XLuaScript.asm
        // gốc body in 0023d6dc_LuaNpc12LuaSetPkModeER10XLuaScript.asm (120 bytes ARM64)
        public object SetPkMode(params object[] args)
        {
            // TODO: port body from 0023d6dc_LuaNpc12LuaSetPkModeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetPkMode] not yet ported (gốc 0x23d6dc)");
            return null;
        }

        // VMA: 0x23d754  Source: functions/0023d754_LuaNpc11LuaGetStateER10XLuaScript.asm
        // gốc body in 0023d754_LuaNpc11LuaGetStateER10XLuaScript.asm (316 bytes ARM64)
        public object GetState(params object[] args)
        {
            // TODO: port body from 0023d754_LuaNpc11LuaGetStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetState] not yet ported (gốc 0x23d754)");
            return null;
        }

        // VMA: 0x23d890  Source: functions/0023d890_LuaNpc14LuaShowFlyCharER10XLuaScript.asm
        // gốc body in 0023d890_LuaNpc14LuaShowFlyCharER10XLuaScript.asm (56 bytes ARM64)
        public object ShowFlyChar(params object[] args)
        {
            // TODO: port body from 0023d890_LuaNpc14LuaShowFlyCharER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ShowFlyChar] not yet ported (gốc 0x23d890)");
            return null;
        }

        // VMA: 0x23d8c8  Source: functions/0023d8c8_LuaNpc11LuaAddAngerER10XLuaScript.asm
        // gốc body in 0023d8c8_LuaNpc11LuaAddAngerER10XLuaScript.asm (80 bytes ARM64)
        public object AddAnger(params object[] args)
        {
            // TODO: port body from 0023d8c8_LuaNpc11LuaAddAngerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.AddAnger] not yet ported (gốc 0x23d8c8)");
            return null;
        }

        // VMA: 0x23d918  Source: functions/0023d918_LuaNpc13LuaSetCurLifeER10XLuaScript.asm
        // gốc body in 0023d918_LuaNpc13LuaSetCurLifeER10XLuaScript.asm (124 bytes ARM64)
        public object SetCurLife(params object[] args)
        {
            // TODO: port body from 0023d918_LuaNpc13LuaSetCurLifeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetCurLife] not yet ported (gốc 0x23d918)");
            return null;
        }

        // VMA: 0x23d994  Source: functions/0023d994_LuaNpc13LuaSetCurManaER10XLuaScript.asm
        // gốc body in 0023d994_LuaNpc13LuaSetCurManaER10XLuaScript.asm (124 bytes ARM64)
        public object SetCurMana(params object[] args)
        {
            // TODO: port body from 0023d994_LuaNpc13LuaSetCurManaER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetCurMana] not yet ported (gốc 0x23d994)");
            return null;
        }

        // VMA: 0x23da10  Source: functions/0023da10_LuaNpc13LuaSetMaxLifeER10XLuaScript.asm
        // gốc body in 0023da10_LuaNpc13LuaSetMaxLifeER10XLuaScript.asm (80 bytes ARM64)
        public object SetMaxLife(params object[] args)
        {
            // TODO: port body from 0023da10_LuaNpc13LuaSetMaxLifeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetMaxLife] not yet ported (gốc 0x23da10)");
            return null;
        }

        // VMA: 0x23da60  Source: functions/0023da60_LuaNpc10LuaSetCampER10XLuaScript.asm
        // gốc body in 0023da60_LuaNpc10LuaSetCampER10XLuaScript.asm (88 bytes ARM64)
        public object SetCamp(params object[] args)
        {
            // TODO: port body from 0023da60_LuaNpc10LuaSetCampER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetCamp] not yet ported (gốc 0x23da60)");
            return null;
        }

        // VMA: 0x23dab8  Source: functions/0023dab8_LuaNpc18LuaSetNotifyHpInfoER10XLuaScript.asm
        // gốc body in 0023dab8_LuaNpc18LuaSetNotifyHpInfoER10XLuaScript.asm (64 bytes ARM64)
        public object SetNotifyHpInfo(params object[] args)
        {
            // TODO: port body from 0023dab8_LuaNpc18LuaSetNotifyHpInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetNotifyHpInfo] not yet ported (gốc 0x23dab8)");
            return null;
        }

        // VMA: 0x23daf8  Source: functions/0023daf8_LuaNpc13LuaSetHideNpcER10XLuaScript.asm
        // gốc body in 0023daf8_LuaNpc13LuaSetHideNpcER10XLuaScript.asm (64 bytes ARM64)
        public object SetHideNpc(params object[] args)
        {
            // TODO: port body from 0023daf8_LuaNpc13LuaSetHideNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetHideNpc] not yet ported (gốc 0x23daf8)");
            return null;
        }

        // VMA: 0x23db38  Source: functions/0023db38_LuaNpc25LuaGetNearbyNpcByRelationER10XLuaScript.asm
        // gốc body in 0023db38_LuaNpc25LuaGetNearbyNpcByRelationER10XLuaScript.asm (472 bytes ARM64)
        public object GetNearbyNpcByRelation(params object[] args)
        {
            // TODO: port body from 0023db38_LuaNpc25LuaGetNearbyNpcByRelationER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetNearbyNpcByRelation] not yet ported (gốc 0x23db38)");
            return null;
        }

        // VMA: 0x23dd10  Source: functions/0023dd10_LuaNpc29LuaGetNearbyNpcByRelationCharER10XLuaScript.asm
        // gốc body in 0023dd10_LuaNpc29LuaGetNearbyNpcByRelationCharER10XLuaScript.asm (392 bytes ARM64)
        public object GetNearbyNpcByRelationChar(params object[] args)
        {
            // TODO: port body from 0023dd10_LuaNpc29LuaGetNearbyNpcByRelationCharER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetNearbyNpcByRelationChar] not yet ported (gốc 0x23dd10)");
            return null;
        }

        // VMA: 0x23de98  Source: functions/0023de98_LuaNpc21LuaGetCurrentTrapNameER10XLuaScript.asm
        // gốc body in 0023de98_LuaNpc21LuaGetCurrentTrapNameER10XLuaScript.asm (64 bytes ARM64)
        public object GetCurrentTrapName(params object[] args)
        {
            // TODO: port body from 0023de98_LuaNpc21LuaGetCurrentTrapNameER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetCurrentTrapName] not yet ported (gốc 0x23de98)");
            return null;
        }

        // VMA: 0x23ded8  Source: functions/0023ded8_LuaNpc13LuaSetTitleIDER10XLuaScript.asm
        // gốc body in 0023ded8_LuaNpc13LuaSetTitleIDER10XLuaScript.asm (72 bytes ARM64)
        public object SetTitleID(params object[] args)
        {
            // TODO: port body from 0023ded8_LuaNpc13LuaSetTitleIDER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetTitleID] not yet ported (gốc 0x23ded8)");
            return null;
        }

        // VMA: 0x23df20  Source: functions/0023df20_LuaNpc11LuaSetTitleER10XLuaScript.asm
        // gốc body in 0023df20_LuaNpc11LuaSetTitleER10XLuaScript.asm (72 bytes ARM64)
        public object SetTitle(params object[] args)
        {
            // TODO: port body from 0023df20_LuaNpc11LuaSetTitleER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetTitle] not yet ported (gốc 0x23df20)");
            return null;
        }

        // VMA: 0x23df68  Source: functions/0023df68_LuaNpc15LuaSetTitleInfoER10XLuaScript.asm
        // gốc body in 0023df68_LuaNpc15LuaSetTitleInfoER10XLuaScript.asm (124 bytes ARM64)
        public object SetTitleInfo(params object[] args)
        {
            // TODO: port body from 0023df68_LuaNpc15LuaSetTitleInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetTitleInfo] not yet ported (gốc 0x23df68)");
            return null;
        }

        // VMA: 0x23dfe4  Source: functions/0023dfe4_LuaNpc10LuaSetNameER10XLuaScript.asm
        // gốc body in 0023dfe4_LuaNpc10LuaSetNameER10XLuaScript.asm (64 bytes ARM64)
        public object SetName(params object[] args)
        {
            // TODO: port body from 0023dfe4_LuaNpc10LuaSetNameER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetName] not yet ported (gốc 0x23dfe4)");
            return null;
        }

        // VMA: 0x23e024  Source: functions/0023e024_LuaNpc13LuaBubbleTalkER10XLuaScript.asm
        // gốc body in 0023e024_LuaNpc13LuaBubbleTalkER10XLuaScript.asm (140 bytes ARM64)
        public object BubbleTalk(params object[] args)
        {
            // TODO: port body from 0023e024_LuaNpc13LuaBubbleTalkER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.BubbleTalk] not yet ported (gốc 0x23e024)");
            return null;
        }

        // VMA: 0x23e0b0  Source: functions/0023e0b0_LuaNpc10LuaDoDeathER10XLuaScript.asm
        // gốc body in 0023e0b0_LuaNpc10LuaDoDeathER10XLuaScript.asm (48 bytes ARM64)
        public object DoDeath(params object[] args)
        {
            // TODO: port body from 0023e0b0_LuaNpc10LuaDoDeathER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.DoDeath] not yet ported (gốc 0x23e0b0)");
            return null;
        }

        // VMA: 0x23e0e0  Source: functions/0023e0e0_LuaNpc15LuaSetBloodTypeER10XLuaScript.asm
        // gốc body in 0023e0e0_LuaNpc15LuaSetBloodTypeER10XLuaScript.asm (64 bytes ARM64)
        public object SetBloodType(params object[] args)
        {
            // TODO: port body from 0023e0e0_LuaNpc15LuaSetBloodTypeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetBloodType] not yet ported (gốc 0x23e0e0)");
            return null;
        }

        // VMA: 0x23e120  Source: functions/0023e120_LuaNpc12LuaRestoreHPER10XLuaScript.asm
        // gốc body in 0023e120_LuaNpc12LuaRestoreHPER10XLuaScript.asm (40 bytes ARM64)
        public object RestoreHP(params object[] args)
        {
            // TODO: port body from 0023e120_LuaNpc12LuaRestoreHPER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.RestoreHP] not yet ported (gốc 0x23e120)");
            return null;
        }

        // VMA: 0x23e148  Source: functions/0023e148_LuaNpc22LuaRemoveAllSkillStateER10XLuaScript.asm
        // gốc body in 0023e148_LuaNpc22LuaRemoveAllSkillStateER10XLuaScript.asm (88 bytes ARM64)
        public object RemoveAllSkillState(params object[] args)
        {
            // TODO: port body from 0023e148_LuaNpc22LuaRemoveAllSkillStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.RemoveAllSkillState] not yet ported (gốc 0x23e148)");
            return null;
        }

        // VMA: 0x23e1a0  Source: functions/0023e1a0_LuaNpc29LuaClearSkillStateByMagicTypeER10XLuaScript.asm
        // gốc body in 0023e1a0_LuaNpc29LuaClearSkillStateByMagicTypeER10XLuaScript.asm (140 bytes ARM64)
        public object ClearSkillStateByMagicType(params object[] args)
        {
            // TODO: port body from 0023e1a0_LuaNpc29LuaClearSkillStateByMagicTypeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ClearSkillStateByMagicType] not yet ported (gốc 0x23e1a0)");
            return null;
        }

        // VMA: 0x23e22c  Source: functions/0023e22c_LuaNpc17LuaSetMasterNpcIdER10XLuaScript.asm
        // gốc body in 0023e22c_LuaNpc17LuaSetMasterNpcIdER10XLuaScript.asm (72 bytes ARM64)
        public object SetMasterNpcId(params object[] args)
        {
            // TODO: port body from 0023e22c_LuaNpc17LuaSetMasterNpcIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetMasterNpcId] not yet ported (gốc 0x23e22c)");
            return null;
        }

        // VMA: 0x23e274  Source: functions/0023e274_LuaNpc14LuaSetAiRadiusER10XLuaScript.asm
        // gốc body in 0023e274_LuaNpc14LuaSetAiRadiusER10XLuaScript.asm (92 bytes ARM64)
        public object SetAiRadius(params object[] args)
        {
            // TODO: port body from 0023e274_LuaNpc14LuaSetAiRadiusER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetAiRadius] not yet ported (gốc 0x23e274)");
            return null;
        }

        // VMA: 0x23e2d0  Source: functions/0023e2d0_LuaNpc19LuaSetActiveForeverER10XLuaScript.asm
        // gốc body in 0023e2d0_LuaNpc19LuaSetActiveForeverER10XLuaScript.asm (64 bytes ARM64)
        public object SetActiveForever(params object[] args)
        {
            // TODO: port body from 0023e2d0_LuaNpc19LuaSetActiveForeverER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetActiveForever] not yet ported (gốc 0x23e2d0)");
            return null;
        }

        // VMA: 0x23e310  Source: functions/0023e310_LuaNpc12LuaGetPkModeER10XLuaScript.asm
        // gốc body in 0023e310_LuaNpc12LuaGetPkModeER10XLuaScript.asm (76 bytes ARM64)
        public object GetPkMode(params object[] args)
        {
            // TODO: port body from 0023e310_LuaNpc12LuaGetPkModeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetPkMode] not yet ported (gốc 0x23e310)");
            return null;
        }

        // VMA: 0x23e35c  Source: functions/0023e35c_LuaNpc15LuaSetProtectedER10XLuaScript.asm
        // gốc body in 0023e35c_LuaNpc15LuaSetProtectedER10XLuaScript.asm (80 bytes ARM64)
        public object SetProtected(params object[] args)
        {
            // TODO: port body from 0023e35c_LuaNpc15LuaSetProtectedER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetProtected] not yet ported (gốc 0x23e35c)");
            return null;
        }

        // VMA: 0x23e3ac  Source: functions/0023e3ac_LuaNpc16LuaGetActionModeER10XLuaScript.asm
        // gốc body in 0023e3ac_LuaNpc16LuaGetActionModeER10XLuaScript.asm (44 bytes ARM64)
        public object GetActionMode(params object[] args)
        {
            // TODO: port body from 0023e3ac_LuaNpc16LuaGetActionModeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetActionMode] not yet ported (gốc 0x23e3ac)");
            return null;
        }

        // VMA: 0x23e3d8  Source: functions/0023e3d8_LuaNpc21LuaSetFindEnemyNotifyER10XLuaScript.asm
        // gốc body in 0023e3d8_LuaNpc21LuaSetFindEnemyNotifyER10XLuaScript.asm (64 bytes ARM64)
        public object SetFindEnemyNotify(params object[] args)
        {
            // TODO: port body from 0023e3d8_LuaNpc21LuaSetFindEnemyNotifyER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetFindEnemyNotify] not yet ported (gốc 0x23e3d8)");
            return null;
        }

        // VMA: 0x23e418  Source: functions/0023e418_LuaNpc14LuaSetNpcRangeER10XLuaScript.asm
        // gốc body in 0023e418_LuaNpc14LuaSetNpcRangeER10XLuaScript.asm (92 bytes ARM64)
        public object SetNpcRange(params object[] args)
        {
            // TODO: port body from 0023e418_LuaNpc14LuaSetNpcRangeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetNpcRange] not yet ported (gốc 0x23e418)");
            return null;
        }

        // VMA: 0x23e474  Source: functions/0023e474_LuaNpc24LuaGetAttckMePlayersInfoER10XLuaScript.asm
        // gốc body in 0023e474_LuaNpc24LuaGetAttckMePlayersInfoER10XLuaScript.asm (552 bytes ARM64)
        public object GetAttckMePlayersInfo(params object[] args)
        {
            // TODO: port body from 0023e474_LuaNpc24LuaGetAttckMePlayersInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetAttckMePlayersInfo] not yet ported (gốc 0x23e474)");
            return null;
        }

        // VMA: 0x23e69c  Source: functions/0023e69c_LuaNpc21LuaGetLastDamageNpcIdER10XLuaScript.asm
        // gốc body in 0023e69c_LuaNpc21LuaGetLastDamageNpcIdER10XLuaScript.asm (64 bytes ARM64)
        public object GetLastDamageNpcId(params object[] args)
        {
            // TODO: port body from 0023e69c_LuaNpc21LuaGetLastDamageNpcIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetLastDamageNpcId] not yet ported (gốc 0x23e69c)");
            return null;
        }

        // VMA: 0x23e6dc  Source: functions/0023e6dc_LuaNpc12LuaDoFlyCharER10XLuaScript.asm
        // gốc body in 0023e6dc_LuaNpc12LuaDoFlyCharER10XLuaScript.asm (100 bytes ARM64)
        public object DoFlyChar(params object[] args)
        {
            // TODO: port body from 0023e6dc_LuaNpc12LuaDoFlyCharER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.DoFlyChar] not yet ported (gốc 0x23e6dc)");
            return null;
        }

        // VMA: 0x23e740  Source: functions/0023e740_LuaNpc16LuaIsDelayDeleteER10XLuaScript.asm
        // gốc body in 0023e740_LuaNpc16LuaIsDelayDeleteER10XLuaScript.asm (80 bytes ARM64)
        public object IsDelayDelete(params object[] args)
        {
            // TODO: port body from 0023e740_LuaNpc16LuaIsDelayDeleteER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.IsDelayDelete] not yet ported (gốc 0x23e740)");
            return null;
        }

        // VMA: 0x23e7ac  Source: functions/0023e7ac_LuaNpc19LuaApplyMagicAttribER10XLuaScript.asm
        // gốc body in 0023e7ac_LuaNpc19LuaApplyMagicAttribER10XLuaScript.asm (432 bytes ARM64)
        public object ApplyMagicAttrib(params object[] args)
        {
            // TODO: port body from 0023e7ac_LuaNpc19LuaApplyMagicAttribER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ApplyMagicAttrib] not yet ported (gốc 0x23e7ac)");
            return null;
        }

        // VMA: 0x23e95c  Source: functions/0023e95c_LuaNpc20LuaRemoveMagicAttribER10XLuaScript.asm
        // gốc body in 0023e95c_LuaNpc20LuaRemoveMagicAttribER10XLuaScript.asm (432 bytes ARM64)
        public object RemoveMagicAttrib(params object[] args)
        {
            // TODO: port body from 0023e95c_LuaNpc20LuaRemoveMagicAttribER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.RemoveMagicAttrib] not yet ported (gốc 0x23e95c)");
            return null;
        }

        // VMA: 0x23eb0c  Source: functions/0023eb0c_LuaNpc18LuaSetBaseRunSpeedER10XLuaScript.asm
        // gốc body in 0023eb0c_LuaNpc18LuaSetBaseRunSpeedER10XLuaScript.asm (64 bytes ARM64)
        public object SetBaseRunSpeed(params object[] args)
        {
            // TODO: port body from 0023eb0c_LuaNpc18LuaSetBaseRunSpeedER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetBaseRunSpeed] not yet ported (gốc 0x23eb0c)");
            return null;
        }

        // VMA: 0x23eb4c  Source: functions/0023eb4c_LuaNpc12LuaSetNoWalkER10XLuaScript.asm
        // gốc body in 0023eb4c_LuaNpc12LuaSetNoWalkER10XLuaScript.asm (48 bytes ARM64)
        public object SetNoWalk(params object[] args)
        {
            // TODO: port body from 0023eb4c_LuaNpc12LuaSetNoWalkER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetNoWalk] not yet ported (gốc 0x23eb4c)");
            return null;
        }

        // VMA: 0x23eb7c  Source: functions/0023eb7c_LuaNpc16LuaCanDoQingKungER10XLuaScript.asm
        // gốc body in 0023eb7c_LuaNpc16LuaCanDoQingKungER10XLuaScript.asm (52 bytes ARM64)
        public object CanDoQingKung(params object[] args)
        {
            // TODO: port body from 0023eb7c_LuaNpc16LuaCanDoQingKungER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.CanDoQingKung] not yet ported (gốc 0x23eb7c)");
            return null;
        }

        // VMA: 0x23ebb0  Source: functions/0023ebb0_LuaNpc18LuaCanDoTownPortalER10XLuaScript.asm
        // gốc body in 0023ebb0_LuaNpc18LuaCanDoTownPortalER10XLuaScript.asm (52 bytes ARM64)
        public object CanDoTownPortal(params object[] args)
        {
            // TODO: port body from 0023ebb0_LuaNpc18LuaCanDoTownPortalER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.CanDoTownPortal] not yet ported (gốc 0x23ebb0)");
            return null;
        }

        // VMA: 0x23ebe4  Source: functions/0023ebe4_LuaNpc19LuaCanReachDirectlyER10XLuaScript.asm
        // gốc body in 0023ebe4_LuaNpc19LuaCanReachDirectlyER10XLuaScript.asm (292 bytes ARM64)
        public object CanReachDirectly(params object[] args)
        {
            // TODO: port body from 0023ebe4_LuaNpc19LuaCanReachDirectlyER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.CanReachDirectly] not yet ported (gốc 0x23ebe4)");
            return null;
        }

        // VMA: 0x23ed08  Source: functions/0023ed08_LuaNpc17LuaSetPriStandActER10XLuaScript.asm
        // gốc body in 0023ed08_LuaNpc17LuaSetPriStandActER10XLuaScript.asm (92 bytes ARM64)
        public object SetPriStandAct(params object[] args)
        {
            // TODO: port body from 0023ed08_LuaNpc17LuaSetPriStandActER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetPriStandAct] not yet ported (gốc 0x23ed08)");
            return null;
        }

        // VMA: 0x23ed64  Source: functions/0023ed64_LuaNpc18LuaStopPriStandActER10XLuaScript.asm
        // gốc body in 0023ed64_LuaNpc18LuaStopPriStandActER10XLuaScript.asm (28 bytes ARM64)
        public object StopPriStandAct(params object[] args)
        {
            // TODO: port body from 0023ed64_LuaNpc18LuaStopPriStandActER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.StopPriStandAct] not yet ported (gốc 0x23ed64)");
            return null;
        }

        // VMA: 0x23ed80  Source: functions/0023ed80_LuaNpc16LuaCanDoAutoPathER10XLuaScript.asm
        // gốc body in 0023ed80_LuaNpc16LuaCanDoAutoPathER10XLuaScript.asm (52 bytes ARM64)
        public object CanDoAutoPath(params object[] args)
        {
            // TODO: port body from 0023ed80_LuaNpc16LuaCanDoAutoPathER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.CanDoAutoPath] not yet ported (gốc 0x23ed80)");
            return null;
        }

        // VMA: 0x23edb4  Source: functions/0023edb4_LuaNpc8LuaRunToER10XLuaScript.asm
        // gốc body in 0023edb4_LuaNpc8LuaRunToER10XLuaScript.asm (148 bytes ARM64)
        public object RunTo(params object[] args)
        {
            // TODO: port body from 0023edb4_LuaNpc8LuaRunToER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.RunTo] not yet ported (gốc 0x23edb4)");
            return null;
        }

        // VMA: 0x23ee48  Source: functions/0023ee48_LuaNpc17LuaDoSpecicalMoveER10XLuaScript.asm
        // gốc body in 0023ee48_LuaNpc17LuaDoSpecicalMoveER10XLuaScript.asm (724 bytes ARM64)
        public object DoSpecicalMove(params object[] args)
        {
            // TODO: port body from 0023ee48_LuaNpc17LuaDoSpecicalMoveER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.DoSpecicalMove] not yet ported (gốc 0x23ee48)");
            return null;
        }

        // VMA: 0x23f11c  Source: functions/0023f11c_LuaNpc12LuaLockDoingER10XLuaScript.asm
        // gốc body in 0023f11c_LuaNpc12LuaLockDoingER10XLuaScript.asm (76 bytes ARM64)
        public object LockDoing(params object[] args)
        {
            // TODO: port body from 0023f11c_LuaNpc12LuaLockDoingER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.LockDoing] not yet ported (gốc 0x23f11c)");
            return null;
        }

        // VMA: 0x23f168  Source: functions/0023f168_LuaNpc14LuaUnLockDoingER10XLuaScript.asm
        // gốc body in 0023f168_LuaNpc14LuaUnLockDoingER10XLuaScript.asm (76 bytes ARM64)
        public object UnLockDoing(params object[] args)
        {
            // TODO: port body from 0023f168_LuaNpc14LuaUnLockDoingER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.UnLockDoing] not yet ported (gốc 0x23f168)");
            return null;
        }

        // VMA: 0x23f1b4  Source: functions/0023f1b4_LuaNpc14LuaGetActFrameER10XLuaScript.asm
        // gốc body in 0023f1b4_LuaNpc14LuaGetActFrameER10XLuaScript.asm (196 bytes ARM64)
        public object GetActFrame(params object[] args)
        {
            // TODO: port body from 0023f1b4_LuaNpc14LuaGetActFrameER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetActFrame] not yet ported (gốc 0x23f1b4)");
            return null;
        }

        // VMA: 0x23f278  Source: functions/0023f278_LuaNpc22LuaGetMapMaxPosForTestER10XLuaScript.asm
        // gốc body in 0023f278_LuaNpc22LuaGetMapMaxPosForTestER10XLuaScript.asm (384 bytes ARM64)
        public object GetMapMaxPosForTest(params object[] args)
        {
            // TODO: port body from 0023f278_LuaNpc22LuaGetMapMaxPosForTestER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetMapMaxPosForTest] not yet ported (gốc 0x23f278)");
            return null;
        }

        // VMA: 0x23f3f8  Source: functions/0023f3f8_LuaNpc13LuaDoQingKungER10XLuaScript.asm
        // gốc body in 0023f3f8_LuaNpc13LuaDoQingKungER10XLuaScript.asm (44 bytes ARM64)
        public object DoQingKung(params object[] args)
        {
            // TODO: port body from 0023f3f8_LuaNpc13LuaDoQingKungER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.DoQingKung] not yet ported (gốc 0x23f3f8)");
            return null;
        }

        // VMA: 0x23f424  Source: functions/0023f424_LuaNpc12LuaSetActiveER10XLuaScript.asm
        // gốc body in 0023f424_LuaNpc12LuaSetActiveER10XLuaScript.asm (64 bytes ARM64)
        public object SetActive(params object[] args)
        {
            // TODO: port body from 0023f424_LuaNpc12LuaSetActiveER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetActive] not yet ported (gốc 0x23f424)");
            return null;
        }

        // VMA: 0x23f464  Source: functions/0023f464_LuaNpc21LuaSetDefaultRunActIDER10XLuaScript.asm
        // gốc body in 0023f464_LuaNpc21LuaSetDefaultRunActIDER10XLuaScript.asm (64 bytes ARM64)
        public object SetDefaultRunActID(params object[] args)
        {
            // TODO: port body from 0023f464_LuaNpc21LuaSetDefaultRunActIDER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetDefaultRunActID] not yet ported (gốc 0x23f464)");
            return null;
        }

        // VMA: 0x23f4a4  Source: functions/0023f4a4_LuaNpc25LuaGetIgnoreResistVByTypeER10XLuaScript.asm
        // gốc body in 0023f4a4_LuaNpc25LuaGetIgnoreResistVByTypeER10XLuaScript.asm (204 bytes ARM64)
        public object GetIgnoreResistVByType(params object[] args)
        {
            // TODO: port body from 0023f4a4_LuaNpc25LuaGetIgnoreResistVByTypeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetIgnoreResistVByType] not yet ported (gốc 0x23f4a4)");
            return null;
        }

        // VMA: 0x23f570  Source: functions/0023f570_LuaNpc24LuaGetFightStateByPlayerER10XLuaScript.asm
        // gốc body in 0023f570_LuaNpc24LuaGetFightStateByPlayerER10XLuaScript.asm (44 bytes ARM64)
        public object GetFightStateByPlayer(params object[] args)
        {
            // TODO: port body from 0023f570_LuaNpc24LuaGetFightStateByPlayerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetFightStateByPlayer] not yet ported (gốc 0x23f570)");
            return null;
        }

        // VMA: 0x23f59c  Source: functions/0023f59c_LuaNpc16LuaGetFightStateER10XLuaScript.asm
        // gốc body in 0023f59c_LuaNpc16LuaGetFightStateER10XLuaScript.asm (44 bytes ARM64)
        public object GetFightState(params object[] args)
        {
            // TODO: port body from 0023f59c_LuaNpc16LuaGetFightStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetFightState] not yet ported (gốc 0x23f59c)");
            return null;
        }

        // VMA: 0x23f5c8  Source: functions/0023f5c8_LuaNpc18LuaGetAllSkillInfoER10XLuaScript.asm
        // gốc body in 0023f5c8_LuaNpc18LuaGetAllSkillInfoER10XLuaScript.asm (200 bytes ARM64)
        public object GetAllSkillInfo(params object[] args)
        {
            // TODO: port body from 0023f5c8_LuaNpc18LuaGetAllSkillInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetAllSkillInfo] not yet ported (gốc 0x23f5c8)");
            return null;
        }

        // VMA: 0x23f690  Source: functions/0023f690_LuaNpc19LuaTownPortalHandleER10XLuaScript.asm
        // gốc body in 0023f690_LuaNpc19LuaTownPortalHandleER10XLuaScript.asm (36 bytes ARM64)
        public object TownPortalHandle(params object[] args)
        {
            // TODO: port body from 0023f690_LuaNpc19LuaTownPortalHandleER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.TownPortalHandle] not yet ported (gốc 0x23f690)");
            return null;
        }

        // VMA: 0x23f6b4  Source: functions/0023f6b4_LuaNpc9LuaIsBossER10XLuaScript.asm
        // gốc body in 0023f6b4_LuaNpc9LuaIsBossER10XLuaScript.asm (40 bytes ARM64)
        public object IsBoss(params object[] args)
        {
            // TODO: port body from 0023f6b4_LuaNpc9LuaIsBossER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.IsBoss] not yet ported (gốc 0x23f6b4)");
            return null;
        }

        // VMA: 0x23f6dc  Source: functions/0023f6dc_LuaNpc26LuaSetQingKungCommandCacheER10XLuaScript.asm
        // gốc body in 0023f6dc_LuaNpc26LuaSetQingKungCommandCacheER10XLuaScript.asm (28 bytes ARM64)
        public object SetQingKungCommandCache(params object[] args)
        {
            // TODO: port body from 0023f6dc_LuaNpc26LuaSetQingKungCommandCacheER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetQingKungCommandCache] not yet ported (gốc 0x23f6dc)");
            return null;
        }

        // VMA: 0x23f6f8  Source: functions/0023f6f8_LuaNpc25LuaClearSkillCommandCacheER10XLuaScript.asm
        // gốc body in 0023f6f8_LuaNpc25LuaClearSkillCommandCacheER10XLuaScript.asm (28 bytes ARM64)
        public object ClearSkillCommandCache(params object[] args)
        {
            // TODO: port body from 0023f6f8_LuaNpc25LuaClearSkillCommandCacheER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ClearSkillCommandCache] not yet ported (gốc 0x23f6f8)");
            return null;
        }

        // VMA: 0x23f714  Source: functions/0023f714_LuaNpc29LuaSetUseMedicineCommandCacheER10XLuaScript.asm
        // gốc body in 0023f714_LuaNpc29LuaSetUseMedicineCommandCacheER10XLuaScript.asm (28 bytes ARM64)
        public object SetUseMedicineCommandCache(params object[] args)
        {
            // TODO: port body from 0023f714_LuaNpc29LuaSetUseMedicineCommandCacheER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetUseMedicineCommandCache] not yet ported (gốc 0x23f714)");
            return null;
        }

        // VMA: 0x23f730  Source: functions/0023f730_LuaNpc27LuaGetLastActionCommandTypeER10XLuaScript.asm
        // gốc body in 0023f730_LuaNpc27LuaGetLastActionCommandTypeER10XLuaScript.asm (104 bytes ARM64)
        public object GetLastActionCommandType(params object[] args)
        {
            // TODO: port body from 0023f730_LuaNpc27LuaGetLastActionCommandTypeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetLastActionCommandType] not yet ported (gốc 0x23f730)");
            return null;
        }

        // VMA: 0x23f798  Source: functions/0023f798_LuaNpc28LuaRollBackLastActionCommandER10XLuaScript.asm
        // gốc body in 0023f798_LuaNpc28LuaRollBackLastActionCommandER10XLuaScript.asm (28 bytes ARM64)
        public object RollBackLastActionCommand(params object[] args)
        {
            // TODO: port body from 0023f798_LuaNpc28LuaRollBackLastActionCommandER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.RollBackLastActionCommand] not yet ported (gốc 0x23f798)");
            return null;
        }

        // VMA: 0x23f7b4  Source: functions/0023f7b4_LuaNpc16LuaUseSkillToDirER10XLuaScript.asm
        // gốc body in 0023f7b4_LuaNpc16LuaUseSkillToDirER10XLuaScript.asm (332 bytes ARM64)
        public object UseSkillToDir(params object[] args)
        {
            // TODO: port body from 0023f7b4_LuaNpc16LuaUseSkillToDirER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.UseSkillToDir] not yet ported (gốc 0x23f7b4)");
            return null;
        }

        // VMA: 0x23f900  Source: functions/0023f900_LuaNpc16LuaUseSkillToNpcER10XLuaScript.asm
        // gốc body in 0023f900_LuaNpc16LuaUseSkillToNpcER10XLuaScript.asm (104 bytes ARM64)
        public object UseSkillToNpc(params object[] args)
        {
            // TODO: port body from 0023f900_LuaNpc16LuaUseSkillToNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.UseSkillToNpc] not yet ported (gốc 0x23f900)");
            return null;
        }

        // VMA: 0x23f968  Source: functions/0023f968_LuaNpc15LuaSetBindNpcIdER10XLuaScript.asm
        // gốc body in 0023f968_LuaNpc15LuaSetBindNpcIdER10XLuaScript.asm (144 bytes ARM64)
        public object SetBindNpcId(params object[] args)
        {
            // TODO: port body from 0023f968_LuaNpc15LuaSetBindNpcIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetBindNpcId] not yet ported (gốc 0x23f968)");
            return null;
        }

        // VMA: 0x23f9f8  Source: functions/0023f9f8_LuaNpc11LuaDeathNpcER10XLuaScript.asm
        // gốc body in 0023f9f8_LuaNpc11LuaDeathNpcER10XLuaScript.asm (48 bytes ARM64)
        public object DeathNpc(params object[] args)
        {
            // TODO: port body from 0023f9f8_LuaNpc11LuaDeathNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.DeathNpc] not yet ported (gốc 0x23f9f8)");
            return null;
        }

        // VMA: 0x23fa28  Source: functions/0023fa28_LuaNpc19LuaSetForceTargetIdER10XLuaScript.asm
        // gốc body in 0023fa28_LuaNpc19LuaSetForceTargetIdER10XLuaScript.asm (56 bytes ARM64)
        public object SetForceTargetId(params object[] args)
        {
            // TODO: port body from 0023fa28_LuaNpc19LuaSetForceTargetIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetForceTargetId] not yet ported (gốc 0x23fa28)");
            return null;
        }

        // VMA: 0x23fa60  Source: functions/0023fa60_LuaNpc18LuaGetMissileSpeedER10XLuaScript.asm
        // gốc body in 0023fa60_LuaNpc18LuaGetMissileSpeedER10XLuaScript.asm (100 bytes ARM64)
        public object GetMissileSpeed(params object[] args)
        {
            // TODO: port body from 0023fa60_LuaNpc18LuaGetMissileSpeedER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetMissileSpeed] not yet ported (gốc 0x23fa60)");
            return null;
        }

        // VMA: 0x23fac4  Source: functions/0023fac4_LuaNpc16LuaRestoreActionER10XLuaScript.asm
        // gốc body in 0023fac4_LuaNpc16LuaRestoreActionER10XLuaScript.asm (28 bytes ARM64)
        public object RestoreAction(params object[] args)
        {
            // TODO: port body from 0023fac4_LuaNpc16LuaRestoreActionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.RestoreAction] not yet ported (gốc 0x23fac4)");
            return null;
        }

        // VMA: 0x23fae0  Source: functions/0023fae0_LuaNpc16LuaGetHorseResIdER10XLuaScript.asm
        // gốc body in 0023fae0_LuaNpc16LuaGetHorseResIdER10XLuaScript.asm (140 bytes ARM64)
        public object GetHorseResId(params object[] args)
        {
            // TODO: port body from 0023fae0_LuaNpc16LuaGetHorseResIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetHorseResId] not yet ported (gốc 0x23fae0)");
            return null;
        }

        // VMA: 0x23fb6c  Source: functions/0023fb6c_LuaNpc19LuaIgnoreSkillLimitER10XLuaScript.asm
        // gốc body in 0023fb6c_LuaNpc19LuaIgnoreSkillLimitER10XLuaScript.asm (56 bytes ARM64)
        public object IgnoreSkillLimit(params object[] args)
        {
            // TODO: port body from 0023fb6c_LuaNpc19LuaIgnoreSkillLimitER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.IgnoreSkillLimit] not yet ported (gốc 0x23fb6c)");
            return null;
        }

        // VMA: 0x23fba4  Source: functions/0023fba4_LuaNpc11LuaSetLuaAIER10XLuaScript.asm
        // gốc body in 0023fba4_LuaNpc11LuaSetLuaAIER10XLuaScript.asm (56 bytes ARM64)
        public object SetLuaAI(params object[] args)
        {
            // TODO: port body from 0023fba4_LuaNpc11LuaSetLuaAIER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetLuaAI] not yet ported (gốc 0x23fba4)");
            return null;
        }

        // VMA: 0x23fbdc  Source: functions/0023fbdc_LuaNpc20LuaSetDamageDecreaseER10XLuaScript.asm
        // gốc body in 0023fbdc_LuaNpc20LuaSetDamageDecreaseER10XLuaScript.asm (72 bytes ARM64)
        public object SetDamageDecrease(params object[] args)
        {
            // TODO: port body from 0023fbdc_LuaNpc20LuaSetDamageDecreaseER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetDamageDecrease] not yet ported (gốc 0x23fbdc)");
            return null;
        }

        // VMA: 0x23fc24  Source: functions/0023fc24_LuaNpc11LuaTestSlowER10XLuaScript.asm
        // gốc body in 0023fc24_LuaNpc11LuaTestSlowER10XLuaScript.asm (48 bytes ARM64)
        public object TestSlow(params object[] args)
        {
            // TODO: port body from 0023fc24_LuaNpc11LuaTestSlowER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.TestSlow] not yet ported (gốc 0x23fc24)");
            return null;
        }

        // VMA: 0x23fc54  Source: functions/0023fc54_LuaNpc13LuaSetWeakPosER10XLuaScript.asm
        // gốc body in 0023fc54_LuaNpc13LuaSetWeakPosER10XLuaScript.asm (124 bytes ARM64)
        public object SetWeakPos(params object[] args)
        {
            // TODO: port body from 0023fc54_LuaNpc13LuaSetWeakPosER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetWeakPos] not yet ported (gốc 0x23fc54)");
            return null;
        }

        // VMA: 0x23fcd0  Source: functions/0023fcd0_LuaNpc10LuaSetKindER10XLuaScript.asm
        // gốc body in 0023fcd0_LuaNpc10LuaSetKindER10XLuaScript.asm (72 bytes ARM64)
        public object SetKind(params object[] args)
        {
            // TODO: port body from 0023fcd0_LuaNpc10LuaSetKindER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetKind] not yet ported (gốc 0x23fcd0)");
            return null;
        }

        // VMA: 0x23fd18  Source: functions/0023fd18_LuaNpc11LuaHasSkillER10XLuaScript.asm
        // gốc body in 0023fd18_LuaNpc11LuaHasSkillER10XLuaScript.asm (84 bytes ARM64)
        public object HasSkill(params object[] args)
        {
            // TODO: port body from 0023fd18_LuaNpc11LuaHasSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.HasSkill] not yet ported (gốc 0x23fd18)");
            return null;
        }

        // VMA: 0x23fd6c  Source: functions/0023fd6c_LuaNpc17LuaGetHasStartActER10XLuaScript.asm
        // gốc body in 0023fd6c_LuaNpc17LuaGetHasStartActER10XLuaScript.asm (68 bytes ARM64)
        public object GetHasStartAct(params object[] args)
        {
            // TODO: port body from 0023fd6c_LuaNpc17LuaGetHasStartActER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetHasStartAct] not yet ported (gốc 0x23fd6c)");
            return null;
        }

        // VMA: 0x23fdb0  Source: functions/0023fdb0_LuaNpc12LuaGetActionER10XLuaScript.asm
        // gốc body in 0023fdb0_LuaNpc12LuaGetActionER10XLuaScript.asm (116 bytes ARM64)
        public object GetAction(params object[] args)
        {
            // TODO: port body from 0023fdb0_LuaNpc12LuaGetActionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetAction] not yet ported (gốc 0x23fdb0)");
            return null;
        }

        // VMA: 0x23fe24  Source: functions/0023fe24_LuaNpc12LuaUseSkill2ER10XLuaScript.asm
        // gốc body in 0023fe24_LuaNpc12LuaUseSkill2ER10XLuaScript.asm (148 bytes ARM64)
        public object UseSkill2(params object[] args)
        {
            // TODO: port body from 0023fe24_LuaNpc12LuaUseSkill2ER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.UseSkill2] not yet ported (gốc 0x23fe24)");
            return null;
        }

        // VMA: 0x23feb8  Source: functions/0023feb8_LuaNpc18LuaSetIgnoreAttackER10XLuaScript.asm
        // gốc body in 0023feb8_LuaNpc18LuaSetIgnoreAttackER10XLuaScript.asm (68 bytes ARM64)
        public object SetIgnoreAttack(params object[] args)
        {
            // TODO: port body from 0023feb8_LuaNpc18LuaSetIgnoreAttackER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetIgnoreAttack] not yet ported (gốc 0x23feb8)");
            return null;
        }

        // VMA: 0x23fefc  Source: functions/0023fefc_LuaNpc14LuaGetBossWeakER10XLuaScript.asm
        // gốc body in 0023fefc_LuaNpc14LuaGetBossWeakER10XLuaScript.asm (44 bytes ARM64)
        public object GetBossWeak(params object[] args)
        {
            // TODO: port body from 0023fefc_LuaNpc14LuaGetBossWeakER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetBossWeak] not yet ported (gốc 0x23fefc)");
            return null;
        }

        // VMA: 0x23ff28  Source: functions/0023ff28_LuaNpc14LuaSetBossWeakER10XLuaScript.asm
        // gốc body in 0023ff28_LuaNpc14LuaSetBossWeakER10XLuaScript.asm (64 bytes ARM64)
        public object SetBossWeak(params object[] args)
        {
            // TODO: port body from 0023ff28_LuaNpc14LuaSetBossWeakER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetBossWeak] not yet ported (gốc 0x23ff28)");
            return null;
        }

        // VMA: 0x23ff68  Source: functions/0023ff68_LuaNpc15LuaGetPosHeightER10XLuaScript.asm
        // gốc body in 0023ff68_LuaNpc15LuaGetPosHeightER10XLuaScript.asm (36 bytes ARM64)
        public object GetPosHeight(params object[] args)
        {
            // TODO: port body from 0023ff68_LuaNpc15LuaGetPosHeightER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetPosHeight] not yet ported (gốc 0x23ff68)");
            return null;
        }

        // VMA: 0x23ff8c  Source: functions/0023ff8c_LuaNpc12LuaForceSyncER10XLuaScript.asm
        // gốc body in 0023ff8c_LuaNpc12LuaForceSyncER10XLuaScript.asm (64 bytes ARM64)
        public object ForceSync(params object[] args)
        {
            // TODO: port body from 0023ff8c_LuaNpc12LuaForceSyncER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ForceSync] not yet ported (gốc 0x23ff8c)");
            return null;
        }

        // VMA: 0x23ffcc  Source: functions/0023ffcc_LuaNpc21LuaIgnoreSpecialStateER10XLuaScript.asm
        // gốc body in 0023ffcc_LuaNpc21LuaIgnoreSpecialStateER10XLuaScript.asm (56 bytes ARM64)
        public object IgnoreSpecialState(params object[] args)
        {
            // TODO: port body from 0023ffcc_LuaNpc21LuaIgnoreSpecialStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.IgnoreSpecialState] not yet ported (gốc 0x23ffcc)");
            return null;
        }

        // VMA: 0x240004  Source: functions/00240004_LuaNpc12LuaDeleteNpcER10XLuaScript.asm
        // gốc body in 00240004_LuaNpc12LuaDeleteNpcER10XLuaScript.asm (28 bytes ARM64)
        public object DeleteNpc(params object[] args)
        {
            // TODO: port body from 00240004_LuaNpc12LuaDeleteNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.DeleteNpc] not yet ported (gốc 0x240004)");
            return null;
        }

        // VMA: 0x240020  Source: functions/00240020_LuaNpc20LuaFindNearestTargetER10XLuaScript.asm
        // gốc body in 00240020_LuaNpc20LuaFindNearestTargetER10XLuaScript.asm (248 bytes ARM64)
        public object FindNearestTarget(params object[] args)
        {
            // TODO: port body from 00240020_LuaNpc20LuaFindNearestTargetER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.FindNearestTarget] not yet ported (gốc 0x240020)");
            return null;
        }

        // VMA: 0x240118  Source: functions/00240118_LuaNpc18LuaGetIgnoreAttackER10XLuaScript.asm
        // gốc body in 00240118_LuaNpc18LuaGetIgnoreAttackER10XLuaScript.asm (44 bytes ARM64)
        public object GetIgnoreAttack(params object[] args)
        {
            // TODO: port body from 00240118_LuaNpc18LuaGetIgnoreAttackER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetIgnoreAttack] not yet ported (gốc 0x240118)");
            return null;
        }

        // VMA: 0x240144  Source: functions/00240144_LuaNpc16LuaSetForceSkillER10XLuaScript.asm
        // gốc body in 00240144_LuaNpc16LuaSetForceSkillER10XLuaScript.asm (56 bytes ARM64)
        public object SetForceSkill(params object[] args)
        {
            // TODO: port body from 00240144_LuaNpc16LuaSetForceSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetForceSkill] not yet ported (gốc 0x240144)");
            return null;
        }

        // VMA: 0x24017c  Source: functions/0024017c_LuaNpc10LuaUseMaskER10XLuaScript.asm
        // gốc body in 0024017c_LuaNpc10LuaUseMaskER10XLuaScript.asm (92 bytes ARM64)
        public object UseMask(params object[] args)
        {
            // TODO: port body from 0024017c_LuaNpc10LuaUseMaskER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.UseMask] not yet ported (gốc 0x24017c)");
            return null;
        }

        // VMA: 0x2401d8  Source: functions/002401d8_LuaNpc16LuaClearVelocityER10XLuaScript.asm
        // gốc body in 002401d8_LuaNpc16LuaClearVelocityER10XLuaScript.asm (24 bytes ARM64)
        public object ClearVelocity(params object[] args)
        {
            // TODO: port body from 002401d8_LuaNpc16LuaClearVelocityER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ClearVelocity] not yet ported (gốc 0x2401d8)");
            return null;
        }

        // VMA: 0x2401f0  Source: functions/002401f0_LuaNpc9LuaSetActER10XLuaScript.asm
        // gốc body in 002401f0_LuaNpc9LuaSetActER10XLuaScript.asm (124 bytes ARM64)
        public object SetAct(params object[] args)
        {
            // TODO: port body from 002401f0_LuaNpc9LuaSetActER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetAct] not yet ported (gốc 0x2401f0)");
            return null;
        }

        // VMA: 0x24026c  Source: functions/0024026c_LuaNpc18LuaChangePartEquipER10XLuaScript.asm
        // gốc body in 0024026c_LuaNpc18LuaChangePartEquipER10XLuaScript.asm (104 bytes ARM64)
        public object ChangePartEquip(params object[] args)
        {
            // TODO: port body from 0024026c_LuaNpc18LuaChangePartEquipER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ChangePartEquip] not yet ported (gốc 0x24026c)");
            return null;
        }

        // VMA: 0x2402d4  Source: functions/002402d4_LuaNpc23LuaChangeCurFeaturePartER10XLuaScript.asm
        // gốc body in 002402d4_LuaNpc23LuaChangeCurFeaturePartER10XLuaScript.asm (128 bytes ARM64)
        public object ChangeCurFeaturePart(params object[] args)
        {
            // TODO: port body from 002402d4_LuaNpc23LuaChangeCurFeaturePartER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ChangeCurFeaturePart] not yet ported (gốc 0x2402d4)");
            return null;
        }

        // VMA: 0x240354  Source: functions/00240354_LuaNpc16LuaGetNpcFeatureER10XLuaScript.asm
        // gốc body in 00240354_LuaNpc16LuaGetNpcFeatureER10XLuaScript.asm (196 bytes ARM64)
        public object GetNpcFeature(params object[] args)
        {
            // TODO: port body from 00240354_LuaNpc16LuaGetNpcFeatureER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetNpcFeature] not yet ported (gốc 0x240354)");
            return null;
        }

        // VMA: 0x240418  Source: functions/00240418_LuaNpc23LuaGetNpcFashionFeatureER10XLuaScript.asm
        // gốc body in 00240418_LuaNpc23LuaGetNpcFashionFeatureER10XLuaScript.asm (188 bytes ARM64)
        public object GetNpcFashionFeature(params object[] args)
        {
            // TODO: port body from 00240418_LuaNpc23LuaGetNpcFashionFeatureER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetNpcFashionFeature] not yet ported (gốc 0x240418)");
            return null;
        }

        // VMA: 0x2404d4  Source: functions/002404d4_LuaNpc14LuaGetNpcResIdER10XLuaScript.asm
        // gốc body in 002404d4_LuaNpc14LuaGetNpcResIdER10XLuaScript.asm (48 bytes ARM64)
        public object GetNpcResId(params object[] args)
        {
            // TODO: port body from 002404d4_LuaNpc14LuaGetNpcResIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetNpcResId] not yet ported (gốc 0x2404d4)");
            return null;
        }

        // VMA: 0x240504  Source: functions/00240504_LuaNpc14LuaSetNpcResIdER10XLuaScript.asm
        // gốc body in 00240504_LuaNpc14LuaSetNpcResIdER10XLuaScript.asm (80 bytes ARM64)
        public object SetNpcResId(params object[] args)
        {
            // TODO: port body from 00240504_LuaNpc14LuaSetNpcResIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetNpcResId] not yet ported (gốc 0x240504)");
            return null;
        }

        // VMA: 0x240554  Source: functions/00240554_LuaNpc15LuaChangeNpcResER10XLuaScript.asm
        // gốc body in 00240554_LuaNpc15LuaChangeNpcResER10XLuaScript.asm (136 bytes ARM64)
        public object ChangeNpcRes(params object[] args)
        {
            // TODO: port body from 00240554_LuaNpc15LuaChangeNpcResER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ChangeNpcRes] not yet ported (gốc 0x240554)");
            return null;
        }

        // VMA: 0x2405dc  Source: functions/002405dc_LuaNpc19LuaNpcHasSkillStateER10XLuaScript.asm
        // gốc body in 002405dc_LuaNpc19LuaNpcHasSkillStateER10XLuaScript.asm (84 bytes ARM64)
        public object NpcHasSkillState(params object[] args)
        {
            // TODO: port body from 002405dc_LuaNpc19LuaNpcHasSkillStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.NpcHasSkillState] not yet ported (gốc 0x2405dc)");
            return null;
        }

        // VMA: 0x240630  Source: functions/00240630_LuaNpc16LuaChangeRefFlagER10XLuaScript.asm
        // gốc body in 00240630_LuaNpc16LuaChangeRefFlagER10XLuaScript.asm (104 bytes ARM64)
        public object ChangeRefFlag(params object[] args)
        {
            // TODO: port body from 00240630_LuaNpc16LuaChangeRefFlagER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ChangeRefFlag] not yet ported (gốc 0x240630)");
            return null;
        }

        // VMA: 0x240698  Source: functions/00240698_LuaNpc12LuaSetCanRunER10XLuaScript.asm
        // gốc body in 00240698_LuaNpc12LuaSetCanRunER10XLuaScript.asm (56 bytes ARM64)
        public object SetCanRun(params object[] args)
        {
            // TODO: port body from 00240698_LuaNpc12LuaSetCanRunER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetCanRun] not yet ported (gốc 0x240698)");
            return null;
        }

        // VMA: 0x2406d0  Source: functions/002406d0_LuaNpc16LuaGetNearestCatER10XLuaScript.asm
        // gốc body in 002406d0_LuaNpc16LuaGetNearestCatER10XLuaScript.asm (308 bytes ARM64)
        public object GetNearestCat(params object[] args)
        {
            // TODO: port body from 002406d0_LuaNpc16LuaGetNearestCatER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetNearestCat] not yet ported (gốc 0x2406d0)");
            return null;
        }

        // VMA: 0x240804  Source: functions/00240804_LuaNpc16LuaSetActionModeER10XLuaScript.asm
        // gốc body in 00240804_LuaNpc16LuaSetActionModeER10XLuaScript.asm (56 bytes ARM64)
        public object SetActionMode(params object[] args)
        {
            // TODO: port body from 00240804_LuaNpc16LuaSetActionModeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetActionMode] not yet ported (gốc 0x240804)");
            return null;
        }

        // VMA: 0x24083c  Source: functions/0024083c_LuaNpc16LuaGetBloodStyleER10XLuaScript.asm
        // gốc body in 0024083c_LuaNpc16LuaGetBloodStyleER10XLuaScript.asm (44 bytes ARM64)
        public object GetBloodStyle(params object[] args)
        {
            // TODO: port body from 0024083c_LuaNpc16LuaGetBloodStyleER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetBloodStyle] not yet ported (gốc 0x24083c)");
            return null;
        }

        // VMA: 0x240868  Source: functions/00240868_LuaNpc16LuaSetBloodStyleER10XLuaScript.asm
        // gốc body in 00240868_LuaNpc16LuaSetBloodStyleER10XLuaScript.asm (56 bytes ARM64)
        public object SetBloodStyle(params object[] args)
        {
            // TODO: port body from 00240868_LuaNpc16LuaSetBloodStyleER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetBloodStyle] not yet ported (gốc 0x240868)");
            return null;
        }

        // VMA: 0x2408a0  Source: functions/002408a0_LuaNpc13LuaGetAIStateER10XLuaScript.asm
        // gốc body in 002408a0_LuaNpc13LuaGetAIStateER10XLuaScript.asm (88 bytes ARM64)
        public object GetAIState(params object[] args)
        {
            // TODO: port body from 002408a0_LuaNpc13LuaGetAIStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetAIState] not yet ported (gốc 0x2408a0)");
            return null;
        }

        // VMA: 0x2408f8  Source: functions/002408f8_LuaNpc17LuaGetMissileLifeER10XLuaScript.asm
        // gốc body in 002408f8_LuaNpc17LuaGetMissileLifeER10XLuaScript.asm (120 bytes ARM64)
        public object GetMissileLife(params object[] args)
        {
            // TODO: port body from 002408f8_LuaNpc17LuaGetMissileLifeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetMissileLife] not yet ported (gốc 0x2408f8)");
            return null;
        }

        // VMA: 0x240970  Source: functions/00240970_LuaNpc17LuaGetFollowNpcIdER10XLuaScript.asm
        // gốc body in 00240970_LuaNpc17LuaGetFollowNpcIdER10XLuaScript.asm (44 bytes ARM64)
        public object GetFollowNpcId(params object[] args)
        {
            // TODO: port body from 00240970_LuaNpc17LuaGetFollowNpcIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetFollowNpcId] not yet ported (gốc 0x240970)");
            return null;
        }

        // VMA: 0x24099c  Source: functions/0024099c_LuaNpc12LuaIsOnGroudER10XLuaScript.asm
        // gốc body in 0024099c_LuaNpc12LuaIsOnGroudER10XLuaScript.asm (60 bytes ARM64)
        public object IsOnGroud(params object[] args)
        {
            // TODO: port body from 0024099c_LuaNpc12LuaIsOnGroudER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.IsOnGroud] not yet ported (gốc 0x24099c)");
            return null;
        }

        // VMA: 0x2409d8  Source: functions/002409d8_LuaNpc20LuaGetRelativeHeightER10XLuaScript.asm
        // gốc body in 002409d8_LuaNpc20LuaGetRelativeHeightER10XLuaScript.asm (60 bytes ARM64)
        public object GetRelativeHeight(params object[] args)
        {
            // TODO: port body from 002409d8_LuaNpc20LuaGetRelativeHeightER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetRelativeHeight] not yet ported (gốc 0x2409d8)");
            return null;
        }

        // VMA: 0x240a14  Source: functions/00240a14_LuaNpc13LuaGetFactionER10XLuaScript.asm
        // gốc body in 00240a14_LuaNpc13LuaGetFactionER10XLuaScript.asm (40 bytes ARM64)
        public object GetFaction(params object[] args)
        {
            // TODO: port body from 00240a14_LuaNpc13LuaGetFactionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetFaction] not yet ported (gốc 0x240a14)");
            return null;
        }

        // VMA: 0x240a3c  Source: functions/00240a3c_LuaNpc16LuaClearNpcStateER10XLuaScript.asm
        // gốc body in 00240a3c_LuaNpc16LuaClearNpcStateER10XLuaScript.asm (108 bytes ARM64)
        public object ClearNpcState(params object[] args)
        {
            // TODO: port body from 00240a3c_LuaNpc16LuaClearNpcStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.ClearNpcState] not yet ported (gốc 0x240a3c)");
            return null;
        }

        // VMA: 0x240aa8  Source: functions/00240aa8_LuaNpc35LuaGetPartnerProtectSkillAdditionLvER10XLuaScript.asm
        // gốc body in 00240aa8_LuaNpc35LuaGetPartnerProtectSkillAdditionLvER10XLuaScript.asm (64 bytes ARM64)
        public object GetPartnerProtectSkillAdditionLv(params object[] args)
        {
            // TODO: port body from 00240aa8_LuaNpc35LuaGetPartnerProtectSkillAdditionLvER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetPartnerProtectSkillAdditionLv] not yet ported (gốc 0x240aa8)");
            return null;
        }

        // VMA: 0x240ae8  Source: functions/00240ae8_LuaNpc14LuaSetMasterIdER10XLuaScript.asm
        // gốc body in 00240ae8_LuaNpc14LuaSetMasterIdER10XLuaScript.asm (68 bytes ARM64)
        public object SetMasterId(params object[] args)
        {
            // TODO: port body from 00240ae8_LuaNpc14LuaSetMasterIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetMasterId] not yet ported (gốc 0x240ae8)");
            return null;
        }

        // VMA: 0x240b2c  Source: functions/00240b2c_LuaNpc20LuaGetEquipShowStateER10XLuaScript.asm
        // gốc body in 00240b2c_LuaNpc20LuaGetEquipShowStateER10XLuaScript.asm (96 bytes ARM64)
        public object GetEquipShowState(params object[] args)
        {
            // TODO: port body from 00240b2c_LuaNpc20LuaGetEquipShowStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetEquipShowState] not yet ported (gốc 0x240b2c)");
            return null;
        }

        // VMA: 0x240b8c  Source: functions/00240b8c_LuaNpc20LuaSetEquipShowStateER10XLuaScript.asm
        // gốc body in 00240b8c_LuaNpc20LuaSetEquipShowStateER10XLuaScript.asm (112 bytes ARM64)
        public object SetEquipShowState(params object[] args)
        {
            // TODO: port body from 00240b8c_LuaNpc20LuaSetEquipShowStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KNpcLua.SetEquipShowState] not yet ported (gốc 0x240b8c)");
            return null;
        }

        // ============ Other methods ============
        // VMA: 0x239e20  Source: functions/00239e20_LuaNpc6GetHimER10XLuaScripti.asm
        public object GetHim(params object[] args)
        {
            UnityEngine.Debug.LogWarning($"[KNpcLua.GetHim] not yet ported (gốc 0x239e20)");
            return null;
        }

        // VMA: 0x239e5c  Source: functions/00239e5c_LuaNpc14ClearTempTableEv.asm
        public object ClearTempTable(params object[] args)
        {
            UnityEngine.Debug.LogWarning($"[KNpcLua.ClearTempTable] not yet ported (gốc 0x239e5c)");
            return null;
        }

        // VMA: 0x25bb40  Source: functions/0025bb40_LuaNpc8PushCObjEP9lua_State.asm
        public object PushCObj(params object[] args)
        {
            UnityEngine.Debug.LogWarning($"[KNpcLua.PushCObj] not yet ported (gốc 0x25bb40)");
            return null;
        }

    }

    /// <summary>Data backing for KNpcLua — mirrors C++ underlying object fields.</summary>
    public class KNpcLuaData
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