// gốc: KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1616 + nested 1613/1614/1615)
//      KTO_DecompiledReference/_root/UIMultiLangConfig.c
//
// LEGACY NGUI multi-language config — superseded by Localize component (I2.Loc).
// All 4 methods empty bodies in gốc IL2CPP (RVAs 0x1B2B475..0x1B2B478).
//
// PORT 2026-05-02: replace AR Cpp2IL dummy stub. Field arrays + nested types preserved.

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class UIMultiLangConfig : MonoBehaviour
    {
        // Nested type — gốc TypeDefIndex 1613
        [Serializable]
        public class TextInfo
        {
            public Text text;
            public string textFile;
            public string textID;
        }

        // Nested type — gốc TypeDefIndex 1614
        [Serializable]
        public class ImageInfo
        {
            public Image image;
            public string imagePath;
        }

        // Nested type — gốc TypeDefIndex 1615
        [Serializable]
        public class RawImageInfo
        {
            public RawImage rawImage;
            public string rawImagePath;
        }

        // Fields (matches dump.cs offsets 0x20, 0x28, 0x30)
        public TextInfo[] textList;
        public ImageInfo[] imageList;
        public RawImageInfo[] rawImageList;

        // gốc methods — empty bodies
        public void Awake() { }
        public void Refresh(string language) { }
        public void OnPreDestroy() { }
    }
}
