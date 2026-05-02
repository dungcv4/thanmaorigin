// DEBUG 2026-05-02 — directly evaluate Lua state to check why RECOMMEND branch
// doesn't fire even though nType=2 prints. Hypothesis: nType is string "2" but
// Login.SERVER_TYPE_RECOMMEND is number 2 → Lua "2"==2 is false → no branch matches.

using UnityEngine;
using UnityEditor;

public static class DiagLoginServerNType
{
    public static void Execute()
    {
        Debug.Log("=== DiagLoginServerNType START ===");
        var engine = ThanMaOrigin.Lua.LuaEngine.Instance;
        if (engine == null) { Debug.LogError("LuaEngine not running. Press Play first."); return; }

        // Find UILoginServer window via the Ui table
        try
        {
        engine.Env.DoString(@"
            local ok, err = pcall(function()
            local wnd = Ui and Ui:GetWindow and Ui:GetWindow('UILoginServer')
            if not wnd then
                print('[DIAG] UILoginServer window not found via Ui:GetWindow')
                return
            end
            print('[DIAG] UILoginServer wnd found. nCurServerId=' .. tostring(wnd.nCurServerId))

            -- Re-poke server list
            if wnd.tbSerList then
                print('[DIAG] tbSerList type=' .. type(wnd.tbSerList) .. ' #=' .. tostring(#wnd.tbSerList))
                for i, srv in ipairs(wnd.tbSerList) do
                    print(string.format('[DIAG]   server[%d] dwServerId=%s nType=%s (type %s) szName=%s',
                        i, tostring(srv.dwServerId), tostring(srv.nType),
                        type(srv.nType), tostring(srv.szName)))
                    if i >= 3 then break end
                end
            else
                print('[DIAG] wnd.tbSerList = nil')
            end

            print('[DIAG] Login.SERVER_TYPE_RECOMMEND = ' .. tostring(Login.SERVER_TYPE_RECOMMEND) ..
                  ' (type ' .. type(Login.SERVER_TYPE_RECOMMEND) .. ')')

            -- Try forcing RECOMMEND branch on first server
            if wnd.tbSerList and wnd.tbSerList[1] then
                print('[DIAG] Force-running UpdateServerShow with nType=2 (number)')
                local copy = {}
                for k,v in pairs(wnd.tbSerList[1]) do copy[k]=v end
                copy.nType = 2
                wnd:UpdateServerShow(copy)
                print('[DIAG] After force: ServerFlagGreen IsActive = ' ..
                    tostring(wnd.pPanel:IsActive('imgBG/PanelServer/ServerFlagGreen')))
            end
            end)
            if not ok then print('[DIAG] LUA ERROR: ' .. tostring(err)) end
        ");
        }
        catch (System.Exception e) { Debug.LogError("[DIAG] C# exception: " + e); }

        Debug.Log("=== DiagLoginServerNType END ===");
    }
}
