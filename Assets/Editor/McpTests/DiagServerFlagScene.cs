// DEBUG 2026-05-02 — check actual scene-instantiated ServerFlag* state + parent chain.
// Filter out prefab assets that always report activeInHierarchy=false.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Linq;

public static class DiagServerFlagScene
{
    public static void Execute()
    {
        Debug.Log("=== DiagServerFlagScene START ===");
        // Find scene-only ServerFlag (filter prefab assets)
        var all = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => go.name.StartsWith("ServerFlag") && !go.name.Contains("(Clone)"))
            .Where(go => go.scene.IsValid() && !EditorUtility.IsPersistent(go))
            .ToArray();
        Debug.Log($"  Scene-only ServerFlag* found: {all.Length}");
        foreach (var go in all)
        {
            // Walk parent chain
            string chain = "";
            for (var t = go.transform; t != null; t = t.parent)
            {
                chain = t.name + (string.IsNullOrEmpty(chain) ? "" : " > " + chain);
                chain += $"(self={t.gameObject.activeSelf})";
            }
            var img = go.GetComponent<Image>();
            Debug.Log($"  {chain}");
            Debug.Log($"    activeInHierarchy={go.activeInHierarchy} activeSelf={go.activeSelf} scene={go.scene.name}");
            if (img != null)
                Debug.Log($"    Image: sprite={(img.sprite != null ? img.sprite.name : "NULL")} color.a={img.color.a:F2}");
        }
        Debug.Log("=== DiagServerFlagScene END ===");
    }
}
