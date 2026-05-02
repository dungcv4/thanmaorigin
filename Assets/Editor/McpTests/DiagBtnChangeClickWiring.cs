// Diagnose why click on btnChange (the ">" arrow button) doesn't open UISelectServer popup.
// Per gốc Lua Script_Ui_Window_UILoginServer.lua:127:
//   tbOnClick.btnChangeServer = function(self) Ui:OpenWindow("UISelectServer", self.tbSerList) end
// Per gốc UIPanel:InitButtonEvent walker:
//   for key, func in pairs(self.tbOnClick) do
//     if self[key] then Ui:Button_BindEvent(self.pPanel, self[key], func, self) end
//   end
// Bug hypothesis: walker doesn't fire OR Button_BindEvent fails OR self.btnChangeServer resolve nil.

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class DiagBtnChangeClickWiring
{
    public static void Execute()
    {
        Debug.Log("=== DiagBtnChangeClickWiring START ===");

        var btn = GameObject.Find("UILoginServer/imgBG/PanelServer/btnChange");
        if (btn == null) { Debug.LogError("btnChange not found in scene"); return; }

        var b = btn.GetComponent<Button>();
        if (b == null) { Debug.LogError("No Button on btnChange"); return; }

        Debug.Log($"  Button.interactable={b.interactable} enabled={b.enabled} transition={b.transition}");
        Debug.Log($"  Button.onClick.GetPersistentEventCount={b.onClick.GetPersistentEventCount()}");
        // Reflect runtime listeners
        var fld = typeof(UnityEngine.Events.UnityEventBase).GetField("m_Calls", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        if (fld != null)
        {
            var calls = fld.GetValue(b.onClick);
            if (calls != null)
            {
                var runtimeCallsFld = calls.GetType().GetField("m_RuntimeCalls", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (runtimeCallsFld != null)
                {
                    var rc = runtimeCallsFld.GetValue(calls) as System.Collections.IList;
                    Debug.Log($"  Button.onClick runtime listeners count = {(rc?.Count ?? -1)}");
                }
            }
        }

        // Try invoke onClick directly to see if anything fires
        Debug.Log("  Invoking Button.onClick.Invoke()...");
        try { b.onClick.Invoke(); Debug.Log("  Invoke returned (no exception)"); }
        catch (System.Exception e) { Debug.LogError("  Invoke threw: " + e.Message); }

        // Check Lua side: does tbWnd have tbOnClick + did InitButtonEvent run
        var luaEngine = ThanMaOrigin.Lua.LuaEngine.Instance;
        if (luaEngine == null) { Debug.LogError("LuaEngine null — script ran in Edit mode?"); }
        else
        {
            try
            {
                luaEngine.Env.DoString(@"
                    local ok, err = pcall(function()
                        local wnd = Ui:GetWindow('UILoginServer')
                        if not wnd then print('[DIAG] UILoginServer wnd nil'); return end
                        print('[DIAG] tbOnClick type=' .. type(wnd.tbOnClick))
                        if type(wnd.tbOnClick) == 'table' then
                            local c = 0
                            for k, _ in pairs(wnd.tbOnClick) do c = c + 1; print('[DIAG]   tbOnClick.' .. k) end
                            print('[DIAG] tbOnClick keys count=' .. c)
                            print('[DIAG] tbOnClick.btnChangeServer type=' .. type(wnd.tbOnClick.btnChangeServer))
                        end
                        print('[DIAG] wnd.btnChangeServer type=' .. type(wnd.btnChangeServer))
                        print('[DIAG] tbControls.btnChangeServer = ' .. tostring(tbControls and tbControls.btnChangeServer))
                        if wnd.tbOnClick and wnd.tbOnClick.btnChangeServer then
                            print('[DIAG] Trying direct call wnd.tbOnClick.btnChangeServer(wnd)')
                            local ok2, err2 = pcall(wnd.tbOnClick.btnChangeServer, wnd)
                            print('[DIAG]   call ok=' .. tostring(ok2) .. ' err=' .. tostring(err2))
                        end
                    end)
                    if not ok then print('[DIAG] LUA ERR: ' .. tostring(err)) end
                ");
            }
            catch (System.Exception e) { Debug.LogError("[DIAG] C# ex: " + e.Message); }
        }

        Debug.Log("=== END ===");
    }
}
