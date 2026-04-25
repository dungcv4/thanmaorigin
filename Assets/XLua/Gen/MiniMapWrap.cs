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
    public class MiniMapWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(MiniMap);
			Utils.BeginObjectRegister(type, L, translator, 0, 10, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetUIPanel", _m_SetUIPanel);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ResetOnSwitchMap", _m_ResetOnSwitchMap);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetMiniMapInfo", _m_SetMiniMapInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdatePlayerPos", _m_UpdatePlayerPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateTeamMember", _m_UpdateTeamMember);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddTeamMemberNpcID", _m_AddTeamMemberNpcID);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetTeamMemberLogicPos", _m_SetTeamMemberLogicPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPlayerLogicPos", _m_SetPlayerLogicPos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetUVOffset", _m_SetUVOffset);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetMapPointOffset", _m_SetMapPointOffset);
			
			
			
			
			
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
					
					var gen_ret = new MiniMap();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to MiniMap constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUIPanel(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MiniMap gen_to_be_invoked = (MiniMap)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<Game.UI.UIPanel>(L, 2)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    Game.UI.UIPanel _pPanel = (Game.UI.UIPanel)translator.GetObject(L, 2, typeof(Game.UI.UIPanel));
                    string _templatePath = LuaAPI.lua_tostring(L, 3);
                    int _maxTeamMember = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.SetUIPanel( _pPanel, _templatePath, _maxTeamMember );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 4&& translator.Assignable<Game.UI.UIPanel>(L, 2)&& translator.Assignable<UnityEngine.Transform>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    Game.UI.UIPanel _pPanel = (Game.UI.UIPanel)translator.GetObject(L, 2, typeof(Game.UI.UIPanel));
                    UnityEngine.Transform _templateTrans = (UnityEngine.Transform)translator.GetObject(L, 3, typeof(UnityEngine.Transform));
                    int _maxTeamMember = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.SetUIPanel( _pPanel, _templateTrans, _maxTeamMember );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to MiniMap.SetUIPanel!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetOnSwitchMap(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MiniMap gen_to_be_invoked = (MiniMap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ResetOnSwitchMap(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMiniMapInfo(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MiniMap gen_to_be_invoked = (MiniMap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _rawScale = (float)LuaAPI.lua_tonumber(L, 2);
                    float _padWidth = (float)LuaAPI.lua_tonumber(L, 3);
                    float _padHeight = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    gen_to_be_invoked.SetMiniMapInfo( _rawScale, _padWidth, _padHeight );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePlayerPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MiniMap gen_to_be_invoked = (MiniMap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdatePlayerPos(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateTeamMember(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MiniMap gen_to_be_invoked = (MiniMap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateTeamMember(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddTeamMemberNpcID(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MiniMap gen_to_be_invoked = (MiniMap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _nNpcID = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.AddTeamMemberNpcID( _nNpcID );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTeamMemberLogicPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MiniMap gen_to_be_invoked = (MiniMap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _nSlot = LuaAPI.xlua_tointeger(L, 2);
                    int _nLogicX = LuaAPI.xlua_tointeger(L, 3);
                    int _nLogicY = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.SetTeamMemberLogicPos( _nSlot, _nLogicX, _nLogicY );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPlayerLogicPos(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MiniMap gen_to_be_invoked = (MiniMap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _nLogicX = LuaAPI.xlua_tointeger(L, 2);
                    int _nLogicY = LuaAPI.xlua_tointeger(L, 3);
                    
                    gen_to_be_invoked.SetPlayerLogicPos( _nLogicX, _nLogicY );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetUVOffset(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MiniMap gen_to_be_invoked = (MiniMap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.SetUVOffset( _x, _y );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetMapPointOffset(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                MiniMap gen_to_be_invoked = (MiniMap)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.SetMapPointOffset( _x, _y );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
