// File: Assets/_Project/Scripts/Lua/UnityObjAlive.cs
//
// Helper for Lua to safely test whether a Unity Object reference is still alive.
//
// Background:
//   Unity overloads `Object.operator ==` to return true when the underlying native
//   object has been Destroy()'d, even if the C# wrapper still holds a reference.
//   From Lua/XLua, you cannot trigger that overload — `tbWnd.view == nil` does
//   plain reference comparison and returns false even for destroyed objects.
//   `tostring(view)` returns the type name (e.g. "Game.UI.UIView"), not "null",
//   for destroyed objects in many code paths.
//
// Usage from Lua:
//   if not CS.UnityObjAlive.IsAlive(tbWnd.view) then ... end
//
// 1-1 reference: gốc Lua native side calls XLuaScript::IsValid(view) which wraps
//   `view != nullptr && view->IsAlive()`. We provide the equivalent here.

using UnityEngine;

public static class UnityObjAlive
{
    public static bool IsAlive(Object o)
    {
        // Unity's overloaded `==` returns true if o is null OR has been Destroy()'d.
        // Negation gives "alive".
        return o != null;
    }
}
