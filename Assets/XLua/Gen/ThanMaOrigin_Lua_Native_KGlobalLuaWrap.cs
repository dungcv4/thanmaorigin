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
    public class ThanMaOriginLuaNativeKGlobalLuaWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(ThanMaOrigin.Lua.Native.KGlobalLua);
			Utils.BeginObjectRegister(type, L, translator, 0, 132, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReloadMapSetting", _m_ReloadMapSetting);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReloadTimeFrame", _m_ReloadTimeFrame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RegisterTimerPoint", _m_RegisterTimerPoint);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GMCommand", _m_GMCommand);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetRoleList", _m_GetRoleList);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoginRole", _m_LoginRole);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ConnectGateway", _m_ConnectGateway);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ConnectWorldServer", _m_ConnectWorldServer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetWorldServerConnectTimeout", _m_SetWorldServerConnectTimeout);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ConnectServer", _m_ConnectServer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReconnectServer", _m_ReconnectServer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsAlone", _m_IsAlone);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetStandAlone", _m_SetStandAlone);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetGameWorldScale", _m_SetGameWorldScale);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetVSyncFPS", _m_SetVSyncFPS);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseServerConnect", _m_CloseServerConnect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseGateWayConnect", _m_CloseGateWayConnect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTime", _m_GetTime);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ForbidReconnect", _m_ForbidReconnect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Logout", _m_Logout);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendChannelMessage", _m_SendChannelMessage);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsServerConnected", _m_IsServerConnected);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SendPrivateMessage", _m_SendPrivateMessage);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BindCameraToNpc", _m_BindCameraToNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RequestServerList", _m_RequestServerList);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RequestRankServerCommon", _m_RequestRankServerCommon);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RequestAccSerInfo", _m_RequestAccSerInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RequestAccountActive", _m_RequestAccountActive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAccountName", _m_GetAccountName);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCertification", _m_GetCertification);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetServerList", _m_GetServerList);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetServerRegion", _m_GetServerRegion);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetServerName", _m_GetServerName);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ParseLinkData", _m_ParseLinkData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetServerCreateTime", _m_GetServerCreateTime);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TraverseDir", _m_TraverseDir);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GiveUpWaitQueue", _m_GiveUpWaitQueue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloseMap", _m_CloseMap);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StartRecordScreen", _m_StartRecordScreen);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StopRecordScreen", _m_StopRecordScreen);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DoLoadMap", _m_DoLoadMap);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ResetLogicFrame", _m_ResetLogicFrame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPingDelay", _m_GetPingDelay);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetDeviceIPAdress", _m_GetDeviceIPAdress);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAppleEquipId", _m_GetAppleEquipId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAppleMacAddress", _m_GetAppleMacAddress);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAppleModelName", _m_GetAppleModelName);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAppleIdfa", _m_GetAppleIdfa);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAppleAppVersion", _m_GetAppleAppVersion);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAppleBatteryLevel", _m_GetAppleBatteryLevel);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAppletNetWorkType", _m_GetAppletNetWorkType);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAppletTelecomOper", _m_GetAppletTelecomOper);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ResetStat", _m_ResetStat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CheckBarrier", _m_CheckBarrier);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LogBeforeLogin", _m_LogBeforeLogin);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetServerIpInfo", _m_GetServerIpInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsJailbroken", _m_IsJailbroken);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Crash", _m_Crash);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreateRole", _m_CreateRole);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetMeInfo", _m_SetMeInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HideAllNpc", _m_HideAllNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFrame", _m_GetFrame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetLuaTop", _m_GetLuaTop);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeleteNearbyCampNpc", _m_DeleteNearbyCampNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNpcDialogDistance", _m_GetNpcDialogDistance);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CrashInCpp", _m_CrashInCpp);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HeartBeatToWorldServer", _m_HeartBeatToWorldServer);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMapBaseInfo", _m_GetMapBaseInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CanAutoPathReach", _m_CanAutoPathReach);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAOIOpen", _m_SetAOIOpen);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadAllRegions", _m_LoadAllRegions);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsRegionExists", _m_IsRegionExists);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetZoneTimeSecDiff", _m_GetZoneTimeSecDiff);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearRandomKeyAndAccountInfo", _m_ClearRandomKeyAndAccountInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGlobalP2PTradeProcessor", _m_GetGlobalP2PTradeProcessor);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsPayOpen", _m_IsPayOpen);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMarketStallMgr", _m_GetMarketStallMgr);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPlayerMaxLevel", _m_GetPlayerMaxLevel);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetQueueOrderNumber", _m_SetQueueOrderNumber);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetQueueOrderNumber", _m_GetQueueOrderNumber);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadLuaFile", _m_ReadLuaFile);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteLuaFile", _m_WriteLuaFile);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SyncTeamMemberTarget", _m_SyncTeamMemberTarget);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SyncTeamMemberFightPos", _m_SyncTeamMemberFightPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetRideState", _m_SetRideState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetResetTargetNpcPos", _m_SetResetTargetNpcPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPlayerZongShiLevelSetting", _m_GetPlayerZongShiLevelSetting);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadTabFileEx", _m_LoadTabFileEx);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadTxtFile", _m_ReadTxtFile);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MathRandom", _m_MathRandom);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MathGetRandSeed", _m_MathGetRandSeed);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MathSetRandSeed", _m_MathSetRandSeed);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTimeFrameState", _m_GetTimeFrameState);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalcTimeFrameOpenTime", _m_CalcTimeFrameOpenTime);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsSameMapId", _m_IsSameMapId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTableSize", _m_GetTableSize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "TestFunc", _m_TestFunc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CheckNameAvailable", _m_CheckNameAvailable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPartnerBaseExp", _m_GetPartnerBaseExp);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddObj", _m_AddObj);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DelObj", _m_DelObj);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetFileChangeTime", _m_GetFileChangeTime);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSkillBaseInfo", _m_GetSkillBaseInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DoSystemCmd", _m_DoSystemCmd);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DebugAssert", _m_DebugAssert);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMapTemplateId", _m_GetMapTemplateId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPlayerInitInfo", _m_GetPlayerInitInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemOwner", _m_GetItemOwner);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemByName", _m_GetItemByName);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMapHeight", _m_GetMapHeight);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetActFrame", _m_GetActFrame);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemRes", _m_GetItemRes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetEquipIconByShowType", _m_GetEquipIconByShowType);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemAttributePower", _m_GetItemAttributePower);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemTimeOut", _m_GetItemTimeOut);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemGenTime", _m_GetItemGenTime);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTimeOutInvalid", _m_SetTimeOutInvalid);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemDynamicTimeOut", _m_GetItemDynamicTimeOut);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StringToLower", _m_StringToLower);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGroupKey", _m_GetGroupKey);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ChangeGroupKeyInfo", _m_ChangeGroupKeyInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReplaceLimitWords", _m_ReplaceLimitWords);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTongMapTemplateId", _m_GetTongMapTemplateId);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddDynObst", _m_AddDynObst);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DelDynObst", _m_DelDynObst);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "EnableDynObst", _m_EnableDynObst);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsEnableDynObst", _m_IsEnableDynObst);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PushString", _m_PushString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PopString", _m_PopString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReplaceString", _m_ReplaceString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AppendString", _m_AppendString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetMaxAttackSpeed", _m_SetMaxAttackSpeed);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Data", _g_get_Data);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Data", _s_set_Data);
            
			
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
					
					var gen_ret = new ThanMaOrigin.Lua.Native.KGlobalLua();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ThanMaOrigin.Lua.Native.KGlobalLua constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReloadMapSetting(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ReloadMapSetting( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReloadTimeFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ReloadTimeFrame( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RegisterTimerPoint(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RegisterTimerPoint( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GMCommand(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GMCommand( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRoleList(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetRoleList( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoginRole(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.LoginRole( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConnectGateway(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ConnectGateway( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConnectWorldServer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ConnectWorldServer( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetWorldServerConnectTimeout(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetWorldServerConnectTimeout( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConnectServer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ConnectServer( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReconnectServer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ReconnectServer( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_SetStandAlone(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetStandAlone( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetGameWorldScale(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetGameWorldScale( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetVSyncFPS(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetVSyncFPS( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseServerConnect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CloseServerConnect( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseGateWayConnect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CloseGateWayConnect( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTime(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetTime( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForbidReconnect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ForbidReconnect( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Logout(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.Logout( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendChannelMessage(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SendChannelMessage( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsServerConnected(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsServerConnected( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SendPrivateMessage(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SendPrivateMessage( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BindCameraToNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.BindCameraToNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RequestServerList(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RequestServerList( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RequestRankServerCommon(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RequestRankServerCommon( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RequestAccSerInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RequestAccSerInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RequestAccountActive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.RequestAccountActive( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAccountName(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAccountName( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCertification(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetCertification( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetServerList(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetServerList( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetServerRegion(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetServerRegion( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetServerName(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetServerName( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseLinkData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ParseLinkData( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetServerCreateTime(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetServerCreateTime( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TraverseDir(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.TraverseDir( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GiveUpWaitQueue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GiveUpWaitQueue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloseMap(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CloseMap( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartRecordScreen(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.StartRecordScreen( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StopRecordScreen(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.StopRecordScreen( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoLoadMap(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DoLoadMap( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetLogicFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ResetLogicFrame( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPingDelay(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPingDelay( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetDeviceIPAdress(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetDeviceIPAdress( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAppleEquipId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAppleEquipId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAppleMacAddress(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAppleMacAddress( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAppleModelName(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAppleModelName( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAppleIdfa(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAppleIdfa( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAppleAppVersion(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAppleAppVersion( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAppleBatteryLevel(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAppleBatteryLevel( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAppletNetWorkType(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAppletNetWorkType( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAppletTelecomOper(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAppletTelecomOper( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetStat(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ResetStat( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckBarrier(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CheckBarrier( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LogBeforeLogin(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.LogBeforeLogin( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetServerIpInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetServerIpInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsJailbroken(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsJailbroken( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Crash(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.Crash( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateRole(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CreateRole( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMeInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetMeInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HideAllNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.HideAllNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetFrame( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetLuaTop(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetLuaTop( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeleteNearbyCampNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DeleteNearbyCampNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNpcDialogDistance(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetNpcDialogDistance( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CrashInCpp(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CrashInCpp( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HeartBeatToWorldServer(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.HeartBeatToWorldServer( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMapBaseInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetMapBaseInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CanAutoPathReach(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CanAutoPathReach( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAOIOpen(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetAOIOpen( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadAllRegions(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.LoadAllRegions( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsRegionExists(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsRegionExists( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetZoneTimeSecDiff(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetZoneTimeSecDiff( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearRandomKeyAndAccountInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ClearRandomKeyAndAccountInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGlobalP2PTradeProcessor(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetGlobalP2PTradeProcessor( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPayOpen(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsPayOpen( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMarketStallMgr(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetMarketStallMgr( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlayerMaxLevel(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPlayerMaxLevel( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetQueueOrderNumber(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetQueueOrderNumber( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetQueueOrderNumber(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetQueueOrderNumber( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadLuaFile(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ReadLuaFile( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteLuaFile(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.WriteLuaFile( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SyncTeamMemberTarget(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SyncTeamMemberTarget( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SyncTeamMemberFightPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SyncTeamMemberFightPos( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetRideState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetRideState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetResetTargetNpcPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetResetTargetNpcPos( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlayerZongShiLevelSetting(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPlayerZongShiLevelSetting( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadTabFileEx(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.LoadTabFileEx( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadTxtFile(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ReadTxtFile( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MathRandom(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.MathRandom( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MathGetRandSeed(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.MathGetRandSeed( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MathSetRandSeed(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.MathSetRandSeed( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTimeFrameState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetTimeFrameState( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalcTimeFrameOpenTime(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CalcTimeFrameOpenTime( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsSameMapId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsSameMapId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTableSize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetTableSize( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TestFunc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.TestFunc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CheckNameAvailable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CheckNameAvailable( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPartnerBaseExp(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPartnerBaseExp( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddObj(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddObj( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelObj(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DelObj( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetFileChangeTime(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetFileChangeTime( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkillBaseInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetSkillBaseInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DoSystemCmd(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DoSystemCmd( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DebugAssert(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DebugAssert( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMapTemplateId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetMapTemplateId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlayerInitInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPlayerInitInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemOwner(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemOwner( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemByName(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemByName( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMapHeight(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetMapHeight( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetItemRes(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemRes( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetEquipIconByShowType(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetEquipIconByShowType( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemAttributePower(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemAttributePower( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemTimeOut(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemTimeOut( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemGenTime(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemGenTime( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTimeOutInvalid(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetTimeOutInvalid( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetItemDynamicTimeOut(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemDynamicTimeOut( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StringToLower(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.StringToLower( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGroupKey(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetGroupKey( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ChangeGroupKeyInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ChangeGroupKeyInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReplaceLimitWords(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ReplaceLimitWords( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTongMapTemplateId(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetTongMapTemplateId( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddDynObst(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddDynObst( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelDynObst(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.DelDynObst( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_EnableDynObst(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.EnableDynObst( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsEnableDynObst(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsEnableDynObst( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.PushString( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.PopString( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReplaceString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ReplaceString( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AppendString(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AppendString( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMaxAttackSpeed(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetMaxAttackSpeed( _args );
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
			
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Data);
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
			
                ThanMaOrigin.Lua.Native.KGlobalLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KGlobalLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Data = (ThanMaOrigin.Lua.Native.KGlobalLuaData)translator.GetObject(L, 2, typeof(ThanMaOrigin.Lua.Native.KGlobalLuaData));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
