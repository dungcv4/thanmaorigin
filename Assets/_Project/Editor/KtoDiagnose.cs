// KTO Diagnostics — Phase A smoke test (2026-04-26)
//
// Bypass MCP permission prompts: dump state to /tmp/kto_diag/ via menu items.
// Each menu writes a JSON/text file that can be read from outside Unity.
//
// Usage:
//   1. Press "KTO Diag → Dump Editor State" — captures scene + compile state
//   2. Enter Play mode, login
//   3. Press "KTO Diag → Dump Lua + HUD State" — captures Lua globals + HudRoot
//   4. Press "KTO Diag → Dump Console Logs" — captures all console buffer
//
// Output dir: /tmp/kto_diag/

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThanMaOrigin.EditorDiag
{
    public static class KtoDiagnose
    {
        const string OUT_DIR = "/tmp/kto_diag";

        static void EnsureDir()
        {
            if (!Directory.Exists(OUT_DIR)) Directory.CreateDirectory(OUT_DIR);
        }

        [MenuItem("KTO Diag/1. Dump Editor State")]
        public static void DumpEditorState()
        {
            EnsureDir();
            var sb = new StringBuilder();
            sb.AppendLine("=== EDITOR STATE ===");
            sb.AppendLine($"timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"unity: {Application.unityVersion}");
            sb.AppendLine($"playMode: {EditorApplication.isPlaying}");
            sb.AppendLine($"compileState: {EditorApplication.isCompiling}");
            sb.AppendLine($"updating: {EditorApplication.isUpdating}");
            sb.AppendLine();
            sb.AppendLine("=== LOADED SCENES ===");
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var s = SceneManager.GetSceneAt(i);
                sb.AppendLine($"  [{i}] {s.name} loaded={s.isLoaded} path={s.path}");
            }
            sb.AppendLine();
            sb.AppendLine("=== ACTIVE SCENE HIERARCHY (depth 2) ===");
            var active = SceneManager.GetActiveScene();
            foreach (var root in active.GetRootGameObjects())
            {
                sb.AppendLine($"+ {root.name} (active={root.activeInHierarchy})");
                for (int i = 0; i < root.transform.childCount; i++)
                {
                    var child = root.transform.GetChild(i);
                    sb.AppendLine($"  └ {child.name} (active={child.gameObject.activeInHierarchy})");
                }
            }
            File.WriteAllText(Path.Combine(OUT_DIR, "01_editor_state.txt"), sb.ToString());
            Debug.Log($"[KTO Diag] Wrote {OUT_DIR}/01_editor_state.txt");
        }

        [MenuItem("KTO Diag/2. Dump Lua + HUD State")]
        public static void DumpLuaState()
        {
            EnsureDir();
            var sb = new StringBuilder();
            sb.AppendLine("=== LUA + HUD STATE ===");
            sb.AppendLine($"timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"playMode: {EditorApplication.isPlaying}");
            sb.AppendLine();

            // Try to find LuaEngine via reflection
            var luaEngineType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => { try { return a.GetTypes(); } catch { return Type.EmptyTypes; } })
                .FirstOrDefault(t => t.FullName == "ThanMaOrigin.Lua.LuaEngine");
            if (luaEngineType == null)
            {
                sb.AppendLine("LuaEngine type NOT FOUND");
            }
            else
            {
                var instanceProp = luaEngineType.GetProperty("Instance",
                    BindingFlags.Public | BindingFlags.Static);
                var instance = instanceProp?.GetValue(null);
                sb.AppendLine($"LuaEngine.Instance: {(instance != null ? "EXISTS" : "NULL")}");
                if (instance != null)
                {
                    var envProp = luaEngineType.GetProperty("Env");
                    var env = envProp?.GetValue(instance);
                    sb.AppendLine($"LuaEngine.Env: {(env != null ? "EXISTS" : "NULL")}");
                    if (env != null)
                    {
                        try
                        {
                            // Probe Lua globals
                            var doStringMethod = env.GetType().GetMethod("DoString",
                                new[] { typeof(string), typeof(string), typeof(Type) });
                            if (doStringMethod != null)
                            {
                                var probe = @"
                                    local r = {}
                                    r.UiExists = (Ui ~= nil) and 'YES' or 'NO'
                                    if Ui then
                                        r.UiHomeScreenStateTable = (Ui.HomeScreenState ~= nil) and 'YES' or 'NO'
                                        r.UinHomeScreenState = tostring(Ui.nHomeScreenState)
                                        r.UibInDelayUpdateMain = tostring(Ui.bInDelayUpdateMain)
                                        r.UinUiState = tostring(Ui.nUiState)
                                        r.UinFightState = tostring(Ui.nFightState)
                                        r.UibIsInDestroyAllWindowState = tostring(Ui.bIsInDestroyAllWindowState)
                                        r.UitbUiCount = (Ui.tbUi ~= nil) and tostring(0) or 'NIL'
                                        if Ui.tbUi then
                                            local n = 0
                                            for _ in pairs(Ui.tbUi) do n = n + 1 end
                                            r.UitbUiCount = tostring(n)
                                        end
                                    end
                                    r.OperationExists = (Operation ~= nil) and 'YES' or 'NO'
                                    r.RemoteServerExists = (RemoteServer ~= nil) and 'YES' or 'NO'
                                    r.SendCMDExists = (SendCMD ~= nil) and 'YES' or 'NO'
                                    r.SendRemoteServerCallExists = (SendRemoteServerCall ~= nil) and 'YES' or 'NO'
                                    r.MeExists = (me ~= nil) and 'YES' or 'NO'
                                    r.MeRoleId = me and tostring(me.dwID or 'no_dwID') or 'no_me'
                                    r.MeMapId = me and tostring(me.nMapId or 'no_mapId') or 'no_me'
                                    r.ClientExists = (Client ~= nil) and 'YES' or 'NO'
                                    r.ClientUIModuleExists = (Client and Client.UIModule) and 'YES' or 'NO'
                                    r.EventNotifyExists = (EventNotify ~= nil) and 'YES' or 'NO'
                                    r.TimerExists = (Timer ~= nil) and 'YES' or 'NO'
                                    if Timer and Timer.tbRegister then
                                        local n = 0
                                        for _ in pairs(Timer.tbRegister) do n = n + 1 end
                                        r.TimerRegisterCount = tostring(n)
                                    else
                                        r.TimerRegisterCount = 'NIL'
                                    end
                                    local out = ''
                                    for k, v in pairs(r) do out = out .. k .. '=' .. tostring(v) .. '\n' end
                                    return out
                                ";
                                var result = doStringMethod.Invoke(env, new object[] { probe, "kto_diag", typeof(string) });
                                if (result is object[] arr && arr.Length > 0)
                                {
                                    sb.AppendLine("--- Lua probe result ---");
                                    sb.AppendLine(arr[0]?.ToString() ?? "(null)");
                                }
                                else
                                {
                                    sb.AppendLine($"DoString returned: {result?.GetType().Name ?? "null"}");
                                }
                            }
                            else
                            {
                                sb.AppendLine("DoString(string,string,Type) method NOT FOUND on Env");
                            }
                        }
                        catch (Exception e)
                        {
                            sb.AppendLine($"Lua probe ERROR: {e.GetType().Name}: {e.Message}");
                            sb.AppendLine(e.StackTrace);
                        }
                    }
                }
            }

            sb.AppendLine();
            sb.AppendLine("=== HUD STATE ===");
            var hudRoot = GameObject.Find("HudRoot");
            if (hudRoot == null)
            {
                sb.AppendLine("HudRoot: NOT FOUND in scene");
            }
            else
            {
                sb.AppendLine($"HudRoot: FOUND, children={hudRoot.transform.childCount}");
                for (int i = 0; i < hudRoot.transform.childCount; i++)
                {
                    var c = hudRoot.transform.GetChild(i);
                    sb.AppendLine($"  └ {c.name} active={c.gameObject.activeInHierarchy}");
                }
            }

            // List all "UI*" GameObjects in scene
            sb.AppendLine();
            sb.AppendLine("=== ALL UI* TOP-LEVEL GAMEOBJECTS ===");
            var active = SceneManager.GetActiveScene();
            int uiCount = 0;
            foreach (var root in active.GetRootGameObjects())
            {
                if (root.name.StartsWith("UI"))
                {
                    sb.AppendLine($"  + {root.name} active={root.activeInHierarchy} children={root.transform.childCount}");
                    uiCount++;
                }
            }
            sb.AppendLine($"Total root UI*: {uiCount}");

            File.WriteAllText(Path.Combine(OUT_DIR, "02_lua_hud_state.txt"), sb.ToString());
            Debug.Log($"[KTO Diag] Wrote {OUT_DIR}/02_lua_hud_state.txt");
        }

        [MenuItem("KTO Diag/3. Dump Console Logs (last 500)")]
        public static void DumpConsoleLogs()
        {
            EnsureDir();
            // Use reflection to grab Editor LogEntries.
            var logEntriesType = Type.GetType("UnityEditor.LogEntries,UnityEditor");
            if (logEntriesType == null)
            {
                File.WriteAllText(Path.Combine(OUT_DIR, "03_console_logs.txt"),
                    "ERROR: UnityEditor.LogEntries type not found");
                return;
            }
            var logEntryType = Type.GetType("UnityEditor.LogEntry,UnityEditor");

            var startGetting = logEntriesType.GetMethod("StartGettingEntries", BindingFlags.Static | BindingFlags.Public);
            var endGetting = logEntriesType.GetMethod("EndGettingEntries", BindingFlags.Static | BindingFlags.Public);
            var getEntry = logEntriesType.GetMethod("GetEntryInternal", BindingFlags.Static | BindingFlags.Public);
            var getCount = logEntriesType.GetMethod("GetCount", BindingFlags.Static | BindingFlags.Public);

            int total = (int)startGetting.Invoke(null, null);
            int countAvail = total;
            try
            {
                var entry = Activator.CreateInstance(logEntryType);
                var msgField = logEntryType.GetField("message", BindingFlags.Public | BindingFlags.Instance);
                var modeField = logEntryType.GetField("mode", BindingFlags.Public | BindingFlags.Instance);
                var sb = new StringBuilder();
                int from = Mathf.Max(0, countAvail - 500);
                sb.AppendLine($"=== CONSOLE LOGS (showing {from}..{countAvail} of {countAvail}) ===");
                for (int i = from; i < countAvail; i++)
                {
                    getEntry.Invoke(null, new object[] { i, entry });
                    string msg = msgField?.GetValue(entry)?.ToString() ?? "";
                    int mode = modeField != null ? (int)modeField.GetValue(entry) : 0;
                    string level = (mode & 1) != 0 ? "ERROR" : (mode & 256) != 0 ? "WARN" : "LOG";
                    sb.AppendLine($"[{i}][{level}] {msg.Replace("\n", " | ")}");
                }
                File.WriteAllText(Path.Combine(OUT_DIR, "03_console_logs.txt"), sb.ToString());
                Debug.Log($"[KTO Diag] Wrote {OUT_DIR}/03_console_logs.txt ({countAvail - from} entries)");
            }
            finally
            {
                endGetting.Invoke(null, null);
            }
        }

        [MenuItem("KTO Diag/4. Trigger Ui:OnMapLoaded (force HUD spawn)")]
        public static void TriggerOnMapLoaded()
        {
            EnsureDir();
            var sb = new StringBuilder();
            sb.AppendLine("=== TRIGGER Ui:OnMapLoaded ===");
            sb.AppendLine($"timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

            var luaEngineType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => { try { return a.GetTypes(); } catch { return Type.EmptyTypes; } })
                .FirstOrDefault(t => t.FullName == "ThanMaOrigin.Lua.LuaEngine");
            if (luaEngineType == null)
            {
                sb.AppendLine("LuaEngine NOT FOUND — must be in Play mode + LuaEngine init'd");
            }
            else
            {
                var instance = luaEngineType.GetProperty("Instance",
                    BindingFlags.Public | BindingFlags.Static).GetValue(null);
                var env = luaEngineType.GetProperty("Env").GetValue(instance);
                var doStr = env.GetType().GetMethod("DoString", new[] { typeof(string), typeof(string), typeof(Type) });

                try
                {
                    var probe = @"
                        local before_count = 0
                        local hud = CS.UnityEngine.GameObject.Find('HudRoot')
                        if hud then before_count = hud.transform.childCount end
                        local err = nil
                        local ok = pcall(function()
                            if EventNotify and EventNotify.OnNotify then
                                EventNotify.OnNotify(28, 1)  -- emNOTIFY_MAP_LOADED
                            else
                                err = 'EventNotify.OnNotify missing'
                            end
                        end)
                        local after_count = 0
                        if hud then after_count = hud.transform.childCount end
                        return string.format('before=%d after=%d ok=%s err=%s', before_count, after_count, tostring(ok), tostring(err))
                    ";
                    var result = doStr.Invoke(env, new object[] { probe, "trigger_onmap", typeof(string) });
                    if (result is object[] arr && arr.Length > 0)
                        sb.AppendLine($"Result: {arr[0]}");
                    else
                        sb.AppendLine($"Unknown result: {result}");
                }
                catch (Exception e)
                {
                    sb.AppendLine($"ERROR: {e.GetType().Name}: {e.Message}");
                    sb.AppendLine(e.StackTrace);
                }
            }
            File.WriteAllText(Path.Combine(OUT_DIR, "04_trigger_onmap.txt"), sb.ToString());
            Debug.Log($"[KTO Diag] Wrote {OUT_DIR}/04_trigger_onmap.txt");
        }

        [MenuItem("KTO Diag/5. Trace _UpdateMainUi step-by-step")]
        public static void TraceUpdateMainUi()
        {
            EnsureDir();
            var sb = new StringBuilder();
            sb.AppendLine("=== TRACE _UpdateMainUi step-by-step ===");
            sb.AppendLine($"timestamp: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

            var luaEngineType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => { try { return a.GetTypes(); } catch { return Type.EmptyTypes; } })
                .FirstOrDefault(t => t.FullName == "ThanMaOrigin.Lua.LuaEngine");
            if (luaEngineType == null)
            {
                sb.AppendLine("LuaEngine NOT FOUND — must be in Play mode");
                File.WriteAllText(Path.Combine(OUT_DIR, "05_trace_updatemain.txt"), sb.ToString());
                return;
            }
            var instance = luaEngineType.GetProperty("Instance",
                BindingFlags.Public | BindingFlags.Static).GetValue(null);
            var env = luaEngineType.GetProperty("Env").GetValue(instance);
            var doStr = env.GetType().GetMethod("DoString", new[] { typeof(string), typeof(string), typeof(Type) });

            try
            {
                var probe = @"
                    local trace = {}
                    local function log(s) table.insert(trace, s) end
                    local ok, err = pcall(function()
                        log('Ui exists: ' .. tostring(Ui ~= nil))
                        if not Ui then return end
                        log('Ui.HomeScreenState exists: ' .. tostring(Ui.HomeScreenState ~= nil))
                        log('Ui.nHomeScreenState: ' .. tostring(Ui.nHomeScreenState))
                        log('Ui.tbShowUiState: ' .. tostring(Ui.tbShowUiState))
                        log('Ui.bInDelayUpdateMain: ' .. tostring(Ui.bInDelayUpdateMain))
                        log('Ui.nUiState: ' .. tostring(Ui.nUiState))
                        log('Ui.nFightState: ' .. tostring(Ui.nFightState))
                        log('Ui.bHideStateWnd: ' .. tostring(Ui.bHideStateWnd))
                        log('Ui.tbHideStateUi: ' .. tostring(Ui.tbHideStateUi))
                        log('Client exists: ' .. tostring(Client ~= nil))
                        log('Client.UIModule exists: ' .. tostring(Client and Client.UIModule ~= nil))
                        log('Client.UIModule.PreloadUI exists: ' .. tostring(Client and Client.UIModule and Client.UIModule.PreloadUI ~= nil))
                        log('--- forcing Ui:UpdateMainUi(true) ---')
                        local ok2, err2 = pcall(Ui.UpdateMainUi, Ui, true)  -- forceInstant=true
                        log('UpdateMainUi result: ok=' .. tostring(ok2) .. ' err=' .. tostring(err2))
                        local hud = CS.UnityEngine.GameObject.Find('HudRoot')
                        if hud then
                            log('HudRoot.children after: ' .. tostring(hud.transform.childCount))
                        else
                            log('HudRoot: NOT FOUND')
                        end
                    end)
                    log('outer pcall: ok=' .. tostring(ok) .. ' err=' .. tostring(err))
                    return table.concat(trace, '\n')
                ";
                var result = doStr.Invoke(env, new object[] { probe, "trace_updatemain", typeof(string) });
                if (result is object[] arr && arr.Length > 0)
                {
                    sb.AppendLine("--- Lua trace ---");
                    sb.AppendLine(arr[0]?.ToString() ?? "(null)");
                }
            }
            catch (Exception e)
            {
                sb.AppendLine($"ERROR: {e.GetType().Name}: {e.Message}");
                sb.AppendLine(e.StackTrace);
            }

            File.WriteAllText(Path.Combine(OUT_DIR, "05_trace_updatemain.txt"), sb.ToString());
            Debug.Log($"[KTO Diag] Wrote {OUT_DIR}/05_trace_updatemain.txt");
        }
    }
}
