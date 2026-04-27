using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public static class _TestUIHudDeep
{
    public static void Execute()
    {
        Debug.Log("[HUD_DEEP] BEGIN");
        const string path = "Assets/game/ui/views/UIHud.prefab";

        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceSynchronousImport | ImportAssetOptions.ForceUpdate);
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
        if (prefab == null)
        {
            Debug.Log("[HUD_DEEP] NULL"); return;
        }

        // Walk all components, count by type name
        var byType = new Dictionary<string, int>();
        var allMBs = prefab.GetComponentsInChildren<MonoBehaviour>(true);
        foreach (var mb in allMBs)
        {
            string typeName = mb == null ? "(null/missing)" : mb.GetType().FullName;
            byType[typeName] = byType.ContainsKey(typeName) ? byType[typeName] + 1 : 1;
        }

        // Sort by count desc
        var sorted = new List<KeyValuePair<string, int>>(byType);
        sorted.Sort((a, b) => b.Value.CompareTo(a.Value));

        Debug.Log($"[HUD_DEEP] Total MonoBehaviours: {allMBs.Length}");
        Debug.Log($"[HUD_DEEP] Unique types: {byType.Count}");
        for (int i = 0; i < System.Math.Min(15, sorted.Count); i++)
        {
            Debug.Log($"[HUD_DEEP]   {sorted[i].Value,4}  {sorted[i].Key}");
        }
        Debug.Log("[HUD_DEEP] END");
    }
}
