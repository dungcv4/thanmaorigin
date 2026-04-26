// Class:  I2.Loc.I2Utils
// GUID:   2669a5482283ec7ef7040987657b2a89 (preserved via .meta)
// Source: KTO_DecompiledReference/I2.Loc/I2Utils.c (16 methods)
// Address range: 0x01c19ffc — 0x01c1aeae + 0x01eb758c (FindInParents<T>)
//
// FULL 1-1 PORT 2026-04-26 — every method body verified against Ghidra C decompile.

using System;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

namespace I2.Loc
{
    public static class I2Utils
    {
        // gốc DAT_035aabf0: cached compiled regex for tag matching (RemoveTags)
        private static readonly Regex _tagRegex = new Regex("\\[.*?\\]|<.*?>|\\{.*?\\}|\\(.*?\\)");

        // gốc DAT_03597cd0: ASCII allowlist string for RemoveNonASCII override
        private static string _nonAsciiAllow = "";

        // gốc DAT_03597f50: "/" path separator string used in GetPath/FindObject
        private const string PathSep = "/";

        // ─── PORT 1-1: I2Utils.ReverseText ────────────────────────────────
        // VMA: 0x01c19ffc — Source: I2Utils.c:9494
        public static string ReverseText(string param_1)
        {
            if (param_1 == null) throw new NullReferenceException();
            int uVar1 = param_1.Length;
            char[] lVar6 = new char[uVar1];
            char[] lVar7 = new char[2] { '\r', '\n' };

            if (uVar1 > 0)
            {
                ulong uVar10 = 0;
                while ((int)uVar10 < uVar1)
                {
                    int next = param_1.IndexOfAny(lVar7, (int)uVar10);
                    int iVar2 = next < 0 ? uVar1 : next;

                    Reverse_3_0((int)uVar10, iVar2 - 1, new ReverseTarget { array = lVar6, source = param_1 });

                    if (iVar2 < uVar1)
                    {
                        long lVar9 = 0;
                        bool didCopy = false;
                        while (true)
                        {
                            uVar10 = (ulong)iVar2 + (ulong)lVar9;
                            if ((int)uVar10 >= uVar1) break;
                            char c = param_1[(int)uVar10];
                            if (c != '\r' && c != '\n') break;
                            lVar6[(long)iVar2 + lVar9] = c;
                            lVar9++;
                            didCopy = true;
                            if ((long)uVar1 - iVar2 == lVar9) goto build;
                        }
                        if (!didCopy) uVar10 = (ulong)(uint)(iVar2 + (int)lVar9);
                        else uVar10 = (ulong)(uint)(iVar2 + (int)lVar9);
                    }
                    else
                    {
                        uVar10 = (ulong)(uint)iVar2;
                    }
                }
            }
        build:
            return new string(lVar6);
        }

        // gốc helper: Reverse|3_0 closure target { array, source }
        private class ReverseTarget { public char[] array; public string source; }

        // ─── PORT 1-1: I2Utils.<ReverseText>g__Reverse|3_0 ────────────────
        // VMA: 0x01c1a190 — Source: I2Utils.c:9575
        // gốc: for (j = 0; j <= end-start; j++) target.array[end - j] = source[start + j];
        private static void Reverse_3_0(int param_1, int param_2, ReverseTarget param_3)
        {
            int iVar4 = param_2 - param_1;
            if (iVar4 < 0) return;
            int iVar3 = 0;
            do
            {
                if (param_3 == null || param_3.source == null) throw new NullReferenceException();
                if ((uint)param_2 >= (uint)param_3.array.Length) throw new IndexOutOfRangeException();
                param_3.array[param_2] = param_3.source[param_1 + iVar3];
                iVar3++;
                param_2--;
            } while (iVar3 <= iVar4);
        }

