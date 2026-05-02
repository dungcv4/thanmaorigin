// Diag UICreateRole — find character avatar GO, check Canvas/Image/Animator state.
// Compare against gốc UICreateRole.prefab to find what's missing or wrong.

using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;

public static class DiagCreateRoleCharacter
{
    public static void Execute()
    {
        Debug.Log("=== DiagCreateRoleCharacter START ===");

        // (1) Find all Character-like GOs across scene
        var allGos = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(go => go.scene.IsValid() && !EditorUtility.IsPersistent(go))
            .Where(go => {
                var n = go.name.ToLower();
                return n.Contains("character") || n.Contains("avatar") || n.Contains("faction") ||
                       n.StartsWith("m_") || n.StartsWith("f_") || n.Contains("cuiyan");
            })
            .ToArray();

        Debug.Log($"  Character-like GOs in scene: {allGos.Length}");
        foreach (var go in allGos.Take(40))
        {
            string path = GetPath(go.transform);
            var img = go.GetComponent<Image>();
            var sr = go.GetComponent<SpriteRenderer>();
            var anim = go.GetComponent<Animator>();
            var canvas = go.GetComponent<Canvas>();
            string info = $"active={go.activeInHierarchy}";
            if (img != null) info += $" Image(rt={img.raycastTarget},sprite={(img.sprite != null ? img.sprite.name : "NULL")},a={img.color.a:F2})";
            if (sr != null) info += $" SR(sprite={(sr.sprite != null ? sr.sprite.name : "NULL")},a={sr.color.a:F2})";
            if (anim != null) info += $" Animator(controller={(anim.runtimeAnimatorController != null ? anim.runtimeAnimatorController.name : "NULL")})";
            if (canvas != null) info += $" Canvas(enabled={canvas.enabled},override={canvas.overrideSorting},so={canvas.sortingOrder})";
            Debug.Log($"    {path}: {info}");
        }

        // (2) Inspect FactionInfo subtree under UICreateRole
        var ucr = Resources.FindObjectsOfTypeAll<GameObject>()
            .FirstOrDefault(go => go.name == "UICreateRole" && go.scene.IsValid() && !EditorUtility.IsPersistent(go));
        if (ucr != null)
        {
            Debug.Log("  UICreateRole/imgBG/FactionInfo subtree:");
            DumpRecursive(ucr.transform.Find("imgBG/FactionInfo"), 0, 4);
        }
        Debug.Log("=== END ===");
    }

    static void DumpRecursive(Transform t, int depth, int maxDepth)
    {
        if (t == null || depth > maxDepth) return;
        var indent = new string(' ', (depth + 2) * 2);
        var img = t.GetComponent<Image>();
        var anim = t.GetComponent<Animator>();
        var canvas = t.GetComponent<Canvas>();
        string info = "";
        if (img != null) info += $" img={(img.sprite != null ? img.sprite.name : "NULL")}/a{img.color.a:F1}";
        if (anim != null) info += $" anim={(anim.runtimeAnimatorController != null ? "Y" : "N")}";
        if (canvas != null) info += $" Canvas(o={canvas.overrideSorting},so={canvas.sortingOrder})";
        Debug.Log($"{indent}{t.name} (active={t.gameObject.activeSelf}){info}");
        foreach (Transform c in t) DumpRecursive(c, depth + 1, maxDepth);
    }

    static string GetPath(Transform t)
    {
        var stack = new Stack<string>();
        while (t != null) { stack.Push(t.name); t = t.parent; }
        return string.Join("/", stack);
    }
}
