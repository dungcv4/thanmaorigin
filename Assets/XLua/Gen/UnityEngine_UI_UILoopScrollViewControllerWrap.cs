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
    public class UnityEngineUIUILoopScrollViewControllerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.UI.UILoopScrollViewController);
			Utils.BeginObjectRegister(type, L, translator, 0, 13, 4, 2);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ResetScrollContentPosition", _m_ResetScrollContentPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InitLoopScrollView", _m_InitLoopScrollView);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnScrollPosChanged", _m_OnScrollPosChanged);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReuseCells", _m_ReuseCells);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnScrollToIndex", _m_OnScrollToIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateContents", _m_UpdateContents);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateContentWhenSizeNotChange", _m_UpdateContentWhenSizeNotChange);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCellsCount", _m_GetCellsCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMaxIndex", _m_GetMaxIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetMinIndex", _m_GetMinIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearCells", _m_ClearCells);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GoTop", _m_GoTop);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GoButtom", _m_GoButtom);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "CachedRectTransform", _g_get_CachedRectTransform);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CachedScrollRect", _g_get_CachedScrollRect);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "spacingHeight", _g_get_spacingHeight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onCellUpdate", _g_get_onCellUpdate);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "spacingHeight", _s_set_spacingHeight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onCellUpdate", _s_set_onCellUpdate);
            
			
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
					
					var gen_ret = new UnityEngine.UI.UILoopScrollViewController();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.UI.UILoopScrollViewController constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetScrollContentPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ResetScrollContentPosition(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitLoopScrollView(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szCellBase = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.InitLoopScrollView( _szCellBase );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnScrollPosChanged(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector2 _scrollPos;translator.Get(L, 2, out _scrollPos);
                    
                    gen_to_be_invoked.OnScrollPosChanged( _scrollPos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReuseCells(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _scrollDirection = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.ReuseCells( _scrollDirection );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnScrollToIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _nPos = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.OnScrollToIndex( _nPos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateContents(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _listSize = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.UpdateContents( _listSize );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateContentWhenSizeNotChange(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateContentWhenSizeNotChange(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCellsCount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetCellsCount(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMaxIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetMaxIndex(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetMinIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetMinIndex(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearCells(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ClearCells(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoTop(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.GoTop(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GoButtom(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.GoButtom(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CachedRectTransform(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.CachedRectTransform);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CachedScrollRect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.CachedScrollRect);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_spacingHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.spacingHeight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onCellUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onCellUpdate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_spacingHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.spacingHeight = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onCellUpdate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.UI.UILoopScrollViewController gen_to_be_invoked = (UnityEngine.UI.UILoopScrollViewController)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onCellUpdate = (UnityEngine.Events.UnityEvent<int, int>)translator.GetObject(L, 2, typeof(UnityEngine.Events.UnityEvent<int, int>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
