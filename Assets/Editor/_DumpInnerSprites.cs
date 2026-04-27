using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public static class _DumpInnerSprites
{
    public static void Execute()
    {
        Debug.Log("[DIS] BEGIN");
        var all = Resources.FindObjectsOfTypeAll<GameObject>();
        var inner = all.FirstOrDefault(g => g != null && g.name == "UILoginChannelInner" && g.scene.IsValid());
        if (inner == null) { Debug.LogError("[DIS] not found"); return; }
        var imgs = inner.GetComponentsInChildren<Image>(true);
        Debug.Log($"[DIS] Total Images: {imgs.Length}");
        // Group: with sprite vs without
        int withS = 0, woS = 0;
        for (int i = 0; i < imgs.Length; i++)
        {
            var img = imgs[i];
            if (img.sprite != null)
            {
                withS++;
                Debug.Log($"[DIS] WITH  [{i}] go={img.gameObject.name} sprite={img.sprite.name}");
            }
            else
            {
                woS++;
                Debug.Log($"[DIS] WITHOUT [{i}] go={img.gameObject.name} (no sprite)");
            }
        }
        Debug.Log($"[DIS] Summary: {withS} with sprite, {woS} without");
        Debug.Log("[DIS] END");
    }
}
