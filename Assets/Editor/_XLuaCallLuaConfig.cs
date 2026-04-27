// XLua CSharpCallLua type registration — required for Lua functions to be converted
// to C# delegate types (e.g., UnityAction<bool> for Toggle.onValueChanged callbacks).
// Without this list, XLua throws "This type must add to CSharpCallLua" at runtime.
//
// 1-1 cite: gốc XLua Gen wrap files have these registered. thanmaorigin runs in
// reflection-only mode (no Gen), so we register at editor-time via [CSharpCallLua]
// attribute on a static List<Type> field.
//
// Source: gốc Lua Toggle_BindEvent (Script_Ui_Ui.lua:2043) calls
//   togBtn.onValueChanged:AddListener(luaFunc) where luaFunc must convert to UnityAction<bool>.
// Same for Button.onClick (UnityAction).

using System;
using System.Collections.Generic;
using UnityEngine.Events;

public static class _XLuaCallLuaConfig
{
    [XLua.CSharpCallLua]
    public static List<Type> CSharpCallLuaList = new List<Type>()
    {
        typeof(System.Action),
        typeof(System.Action<bool>),
        typeof(System.Action<int>),
        typeof(System.Action<float>),
        typeof(System.Action<string>),
        typeof(System.Action<UnityEngine.GameObject>),
        typeof(UnityEngine.Events.UnityAction),
        typeof(UnityEngine.Events.UnityAction<bool>),
        typeof(UnityEngine.Events.UnityAction<int>),
        typeof(UnityEngine.Events.UnityAction<float>),
        typeof(UnityEngine.Events.UnityAction<string>),
        typeof(UnityEngine.Events.UnityAction<UnityEngine.Vector2>),
    };
}
