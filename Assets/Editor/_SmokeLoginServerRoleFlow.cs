using UnityEditor;
using UnityEngine;

public static class _SmokeLoginServerRoleFlow
{
    private static double _startTime;
    private static double _nextLogTime;
    private static double _nextRoleProbeTime;
    private static bool _clickedRole;
    private static bool _finished;

    public static void Execute()
    {
        Debug.Log("[LOGIN_ROLE_FLOW_SMOKE] BEGIN");
        if (!Application.isPlaying)
        {
            Debug.LogError("[LOGIN_ROLE_FLOW_SMOKE] not playing");
            return;
        }

        var lua = ThanMaOrigin.Lua.LuaEngine.Instance;
        if (lua == null)
        {
            lua = Object.FindObjectOfType<ThanMaOrigin.Lua.LuaEngine>();
        }
        if (lua == null || lua.Env == null)
        {
            Debug.LogError("[LOGIN_ROLE_FLOW_SMOKE] LuaEngine env missing");
            return;
        }

        try
        {
            lua.Env.DoString(@"
                print('[LOGIN_ROLE_FLOW_SMOKE.LUA] start')
                if Ui then
                    Ui:CloseWindow('UIMessageBoxBig')
                    Ui:CloseWindow('UILoadingTips')
                    local wnd = Ui:GetWindow('UILoginServer')
                    if wnd then
                        wnd.nCurServerId = 1
                        if wnd.tbSerList then
                            print('[LOGIN_ROLE_FLOW_SMOKE.LUA] server list count=' .. tostring(#wnd.tbSerList))
                            Ui:OpenWindow('UISelectServer', wnd.tbSerList)
                            Ui:CloseWindow('UISelectServer')
                        else
                            print('[LOGIN_ROLE_FLOW_SMOKE.LUA] server list missing')
                        end
                        if wnd.tbOnClick and wnd.tbOnClick.btnLoginServer then
                            wnd.tbOnClick.btnLoginServer(wnd)
                            print('[LOGIN_ROLE_FLOW_SMOKE.LUA] clicked btnLoginServer')
                        else
                            print('[LOGIN_ROLE_FLOW_SMOKE.LUA] btnLoginServer missing')
                        end
                    else
                        print('[LOGIN_ROLE_FLOW_SMOKE.LUA] UILoginServer missing')
                    end
                end
            ", "LOGIN_ROLE_FLOW_SMOKE_Start");
        }
        catch (System.Exception e)
        {
            Debug.LogError("[LOGIN_ROLE_FLOW_SMOKE] Lua start failed: " + e.Message);
            return;
        }

        _clickedRole = false;
        _finished = false;
        _startTime = EditorApplication.timeSinceStartup;
        _nextLogTime = _startTime + 5;
        _nextRoleProbeTime = _startTime + 0.75;
        EditorApplication.update -= Poll;
        EditorApplication.update += Poll;
    }

    private static void Poll()
    {
        var elapsed = EditorApplication.timeSinceStartup - _startTime;
        if (elapsed < 0.75)
        {
            return;
        }

        if (!_clickedRole && EditorApplication.timeSinceStartup >= _nextRoleProbeTime)
        {
            _nextRoleProbeTime = EditorApplication.timeSinceStartup + 1;
            var result = RunLuaForString(@"
                local function isVisible(name)
                    return Ui and Ui.WindowVisible and Ui:WindowVisible(name)
                end

                if isVisible('UISelectRoleExist') then
                    local wnd = Ui:GetWindow('UISelectRoleExist')
                    if not wnd or not wnd.tbRoleList then
                        print('[LOGIN_ROLE_FLOW_SMOKE.LUA] UISelectRoleExist visible but role list missing')
                        return 'select-missing'
                    end
                    local idx = wnd.nSelectRole or 1
                    local role = wnd.tbRoleList[idx] or wnd.tbRoleList[1]
                    if not role then
                        print('[LOGIN_ROLE_FLOW_SMOKE.LUA] UISelectRoleExist visible but no role row')
                        return 'select-empty'
                    end
                    Ui.PlayerPrefs.SetInt('LoginRoleID', role.nRoleID)
                    print('[LOGIN_ROLE_FLOW_SMOKE.LUA] LoginRole existing role id=' .. tostring(role.nRoleID))
                    LoginRole(role.nRoleID)
                    return 'select-clicked'
                end

                if isVisible('UICreateRole') then
                    local wnd = Ui:GetWindow('UICreateRole')
                    if not wnd then
                        return 'create-missing'
                    end
                    wnd.nCurSelectSex = wnd.nCurSelectSex or 0
                    wnd.nCurFactionId = wnd.nCurFactionId or 1
                    local name = 'TMO' .. tostring(math.random(100000, 999999))
                    if wnd.pPanel and wnd.tbControls and wnd.tbControls.inputCreateRoleName then
                        wnd.pPanel:Input_SetText(wnd.tbControls.inputCreateRoleName, name)
                    end
                    print('[LOGIN_ROLE_FLOW_SMOKE.LUA] CreateRole name=' .. name)
                    CreateRole(name, wnd.nCurSelectSex, wnd.nCurFactionId)
                    return 'create-clicked'
                end

                return 'none'
            ", "LOGIN_ROLE_FLOW_SMOKE_ClickRoleWindow");

            if (result == "select-clicked" || result == "create-clicked")
            {
                _clickedRole = true;
                Debug.Log("[LOGIN_ROLE_FLOW_SMOKE] role action=" + result);
            }
        }

        var hud = FindSceneObjectActive("UIHud");
        var loading = FindSceneObjectActive("UILoadingTips");
        var msgBox = FindSceneObjectActive("UIMessageBoxBig");
        var roleSelect = FindSceneObjectActive("UISelectRoleExist");
        var roleCreate = FindSceneObjectActive("UICreateRole");

        if (!_finished && EditorApplication.timeSinceStartup >= _nextLogTime)
        {
            _nextLogTime = EditorApplication.timeSinceStartup + 2;
            Debug.Log(
                "[LOGIN_ROLE_FLOW_SMOKE] POLL " +
                "elapsed=" + elapsed.ToString("0.0") + " " +
                "UILoadingTips=" + loading + " " +
                "UIMessageBoxBig=" + msgBox + " " +
                "UISelectRoleExist=" + roleSelect + " " +
                "UICreateRole=" + roleCreate + " " +
                "UIHud=" + hud);
        }

        if (hud == "active")
        {
            _finished = true;
            EditorApplication.update -= Poll;
            Debug.Log("[LOGIN_ROLE_FLOW_SMOKE] PASS UIHud=active");
            return;
        }

        if (elapsed > 35)
        {
            EditorApplication.update -= Poll;
            Debug.LogError(
                "[LOGIN_ROLE_FLOW_SMOKE] TIMEOUT " +
                "UILoadingTips=" + loading + " " +
                "UIMessageBoxBig=" + msgBox + " " +
                "UISelectRoleExist=" + roleSelect + " " +
                "UICreateRole=" + roleCreate + " " +
                "UIHud=" + hud);
        }
    }

    private static void RunLua(string code, string chunkName)
    {
        try
        {
            ThanMaOrigin.Lua.LuaEngine.Instance.Env.DoString(code, chunkName);
        }
        catch (System.Exception e)
        {
            Debug.LogError("[LOGIN_ROLE_FLOW_SMOKE] Lua failed: " + e.Message);
        }
    }

    private static string RunLuaForString(string code, string chunkName)
    {
        try
        {
            var lua = ThanMaOrigin.Lua.LuaEngine.Instance;
            if (lua == null || lua.Env == null) return "no-env";
            var values = lua.Env.DoString(code, chunkName);
            if (values != null && values.Length > 0 && values[0] != null)
            {
                return values[0].ToString();
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("[LOGIN_ROLE_FLOW_SMOKE] Lua failed: " + e.Message);
        }

        return "error";
    }

    private static string FindSceneObjectActive(string name)
    {
        var foundInactive = false;
        foreach (var go in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            if (go.name == name && go.scene.IsValid())
            {
                if (go.activeInHierarchy) return "active";
                foundInactive = true;
            }
        }

        return foundInactive ? "inactive" : "missing";
    }
}
