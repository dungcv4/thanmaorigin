using UnityEngine;
using UnityEngine.UI;
using Game.UI;
using System.Linq;

public static class _TestClickPostCleanup
{
    public static void Execute()
    {
        Debug.Log("=== [PostCleanupTest] BEGIN ===");
        var all = Resources.FindObjectsOfTypeAll<GameObject>();
        var inner = all.FirstOrDefault(g => g != null && g.name == "UILoginChannelInner" && g.scene.IsValid());
        if (inner == null) { Debug.LogError("[PostCleanupTest] UILoginChannelInner not found"); return; }
        var btn = inner.GetComponentsInChildren<Button>(true).FirstOrDefault(b => b.gameObject.name == "btnEnterGame");
        if (btn == null) { Debug.LogError("[PostCleanupTest] btnEnterGame not found"); return; }
        Debug.Log($"[PostCleanupTest] Invoking btnEnterGame click...");
        btn.onClick.Invoke();
        Debug.Log("=== [PostCleanupTest] END ===");
    }
}
