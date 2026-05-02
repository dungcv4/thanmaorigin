// Verify both prefab on disk + runtime instance state for btnChange/Image.
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

public static class CheckBtnChangeArrowState
{
    public static void Execute()
    {
        Debug.Log("=== CheckBtnChangeArrowState START ===");

        // (1) Read prefab via AssetDatabase
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/game/ui/views/UILoginServer.prefab");
        var t = prefab.transform.Find("imgBG/PanelServer/btnChange/Image");
        var img = t.GetComponent<Image>();
        var rt = t as RectTransform;
        Debug.Log($"  PREFAB(API): sprite={(img.sprite != null ? img.sprite.name : "NULL")} color={img.color} rotZ={rt.localEulerAngles.z}");

        // (2) Read raw YAML to confirm save persisted
        string yaml = File.ReadAllText("Assets/game/ui/views/UILoginServer.prefab");
        // Find btnChange/Image GO via parent walk → find m_Sprite line
        // Easier: find all m_Sprite then identify the one whose GO has m_Father chain leading to btnChange
        // Simpler: count m_Sprite lines + look for the ones whose color is 1,1,1,1 + sizeDelta 60
        var lines = yaml.Split('\n');
        // Find the GO whose Transform parent matches btnChange's Transform
        // Do it by name: find "Image" GO under btnChange directly via PrefabUtility name
        // Already verified by API above. Just spot-check raw count:
        int hardCoded = 0, placeholder = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            if (Regex.IsMatch(lines[i], @"^\s+m_Sprite: \{fileID:"))
            {
                if (lines[i].Contains("guid: 0000000000000000f000000000000000")) placeholder++;
                else if (!lines[i].Contains("fileID: 0,")) hardCoded++;
            }
        }
        Debug.Log($"  RAW YAML m_Sprite refs: hard-coded={hardCoded} placeholder={placeholder}");

        // (3) Runtime instance state
        var runtimeT = GameObject.Find("UILoginServer/imgBG/PanelServer/btnChange/Image");
        if (runtimeT != null)
        {
            var runtimeImg = runtimeT.GetComponent<Image>();
            var runtimeRT = runtimeT.transform as RectTransform;
            Debug.Log($"  RUNTIME: sprite={(runtimeImg.sprite != null ? runtimeImg.sprite.name : "NULL")} color={runtimeImg.color} rotZ={runtimeRT.localEulerAngles.z} active={runtimeT.activeInHierarchy}");
            Debug.Log($"  RUNTIME RectTransform: sizeDelta={runtimeRT.sizeDelta} anchoredPos={runtimeRT.anchoredPosition} localPos={runtimeRT.localPosition}");
            // Check parent canvas
            var canvas = runtimeT.GetComponentInParent<Canvas>();
            if (canvas != null) {
                var cg = canvas.GetComponent<CanvasGroup>();
                Debug.Log($"  Parent Canvas: '{canvas.name}' enabled={canvas.enabled} sortingOrder={canvas.sortingOrder} alpha={(cg != null ? cg.alpha.ToString() : "no CanvasGroup")}");
            }
        }
        else { Debug.Log("  RUNTIME: btnChange/Image NOT FOUND in scene"); }

        // (4) Check if sprite asset still loadable
        var arrowAsset = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/game/ui/atlas/common_btn/btn_narrow_right.asset");
        Debug.Log($"  Atlas sprite btn_narrow_right.asset: {(arrowAsset != null ? "OK name="+arrowAsset.name+" rect="+arrowAsset.rect : "MISSING")}");

        Debug.Log("=== CheckBtnChangeArrowState END ===");
    }
}
