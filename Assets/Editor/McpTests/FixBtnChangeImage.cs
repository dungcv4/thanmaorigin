using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class FixBtnChangeImage
{
    // Source: KTO bundle res_p_137 (UILoginServer)
    //   re-extracted via tools/extract_kto_prefab.py with Tuanjie typetrees
    //   btnChange/Image -> m_Sprite: {m_FileID: 0, m_PathID: 0}  (truly null in gốc)
    // Tuanjie engine renders null-sprite Image as nothing; standard Unity renders white.
    // Fix: match gốc bundle by clearing sprite + alpha=0, no creative replacement.
    public static void Execute()
    {
        string path = "UILoginServer/imgBG/PanelServer/btnChange/Image";
        var go = GameObject.Find(path);
        if (go == null)
        {
            Debug.LogError("[Fix] not found: " + path);
            return;
        }
        var img = go.GetComponent<Image>();
        if (img == null)
        {
            Debug.LogError("[Fix] no Image on " + path);
            return;
        }
        Debug.Log("[Fix] BEFORE: sprite=" + (img.sprite != null ? img.sprite.name : "<NULL>")
            + " colorA=" + img.color.a);
        img.sprite = null;
        var c = img.color;
        c.a = 0f;
        img.color = c;
        img.SetAllDirty();
        Debug.Log("[Fix] AFTER: sprite=" + (img.sprite != null ? img.sprite.name : "<NULL>")
            + " colorA=" + img.color.a);
    }
}
