using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public static class _InspectInner
{
    public static void Execute()
    {
        var go = GameObject.Find("UILoginChannelInner");
        if (go == null) { Debug.LogError("[INNER] not found in scene"); return; }
        Debug.Log($"[INNER] go={go.name} active={go.activeInHierarchy} layer={go.layer}");
        var rt = go.GetComponent<RectTransform>();
        if (rt) Debug.Log($"[INNER] rt anchorMin={rt.anchorMin} anchorMax={rt.anchorMax} sizeDelta={rt.sizeDelta} anchoredPos={rt.anchoredPosition} pivot={rt.pivot} localScale={rt.localScale}");
        var canvas = go.GetComponentInParent<Canvas>();
        Debug.Log($"[INNER] parent canvas={(canvas == null ? "NULL" : canvas.name)}");
        var ownCanvas = go.GetComponent<Canvas>();
        Debug.Log($"[INNER] own canvas={(ownCanvas == null ? "NULL" : "enabled="+ownCanvas.enabled+" sortOrder="+ownCanvas.sortingOrder)}");
        var imgs = go.GetComponentsInChildren<Image>(true);
        var withSprite = imgs.Count(i => i != null && i.sprite != null);
        Debug.Log($"[INNER] Images: total={imgs.Length} withSprite={withSprite}");
        for (int i = 0; i < System.Math.Min(5, imgs.Length); i++)
        {
            var img = imgs[i];
            Debug.Log($"[INNER]  [Image {i}] go={img.gameObject.name} active={img.gameObject.activeInHierarchy} sprite={(img.sprite==null?"NULL":img.sprite.name)} color={img.color} enabled={img.enabled}");
        }
    }
}
