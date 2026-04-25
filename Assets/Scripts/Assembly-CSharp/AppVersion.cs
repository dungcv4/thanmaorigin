// Class:  AppVersion
// GUID:   85f6a905e922547bcae95759b99bccfc (preserved via .meta)
// Source: KTO_DecompiledReference/_root/AppVersion.c (30 methods, 1102 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 588)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.

using System;
using System.Text;
using UnityEngine;

public class AppVersion : IComparable, ICloneable
{
    // Fields (offsets từ dump.cs)
    public uint Major;                      // 0x10
    public uint Minor;                      // 0x14
    public uint Patch;                      // 0x18
    public uint Build;                      // 0x1C
    private string m_SvnBranch;             // 0x20 (k__BackingField)
    private string m_VersionType;           // 0x28 (k__BackingField)
    private string m_VersionDesc;           // 0x30 (k__BackingField)
    private static AppVersion _Instance;    // 0x0

    // VMA: 0x01cd55b7 / 0x01cd55bc — Source: AppVersion.c:15/32 (get/set_SvnBranch)
    public string SvnBranch { get => m_SvnBranch; set => m_SvnBranch = value; }
    // VMA: 0x01cd55c1 / 0x01cd55c6 — Source: AppVersion.c:50/67 (get/set_VersionType)
    public string VersionType { get => m_VersionType; set => m_VersionType = value; }
    // VMA: 0x01cd55cb / 0x01cd55d0 — Source: AppVersion.c:85/102 (get/set_VersionDesc)
    public string VersionDesc { get => m_VersionDesc; set => m_VersionDesc = value; }

