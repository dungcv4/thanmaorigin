// One-shot probe: check Lua globals state after preload.
// Run via MCP execute_script.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

public static class KtoProbeGlobals
{
    public static void Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"=== KtoProbeGlobals @ {DateTime.Now:HH:mm:ss} ===");

        var luaEngineType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => { try { return a.GetTypes(); } catch { return Type.EmptyTypes; } })
            .FirstOrDefault(t => t.FullName == "ThanMaOrigin.Lua.LuaEngine");
        if (luaEngineType == null) { sb.AppendLine("LuaEngine type NOT FOUND"); WriteOut(sb); return; }

        // Try Object.FindObjectOfType (works for MonoBehaviour even in DontDestroyOnLoad)
        UnityEngine.Object instance = null;
        try
        {
            var findMethod = typeof(UnityEngine.Object).GetMethod("FindObjectOfType",
                BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(Type) }, null);
            if (findMethod != null)
                instance = (UnityEngine.Object)findMethod.Invoke(null, new object[] { luaEngineType });
        }
        catch (Exception e) { sb.AppendLine($"FindObjectOfType err: {e.Message}"); }

        if (instance == null)
        {
            // Fallback to static Instance property
            var prop = luaEngineType.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
            instance = (UnityEngine.Object)prop?.GetValue(null);
        }
        if (instance == null) { sb.AppendLine("Instance NULL (both Find + static prop)"); WriteOut(sb); return; }
        sb.AppendLine($"Instance found via: {instance.GetType().FullName}");

        var env = luaEngineType.GetProperty("Env").GetValue(instance);
        if (env == null) { sb.AppendLine("Env NULL"); WriteOut(sb); return; }

        var doStr = env.GetType().GetMethod("DoString", new[] { typeof(string), typeof(string), typeof(Type) });

        try
        {
            var probe = @"
                local r = {}
                r.Client_exists = (Client ~= nil) and 'YES' or 'NO'
                r.Sdk_exists = (Sdk ~= nil) and 'YES' or 'NO'
                r.Login_exists = (Login ~= nil) and 'YES' or 'NO'
                r.EventNotify_exists = (EventNotify ~= nil) and 'YES' or 'NO'
                r.Operation_exists = (Operation ~= nil) and 'YES' or 'NO'
                r.Timer_exists = (Timer ~= nil) and 'YES' or 'NO'
                r.Item_exists = (Item ~= nil) and 'YES' or 'NO'
                r.Ui_exists = (Ui ~= nil) and 'YES' or 'NO'
                r.Player_exists = (Player ~= nil) and 'YES' or 'NO'
                r.tbGlobalTable_exists = (tbGlobalTable ~= nil) and 'YES' or 'NO'
                r.tbPreGlobalTable_exists = (tbPreGlobalTable ~= nil) and 'YES' or 'NO'
                if tbGlobalTable then
                    r.tbGlobalTable_Sdk = (tbGlobalTable.Sdk ~= nil) and 'YES' or 'NO'
                    local n = 0
                    for _ in pairs(tbGlobalTable) do n = n + 1 end
                    r.tbGlobalTable_count = tostring(n)
                end
                r.Require_exists = (Require ~= nil) and 'YES' or 'NO'
                r.luanet_import_type_exists = (luanet and luanet.import_type) and 'YES' or 'NO'
                r.RegisterTimerPoint_exists = (RegisterTimerPoint ~= nil) and 'YES' or 'NO'
                r.bIsLoad_set = tostring(bIsLoad)
                if Sdk then
                    r.Sdk_SetReferenceResolution = (Sdk.SetReferenceResolution ~= nil) and 'YES' or 'NO'
                    local sn = 0
                    for _ in pairs(Sdk) do sn = sn + 1 end
                    r.Sdk_keys = tostring(sn)
                end
                local out = ''
                local keys = {}
                for k, _ in pairs(r) do table.insert(keys, k) end
                table.sort(keys)
                for _, k in ipairs(keys) do out = out .. k .. '=' .. tostring(r[k]) .. '\n' end
                return out
            ";
            var result = doStr.Invoke(env, new object[] { probe, "probe_globals", typeof(string) });
            if (result is object[] arr && arr.Length > 0)
                sb.AppendLine(arr[0]?.ToString() ?? "(null)");
            else
                sb.AppendLine($"DoString returned: {result?.GetType().Name}");
        }
        catch (Exception e)
        {
            sb.AppendLine($"ERROR: {e.GetType().Name}: {e.Message}");
        }

        WriteOut(sb);
    }

    static void WriteOut(StringBuilder sb)
    {
        Directory.CreateDirectory("/tmp/kto_diag");
        File.WriteAllText("/tmp/kto_diag/probe_globals.txt", sb.ToString());
        Debug.Log($"[KtoProbeGlobals] Wrote /tmp/kto_diag/probe_globals.txt\n{sb}");
    }
}
