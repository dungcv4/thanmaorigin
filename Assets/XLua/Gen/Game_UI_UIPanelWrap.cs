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
    public class GameUIUIPanelWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Game.UI.UIPanel);
			Utils.BeginObjectRegister(type, L, translator, 0, 38, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetActive", _m_SetActive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsActive", _m_IsActive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Label_SetText", _m_Label_SetText);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Label_GetText", _m_Label_GetText);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetText", _m_GetText);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Sprite_SetSprite", _m_Sprite_SetSprite);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Sprite_SetSpriteImage", _m_Sprite_SetSpriteImage);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Sprite_SetNativeSize", _m_Sprite_SetNativeSize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Sprite_SetFill", _m_Sprite_SetFill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetImage", _m_GetImage);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetButton", _m_GetButton);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Button_BindEvent", _m_Button_BindEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Swipe_BindEvent", _m_Swipe_BindEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Button_SetEnable", _m_Button_SetEnable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Button_SetText", _m_Button_SetText);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Button_BindLongPressEnd", _m_Button_BindLongPressEnd);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Button_BindLongPressUp", _m_Button_BindLongPressUp);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Button_BindLongPressLoop", _m_Button_BindLongPressLoop);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Label_SetColorByName", _m_Label_SetColorByName);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetToggle", _m_GetToggle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Toggle_BindEvent", _m_Toggle_BindEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Toggle_SetChecked", _m_Toggle_SetChecked);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Toggle_GetChecked", _m_Toggle_GetChecked);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Toggle_SetEnable", _m_Toggle_SetEnable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToggleGroup_SetSelect", _m_ToggleGroup_SetSelect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetInput", _m_GetInput);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Input_GetText", _m_Input_GetText);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Input_SetText", _m_Input_SetText);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTransform", _m_GetTransform);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetRectTransform", _m_GetRectTransform);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetObject", _m_GetObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Object_SetSize", _m_Object_SetSize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddObject", _m_AddObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloneObject", _m_CloneObject);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CloneObjectAsSamePosition", _m_CloneObjectAsSamePosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPanelSortingOrder", _m_GetPanelSortingOrder);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetPanelSortingOrder", _m_SetPanelSortingOrder);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ContentSizeFitter_Refresh", _m_ContentSizeFitter_Refresh);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "UIPath", _g_get_UIPath);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "UIPath", _s_set_UIPath);
            
			
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
					
					var gen_ret = new Game.UI.UIPanel();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Game.UI.UIPanel constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetActive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    bool _bVisible = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.SetActive( _szKey, _bVisible );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsActive(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.IsActive( _szKey );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Label_SetText(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    string _szText = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.Label_SetText( _szKey, _szText );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Label_GetText(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.Label_GetText( _szKey );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetText(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetText( _szKey );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sprite_SetSprite(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    string _szPath = LuaAPI.lua_tostring(L, 3);
                    bool _bOverride = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.Sprite_SetSprite( _szKey, _szPath, _bOverride );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    string _szPath = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.Sprite_SetSprite( _szKey, _szPath );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Game.UI.UIPanel.Sprite_SetSprite!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sprite_SetSpriteImage(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Sprite>(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Sprite _sprite = (UnityEngine.Sprite)translator.GetObject(L, 3, typeof(UnityEngine.Sprite));
                    bool _bOverride = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.Sprite_SetSpriteImage( _szKey, _sprite, _bOverride );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<UnityEngine.Sprite>(L, 3)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.Sprite _sprite = (UnityEngine.Sprite)translator.GetObject(L, 3, typeof(UnityEngine.Sprite));
                    
                    gen_to_be_invoked.Sprite_SetSpriteImage( _szKey, _sprite );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Game.UI.UIPanel.Sprite_SetSpriteImage!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sprite_SetNativeSize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.Sprite_SetNativeSize( _szKey );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Sprite_SetFill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    float _fValue = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.Sprite_SetFill( _szKey, _fValue );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetImage(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetImage( _szKey );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetButton(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetButton( _szKey );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Button_BindEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    XLua.LuaFunction _funcCall = (XLua.LuaFunction)translator.GetObject(L, 3, typeof(XLua.LuaFunction));
                    object[] _vecParams = translator.GetParams<object>(L, 4);
                    
                    gen_to_be_invoked.Button_BindEvent( _szKey, _funcCall, _vecParams );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Swipe_BindEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    XLua.LuaFunction _funcCall = (XLua.LuaFunction)translator.GetObject(L, 3, typeof(XLua.LuaFunction));
                    
                    gen_to_be_invoked.Swipe_BindEvent( _szKey, _funcCall );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Button_SetEnable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    bool _bEnable = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.Button_SetEnable( _szKey, _bEnable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Button_SetText(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    string _szText = LuaAPI.lua_tostring(L, 3);
                    string _szTextPath = LuaAPI.lua_tostring(L, 4);
                    
                    gen_to_be_invoked.Button_SetText( _szKey, _szText, _szTextPath );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    string _szText = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.Button_SetText( _szKey, _szText );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Game.UI.UIPanel.Button_SetText!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Button_BindLongPressEnd(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    XLua.LuaFunction _funcCall = (XLua.LuaFunction)translator.GetObject(L, 3, typeof(XLua.LuaFunction));
                    
                    gen_to_be_invoked.Button_BindLongPressEnd( _szKey, _funcCall );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Button_BindLongPressUp(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    XLua.LuaFunction _funcCall = (XLua.LuaFunction)translator.GetObject(L, 3, typeof(XLua.LuaFunction));
                    
                    gen_to_be_invoked.Button_BindLongPressUp( _szKey, _funcCall );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Button_BindLongPressLoop(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    XLua.LuaFunction _funcCall = (XLua.LuaFunction)translator.GetObject(L, 3, typeof(XLua.LuaFunction));
                    
                    gen_to_be_invoked.Button_BindLongPressLoop( _szKey, _funcCall );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Label_SetColorByName(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    string _szName = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.Label_SetColorByName( _szKey, _szName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetToggle(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetToggle( _szKey );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Toggle_BindEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    XLua.LuaFunction _funcCall = (XLua.LuaFunction)translator.GetObject(L, 3, typeof(XLua.LuaFunction));
                    object[] _vecParams = translator.GetParams<object>(L, 4);
                    
                    gen_to_be_invoked.Toggle_BindEvent( _szKey, _funcCall, _vecParams );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Toggle_SetChecked(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    bool _bChecked = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.Toggle_SetChecked( _szKey, _bChecked );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Toggle_GetChecked(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.Toggle_GetChecked( _szKey );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Toggle_SetEnable(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    bool _bEnable = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.Toggle_SetEnable( _szKey, _bEnable );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToggleGroup_SetSelect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    bool _bSelect = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.ToggleGroup_SetSelect( _szKey, _bSelect );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetInput(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetInput( _szKey );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Input_GetText(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.Input_GetText( _szKey );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Input_SetText(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    string _szText = LuaAPI.lua_tostring(L, 3);
                    
                    gen_to_be_invoked.Input_SetText( _szKey, _szText );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTransform(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetTransform( _szKey );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRectTransform(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetRectTransform( _szKey );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    bool _bLog = LuaAPI.lua_toboolean(L, 3);
                    
                        var gen_ret = gen_to_be_invoked.GetObject( _szKey, _bLog );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.GetObject( _szKey );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Game.UI.UIPanel.GetObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Object_SetSize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    float _fWidth = (float)LuaAPI.lua_tonumber(L, 3);
                    float _fHeight = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    gen_to_be_invoked.Object_SetSize( _szKey, _fWidth, _fHeight );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    UnityEngine.GameObject _go = (UnityEngine.GameObject)translator.GetObject(L, 3, typeof(UnityEngine.GameObject));
                    
                    gen_to_be_invoked.AddObject( _szKey, _go );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloneObject(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    string _szName = LuaAPI.lua_tostring(L, 3);
                    string _szNewObjectKey = LuaAPI.lua_tostring(L, 4);
                    
                        var gen_ret = gen_to_be_invoked.CloneObject( _szKey, _szName, _szNewObjectKey );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    string _szName = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = gen_to_be_invoked.CloneObject( _szKey, _szName );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CloneObject( _szKey );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Game.UI.UIPanel.CloneObject!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CloneObjectAsSamePosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 4) || LuaAPI.lua_type(L, 4) == LuaTypes.LUA_TSTRING)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    string _szName = LuaAPI.lua_tostring(L, 3);
                    string _szNewObjectKey = LuaAPI.lua_tostring(L, 4);
                    
                        var gen_ret = gen_to_be_invoked.CloneObjectAsSamePosition( _szKey, _szName, _szNewObjectKey );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& (LuaAPI.lua_isnil(L, 3) || LuaAPI.lua_type(L, 3) == LuaTypes.LUA_TSTRING)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    string _szName = LuaAPI.lua_tostring(L, 3);
                    
                        var gen_ret = gen_to_be_invoked.CloneObjectAsSamePosition( _szKey, _szName );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                        var gen_ret = gen_to_be_invoked.CloneObjectAsSamePosition( _szKey );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Game.UI.UIPanel.CloneObjectAsSamePosition!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPanelSortingOrder(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        var gen_ret = gen_to_be_invoked.GetPanelSortingOrder(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetPanelSortingOrder(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _nOrder = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.SetPanelSortingOrder( _nOrder );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ContentSizeFitter_Refresh(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _szKey = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.ContentSizeFitter_Refresh( _szKey );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UIPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.UIPath);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UIPath(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Game.UI.UIPanel gen_to_be_invoked = (Game.UI.UIPanel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.UIPath = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
