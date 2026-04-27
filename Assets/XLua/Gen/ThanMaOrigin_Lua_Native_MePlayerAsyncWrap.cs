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
    public class ThanMaOriginLuaNativeMePlayerAsyncWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(ThanMaOrigin.Lua.Native.MePlayerAsync);
			Utils.BeginObjectRegister(type, L, translator, 0, 17, 3, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPlayerInfo", _m_GetPlayerInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddAsyncNpc", _m_AddAsyncNpc);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAsyncValue", _m_GetAsyncValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAsyncValue", _m_SetAsyncValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAsyncBattleValue", _m_GetAsyncBattleValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAsyncBattleValue", _m_SetAsyncBattleValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAsyncPowerValue", _m_GetAsyncPowerValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetAsyncPowerValue", _m_SetAsyncPowerValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetEquips", _m_GetEquips);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPartners", _m_GetPartners);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetScriptValue", _m_GetScriptValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetScriptValue", _m_SetScriptValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsPosHaveEquip", _m_IsPosHaveEquip);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSkills", _m_GetSkills);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAsyncAttr", _m_GetAsyncAttr);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetAttrTitles", _m_GetAttrTitles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PushCObj", _m_PushCObj);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Data", _g_get_Data);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ID", _g_get_ID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Name", _g_get_Name);
            
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
					
					var gen_ret = new ThanMaOrigin.Lua.Native.MePlayerAsync();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to ThanMaOrigin.Lua.Native.MePlayerAsync constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPlayerInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPlayerInfo( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddAsyncNpc(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.AddAsyncNpc( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAsyncValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAsyncValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAsyncValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetAsyncValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAsyncBattleValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAsyncBattleValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAsyncBattleValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetAsyncBattleValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAsyncPowerValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAsyncPowerValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetAsyncPowerValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetAsyncPowerValue( _args );
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
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetPartners(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetPartners( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetScriptValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetScriptValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetScriptValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.SetScriptValue( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPosHaveEquip(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsPosHaveEquip( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSkills(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetSkills( _args );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAsyncAttr(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetAsyncAttr( _args );
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
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_PushCObj(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
            
            
                
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
			
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Data);
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
			
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ID);
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
			
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Name);
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
			
                ThanMaOrigin.Lua.Native.MePlayerAsync gen_to_be_invoked = (ThanMaOrigin.Lua.Native.MePlayerAsync)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Data = (ThanMaOrigin.Lua.Native.MePlayerAsyncData)translator.GetObject(L, 2, typeof(ThanMaOrigin.Lua.Native.MePlayerAsyncData));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
