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
    public class ClientMarketStallMgrWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Client.MarketStallMgr);
			Utils.BeginObjectRegister(type, L, translator, 0, 6, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DelStallItem", _m_DelStallItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetStallItem", _m_GetStallItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PushStallItemObj", _m_PushStallItemObj);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PopStallItemObj", _m_PopStallItemObj);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnSyncMarketStallItemList", _m_OnSyncMarketStallItemList);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "initBase", _m_initBase);
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 1, 0);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new Client.MarketStallMgr();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Client.MarketStallMgr constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DelStallItem(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Client.MarketStallMgr gen_to_be_invoked = (Client.MarketStallMgr)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _nStallId = LuaAPI.lua_toint64(L, 2);
                    
                    gen_to_be_invoked.DelStallItem( _nStallId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetStallItem(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Client.MarketStallMgr gen_to_be_invoked = (Client.MarketStallMgr)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _nStallId = LuaAPI.lua_toint64(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetStallItem( _nStallId );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PushStallItemObj(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Client.MarketStallMgr gen_to_be_invoked = (Client.MarketStallMgr)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _nStallId = LuaAPI.lua_toint64(L, 2);
                    object _pItemData = translator.GetObject(L, 3, typeof(object));
                    int _nFlag1 = LuaAPI.xlua_tointeger(L, 4);
                    int _nFlag2 = LuaAPI.xlua_tointeger(L, 5);
                    
                    gen_to_be_invoked.PushStallItemObj( _nStallId, _pItemData, _nFlag1, _nFlag2 );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PopStallItemObj(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Client.MarketStallMgr gen_to_be_invoked = (Client.MarketStallMgr)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    long _nStallId = LuaAPI.lua_toint64(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.PopStallItemObj( _nStallId );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnSyncMarketStallItemList(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Client.MarketStallMgr gen_to_be_invoked = (Client.MarketStallMgr)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    object _pSyncMsg = translator.GetObject(L, 2, typeof(object));
                    
                    gen_to_be_invoked.OnSyncMarketStallItemList( _pSyncMsg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_initBase(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Client.MarketStallMgr gen_to_be_invoked = (Client.MarketStallMgr)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.initBase(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Client.MarketStallMgr.Instance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
