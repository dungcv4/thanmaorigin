// Cast raycast at the WORLD position of each Button to see if EventSystem can hit them.
// If 0 hits where button visually is → button isn't getting input despite having listener.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Linq;

public static class DiagUISelectServerRaycastAtButtons
{
    public static void Execute()
    {
        Debug.Log("=== DiagUISelectServerRaycastAtButtons START ===");
        var roots = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => go.name == "UISelectServer" && go.scene.IsValid() && !EditorUtility.IsPersistent(go))
            .ToArray();
        if (roots.Length == 0) { Debug.LogError("UISelectServer not in scene"); return; }
        var root = roots[0];

        var buttons = root.GetComponentsInChildren<Button>(includeInactive: false);
        Debug.Log($"  Total Buttons: {buttons.Length}");
        Debug.Log($"  Screen: {Screen.width}x{Screen.height}");

        var es = EventSystem.current;
        if (es == null) { Debug.LogError("EventSystem null"); return; }

        // Find the popup's Canvas to know if it's overlay or camera mode
        var canvas = root.GetComponentInChildren<Canvas>();
        Debug.Log($"  Canvas renderMode={canvas.renderMode} worldCamera={(canvas.worldCamera != null ? canvas.worldCamera.name : "null")} pixelRect={canvas.pixelRect}");
        var scaler = canvas.GetComponent<CanvasScaler>();
        if (scaler != null)
        {
            Debug.Log($"  CanvasScaler uiScaleMode={scaler.uiScaleMode} referenceResolution={scaler.referenceResolution} matchWidthOrHeight={scaler.matchWidthOrHeight}");
        }

        foreach (var b in buttons)
        {
            var rt = b.transform as RectTransform;
            // Get world corners
            Vector3[] corners = new Vector3[4];
            rt.GetWorldCorners(corners);
            Vector3 worldCenter = (corners[0] + corners[2]) * 0.5f;

            // Convert to screen position
            Vector2 screenPos;
            if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
                screenPos = worldCenter;  // overlay = world is screen
            else
                screenPos = canvas.worldCamera != null ? canvas.worldCamera.WorldToScreenPoint(worldCenter) : worldCenter;

            // RaycastAll at this screen position
            var ped = new PointerEventData(es) { position = screenPos };
            var results = new System.Collections.Generic.List<RaycastResult>();
            es.RaycastAll(ped, results);

            string topHit = results.Count > 0 ? GetPath(results[0].gameObject.transform) : "NONE";
            Debug.Log($"  Btn '{b.name}' worldCenter={worldCenter} screenPos={screenPos} hits={results.Count} TOP={topHit}");
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
