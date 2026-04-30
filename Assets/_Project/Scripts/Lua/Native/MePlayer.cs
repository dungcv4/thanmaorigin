// Class:  MePlayer  (gốc native binding `LuaPlayer` from libclient_scene.so)
// Source: KTO_LibClientScene_Decompiled/INDEX.tsv (256 methods)
// XLua global: `me` (registered via LuaEnv.Global.Set)
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
    public class MePlayer
    {
        // Underlying C++ KPlayer/KNpc/KItem proxy (state holder).
        // gốc: LuaPlayer.this->player_ptr at offset +8 in C++ object.
        public MePlayerData Data { get; set; } = new MePlayerData();

        // ============ Properties (paired getX/setX) ============
        // VMA: 0x246c44  Source: functions/00246c44_LuaPlayer28getActiveSkillsReduceCdtimePEv.asm
        public bool ActiveSkillsReduceCdtimeP { get; }

        // VMA: 0x245c88  Source: functions/00245c88_LuaPlayer8getAloneEv.asm
        public int Alone { get; }

        // VMA: 0x246c74  Source: functions/00246c74_LuaPlayer15getAttackSpeedVEv.asm
        public int AttackSpeedV { get; }

        // VMA: 0x245d88  Source: functions/00245d88_LuaPlayer16getBaseDexterityEv.asm
        public int BaseDexterity { get; }

        // VMA: 0x245d94  Source: functions/00245d94_LuaPlayer13getBaseEnergyEv.asm
        public int BaseEnergy { get; }

        // VMA: 0x245d7c  Source: functions/00245d7c_LuaPlayer15getBaseStrengthEv.asm
        public string BaseStrength { get; }

        // VMA: 0x245d70  Source: functions/00245d70_LuaPlayer15getBaseVitalityEv.asm
        public int BaseVitality { get; }

        // VMA: 0x2468b8  Source: functions/002468b8_LuaPlayer9getBlockPEv.asm
        public int BlockP { get; }

        // VMA: 0x246888  Source: functions/00246888_LuaPlayer9getBlockVEv.asm
        public int BlockV { get; }

        // VMA: 0x246478  Source: functions/00246478_LuaPlayer17getBurnAttackRateEv.asm
        public int BurnAttackRate { get; }

        // VMA: 0x2464ac  Source: functions/002464ac_LuaPlayer17getBurnAttackTimeEv.asm
        public long BurnAttackTime { get; }

        // VMA: 0x246680  Source: functions/00246680_LuaPlayer17getBurnResistRateEv.asm
        public string BurnResistRate { get; }

        // VMA: 0x2466b4  Source: functions/002466b4_LuaPlayer17getBurnResistTimeEv.asm
        public bool BurnResistTime { get; }

        // VMA: 0x246a70  Source: functions/00246a70_LuaPlayer13getCreateTimeEv.asm
        public long CreateTime { get; }

        // VMA: 0x2469cc  Source: functions/002469cc_LuaPlayer12getDSDefenseEv.asm
        public int DSDefense { get; }

        // VMA: 0x246978  Source: functions/00246978_LuaPlayer28getDeadlyStrikeDamagePercentEv.asm
        public string DeadlyStrikeDamagePercent { get; }

        // VMA: 0x245d28  Source: functions/00245d28_LuaPlayer12getDexterityEv.asm
        public int Dexterity { get; }

        // VMA: 0x246054  Source: functions/00246054_LuaPlayer9getEarthREv.asm
        public int EarthR { get; }

        // VMA: 0x245d4c  Source: functions/00245d4c_LuaPlayer9getEnergyEv.asm
        public int Energy { get; }

        // VMA: 0x246828  Source: functions/00246828_LuaPlayer17getEnhanceDamagePEv.asm
        public int EnhanceDamageP { get; }

        // VMA: 0x246c14  Source: functions/00246c14_LuaPlayer27getEnhanceFinalDamageEarthPEv.asm
        public int EnhanceFinalDamageEarthP { get; }

        // VMA: 0x247154  Source: functions/00247154_LuaPlayer31getEnhanceFinalDamageEnemyBurnPEv.asm
        public int EnhanceFinalDamageEnemyBurnP { get; }

        // VMA: 0x247124  Source: functions/00247124_LuaPlayer34getEnhanceFinalDamageEnemyConfusePEv.asm
        public int EnhanceFinalDamageEnemyConfuseP { get; }

        // VMA: 0x246e84  Source: functions/00246e84_LuaPlayer34getEnhanceFinalDamageEnemyControlPEv.asm
        public int EnhanceFinalDamageEnemyControlP { get; }

        // VMA: 0x246fa4  Source: functions/00246fa4_LuaPlayer31getEnhanceFinalDamageEnemyDragPEv.asm
        public int EnhanceFinalDamageEnemyDragP { get; }

        // VMA: 0x2470f4  Source: functions/002470f4_LuaPlayer32getEnhanceFinalDamageEnemyFixedPEv.asm
        public int EnhanceFinalDamageEnemyFixedP { get; }

        // VMA: 0x247064  Source: functions/00247064_LuaPlayer33getEnhanceFinalDamageEnemyFreezePEv.asm
        public int EnhanceFinalDamageEnemyFreezeP { get; }

        // VMA: 0x246f14  Source: functions/00246f14_LuaPlayer33getEnhanceFinalDamageEnemyHealthPEv.asm
        public int EnhanceFinalDamageEnemyHealthP { get; }

        // VMA: 0x247094  Source: functions/00247094_LuaPlayer31getEnhanceFinalDamageEnemyHurtPEv.asm
        public int EnhanceFinalDamageEnemyHurtP { get; }

        // VMA: 0x246f44  Source: functions/00246f44_LuaPlayer33getEnhanceFinalDamageEnemyInjuryPEv.asm
        public int EnhanceFinalDamageEnemyInjuryP { get; }

        // VMA: 0x247004  Source: functions/00247004_LuaPlayer32getEnhanceFinalDamageEnemyKnockPEv.asm
        public int EnhanceFinalDamageEnemyKnockP { get; }

        // VMA: 0x2470c4  Source: functions/002470c4_LuaPlayer32getEnhanceFinalDamageEnemyPalsyPEv.asm
        public int EnhanceFinalDamageEnemyPalsyP { get; }

        // VMA: 0x246fd4  Source: functions/00246fd4_LuaPlayer34getEnhanceFinalDamageEnemySlowallPEv.asm
        public int EnhanceFinalDamageEnemySlowallP { get; }

        // VMA: 0x246f74  Source: functions/00246f74_LuaPlayer31getEnhanceFinalDamageEnemyStunPEv.asm
        public int EnhanceFinalDamageEnemyStunP { get; }

        // VMA: 0x247034  Source: functions/00247034_LuaPlayer31getEnhanceFinalDamageEnemyWeakPEv.asm
        public int EnhanceFinalDamageEnemyWeakP { get; }

        // VMA: 0x246be4  Source: functions/00246be4_LuaPlayer26getEnhanceFinalDamageFirePEv.asm
        public int EnhanceFinalDamageFireP { get; }

        // VMA: 0x246d04  Source: functions/00246d04_LuaPlayer27getEnhanceFinalDamageMeleePEv.asm
        public int EnhanceFinalDamageMeleeP { get; }

        // VMA: 0x246b54  Source: functions/00246b54_LuaPlayer27getEnhanceFinalDamageMetalPEv.asm
        public int EnhanceFinalDamageMetalP { get; }

        // VMA: 0x246ca4  Source: functions/00246ca4_LuaPlayer29getEnhanceFinalDamageNpcBossPEv.asm
        public int EnhanceFinalDamageNpcBossP { get; }

        // VMA: 0x246dc4  Source: functions/00246dc4_LuaPlayer31getEnhanceFinalDamageOwnHealthPEv.asm
        public int EnhanceFinalDamageOwnHealthP { get; }

        // VMA: 0x246e24  Source: functions/00246e24_LuaPlayer31getEnhanceFinalDamageOwnInjuryPEv.asm
        public int EnhanceFinalDamageOwnInjuryP { get; }

        // VMA: 0x246d64  Source: functions/00246d64_LuaPlayer28getEnhanceFinalDamageRemotePEv.asm
        public int EnhanceFinalDamageRemoteP { get; }

        // VMA: 0x247184  Source: functions/00247184_LuaPlayer34getEnhanceFinalDamageSkillTagBasePEv.asm
        public int EnhanceFinalDamageSkillTagBaseP { get; }

        // VMA: 0x2471e4  Source: functions/002471e4_LuaPlayer36getEnhanceFinalDamageSkillTagKernelPEv.asm
        public int EnhanceFinalDamageSkillTagKernelP { get; }

        // VMA: 0x2471b4  Source: functions/002471b4_LuaPlayer39getEnhanceFinalDamageSkillTagMechanismPEv.asm
        public bool EnhanceFinalDamageSkillTagMechanismP { get; }

        // VMA: 0x247214  Source: functions/00247214_LuaPlayer37getEnhanceFinalDamageSkillTagSpecialPEv.asm
        public int EnhanceFinalDamageSkillTagSpecialP { get; }

        // VMA: 0x246bb4  Source: functions/00246bb4_LuaPlayer27getEnhanceFinalDamageWaterPEv.asm
        public int EnhanceFinalDamageWaterP { get; }

        // VMA: 0x246b84  Source: functions/00246b84_LuaPlayer26getEnhanceFinalDamageWoodPEv.asm
        public int EnhanceFinalDamageWoodP { get; }

        // VMA: 0x245ca4  Source: functions/00245ca4_LuaPlayer10getFactionEv.asm
        public int Faction { get; set; }

        // VMA: 0x245cbc  Source: functions/00245cbc_LuaPlayer14getFactionSectEv.asm
        public int FactionSect { get; set; }

        // VMA: 0x245c38  Source: functions/00245c38_LuaPlayer12getFightModeEv.asm
        public int FightMode { get; set; }

        // VMA: 0x2460ac  Source: functions/002460ac_LuaPlayer8getFireREv.asm
        public int FireR { get; }

        // VMA: 0x246780  Source: functions/00246780_LuaPlayer10getHitRateEv.asm
        public int HitRate { get; }

        // VMA: 0x2469fc  Source: functions/002469fc_LuaPlayer13getHonorLevelEv.asm
        public int HonorLevel { get; }

        // VMA: 0x246a18  Source: functions/00246a18_LuaPlayer17getHonorStarLevelEv.asm
        public int HonorStarLevel { get; }

        // VMA: 0x246340  Source: functions/00246340_LuaPlayer17getHurtAttackRateEv.asm
        public int HurtAttackRate { get; }

        // VMA: 0x246374  Source: functions/00246374_LuaPlayer17getHurtAttackTimeEv.asm
        public long HurtAttackTime { get; }

        // VMA: 0x246548  Source: functions/00246548_LuaPlayer17getHurtResistRateEv.asm
        public string HurtResistRate { get; }

        // VMA: 0x24657c  Source: functions/0024657c_LuaPlayer17getHurtResistTimeEv.asm
        public bool HurtResistTime { get; }

        // VMA: 0x2459f4  Source: functions/002459f4_LuaPlayer5getIDEv.asm
        public int ID { get; set; }

        // VMA: 0x246310  Source: functions/00246310_LuaPlayer18getIgnoreAllResistEv.asm
        public bool IgnoreAllResist { get; }

        // VMA: 0x2468e8  Source: functions/002468e8_LuaPlayer16getIgnoreDefenseEv.asm
        public int IgnoreDefense { get; }

        // VMA: 0x2462b0  Source: functions/002462b0_LuaPlayer14getIgnoreEarthEv.asm
        public int IgnoreEarth { get; }

        // VMA: 0x2462e0  Source: functions/002462e0_LuaPlayer16getIgnoreEarthRVEv.asm
        public int IgnoreEarthRV { get; }

        // VMA: 0x246250  Source: functions/00246250_LuaPlayer13getIgnoreFireEv.asm
        public int IgnoreFire { get; }

        // VMA: 0x246280  Source: functions/00246280_LuaPlayer15getIgnoreFireRVEv.asm
        public int IgnoreFireRV { get; }

        // VMA: 0x246130  Source: functions/00246130_LuaPlayer14getIgnoreMetalEv.asm
        public int IgnoreMetal { get; }

        // VMA: 0x246160  Source: functions/00246160_LuaPlayer16getIgnoreMetalRVEv.asm
        public int IgnoreMetalRV { get; }

        // VMA: 0x2461f0  Source: functions/002461f0_LuaPlayer14getIgnoreWaterEv.asm
        public int IgnoreWater { get; }

        // VMA: 0x246220  Source: functions/00246220_LuaPlayer16getIgnoreWaterRVEv.asm
        public int IgnoreWaterRV { get; }

        // VMA: 0x246190  Source: functions/00246190_LuaPlayer13getIgnoreWoodEv.asm
        public int IgnoreWood { get; }

        // VMA: 0x2461c0  Source: functions/002461c0_LuaPlayer15getIgnoreWoodRVEv.asm
        public int IgnoreWoodRV { get; }

        // VMA: 0x246a50  Source: functions/00246a50_LuaPlayer16getInBattleStateEv.asm
        public int InBattleState { get; }

        // VMA: 0x2472d0  Source: functions/002472d0_LuaPlayer15getIsP2PTradingEv.asm
        public bool IsP2PTrading { get; set; }

        // VMA: 0x245a0c  Source: functions/00245a0c_LuaPlayer8getKinIdEv.asm
        public int KinId { get; set; }

        // VMA: 0x245bb4  Source: functions/00245bb4_LuaPlayer11getKinTitleEv.asm
        public string KinTitle { get; set; }

        // VMA: 0x245da0  Source: functions/00245da0_LuaPlayer21getLeftPotentialPointEv.asm
        public int LeftPotentialPoint { get; }

        // VMA: 0x245a7c  Source: functions/00245a7c_LuaPlayer11getLegionIdEv.asm
        public int LegionId { get; set; }

        // VMA: 0x245ad0  Source: functions/00245ad0_LuaPlayer8getLevelEv.asm
        public int Level => Data.nLevel;

        // VMA: 0x245b2c  Source: functions/00245b2c_LuaPlayer26getLevelUpAboutEquipSeriesEv.asm
        public int LevelUpAboutEquipSeries { get; set; }

        // VMA: 0x247244  Source: functions/00247244_LuaPlayer14getLifeMaxAllPEv.asm
        public int LifeMaxAllP { get; }

        // VMA: 0x246004  Source: functions/00246004_LuaPlayer18getLifeMaxEnhanceWEv.asm
        public int LifeMaxEnhanceW { get; }

        // VMA: 0x245dec  Source: functions/00245dec_LuaPlayer19getLifeRecoverTotalEv.asm
        public int LifeRecoverTotal { get; }

        // VMA: 0x245e3c  Source: functions/00245e3c_LuaPlayer16getLifeReplenishEv.asm
        public bool LifeReplenish { get; }

        // VMA: 0x246a7c  Source: functions/00246a7c_LuaPlayer20getMainStreetEnabledEv.asm
        public string MainStreetEnabled { get; set; }

        // VMA: 0x245e14  Source: functions/00245e14_LuaPlayer19getManaRecoverTotalEv.asm
        public int ManaRecoverTotal { get; }

        // VMA: 0x245e60  Source: functions/00245e60_LuaPlayer16getManaReplenishEv.asm
        public bool ManaReplenish { get; }

        // VMA: 0x245b54  Source: functions/00245b54_LuaPlayer8getMapIdEv.asm
        public int MapId { get; }

        // VMA: 0x245bf4  Source: functions/00245bf4_LuaPlayer10getMapNameEv.asm
        public string MapName { get; }

        // VMA: 0x245b74  Source: functions/00245b74_LuaPlayer16getMapTemplateIdEv.asm
        public int MapTemplateId { get; }

        // VMA: 0x246b2c  Source: functions/00246b2c_LuaPlayer21getMaskFactSkillStateEv.asm
        public int MaskFactSkillState { get; set; }

        // VMA: 0x246b04  Source: functions/00246b04_LuaPlayer22getMaskPlayerAttrStateEv.asm
        public int MaskPlayerAttrState { get; set; }

        // VMA: 0x245dac  Source: functions/00245dac_LuaPlayer10getMaxLifeEv.asm
        public int MaxLife { get; }

        // VMA: 0x245dcc  Source: functions/00245dcc_LuaPlayer10getMaxManaEv.asm
        public int MaxMana { get; }

        // VMA: 0x246104  Source: functions/00246104_LuaPlayer9getMetalREv.asm
        public int MetalR { get; }

        // VMA: 0x2467a4  Source: functions/002467a4_LuaPlayer7getMissEv.asm
        public bool Miss { get; }

        // VMA: 0x245b94  Source: functions/00245b94_LuaPlayer7getNameEv.asm
        public string Name { get; }

        // VMA: 0x246750  Source: functions/00246750_LuaPlayer25getPhysicsPotentialDamageEv.asm
        public int PhysicsPotentialDamage { get; }

        // VMA: 0x245c1c  Source: functions/00245c1c_LuaPlayer9getPkModeEv.asm
        public int PkMode { get; }

        // VMA: 0x246a34  Source: functions/00246a34_LuaPlayer11getPortraitEv.asm
        public int Portrait { get; }

        // VMA: 0x246ee4  Source: functions/00246ee4_LuaPlayer19getReduceDamageAllPEv.asm
        public int ReduceDamageAllP { get; }

        // VMA: 0x246cd4  Source: functions/00246cd4_LuaPlayer20getReduceDamageBossPEv.asm
        public int ReduceDamageBossP { get; }

        // VMA: 0x246eb4  Source: functions/00246eb4_LuaPlayer23getReduceDamageControlPEv.asm
        public int ReduceDamageControlP { get; }

        // VMA: 0x246df4  Source: functions/00246df4_LuaPlayer22getReduceDamageHealthPEv.asm
        public int ReduceDamageHealthP { get; }

        // VMA: 0x246e54  Source: functions/00246e54_LuaPlayer22getReduceDamageInjuryPEv.asm
        public int ReduceDamageInjuryP { get; }

        // VMA: 0x246d34  Source: functions/00246d34_LuaPlayer21getReduceDamageMeleePEv.asm
        public int ReduceDamageMeleeP { get; }

        // VMA: 0x2467c8  Source: functions/002467c8_LuaPlayer16getReduceDamagePEv.asm
        public int ReduceDamageP { get; }

        // VMA: 0x246d94  Source: functions/00246d94_LuaPlayer22getReduceDamageRemotePEv.asm
        public int ReduceDamageRemoteP { get; }

        // VMA: 0x246858  Source: functions/00246858_LuaPlayer23getResistEnhanceDamagePEv.asm
        public bool ResistEnhanceDamageP { get; }

        // VMA: 0x2467f8  Source: functions/002467f8_LuaPlayer22getResistReduceDamagePEv.asm
        public string ResistReduceDamageP { get; }

        // VMA: 0x246918  Source: functions/00246918_LuaPlayer21getReturnResistMeleeVEv.asm
        public bool ReturnResistMeleeV { get; }

        // VMA: 0x246948  Source: functions/00246948_LuaPlayer21getReturnResistRangeVEv.asm
        public string ReturnResistRangeV { get; }

        // VMA: 0x246ac0  Source: functions/00246ac0_LuaPlayer12getRideStateEv.asm
        public int RideState { get; }

        // VMA: 0x246ab4  Source: functions/00246ab4_LuaPlayer11getServerIdEv.asm
        public int ServerId { get; }

        // VMA: 0x245cd4  Source: functions/00245cd4_LuaPlayer6getSexEv.asm
        public int Sex { get; }

        // VMA: 0x2463a8  Source: functions/002463a8_LuaPlayer20getSlowAllAttackRateEv.asm
        public int SlowAllAttackRate { get; }

        // VMA: 0x2463dc  Source: functions/002463dc_LuaPlayer19getSlowAllAttckTimeEv.asm
        public long SlowAllAttckTime { get; }

        // VMA: 0x2465b0  Source: functions/002465b0_LuaPlayer20getSlowAllResistRateEv.asm
        public string SlowAllResistRate { get; }

        // VMA: 0x2465e4  Source: functions/002465e4_LuaPlayer20getSlowAllResistTimeEv.asm
        public bool SlowAllResistTime { get; }

        // VMA: 0x245e84  Source: functions/00245e84_LuaPlayer16getStealLifeRateEv.asm
        public int StealLifeRate { get; }

        // VMA: 0x245eb4  Source: functions/00245eb4_LuaPlayer22getStealLifeResistRateEv.asm
        public string StealLifeResistRate { get; }

        // VMA: 0x245f14  Source: functions/00245f14_LuaPlayer23getStealLifeResistValueEv.asm
        public bool StealLifeResistValue { get; }

        // VMA: 0x245ee4  Source: functions/00245ee4_LuaPlayer17getStealLifeValueEv.asm
        public int StealLifeValue { get; }

        // VMA: 0x245f44  Source: functions/00245f44_LuaPlayer16getStealManaRateEv.asm
        public int StealManaRate { get; }

        // VMA: 0x245fa4  Source: functions/00245fa4_LuaPlayer22getStealManaResistRateEv.asm
        public string StealManaResistRate { get; }

        // VMA: 0x245fd4  Source: functions/00245fd4_LuaPlayer23getStealManaResistValueEv.asm
        public bool StealManaResistValue { get; }

        // VMA: 0x245f74  Source: functions/00245f74_LuaPlayer17getStealManaValueEv.asm
        public int StealManaValue { get; }

        // VMA: 0x245d04  Source: functions/00245d04_LuaPlayer11getStrengthEv.asm
        public string Strength { get; }

        // VMA: 0x246410  Source: functions/00246410_LuaPlayer17getStunAttackRateEv.asm
        public int StunAttackRate { get; }

        // VMA: 0x246444  Source: functions/00246444_LuaPlayer17getStunAttackTimeEv.asm
        public long StunAttackTime { get; }

        // VMA: 0x246618  Source: functions/00246618_LuaPlayer17getStunResistRateEv.asm
        public string StunResistRate { get; }

        // VMA: 0x24664c  Source: functions/0024664c_LuaPlayer17getStunResistTimeEv.asm
        public bool StunResistTime { get; }

        // VMA: 0x245ab4  Source: functions/00245ab4_LuaPlayer9getTeamIDEv.asm
        public int TeamID { get; }

        // VMA: 0x245a44  Source: functions/00245a44_LuaPlayer9getTongIdEv.asm
        public int TongId
        {
            get => (int)Data.dwTongId;
            set => Data.dwTongId = (uint)value;
        }

        // gốc Lua scripts also access raw LuaPlayer field names (`me.dwID`,
        // `me.nMapTemplateId`) and attach Lua-side state (`me.tbPlayerEvent`).
        // The native object accepts these through LuaNewIndex; expose explicit
        // properties here so XLua has the same writable surface.
        public uint dwID
        {
            get => Data.dwID;
            set => Data.dwID = value;
        }

        public int nMapTemplateId
        {
            get => Data.nMapTemplateId;
            set => Data.nMapTemplateId = value;
        }

        public LuaTable tbPlayerEvent { get; set; }

        // VMA: 0x245b08  Source: functions/00245b08_LuaPlayer13getTotalLevelEv.asm
        public int TotalLevel { get; }

        // VMA: 0x245ce0  Source: functions/00245ce0_LuaPlayer11getVitalityEv.asm
        public int Vitality { get; }

        // VMA: 0x246080  Source: functions/00246080_LuaPlayer9getWaterREv.asm
        public int WaterR { get; }

        // VMA: 0x2464e0  Source: functions/002464e0_LuaPlayer17getWeakAttackRateEv.asm
        public int WeakAttackRate { get; }

        // VMA: 0x246514  Source: functions/00246514_LuaPlayer17getWeakAttackTimeEv.asm
        public long WeakAttackTime { get; }

        // VMA: 0x2466e8  Source: functions/002466e8_LuaPlayer17getWeakResistRateEv.asm
        public string WeakResistRate { get; }

        // VMA: 0x24671c  Source: functions/0024671c_LuaPlayer17getWeakResistTimeEv.asm
        public bool WeakResistTime { get; }

        // VMA: 0x2469a8  Source: functions/002469a8_LuaPlayer11getWeakenDSEv.asm
        public int WeakenDS { get; }

        // VMA: 0x2460d8  Source: functions/002460d8_LuaPlayer8getWindREv.asm
        public int WindR { get; }

        // VMA: 0x245aec  Source: functions/00245aec_LuaPlayer15getZongShiLevelEv.asm
        public int ZongShiLevel { get; }

        // ============ Lua-callable methods (LuaXxx) ============
        // VMA: 0x2454e8  Source: functions/002454e8_LuaPlayer17LuaGetScriptTableER10XLuaScript.asm
        // gốc body in 002454e8_LuaPlayer17LuaGetScriptTableER10XLuaScript.asm (508 bytes ARM64)
        public object GetScriptTable(params object[] args)
        {
            // TODO: port body from 002454e8_LuaPlayer17LuaGetScriptTableER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetScriptTable] not yet ported (gốc 0x2454e8)");
            return null;
        }

        // VMA: 0x2456e4  Source: functions/002456e4_LuaPlayer18LuaSaveScriptTableER10XLuaScript.asm
        // gốc body in 002456e4_LuaPlayer18LuaSaveScriptTableER10XLuaScript.asm (8 bytes ARM64)
        public object SaveScriptTable(params object[] args)
        {
            // TODO: port body from 002456e4_LuaPlayer18LuaSaveScriptTableER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.SaveScriptTable] not yet ported (gốc 0x2456e4)");
            return null;
        }

        // VMA: 0x2456ec  Source: functions/002456ec_LuaPlayer23LuaGetSaveScriptVersionER10XLuaScript.asm
        // gốc body in 002456ec_LuaPlayer23LuaGetSaveScriptVersionER10XLuaScript.asm (776 bytes ARM64)
        public object GetSaveScriptVersion(params object[] args)
        {
            // TODO: port body from 002456ec_LuaPlayer23LuaGetSaveScriptVersionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetSaveScriptVersion] not yet ported (gốc 0x2456ec)");
            return null;
        }

        // VMA: 0x2472f0  Source: functions/002472f0_LuaPlayer13LuaClearItemsER10XLuaScript.asm
        // gốc body in 002472f0_LuaPlayer13LuaClearItemsER10XLuaScript.asm (40 bytes ARM64)
        public object ClearItems(params object[] args)
        {
            // TODO: port body from 002472f0_LuaPlayer13LuaClearItemsER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.ClearItems] not yet ported (gốc 0x2472f0)");
            return null;
        }

        // VMA: 0x247318  Source: functions/00247318_LuaPlayer19LuaGetAllItemsInBagER10XLuaScript.asm
        // gốc body in 00247318_LuaPlayer19LuaGetAllItemsInBagER10XLuaScript.asm (140 bytes ARM64)
        public object GetAllItemsInBag(params object[] args)
        {
            // TODO: port body from 00247318_LuaPlayer19LuaGetAllItemsInBagER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetAllItemsInBag] not yet ported (gốc 0x247318)");
            return null;
        }

        // VMA: 0x2473a4  Source: functions/002473a4_LuaPlayer12LuaGetEquipsER10XLuaScript.asm
        // gốc body in 002473a4_LuaPlayer12LuaGetEquipsER10XLuaScript.asm (172 bytes ARM64)
        public object GetEquips(params object[] args)
        {
            // TODO: port body from 002473a4_LuaPlayer12LuaGetEquipsER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetEquips] not yet ported (gốc 0x2473a4)");
            return null;
        }

        // VMA: 0x247450  Source: functions/00247450_LuaPlayer16LuaGetEquipByPosER10XLuaScript.asm
        // gốc body in 00247450_LuaPlayer16LuaGetEquipByPosER10XLuaScript.asm (312 bytes ARM64)
        public object GetEquipByPos(params object[] args)
        {
            // TODO: port body from 00247450_LuaPlayer16LuaGetEquipByPosER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetEquipByPos] not yet ported (gốc 0x247450)");
            return null;
        }

        // VMA: 0x247588  Source: functions/00247588_LuaPlayer16LuaGetActionModeER10XLuaScript.asm
        // gốc body in 00247588_LuaPlayer16LuaGetActionModeER10XLuaScript.asm (64 bytes ARM64)
        public object GetActionMode(params object[] args)
        {
            // TODO: port body from 00247588_LuaPlayer16LuaGetActionModeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetActionMode] not yet ported (gốc 0x247588)");
            return null;
        }

        // VMA: 0x2475c8  Source: functions/002475c8_LuaPlayer9LuaGetExpER10XLuaScript.asm
        // gốc body in 002475c8_LuaPlayer9LuaGetExpER10XLuaScript.asm (40 bytes ARM64)
        public object GetExp(params object[] args)
        {
            // TODO: port body from 002475c8_LuaPlayer9LuaGetExpER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetExp] not yet ported (gốc 0x2475c8)");
            return null;
        }

        // VMA: 0x2475f0  Source: functions/002475f0_LuaPlayer18LuaGetNextLevelExpER10XLuaScript.asm
        // gốc body in 002475f0_LuaPlayer18LuaGetNextLevelExpER10XLuaScript.asm (40 bytes ARM64)
        public object GetNextLevelExp(params object[] args)
        {
            // TODO: port body from 002475f0_LuaPlayer18LuaGetNextLevelExpER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetNextLevelExp] not yet ported (gốc 0x2475f0)");
            return null;
        }

        // VMA: 0x247618  Source: functions/00247618_LuaPlayer19LuaGetItemListInBagER10XLuaScript.asm
        // gốc body in 00247618_LuaPlayer19LuaGetItemListInBagER10XLuaScript.asm (400 bytes ARM64)
        public object GetItemListInBag(params object[] args)
        {
            // TODO: port body from 00247618_LuaPlayer19LuaGetItemListInBagER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetItemListInBag] not yet ported (gốc 0x247618)");
            return null;
        }

        // VMA: 0x2477a8  Source: functions/002477a8_LuaPlayer19LuaGetItemListInBoxER10XLuaScript.asm
        // gốc body in 002477a8_LuaPlayer19LuaGetItemListInBoxER10XLuaScript.asm (352 bytes ARM64)
        public object GetItemListInBox(params object[] args)
        {
            // TODO: port body from 002477a8_LuaPlayer19LuaGetItemListInBoxER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetItemListInBox] not yet ported (gốc 0x2477a8)");
            return null;
        }

        // VMA: 0x247908  Source: functions/00247908_LuaPlayer21LuaGetItemListInBagExER10XLuaScript.asm
        // gốc body in 00247908_LuaPlayer21LuaGetItemListInBagExER10XLuaScript.asm (140 bytes ARM64)
        public object GetItemListInBagEx(params object[] args)
        {
            // TODO: port body from 00247908_LuaPlayer21LuaGetItemListInBagExER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetItemListInBagEx] not yet ported (gốc 0x247908)");
            return null;
        }

        // VMA: 0x247994  Source: functions/00247994_LuaPlayer21LuaGetItemListInBoxExER10XLuaScript.asm
        // gốc body in 00247994_LuaPlayer21LuaGetItemListInBoxExER10XLuaScript.asm (140 bytes ARM64)
        public object GetItemListInBoxEx(params object[] args)
        {
            // TODO: port body from 00247994_LuaPlayer21LuaGetItemListInBoxExER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetItemListInBoxEx] not yet ported (gốc 0x247994)");
            return null;
        }

        // VMA: 0x247a20  Source: functions/00247a20_LuaPlayer27LuaGetItemListInMedicineBagER10XLuaScript.asm
        // gốc body in 00247a20_LuaPlayer27LuaGetItemListInMedicineBagER10XLuaScript.asm (140 bytes ARM64)
        public object GetItemListInMedicineBag(params object[] args)
        {
            // TODO: port body from 00247a20_LuaPlayer27LuaGetItemListInMedicineBagER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetItemListInMedicineBag] not yet ported (gốc 0x247a20)");
            return null;
        }

        // VMA: 0x247aac  Source: functions/00247aac_LuaPlayer18LuaGetBagUsedCountER10XLuaScript.asm
        // gốc body in 00247aac_LuaPlayer18LuaGetBagUsedCountER10XLuaScript.asm (96 bytes ARM64)
        public object GetBagUsedCount(params object[] args)
        {
            // TODO: port body from 00247aac_LuaPlayer18LuaGetBagUsedCountER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetBagUsedCount] not yet ported (gốc 0x247aac)");
            return null;
        }

        // VMA: 0x247b0c  Source: functions/00247b0c_LuaPlayer18LuaGetFreeBagCountER10XLuaScript.asm
        // gốc body in 00247b0c_LuaPlayer18LuaGetFreeBagCountER10XLuaScript.asm (56 bytes ARM64)
        public object GetFreeBagCount(params object[] args)
        {
            // TODO: port body from 00247b0c_LuaPlayer18LuaGetFreeBagCountER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetFreeBagCount] not yet ported (gốc 0x247b0c)");
            return null;
        }

        // VMA: 0x247b44  Source: functions/00247b44_LuaPlayer14LuaGetBagCountER10XLuaScript.asm
        // gốc body in 00247b44_LuaPlayer14LuaGetBagCountER10XLuaScript.asm (56 bytes ARM64)
        public object GetBagCount(params object[] args)
        {
            // TODO: port body from 00247b44_LuaPlayer14LuaGetBagCountER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetBagCount] not yet ported (gốc 0x247b44)");
            return null;
        }

        // VMA: 0x247b7c  Source: functions/00247b7c_LuaPlayer14LuaSetBagCountER10XLuaScript.asm
        // gốc body in 00247b7c_LuaPlayer14LuaSetBagCountER10XLuaScript.asm (64 bytes ARM64)
        public object SetBagCount(params object[] args)
        {
            // TODO: port body from 00247b7c_LuaPlayer14LuaSetBagCountER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.SetBagCount] not yet ported (gốc 0x247b7c)");
            return null;
        }

        // VMA: 0x247bbc  Source: functions/00247bbc_LuaPlayer18LuaGetFreeBoxCountER10XLuaScript.asm
        // gốc body in 00247bbc_LuaPlayer18LuaGetFreeBoxCountER10XLuaScript.asm (56 bytes ARM64)
        public object GetFreeBoxCount(params object[] args)
        {
            // TODO: port body from 00247bbc_LuaPlayer18LuaGetFreeBoxCountER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetFreeBoxCount] not yet ported (gốc 0x247bbc)");
            return null;
        }

        // VMA: 0x247bf4  Source: functions/00247bf4_LuaPlayer14LuaGetBoxCountER10XLuaScript.asm
        // gốc body in 00247bf4_LuaPlayer14LuaGetBoxCountER10XLuaScript.asm (56 bytes ARM64)
        public object GetBoxCount(params object[] args)
        {
            // TODO: port body from 00247bf4_LuaPlayer14LuaGetBoxCountER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetBoxCount] not yet ported (gốc 0x247bf4)");
            return null;
        }

        // VMA: 0x247c2c  Source: functions/00247c2c_LuaPlayer14LuaSetBoxCountER10XLuaScript.asm
        // gốc body in 00247c2c_LuaPlayer14LuaSetBoxCountER10XLuaScript.asm (64 bytes ARM64)
        public object SetBoxCount(params object[] args)
        {
            // TODO: port body from 00247c2c_LuaPlayer14LuaSetBoxCountER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.SetBoxCount] not yet ported (gốc 0x247c2c)");
            return null;
        }

        // VMA: 0x247c6c  Source: functions/00247c6c_LuaPlayer15LuaGetItemInBagER10XLuaScript.asm
        // gốc body in 00247c6c_LuaPlayer15LuaGetItemInBagER10XLuaScript.asm (108 bytes ARM64)
        public object GetItemInBag(params object[] args)
        {
            // TODO: port body from 00247c6c_LuaPlayer15LuaGetItemInBagER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetItemInBag] not yet ported (gốc 0x247c6c)");
            return null;
        }

        // VMA: 0x247cd8  Source: functions/00247cd8_LuaPlayer24LuaGetOneItemByTypeInBagER10XLuaScript.asm
        // gốc body in 00247cd8_LuaPlayer24LuaGetOneItemByTypeInBagER10XLuaScript.asm (188 bytes ARM64)
        public object GetOneItemByTypeInBag(params object[] args)
        {
            // TODO: port body from 00247cd8_LuaPlayer24LuaGetOneItemByTypeInBagER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetOneItemByTypeInBag] not yet ported (gốc 0x247cd8)");
            return null;
        }

        // VMA: 0x247d94  Source: functions/00247d94_LuaPlayer20LuaGetItemInAllSpaceER10XLuaScript.asm
        // gốc body in 00247d94_LuaPlayer20LuaGetItemInAllSpaceER10XLuaScript.asm (116 bytes ARM64)
        public object GetItemInAllSpace(params object[] args)
        {
            // TODO: port body from 00247d94_LuaPlayer20LuaGetItemInAllSpaceER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetItemInAllSpace] not yet ported (gốc 0x247d94)");
            return null;
        }

        // VMA: 0x247e08  Source: functions/00247e08_LuaPlayer11LuaFindItemER10XLuaScript.asm
        // gốc body in 00247e08_LuaPlayer11LuaFindItemER10XLuaScript.asm (464 bytes ARM64)
        public object FindItem(params object[] args)
        {
            // TODO: port body from 00247e08_LuaPlayer11LuaFindItemER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.FindItem] not yet ported (gốc 0x247e08)");
            return null;
        }

        // VMA: 0x247fd8  Source: functions/00247fd8_LuaPlayer11LuaUseSkillER10XLuaScript.asm
        // gốc body in 00247fd8_LuaPlayer11LuaUseSkillER10XLuaScript.asm (316 bytes ARM64)
        public object UseSkill(params object[] args)
        {
            // TODO: port body from 00247fd8_LuaPlayer11LuaUseSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.UseSkill] not yet ported (gốc 0x247fd8)");
            return null;
        }

        // VMA: 0x248114  Source: functions/00248114_LuaPlayer16LuaUseSkillToDirER10XLuaScript.asm
        // gốc body in 00248114_LuaPlayer16LuaUseSkillToDirER10XLuaScript.asm (468 bytes ARM64)
        public object UseSkillToDir(params object[] args)
        {
            // TODO: port body from 00248114_LuaPlayer16LuaUseSkillToDirER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.UseSkillToDir] not yet ported (gốc 0x248114)");
            return null;
        }

        // VMA: 0x2482e8  Source: functions/002482e8_LuaPlayer17LuaSetWellNetworkER10XLuaScript.asm
        // gốc body in 002482e8_LuaPlayer17LuaSetWellNetworkER10XLuaScript.asm (64 bytes ARM64)
        public object SetWellNetwork(params object[] args)
        {
            // TODO: port body from 002482e8_LuaPlayer17LuaSetWellNetworkER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.SetWellNetwork] not yet ported (gốc 0x2482e8)");
            return null;
        }

        // VMA: 0x248328  Source: functions/00248328_LuaPlayer14LuaGetWorldPosER10XLuaScript.asm
        // gốc body in 00248328_LuaPlayer14LuaGetWorldPosER10XLuaScript.asm (332 bytes ARM64)
        public object GetWorldPos(params object[] args)
        {
            // TODO: port body from 00248328_LuaPlayer14LuaGetWorldPosER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetWorldPos] not yet ported (gốc 0x248328)");
            return null;
        }

        // VMA: 0x248474  Source: functions/00248474_LuaPlayer9LuaGetNpcER10XLuaScript.asm
        // gốc body in 00248474_LuaPlayer9LuaGetNpcER10XLuaScript.asm (60 bytes ARM64)
        public object GetNpc(params object[] args)
        {
            // TODO: port body from 00248474_LuaPlayer9LuaGetNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetNpc] not yet ported (gốc 0x248474)");
            return null;
        }

        // VMA: 0x2484b0  Source: functions/002484b0_LuaPlayer12LuaSetActionER10XLuaScript.asm
        // gốc body in 002484b0_LuaPlayer12LuaSetActionER10XLuaScript.asm (184 bytes ARM64)
        public object SetAction(params object[] args)
        {
            // TODO: port body from 002484b0_LuaPlayer12LuaSetActionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.SetAction] not yet ported (gốc 0x2484b0)");
            return null;
        }

        // VMA: 0x248568  Source: functions/00248568_LuaPlayer11LuaStopGotoER10XLuaScript.asm
        // gốc body in 00248568_LuaPlayer11LuaStopGotoER10XLuaScript.asm (28 bytes ARM64)
        public object StopGoto(params object[] args)
        {
            // TODO: port body from 00248568_LuaPlayer11LuaStopGotoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.StopGoto] not yet ported (gốc 0x248568)");
            return null;
        }

        // VMA: 0x248584  Source: functions/00248584_LuaPlayer15LuaGotoPositionER10XLuaScript.asm
        // gốc body in 00248584_LuaPlayer15LuaGotoPositionER10XLuaScript.asm (244 bytes ARM64)
        public object GotoPosition(params object[] args)
        {
            // TODO: port body from 00248584_LuaPlayer15LuaGotoPositionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GotoPosition] not yet ported (gốc 0x248584)");
            return null;
        }

        // VMA: 0x248678  Source: functions/00248678_LuaPlayer14LuaGoDirectionER10XLuaScript.asm
        // gốc body in 00248678_LuaPlayer14LuaGoDirectionER10XLuaScript.asm (92 bytes ARM64)
        public object GoDirection(params object[] args)
        {
            // TODO: port body from 00248678_LuaPlayer14LuaGoDirectionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GoDirection] not yet ported (gốc 0x248678)");
            return null;
        }

        // VMA: 0x2486d4  Source: functions/002486d4_LuaPlayer17LuaStartDirectionER10XLuaScript.asm
        // gốc body in 002486d4_LuaPlayer17LuaStartDirectionER10XLuaScript.asm (56 bytes ARM64)
        public object StartDirection(params object[] args)
        {
            // TODO: port body from 002486d4_LuaPlayer17LuaStartDirectionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.StartDirection] not yet ported (gốc 0x2486d4)");
            return null;
        }

        // VMA: 0x24870c  Source: functions/0024870c_LuaPlayer16LuaStopDirectionER10XLuaScript.asm
        // gốc body in 0024870c_LuaPlayer16LuaStopDirectionER10XLuaScript.asm (28 bytes ARM64)
        public object StopDirection(params object[] args)
        {
            // TODO: port body from 0024870c_LuaPlayer16LuaStopDirectionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.StopDirection] not yet ported (gốc 0x24870c)");
            return null;
        }

        // VMA: 0x248728  Source: functions/00248728_LuaPlayer14LuaSetPositionER10XLuaScript.asm
        // gốc body in 00248728_LuaPlayer14LuaSetPositionER10XLuaScript.asm (172 bytes ARM64)
        public object SetPosition(params object[] args)
        {
            // TODO: port body from 00248728_LuaPlayer14LuaSetPositionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.SetPosition] not yet ported (gốc 0x248728)");
            return null;
        }

        // VMA: 0x2487d4  Source: functions/002487d4_LuaPlayer20LuaGetTargetPositionER10XLuaScript.asm
        // gốc body in 002487d4_LuaPlayer20LuaGetTargetPositionER10XLuaScript.asm (152 bytes ARM64)
        public object GetTargetPosition(params object[] args)
        {
            // TODO: port body from 002487d4_LuaPlayer20LuaGetTargetPositionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetTargetPosition] not yet ported (gốc 0x2487d4)");
            return null;
        }

        // VMA: 0x24886c  Source: functions/0024886c_LuaPlayer15LuaCanCastSkillER10XLuaScript.asm
        // gốc body in 0024886c_LuaPlayer15LuaCanCastSkillER10XLuaScript.asm (252 bytes ARM64)
        public object CanCastSkill(params object[] args)
        {
            // TODO: port body from 0024886c_LuaPlayer15LuaCanCastSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.CanCastSkill] not yet ported (gốc 0x24886c)");
            return null;
        }

        // VMA: 0x248968  Source: functions/00248968_LuaPlayer9LuaReviveER10XLuaScript.asm
        // gốc body in 00248968_LuaPlayer9LuaReviveER10XLuaScript.asm (32 bytes ARM64)
        public object Revive(params object[] args)
        {
            // TODO: port body from 00248968_LuaPlayer9LuaReviveER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.Revive] not yet ported (gốc 0x248968)");
            return null;
        }

        // VMA: 0x248988  Source: functions/00248988_LuaPlayer17LuaEnterClientMapER10XLuaScript.asm
        // gốc body in 00248988_LuaPlayer17LuaEnterClientMapER10XLuaScript.asm (140 bytes ARM64)
        public object EnterClientMap(params object[] args)
        {
            // TODO: port body from 00248988_LuaPlayer17LuaEnterClientMapER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.EnterClientMap] not yet ported (gốc 0x248988)");
            return null;
        }

        // VMA: 0x248a14  Source: functions/00248a14_LuaPlayer10LuaBindNpcER10XLuaScript.asm
        // gốc body in 00248a14_LuaPlayer10LuaBindNpcER10XLuaScript.asm (384 bytes ARM64)
        public object BindNpc(params object[] args)
        {
            // TODO: port body from 00248a14_LuaPlayer10LuaBindNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.BindNpc] not yet ported (gốc 0x248a14)");
            return null;
        }

        // VMA: 0x248b94  Source: functions/00248b94_LuaPlayer10LuaHaveNpcER10XLuaScript.asm
        // gốc body in 00248b94_LuaPlayer10LuaHaveNpcER10XLuaScript.asm (48 bytes ARM64)
        public object HaveNpc(params object[] args)
        {
            // TODO: port body from 00248b94_LuaPlayer10LuaHaveNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.HaveNpc] not yet ported (gốc 0x248b94)");
            return null;
        }

        // VMA: 0x248bc4  Source: functions/00248bc4_LuaPlayer14LuaSetPortraitER10XLuaScript.asm
        // gốc body in 00248bc4_LuaPlayer14LuaSetPortraitER10XLuaScript.asm (64 bytes ARM64)
        public object SetPortrait(params object[] args)
        {
            // TODO: port body from 00248bc4_LuaPlayer14LuaSetPortraitER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.SetPortrait] not yet ported (gốc 0x248bc4)");
            return null;
        }

        // VMA: 0x248c04  Source: functions/00248c04_LuaPlayer16LuaGetBaseDamageER10XLuaScript.asm
        // gốc body in 00248c04_LuaPlayer16LuaGetBaseDamageER10XLuaScript.asm (144 bytes ARM64)
        public object GetBaseDamage(params object[] args)
        {
            // TODO: port body from 00248c04_LuaPlayer16LuaGetBaseDamageER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetBaseDamage] not yet ported (gốc 0x248c04)");
            return null;
        }

        // VMA: 0x248c94  Source: functions/00248c94_LuaPlayer16LuaStartProgressER10XLuaScript.asm
        // gốc body in 00248c94_LuaPlayer16LuaStartProgressER10XLuaScript.asm (256 bytes ARM64)
        public object StartProgress(params object[] args)
        {
            // TODO: port body from 00248c94_LuaPlayer16LuaStartProgressER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.StartProgress] not yet ported (gốc 0x248c94)");
            return null;
        }

        // VMA: 0x248d94  Source: functions/00248d94_LuaPlayer15LuaGetUserValueER10XLuaScript.asm
        // gốc body in 00248d94_LuaPlayer15LuaGetUserValueER10XLuaScript.asm (196 bytes ARM64)
        public object GetUserValue(params object[] args)
        {
            // TODO: port body from 00248d94_LuaPlayer15LuaGetUserValueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetUserValue] not yet ported (gốc 0x248d94)");
            return null;
        }

        // VMA: 0x248e58  Source: functions/00248e58_LuaPlayer16LuaDropItemInPosER10XLuaScript.asm
        // gốc body in 00248e58_LuaPlayer16LuaDropItemInPosER10XLuaScript.asm (1956 bytes ARM64)
        public object DropItemInPos(params object[] args)
        {
            // TODO: port body from 00248e58_LuaPlayer16LuaDropItemInPosER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.DropItemInPos] not yet ported (gốc 0x248e58)");
            return null;
        }

        // VMA: 0x249694  Source: functions/00249694_LuaPlayer16LuaGetSkillLevelER10XLuaScript.asm
        // gốc body in 00249694_LuaPlayer16LuaGetSkillLevelER10XLuaScript.asm (160 bytes ARM64)
        public object GetSkillLevel(params object[] args)
        {
            // TODO: port body from 00249694_LuaPlayer16LuaGetSkillLevelER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetSkillLevel] not yet ported (gốc 0x249694)");
            return null;
        }

        // VMA: 0x249734  Source: functions/00249734_LuaPlayer16LuaGetPartnerObjER10XLuaScript.asm
        // gốc body in 00249734_LuaPlayer16LuaGetPartnerObjER10XLuaScript.asm (196 bytes ARM64)
        public object GetPartnerObj(params object[] args)
        {
            // TODO: port body from 00249734_LuaPlayer16LuaGetPartnerObjER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetPartnerObj] not yet ported (gốc 0x249734)");
            return null;
        }

        // VMA: 0x2497f8  Source: functions/002497f8_LuaPlayer16LuaGetAllPartnerER10XLuaScript.asm
        // gốc body in 002497f8_LuaPlayer16LuaGetAllPartnerER10XLuaScript.asm (172 bytes ARM64)
        public object GetAllPartner(params object[] args)
        {
            // TODO: port body from 002497f8_LuaPlayer16LuaGetAllPartnerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetAllPartner] not yet ported (gốc 0x2497f8)");
            return null;
        }

        // VMA: 0x2498a4  Source: functions/002498a4_LuaPlayer20LuaGetPartnerPosInfoER10XLuaScript.asm
        // gốc body in 002498a4_LuaPlayer20LuaGetPartnerPosInfoER10XLuaScript.asm (244 bytes ARM64)
        public object GetPartnerPosInfo(params object[] args)
        {
            // TODO: port body from 002498a4_LuaPlayer20LuaGetPartnerPosInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetPartnerPosInfo] not yet ported (gốc 0x2498a4)");
            return null;
        }

        // VMA: 0x249998  Source: functions/00249998_LuaPlayer15LuaGetValueItemER10XLuaScript.asm
        // gốc body in 00249998_LuaPlayer15LuaGetValueItemER10XLuaScript.asm (104 bytes ARM64)
        public object GetValueItem(params object[] args)
        {
            // TODO: port body from 00249998_LuaPlayer15LuaGetValueItemER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetValueItem] not yet ported (gốc 0x249998)");
            return null;
        }

        // VMA: 0x249a00  Source: functions/00249a00_LuaPlayer18LuaGetAllValueItemER10XLuaScript.asm
        // gốc body in 00249a00_LuaPlayer18LuaGetAllValueItemER10XLuaScript.asm (236 bytes ARM64)
        public object GetAllValueItem(params object[] args)
        {
            // TODO: port body from 00249a00_LuaPlayer18LuaGetAllValueItemER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetAllValueItem] not yet ported (gốc 0x249a00)");
            return null;
        }

        // VMA: 0x249aec  Source: functions/00249aec_LuaPlayer16LuaGetNpcResInfoER10XLuaScript.asm
        // gốc body in 00249aec_LuaPlayer16LuaGetNpcResInfoER10XLuaScript.asm (536 bytes ARM64)
        public object GetNpcResInfo(params object[] args)
        {
            // TODO: port body from 00249aec_LuaPlayer16LuaGetNpcResInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetNpcResInfo] not yet ported (gốc 0x249aec)");
            return null;
        }

        // VMA: 0x249d04  Source: functions/00249d04_LuaPlayer27LuaGetFactionPotencyByLevelER10XLuaScript.asm
        // gốc body in 00249d04_LuaPlayer27LuaGetFactionPotencyByLevelER10XLuaScript.asm (376 bytes ARM64)
        public object GetFactionPotencyByLevel(params object[] args)
        {
            // TODO: port body from 00249d04_LuaPlayer27LuaGetFactionPotencyByLevelER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetFactionPotencyByLevel] not yet ported (gốc 0x249d04)");
            return null;
        }

        // VMA: 0x249e7c  Source: functions/00249e7c_LuaPlayer29LuaGetNextLevelFactionPotencyER10XLuaScript.asm
        // gốc body in 00249e7c_LuaPlayer29LuaGetNextLevelFactionPotencyER10XLuaScript.asm (412 bytes ARM64)
        public object GetNextLevelFactionPotency(params object[] args)
        {
            // TODO: port body from 00249e7c_LuaPlayer29LuaGetNextLevelFactionPotencyER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetNextLevelFactionPotency] not yet ported (gốc 0x249e7c)");
            return null;
        }

        // VMA: 0x24a018  Source: functions/0024a018_LuaPlayer26LuaCheckSkillAvailable2NpcER10XLuaScript.asm
        // gốc body in 0024a018_LuaPlayer26LuaCheckSkillAvailable2NpcER10XLuaScript.asm (336 bytes ARM64)
        public object CheckSkillAvailable2Npc(params object[] args)
        {
            // TODO: port body from 0024a018_LuaPlayer26LuaCheckSkillAvailable2NpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.CheckSkillAvailable2Npc] not yet ported (gốc 0x24a018)");
            return null;
        }

        // VMA: 0x24a168  Source: functions/0024a168_LuaPlayer30LuaCheckRelationSkillAvailableER10XLuaScript.asm
        // gốc body in 0024a168_LuaPlayer30LuaCheckRelationSkillAvailableER10XLuaScript.asm (160 bytes ARM64)
        public object CheckRelationSkillAvailable(params object[] args)
        {
            // TODO: port body from 0024a168_LuaPlayer30LuaCheckRelationSkillAvailableER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.CheckRelationSkillAvailable] not yet ported (gốc 0x24a168)");
            return null;
        }

        // VMA: 0x24a208  Source: functions/0024a208_LuaPlayer11LuaGetDoingER10XLuaScript.asm
        // gốc body in 0024a208_LuaPlayer11LuaGetDoingER10XLuaScript.asm (64 bytes ARM64)
        public object GetDoing(params object[] args)
        {
            // TODO: port body from 0024a208_LuaPlayer11LuaGetDoingER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetDoing] not yet ported (gốc 0x24a208)");
            return null;
        }

        // VMA: 0x24a248  Source: functions/0024a248_LuaPlayer18LuaGetBaseAwardExpER10XLuaScript.asm
        // gốc body in 0024a248_LuaPlayer18LuaGetBaseAwardExpER10XLuaScript.asm (520 bytes ARM64)
        public object GetBaseAwardExp(params object[] args)
        {
            // TODO: port body from 0024a248_LuaPlayer18LuaGetBaseAwardExpER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetBaseAwardExp] not yet ported (gốc 0x24a248)");
            return null;
        }

        // VMA: 0x24a508  Source: functions/0024a508_LuaPlayer21LuaModifyFeatureEquipER10XLuaScript.asm
        // gốc body in 0024a508_LuaPlayer21LuaModifyFeatureEquipER10XLuaScript.asm (332 bytes ARM64)
        public object ModifyFeatureEquip(params object[] args)
        {
            // TODO: port body from 0024a508_LuaPlayer21LuaModifyFeatureEquipER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.ModifyFeatureEquip] not yet ported (gốc 0x24a508)");
            return null;
        }

        // VMA: 0x24a654  Source: functions/0024a654_LuaPlayer19LuaApplyWLZExAttribER10XLuaScript.asm
        // gốc body in 0024a654_LuaPlayer19LuaApplyWLZExAttribER10XLuaScript.asm (452 bytes ARM64)
        public object ApplyWLZExAttrib(params object[] args)
        {
            // TODO: port body from 0024a654_LuaPlayer19LuaApplyWLZExAttribER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.ApplyWLZExAttrib] not yet ported (gốc 0x24a654)");
            return null;
        }

        // VMA: 0x24a818  Source: functions/0024a818_LuaPlayer17LuaClearLinkSkillER10XLuaScript.asm
        // gốc body in 0024a818_LuaPlayer17LuaClearLinkSkillER10XLuaScript.asm (28 bytes ARM64)
        public object ClearLinkSkill(params object[] args)
        {
            // TODO: port body from 0024a818_LuaPlayer17LuaClearLinkSkillER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.ClearLinkSkill] not yet ported (gốc 0x24a818)");
            return null;
        }

        // VMA: 0x24a834  Source: functions/0024a834_LuaPlayer20LuaApplyExternAttribER10XLuaScript.asm
        // gốc body in 0024a834_LuaPlayer20LuaApplyExternAttribER10XLuaScript.asm (120 bytes ARM64)
        public object ApplyExternAttrib(params object[] args)
        {
            // TODO: port body from 0024a834_LuaPlayer20LuaApplyExternAttribER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.ApplyExternAttrib] not yet ported (gốc 0x24a834)");
            return null;
        }

        // VMA: 0x24a8ac  Source: functions/0024a8ac_LuaPlayer21LuaRemoveExternAttribER10XLuaScript.asm
        // gốc body in 0024a8ac_LuaPlayer21LuaRemoveExternAttribER10XLuaScript.asm (64 bytes ARM64)
        public object RemoveExternAttrib(params object[] args)
        {
            // TODO: port body from 0024a8ac_LuaPlayer21LuaRemoveExternAttribER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.RemoveExternAttrib] not yet ported (gốc 0x24a8ac)");
            return null;
        }

        // VMA: 0x24a8ec  Source: functions/0024a8ec_LuaPlayer21LuaGetCanMoveDistanceER10XLuaScript.asm
        // gốc body in 0024a8ec_LuaPlayer21LuaGetCanMoveDistanceER10XLuaScript.asm (196 bytes ARM64)
        public object GetCanMoveDistance(params object[] args)
        {
            // TODO: port body from 0024a8ec_LuaPlayer21LuaGetCanMoveDistanceER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetCanMoveDistance] not yet ported (gốc 0x24a8ec)");
            return null;
        }

        // VMA: 0x24a9b0  Source: functions/0024a9b0_LuaPlayer19LuaApplyMagicAttribER10XLuaScript.asm
        // gốc body in 0024a9b0_LuaPlayer19LuaApplyMagicAttribER10XLuaScript.asm (444 bytes ARM64)
        public object ApplyMagicAttrib(params object[] args)
        {
            // TODO: port body from 0024a9b0_LuaPlayer19LuaApplyMagicAttribER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.ApplyMagicAttrib] not yet ported (gốc 0x24a9b0)");
            return null;
        }

        // VMA: 0x24ab6c  Source: functions/0024ab6c_LuaPlayer20LuaRemoveMagicAttribER10XLuaScript.asm
        // gốc body in 0024ab6c_LuaPlayer20LuaRemoveMagicAttribER10XLuaScript.asm (444 bytes ARM64)
        public object RemoveMagicAttrib(params object[] args)
        {
            // TODO: port body from 0024ab6c_LuaPlayer20LuaRemoveMagicAttribER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.RemoveMagicAttrib] not yet ported (gốc 0x24ab6c)");
            return null;
        }

        // VMA: 0x24ad28  Source: functions/0024ad28_LuaPlayer13LuaGetBarrierER10XLuaScript.asm
        // gốc body in 0024ad28_LuaPlayer13LuaGetBarrierER10XLuaScript.asm (140 bytes ARM64)
        public object GetBarrier(params object[] args)
        {
            // TODO: port body from 0024ad28_LuaPlayer13LuaGetBarrierER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetBarrier] not yet ported (gốc 0x24ad28)");
            return null;
        }

        // VMA: 0x24adb4  Source: functions/0024adb4_LuaPlayer21LuaDoSpecicalMoveStepER10XLuaScript.asm
        // gốc body in 0024adb4_LuaPlayer21LuaDoSpecicalMoveStepER10XLuaScript.asm (196 bytes ARM64)
        public object DoSpecicalMoveStep(params object[] args)
        {
            // TODO: port body from 0024adb4_LuaPlayer21LuaDoSpecicalMoveStepER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.DoSpecicalMoveStep] not yet ported (gốc 0x24adb4)");
            return null;
        }

        // VMA: 0x24ae78  Source: functions/0024ae78_LuaPlayer19LuaSetPlayerSkillCDER10XLuaScript.asm
        // gốc body in 0024ae78_LuaPlayer19LuaSetPlayerSkillCDER10XLuaScript.asm (192 bytes ARM64)
        public object SetPlayerSkillCD(params object[] args)
        {
            // TODO: port body from 0024ae78_LuaPlayer19LuaSetPlayerSkillCDER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.SetPlayerSkillCD] not yet ported (gốc 0x24ae78)");
            return null;
        }

        // VMA: 0x24af38  Source: functions/0024af38_LuaPlayer10LuaAddItemER10XLuaScript.asm
        // gốc body in 0024af38_LuaPlayer10LuaAddItemER10XLuaScript.asm (700 bytes ARM64)
        public object AddItem(params object[] args)
        {
            // TODO: port body from 0024af38_LuaPlayer10LuaAddItemER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.AddItem] not yet ported (gốc 0x24af38)");
            return null;
        }

        // VMA: 0x24b1f4  Source: functions/0024b1f4_LuaPlayer16LuaAddItemUnsafeER10XLuaScript.asm
        // gốc body in 0024b1f4_LuaPlayer16LuaAddItemUnsafeER10XLuaScript.asm (700 bytes ARM64)
        public object AddItemUnsafe(params object[] args)
        {
            // TODO: port body from 0024b1f4_LuaPlayer16LuaAddItemUnsafeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.AddItemUnsafe] not yet ported (gốc 0x24b1f4)");
            return null;
        }

        // VMA: 0x24b4b0  Source: functions/0024b4b0_LuaPlayer11LuaUseEquipER10XLuaScript.asm
        // gốc body in 0024b4b0_LuaPlayer11LuaUseEquipER10XLuaScript.asm (224 bytes ARM64)
        public object UseEquip(params object[] args)
        {
            // TODO: port body from 0024b4b0_LuaPlayer11LuaUseEquipER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.UseEquip] not yet ported (gốc 0x24b4b0)");
            return null;
        }

        // VMA: 0x24b590  Source: functions/0024b590_LuaPlayer13LuaUnuseEquipER10XLuaScript.asm
        // gốc body in 0024b590_LuaPlayer13LuaUnuseEquipER10XLuaScript.asm (64 bytes ARM64)
        public object UnuseEquip(params object[] args)
        {
            // TODO: port body from 0024b590_LuaPlayer13LuaUnuseEquipER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.UnuseEquip] not yet ported (gốc 0x24b590)");
            return null;
        }

        // VMA: 0x24b5d0  Source: functions/0024b5d0_LuaPlayer17LuaUnuseEquipByIdER10XLuaScript.asm
        // gốc body in 0024b5d0_LuaPlayer17LuaUnuseEquipByIdER10XLuaScript.asm (136 bytes ARM64)
        public object UnuseEquipById(params object[] args)
        {
            // TODO: port body from 0024b5d0_LuaPlayer17LuaUnuseEquipByIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.UnuseEquipById] not yet ported (gốc 0x24b5d0)");
            return null;
        }

        // VMA: 0x24b658  Source: functions/0024b658_LuaPlayer16LuaAddAttrTitlesER10XLuaScript.asm
        // gốc body in 0024b658_LuaPlayer16LuaAddAttrTitlesER10XLuaScript.asm (132 bytes ARM64)
        public object AddAttrTitles(params object[] args)
        {
            // TODO: port body from 0024b658_LuaPlayer16LuaAddAttrTitlesER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.AddAttrTitles] not yet ported (gốc 0x24b658)");
            return null;
        }

        // VMA: 0x24b6dc  Source: functions/0024b6dc_LuaPlayer15LuaAddAttrTitleER10XLuaScript.asm
        // gốc body in 0024b6dc_LuaPlayer15LuaAddAttrTitleER10XLuaScript.asm (76 bytes ARM64)
        public object AddAttrTitle(params object[] args)
        {
            // TODO: port body from 0024b6dc_LuaPlayer15LuaAddAttrTitleER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.AddAttrTitle] not yet ported (gốc 0x24b6dc)");
            return null;
        }

        // VMA: 0x24b728  Source: functions/0024b728_LuaPlayer11LuaDelTitleER10XLuaScript.asm
        // gốc body in 0024b728_LuaPlayer11LuaDelTitleER10XLuaScript.asm (76 bytes ARM64)
        public object DelTitle(params object[] args)
        {
            // TODO: port body from 0024b728_LuaPlayer11LuaDelTitleER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.DelTitle] not yet ported (gốc 0x24b728)");
            return null;
        }

        // VMA: 0x24b774  Source: functions/0024b774_LuaPlayer16LuaGetAttrTitlesER10XLuaScript.asm
        // gốc body in 0024b774_LuaPlayer16LuaGetAttrTitlesER10XLuaScript.asm (364 bytes ARM64)
        public object GetAttrTitles(params object[] args)
        {
            // TODO: port body from 0024b774_LuaPlayer16LuaGetAttrTitlesER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.GetAttrTitles] not yet ported (gốc 0x24b774)");
            return null;
        }

        // VMA: 0x24b8e0  Source: functions/0024b8e0_LuaPlayer16LuaAddTitlesAttrER10XLuaScript.asm
        // gốc body in 0024b8e0_LuaPlayer16LuaAddTitlesAttrER10XLuaScript.asm (264 bytes ARM64)
        public object AddTitlesAttr(params object[] args)
        {
            // TODO: port body from 0024b8e0_LuaPlayer16LuaAddTitlesAttrER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.AddTitlesAttr] not yet ported (gốc 0x24b8e0)");
            return null;
        }

        // VMA: 0x24b9e8  Source: functions/0024b9e8_LuaPlayer15LuaAddTitleAttrER10XLuaScript.asm
        // gốc body in 0024b9e8_LuaPlayer15LuaAddTitleAttrER10XLuaScript.asm (188 bytes ARM64)
        public object AddTitleAttr(params object[] args)
        {
            // TODO: port body from 0024b9e8_LuaPlayer15LuaAddTitleAttrER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.AddTitleAttr] not yet ported (gốc 0x24b9e8)");
            return null;
        }

        // VMA: 0x24baa4  Source: functions/0024baa4_LuaPlayer18LuaRemoveTitleAttrER10XLuaScript.asm
        // gốc body in 0024baa4_LuaPlayer18LuaRemoveTitleAttrER10XLuaScript.asm (188 bytes ARM64)
        public object RemoveTitleAttr(params object[] args)
        {
            // TODO: port body from 0024baa4_LuaPlayer18LuaRemoveTitleAttrER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.RemoveTitleAttr] not yet ported (gốc 0x24baa4)");
            return null;
        }

        // VMA: 0x24bb60  Source: functions/0024bb60_LuaPlayer12LuaIsCanPathER10XLuaScript.asm
        // gốc body in 0024bb60_LuaPlayer12LuaIsCanPathER10XLuaScript.asm (212 bytes ARM64)
        public object IsCanPath(params object[] args)
        {
            // TODO: port body from 0024bb60_LuaPlayer12LuaIsCanPathER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.IsCanPath] not yet ported (gốc 0x24bb60)");
            return null;
        }

        // VMA: 0x24bc34  Source: functions/0024bc34_LuaPlayer13LuaSetFactionER10XLuaScript.asm
        // gốc body in 0024bc34_LuaPlayer13LuaSetFactionER10XLuaScript.asm (400 bytes ARM64)
        public object SetFaction(params object[] args)
        {
            // TODO: port body from 0024bc34_LuaPlayer13LuaSetFactionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.SetFaction] not yet ported (gốc 0x24bc34)");
            return null;
        }

        // VMA: 0x24bdc4  Source: functions/0024bdc4_LuaPlayer19LuaBackToNavigationER10XLuaScript.asm
        // gốc body in 0024bdc4_LuaPlayer19LuaBackToNavigationER10XLuaScript.asm (692 bytes ARM64)
        public object BackToNavigation(params object[] args)
        {
            // TODO: port body from 0024bdc4_LuaPlayer19LuaBackToNavigationER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.BackToNavigation] not yet ported (gốc 0x24bdc4)");
            return null;
        }

        // VMA: 0x24c078  Source: functions/0024c078_LuaPlayer17LuaSetCaptainFalgER10XLuaScript.asm
        // gốc body in 0024c078_LuaPlayer17LuaSetCaptainFalgER10XLuaScript.asm (60 bytes ARM64)
        public object SetCaptainFalg(params object[] args)
        {
            // TODO: port body from 0024c078_LuaPlayer17LuaSetCaptainFalgER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.SetCaptainFalg] not yet ported (gốc 0x24c078)");
            return null;
        }

        // VMA: 0x24c0b4  Source: functions/0024c0b4_LuaPlayer25LuaUpdateZongShiLevelDataER10XLuaScript.asm
        // gốc body in 0024c0b4_LuaPlayer25LuaUpdateZongShiLevelDataER10XLuaScript.asm (148 bytes ARM64)
        public object UpdateZongShiLevelData(params object[] args)
        {
            // TODO: port body from 0024c0b4_LuaPlayer25LuaUpdateZongShiLevelDataER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[MePlayer.UpdateZongShiLevelData] not yet ported (gốc 0x24c0b4)");
            return null;
        }

        // ============ Other methods ============
        // VMA: 0x24545c  Source: functions/0024545c_LuaPlayer5GetMeER10XLuaScripti.asm
        public object GetMe(params object[] args)
        {
            UnityEngine.Debug.LogWarning($"[MePlayer.GetMe] not yet ported (gốc 0x24545c)");
            return null;
        }

        // VMA: 0x245498  Source: functions/00245498_LuaPlayer14ClearTempTableEv.asm
        public object ClearTempTable(params object[] args)
        {
            UnityEngine.Debug.LogWarning($"[MePlayer.ClearTempTable] not yet ported (gốc 0x245498)");
            return null;
        }

        // VMA: 0x2454bc  Source: functions/002454bc_LuaPlayer16ClearScriptTableEv.asm
        public object ClearScriptTable(params object[] args)
        {
            UnityEngine.Debug.LogWarning($"[MePlayer.ClearScriptTable] not yet ported (gốc 0x2454bc)");
            return null;
        }

        // VMA: 0x26d33c  Source: functions/0026d33c_LuaPlayer8PushCObjEP9lua_State.asm
        public object PushCObj(params object[] args)
        {
            UnityEngine.Debug.LogWarning($"[MePlayer.PushCObj] not yet ported (gốc 0x26d33c)");
            return null;
        }

    }

    /// <summary>Data backing for MePlayer — mirrors C++ underlying object fields.</summary>
    public class MePlayerData
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