        // ─── PORT 1-1: I2Utils.RemoveNonASCII ─────────────────────────────
        // VMA: 0x01c1a1fd — Source: I2Utils.c:9614
        public static string RemoveNonASCII(string param_1, bool param_2)
        {
            if (string.IsNullOrEmpty(param_1)) return param_1;
            if (param_1 == null) throw new NullReferenceException();
            int srcLen = param_1.Length;
            char[] lVar5 = new char[srcLen];
            ulong uVar9 = 0;
            string lVar6 = param_1.Trim();
            if (lVar6 == null) throw new NullReferenceException();
            int trimLen = lVar6.Length;
            if (trimLen <= 0) return new string(lVar5, 0, 0);

            int iVar7 = 0;
            bool bVar1 = false;
            ulong uVar10 = 0;
            const ulong AsciiBitmask = 0x400000000002001UL;

            do
            {
                uint uVar3 = lVar6[iVar7];
                ushort uVar8 = (ushort)uVar3;
                bool keepAsIs = false;
                if (param_2)
                {
                    ushort offs = (ushort)(uVar3 - 0x22);
                    if (offs <= 0x3a)
                    {
                        if (((AsciiBitmask >> (int)(offs & 0x3f)) & 1UL) != 0)
                        {
                            keepAsIs = true;
                        }
                    }
                }
                if (!keepAsIs)
                {
                    if (!System.Char.IsLetterOrDigit((char)uVar8))
                    {
                        bool inAllowlist = false;
                        if (!string.IsNullOrEmpty(_nonAsciiAllow))
                        {
                            int iVar4 = _nonAsciiAllow.IndexOf((char)(uVar3 & 0xffff));
                            if (iVar4 >= 0) inAllowlist = true;
                        }
                        if (!inAllowlist) uVar8 = 0x20;
                    }
                }
                bool isWs = System.Char.IsWhiteSpace((char)uVar8);
                if (!isWs)
                {
                    if (lVar5 == null) throw new NullReferenceException();
                    uint uVar3a = (uint)uVar10;
                    if ((uint)lVar5.Length <= uVar3a) throw new IndexOutOfRangeException();
                    uVar9 = (ulong)(uVar3a + 1);
                    lVar5[(int)uVar3a] = (char)uVar8;
                    bVar1 = false;
                }
                else
                {
                    uVar9 = uVar10;
                    if (!bVar1)
                    {
                        bVar1 = true;
                        if ((int)uVar10 > 0)
                        {
                            if (lVar5 == null) throw new NullReferenceException();
                            uint uVar3b = (uint)uVar10;
                            if ((uint)lVar5.Length <= uVar3b) throw new IndexOutOfRangeException();
                            uVar9 = (ulong)(uVar3b + 1);
                            lVar5[(int)uVar10] = (char)0x20;
                            bVar1 = true;
                        }
                    }
                }
                iVar7++;
                uVar10 = uVar9;
            } while (iVar7 < trimLen);

            return new string(lVar5, 0, (int)uVar9);
        }

        // ─── PORT 1-1: I2Utils.GetValidTermName ───────────────────────────
        // VMA: 0x01c1a3d6 — Source: I2Utils.c:9710
        public static string GetValidTermName(string param_1, bool param_2)
        {
            if (param_1 == null) return null;
            string uVar1 = RemoveTags(param_1);
            return RemoveNonASCII(uVar1, param_2);
        }

        // ─── PORT 1-1: I2Utils.RemoveTags ─────────────────────────────────
        // VMA: 0x01c1a3f2 — Source: I2Utils.c:9730
        // gốc: System.Text.RegularExpressions.Regex.Replace(input, _tagRegex, "")
        public static string RemoveTags(string param_1)
        {
            if (param_1 == null) return null;
            return _tagRegex.Replace(param_1, "");
        }

