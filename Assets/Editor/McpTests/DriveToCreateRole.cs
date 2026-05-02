using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Collections.Generic;

public static class DriveToCreateRole
{
    public static void Execute()
    {
        // Find Login button. Most likely UILoginInner or UILoginChannelInner with "Đăng nhập" button.
        Debug.Log("[Drive] Looking for login UI...");
        foreach (var btn in Object.FindObjectsOfType<Button>(true))
        {
            if (!btn.gameObject.activeInHierarchy) continue;
            string p = GetPath(btn.transform);
            string txt = "";
            var t = btn.GetComponentInChildren<Text>(true);
            if (t != null) txt = t.text;
            Debug.Log("[Drive] Btn: " + p + " text='" + txt + "'");
        }
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
