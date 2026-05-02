// Find the chain of Images blocking raycast on UISelectServer Buttons.
// Identify which Image needs raycastTarget=false.
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;

public static class DiagBlockingImageChain
{
    public static void Execute()
    {
        Debug.Log("=== DiagBlockingImageChain START ===");
        var roots = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => go.name == "UISelectServer" && go.scene.IsValid() && !EditorUtility.IsPersistent(go))
            .ToArray();
        if (roots.Length == 0) { Debug.LogError("UISelectServer not in scene"); return; }
        var root = roots[0];

        var es = EventSystem.current;
        if (es == null) { Debug.LogError("EventSystem null"); return; }

        // Pick a server-list item to test
        var item = root.transform.Find("node/imgBG/Content/PanelServerList/MaskView/List/Element1");
        if (item == null) { Debug.LogError("Element1 not found"); return; }
        var rt = item as RectTransform;
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);
        Vector3 worldCenter = (corners[0] + corners[2]) * 0.5f;

        Debug.Log($"  Testing Element1 at worldCenter={worldCenter}");
        var ped = new PointerEventData(es) { position = worldCenter };
        var results = new List<RaycastResult>();
        es.RaycastAll(ped, results);

        Debug.Log($"  Total hits: {results.Count}");
        for (int i = 0; i < results.Count; i++)
        {
            var hit = results[i];
            var img = hit.gameObject.GetComponent<Image>();
            string raycastTarget = img != null ? $"raycastTarget={img.raycastTarget}" : "(no Image)";
            Debug.Log($"    HIT[{i}] depth={hit.depth} sortingOrder={hit.sortingOrder} {GetPath(hit.gameObject.transform)} | {raycastTarget}");
        }

        // Walk parent chain of Element1 — list every Image with raycastTarget=true
        Debug.Log("  Parent chain Images with raycastTarget=true:");
        Transform t = item;
        while (t != null && t != root.transform.parent)
        {
            var img = t.GetComponent<Image>();
            if (img != null && img.raycastTarget)
            {
                Debug.Log($"    BLOCKER: {GetPath(t)} (Image raycastTarget=true sprite={(img.sprite != null ? img.sprite.name : "null")} alpha={img.color.a:F2})");
            }
            t = t.parent;
        }

        Debug.Log("=== END ===");
    }

    static string GetPath(Transform t)
    {
        var stack = new Stack<string>();
        while (t != null) { stack.Push(t.name); t = t.parent; }
        return string.Join("/", stack);
    }
}
