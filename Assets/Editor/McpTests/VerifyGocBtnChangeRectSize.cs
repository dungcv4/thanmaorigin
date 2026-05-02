// Verify gốc btnChange/Image RectTransform sizeDelta + anchor + position.
// Compare with current to find why arrow renders too large.

using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

public static class VerifyGocBtnChangeRectSize
{
    public static void Execute()
    {
        Debug.Log("=== VerifyGocBtnChangeRectSize START ===");

        // (1) Read gốc YAML — find btnChange/Image GO id (we know fileID 67402857929426285),
        // then find its RectTransform (!u!224) component.
        string gocPath = "/Users/vsf-user-l/Documents/Test/alo/KTO_FullExtract/Assets_YAML/ui/views/res_p_137/UILoginServer.prefab";
        string content = File.ReadAllText(gocPath);
        var lines = content.Split('\n');

        // Find !u!224 RectTransform whose m_GameObject = 67402857929426285 (Image GO)
        int rtStart = -1;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("m_GameObject: {fileID: 67402857929426285}") &&
                i > 0 && lines[i-3].Contains("!u!224"))
            {
                rtStart = i - 3;
                break;
            }
        }
        if (rtStart < 0) { Debug.LogError("RectTransform for Image GO not found in gốc"); return; }

        Debug.Log($"  GỐC RectTransform block (line {rtStart+1}):");
        for (int i = rtStart; i < System.Math.Min(lines.Length, rtStart + 30); i++)
        {
            string s = lines[i].TrimEnd('\r');
            if (s.Contains("m_AnchorMin") || s.Contains("m_AnchorMax") || s.Contains("m_AnchoredPosition") ||
                s.Contains("m_SizeDelta") || s.Contains("m_Pivot") || s.Contains("m_LocalPosition") ||
                s.Contains("m_LocalRotation") || s.Contains("m_LocalScale") || s.Contains("m_LocalEulerAnglesHint"))
                Debug.Log($"    {s}");
        }

        // (2) Current prefab via API
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/game/ui/views/UILoginServer.prefab");
        var t = prefab.transform.Find("imgBG/PanelServer/btnChange/Image") as RectTransform;
        Debug.Log($"  CURRENT RectTransform:");
        Debug.Log($"    sizeDelta={t.sizeDelta}");
        Debug.Log($"    anchoredPosition={t.anchoredPosition}");
        Debug.Log($"    anchorMin={t.anchorMin} anchorMax={t.anchorMax}");
        Debug.Log($"    pivot={t.pivot}");
        Debug.Log($"    localScale={t.localScale}");
        Debug.Log($"    localEulerAngles={t.localEulerAngles}");

        Debug.Log("=== END ===");
    }
}
