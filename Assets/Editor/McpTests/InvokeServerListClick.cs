// Directly invoke onClick on a server-list Element to bypass raycast.
// If invoke works → click handler is OK, raycast/blocker is the only issue.
// If invoke fails too → handler bind itself is broken.

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;

public static class InvokeServerListClick
{
    public static void Execute()
    {
        Debug.Log("=== InvokeServerListClick START ===");
        var roots = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => go.name == "UISelectServer" && go.scene.IsValid() && !EditorUtility.IsPersistent(go))
            .ToArray();
        if (roots.Length == 0) { Debug.LogError("UISelectServer not in scene"); return; }
        var root = roots[0];

        // Try invoking each Button's onClick
        var buttons = root.GetComponentsInChildren<Button>(includeInactive: false);
        foreach (var b in buttons)
        {
            string path = GetPath(b.transform);
            Debug.Log($"  → Invoking onClick on {path}");
            try
            {
                b.onClick.Invoke();
                Debug.Log($"     OK invoked");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"     FAILED: {e.Message}");
            }
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
