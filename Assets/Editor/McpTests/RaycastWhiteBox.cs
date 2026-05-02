using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Collections.Generic;

public static class RaycastWhiteBox
{
    public static void Execute()
    {
        // Image is captured at 1374x711 by capture_ui_canvas.
        // White box approx image x: 1040..1330, y: 0..140 (image y=0 is top)
        // Center: image (1185, 70). Convert to actual Unity screen using image / Screen ratios.
        // Actually capture_ui_canvas may render at canvas's render size.
        // Try multiple test points across the white box area.
        var es = EventSystem.current;
        if (es == null) { Debug.Log("[RC] no EventSystem"); return; }

        // Test points in Unity SCREEN space. We'll sweep top-right.
        // Unity screen y=0 is bottom, max=Screen.height=993.
        // White box spans roughly: x=1300..1700, y=850..993 in actual screen.
        var testPoints = new (float x, float y)[]
        {
            (1500, 900), (1400, 950), (1600, 920), (1450, 880), (1550, 870),
            (1350, 970), (1620, 870), (1500, 850), (1700, 950), (1280, 900),
        };
        foreach (var p in testPoints)
        {
            var ped = new PointerEventData(es) { position = new Vector2(p.x, p.y) };
            var results = new List<RaycastResult>();
            es.RaycastAll(ped, results);
            string hits = "";
            foreach (var r in results)
            {
                hits += "  - " + GetPath(r.gameObject.transform) + " (sortingLayer=" + r.sortingLayer + " order=" + r.sortingOrder + ")\n";
            }
            Debug.Log("[RC] (" + p.x + "," + p.y + ") n=" + results.Count + "\n" + hits);
        }
    }
    static string GetPath(Transform t) { string p = t.name; while ((t = t.parent) != null) p = t.name + "/" + p; return p; }
}
