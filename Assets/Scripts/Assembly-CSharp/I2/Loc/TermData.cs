// 1-1 PORT 2026-04-27: I2.Loc.TermData fields restored from KTO IL2CPP dump.
// Source: KTO_Resources/il2cpp_full_dump/dump.cs class TermData (TypeDefIndex 1544)
using UnityEngine;

namespace I2.Loc
{
    [System.Serializable]
    public class TermData
    {
        public string Term;                              // 0x10
        public eTermType TermType;                       // 0x18
        public string Description;                       // 0x20
        public string[] Languages;                       // 0x28  ← TRANSLATIONS PER LANGUAGE INDEX
        public byte[] Flags;                             // 0x30
        [SerializeField] private string[] Languages_Touch; // 0x38
    }

    public enum eTermType
    {
        Text = 0, Font = 1, Texture = 2, AudioClip = 3, GameObject = 4,
        Sprite = 5, Material = 6, Child = 7, Mesh = 8, Object = 9, Video = 10, Prefab = 11
    }
}
