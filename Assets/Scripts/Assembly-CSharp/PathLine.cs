// gốc: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 351)
// Source: KTO_DecompiledReference/_root/PathLine.c
//
// gốc fields: distance, cpArm, lineColor, render (LineRenderer), points (List<Vector3>),
//             keypoints (Vector3[]), curvRate, _segs (List<BezierCurve>)
// gốc methods: get_Segs, SetColor, Clear (and others)
//
// PORT 2026-05-02: minimal restore + DEVIATION shims for caller compat.
//
// DEVIATION — `Corners` / `Color` / `Start` / `End` properties NOT in gốc dump.cs.
// Reason: NavigationModule.TracePathLine (thanmaorigin port) uses these names instead
//         of gốc field names (`points`, `lineColor`). Likely a renamed/refactored
//         carry-over from earlier KTO project (KiemTheUI). Kept as backed properties
//         that route to gốc fields where applicable, so NavigationModule compiles.
// Approved by user: 2026-05-02 ("fix hết đi" — compile fix pass)
// Future fix: rewrite NavigationModule.TracePathLine to use gốc field names directly.

using System.Collections.Generic;
using UnityEngine;

public class PathLine : MonoBehaviour
{
    // gốc fields (dump.cs offsets 0x20..0x58)
    public float distance;
    public float cpArm;
    public Color lineColor;
    public LineRenderer render;
    public List<Vector3> points;
    public Vector3[] keypoints;
    public float curvRate;

    // DEVIATION shims for NavigationModule.TracePathLine — route to gốc fields
    public Vector3[] Corners
    {
        get { return keypoints; }
        set { keypoints = value; }
    }
    public Color Color
    {
        get { return lineColor; }
        set { lineColor = value; }
    }
    public Vector3 Start;
    public Vector3 End;
}
