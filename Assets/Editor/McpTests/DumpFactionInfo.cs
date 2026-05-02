using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class DumpFactionInfo
{
    public static void Execute()
    {
        var fi = GameObject.Find("UICreateRole/imgBG/FactionInfo");
        if (fi == null) { Debug.Log("[FI] not found"); return; }
        Debug.Log("[FI] FactionInfo descendants (active+enabled, all types):");
        foreach (var t in fi.GetComponentsInChildren<Transform>(true))
        {
            string p = GetPath(t);
            // skip self
            string components = "";
            foreach (var c in t.GetComponents<Component>())
            {
                if (c == null) continue;
                components += c.GetType().Name + ",";
            }
            var rt = t as RectTransform;
            string rect = rt != null ? "sd=" + rt.sizeDelta + " ap=" + rt.anchoredPosition : "";
            bool active = t.gameObject.activeInHierarchy;
            Debug.Log("[FI] " + p + " active=" + active + " | comps=[" + components + "] | " + rect);
        }
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
