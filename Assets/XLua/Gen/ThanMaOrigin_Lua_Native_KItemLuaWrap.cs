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
    public class ThanMaOriginLuaNativeKItemLuaWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(ThanMaOrigin.Lua.Native.KItemLua);
			Utils.BeginObjectRegister(type, L, translator, 0, 25, 37, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsEquip", _m_IsEquip);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsStackable", _m_IsStackable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBaseAttrib", _m_GetBaseAttrib);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetBaseAttribRange", _m_SetBaseAttribRange);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetBaseAttribRange", _m_GetBaseAttribRange);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetOwner", _m_GetOwner);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Remove", _m_Remove);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTimeOut", _m_SetTimeOut);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCount", _m_SetCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGenTime", _m_GetGenTime);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTimeOut", _m_GetTimeOut);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Sync", _m_Sync);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSingleValue", _m_GetSingleValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetSingleValue", _m_SetSingleValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetIntValue", _m_GetIntValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetStrValue", _m_GetStrValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReInit", _m_ReInit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetName", _m_SetName);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetItemShowInfo", _m_GetItemShowInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnTrade", _m_OnTrade);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsInTradeLimit", _m_IsInTradeLimit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSeries", _m_GetSeries);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PushCObj", _m_PushCObj);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetIt", _m_GetIt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearTempTable", _m_ClearTempTable);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Data", _g_get_Data);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AttributePower", _g_get_AttributePower);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "BaseFightPower", _g_get_BaseFightPower);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CdType", _g_get_CdType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Class", _g_get_Class);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Count", _g_get_Count);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DetailType", _g_get_DetailType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EquipPos", _g_get_EquipPos);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FightPower", _g_get_FightPower);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "GUID", _g_get_GUID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "HoleCount", _g_get_HoleCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Id", _g_get_Id);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "InsetLevel", _g_get_InsetLevel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsEmptyAttr", _g_get_IsEmptyAttr);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ItemType", _g_get_ItemType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "KinRuneLevel", _g_get_KinRuneLevel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Level", _g_get_Level);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "MaxCount", _g_get_MaxCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Name", _g_get_Name);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ObjIdx", _g_get_ObjIdx);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OrgName", _g_get_OrgName);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OrgValue", _g_get_OrgValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Pos", _g_get_Pos);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Price", _g_get_Price);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Quality", _g_get_Quality);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "RealLevel", _g_get_RealLevel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Sex", _g_get_Sex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TemplateId", _g_get_TemplateId);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TemplateTradeLimitType", _g_get_TemplateTradeLimitType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TemplateTradeLimitValue", _g_get_TemplateTradeLimitValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TemplateTradeLimitWay", _g_get_TemplateTradeLimitWay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TradeLimitType", _g_get_TradeLimitType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TradeLimitValue", _g_get_TradeLimitValue);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "UseDelayMins", _g_get_UseDelayMins);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "UseLevel", _g_get_UseLevel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Value", _g_get_Value);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "WeaponType", _g_get_WeaponType);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Data", _s_set_Data);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "FightPower", _s_set_FightPower);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Quality", _s_set_Quality);
            
			
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
					
					var gen_ret = new ThanMaOrigin.Lua.Native.KItemLua();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ThanMaOrigin.Lua.Native.KItemLua constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsEquip(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsEquip( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsStackable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsStackable( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBaseAttrib(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetBaseAttrib( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetBaseAttribRange(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetBaseAttribRange( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetBaseAttribRange(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetBaseAttribRange( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetOwner(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetOwner( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Remove(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.Remove( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTimeOut(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetTimeOut( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetCount( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGenTime(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetGenTime( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTimeOut(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetTimeOut( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sync(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.Sync( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSingleValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetSingleValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSingleValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetSingleValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetIntValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetIntValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStrValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetStrValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReInit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.ReInit( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetItemShowInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetItemShowInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnTrade(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.OnTrade( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsInTradeLimit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsInTradeLimit( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSeries(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetSeries( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetIt(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetIt( _args );
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
            
            
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _g_get_Data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Data);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AttributePower(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.AttributePower);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_BaseFightPower(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.BaseFightPower);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CdType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.CdType);
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
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Class);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Count(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Count);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DetailType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.DetailType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EquipPos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.EquipPos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FightPower(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.FightPower);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_GUID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.GUID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_HoleCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.HoleCount);
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
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Id);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_InsetLevel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.InsetLevel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsEmptyAttr(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsEmptyAttr);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ItemType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ItemType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_KinRuneLevel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.KinRuneLevel);
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
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Level);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MaxCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.MaxCount);
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
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Name);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ObjIdx(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ObjIdx);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OrgName(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.OrgName);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OrgValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.OrgValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Pos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Pos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Price(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Price);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Quality(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Quality);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_RealLevel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.RealLevel);
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
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Sex);
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
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TemplateId);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TemplateTradeLimitType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TemplateTradeLimitType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TemplateTradeLimitValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TemplateTradeLimitValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TemplateTradeLimitWay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TemplateTradeLimitWay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TradeLimitType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TradeLimitType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TradeLimitValue(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TradeLimitValue);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UseDelayMins(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.UseDelayMins);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UseLevel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.UseLevel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Value(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Value);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_WeaponType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.WeaponType);
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
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Data = (ThanMaOrigin.Lua.Native.KItemLuaData)translator.GetObject(L, 2, typeof(ThanMaOrigin.Lua.Native.KItemLuaData));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FightPower(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.FightPower = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Quality(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                ThanMaOrigin.Lua.Native.KItemLua gen_to_be_invoked = (ThanMaOrigin.Lua.Native.KItemLua)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Quality = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
