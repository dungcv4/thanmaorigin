using UnityEditor;
using UnityEngine;

public static class _Diag_LuaResources
{
    public static void Execute()
    {
        // Test: can Resources.Load find Script_Client.lua?
        var ta1 = Resources.Load<TextAsset>("Lua/commonui/Script_Client.lua");
        Debug.Log($"[Diag] Lua/commonui/Script_Client.lua: {(ta1 == null ? "NULL" : $"OK len={ta1.bytes.Length}")}");

        var ta2 = Resources.Load<TextAsset>("Lua/commonui/Script_Client");
        Debug.Log($"[Diag] Lua/commonui/Script_Client: {(ta2 == null ? "NULL" : $"OK len={ta2.bytes.Length}")}");

        // Test loading all
        var all = Resources.LoadAll<TextAsset>("Lua");
        Debug.Log($"[Diag] LoadAll Lua: {all.Length} TextAssets");
        if (all.Length > 0)
        {
            int withClient = 0;
            foreach (var ta in all)
            {
                if (ta.name.Contains("Script_Client")) withClient++;
            }
            Debug.Log($"[Diag] Names containing 'Script_Client': {withClient}");
        }
    }
}
