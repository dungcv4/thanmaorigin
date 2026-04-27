using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public static class _InspectInner2
{
    public static void Execute()
    {
        Debug.Log("[INNER2] BEGIN");
        // Find by all (incl inactive)
        var all = Resources.FindObjectsOfTypeAll<GameObject>();
        var inner = all.FirstOrDefault(g => g != null && g.name == "UILoginChannelInner" && g.scene.IsValid());
        if (inner == null) { Debug.LogError("[INNER2] not found"); return; }
        // Walk parent chain
        var t = inner.transform;
        while (t != null)
        {
            Debug.Log($"[INNER2] tree: {t.name} active={t.gameObject.activeSelf} activeInHierarchy={t.gameObject.activeInHierarchy}");
            t = t.parent;
        }
        // Check own components
        Debug.Log($"[INNER2] inner components:");
        foreach (var c in inner.GetComponents<Component>())
            Debug.Log($"   - {(c == null ? "<missing>" : c.GetType().FullName)} (enabled={(c is Behaviour b ? b.enabled.ToString() : "n/a")})");
        Debug.Log("[INNER2] END");
    }
}
