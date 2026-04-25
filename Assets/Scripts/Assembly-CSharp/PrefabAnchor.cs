// Class: PrefabAnchor
// GUID:  7b7f1cf78779d4013efb6d718d000b72 (preserved via .meta)
// Source: KTO_FullExtract — runtime prefab instantiation anchor
//
// PARTIAL PORT 2026-04-25: API surface for UIPanel.CreatePrefabByAnchor.

using UnityEngine;

public class PrefabAnchor : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;

    public GameObject CreatePrefab()
    {
        if (prefab == null) return null;
        var go = Instantiate(prefab, parent != null ? parent : transform);
        return go;
    }
}
