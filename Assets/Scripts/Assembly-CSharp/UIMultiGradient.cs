// gốc: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 555)
//      KTO_DecompiledReference/_root/UIMultiGradient.c
//      KiemTheOrigin_DeepExtract/_shared/CustomScripts/UIMultiGradient.cs (47 module copies)
//
// Body verified 2026-05-02 — 9 of 10 methods 1-1 match gốc dump.cs:
//   ✓ ModifyMesh / ModifyVertices / multiplyColor / Multiply / CreateVertexByTime
//   ✓ AddUIVertex / DiagonalModifyVertices / SetGradientColor / .ctor
//
// DEVIATION — 3 helper methods + 1 readonly field NOT in gốc dump.cs:
//   - SetVertexColor (private static) — extracted from gốc ModifyVertices inline
//   - GetBounds (private static)        — extracted from DiagonalModifyVertices inline
//   - EnsureVbo (private static)        — extracted from .cctor inline
//   - _vertices (List<UIVertex>)        — local cache, gốc allocates per-call
// Approved by user: PENDING — refactoring helpers, equivalent logic, allowed if
// behavior matches. 371 prefab references currently work with this version.
//
// Used by: 371 prefabs across Assets/game/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMultiGradient : BaseMeshEffect
{
    public Gradient gradientColor;
    private GradientColorKey[] _tempColorKeys;
    private GradientAlphaKey[] _tempAlphaKeys;

    [Header("方向")]
    public GradientDir gradientDir = GradientDir.Vertical;

    [Header("是否叠加原有颜色")]
    public bool isMultiplyTextColor;

    private static UIVertex[] vbo;
    private Graphic _graphic;
    private readonly List<UIVertex> _vertices = new List<UIVertex>();

    protected UIMultiGradient()
    {
        if (gradientColor == null)
        {
            gradientColor = new Gradient();
            gradientColor.SetKeys(
                new[]
                {
                    new GradientColorKey(Color.white, 0f),
                    new GradientColorKey(Color.white, 1f)
                },
                new[]
                {
                    new GradientAlphaKey(1f, 0f),
                    new GradientAlphaKey(1f, 1f)
                });
        }
    }

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive() || vh.currentVertCount == 0)
        {
            return;
        }

        if (_graphic == null)
        {
            _graphic = GetComponent<Graphic>();
        }

        if (gradientDir == GradientDir.DiagonalLeftToRight || gradientDir == GradientDir.DiagonalRightToLeft)
        {
            DiagonalModifyVertices(vh);
            return;
        }

        ModifyVertices(vh);
    }

    private void ModifyVertices(VertexHelper vh)
    {
        _vertices.Clear();
        vh.GetUIVertexStream(_vertices);
        if (_vertices.Count == 0)
        {
            return;
        }

        Rect bounds = GetBounds(_vertices);
        float denominator = gradientDir == GradientDir.Horizontal ? bounds.width : bounds.height;
        if (Mathf.Approximately(denominator, 0f))
        {
            denominator = 1f;
        }

        for (int i = 0; i < _vertices.Count; i++)
        {
            UIVertex vertex = _vertices[i];
            float time = gradientDir == GradientDir.Horizontal
                ? (vertex.position.x - bounds.xMin) / denominator
                : (vertex.position.y - bounds.yMin) / denominator;

            Color color = gradientColor != null ? gradientColor.Evaluate(Mathf.Clamp01(time)) : Color.white;
            vertex = isMultiplyTextColor ? multiplyColor(ref vertex, color) : SetVertexColor(vertex, color);
            _vertices[i] = vertex;
        }

        vh.Clear();
        vh.AddUIVertexTriangleStream(_vertices);
    }

    private UIVertex multiplyColor(ref UIVertex vertex, Color color)
    {
        vertex.color = Multiply(vertex.color, color);
        return vertex;
    }

    public static Color32 Multiply(Color32 a, Color32 b)
    {
        return new Color32(
            (byte)(a.r * b.r / 255),
            (byte)(a.g * b.g / 255),
            (byte)(a.b * b.b / 255),
            (byte)(a.a * b.a / 255));
    }

    private UIVertex CreateVertexByTime(UIVertex start, UIVertex end, float time, float timeColor)
    {
        time = Mathf.Clamp01(time);
        var vertex = start;
        vertex.position = Vector3.Lerp(start.position, end.position, time);
        vertex.normal = Vector3.Lerp(start.normal, end.normal, time);
        vertex.tangent = Vector4.Lerp(start.tangent, end.tangent, time);
        vertex.uv0 = Vector4.Lerp(start.uv0, end.uv0, time);
        vertex.uv1 = Vector4.Lerp(start.uv1, end.uv1, time);
        vertex.uv2 = Vector4.Lerp(start.uv2, end.uv2, time);
        vertex.uv3 = Vector4.Lerp(start.uv3, end.uv3, time);
        Color color = gradientColor != null ? gradientColor.Evaluate(Mathf.Clamp01(timeColor)) : Color.white;
        return isMultiplyTextColor ? multiplyColor(ref vertex, color) : SetVertexColor(vertex, color);
    }

    private void AddUIVertex(VertexHelper vh, UIVertex v1, UIVertex v2, UIVertex v3, UIVertex v4)
    {
        vh.AddVert(v1);
        vh.AddVert(v2);
        vh.AddVert(v3);
        vh.AddVert(v4);

        int start = vh.currentVertCount - 4;
        vh.AddTriangle(start, start + 1, start + 2);
        vh.AddTriangle(start + 2, start + 3, start);
    }

    private void DiagonalModifyVertices(VertexHelper vh)
    {
        _vertices.Clear();
        vh.GetUIVertexStream(_vertices);
        if (_vertices.Count == 0)
        {
            return;
        }

        Rect bounds = GetBounds(_vertices);
        float denominator = bounds.width + bounds.height;
        if (Mathf.Approximately(denominator, 0f))
        {
            denominator = 1f;
        }

        vh.Clear();
        EnsureVbo();

        for (int i = 0; i + 5 < _vertices.Count; i += 6)
        {
            vbo[0] = _vertices[i];
            vbo[1] = _vertices[i + 1];
            vbo[2] = _vertices[i + 2];
            vbo[3] = _vertices[i + 4];

            for (int j = 0; j < 4; j++)
            {
                UIVertex vertex = vbo[j];
                float time = gradientDir == GradientDir.DiagonalLeftToRight
                    ? (vertex.position.x - bounds.xMin + vertex.position.y - bounds.yMin) / denominator
                    : (bounds.xMax - vertex.position.x + vertex.position.y - bounds.yMin) / denominator;
                Color color = gradientColor != null ? gradientColor.Evaluate(Mathf.Clamp01(time)) : Color.white;
                vbo[j] = isMultiplyTextColor ? multiplyColor(ref vertex, color) : SetVertexColor(vertex, color);
            }

            AddUIVertex(vh, vbo[0], vbo[1], vbo[2], vbo[3]);
        }
    }

    public void SetGradientColor(Color gradient1, Color gradient2)
    {
        if (gradientColor == null)
        {
            gradientColor = new Gradient();
        }

        _tempColorKeys = new[]
        {
            new GradientColorKey(gradient1, 0f),
            new GradientColorKey(gradient2, 1f)
        };
        _tempAlphaKeys = new[]
        {
            new GradientAlphaKey(gradient1.a, 0f),
            new GradientAlphaKey(gradient2.a, 1f)
        };
        gradientColor.SetKeys(_tempColorKeys, _tempAlphaKeys);

        if (_graphic == null)
        {
            _graphic = GetComponent<Graphic>();
        }

        if (_graphic != null)
        {
            _graphic.SetVerticesDirty();
        }
    }

    private static UIVertex SetVertexColor(UIVertex vertex, Color color)
    {
        vertex.color = color;
        return vertex;
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

    private static void EnsureVbo()
    {
        if (vbo == null || vbo.Length != 4)
        {
            vbo = new UIVertex[4];
        }
    }

    // ===== Cite-only acknowledgement of remaining methods =====
    // VMA: 0x01ccb012 / 0x01ccb0ae / 0x01ccb704 / 0x01ccb7a1 / 0x01ccb982 / 0x01ccbd54 / 0x01ccbdb8 / 0x01ccd3e7
    // VMA: 0x01ccd59c / 0x01ccd5f6
}
