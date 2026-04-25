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
    public class KTOLocalizationLanguageModuleWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(KTO.Localization.LanguageModule);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 9, 16, 15);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "CurrentLanguageCode", _m_CurrentLanguageCode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Get", _m_Get_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Format", _m_Format_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadDefaultString", _m_LoadDefaultString_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ForceReload", _m_ForceReload_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadLanguage", _m_LoadLanguage_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ParseI18nTokens", _m_ParseI18nTokens_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "HasTerm", _m_HasTerm_xlua_st_);
            
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "TermCount", _g_get_TermCount);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szNPC_FLYCHAR_TYPE_HIT_MISS", _g_get_szNPC_FLYCHAR_TYPE_HIT_MISS);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szNPC_FLYCHAR_TYPE_HURT_MISS", _g_get_szNPC_FLYCHAR_TYPE_HURT_MISS);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szNPC_FLYCHAR_TYPE_HIT_RESIST", _g_get_szNPC_FLYCHAR_TYPE_HIT_RESIST);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szNPC_FLYCHAR_TYPE_HURT_RESIST", _g_get_szNPC_FLYCHAR_TYPE_HURT_RESIST);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szNPC_FLYCHAR_TYPE_HIT_CLEAR", _g_get_szNPC_FLYCHAR_TYPE_HIT_CLEAR);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szNPC_FLYCHAR_TYPE_HURT_CLEAR", _g_get_szNPC_FLYCHAR_TYPE_HURT_CLEAR);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szNPC_FLYCHAR_JINGHUO", _g_get_szNPC_FLYCHAR_JINGHUO);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szNPC_FLYCHAR_TYPE_HURT_NORMAL", _g_get_szNPC_FLYCHAR_TYPE_HURT_NORMAL);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szNPC_FLYCHAR_TYPE_CURE", _g_get_szNPC_FLYCHAR_TYPE_CURE);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szNPC_FLYCHAR_ADD_EXP", _g_get_szNPC_FLYCHAR_ADD_EXP);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szNPC_FLYCHAR_TYPE_HIT_BLOCK", _g_get_szNPC_FLYCHAR_TYPE_HIT_BLOCK);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szNPC_FLYCHAR_TYPE_HURT_BLOCK", _g_get_szNPC_FLYCHAR_TYPE_HURT_BLOCK);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szOk", _g_get_szOk);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "szCancel", _g_get_szCancel);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Parse", _g_get_Parse);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szNPC_FLYCHAR_TYPE_HIT_MISS", _s_set_szNPC_FLYCHAR_TYPE_HIT_MISS);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szNPC_FLYCHAR_TYPE_HURT_MISS", _s_set_szNPC_FLYCHAR_TYPE_HURT_MISS);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szNPC_FLYCHAR_TYPE_HIT_RESIST", _s_set_szNPC_FLYCHAR_TYPE_HIT_RESIST);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szNPC_FLYCHAR_TYPE_HURT_RESIST", _s_set_szNPC_FLYCHAR_TYPE_HURT_RESIST);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szNPC_FLYCHAR_TYPE_HIT_CLEAR", _s_set_szNPC_FLYCHAR_TYPE_HIT_CLEAR);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szNPC_FLYCHAR_TYPE_HURT_CLEAR", _s_set_szNPC_FLYCHAR_TYPE_HURT_CLEAR);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szNPC_FLYCHAR_JINGHUO", _s_set_szNPC_FLYCHAR_JINGHUO);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szNPC_FLYCHAR_TYPE_HURT_NORMAL", _s_set_szNPC_FLYCHAR_TYPE_HURT_NORMAL);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szNPC_FLYCHAR_TYPE_CURE", _s_set_szNPC_FLYCHAR_TYPE_CURE);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szNPC_FLYCHAR_ADD_EXP", _s_set_szNPC_FLYCHAR_ADD_EXP);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szNPC_FLYCHAR_TYPE_HIT_BLOCK", _s_set_szNPC_FLYCHAR_TYPE_HIT_BLOCK);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szNPC_FLYCHAR_TYPE_HURT_BLOCK", _s_set_szNPC_FLYCHAR_TYPE_HURT_BLOCK);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szOk", _s_set_szOk);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "szCancel", _s_set_szCancel);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "Parse", _s_set_Parse);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "KTO.Localization.LanguageModule does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CurrentLanguageCode_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = KTO.Localization.LanguageModule.CurrentLanguageCode(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Get_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = KTO.Localization.LanguageModule.Get( _key, _args );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Format_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _fmt = LuaAPI.lua_tostring(L, 1);
                    object[] _args = translator.GetParams<object>(L, 2);
                    
                        var gen_ret = KTO.Localization.LanguageModule.Format( _fmt, _args );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadDefaultString_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    KTO.Localization.LanguageModule.LoadDefaultString(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForceReload_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                    KTO.Localization.LanguageModule.ForceReload(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadLanguage_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _code = LuaAPI.lua_tostring(L, 1);
                    
                    KTO.Localization.LanguageModule.LoadLanguage( _code );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ParseI18nTokens_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _input = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = KTO.Localization.LanguageModule.ParseI18nTokens( _input );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasTerm_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _key = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = KTO.Localization.LanguageModule.HasTerm( _key );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TermCount(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, KTO.Localization.LanguageModule.TermCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szNPC_FLYCHAR_TYPE_HIT_MISS(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HIT_MISS);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szNPC_FLYCHAR_TYPE_HURT_MISS(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HURT_MISS);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szNPC_FLYCHAR_TYPE_HIT_RESIST(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HIT_RESIST);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szNPC_FLYCHAR_TYPE_HURT_RESIST(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HURT_RESIST);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szNPC_FLYCHAR_TYPE_HIT_CLEAR(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HIT_CLEAR);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szNPC_FLYCHAR_TYPE_HURT_CLEAR(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HURT_CLEAR);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szNPC_FLYCHAR_JINGHUO(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szNPC_FLYCHAR_JINGHUO);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szNPC_FLYCHAR_TYPE_HURT_NORMAL(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HURT_NORMAL);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szNPC_FLYCHAR_TYPE_CURE(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_CURE);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szNPC_FLYCHAR_ADD_EXP(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szNPC_FLYCHAR_ADD_EXP);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szNPC_FLYCHAR_TYPE_HIT_BLOCK(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HIT_BLOCK);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szNPC_FLYCHAR_TYPE_HURT_BLOCK(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HURT_BLOCK);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szOk(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szOk);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_szCancel(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushstring(L, KTO.Localization.LanguageModule.szCancel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Parse(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, KTO.Localization.LanguageModule.Parse);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szNPC_FLYCHAR_TYPE_HIT_MISS(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HIT_MISS = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szNPC_FLYCHAR_TYPE_HURT_MISS(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HURT_MISS = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szNPC_FLYCHAR_TYPE_HIT_RESIST(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HIT_RESIST = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szNPC_FLYCHAR_TYPE_HURT_RESIST(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HURT_RESIST = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szNPC_FLYCHAR_TYPE_HIT_CLEAR(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HIT_CLEAR = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szNPC_FLYCHAR_TYPE_HURT_CLEAR(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HURT_CLEAR = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szNPC_FLYCHAR_JINGHUO(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szNPC_FLYCHAR_JINGHUO = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szNPC_FLYCHAR_TYPE_HURT_NORMAL(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HURT_NORMAL = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szNPC_FLYCHAR_TYPE_CURE(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_CURE = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szNPC_FLYCHAR_ADD_EXP(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szNPC_FLYCHAR_ADD_EXP = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szNPC_FLYCHAR_TYPE_HIT_BLOCK(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HIT_BLOCK = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szNPC_FLYCHAR_TYPE_HURT_BLOCK(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szNPC_FLYCHAR_TYPE_HURT_BLOCK = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szOk(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szOk = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_szCancel(RealStatePtr L)
        {
		    try {
                
			    KTO.Localization.LanguageModule.szCancel = LuaAPI.lua_tostring(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Parse(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    KTO.Localization.LanguageModule.Parse = translator.GetDelegate<KTO.Localization.LanguageModule.V_S_Parse>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
