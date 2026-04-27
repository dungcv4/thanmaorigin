using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public static class _ForceInnerActive
{
    public static void Execute()
    {
        var all = Resources.FindObjectsOfTypeAll<GameObject>();
        var inner = all.FirstOrDefault(g => g != null && g.name == "UILoginChannelInner" && g.scene.IsValid());
        if (inner == null) { Debug.LogError("[FORCE] not found"); return; }
        inner.SetActive(true);
        Debug.Log($"[FORCE] set active=true. activeSelf={inner.activeSelf} activeInHierarchy={inner.activeInHierarchy}");
        // Also count Images
        var imgs = inner.GetComponentsInChildren<Image>(true);
        var withSprite = imgs.Count(i => i != null && i.sprite != null);
        Debug.Log($"[FORCE] Images total={imgs.Length} withSprite={withSprite}");
    }
}
