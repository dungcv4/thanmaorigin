// Diagnose why click on UISelectServer items doesn't work.
// Check: EventSystem, GraphicRaycaster, Canvas sortingOrder, Button listeners,
// any full-screen overlay above blocking input.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Linq;

public static class DiagUISelectServerClick
{
    public static void Execute()
    {
        Debug.Log("=== DiagUISelectServerClick START ===");

        // Find scene-instantiated UISelectServer (filter prefab assets)
        var roots = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => go.name.StartsWith("UISelectServer") && go.scene.IsValid() && !EditorUtility.IsPersistent(go))
            .ToArray();
        Debug.Log($"  Scene-side UISelectServer GOs: {roots.Length}");
        var root = roots.FirstOrDefault(go => go.transform.parent == null || go.transform.parent.GetComponent<Canvas>() != null) ?? roots.FirstOrDefault();
        if (root == null) { Debug.LogError("No scene UISelectServer found"); return; }
        Debug.Log($"  Using {GetPath(root.transform)} active={root.activeInHierarchy}");

        // (1) EventSystem
        var es = EventSystem.current;
        Debug.Log($"  EventSystem.current: {(es != null ? es.name + " enabled=" + es.enabled : "NULL")}");
        if (es != null)
        {
            var inputModule = es.currentInputModule;
            Debug.Log($"    currentInputModule: {(inputModule != null ? inputModule.GetType().Name + " enabled=" + inputModule.enabled : "NULL")}");
        }

        // (2) Canvas + GraphicRaycaster of UISelectServer
        var canvas = root.GetComponentInChildren<Canvas>(includeInactive: true);
        var gr = root.GetComponentInChildren<GraphicRaycaster>(includeInactive: true);
        Debug.Log($"  UISelectServer Canvas: {(canvas != null ? "name="+canvas.name+" sortingOrder="+canvas.sortingOrder+" enabled="+canvas.enabled : "NULL")}");
        Debug.Log($"  UISelectServer GraphicRaycaster: {(gr != null ? "enabled="+gr.enabled+" blockingObjects="+gr.blockingObjects : "NULL")}");

        // (3) All Canvases in scene + sortingOrder
        var allCanvases = Object.FindObjectsOfType<Canvas>().OrderByDescending(c => c.sortingOrder);
        Debug.Log("  All Canvases (sorted by order desc):");
        foreach (var c in allCanvases)
        {
            string raycaster = c.GetComponent<GraphicRaycaster>() != null ? "+GR" : "-GR";
            Debug.Log($"    {c.name} sortOrder={c.sortingOrder} enabled={c.enabled} {raycaster} renderMode={c.renderMode}");
        }

        // (4) Sample a server item button: find buttons under UISelectServer + check listener count
        var buttons = root.GetComponentsInChildren<Button>(includeInactive: false);
        Debug.Log($"  Found {buttons.Length} active Buttons under UISelectServer");
        foreach (var b in buttons.Take(8))
        {
            int persist = b.onClick.GetPersistentEventCount();
            // Reflect runtime listeners
            int runtime = 0;
            try
            {
                var fld = typeof(UnityEngine.Events.UnityEventBase).GetField("m_Calls", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                var calls = fld?.GetValue(b.onClick);
                var rcFld = calls?.GetType().GetField("m_RuntimeCalls", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                var rc = rcFld?.GetValue(calls) as System.Collections.IList;
                runtime = rc?.Count ?? -1;
            } catch {}
            string path = GetPath(b.transform);
            Debug.Log($"    Button {path}: interactable={b.interactable} persistent={persist} runtime={runtime}");
        }

        // (5) Check if anything raycast-blocks above UISelectServer (do a UI raycast at center of screen)
        if (es != null)
        {
            var ped = new PointerEventData(es) { position = new Vector2(Screen.width / 2, Screen.height / 2) };
            var results = new System.Collections.Generic.List<RaycastResult>();
            es.RaycastAll(ped, results);
            Debug.Log($"  RaycastAll at screen center ({Screen.width/2},{Screen.height/2}): {results.Count} hits");
            foreach (var r in results.Take(5))
                Debug.Log($"    HIT: {GetPath(r.gameObject.transform)} raycastTarget={r.gameObject.GetComponent<Graphic>()?.raycastTarget} layer={r.gameObject.layer}");
        }

        Debug.Log("=== END ===");
    }

    static string GetPath(Transform t)
    {
        var stack = new System.Collections.Generic.Stack<string>();
        while (t != null) { stack.Push(t.name); t = t.parent; }
        return string.Join("/", stack);
    }
}