        // ─── PORT 1-1: I2Utils.SplitLine ──────────────────────────────────
        // VMA: 0x01c1a461 — Source: I2Utils.c:9753
        public static string SplitLine(string param_1, int param_2)
        {
            if (param_2 < 1) return param_1;
            if (param_1 == null) throw new NullReferenceException();
            if (param_1.Length < param_2) return param_1;
            char[] lVar5 = param_1.ToCharArray();
            if (lVar5 == null) throw new NullReferenceException();
            int len = lVar5.Length;
            if (len > 0)
            {
                bool bVar11 = true;
                int iVar10 = 0;
                bool bVar4 = false;
                ulong uVar9 = 0;

                do
                {
                    if (bVar11)
                    {
                        if ((ulong)len <= uVar9) throw new IndexOutOfRangeException();
                        short sVar2 = (short)lVar5[uVar9];
                        iVar10++;
                        if (sVar2 == 10) iVar10 = 0;
                        if (param_2 <= iVar10)
                        {
                            bool isWs = System.Char.IsWhiteSpace((char)sVar2);
                            if (isWs)
                            {
                                if ((uint)lVar5.Length <= uVar9) throw new IndexOutOfRangeException();
                                lVar5[uVar9] = '\n';
                                bVar4 = false;
                                bVar11 = false;
                            }
                        }
                    }
                    else
                    {
                        if ((ulong)len <= uVar9) throw new IndexOutOfRangeException();
                        char uVar1 = lVar5[uVar9];
                        bool isWs = System.Char.IsWhiteSpace(uVar1);
                        if (!isWs)
                        {
                            iVar10 = 0;
                            bVar11 = true;
                        }
                        else
                        {
                            if ((uint)lVar5.Length <= uVar9) throw new IndexOutOfRangeException();
                            if (lVar5[uVar9] == '\n')
                            {
                                if (!bVar4)
                                {
                                    lVar5[uVar9] = '\0';
                                }
                                bVar4 = true;
                            }
                            else
                            {
                                lVar5[uVar9] = '\0';
                            }
                        }
                    }
                    uVar9++;
                    len = lVar5.Length;
                } while ((long)uVar9 < (long)(uint)len);
            }
            // gốc: Linq.Where(c => c != 0).ToArray() → new string
            char[] filtered = lVar5.Where(c => c != '\0').ToArray();
            return new string(filtered);
        }

        // ─── PORT 1-1: I2Utils.FindNextTag ────────────────────────────────
        // VMA: 0x01c1a6f3 — Source: I2Utils.c:9875
        public static bool FindNextTag(string param_1, ulong param_2, out uint param_3, out int param_4)
        {
            param_3 = 0xffffffff;
            param_4 = -1;
            if (param_1 == null) throw new NullReferenceException();
            while (true)
            {
                int iVar1 = param_1.Length;
                param_3 = (uint)param_2;
                if ((int)param_3 < iVar1)
                {
                    while (true)
                    {
                        char sVar2 = param_1[(int)param_2];
                        if (sVar2 == '[' || param_1[(int)param_3] == '(' || param_1[(int)param_3] == '{' || param_1[(int)param_3] == '<')
                            break;
                        uint uVar3 = param_3 + 1;
                        param_2 = (ulong)uVar3;
                        param_3 = uVar3;
                        if ((int)uVar3 >= iVar1) break;
                    }
                    param_2 = (ulong)param_3;
                }
                if ((int)param_2 == iVar1) return false;
                int iVar4 = (int)param_2 + 1;
                param_4 = iVar4;
                if (iVar1 <= iVar4) return false;

                bool bVar5 = false;
                while (true)
                {
                    uint uVar3 = param_1[iVar4];
                    bool isClose1 = ((ushort)(uVar3 - 0x3e) < 0x40)
                                    && (((0x8000000080000001UL >> (int)((ulong)(uVar3 - 0x3e) & 0x3f)) & 1UL) != 0);
                    bool isClose2 = (short)uVar3 == 0x29;
                    if (isClose1 || isClose2) break;
                    if ((uVar3 & 0xffff) > 0xff) bVar5 = true;
                    iVar4 = param_4 + 1;
                    param_4 = iVar4;
                    if (iVar1 <= iVar4) return false;
                }
                if (!bVar5) return true;
                param_2 = (ulong)(param_4 + 1);
                param_3 = 0xffffffff;
                param_4 = -1;
            }
        }

