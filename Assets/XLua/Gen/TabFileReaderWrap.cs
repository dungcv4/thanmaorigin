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
    public class TabFileReaderWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(TabFileReader);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "SetEnv", _m_SetEnv_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LoadTabFileEx", _m_LoadTabFileEx_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "KLib_LoadTabFileEx", _m_KLib_LoadTabFileEx_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "KLib_LoadIniFile", _m_KLib_LoadIniFile_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "TabFileReader does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetEnv_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    XLua.LuaEnv _env = (XLua.LuaEnv)translator.GetObject(L, 1, typeof(XLua.LuaEnv));
                    
                    TabFileReader.SetEnv( _env );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadTabFileEx_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _szFile = LuaAPI.lua_tostring(L, 1);
                    string _szType = LuaAPI.lua_tostring(L, 2);
                    string _szIndex = LuaAPI.lua_tostring(L, 3);
                    XLua.LuaTable _tbField = (XLua.LuaTable)translator.GetObject(L, 4, typeof(XLua.LuaTable));
                    int _bOutsidePackage = LuaAPI.xlua_tointeger(L, 5);
                    int _nBeginRow = LuaAPI.xlua_tointeger(L, 6);
                    
                        var gen_ret = TabFileReader.LoadTabFileEx( _szFile, _szType, _szIndex, _tbField, _bOutsidePackage, _nBeginRow );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_KLib_LoadTabFileEx_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _szFile = LuaAPI.lua_tostring(L, 1);
                    int _bOutsidePackage = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = TabFileReader.KLib_LoadTabFileEx( _szFile, _bOutsidePackage );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_KLib_LoadIniFile_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _szFile = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = TabFileReader.KLib_LoadIniFile( _szFile );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
