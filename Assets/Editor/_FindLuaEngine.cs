using UnityEditor;
using UnityEngine;
using System.Linq;

public static class _FindLuaEngine
{
    public static void Execute()
    {
        Debug.Log("[FIND_LUA] BEGIN");
        Debug.Log($"[FIND_LUA] isPlaying={Application.isPlaying}");
        // Find any MonoBehaviour with type name LuaEngine
        var all = Resources.FindObjectsOfTypeAll<MonoBehaviour>();
        var matches = all.Where(c => c != null && c.GetType().Name == "LuaEngine").ToArray();
        Debug.Log($"[FIND_LUA] Found {matches.Length} MonoBehaviour with name 'LuaEngine'");
        foreach (var m in matches)
        {
            Debug.Log($"[FIND_LUA]   {m.GetType().FullName}  go={m.gameObject.name} active={m.gameObject.activeSelf}");
        }
        Debug.Log("[FIND_LUA] END");
    }
}