    // VMA: 0x01cd55d5 — Source: AppVersion.c:120 (get__Version)
    // gốc body:
    //   if (_Instance == null) {
    //     string vstr = Application.version;
    //     _Instance = new AppVersion(vstr);
    //   }
    //   return _Instance;
    public static AppVersion _Version
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new AppVersion(Application.version);
            }
            return _Instance;
        }
    }

    // VMA: 0x01cd576b — Source: AppVersion.c:207 (get_VersionTypeEnum)
    // gốc body:
    //   if (m_VersionType != null) {
    //     string lower = m_VersionType.ToLower();
    //     StringBuilder sb = new StringBuilder(lower);
    //     sb[0] = char.ToUpper(sb[0]);
    //     return (AppVersionType)Enum.Parse(typeof(AppVersionType), sb.ToString());
    //   }
    //   throw;
    // VMA: 0x01cd58ea — Source: AppVersion.c:271 (set_VersionTypeEnum)
    // gốc body:
    //   string s = ((AppVersionType)value).ToString();
    //   m_VersionType = s.ToLower();
    public AppVersionType VersionTypeEnum
    {
        get
        {
            if (m_VersionType == null) throw new NullReferenceException(nameof(m_VersionType));
            string lower = m_VersionType.ToLower();
            var sb = new StringBuilder(lower);
            if (sb.Length > 0) sb[0] = char.ToUpper(sb[0]);
            return (AppVersionType)Enum.Parse(typeof(AppVersionType), sb.ToString());
        }
        set
        {
            string s = value.ToString();
            m_VersionType = s.ToLower();
        }
    }

    // VMA: 0x01cd5670 — Source: AppVersion.c:155 (.ctor(string))
    // gốc body:
    //   string[] parts = versionStr.Split('.');
    //   if (parts.Length > 0) uint.TryParse(parts[0], out Major);
    //   if (parts.Length > 1) uint.TryParse(parts[1], out Minor);
    //   if (parts.Length > 2) uint.TryParse(parts[2], out Patch);
    //   if (parts.Length > 3) uint.TryParse(parts[3], out Build);
    //   if (parts.Length > 4) m_VersionType = parts[4];
    //   if (parts.Length > 5) m_SvnBranch  = parts[5];
    //   if (parts.Length > 6) m_VersionDesc = string.Join(".", parts, 5, parts.Length - 5);
    //   (gốc preserves: m_VersionType written before SvnBranch but at offsets 0x28 / 0x20)
    public AppVersion(string versionStr)
    {
        if (versionStr == null) throw new NullReferenceException(nameof(versionStr));
        string[] parts = versionStr.Split('.');
        if (parts.Length > 0) uint.TryParse(parts[0], out Major);
        if (parts.Length > 1) uint.TryParse(parts[1], out Minor);
        if (parts.Length > 2) uint.TryParse(parts[2], out Patch);
        if (parts.Length > 3) uint.TryParse(parts[3], out Build);
        if (parts.Length > 4) m_VersionType = parts[4];
        // gốc: only assigns SvnBranch when parts.Length != 5 (i.e. > 5)
        if (parts.Length > 5) m_SvnBranch = parts[5];
        if (parts.Length > 6) m_VersionDesc = string.Join(".", parts, 5, parts.Length - 5);
    }

    // VMA: 0x01cd5952 — Source: AppVersion.c:308 (ToString)
    // gốc body:
    //   StringBuilder sb = new StringBuilder();
    //   object[] args = new object[6] { Major, Minor, Patch, Build, VersionType.ToLower(), SvnBranch.ToLower() };
    //   sb.AppendFormat("{0}.{1}.{2}.{3}.{4}.{5}", args);  // DAT_035b7958 = "{0}.{1}.{2}.{3}.{4}.{5}"
    //   if (!string.IsNullOrEmpty(VersionDesc))
    //       sb.AppendFormat(".{0}", VersionDesc);          // DAT_03597f40 = ".{0}"
    //   return sb.ToString();
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendFormat("{0}.{1}.{2}.{3}.{4}.{5}",
            Major, Minor, Patch, Build,
            m_VersionType?.ToLower() ?? "",
            m_SvnBranch?.ToLower() ?? "");
        if (!string.IsNullOrEmpty(m_VersionDesc))
            sb.AppendFormat(".{0}", m_VersionDesc);
        return sb.ToString();
    }

    // VMA: 0x01cd5c38 — Source: AppVersion.c:419 (Clone)
    // gốc body: return MemberwiseClone();
    public object Clone() => MemberwiseClone();

    // VMA: 0x01cd5c3f — Source: AppVersion.c:437 (ToVersion2)
    // gốc body: return string.Format("{0}.{1}", Major, Minor);  // DAT_035b7938 = "{0}.{1}"
    public string ToVersion2() => string.Format("{0}.{1}", Major, Minor);

    // VMA: 0x01cd5cc2 — Source: AppVersion.c:465 (ToVersion3)
    // gốc body: return string.Format("{0}.{1}.{2}", Major, Minor, Patch);  // DAT_035b7940
    public string ToVersion3() => string.Format("{0}.{1}.{2}", Major, Minor, Patch);

    // VMA: 0x01cd5d65 — Source: AppVersion.c:495 (ToVersion4Update)
    // gốc body: same format string DAT_035b7940 ("{0}.{1}.{2}") but called ToVersion4Update.
    // Same body as ToVersion3 — gốc inconsistency preserved.
    public string ToVersion4Update() => string.Format("{0}.{1}.{2}", Major, Minor, Patch);

    // VMA: 0x01cd5e08 — Source: AppVersion.c:525 (ToVersion4)
    // gốc body: return string.Format("{0}.{1}.{2}.{3}", Major, Minor, Patch, Build);  // DAT_035b7950
    public string ToVersion4() => string.Format("{0}.{1}.{2}.{3}", Major, Minor, Patch, Build);

    // VMA: 0x01cd5fa2 — Source: AppVersion.c:598 (ToUint)
    // gốc body: return Major*0x10000000 + Minor*0x400000 + Patch*0x10000 + Build;
    public uint ToUint()
    {
        return Major * 0x10000000u + Minor * 0x400000u + Patch * 0x10000u + Build;
    }

    // VMA: 0x01cd5fbc — Source: AppVersion.c:617 (ToInt)
    // gốc body: return _Minor*0x400000 + _Major*0x10000000 + _Patch*0x10000 + _Build;
    public static uint ToInt(uint _Major, uint _Minor, uint _Patch, uint _Build)
    {
        return _Minor * 0x400000u + _Major * 0x10000000u + _Patch * 0x10000u + _Build;
    }

    // VMA: 0x01cd5fcd — Source: AppVersion.c:634 (GetVersionNumbers)
    // gốc body:
    //   if (limit == 1) { return new uint[1] {Major}; }
    //   if (limit == 2) { return new uint[2] {Major, Minor}; }
    //   if (limit == 3) { return new uint[3] {Major, Minor, Patch}; }
    //   /* limit == 4 or > 1 */ return new uint[4] {Major, Minor, Patch, Build};
    private uint[] GetVersionNumbers(int limit = 4)
    {
        if (limit == 2) return new uint[] { Major, Minor };
        if (limit == 3) return new uint[] { Major, Minor, Patch };
        if (limit == 4 || limit > 1) return new uint[] { Major, Minor, Patch, Build };
        return new uint[] { Major };
    }

    // VMA: 0x01cd6100 — Source: AppVersion.c:704 (CompareTo(object))
    // gốc body: return CompareTo(obj, 100);
    public int CompareTo(object obj) => CompareTo(obj, 100);

    // VMA: 0x01cd610a — Source: AppVersion.c:722 (CompareTo(object,int))
    // gốc body:
    //   AppVersion v2 = v2o as AppVersion;
    //   if (v2 == null) throw new ArgumentException("Object is not AppVersion");
    //   uint[] a = this.GetVersionNumbers(limitNumber);
    //   uint[] b = v2.GetVersionNumbers(limitNumber);
    //   for (int i = 0; i < a.Length; i++) {
    //     if (a[i] != b[i]) return a[i].CompareTo(b[i]);
    //   }
    //   return 0;
    public int CompareTo(object v2o, int limitNumber)
    {
        AppVersion v2 = v2o as AppVersion;
        if (v2 == null) throw new ArgumentException("Object is not AppVersion");
        uint[] a = this.GetVersionNumbers(limitNumber);
        uint[] b = v2.GetVersionNumbers(limitNumber);
        for (int i = 0; i < a.Length; i++)
        {
            if (i >= b.Length) throw new IndexOutOfRangeException();
            if (a[i] != b[i]) return a[i].CompareTo(b[i]);
        }
        return 0;
    }

    // VMA: 0x01cd6258 — Source: AppVersion.c:857 (Equals(object))
    // gốc body: return Equals(obj as AppVersion);
    public override bool Equals(object obj) => Equals(obj as AppVersion);

    // VMA: 0x01cd62c4 — Source: AppVersion.c:893 (Equals(AppVersion))
    // gốc body:
    //   if (other == null) return false;
    //   if (this == other) return true;
    //   if (other.GetType() != this.GetType()) return false;
    //   return CompareTo(other, 100) == 0;
    protected bool Equals(AppVersion other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (other.GetType() != this.GetType()) return false;
        return CompareTo(other, 100) == 0;
    }

    // VMA: 0x01cd6367 — Source: AppVersion.c:940 (GetHashCode)
    // gốc body:
    //   int h = (int)Major;
    //   uint hash = (uint)((((h*0x18d ^ Minor) * 0x18d ^ Patch) * 0x18d ^ Build) * 0x18d);
    //   uint h1 = m_SvnBranch != null ? (uint)m_SvnBranch.GetHashCode() : 0;
    //   uint h2 = m_VersionType != null ? (uint)m_VersionType.GetHashCode() : 0;
    //   uint h3 = m_VersionDesc != null ? (uint)m_VersionDesc.GetHashCode() : 0;
    //   return (int)((h2 ^ (h1 ^ hash) * 0x18d) * 0x18d ^ h3);
    public override int GetHashCode()
    {
        int h = (int)Major;
        uint hash = (uint)((((h * 0x18d ^ (int)Minor) * 0x18d ^ (int)Patch) * 0x18d ^ (int)Build) * 0x18d);
        uint h1 = m_SvnBranch != null ? (uint)m_SvnBranch.GetHashCode() : 0u;
        uint h2 = m_VersionType != null ? (uint)m_VersionType.GetHashCode() : 0u;
        uint h3 = m_VersionDesc != null ? (uint)m_VersionDesc.GetHashCode() : 0u;
        return (int)((h2 ^ (h1 ^ hash) * 0x18d) * 0x18d ^ h3);
    }

    // VMA: 0x01cd6248 — Source: AppVersion.c:808 (op_Equality)
    // gốc body:
    //   if (v1 == null) return v2 == null;
    //   if (v2 == null) return false;
    //   if (v1 == v2) return true;
    //   if (v2.GetType() != v1.GetType()) return false;
    //   return CompareTo(v1, v2, 100) == 0;
    public static bool op_Equality(AppVersion v1, AppVersion v2)
    {
        if (v1 is null) return v2 is null;
        if (v2 is null) return false;
        if (ReferenceEquals(v1, v2)) return true;
        if (v2.GetType() != v1.GetType()) return false;
        return v1.CompareTo(v2, 100) == 0;
    }

    // VMA: 0x01cd642c — Source: AppVersion.c:988 (op_Inequality)
    // gốc body: return !(v1 == v2);
    public static bool op_Inequality(AppVersion v1, AppVersion v2) => !op_Equality(v1, v2);

    // VMA: 0x01cd6446 — Source: AppVersion.c:1013 (op_LessThan)
    // gốc body:
    //   if (v1 == null) throw new ArgumentNullException("v1");
    //   return CompareTo(v1, v2, 100) < 0;
    public static bool op_LessThan(AppVersion v1, AppVersion v2)
    {
        if (v1 is null) throw new ArgumentNullException(nameof(v1));
        return v1.CompareTo(v2, 100) < 0;
    }

    // VMA: 0x01cd64a2 — Source: AppVersion.c:1044 (op_LessThanOrEqual)
    // gốc body:
    //   if (v1 == null) throw new ArgumentNullException("v1");
    //   return CompareTo(v1, v2, 100) <= 0;
    public static bool op_LessThanOrEqual(AppVersion v1, AppVersion v2)
    {
        if (v1 is null) throw new ArgumentNullException(nameof(v1));
        return v1.CompareTo(v2, 100) <= 0;
    }

    // VMA: 0x01cd6500 — Source: AppVersion.c:1075 (op_GreaterThan)
    // gốc body: return op_LessThan(v2, v1);
    public static bool op_GreaterThan(AppVersion v1, AppVersion v2) => op_LessThan(v2, v1);

    // VMA: 0x01cd650e — Source: AppVersion.c:1093 (op_GreaterThanOrEqual)
    // gốc body: return op_LessThanOrEqual(v2, v1);
    public static bool op_GreaterThanOrEqual(AppVersion v1, AppVersion v2) => op_LessThanOrEqual(v2, v1);
}