        // ─── PORT 1-1: I2Utils.RemoveResourcesPath ────────────────────────
        // VMA: 0x01c1a815 — Source: I2Utils.c:9945
        public static bool RemoveResourcesPath(ref string param_1)
        {
            if (param_1 == null) throw new NullReferenceException();
            int iVar2 = param_1.IndexOf("/Resources/", StringComparison.Ordinal);
            int iVar3 = param_1.IndexOf("/Assets/", StringComparison.Ordinal);
            uint uVar4 = (uint)param_1.IndexOf("/", StringComparison.Ordinal);
            int uVar5 = param_1.IndexOf("\\", StringComparison.Ordinal);

            // gốc: int[4] {iVar2, iVar3, uVar4, uVar5}, find max
            int[] arr = new int[] { iVar2, iVar3, (int)uVar4, uVar5 };
            int iVar2Max = arr[0];
            if (iVar2Max < arr[1]) iVar2Max = arr[1];
            if (arr.Length > 2)
            {
                long idx = 0;
                while ((long)arr.Length - 2 != idx)
                {
                    int v = arr[2 + idx];
                    if (iVar2Max < v) iVar2Max = v;
                    idx++;
                }
            }

            ulong uVar9 = 0;
            if (iVar2Max < 0)
            {
                int last = param_1.LastIndexOfAny(new char[] { '/', '\\' });
                if (last > 0)
                {
                    int iVar3a = last + 1;
                    param_1 = param_1.Substring(iVar3a);
                }
            }
            else
            {
                int iVar3b = iVar2Max + 0xb;
                uVar9 = (ulong)(iVar2Max < 0 ? 0u : 1u);
                param_1 = param_1.Substring(iVar3b);
            }

            string lVar6 = System.IO.Path.GetExtension(param_1);
            bool isEmpty = string.IsNullOrEmpty(lVar6);
            if (!isEmpty)
            {
                if (param_1 == null || lVar6 == null) throw new NullReferenceException();
                param_1 = param_1.Substring(0, param_1.Length - lVar6.Length);
            }
            return uVar9 != 0;
        }

        // ─── PORT 1-1: I2Utils.IsPlaying ──────────────────────────────────
        // VMA: 0x01c1aa71 — Source: I2Utils.c:10051
        public static bool IsPlaying() => Application.isPlaying;

        // ─── PORT 1-1: I2Utils.GetPath ────────────────────────────────────
        // VMA: 0x01c1aaae — Source: I2Utils.c:10072
        public static string GetPath(Transform param_1)
        {
            if (param_1 == null) throw new NullReferenceException();
            Transform uVar2 = param_1.parent;
            // gốc op_Equality(param_1, 0): Unity null check on `this`
            if (param_1 == null) return null;
            if (uVar2 == null)
            {
                return param_1.name;
            }
            string uVar2Name = GetPath(uVar2);
            string uVar3 = param_1.name;
            return string.Concat(uVar2Name, PathSep, uVar3);
        }

        // ─── PORT 1-1: I2Utils.FindObject (overload by name in active scene) ──
        // VMA: 0x01c1ab60 — Source: I2Utils.c:10110
        public static Transform FindObject(string param_1)
        {
            Scene uVar1 = SceneManager.GetActiveScene();
            return FindObject(uVar1, param_1);
        }

