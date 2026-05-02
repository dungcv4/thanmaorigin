// gốc: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 529)
//      KTO_DecompiledReference/_root/UIGradient.c
//
// Body verified 2026-05-02 — 4 of 4 gốc methods 1-1 match dump.cs:
//   ✓ Awake (override) / ModifyMesh (override) / CompareCarefully / .ctor
//
// DEVIATION — 3 helper methods + 1 readonly field NOT in gốc dump.cs:
//   - GetBounds (private static)        — extracted from gốc ModifyMesh inline
//   - GetDenominator (private)          — extracted from gốc ModifyMesh inline
//   - GetTime (private)                 — extracted from gốc ModifyMesh inline
//   - _vertices (List<UIVertex>)        — local cache, gốc allocates per-call
//   - field initializers (vertex1=Color.white, vertex2=Color.white)  — gốc has only the field, no init
// Approved by user: PENDING — refactoring helpers, equivalent logic.
//
// Used by: 0 prefab references currently (orphan but kept available).

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GradientMode
{
    Global = 0,
    Local = 1
}

public enum GradientDir
{
    Vertical = 0,
    Horizontal = 1,
    DiagonalLeftToRight = 2,
    DiagonalRightToLeft = 3
}

public class UIGradient : BaseMeshEffect
{
    public GradientMode gradientMode = GradientMode.Global;
    public GradientDir gradientDir = GradientDir.Vertical;
    public bool overwriteAllColor;
    public Color vertex1 = Color.white;
    public Color vertex2 = Color.white;

    private Graphic targetGraphic;
    private readonly List<UIVertex> _vertices = new List<UIVertex>();

    protected override void Awake()
    {
        base.Awake();
        targetGraphic = GetComponent<Graphic>();
    }

    public override void ModifyMesh(VertexHelper helper)
    {
        if (!IsActive() || helper.currentVertCount == 0)
        {
            return;
        }

        if (targetGraphic == null)
        {
            targetGraphic = GetComponent<Graphic>();
        }

        _vertices.Clear();
        helper.GetUIVertexStream(_vertices);
        if (_vertices.Count == 0)
        {
            return;
        }

        var bounds = GetBounds(_vertices);
        float denominator = GetDenominator(bounds);
        if (Mathf.Approximately(denominator, 0f))
        {
            denominator = 1f;
        }

        Color baseColor = targetGraphic != null ? targetGraphic.color : Color.white;
        for (int i = 0; i < _vertices.Count; i++)
        {
            UIVertex vertex = _vertices[i];
            float time = GetTime(vertex.position, bounds, denominator);
            Color gradient = Color.Lerp(vertex1, vertex2, Mathf.Clamp01(time));

            if (gradientMode == GradientMode.Local && !overwriteAllColor)
            {
                Color source = vertex.color;
                if (CompareCarefully(source, baseColor))
                {
                    source = Color.white;
                }

                gradient *= source;
            }
            else if (!overwriteAllColor)
            {
                gradient *= vertex.color;
            }

            vertex.color = gradient;
            _vertices[i] = vertex;
        }

        helper.Clear();
        helper.AddUIVertexTriangleStream(_vertices);
    }

    private bool CompareCarefully(Color col1, Color col2)
    {
        return Mathf.Approximately(col1.r, col2.r)
            && Mathf.Approximately(col1.g, col2.g)
            && Mathf.Approximately(col1.b, col2.b)
            && Mathf.Approximately(col1.a, col2.a);
    }

    private static Rect GetBounds(List<UIVertex> vertices)
    {
        Vector2 min = vertices[0].position;
        Vector2 max = vertices[0].position;
        for (int i = 1; i < vertices.Count; i++)
        {
            Vector3 position = vertices[i].position;
            min.x = Mathf.Min(min.x, position.x);
            min.y = Mathf.Min(min.y, position.y);
            max.x = Mathf.Max(max.x, position.x);
            max.y = Mathf.Max(max.y, position.y);
        }

        return Rect.MinMaxRect(min.x, min.y, max.x, max.y);
    }

    private float GetDenominator(Rect bounds)
    {
        switch (gradientDir)
        {
            case GradientDir.Horizontal:
                return bounds.width;
            case GradientDir.DiagonalLeftToRight:
            case GradientDir.DiagonalRightToLeft:
                return bounds.width + bounds.height;
            default:
                return bounds.height;
        }
    }

    private float GetTime(Vector3 position, Rect bounds, float denominator)
    {
        switch (gradientDir)
        {
            case GradientDir.Horizontal:
                return (position.x - bounds.xMin) / denominator;
            case GradientDir.DiagonalLeftToRight:
                return (position.x - bounds.xMin + position.y - bounds.yMin) / denominator;
            case GradientDir.DiagonalRightToLeft:
                return (bounds.xMax - position.x + position.y - bounds.yMin) / denominator;
            default:
                return (position.y - bounds.yMin) / denominator;
        }
    }

    // ===== Cite-only acknowledgement of remaining methods =====
    // VMA: 0x01cc158a / 0x01cc15c2 / 0x01cc1e78 / 0x01cc1ed1
}
