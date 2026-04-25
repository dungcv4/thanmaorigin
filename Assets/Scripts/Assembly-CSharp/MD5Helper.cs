// Class:  KKUpdater.Md5Helper  (filename keeps "MD5Helper" to preserve GUID)
// GUID:   1ebd53768dd0cd073d4231b43ac385ec (preserved via .meta)
// Source: KTO_DecompiledReference/KKUpdater/Md5Helper.c (5 methods, 373 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1369)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.

using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace KKUpdater
{
    public static class Md5Helper
    {
        // VMA: 0x01bc7508 — Source: KTO_DecompiledReference/KKUpdater/Md5Helper.c:354 (.cctor)
        // gốc body: Md5Hash = MD5.Create();
        private static readonly MD5 Md5Hash = MD5.Create();

        // VMA: 0x01bc6ba5 — Source: KTO_DecompiledReference/KKUpdater/Md5Helper.c:15 (GetSaltBytes)
        // gốc body:
        //   if (string.IsNullOrEmpty(salt)) return null;
        //   return Encoding.UTF8.GetBytes(salt);
        private static byte[] GetSaltBytes(string salt)
        {
            if (string.IsNullOrEmpty(salt)) return null;
            return Encoding.UTF8.GetBytes(salt);
        }

        // VMA: 0x01bc6be4 — Source: KTO_DecompiledReference/KKUpdater/Md5Helper.c:54 (Md5String)
        // gốc body:
        //   using (MemoryStream ms = new MemoryStream()) {
        //     byte[] strBytes = Encoding.UTF8.GetBytes(str);
        //     ms.Write(strBytes, 0, strBytes.Length);
        //     byte[] saltBytes = GetSaltBytes(salt);
        //     if (saltBytes != null) ms.Write(saltBytes, 0, salt.Length);  // gốc bug: salt.Length not saltBytes.Length
        //     ms.Position = 0;
        //     byte[] hash = Md5Hash.ComputeHash(ms);
        //     return _ToHexDigest(hash);
        //   }
        public static string Md5String(string str, string salt)
        {
            using (var ms = new MemoryStream())
            {
                byte[] strBytes = Encoding.UTF8.GetBytes(str);
                ms.Write(strBytes, 0, strBytes.Length);
                byte[] saltBytes = GetSaltBytes(salt);
                if (saltBytes != null)
                {
                    // gốc bug preserved: uses salt.Length (chars) not saltBytes.Length (utf-8 bytes).
                    ms.Write(saltBytes, 0, salt.Length);
                }
                ms.Position = 0;
                byte[] hash = Md5Hash.ComputeHash(ms);
                return _ToHexDigest(hash);
            }
        }

        // VMA: 0x01bc6e8b — Source: KTO_DecompiledReference/KKUpdater/Md5Helper.c:153 (_ToHexDigest)
        // gốc body:
        //   StringBuilder sb = new StringBuilder();
        //   for (int i = 0; i < hash.Length; i++) sb.Append(hash[i].ToString("x2"));
        //   return sb.ToString();
        private static string _ToHexDigest(byte[] hash)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));
            return sb.ToString();
        }

        // VMA: 0x01bc6f5d — Source: KTO_DecompiledReference/KKUpdater/Md5Helper.c:219 (Md5File)
        // gốc body:
        //   using (FileStream fs = File.OpenRead(fileName)) {
        //     byte[] saltBytes = GetSaltBytes(salt);
        //     byte[] hash;
        //     if (saltBytes == null) {
        //       hash = Md5Hash.ComputeHash(fs);
        //     } else {
        //       using (MemoryStream saltMs = new MemoryStream(saltBytes))
        //       using (MergedStream merged = new MergedStream(fs, saltMs)) {
        //         saltMs.Position = 0;
        //         hash = Md5Hash.ComputeHash(merged);
        //       }
        //     }
        //     return _ToHexDigest(hash);
        //   }
        public static string Md5File(string fileName, string salt)
        {
            using (var fs = File.OpenRead(fileName))
            {
                byte[] saltBytes = GetSaltBytes(salt);
                byte[] hash;
                if (saltBytes == null)
                {
                    hash = Md5Hash.ComputeHash(fs);
                }
                else
                {
                    using (var saltMs = new MemoryStream(saltBytes))
                    using (var merged = new MergedStream(fs, saltMs))
                    {
                        saltMs.Position = 0;
                        hash = Md5Hash.ComputeHash(merged);
                    }
                }
                return _ToHexDigest(hash);
            }
        }
    }
}
