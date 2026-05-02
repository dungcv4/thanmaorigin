// VERIFY 2026-05-02 — open gốc UILoginServer.prefab from KTO_FullExtract and read
// btnChange/Image's actual m_Sprite. Confirms whether FixBtnChangeImage's premise
// ("truly null in gốc") is correct.
//
// gốc path: KTO_FullExtract/Assets_YAML/ui/views/res_p_137/UILoginServer.prefab
// (not in current Unity AssetDatabase since it's outside Assets/. Read raw YAML.)

using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public static class VerifyGocBtnChange
{
    public static void Execute()
    {
        Debug.Log("=== VerifyGocBtnChange START ===");

        string gocPath = "/Users/vsf-user-l/Documents/Test/alo/KTO_FullExtract/Assets_YAML/ui/views/res_p_137/UILoginServer.prefab";
        if (!File.Exists(gocPath)) { Debug.LogError("gốc not found"); return; }

        string content = File.ReadAllText(gocPath);
        var lines = content.Split('\n');

        // 1. Find btnChange GameObject + its component Transform fileID
        int bcLineIdx = -1;
        long bcGoId = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].TrimStart().StartsWith("m_Name: btnChange"))
            {
                bcLineIdx = i;
                // Walk back to find !u!1 &<id>
                for (int j = i; j >= System.Math.Max(0, i - 30); j--)
                {
                    var m = Regex.Match(lines[j], @"!u!1 &(-?\d+)");
                    if (m.Success) { bcGoId = long.Parse(m.Groups[1].Value); break; }
                }
                break;
            }
        }
        Debug.Log($"  gốc btnChange GO at line {bcLineIdx + 1}, fileID={bcGoId}");

        // 2. Find btnChange's Transform component fileID (RectTransform/Transform)
        // Look in btnChange GO block for "- component: {fileID: <id>}"
        long bcTransformId = 0;
        for (int i = bcLineIdx; i >= System.Math.Max(0, bcLineIdx - 20); i--)
        {
            var m = Regex.Match(lines[i], @"- component: \{fileID: (-?\d+)\}");
            if (m.Success && bcTransformId == 0) bcTransformId = long.Parse(m.Groups[1].Value);
        }
        Debug.Log($"  Looking for Transform whose m_GameObject={bcGoId}");

        // 3. Find Transform whose m_GameObject={bcGoId} → get its m_Children list
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains($"m_GameObject: {{fileID: {bcGoId}}}") &&
                i > 0 && (lines[i-3].Contains("Transform:") || lines[i-3].Contains("RectTransform:")))
            {
                Debug.Log($"  Found btnChange Transform at line {i+1}");
                // Print next 30 lines to see m_Children
                for (int j = i; j < System.Math.Min(lines.Length, i + 35); j++)
                {
                    if (lines[j].Contains("m_Children") || lines[j].Contains("- {fileID:"))
                        Debug.Log($"    L{j+1}: {lines[j]}");
                }
                break;
            }
        }

        // 4. Brute force: find all "m_Name: Image" GOs where the Image's m_Father resolves to btnChange
        // Simpler approach: search for "m_Name: Image" and dump nearby m_Sprite
        Debug.Log("  All 'm_Name: Image' in gốc UILoginServer:");
        int imgCount = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].TrimStart().StartsWith("m_Name: Image") && !lines[i].Contains("CompositeImage"))
            {
                imgCount++;
                // Find go fileID by walking back to !u!1 &
                long imgGoId = 0;
                for (int j = i; j >= System.Math.Max(0, i - 25); j--)
                {
                    var m = Regex.Match(lines[j], @"!u!1 &(-?\d+)");
                    if (m.Success) { imgGoId = long.Parse(m.Groups[1].Value); break; }
                }
                Debug.Log($"    'Image' GO #{imgCount} at line {i+1} fileID={imgGoId}");
            }
        }
        Debug.Log($"  Total 'Image' GOs in gốc UILoginServer: {imgCount}");

        Debug.Log("=== VerifyGocBtnChange END ===");
    }
}
