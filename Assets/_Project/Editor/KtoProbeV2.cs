// V2: more defensive probe — finds LuaEngine reliably + handles null Env.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

public static class KtoProbeV2
{
    public static void Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"=== KtoProbeV2 @ {DateTime.Now:HH:mm:ss} (playMode={EditorApplication.isPlaying}) ===");

        // Find LuaEngine type
        Type leType = null;
        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            try
            {
                var t = asm.GetType("ThanMaOrigin.Lua.LuaEngine");
                if (t != null) { leType = t; sb.AppendLine($"Type found in {asm.GetName().Name}"); break; }
            }
            catch { }
        }
        if (leType == null) { sb.AppendLine("LuaEngine type NOT FOUND"); WriteOut(sb); return; }

        // FindObjectsOfType including inactive
        var findAll = typeof(UnityEngine.Object).GetMethod("FindObjectsOfType",
            BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(Type), typeof(bool) }, null);
        var allRaw = (Array)findAll.Invoke(null, new object[] { leType, true });
        sb.AppendLine($"FindObjectsOfType count: {allRaw.Length}");

        UnityEngine.Object inst = null;
        foreach (UnityEngine.Object o in allRaw)
        {
            if (o == null) continue;
            sb.AppendLine($"  [{o.name}] hash={o.GetHashCode()}");
            if (inst == null) inst = o;
        }

        if (inst == null) { sb.AppendLine("No instance"); WriteOut(sb); return; }

        // Check Env via reflection
        var envProp = leType.GetProperty("Env");
        var envField = leType.GetField("<Env>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
        var env = envProp?.GetValue(inst);
        sb.AppendLine($"Env property: {(env == null ? "NULL" : env.GetType().FullName)}");
        if (envField != null)
        {
            var envFieldVal = envField.GetValue(inst);
            sb.AppendLine($"Env backing field: {(envFieldVal == null ? "NULL" : "set")}");
        }

        // Check static Instance
        var instProp = leType.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
        var staticInst = instProp?.GetValue(null);
        sb.AppendLine($"static Instance: {(staticInst == null ? "NULL" : "set")}");
        sb.AppendLine($"static==findobj: {(ReferenceEquals(staticInst, inst) ? "YES" : "NO")}");

        // If env exists, probe Lua state
        if (env != null)
        {
            var doStr = env.GetType().GetMethod("DoString", new[] { typeof(string), typeof(string), typeof(Type) });
            if (doStr == null)
                sb.AppendLine("DoString method NOT FOUND on Env");
            else
            {
                try
                {
                    var probe = "return tostring(Sdk) .. ',' .. tostring(Sdk and Sdk.SetReferenceResolution) .. ',' .. tostring(tbGlobalTable) .. ',' .. tostring(tbGlobalTable and tbGlobalTable.Sdk)";
                    var result = doStr.Invoke(env, new object[] { probe, "probe", typeof(string) });
                    if (result is object[] arr && arr.Length > 0)
                        sb.AppendLine($"Lua state: {arr[0]}");
                }
                catch (Exception e) { sb.AppendLine($"Lua probe ERR: {e.Message}"); }
            }
        }

        WriteOut(sb);
    }

    static void WriteOut(StringBuilder sb)
    {
        Directory.CreateDirectory("/tmp/kto_diag");
        File.WriteAllText("/tmp/kto_diag/probe_v2.txt", sb.ToString());
        Debug.Log($"[KtoProbeV2]\n{sb}");
    }
}
