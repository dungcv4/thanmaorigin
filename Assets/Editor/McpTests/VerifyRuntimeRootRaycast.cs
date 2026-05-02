// Verify runtime UISelectServer root Image raycastTarget value.
// If still =true at runtime, Play loaded old bundle (cached) → user needs to
// Stop+Start Play to reload.

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;

public static class VerifyRuntimeRootRaycast
{
    public static void Execute()
    {
        Debug.Log("=== VerifyRuntimeRootRaycast START ===");
        var roots = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => go.name == "UISelectServer" && go.scene.IsValid() && !EditorUtility.IsPersistent(go))
            .ToArray();
        if (roots.Length == 0) { Debug.LogError("No scene UISelectServer (popup closed?)"); return; }
        var root = roots[0];
        var img = root.GetComponent<Image>();
        if (img == null) { Debug.LogError("No Image on root"); return; }
        Debug.Log($"  Runtime root Image: sprite={(img.sprite!=null?img.sprite.name:"NULL")} color={img.color} raycastTarget={img.raycastTarget}");
        if (img.raycastTarget) Debug.LogWarning("  ⚠️ raycastTarget STILL true → Play loaded OLD bundle. Stop+Start Play.");
        else Debug.Log("  ✅ raycastTarget=false → fix loaded correctly. Click should work now.");
        Debug.Log("=== END ===");
    }
}
