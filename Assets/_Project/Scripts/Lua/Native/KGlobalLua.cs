// Class:  KGlobalLua  (gốc native binding `LuaGlobalScriptNameSpace` from libclient_scene.so)
// Source: KTO_LibClientScene_Decompiled/INDEX.tsv (132 methods)
// XLua global: `Global` (registered via LuaEnv.Global.Set)
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
    public class KGlobalLua
    {
        // Underlying C++ KPlayer/KNpc/KItem proxy (state holder).
        // gốc: LuaPlayer.this->player_ptr at offset +8 in C++ object.
        public KGlobalLuaData Data { get; set; } = new KGlobalLuaData();

        // ============ Properties (paired getX/setX) ============
        // ============ Lua-callable methods (LuaXxx) ============
        // VMA: 0x23658c  Source: functions/0023658c_LuaGlobalScriptNameSpace19LuaReloadMapSettingER10XLuaScript.asm
        // gốc body in 0023658c_LuaGlobalScriptNameSpace19LuaReloadMapSettingER10XLuaScript.asm (64 bytes ARM64)
        public object ReloadMapSetting(params object[] args)
        {
            // TODO: port body from 0023658c_LuaGlobalScriptNameSpace19LuaReloadMapSettingER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ReloadMapSetting] not yet ported (gốc 0x23658c)");
            return null;
        }

        // VMA: 0x2365cc  Source: functions/002365cc_LuaGlobalScriptNameSpace18LuaReloadTimeFrameER10XLuaScript.asm
        // gốc body in 002365cc_LuaGlobalScriptNameSpace18LuaReloadTimeFrameER10XLuaScript.asm (64 bytes ARM64)
        public object ReloadTimeFrame(params object[] args)
        {
            // TODO: port body from 002365cc_LuaGlobalScriptNameSpace18LuaReloadTimeFrameER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ReloadTimeFrame] not yet ported (gốc 0x2365cc)");
            return null;
        }

        // VMA: 0x23660c  Source: functions/0023660c_LuaGlobalScriptNameSpace21LuaRegisterTimerPointER10XLuaScript.asm
        // gốc body in 0023660c_LuaGlobalScriptNameSpace21LuaRegisterTimerPointER10XLuaScript.asm (76 bytes ARM64)
        public object RegisterTimerPoint(params object[] args)
        {
            // TODO: port body from 0023660c_LuaGlobalScriptNameSpace21LuaRegisterTimerPointER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.RegisterTimerPoint] not yet ported (gốc 0x23660c)");
            return null;
        }

        // VMA: 0x236658  Source: functions/00236658_LuaGlobalScriptNameSpace12LuaGMCommandER10XLuaScript.asm
        // gốc body in 00236658_LuaGlobalScriptNameSpace12LuaGMCommandER10XLuaScript.asm (356 bytes ARM64)
        public object GMCommand(params object[] args)
        {
            // TODO: port body from 00236658_LuaGlobalScriptNameSpace12LuaGMCommandER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GMCommand] not yet ported (gốc 0x236658)");
            return null;
        }

        // VMA: 0x2367bc  Source: functions/002367bc_LuaGlobalScriptNameSpace14LuaGetRoleListER10XLuaScript.asm
        // gốc body in 002367bc_LuaGlobalScriptNameSpace14LuaGetRoleListER10XLuaScript.asm (748 bytes ARM64)
        public object GetRoleList(params object[] args)
        {
            // TODO: port body from 002367bc_LuaGlobalScriptNameSpace14LuaGetRoleListER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetRoleList] not yet ported (gốc 0x2367bc)");
            return null;
        }

        // VMA: 0x236aa8  Source: functions/00236aa8_LuaGlobalScriptNameSpace12LuaLoginRoleER10XLuaScript.asm
        // gốc body in 00236aa8_LuaGlobalScriptNameSpace12LuaLoginRoleER10XLuaScript.asm (52 bytes ARM64)
        public object LoginRole(params object[] args)
        {
            // TODO: port body from 00236aa8_LuaGlobalScriptNameSpace12LuaLoginRoleER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.LoginRole] not yet ported (gốc 0x236aa8)");
            return null;
        }

        // VMA: 0x236adc  Source: functions/00236adc_LuaGlobalScriptNameSpace17LuaConnectGatewayER10XLuaScript.asm
        // gốc body in 00236adc_LuaGlobalScriptNameSpace17LuaConnectGatewayER10XLuaScript.asm (140 bytes ARM64)
        public object ConnectGateway(params object[] args)
        {
            // TODO: port body from 00236adc_LuaGlobalScriptNameSpace17LuaConnectGatewayER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ConnectGateway] not yet ported (gốc 0x236adc)");
            return null;
        }

        // VMA: 0x236b68  Source: functions/00236b68_LuaGlobalScriptNameSpace21LuaConnectWorldServerER10XLuaScript.asm
        // gốc body in 00236b68_LuaGlobalScriptNameSpace21LuaConnectWorldServerER10XLuaScript.asm (92 bytes ARM64)
        public object ConnectWorldServer(params object[] args)
        {
            // TODO: port body from 00236b68_LuaGlobalScriptNameSpace21LuaConnectWorldServerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ConnectWorldServer] not yet ported (gốc 0x236b68)");
            return null;
        }

        // VMA: 0x236bc4  Source: functions/00236bc4_LuaGlobalScriptNameSpace31LuaSetWorldServerConnectTimeoutER10XLuaScript.asm
        // gốc body in 00236bc4_LuaGlobalScriptNameSpace31LuaSetWorldServerConnectTimeoutER10XLuaScript.asm (60 bytes ARM64)
        public object SetWorldServerConnectTimeout(params object[] args)
        {
            // TODO: port body from 00236bc4_LuaGlobalScriptNameSpace31LuaSetWorldServerConnectTimeoutER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SetWorldServerConnectTimeout] not yet ported (gốc 0x236bc4)");
            return null;
        }

        // VMA: 0x236c00  Source: functions/00236c00_LuaGlobalScriptNameSpace16LuaConnectServerER10XLuaScript.asm
        // gốc body in 00236c00_LuaGlobalScriptNameSpace16LuaConnectServerER10XLuaScript.asm (60 bytes ARM64)
        public object ConnectServer(params object[] args)
        {
            // TODO: port body from 00236c00_LuaGlobalScriptNameSpace16LuaConnectServerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ConnectServer] not yet ported (gốc 0x236c00)");
            return null;
        }

        // VMA: 0x236c3c  Source: functions/00236c3c_LuaGlobalScriptNameSpace18LuaReconnectServerER10XLuaScript.asm
        // gốc body in 00236c3c_LuaGlobalScriptNameSpace18LuaReconnectServerER10XLuaScript.asm (64 bytes ARM64)
        public object ReconnectServer(params object[] args)
        {
            // TODO: port body from 00236c3c_LuaGlobalScriptNameSpace18LuaReconnectServerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ReconnectServer] not yet ported (gốc 0x236c3c)");
            return null;
        }

        // VMA: 0x236c7c  Source: functions/00236c7c_LuaGlobalScriptNameSpace10LuaIsAloneER10XLuaScript.asm
        // gốc body in 00236c7c_LuaGlobalScriptNameSpace10LuaIsAloneER10XLuaScript.asm (48 bytes ARM64)
        public object IsAlone(params object[] args)
        {
            // TODO: port body from 00236c7c_LuaGlobalScriptNameSpace10LuaIsAloneER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.IsAlone] not yet ported (gốc 0x236c7c)");
            return null;
        }

        // VMA: 0x236cac  Source: functions/00236cac_LuaGlobalScriptNameSpace16LuaSetStandAloneER10XLuaScript.asm
        // gốc body in 00236cac_LuaGlobalScriptNameSpace16LuaSetStandAloneER10XLuaScript.asm (60 bytes ARM64)
        public object SetStandAlone(params object[] args)
        {
            // TODO: port body from 00236cac_LuaGlobalScriptNameSpace16LuaSetStandAloneER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SetStandAlone] not yet ported (gốc 0x236cac)");
            return null;
        }

        // VMA: 0x236ce8  Source: functions/00236ce8_LuaGlobalScriptNameSpace20LuaSetGameWorldScaleER10XLuaScript.asm
        // gốc body in 00236ce8_LuaGlobalScriptNameSpace20LuaSetGameWorldScaleER10XLuaScript.asm (48 bytes ARM64)
        public object SetGameWorldScale(params object[] args)
        {
            // TODO: port body from 00236ce8_LuaGlobalScriptNameSpace20LuaSetGameWorldScaleER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SetGameWorldScale] not yet ported (gốc 0x236ce8)");
            return null;
        }

        // VMA: 0x236d18  Source: functions/00236d18_LuaGlobalScriptNameSpace14LuaSetVSyncFPSER10XLuaScript.asm
        // gốc body in 00236d18_LuaGlobalScriptNameSpace14LuaSetVSyncFPSER10XLuaScript.asm (100 bytes ARM64)
        public object SetVSyncFPS(params object[] args)
        {
            // TODO: port body from 00236d18_LuaGlobalScriptNameSpace14LuaSetVSyncFPSER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SetVSyncFPS] not yet ported (gốc 0x236d18)");
            return null;
        }

        // VMA: 0x236d7c  Source: functions/00236d7c_LuaGlobalScriptNameSpace21LuaCloseServerConnectER10XLuaScript.asm
        // gốc body in 00236d7c_LuaGlobalScriptNameSpace21LuaCloseServerConnectER10XLuaScript.asm (52 bytes ARM64)
        public object CloseServerConnect(params object[] args)
        {
            // TODO: port body from 00236d7c_LuaGlobalScriptNameSpace21LuaCloseServerConnectER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.CloseServerConnect] not yet ported (gốc 0x236d7c)");
            return null;
        }

        // VMA: 0x236db0  Source: functions/00236db0_LuaGlobalScriptNameSpace22LuaCloseGateWayConnectER10XLuaScript.asm
        // gốc body in 00236db0_LuaGlobalScriptNameSpace22LuaCloseGateWayConnectER10XLuaScript.asm (36 bytes ARM64)
        public object CloseGateWayConnect(params object[] args)
        {
            // TODO: port body from 00236db0_LuaGlobalScriptNameSpace22LuaCloseGateWayConnectER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.CloseGateWayConnect] not yet ported (gốc 0x236db0)");
            return null;
        }

        // VMA: 0x236dd4  Source: functions/00236dd4_LuaGlobalScriptNameSpace10LuaGetTimeER10XLuaScript.asm
        // gốc body in 00236dd4_LuaGlobalScriptNameSpace10LuaGetTimeER10XLuaScript.asm (64 bytes ARM64)
        public object GetTime(params object[] args)
        {
            // TODO: port body from 00236dd4_LuaGlobalScriptNameSpace10LuaGetTimeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetTime] not yet ported (gốc 0x236dd4)");
            return null;
        }

        // VMA: 0x236e14  Source: functions/00236e14_LuaGlobalScriptNameSpace18LuaForbidReconnectER10XLuaScript.asm
        // gốc body in 00236e14_LuaGlobalScriptNameSpace18LuaForbidReconnectER10XLuaScript.asm (44 bytes ARM64)
        public object ForbidReconnect(params object[] args)
        {
            // TODO: port body from 00236e14_LuaGlobalScriptNameSpace18LuaForbidReconnectER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ForbidReconnect] not yet ported (gốc 0x236e14)");
            return null;
        }

        // VMA: 0x236e40  Source: functions/00236e40_LuaGlobalScriptNameSpace9LuaLogoutER10XLuaScript.asm
        // gốc body in 00236e40_LuaGlobalScriptNameSpace9LuaLogoutER10XLuaScript.asm (36 bytes ARM64)
        public object Logout(params object[] args)
        {
            // TODO: port body from 00236e40_LuaGlobalScriptNameSpace9LuaLogoutER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.Logout] not yet ported (gốc 0x236e40)");
            return null;
        }

        // VMA: 0x236e64  Source: functions/00236e64_LuaGlobalScriptNameSpace21LuaSendChannelMessageER10XLuaScript.asm
        // gốc body in 00236e64_LuaGlobalScriptNameSpace21LuaSendChannelMessageER10XLuaScript.asm (892 bytes ARM64)
        public object SendChannelMessage(params object[] args)
        {
            // TODO: port body from 00236e64_LuaGlobalScriptNameSpace21LuaSendChannelMessageER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SendChannelMessage] not yet ported (gốc 0x236e64)");
            return null;
        }

        // VMA: 0x2371e0  Source: functions/002371e0_LuaGlobalScriptNameSpace20LuaIsServerConnectedER10XLuaScript.asm
        // gốc body in 002371e0_LuaGlobalScriptNameSpace20LuaIsServerConnectedER10XLuaScript.asm (56 bytes ARM64)
        public object IsServerConnected(params object[] args)
        {
            // TODO: port body from 002371e0_LuaGlobalScriptNameSpace20LuaIsServerConnectedER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.IsServerConnected] not yet ported (gốc 0x2371e0)");
            return null;
        }

        // VMA: 0x237218  Source: functions/00237218_LuaGlobalScriptNameSpace21LuaSendPrivateMessageER10XLuaScript.asm
        // gốc body in 00237218_LuaGlobalScriptNameSpace21LuaSendPrivateMessageER10XLuaScript.asm (660 bytes ARM64)
        public object SendPrivateMessage(params object[] args)
        {
            // TODO: port body from 00237218_LuaGlobalScriptNameSpace21LuaSendPrivateMessageER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SendPrivateMessage] not yet ported (gốc 0x237218)");
            return null;
        }

        // VMA: 0x2374ac  Source: functions/002374ac_LuaGlobalScriptNameSpace18LuaBindCameraToNpcER10XLuaScript.asm
        // gốc body in 002374ac_LuaGlobalScriptNameSpace18LuaBindCameraToNpcER10XLuaScript.asm (104 bytes ARM64)
        public object BindCameraToNpc(params object[] args)
        {
            // TODO: port body from 002374ac_LuaGlobalScriptNameSpace18LuaBindCameraToNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.BindCameraToNpc] not yet ported (gốc 0x2374ac)");
            return null;
        }

        // VMA: 0x237514  Source: functions/00237514_LuaGlobalScriptNameSpace20LuaRequestServerListER10XLuaScript.asm
        // gốc body in 00237514_LuaGlobalScriptNameSpace20LuaRequestServerListER10XLuaScript.asm (36 bytes ARM64)
        public object RequestServerList(params object[] args)
        {
            // TODO: port body from 00237514_LuaGlobalScriptNameSpace20LuaRequestServerListER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.RequestServerList] not yet ported (gốc 0x237514)");
            return null;
        }

        // VMA: 0x237538  Source: functions/00237538_LuaGlobalScriptNameSpace26LuaRequestRankServerCommonER10XLuaScript.asm
        // gốc body in 00237538_LuaGlobalScriptNameSpace26LuaRequestRankServerCommonER10XLuaScript.asm (132 bytes ARM64)
        public object RequestRankServerCommon(params object[] args)
        {
            // TODO: port body from 00237538_LuaGlobalScriptNameSpace26LuaRequestRankServerCommonER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.RequestRankServerCommon] not yet ported (gốc 0x237538)");
            return null;
        }

        // VMA: 0x2375bc  Source: functions/002375bc_LuaGlobalScriptNameSpace20LuaRequestAccSerInfoER10XLuaScript.asm
        // gốc body in 002375bc_LuaGlobalScriptNameSpace20LuaRequestAccSerInfoER10XLuaScript.asm (36 bytes ARM64)
        public object RequestAccSerInfo(params object[] args)
        {
            // TODO: port body from 002375bc_LuaGlobalScriptNameSpace20LuaRequestAccSerInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.RequestAccSerInfo] not yet ported (gốc 0x2375bc)");
            return null;
        }

        // VMA: 0x2375e0  Source: functions/002375e0_LuaGlobalScriptNameSpace23LuaRequestAccountActiveER10XLuaScript.asm
        // gốc body in 002375e0_LuaGlobalScriptNameSpace23LuaRequestAccountActiveER10XLuaScript.asm (60 bytes ARM64)
        public object RequestAccountActive(params object[] args)
        {
            // TODO: port body from 002375e0_LuaGlobalScriptNameSpace23LuaRequestAccountActiveER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.RequestAccountActive] not yet ported (gốc 0x2375e0)");
            return null;
        }

        // VMA: 0x23761c  Source: functions/0023761c_LuaGlobalScriptNameSpace17LuaGetAccountNameER10XLuaScript.asm
        // gốc body in 0023761c_LuaGlobalScriptNameSpace17LuaGetAccountNameER10XLuaScript.asm (36 bytes ARM64)
        public object GetAccountName(params object[] args)
        {
            // TODO: port body from 0023761c_LuaGlobalScriptNameSpace17LuaGetAccountNameER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetAccountName] not yet ported (gốc 0x23761c)");
            return null;
        }

        // VMA: 0x237640  Source: functions/00237640_LuaGlobalScriptNameSpace19LuaGetCertificationER10XLuaScript.asm
        // gốc body in 00237640_LuaGlobalScriptNameSpace19LuaGetCertificationER10XLuaScript.asm (48 bytes ARM64)
        public object GetCertification(params object[] args)
        {
            // TODO: port body from 00237640_LuaGlobalScriptNameSpace19LuaGetCertificationER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetCertification] not yet ported (gốc 0x237640)");
            return null;
        }

        // VMA: 0x237670  Source: functions/00237670_LuaGlobalScriptNameSpace16LuaGetServerListER10XLuaScript.asm
        // gốc body in 00237670_LuaGlobalScriptNameSpace16LuaGetServerListER10XLuaScript.asm (320 bytes ARM64)
        public object GetServerList(params object[] args)
        {
            // TODO: port body from 00237670_LuaGlobalScriptNameSpace16LuaGetServerListER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetServerList] not yet ported (gốc 0x237670)");
            return null;
        }

        // VMA: 0x2377b0  Source: functions/002377b0_LuaGlobalScriptNameSpace18LuaGetServerRegionER10XLuaScript.asm
        // gốc body in 002377b0_LuaGlobalScriptNameSpace18LuaGetServerRegionER10XLuaScript.asm (208 bytes ARM64)
        public object GetServerRegion(params object[] args)
        {
            // TODO: port body from 002377b0_LuaGlobalScriptNameSpace18LuaGetServerRegionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetServerRegion] not yet ported (gốc 0x2377b0)");
            return null;
        }

        // VMA: 0x237880  Source: functions/00237880_LuaGlobalScriptNameSpace16LuaGetServerNameER10XLuaScript.asm
        // gốc body in 00237880_LuaGlobalScriptNameSpace16LuaGetServerNameER10XLuaScript.asm (136 bytes ARM64)
        public object GetServerName(params object[] args)
        {
            // TODO: port body from 00237880_LuaGlobalScriptNameSpace16LuaGetServerNameER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetServerName] not yet ported (gốc 0x237880)");
            return null;
        }

        // VMA: 0x237908  Source: functions/00237908_LuaGlobalScriptNameSpace16LuaParseLinkDataER10XLuaScript.asm
        // gốc body in 00237908_LuaGlobalScriptNameSpace16LuaParseLinkDataER10XLuaScript.asm (164 bytes ARM64)
        public object ParseLinkData(params object[] args)
        {
            // TODO: port body from 00237908_LuaGlobalScriptNameSpace16LuaParseLinkDataER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ParseLinkData] not yet ported (gốc 0x237908)");
            return null;
        }

        // VMA: 0x2379ac  Source: functions/002379ac_LuaGlobalScriptNameSpace22LuaGetServerCreateTimeER10XLuaScript.asm
        // gốc body in 002379ac_LuaGlobalScriptNameSpace22LuaGetServerCreateTimeER10XLuaScript.asm (44 bytes ARM64)
        public object GetServerCreateTime(params object[] args)
        {
            // TODO: port body from 002379ac_LuaGlobalScriptNameSpace22LuaGetServerCreateTimeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetServerCreateTime] not yet ported (gốc 0x2379ac)");
            return null;
        }

        // VMA: 0x2379d8  Source: functions/002379d8_LuaGlobalScriptNameSpace14LuaTraverseDirER10XLuaScript.asm
        // gốc body in 002379d8_LuaGlobalScriptNameSpace14LuaTraverseDirER10XLuaScript.asm (480 bytes ARM64)
        public object TraverseDir(params object[] args)
        {
            // TODO: port body from 002379d8_LuaGlobalScriptNameSpace14LuaTraverseDirER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.TraverseDir] not yet ported (gốc 0x2379d8)");
            return null;
        }

        // VMA: 0x237cf0  Source: functions/00237cf0_LuaGlobalScriptNameSpace18LuaGiveUpWaitQueueER10XLuaScript.asm
        // gốc body in 00237cf0_LuaGlobalScriptNameSpace18LuaGiveUpWaitQueueER10XLuaScript.asm (36 bytes ARM64)
        public object GiveUpWaitQueue(params object[] args)
        {
            // TODO: port body from 00237cf0_LuaGlobalScriptNameSpace18LuaGiveUpWaitQueueER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GiveUpWaitQueue] not yet ported (gốc 0x237cf0)");
            return null;
        }

        // VMA: 0x237d14  Source: functions/00237d14_LuaGlobalScriptNameSpace11LuaCloseMapER10XLuaScript.asm
        // gốc body in 00237d14_LuaGlobalScriptNameSpace11LuaCloseMapER10XLuaScript.asm (100 bytes ARM64)
        public object CloseMap(params object[] args)
        {
            // TODO: port body from 00237d14_LuaGlobalScriptNameSpace11LuaCloseMapER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.CloseMap] not yet ported (gốc 0x237d14)");
            return null;
        }

        // VMA: 0x237d78  Source: functions/00237d78_LuaGlobalScriptNameSpace20LuaStartRecordScreenER10XLuaScript.asm
        // gốc body in 00237d78_LuaGlobalScriptNameSpace20LuaStartRecordScreenER10XLuaScript.asm (28 bytes ARM64)
        public object StartRecordScreen(params object[] args)
        {
            // TODO: port body from 00237d78_LuaGlobalScriptNameSpace20LuaStartRecordScreenER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.StartRecordScreen] not yet ported (gốc 0x237d78)");
            return null;
        }

        // VMA: 0x237d94  Source: functions/00237d94_LuaGlobalScriptNameSpace19LuaStopRecordScreenER10XLuaScript.asm
        // gốc body in 00237d94_LuaGlobalScriptNameSpace19LuaStopRecordScreenER10XLuaScript.asm (8 bytes ARM64)
        public object StopRecordScreen(params object[] args)
        {
            // TODO: port body from 00237d94_LuaGlobalScriptNameSpace19LuaStopRecordScreenER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.StopRecordScreen] not yet ported (gốc 0x237d94)");
            return null;
        }

        // VMA: 0x237d9c  Source: functions/00237d9c_LuaGlobalScriptNameSpace12LuaDoLoadMapER10XLuaScript.asm
        // gốc body in 00237d9c_LuaGlobalScriptNameSpace12LuaDoLoadMapER10XLuaScript.asm (152 bytes ARM64)
        public object DoLoadMap(params object[] args)
        {
            // TODO: port body from 00237d9c_LuaGlobalScriptNameSpace12LuaDoLoadMapER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.DoLoadMap] not yet ported (gốc 0x237d9c)");
            return null;
        }

        // VMA: 0x237e34  Source: functions/00237e34_LuaGlobalScriptNameSpace18LuaResetLogicFrameER10XLuaScript.asm
        // gốc body in 00237e34_LuaGlobalScriptNameSpace18LuaResetLogicFrameER10XLuaScript.asm (36 bytes ARM64)
        public object ResetLogicFrame(params object[] args)
        {
            // TODO: port body from 00237e34_LuaGlobalScriptNameSpace18LuaResetLogicFrameER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ResetLogicFrame] not yet ported (gốc 0x237e34)");
            return null;
        }

        // VMA: 0x237e58  Source: functions/00237e58_LuaGlobalScriptNameSpace15LuaGetPingDelayER10XLuaScript.asm
        // gốc body in 00237e58_LuaGlobalScriptNameSpace15LuaGetPingDelayER10XLuaScript.asm (44 bytes ARM64)
        public object GetPingDelay(params object[] args)
        {
            // TODO: port body from 00237e58_LuaGlobalScriptNameSpace15LuaGetPingDelayER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetPingDelay] not yet ported (gốc 0x237e58)");
            return null;
        }

        // VMA: 0x237e84  Source: functions/00237e84_LuaGlobalScriptNameSpace20LuaGetDeviceIPAdressER10XLuaScript.asm
        // gốc body in 00237e84_LuaGlobalScriptNameSpace20LuaGetDeviceIPAdressER10XLuaScript.asm (124 bytes ARM64)
        public object GetDeviceIPAdress(params object[] args)
        {
            // TODO: port body from 00237e84_LuaGlobalScriptNameSpace20LuaGetDeviceIPAdressER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetDeviceIPAdress] not yet ported (gốc 0x237e84)");
            return null;
        }

        // VMA: 0x237f00  Source: functions/00237f00_LuaGlobalScriptNameSpace18LuaGetAppleEquipIdER10XLuaScript.asm
        // gốc body in 00237f00_LuaGlobalScriptNameSpace18LuaGetAppleEquipIdER10XLuaScript.asm (128 bytes ARM64)
        public object GetAppleEquipId(params object[] args)
        {
            // TODO: port body from 00237f00_LuaGlobalScriptNameSpace18LuaGetAppleEquipIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetAppleEquipId] not yet ported (gốc 0x237f00)");
            return null;
        }

        // VMA: 0x237f80  Source: functions/00237f80_LuaGlobalScriptNameSpace21LuaGetAppleMacAddressER10XLuaScript.asm
        // gốc body in 00237f80_LuaGlobalScriptNameSpace21LuaGetAppleMacAddressER10XLuaScript.asm (128 bytes ARM64)
        public object GetAppleMacAddress(params object[] args)
        {
            // TODO: port body from 00237f80_LuaGlobalScriptNameSpace21LuaGetAppleMacAddressER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetAppleMacAddress] not yet ported (gốc 0x237f80)");
            return null;
        }

        // VMA: 0x238000  Source: functions/00238000_LuaGlobalScriptNameSpace20LuaGetAppleModelNameER10XLuaScript.asm
        // gốc body in 00238000_LuaGlobalScriptNameSpace20LuaGetAppleModelNameER10XLuaScript.asm (124 bytes ARM64)
        public object GetAppleModelName(params object[] args)
        {
            // TODO: port body from 00238000_LuaGlobalScriptNameSpace20LuaGetAppleModelNameER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetAppleModelName] not yet ported (gốc 0x238000)");
            return null;
        }

        // VMA: 0x23807c  Source: functions/0023807c_LuaGlobalScriptNameSpace15LuaGetAppleIdfaER10XLuaScript.asm
        // gốc body in 0023807c_LuaGlobalScriptNameSpace15LuaGetAppleIdfaER10XLuaScript.asm (124 bytes ARM64)
        public object GetAppleIdfa(params object[] args)
        {
            // TODO: port body from 0023807c_LuaGlobalScriptNameSpace15LuaGetAppleIdfaER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetAppleIdfa] not yet ported (gốc 0x23807c)");
            return null;
        }

        // VMA: 0x2380f8  Source: functions/002380f8_LuaGlobalScriptNameSpace21LuaGetAppleAppVersionER10XLuaScript.asm
        // gốc body in 002380f8_LuaGlobalScriptNameSpace21LuaGetAppleAppVersionER10XLuaScript.asm (124 bytes ARM64)
        public object GetAppleAppVersion(params object[] args)
        {
            // TODO: port body from 002380f8_LuaGlobalScriptNameSpace21LuaGetAppleAppVersionER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetAppleAppVersion] not yet ported (gốc 0x2380f8)");
            return null;
        }

        // VMA: 0x238174  Source: functions/00238174_LuaGlobalScriptNameSpace23LuaGetAppleBatteryLevelER10XLuaScript.asm
        // gốc body in 00238174_LuaGlobalScriptNameSpace23LuaGetAppleBatteryLevelER10XLuaScript.asm (32 bytes ARM64)
        public object GetAppleBatteryLevel(params object[] args)
        {
            // TODO: port body from 00238174_LuaGlobalScriptNameSpace23LuaGetAppleBatteryLevelER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetAppleBatteryLevel] not yet ported (gốc 0x238174)");
            return null;
        }

        // VMA: 0x238194  Source: functions/00238194_LuaGlobalScriptNameSpace23LuaGetAppletNetWorkTypeER10XLuaScript.asm
        // gốc body in 00238194_LuaGlobalScriptNameSpace23LuaGetAppletNetWorkTypeER10XLuaScript.asm (28 bytes ARM64)
        public object GetAppletNetWorkType(params object[] args)
        {
            // TODO: port body from 00238194_LuaGlobalScriptNameSpace23LuaGetAppletNetWorkTypeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetAppletNetWorkType] not yet ported (gốc 0x238194)");
            return null;
        }

        // VMA: 0x2381b0  Source: functions/002381b0_LuaGlobalScriptNameSpace23LuaGetAppletTelecomOperER10XLuaScript.asm
        // gốc body in 002381b0_LuaGlobalScriptNameSpace23LuaGetAppletTelecomOperER10XLuaScript.asm (28 bytes ARM64)
        public object GetAppletTelecomOper(params object[] args)
        {
            // TODO: port body from 002381b0_LuaGlobalScriptNameSpace23LuaGetAppletTelecomOperER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetAppletTelecomOper] not yet ported (gốc 0x2381b0)");
            return null;
        }

        // VMA: 0x2381cc  Source: functions/002381cc_LuaGlobalScriptNameSpace12LuaResetStatER10XLuaScript.asm
        // gốc body in 002381cc_LuaGlobalScriptNameSpace12LuaResetStatER10XLuaScript.asm (8 bytes ARM64)
        public object ResetStat(params object[] args)
        {
            // TODO: port body from 002381cc_LuaGlobalScriptNameSpace12LuaResetStatER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ResetStat] not yet ported (gốc 0x2381cc)");
            return null;
        }

        // VMA: 0x2381d4  Source: functions/002381d4_LuaGlobalScriptNameSpace15LuaCheckBarrierER10XLuaScript.asm
        // gốc body in 002381d4_LuaGlobalScriptNameSpace15LuaCheckBarrierER10XLuaScript.asm (200 bytes ARM64)
        public object CheckBarrier(params object[] args)
        {
            // TODO: port body from 002381d4_LuaGlobalScriptNameSpace15LuaCheckBarrierER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.CheckBarrier] not yet ported (gốc 0x2381d4)");
            return null;
        }

        // VMA: 0x23829c  Source: functions/0023829c_LuaGlobalScriptNameSpace17LuaLogBeforeLoginER10XLuaScript.asm
        // gốc body in 0023829c_LuaGlobalScriptNameSpace17LuaLogBeforeLoginER10XLuaScript.asm (60 bytes ARM64)
        public object LogBeforeLogin(params object[] args)
        {
            // TODO: port body from 0023829c_LuaGlobalScriptNameSpace17LuaLogBeforeLoginER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.LogBeforeLogin] not yet ported (gốc 0x23829c)");
            return null;
        }

        // VMA: 0x2382d8  Source: functions/002382d8_LuaGlobalScriptNameSpace18LuaGetServerIpInfoER10XLuaScript.asm
        // gốc body in 002382d8_LuaGlobalScriptNameSpace18LuaGetServerIpInfoER10XLuaScript.asm (76 bytes ARM64)
        public object GetServerIpInfo(params object[] args)
        {
            // TODO: port body from 002382d8_LuaGlobalScriptNameSpace18LuaGetServerIpInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetServerIpInfo] not yet ported (gốc 0x2382d8)");
            return null;
        }

        // VMA: 0x238324  Source: functions/00238324_LuaGlobalScriptNameSpace15LuaIsJailbrokenER10XLuaScript.asm
        // gốc body in 00238324_LuaGlobalScriptNameSpace15LuaIsJailbrokenER10XLuaScript.asm (28 bytes ARM64)
        public object IsJailbroken(params object[] args)
        {
            // TODO: port body from 00238324_LuaGlobalScriptNameSpace15LuaIsJailbrokenER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.IsJailbroken] not yet ported (gốc 0x238324)");
            return null;
        }

        // VMA: 0x238340  Source: functions/00238340_LuaGlobalScriptNameSpace8LuaCrashER10XLuaScript.asm
        // gốc body in 00238340_LuaGlobalScriptNameSpace8LuaCrashER10XLuaScript.asm (200 bytes ARM64)
        public object Crash(params object[] args)
        {
            // TODO: port body from 00238340_LuaGlobalScriptNameSpace8LuaCrashER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.Crash] not yet ported (gốc 0x238340)");
            return null;
        }

        // VMA: 0x238408  Source: functions/00238408_LuaGlobalScriptNameSpace13LuaCreateRoleER10XLuaScript.asm
        // gốc body in 00238408_LuaGlobalScriptNameSpace13LuaCreateRoleER10XLuaScript.asm (112 bytes ARM64)
        public object CreateRole(params object[] args)
        {
            // TODO: port body from 00238408_LuaGlobalScriptNameSpace13LuaCreateRoleER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.CreateRole] not yet ported (gốc 0x238408)");
            return null;
        }

        // VMA: 0x238478  Source: functions/00238478_LuaGlobalScriptNameSpace12LuaSetMeInfoER10XLuaScript.asm
        // gốc body in 00238478_LuaGlobalScriptNameSpace12LuaSetMeInfoER10XLuaScript.asm (80 bytes ARM64)
        public object SetMeInfo(params object[] args)
        {
            // TODO: port body from 00238478_LuaGlobalScriptNameSpace12LuaSetMeInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SetMeInfo] not yet ported (gốc 0x238478)");
            return null;
        }

        // VMA: 0x2384c8  Source: functions/002384c8_LuaGlobalScriptNameSpace13LuaHideAllNpcER10XLuaScript.asm
        // gốc body in 002384c8_LuaGlobalScriptNameSpace13LuaHideAllNpcER10XLuaScript.asm (44 bytes ARM64)
        public object HideAllNpc(params object[] args)
        {
            // TODO: port body from 002384c8_LuaGlobalScriptNameSpace13LuaHideAllNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.HideAllNpc] not yet ported (gốc 0x2384c8)");
            return null;
        }

        // VMA: 0x2384f4  Source: functions/002384f4_LuaGlobalScriptNameSpace11LuaGetFrameER10XLuaScript.asm
        // gốc body in 002384f4_LuaGlobalScriptNameSpace11LuaGetFrameER10XLuaScript.asm (44 bytes ARM64)
        public object GetFrame(params object[] args)
        {
            // TODO: port body from 002384f4_LuaGlobalScriptNameSpace11LuaGetFrameER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetFrame] not yet ported (gốc 0x2384f4)");
            return null;
        }

        // VMA: 0x238520  Source: functions/00238520_LuaGlobalScriptNameSpace12LuaGetLuaTopER10XLuaScript.asm
        // gốc body in 00238520_LuaGlobalScriptNameSpace12LuaGetLuaTopER10XLuaScript.asm (88 bytes ARM64)
        public object GetLuaTop(params object[] args)
        {
            // TODO: port body from 00238520_LuaGlobalScriptNameSpace12LuaGetLuaTopER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetLuaTop] not yet ported (gốc 0x238520)");
            return null;
        }

        // VMA: 0x238578  Source: functions/00238578_LuaGlobalScriptNameSpace22LuaDeleteNearbyCampNpcER10XLuaScript.asm
        // gốc body in 00238578_LuaGlobalScriptNameSpace22LuaDeleteNearbyCampNpcER10XLuaScript.asm (648 bytes ARM64)
        public object DeleteNearbyCampNpc(params object[] args)
        {
            // TODO: port body from 00238578_LuaGlobalScriptNameSpace22LuaDeleteNearbyCampNpcER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.DeleteNearbyCampNpc] not yet ported (gốc 0x238578)");
            return null;
        }

        // VMA: 0x238930  Source: functions/00238930_LuaGlobalScriptNameSpace23LuaGetNpcDialogDistanceER10XLuaScript.asm
        // gốc body in 00238930_LuaGlobalScriptNameSpace23LuaGetNpcDialogDistanceER10XLuaScript.asm (140 bytes ARM64)
        public object GetNpcDialogDistance(params object[] args)
        {
            // TODO: port body from 00238930_LuaGlobalScriptNameSpace23LuaGetNpcDialogDistanceER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetNpcDialogDistance] not yet ported (gốc 0x238930)");
            return null;
        }

        // VMA: 0x2389bc  Source: functions/002389bc_LuaGlobalScriptNameSpace13LuaCrashInCppER10XLuaScript.asm
        // gốc body in 002389bc_LuaGlobalScriptNameSpace13LuaCrashInCppER10XLuaScript.asm (8 bytes ARM64)
        public object CrashInCpp(params object[] args)
        {
            // TODO: port body from 002389bc_LuaGlobalScriptNameSpace13LuaCrashInCppER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.CrashInCpp] not yet ported (gốc 0x2389bc)");
            return null;
        }

        // VMA: 0x2389c4  Source: functions/002389c4_LuaGlobalScriptNameSpace25LuaHeartBeatToWorldServerER10XLuaScript.asm
        // gốc body in 002389c4_LuaGlobalScriptNameSpace25LuaHeartBeatToWorldServerER10XLuaScript.asm (40 bytes ARM64)
        public object HeartBeatToWorldServer(params object[] args)
        {
            // TODO: port body from 002389c4_LuaGlobalScriptNameSpace25LuaHeartBeatToWorldServerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.HeartBeatToWorldServer] not yet ported (gốc 0x2389c4)");
            return null;
        }

        // VMA: 0x2389ec  Source: functions/002389ec_LuaGlobalScriptNameSpace17LuaGetMapBaseInfoER10XLuaScript.asm
        // gốc body in 002389ec_LuaGlobalScriptNameSpace17LuaGetMapBaseInfoER10XLuaScript.asm (644 bytes ARM64)
        public object GetMapBaseInfo(params object[] args)
        {
            // TODO: port body from 002389ec_LuaGlobalScriptNameSpace17LuaGetMapBaseInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetMapBaseInfo] not yet ported (gốc 0x2389ec)");
            return null;
        }

        // VMA: 0x238c70  Source: functions/00238c70_LuaGlobalScriptNameSpace19LuaCanAutoPathReachER10XLuaScript.asm
        // gốc body in 00238c70_LuaGlobalScriptNameSpace19LuaCanAutoPathReachER10XLuaScript.asm (636 bytes ARM64)
        public object CanAutoPathReach(params object[] args)
        {
            // TODO: port body from 00238c70_LuaGlobalScriptNameSpace19LuaCanAutoPathReachER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.CanAutoPathReach] not yet ported (gốc 0x238c70)");
            return null;
        }

        // VMA: 0x238eec  Source: functions/00238eec_LuaGlobalScriptNameSpace13LuaSetAOIOpenER10XLuaScript.asm
        // gốc body in 00238eec_LuaGlobalScriptNameSpace13LuaSetAOIOpenER10XLuaScript.asm (220 bytes ARM64)
        public object SetAOIOpen(params object[] args)
        {
            // TODO: port body from 00238eec_LuaGlobalScriptNameSpace13LuaSetAOIOpenER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SetAOIOpen] not yet ported (gốc 0x238eec)");
            return null;
        }

        // VMA: 0x238fc8  Source: functions/00238fc8_LuaGlobalScriptNameSpace17LuaLoadAllRegionsER10XLuaScript.asm
        // gốc body in 00238fc8_LuaGlobalScriptNameSpace17LuaLoadAllRegionsER10XLuaScript.asm (548 bytes ARM64)
        public object LoadAllRegions(params object[] args)
        {
            // TODO: port body from 00238fc8_LuaGlobalScriptNameSpace17LuaLoadAllRegionsER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.LoadAllRegions] not yet ported (gốc 0x238fc8)");
            return null;
        }

        // VMA: 0x2391ec  Source: functions/002391ec_LuaGlobalScriptNameSpace17LuaIsRegionExistsER10XLuaScript.asm
        // gốc body in 002391ec_LuaGlobalScriptNameSpace17LuaIsRegionExistsER10XLuaScript.asm (380 bytes ARM64)
        public object IsRegionExists(params object[] args)
        {
            // TODO: port body from 002391ec_LuaGlobalScriptNameSpace17LuaIsRegionExistsER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.IsRegionExists] not yet ported (gốc 0x2391ec)");
            return null;
        }

        // VMA: 0x239368  Source: functions/00239368_LuaGlobalScriptNameSpace21LuaGetZoneTimeSecDiffER10XLuaScript.asm
        // gốc body in 00239368_LuaGlobalScriptNameSpace21LuaGetZoneTimeSecDiffER10XLuaScript.asm (68 bytes ARM64)
        public object GetZoneTimeSecDiff(params object[] args)
        {
            // TODO: port body from 00239368_LuaGlobalScriptNameSpace21LuaGetZoneTimeSecDiffER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetZoneTimeSecDiff] not yet ported (gốc 0x239368)");
            return null;
        }

        // VMA: 0x2393ac  Source: functions/002393ac_LuaGlobalScriptNameSpace31LuaClearRandomKeyAndAccountInfoER10XLuaScript.asm
        // gốc body in 002393ac_LuaGlobalScriptNameSpace31LuaClearRandomKeyAndAccountInfoER10XLuaScript.asm (52 bytes ARM64)
        public object ClearRandomKeyAndAccountInfo(params object[] args)
        {
            // TODO: port body from 002393ac_LuaGlobalScriptNameSpace31LuaClearRandomKeyAndAccountInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ClearRandomKeyAndAccountInfo] not yet ported (gốc 0x2393ac)");
            return null;
        }

        // VMA: 0x2393e0  Source: functions/002393e0_LuaGlobalScriptNameSpace29LuaGetGlobalP2PTradeProcessorER10XLuaScript.asm
        // gốc body in 002393e0_LuaGlobalScriptNameSpace29LuaGetGlobalP2PTradeProcessorER10XLuaScript.asm (40 bytes ARM64)
        public object GetGlobalP2PTradeProcessor(params object[] args)
        {
            // TODO: port body from 002393e0_LuaGlobalScriptNameSpace29LuaGetGlobalP2PTradeProcessorER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetGlobalP2PTradeProcessor] not yet ported (gốc 0x2393e0)");
            return null;
        }

        // VMA: 0x239408  Source: functions/00239408_LuaGlobalScriptNameSpace12LuaIsPayOpenER10XLuaScript.asm
        // gốc body in 00239408_LuaGlobalScriptNameSpace12LuaIsPayOpenER10XLuaScript.asm (40 bytes ARM64)
        public object IsPayOpen(params object[] args)
        {
            // TODO: port body from 00239408_LuaGlobalScriptNameSpace12LuaIsPayOpenER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.IsPayOpen] not yet ported (gốc 0x239408)");
            return null;
        }

        // VMA: 0x239430  Source: functions/00239430_LuaGlobalScriptNameSpace20LuaGetMarketStallMgrER10XLuaScript.asm
        // gốc body in 00239430_LuaGlobalScriptNameSpace20LuaGetMarketStallMgrER10XLuaScript.asm (36 bytes ARM64)
        public object GetMarketStallMgr(params object[] args)
        {
            // TODO: port body from 00239430_LuaGlobalScriptNameSpace20LuaGetMarketStallMgrER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetMarketStallMgr] not yet ported (gốc 0x239430)");
            return null;
        }

        // VMA: 0x239454  Source: functions/00239454_LuaGlobalScriptNameSpace20LuaGetPlayerMaxLevelER10XLuaScript.asm
        // gốc body in 00239454_LuaGlobalScriptNameSpace20LuaGetPlayerMaxLevelER10XLuaScript.asm (48 bytes ARM64)
        public object GetPlayerMaxLevel(params object[] args)
        {
            // TODO: port body from 00239454_LuaGlobalScriptNameSpace20LuaGetPlayerMaxLevelER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetPlayerMaxLevel] not yet ported (gốc 0x239454)");
            return null;
        }

        // VMA: 0x239484  Source: functions/00239484_LuaGlobalScriptNameSpace22LuaSetQueueOrderNumberER10XLuaScript.asm
        // gốc body in 00239484_LuaGlobalScriptNameSpace22LuaSetQueueOrderNumberER10XLuaScript.asm (44 bytes ARM64)
        public object SetQueueOrderNumber(params object[] args)
        {
            // TODO: port body from 00239484_LuaGlobalScriptNameSpace22LuaSetQueueOrderNumberER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SetQueueOrderNumber] not yet ported (gốc 0x239484)");
            return null;
        }

        // VMA: 0x2394b0  Source: functions/002394b0_LuaGlobalScriptNameSpace22LuaGetQueueOrderNumberER10XLuaScript.asm
        // gốc body in 002394b0_LuaGlobalScriptNameSpace22LuaGetQueueOrderNumberER10XLuaScript.asm (48 bytes ARM64)
        public object GetQueueOrderNumber(params object[] args)
        {
            // TODO: port body from 002394b0_LuaGlobalScriptNameSpace22LuaGetQueueOrderNumberER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetQueueOrderNumber] not yet ported (gốc 0x2394b0)");
            return null;
        }

        // VMA: 0x2394e0  Source: functions/002394e0_LuaGlobalScriptNameSpace14LuaReadLuaFileER10XLuaScript.asm
        // gốc body in 002394e0_LuaGlobalScriptNameSpace14LuaReadLuaFileER10XLuaScript.asm (352 bytes ARM64)
        public object ReadLuaFile(params object[] args)
        {
            // TODO: port body from 002394e0_LuaGlobalScriptNameSpace14LuaReadLuaFileER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ReadLuaFile] not yet ported (gốc 0x2394e0)");
            return null;
        }

        // VMA: 0x239640  Source: functions/00239640_LuaGlobalScriptNameSpace15LuaWriteLuaFileER10XLuaScript.asm
        // gốc body in 00239640_LuaGlobalScriptNameSpace15LuaWriteLuaFileER10XLuaScript.asm (200 bytes ARM64)
        public object WriteLuaFile(params object[] args)
        {
            // TODO: port body from 00239640_LuaGlobalScriptNameSpace15LuaWriteLuaFileER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.WriteLuaFile] not yet ported (gốc 0x239640)");
            return null;
        }

        // VMA: 0x239708  Source: functions/00239708_LuaGlobalScriptNameSpace23LuaSyncTeamMemberTargetER10XLuaScript.asm
        // gốc body in 00239708_LuaGlobalScriptNameSpace23LuaSyncTeamMemberTargetER10XLuaScript.asm (60 bytes ARM64)
        public object SyncTeamMemberTarget(params object[] args)
        {
            // TODO: port body from 00239708_LuaGlobalScriptNameSpace23LuaSyncTeamMemberTargetER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SyncTeamMemberTarget] not yet ported (gốc 0x239708)");
            return null;
        }

        // VMA: 0x239744  Source: functions/00239744_LuaGlobalScriptNameSpace25LuaSyncTeamMemberFightPosER10XLuaScript.asm
        // gốc body in 00239744_LuaGlobalScriptNameSpace25LuaSyncTeamMemberFightPosER10XLuaScript.asm (112 bytes ARM64)
        public object SyncTeamMemberFightPos(params object[] args)
        {
            // TODO: port body from 00239744_LuaGlobalScriptNameSpace25LuaSyncTeamMemberFightPosER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SyncTeamMemberFightPos] not yet ported (gốc 0x239744)");
            return null;
        }

        // VMA: 0x2397b4  Source: functions/002397b4_LuaGlobalScriptNameSpace15LuaSetRideStateER10XLuaScript.asm
        // gốc body in 002397b4_LuaGlobalScriptNameSpace15LuaSetRideStateER10XLuaScript.asm (60 bytes ARM64)
        public object SetRideState(params object[] args)
        {
            // TODO: port body from 002397b4_LuaGlobalScriptNameSpace15LuaSetRideStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SetRideState] not yet ported (gốc 0x2397b4)");
            return null;
        }

        // VMA: 0x2397f0  Source: functions/002397f0_LuaGlobalScriptNameSpace23LuaSetResetTargetNpcPosER10XLuaScript.asm
        // gốc body in 002397f0_LuaGlobalScriptNameSpace23LuaSetResetTargetNpcPosER10XLuaScript.asm (52 bytes ARM64)
        public object SetResetTargetNpcPos(params object[] args)
        {
            // TODO: port body from 002397f0_LuaGlobalScriptNameSpace23LuaSetResetTargetNpcPosER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SetResetTargetNpcPos] not yet ported (gốc 0x2397f0)");
            return null;
        }

        // VMA: 0x239824  Source: functions/00239824_LuaGlobalScriptNameSpace31LuaGetPlayerZongShiLevelSettingER10XLuaScript.asm
        // gốc body in 00239824_LuaGlobalScriptNameSpace31LuaGetPlayerZongShiLevelSettingER10XLuaScript.asm (784 bytes ARM64)
        public object GetPlayerZongShiLevelSetting(params object[] args)
        {
            // TODO: port body from 00239824_LuaGlobalScriptNameSpace31LuaGetPlayerZongShiLevelSettingER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetPlayerZongShiLevelSetting] not yet ported (gốc 0x239824)");
            return null;
        }

        // VMA: 0x31689c  Source: functions/0031689c_LuaGlobalScriptNameSpace16LuaLoadTabFileExER10XLuaScript.asm
        // gốc body in 0031689c_LuaGlobalScriptNameSpace16LuaLoadTabFileExER10XLuaScript.asm (1808 bytes ARM64)
        public object LoadTabFileEx(params object[] args)
        {
            // TODO: port body from 0031689c_LuaGlobalScriptNameSpace16LuaLoadTabFileExER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.LoadTabFileEx] not yet ported (gốc 0x31689c)");
            return null;
        }

        // VMA: 0x316fac  Source: functions/00316fac_LuaGlobalScriptNameSpace14LuaReadTxtFileER10XLuaScript.asm
        // gốc body in 00316fac_LuaGlobalScriptNameSpace14LuaReadTxtFileER10XLuaScript.asm (328 bytes ARM64)
        public object ReadTxtFile(params object[] args)
        {
            // TODO: port body from 00316fac_LuaGlobalScriptNameSpace14LuaReadTxtFileER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ReadTxtFile] not yet ported (gốc 0x316fac)");
            return null;
        }

        // VMA: 0x3170f4  Source: functions/003170f4_LuaGlobalScriptNameSpace13LuaMathRandomER10XLuaScript.asm
        // gốc body in 003170f4_LuaGlobalScriptNameSpace13LuaMathRandomER10XLuaScript.asm (232 bytes ARM64)
        public object MathRandom(params object[] args)
        {
            // TODO: port body from 003170f4_LuaGlobalScriptNameSpace13LuaMathRandomER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.MathRandom] not yet ported (gốc 0x3170f4)");
            return null;
        }

        // VMA: 0x3171dc  Source: functions/003171dc_LuaGlobalScriptNameSpace18LuaMathGetRandSeedER10XLuaScript.asm
        // gốc body in 003171dc_LuaGlobalScriptNameSpace18LuaMathGetRandSeedER10XLuaScript.asm (612 bytes ARM64)
        public object MathGetRandSeed(params object[] args)
        {
            // TODO: port body from 003171dc_LuaGlobalScriptNameSpace18LuaMathGetRandSeedER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.MathGetRandSeed] not yet ported (gốc 0x3171dc)");
            return null;
        }

        // VMA: 0x317440  Source: functions/00317440_LuaGlobalScriptNameSpace18LuaMathSetRandSeedER10XLuaScript.asm
        // gốc body in 00317440_LuaGlobalScriptNameSpace18LuaMathSetRandSeedER10XLuaScript.asm (440 bytes ARM64)
        public object MathSetRandSeed(params object[] args)
        {
            // TODO: port body from 00317440_LuaGlobalScriptNameSpace18LuaMathSetRandSeedER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.MathSetRandSeed] not yet ported (gốc 0x317440)");
            return null;
        }

        // VMA: 0x3175f8  Source: functions/003175f8_LuaGlobalScriptNameSpace20LuaGetTimeFrameStateER10XLuaScript.asm
        // gốc body in 003175f8_LuaGlobalScriptNameSpace20LuaGetTimeFrameStateER10XLuaScript.asm (76 bytes ARM64)
        public object GetTimeFrameState(params object[] args)
        {
            // TODO: port body from 003175f8_LuaGlobalScriptNameSpace20LuaGetTimeFrameStateER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetTimeFrameState] not yet ported (gốc 0x3175f8)");
            return null;
        }

        // VMA: 0x317644  Source: functions/00317644_LuaGlobalScriptNameSpace24LuaCalcTimeFrameOpenTimeER10XLuaScript.asm
        // gốc body in 00317644_LuaGlobalScriptNameSpace24LuaCalcTimeFrameOpenTimeER10XLuaScript.asm (76 bytes ARM64)
        public object CalcTimeFrameOpenTime(params object[] args)
        {
            // TODO: port body from 00317644_LuaGlobalScriptNameSpace24LuaCalcTimeFrameOpenTimeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.CalcTimeFrameOpenTime] not yet ported (gốc 0x317644)");
            return null;
        }

        // VMA: 0x317690  Source: functions/00317690_LuaGlobalScriptNameSpace14LuaIsSameMapIdER10XLuaScript.asm
        // gốc body in 00317690_LuaGlobalScriptNameSpace14LuaIsSameMapIdER10XLuaScript.asm (140 bytes ARM64)
        public object IsSameMapId(params object[] args)
        {
            // TODO: port body from 00317690_LuaGlobalScriptNameSpace14LuaIsSameMapIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.IsSameMapId] not yet ported (gốc 0x317690)");
            return null;
        }

        // VMA: 0x31771c  Source: functions/0031771c_LuaGlobalScriptNameSpace15LuaGetTableSizeER10XLuaScript.asm
        // gốc body in 0031771c_LuaGlobalScriptNameSpace15LuaGetTableSizeER10XLuaScript.asm (444 bytes ARM64)
        public object GetTableSize(params object[] args)
        {
            // TODO: port body from 0031771c_LuaGlobalScriptNameSpace15LuaGetTableSizeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetTableSize] not yet ported (gốc 0x31771c)");
            return null;
        }

        // VMA: 0x3178d8  Source: functions/003178d8_LuaGlobalScriptNameSpace11LuaTestFuncER10XLuaScript.asm
        // gốc body in 003178d8_LuaGlobalScriptNameSpace11LuaTestFuncER10XLuaScript.asm (108 bytes ARM64)
        public object TestFunc(params object[] args)
        {
            // TODO: port body from 003178d8_LuaGlobalScriptNameSpace11LuaTestFuncER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.TestFunc] not yet ported (gốc 0x3178d8)");
            return null;
        }

        // VMA: 0x317944  Source: functions/00317944_LuaGlobalScriptNameSpace21LuaCheckNameAvailableER10XLuaScript.asm
        // gốc body in 00317944_LuaGlobalScriptNameSpace21LuaCheckNameAvailableER10XLuaScript.asm (76 bytes ARM64)
        public object CheckNameAvailable(params object[] args)
        {
            // TODO: port body from 00317944_LuaGlobalScriptNameSpace21LuaCheckNameAvailableER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.CheckNameAvailable] not yet ported (gốc 0x317944)");
            return null;
        }

        // VMA: 0x317990  Source: functions/00317990_LuaGlobalScriptNameSpace20LuaGetPartnerBaseExpER10XLuaScript.asm
        // gốc body in 00317990_LuaGlobalScriptNameSpace20LuaGetPartnerBaseExpER10XLuaScript.asm (104 bytes ARM64)
        public object GetPartnerBaseExp(params object[] args)
        {
            // TODO: port body from 00317990_LuaGlobalScriptNameSpace20LuaGetPartnerBaseExpER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetPartnerBaseExp] not yet ported (gốc 0x317990)");
            return null;
        }

        // VMA: 0x3179f8  Source: functions/003179f8_LuaGlobalScriptNameSpace9LuaAddObjER10XLuaScript.asm
        // gốc body in 003179f8_LuaGlobalScriptNameSpace9LuaAddObjER10XLuaScript.asm (264 bytes ARM64)
        public object AddObj(params object[] args)
        {
            // TODO: port body from 003179f8_LuaGlobalScriptNameSpace9LuaAddObjER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.AddObj] not yet ported (gốc 0x3179f8)");
            return null;
        }

        // VMA: 0x317b00  Source: functions/00317b00_LuaGlobalScriptNameSpace9LuaDelObjER10XLuaScript.asm
        // gốc body in 00317b00_LuaGlobalScriptNameSpace9LuaDelObjER10XLuaScript.asm (68 bytes ARM64)
        public object DelObj(params object[] args)
        {
            // TODO: port body from 00317b00_LuaGlobalScriptNameSpace9LuaDelObjER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.DelObj] not yet ported (gốc 0x317b00)");
            return null;
        }

        // VMA: 0x317b44  Source: functions/00317b44_LuaGlobalScriptNameSpace20LuaGetFileChangeTimeER10XLuaScript.asm
        // gốc body in 00317b44_LuaGlobalScriptNameSpace20LuaGetFileChangeTimeER10XLuaScript.asm (56 bytes ARM64)
        public object GetFileChangeTime(params object[] args)
        {
            // TODO: port body from 00317b44_LuaGlobalScriptNameSpace20LuaGetFileChangeTimeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetFileChangeTime] not yet ported (gốc 0x317b44)");
            return null;
        }

        // VMA: 0x317b7c  Source: functions/00317b7c_LuaGlobalScriptNameSpace19LuaGetSkillBaseInfoER10XLuaScript.asm
        // gốc body in 00317b7c_LuaGlobalScriptNameSpace19LuaGetSkillBaseInfoER10XLuaScript.asm (108 bytes ARM64)
        public object GetSkillBaseInfo(params object[] args)
        {
            // TODO: port body from 00317b7c_LuaGlobalScriptNameSpace19LuaGetSkillBaseInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetSkillBaseInfo] not yet ported (gốc 0x317b7c)");
            return null;
        }

        // VMA: 0x317be8  Source: functions/00317be8_LuaGlobalScriptNameSpace14LuaDoSystemCmdER10XLuaScript.asm
        // gốc body in 00317be8_LuaGlobalScriptNameSpace14LuaDoSystemCmdER10XLuaScript.asm (8 bytes ARM64)
        public object DoSystemCmd(params object[] args)
        {
            // TODO: port body from 00317be8_LuaGlobalScriptNameSpace14LuaDoSystemCmdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.DoSystemCmd] not yet ported (gốc 0x317be8)");
            return null;
        }

        // VMA: 0x317bf0  Source: functions/00317bf0_LuaGlobalScriptNameSpace14LuaDebugAssertER10XLuaScript.asm
        // gốc body in 00317bf0_LuaGlobalScriptNameSpace14LuaDebugAssertER10XLuaScript.asm (132 bytes ARM64)
        public object DebugAssert(params object[] args)
        {
            // TODO: port body from 00317bf0_LuaGlobalScriptNameSpace14LuaDebugAssertER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.DebugAssert] not yet ported (gốc 0x317bf0)");
            return null;
        }

        // VMA: 0x317c74  Source: functions/00317c74_LuaGlobalScriptNameSpace19LuaGetMapTemplateIdER10XLuaScript.asm
        // gốc body in 00317c74_LuaGlobalScriptNameSpace19LuaGetMapTemplateIdER10XLuaScript.asm (128 bytes ARM64)
        public object GetMapTemplateId(params object[] args)
        {
            // TODO: port body from 00317c74_LuaGlobalScriptNameSpace19LuaGetMapTemplateIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetMapTemplateId] not yet ported (gốc 0x317c74)");
            return null;
        }

        // VMA: 0x317cf4  Source: functions/00317cf4_LuaGlobalScriptNameSpace20LuaGetPlayerInitInfoER10XLuaScript.asm
        // gốc body in 00317cf4_LuaGlobalScriptNameSpace20LuaGetPlayerInitInfoER10XLuaScript.asm (504 bytes ARM64)
        public object GetPlayerInitInfo(params object[] args)
        {
            // TODO: port body from 00317cf4_LuaGlobalScriptNameSpace20LuaGetPlayerInitInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetPlayerInitInfo] not yet ported (gốc 0x317cf4)");
            return null;
        }

        // VMA: 0x317eec  Source: functions/00317eec_LuaGlobalScriptNameSpace15LuaGetItemOwnerER10XLuaScript.asm
        // gốc body in 00317eec_LuaGlobalScriptNameSpace15LuaGetItemOwnerER10XLuaScript.asm (84 bytes ARM64)
        public object GetItemOwner(params object[] args)
        {
            // TODO: port body from 00317eec_LuaGlobalScriptNameSpace15LuaGetItemOwnerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetItemOwner] not yet ported (gốc 0x317eec)");
            return null;
        }

        // VMA: 0x317f40  Source: functions/00317f40_LuaGlobalScriptNameSpace16LuaGetItemByNameER10XLuaScript.asm
        // gốc body in 00317f40_LuaGlobalScriptNameSpace16LuaGetItemByNameER10XLuaScript.asm (640 bytes ARM64)
        public object GetItemByName(params object[] args)
        {
            // TODO: port body from 00317f40_LuaGlobalScriptNameSpace16LuaGetItemByNameER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetItemByName] not yet ported (gốc 0x317f40)");
            return null;
        }

        // VMA: 0x318268  Source: functions/00318268_LuaGlobalScriptNameSpace15LuaGetMapHeightER10XLuaScript.asm
        // gốc body in 00318268_LuaGlobalScriptNameSpace15LuaGetMapHeightER10XLuaScript.asm (256 bytes ARM64)
        public object GetMapHeight(params object[] args)
        {
            // TODO: port body from 00318268_LuaGlobalScriptNameSpace15LuaGetMapHeightER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetMapHeight] not yet ported (gốc 0x318268)");
            return null;
        }

        // VMA: 0x318368  Source: functions/00318368_LuaGlobalScriptNameSpace14LuaGetActFrameER10XLuaScript.asm
        // gốc body in 00318368_LuaGlobalScriptNameSpace14LuaGetActFrameER10XLuaScript.asm (132 bytes ARM64)
        public object GetActFrame(params object[] args)
        {
            // TODO: port body from 00318368_LuaGlobalScriptNameSpace14LuaGetActFrameER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetActFrame] not yet ported (gốc 0x318368)");
            return null;
        }

        // VMA: 0x3183ec  Source: functions/003183ec_LuaGlobalScriptNameSpace13LuaGetItemResER10XLuaScript.asm
        // gốc body in 003183ec_LuaGlobalScriptNameSpace13LuaGetItemResER10XLuaScript.asm (200 bytes ARM64)
        public object GetItemRes(params object[] args)
        {
            // TODO: port body from 003183ec_LuaGlobalScriptNameSpace13LuaGetItemResER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetItemRes] not yet ported (gốc 0x3183ec)");
            return null;
        }

        // VMA: 0x3184b4  Source: functions/003184b4_LuaGlobalScriptNameSpace25LuaGetEquipIconByShowTypeER10XLuaScript.asm
        // gốc body in 003184b4_LuaGlobalScriptNameSpace25LuaGetEquipIconByShowTypeER10XLuaScript.asm (156 bytes ARM64)
        public object GetEquipIconByShowType(params object[] args)
        {
            // TODO: port body from 003184b4_LuaGlobalScriptNameSpace25LuaGetEquipIconByShowTypeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetEquipIconByShowType] not yet ported (gốc 0x3184b4)");
            return null;
        }

        // VMA: 0x318550  Source: functions/00318550_LuaGlobalScriptNameSpace24LuaGetItemAttributePowerER10XLuaScript.asm
        // gốc body in 00318550_LuaGlobalScriptNameSpace24LuaGetItemAttributePowerER10XLuaScript.asm (96 bytes ARM64)
        public object GetItemAttributePower(params object[] args)
        {
            // TODO: port body from 00318550_LuaGlobalScriptNameSpace24LuaGetItemAttributePowerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetItemAttributePower] not yet ported (gốc 0x318550)");
            return null;
        }

        // VMA: 0x3185b0  Source: functions/003185b0_LuaGlobalScriptNameSpace17LuaGetItemTimeOutER10XLuaScript.asm
        // gốc body in 003185b0_LuaGlobalScriptNameSpace17LuaGetItemTimeOutER10XLuaScript.asm (88 bytes ARM64)
        public object GetItemTimeOut(params object[] args)
        {
            // TODO: port body from 003185b0_LuaGlobalScriptNameSpace17LuaGetItemTimeOutER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetItemTimeOut] not yet ported (gốc 0x3185b0)");
            return null;
        }

        // VMA: 0x318608  Source: functions/00318608_LuaGlobalScriptNameSpace17LuaGetItemGenTimeER10XLuaScript.asm
        // gốc body in 00318608_LuaGlobalScriptNameSpace17LuaGetItemGenTimeER10XLuaScript.asm (268 bytes ARM64)
        public object GetItemGenTime(params object[] args)
        {
            // TODO: port body from 00318608_LuaGlobalScriptNameSpace17LuaGetItemGenTimeER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetItemGenTime] not yet ported (gốc 0x318608)");
            return null;
        }

        // VMA: 0x318714  Source: functions/00318714_LuaGlobalScriptNameSpace20LuaSetTimeOutInvalidER10XLuaScript.asm
        // gốc body in 00318714_LuaGlobalScriptNameSpace20LuaSetTimeOutInvalidER10XLuaScript.asm (92 bytes ARM64)
        public object SetTimeOutInvalid(params object[] args)
        {
            // TODO: port body from 00318714_LuaGlobalScriptNameSpace20LuaSetTimeOutInvalidER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SetTimeOutInvalid] not yet ported (gốc 0x318714)");
            return null;
        }

        // VMA: 0x318770  Source: functions/00318770_LuaGlobalScriptNameSpace24LuaGetItemDynamicTimeOutER10XLuaScript.asm
        // gốc body in 00318770_LuaGlobalScriptNameSpace24LuaGetItemDynamicTimeOutER10XLuaScript.asm (84 bytes ARM64)
        public object GetItemDynamicTimeOut(params object[] args)
        {
            // TODO: port body from 00318770_LuaGlobalScriptNameSpace24LuaGetItemDynamicTimeOutER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetItemDynamicTimeOut] not yet ported (gốc 0x318770)");
            return null;
        }

        // VMA: 0x3187c4  Source: functions/003187c4_LuaGlobalScriptNameSpace16LuaStringToLowerER10XLuaScript.asm
        // gốc body in 003187c4_LuaGlobalScriptNameSpace16LuaStringToLowerER10XLuaScript.asm (196 bytes ARM64)
        public object StringToLower(params object[] args)
        {
            // TODO: port body from 003187c4_LuaGlobalScriptNameSpace16LuaStringToLowerER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.StringToLower] not yet ported (gốc 0x3187c4)");
            return null;
        }

        // VMA: 0x318888  Source: functions/00318888_LuaGlobalScriptNameSpace14LuaGetGroupKeyER10XLuaScript.asm
        // gốc body in 00318888_LuaGlobalScriptNameSpace14LuaGetGroupKeyER10XLuaScript.asm (336 bytes ARM64)
        public object GetGroupKey(params object[] args)
        {
            // TODO: port body from 00318888_LuaGlobalScriptNameSpace14LuaGetGroupKeyER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetGroupKey] not yet ported (gốc 0x318888)");
            return null;
        }

        // VMA: 0x3189d8  Source: functions/003189d8_LuaGlobalScriptNameSpace21LuaChangeGroupKeyInfoER10XLuaScript.asm
        // gốc body in 003189d8_LuaGlobalScriptNameSpace21LuaChangeGroupKeyInfoER10XLuaScript.asm (188 bytes ARM64)
        public object ChangeGroupKeyInfo(params object[] args)
        {
            // TODO: port body from 003189d8_LuaGlobalScriptNameSpace21LuaChangeGroupKeyInfoER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ChangeGroupKeyInfo] not yet ported (gốc 0x3189d8)");
            return null;
        }

        // VMA: 0x318a94  Source: functions/00318a94_LuaGlobalScriptNameSpace20LuaReplaceLimitWordsER10XLuaScript.asm
        // gốc body in 00318a94_LuaGlobalScriptNameSpace20LuaReplaceLimitWordsER10XLuaScript.asm (368 bytes ARM64)
        public object ReplaceLimitWords(params object[] args)
        {
            // TODO: port body from 00318a94_LuaGlobalScriptNameSpace20LuaReplaceLimitWordsER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ReplaceLimitWords] not yet ported (gốc 0x318a94)");
            return null;
        }

        // VMA: 0x318c04  Source: functions/00318c04_LuaGlobalScriptNameSpace23LuaGetTongMapTemplateIdER10XLuaScript.asm
        // gốc body in 00318c04_LuaGlobalScriptNameSpace23LuaGetTongMapTemplateIdER10XLuaScript.asm (48 bytes ARM64)
        public object GetTongMapTemplateId(params object[] args)
        {
            // TODO: port body from 00318c04_LuaGlobalScriptNameSpace23LuaGetTongMapTemplateIdER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.GetTongMapTemplateId] not yet ported (gốc 0x318c04)");
            return null;
        }

        // VMA: 0x318c34  Source: functions/00318c34_LuaGlobalScriptNameSpace13LuaAddDynObstER10XLuaScript.asm
        // gốc body in 00318c34_LuaGlobalScriptNameSpace13LuaAddDynObstER10XLuaScript.asm (188 bytes ARM64)
        public object AddDynObst(params object[] args)
        {
            // TODO: port body from 00318c34_LuaGlobalScriptNameSpace13LuaAddDynObstER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.AddDynObst] not yet ported (gốc 0x318c34)");
            return null;
        }

        // VMA: 0x318cf0  Source: functions/00318cf0_LuaGlobalScriptNameSpace13LuaDelDynObstER10XLuaScript.asm
        // gốc body in 00318cf0_LuaGlobalScriptNameSpace13LuaDelDynObstER10XLuaScript.asm (68 bytes ARM64)
        public object DelDynObst(params object[] args)
        {
            // TODO: port body from 00318cf0_LuaGlobalScriptNameSpace13LuaDelDynObstER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.DelDynObst] not yet ported (gốc 0x318cf0)");
            return null;
        }

        // VMA: 0x318d34  Source: functions/00318d34_LuaGlobalScriptNameSpace16LuaEnableDynObstER10XLuaScript.asm
        // gốc body in 00318d34_LuaGlobalScriptNameSpace16LuaEnableDynObstER10XLuaScript.asm (112 bytes ARM64)
        public object EnableDynObst(params object[] args)
        {
            // TODO: port body from 00318d34_LuaGlobalScriptNameSpace16LuaEnableDynObstER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.EnableDynObst] not yet ported (gốc 0x318d34)");
            return null;
        }

        // VMA: 0x318da4  Source: functions/00318da4_LuaGlobalScriptNameSpace18LuaIsEnableDynObstER10XLuaScript.asm
        // gốc body in 00318da4_LuaGlobalScriptNameSpace18LuaIsEnableDynObstER10XLuaScript.asm (100 bytes ARM64)
        public object IsEnableDynObst(params object[] args)
        {
            // TODO: port body from 00318da4_LuaGlobalScriptNameSpace18LuaIsEnableDynObstER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.IsEnableDynObst] not yet ported (gốc 0x318da4)");
            return null;
        }

        // VMA: 0x318e08  Source: functions/00318e08_LuaGlobalScriptNameSpace13LuaPushStringER10XLuaScript.asm
        // gốc body in 00318e08_LuaGlobalScriptNameSpace13LuaPushStringER10XLuaScript.asm (176 bytes ARM64)
        public object PushString(params object[] args)
        {
            // TODO: port body from 00318e08_LuaGlobalScriptNameSpace13LuaPushStringER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.PushString] not yet ported (gốc 0x318e08)");
            return null;
        }

        // VMA: 0x318eb8  Source: functions/00318eb8_LuaGlobalScriptNameSpace12LuaPopStringER10XLuaScript.asm
        // gốc body in 00318eb8_LuaGlobalScriptNameSpace12LuaPopStringER10XLuaScript.asm (52 bytes ARM64)
        public object PopString(params object[] args)
        {
            // TODO: port body from 00318eb8_LuaGlobalScriptNameSpace12LuaPopStringER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.PopString] not yet ported (gốc 0x318eb8)");
            return null;
        }

        // VMA: 0x318eec  Source: functions/00318eec_LuaGlobalScriptNameSpace16LuaReplaceStringER10XLuaScript.asm
        // gốc body in 00318eec_LuaGlobalScriptNameSpace16LuaReplaceStringER10XLuaScript.asm (100 bytes ARM64)
        public object ReplaceString(params object[] args)
        {
            // TODO: port body from 00318eec_LuaGlobalScriptNameSpace16LuaReplaceStringER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.ReplaceString] not yet ported (gốc 0x318eec)");
            return null;
        }

        // VMA: 0x31918c  Source: functions/0031918c_LuaGlobalScriptNameSpace15LuaAppendStringER10XLuaScript.asm
        // gốc body in 0031918c_LuaGlobalScriptNameSpace15LuaAppendStringER10XLuaScript.asm (172 bytes ARM64)
        public object AppendString(params object[] args)
        {
            // TODO: port body from 0031918c_LuaGlobalScriptNameSpace15LuaAppendStringER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.AppendString] not yet ported (gốc 0x31918c)");
            return null;
        }

        // VMA: 0x319238  Source: functions/00319238_LuaGlobalScriptNameSpace20LuaSetMaxAttackSpeedER10XLuaScript.asm
        // gốc body in 00319238_LuaGlobalScriptNameSpace20LuaSetMaxAttackSpeedER10XLuaScript.asm (48 bytes ARM64)
        public object SetMaxAttackSpeed(params object[] args)
        {
            // TODO: port body from 00319238_LuaGlobalScriptNameSpace20LuaSetMaxAttackSpeedER10XLuaScript.asm (lazy — fill when called)
            UnityEngine.Debug.LogWarning($"[KGlobalLua.SetMaxAttackSpeed] not yet ported (gốc 0x319238)");
            return null;
        }

        // ============ Other methods ============
    }

    /// <summary>Data backing for KGlobalLua — mirrors C++ underlying object fields.</summary>
    public class KGlobalLuaData
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