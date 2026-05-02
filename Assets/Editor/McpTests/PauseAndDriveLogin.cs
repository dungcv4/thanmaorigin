using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Collections.Generic;

public static class PauseAndDriveLogin
{
    public static void Execute()
    {
        // Click "Đăng nhập" to login again
        Button loginBtn = null;
        foreach (var btn in Object.FindObjectsOfType<Button>(true))
        {
            if (!btn.gameObject.activeInHierarchy) continue;
            var t = btn.GetComponentInChildren<Text>(true);
            if (t != null && (t.text.Contains("Đăng nhập") || t.text.Contains("Login")))
            {
                loginBtn = btn;
                break;
            }
        }
        if (loginBtn == null) { Debug.Log("[PD] no login button found"); return; }
        Debug.Log("[PD] clicking login: " + GetPath(loginBtn.transform));
        ExecuteEvents.Execute(loginBtn.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
