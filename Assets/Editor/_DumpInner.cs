using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public static class _DumpInner
{
    public static void Execute()
    {
        Debug.Log("[DI] BEGIN");
        var all = Resources.FindObjectsOfTypeAll<GameObject>();
        var inner = all.FirstOrDefault(g => g != null && g.name == "UILoginChannelInner" && g.scene.IsValid());
        if (inner == null) { Debug.LogError("[DI] not found"); return; }
        var imgs = inner.GetComponentsInChildren<Image>(true);
        var btns = inner.GetComponentsInChildren<Button>(true);
        var togs = inner.GetComponentsInChildren<Toggle>(true);
        var inputs = inner.GetComponentsInChildren<InputField>(true);
        var canvases = inner.GetComponentsInChildren<Canvas>(true);
        Debug.Log($"[DI] Images={imgs.Length}, Buttons={btns.Length}, Toggles={togs.Length}, Inputs={inputs.Length}, Canvas={canvases.Length}");
        // List button gameobject names
        for (int i = 0; i < btns.Length; i++)
            Debug.Log($"[DI]  btn[{i}] {btns[i].gameObject.name}");
        for (int i = 0; i < togs.Length; i++)
            Debug.Log($"[DI]  tog[{i}] {togs[i].gameObject.name}");
        // Sprite usage
        int withSprite = imgs.Count(i => i.sprite != null);
        Debug.Log($"[DI] Images with sprite: {withSprite}/{imgs.Length}");
        Debug.Log("[DI] END");
    }
}
