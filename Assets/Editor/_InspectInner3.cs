using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public static class _InspectInner3
{
    public static void Execute()
    {
        Debug.Log("[INNER3] BEGIN");
        // Iterate ALL GOs named UILoginChannelInner across all scenes
        var all = Resources.FindObjectsOfTypeAll<GameObject>();
        var inners = all.Where(g => g != null && g.name == "UILoginChannelInner").ToArray();
        Debug.Log($"[INNER3] found {inners.Length} GOs named UILoginChannelInner");
        foreach (var inner in inners)
        {
            Debug.Log($"[INNER3] === instance ===");
            Debug.Log($"[INNER3]   scene='{inner.scene.name}' isValid={inner.scene.IsValid()} loaded={inner.scene.isLoaded}");
            Debug.Log($"[INNER3]   activeSelf={inner.activeSelf} activeInHierarchy={inner.activeInHierarchy}");
            Debug.Log($"[INNER3]   layer={inner.layer} hideFlags={inner.hideFlags}");
            // Components
            var comps = inner.GetComponents<Component>();
            Debug.Log($"[INNER3]   components ({comps.Length}):");
            foreach (var c in comps)
                Debug.Log($"[INNER3]     - {(c == null ? "<missing/null>" : c.GetType().FullName)}");
            // Parent
            if (inner.transform.parent != null)
                Debug.Log($"[INNER3]   parent={inner.transform.parent.name}");
            else
                Debug.Log($"[INNER3]   parent=null (root of scene)");
        }
        Debug.Log("[INNER3] END");
    }
}
