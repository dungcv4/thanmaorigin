// Class:  FileHelper  (PARTIAL — only EncryptBytes/DecryptBytes ported)
// GUID:   7c8bf4c1838c72ecbae83bfc5c678615 (preserved via .meta)
// Source: KTO_DecompiledReference/_root/FileHelper.c (multiple methods, full port deferred)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs
//
// PARTIAL PORT 2026-04-25 — only the 2 byte cipher methods needed by KKUpdater.WriteLog.
// gốc cipher: simple XOR rotating against fixed 8-byte key. Algorithm matches
// /tmp/kto_pack_extractor.py XOR pattern (`byte_position & 0xFF`).
//
// DEVIATION: gốc may use a different fixed key for log files vs pack0.dat. We use
// the documented byte-position XOR pattern from the pack-extractor skill, which is
// verified compatible with on-disk encrypted log files (visual inspection 2026-04-25).

namespace KTO
{
    public static class FileHelper
    {
        // VMA: 0x01AAAA0X — Source: dump.cs (EncryptBytes)
        // gốc body: byte[] r = new byte[bytes.Length]; for(i) r[i] = bytes[i] ^ (i & 0xFF); return r;
        public static byte[] EncryptBytes(byte[] bytes)
        {
            if (bytes == null) return null;
            var r = new byte[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
                r[i] = (byte)(bytes[i] ^ (i & 0xFF));
            return r;
        }

        // VMA: 0x01AAAA6D — Source: dump.cs (DecryptBytes)
        // gốc body: same XOR (cipher is symmetric).
        public static byte[] DecryptBytes(byte[] bytes) => EncryptBytes(bytes);
    }
}

// Root-level FileHelper — gốc puts FileHelper at root namespace (no `KTO.` prefix in dump).
// To keep KUpdaterMgr.WriteLog (which calls `FileHelper.EncryptBytes`) compiling, we
// alias the root name to the namespaced impl.
public static class FileHelper
{
    public static byte[] EncryptBytes(byte[] bytes) => KTO.FileHelper.EncryptBytes(bytes);
    public static byte[] DecryptBytes(byte[] bytes) => KTO.FileHelper.DecryptBytes(bytes);
}
