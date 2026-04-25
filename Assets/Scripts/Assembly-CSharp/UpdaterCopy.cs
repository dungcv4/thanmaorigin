// Class:  KKUpdater.UpdaterCopy
// GUID:   ad72fa5e15a44ae3498ee4d9937c997f (preserved via .meta)
// Source: KTO_DecompiledReference/KKUpdater/UpdaterCopy.c (3 methods, 130 LOC)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1383)
//
// FULL 1-1 PORT 2026-04-25 — every method body verified against Ghidra C decompile.

using System.IO;

namespace KKUpdater
{
    public class UpdaterCopy
    {
        // VMA: 0x01bc91cf — Source: KTO_DecompiledReference/KKUpdater/UpdaterCopy.c:15 (CopyDir)
        // gốc body:
        //   if (!Directory.Exists(fromDir)) return;
        //   if (!Directory.Exists(toDir)) Directory.CreateDirectory(toDir);
        //   string[] files = Directory.GetFiles(fromDir);
        //   foreach (string f in files) {
        //     string name = Path.GetFileName(f);
        //     string dst = Path.Combine(toDir, name);
        //     File.Copy(f, dst, overwrite: true);
        //   }
        //   string[] subdirs = Directory.GetDirectories(fromDir);
        //   foreach (string d in subdirs) {
        //     string name = Path.GetFileName(d);
        //     Path.Combine(toDir, name);   // gốc preserved: result discarded
        //     CopyDir(d);                   // gốc bug: only 1 arg passed; recursion misses toDir
        //   }
        // ⚠ DEVIATION: subdir recursion call passes the proper combined toDir to fix gốc bug.
        public static void CopyDir(string fromDir, string toDir)
        {
            if (!Directory.Exists(fromDir)) return;
            if (!Directory.Exists(toDir)) Directory.CreateDirectory(toDir);

            string[] files = Directory.GetFiles(fromDir);
            for (int i = 0; i < files.Length; i++)
            {
                string f = files[i];
                string name = Path.GetFileName(f);
                string dst = Path.Combine(toDir, name);
                File.Copy(f, dst, true);
            }

            string[] subdirs = Directory.GetDirectories(fromDir);
            for (int i = 0; i < subdirs.Length; i++)
            {
                string d = subdirs[i];
                string name = Path.GetFileName(d);
                // gốc preserved: Path.Combine result discarded in expression-only stmt.
                Path.Combine(toDir, name);
                CopyDir(d, Path.Combine(toDir, name)); // DEVIATION — pass combined path.
            }
        }

        // VMA: 0x01bc9337 — Source: KTO_DecompiledReference/KKUpdater/UpdaterCopy.c:96 (MoveDir)
        // gốc body:
        //   if (!Directory.Exists(fromDir)) return;
        //   CopyDir(fromDir, toDir);
        //   Directory.Delete(fromDir, recursive: true);
        public static void MoveDir(string fromDir, string toDir)
        {
            if (!Directory.Exists(fromDir)) return;
            CopyDir(fromDir, toDir);
            Directory.Delete(fromDir, true);
        }

        // VMA: 0x01bc9375 — Source: KTO_DecompiledReference/KKUpdater/UpdaterCopy.c:121 (.ctor)
        // gốc body: System_Object___ctor(this, 0); — chain to base.
        public UpdaterCopy() { }
    }
}
