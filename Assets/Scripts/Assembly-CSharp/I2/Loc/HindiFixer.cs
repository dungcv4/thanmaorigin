// Class:  I2.Loc.HindiFixer
// GUID:   c115cb0dfbcd103b3d79e61c1e2f55cc (preserved via .meta)
// Source: KTO_DecompiledReference/I2.Loc/HindiFixer.c (2 methods)
//
// FULL 1-1 PORT 2026-04-26 — every method body verified against Ghidra C decompile.
//
// Devanagari Unicode codepoints used (gốc 0x9xx series):
//   0x901 ँ CHANDRABINDU       0x93c ़ NUKTA          0x93d ऽ AVAGRAHA
//   0x93f ि VOWEL SIGN I       0x940 ी VOWEL SIGN II  0x943 ृ V SIGN VOCALIC R
//   0x944 ॄ V SIGN VOCALIC RR  0x950 ॐ OM            0x960 ॠ LETTER VOCALIC RR
//   0x961 ॡ LETTER VOCALIC LL  0x962 ॢ V SIGN VOC L  0x963 ॣ V SIGN VOC LL
//   0x964 । DANDA              0x907 इ I             0x908 ई II
//   0x90b ऋ VOCALIC R          0x90c ऌ VOCALIC L

using System.Linq;

namespace I2.Loc
{
    public class HindiFixer
    {
        // ─── PORT 1-1: HindiFixer.Fix ─────────────────────────────────────
        // VMA: 0x01c19b43 — Source: HindiFixer.c:15 (decomp_01c1.c:9240)
        //
        // gốc body summary:
        //   1. param_1 = string. Convert to char[] (lVar3).
        //   2. For each char at index i:
        //      a. If c == 0x93f (VOWEL SIGN I): swap with previous non-whitespace char
        //         (RTL visual→logical reordering for I-vowel).
        //      b. For ligature pairs (c, next == 0x93c NUKTA), substitute combined codepoint:
        //          0x901 + 0x93c → 0x950   (chandrabindu+nukta = OM)
        //          0x943 + 0x93c → 0x944   (vocalic R → RR)
        //          0x907 + 0x93c → 0x90c   (I → vocalic L)
        //          0x908 + 0x93c → 0x961   (II → vocalic LL)
        //          0x90b + 0x93c → 0x960   (vocalic R → RR alt)
        //          0x940 + 0x93c → 0x963   (vowel II → vowel LL)
        //          0x93f + 0x93c → 0x962   (vowel I → vowel L)
        //          0x964 + 0x93c → 0x93d   (DANDA + nukta → AVAGRAHA, 4-byte write)
        //         Setting next char to 0 marks for removal (except 0x964 path).
        //   3. If any change (bVar2): build new string from chars where c != 0.
        //   4. Else return input unchanged.
        public static string Fix(string param_1)
        {
            // gốc: if (param_1 == 0 || ToCharArray returns 0) FUN_0185fa41 (throw)
            if (param_1 == null) throw new System.NullReferenceException();
            char[] chars = param_1.ToCharArray();
            if (chars == null) throw new System.NullReferenceException();
            int len = chars.Length;
            bool changed = false;

            // gốc: if ((int)uVar7 < 1) bVar2 = false; else { iterate }
            if (len >= 1)
            {
                for (int i = 0; i < len; i++)
                {
                    // gốc bounds check at start of each iter: if (uVar7 <= uVar11) goto LAB_01c19f8c (throw)
                    if ((uint)i >= (uint)len) throw new System.IndexOutOfRangeException();

                    // ─── Block A: VOWEL SIGN I (0x93f) — swap with previous non-whitespace ───
                    if (chars[i] == (char)0x93f)
                    {
                        int prev = i - 1;
                        // gốc: if ((uint)uVar7 <= uVar13) goto LAB_01c19f8c
                        if ((uint)prev >= (uint)len) throw new System.IndexOutOfRangeException();
                        char prevChar = chars[prev];
                        // gốc: System.Char.IsWhiteSpace(prevChar)
                        bool isWs = System.Char.IsWhiteSpace(prevChar);
                        // gốc: re-read uVar7 = *(ulong *)(lVar3 + 0x18)
                        len = chars.Length;
                        if (!isWs)
                        {
                            if ((uint)prev >= (uint)len) throw new System.IndexOutOfRangeException();
                            short sVar9 = (short)prevChar;
                            if (sVar9 != 0)
                            {
                                if ((uint)i >= (uint)len) throw new System.IndexOutOfRangeException();
                                chars[i] = (char)sVar9;
                                chars[prev] = (char)0x93f;
                                changed = true;
                            }
                        }
                    }

                    // ─── Block B: ligature pairs at (i, i+1) ───
                    // gốc: if (uVar11 != (int)uVar7 - 1)
                    if (i != len - 1)
                    {
                        // gốc: re-read uVar4 = uVar7 & 0xffffffff (32-bit length)
                        // and: if (uVar4 <= uVar11) goto LAB_01c19f8c
                        if ((uint)i >= (uint)len) throw new System.IndexOutOfRangeException();
                        short sVar9 = (short)chars[i];

                        if (sVar9 == 0x901)
                        {
                            // gốc: if (uVar4 <= uVar11+1) goto LAB_01c19f8c
                            if ((uint)(i + 1) >= (uint)len) throw new System.IndexOutOfRangeException();
                            // gốc: if (*(short *)(lVar3+0x22+i*2) != 0x93c) goto LAB_01c19d52 (else)
                            if (chars[i + 1] == (char)0x93c)
                            {
                                // gốc LAB_01c19d9c: write 0x950, null next, bVar2=true
                                chars[i] = (char)0x950;
                                chars[i + 1] = '\0';
                                changed = true;
                            }
                            // gốc LAB_01c19dd4: re-read sVar9; fall through to LAB_01c19dda
                            sVar9 = (short)chars[i];
                            CheckPair_940_93f_964(chars, i, ref len, ref sVar9, ref changed);
                        }
                        else if (sVar9 == 0x943)
                        {
                            if ((uint)(i + 1) >= (uint)len) throw new System.IndexOutOfRangeException();
                            if (chars[i + 1] == (char)0x93c)
                            {
                                chars[i] = (char)0x944;
                                chars[i + 1] = '\0';
                                changed = true;
                            }
                            sVar9 = (short)chars[i];
                            // gốc fall-through: LAB_01c19d52 → LAB_01c19d58 (0x908/0x90b)
                            CheckPair_908_90b(chars, i, ref len, ref sVar9, ref changed);
                            CheckPair_940_93f_964(chars, i, ref len, ref sVar9, ref changed);
                        }
                        else if (sVar9 == 0x907)
                        {
                            if ((uint)(i + 1) >= (uint)len) throw new System.IndexOutOfRangeException();
                            if (chars[i + 1] == (char)0x93c)
                            {
                                chars[i] = (char)0x90c;
                                chars[i + 1] = '\0';
                                changed = true;
                            }
                            sVar9 = (short)chars[i];
                            CheckPair_908_90b(chars, i, ref len, ref sVar9, ref changed);
                            CheckPair_940_93f_964(chars, i, ref len, ref sVar9, ref changed);
                        }
                        else
                        {
                            // gốc LAB_01c19d58 entry (no 0x901/0x943/0x907 hit)
                            CheckPair_908_90b(chars, i, ref len, ref sVar9, ref changed);
                            CheckPair_940_93f_964(chars, i, ref len, ref sVar9, ref changed);
                        }
                    }
                }
            }

            // gốc: if (bVar2) { ... build new string from where c != 0 ... }
            if (changed)
            {
                // gốc: System.Linq.Enumerable.Where<char>(lVar3, lVar5_predicate) → ToArray<char> → new String
                // The predicate (System.Func<char,bool>) checks `c != 0`.
                char[] filtered = chars.Where(c => c != '\0').ToArray();
                string result = new string(filtered);
                // gốc: System_String__op_Equality(lVar3=result, param_1, 0) — return value discarded
                _ = string.Equals(result, param_1);
                param_1 = result;
            }
            return param_1;
        }