        // ─── PORT 1-1: I2Utils.FindObject (overload by Scene + name) ──────
        // VMA: 0x01c1abaa — Source: I2Utils.c:10134
        public static Transform FindObject(Scene param_1, string param_2)
        {
            GameObject[] lVar3 = param_1.GetRootGameObjects();
            if (lVar3 == null) throw new NullReferenceException();
            uint uVar2 = (uint)lVar3.Length;
            if ((int)uVar2 > 0)
            {
                uint uVar6 = 0;
                do
                {
                    if (uVar2 <= uVar6) throw new IndexOutOfRangeException();
                    GameObject root = lVar3[(int)uVar6];
                    Transform lVar4 = root == null ? null : root.transform;
                    if (lVar4 == null) throw new NullReferenceException();
                    string uVar5 = lVar4.name;
                    if (uVar5 == param_2) return lVar4;
                    string concat = string.Concat(uVar5, PathSep);
                    if (param_2 == null) throw new NullReferenceException();
                    if (param_2.StartsWith(concat, StringComparison.Ordinal))
                    {
                        string rootName = lVar4.name;
                        if (rootName == null) throw new NullReferenceException();
                        string remainder = param_2.Substring(rootName.Length + 1);
                        return FindObject(lVar4, remainder);
                    }
                    uVar6++;
                    uVar2 = (uint)lVar3.Length;
                } while ((int)uVar6 < (int)uVar2);
            }
            return null;
        }

        // ─── PORT 1-1: I2Utils.FindObject (overload by Transform parent + name) ──
        // VMA: 0x01c1acd7 — Source: I2Utils.c:10199
        public static Transform FindObject(Transform param_1, string param_2)
        {
            while (true)
            {
                if (param_1 == null) throw new NullReferenceException();
                int iVar2 = param_1.childCount;
                if (iVar2 < 1) return null;

                Transform lVar4 = null;
                int idx = 0;
                while (idx < iVar2)
                {
                    lVar4 = param_1.GetChild(idx);
                    if (lVar4 == null) throw new NullReferenceException();
                    string uVar5 = lVar4.name;
                    if (uVar5 == param_2) return lVar4;
                    string concat = string.Concat(uVar5, PathSep);
                    if (param_2 == null) throw new NullReferenceException();
                    if (param_2.StartsWith(concat, StringComparison.Ordinal)) break;
                    idx++;
                    int iVar3 = param_1.childCount;
                    if (iVar3 <= idx) return null;
                }
                if (lVar4 == null) return null;
                string lVar6Name = lVar4.name;
                if (lVar6Name == null) throw new NullReferenceException();
                param_2 = param_2.Substring(lVar6Name.Length + 1);
                param_1 = lVar4;
            }
        }

        // ─── PORT 1-1: I2Utils.GetCaptureMatch ────────────────────────────
        // VMA: 0x01c1addc — Source: I2Utils.c:10256
        public static string GetCaptureMatch(Match param_1)
        {
            if (param_1 == null) throw new NullReferenceException();
            GroupCollection groups = param_1.Groups;
            if (groups == null) throw new NullReferenceException();
            int iVar2 = groups.Count;
            for (int i = iVar2 - 1; i >= 0; i--)
            {
                Group g = groups[i];
                if (g == null) throw new NullReferenceException();
                if (g.Success) return g.Value;
            }
            return param_1.Value;
        }

        // ─── PORT 1-1: I2Utils.SendWebRequest ─────────────────────────────
        // VMA: 0x01c1aeae — Source: I2Utils.c:10315
        public static UnityWebRequestAsyncOperation SendWebRequest(UnityWebRequest param_1)
        {
            if (param_1 == null) throw new NullReferenceException();
            return param_1.SendWebRequest();
        }

        // ─── PORT 1-1: I2Utils.FindInParents<T> ───────────────────────────
        // VMA: 0x01eb758c — Source: I2Utils.c:5979
        public static T FindInParents<T>(Transform param_1) where T : Component
        {
            if (param_1 == null) return null;
            T uVar2 = param_1.GetComponent<T>();
            while (true)
            {
                if (uVar2 != null) return uVar2;
                if (param_1 == null) return uVar2;
                if (param_1 == null) throw new NullReferenceException();
                uVar2 = param_1.GetComponent<T>();
                param_1 = param_1.parent;
            }
        }
    }
}
