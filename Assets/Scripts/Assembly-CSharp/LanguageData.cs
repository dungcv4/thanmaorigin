// Class:  I2.Loc.LanguageData
// GUID:   3e3fc073828ccbb130b22848ed21fe6c (preserved via .meta)
// Source: KTO_DecompiledReference/I2.Loc/LanguageData.c (7 methods)
// Address range: 0x01c0384b — 0x01c0389d
//
// FULL 1-1 PORT 2026-04-26 — every method body verified against Ghidra C decompile.
//
// gốc field layout (offset +0x20 from object base):
//   byte flags = bit0 (Enabled INVERTED) | bit1 (CanBeUnloaded INVERTED) | bit2 (Loaded INVERTED)
//   Note: gốc uses INVERTED semantics — IsX returns (flag & mask) == 0, SetX writes (param ^ 1).

using UnityEngine;

namespace I2.Loc
{
    [System.Serializable]
    public class LanguageData
    {
        // gốc field at +0x20: combined flag byte (bit-packed)
        // Public fields fillers at +0x10 (Name) and +0x18 (Code) follow ScriptableObject offsets.
        public string Name;
        public string Code;
        // gốc bit-packed flags at offset 0x20 — 1 byte
        public byte Flags;

        // ─── PORT 1-1: LanguageData.IsEnabled ─────────────────────────────
        // VMA: 0x01c0384b — Source: LanguageData.c:2759
        // gốc: return (*(byte *)(this + 0x20) & 1) == 0;
        public bool IsEnabled() => (Flags & 1) == 0;

        // ─── PORT 1-1: LanguageData.SetEnabled ────────────────────────────
        // VMA: 0x01c03853 — Source: LanguageData.c:2772
        // gốc: *(byte *)(this + 0x20) = (param ^ 1) | *(byte *)(this + 0x20) & 0xfe;
        public void SetEnabled(bool param_2)
        {
            byte p = (byte)(param_2 ? 1 : 0);
            Flags = (byte)((p ^ 1) | (Flags & 0xfe));
        }

        // ─── PORT 1-1: LanguageData.IsLoaded ──────────────────────────────
        // VMA: 0x01c03864 — Source: LanguageData.c:2786
        // gốc: return (*(byte *)(this + 0x20) & 4) == 0;
        public bool IsLoaded() => (Flags & 4) == 0;

        // ─── PORT 1-1: LanguageData.CanBeUnloaded ─────────────────────────
        // VMA: 0x01c0386c — Source: LanguageData.c:2799
        // gốc: return (*(byte *)(this + 0x20) & 2) == 0;
        public bool CanBeUnloaded() => (Flags & 2) == 0;

        // ─── PORT 1-1: LanguageData.SetLoaded ─────────────────────────────
        // VMA: 0x01c03874 — Source: LanguageData.c:2812
        // gốc: *(byte *)(this + 0x20) = ((param ^ 1) << 2) | *(byte *)(this + 0x20) & 0xfb;
        public void SetLoaded(bool param_2)
        {
            byte p = (byte)(param_2 ? 1 : 0);
            Flags = (byte)(((p ^ 1) << 2) | (Flags & 0xfb));
        }

        // ─── PORT 1-1: LanguageData.SetCanBeUnLoaded ──────────────────────
        // VMA: 0x01c03889 — Source: LanguageData.c:2826
        // gốc: *(byte *)(this + 0x20) = ((param ^ 1) * 2) | *(byte *)(this + 0x20) & 0xfd;
        public void SetCanBeUnLoaded(bool param_2)
        {
            byte p = (byte)(param_2 ? 1 : 0);
            Flags = (byte)(((p ^ 1) * 2) | (Flags & 0xfd));
        }

        // ─── PORT 1-1: LanguageData..ctor ─────────────────────────────────
        // VMA: 0x01c0389d — Source: LanguageData.c:2840
        // gốc: System.Object.__ctor(this, 0) — empty constructor.
        public LanguageData() { }
    }
}