        // gốc inlined: LAB_01c19d58 region — 0x908 + 0x93c → 0x961, 0x90b + 0x93c → 0x960
        private static void CheckPair_908_90b(char[] chars, int i, ref int len, ref short sVar9, ref bool changed)
        {
            if (sVar9 == 0x908)
            {
                if ((uint)(i + 1) >= (uint)len) throw new System.IndexOutOfRangeException();
                if (chars[i + 1] == (char)0x93c)
                {
                    // gốc LAB_01c19e1e: uVar8=0x961, then write+null
                    chars[i] = (char)0x961;
                    chars[i + 1] = '\0';
                    changed = true;
                    // gốc: re-read sVar9 = *(short *)(lVar3+0x20+i*2) (LAB_01c19e58 sets sVar9)
                    sVar9 = (short)chars[i];
                }
            }
            else if (sVar9 == 0x90b)
            {
                if ((uint)(i + 1) >= (uint)len) throw new System.IndexOutOfRangeException();
                if (chars[i + 1] == (char)0x93c)
                {
                    // gốc LAB_01c19d9c: uVar8=0x960, puVar12=(i+1)*2+0x20+lVar3 → write next as 0
                    chars[i] = (char)0x960;
                    chars[i + 1] = '\0';
                    changed = true;
                    sVar9 = (short)chars[i];
                }
            }
        }

        // gốc inlined: LAB_01c19dda → LAB_01c19e58 region — 0x940/0x93f/0x964 + 0x93c paths
        private static void CheckPair_940_93f_964(char[] chars, int i, ref int len, ref short sVar9, ref bool changed)
        {
            if (sVar9 == 0x940)
            {
                if ((uint)(i + 1) >= (uint)len) throw new System.IndexOutOfRangeException();
                if (chars[i + 1] == (char)0x93c)
                {
                    // gốc: *(undefined4 *)(lVar3+0x20+i*2) = 0x963 — writes 4 bytes (0x963 LE)
                    // Effect: chars[i] = 0x963, chars[i+1] = 0 (high half is 0).
                    chars[i] = (char)0x963;
                    chars[i + 1] = '\0';
                    changed = true;
                }
            }
            else if (sVar9 == 0x93f)
            {
                if ((uint)(i + 1) >= (uint)len) throw new System.IndexOutOfRangeException();
                if (chars[i + 1] == (char)0x93c)
                {
                    // gốc LAB_01c19e1e: uVar8=0x962, write+null
                    chars[i] = (char)0x962;
                    chars[i + 1] = '\0';
                    changed = true;
                }
            }
            else if (sVar9 == 0x964)
            {
                if ((uint)(i + 1) >= (uint)len) throw new System.IndexOutOfRangeException();
                if (chars[i + 1] == (char)0x93c)
                {
                    // gốc: *(undefined4 *)(lVar3+0x20+i*2) = 0x93d — 4-byte write (low half = 0x93d, high half = 0)
                    chars[i] = (char)0x93d;
                    chars[i + 1] = '\0';
                    changed = true;
                }
            }
        }

        // ─── PORT 1-1: HindiFixer..ctor ───────────────────────────────────
        // VMA: 0x01c19f96 — Source: HindiFixer.c:9431
        // gốc body: System.Object.__ctor(this, 0) — empty constructor.
        public HindiFixer() { }
    }
}
