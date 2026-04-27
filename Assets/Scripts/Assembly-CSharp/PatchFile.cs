// Class:  KKUpdater.PatchFile
// GUID:   (no existing .meta — new file)
// Source: KTO_DecompiledReference/KKUpdater/PatchFile.c (1 method)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1371)
//
// FULL 1-1 PORT 2026-04-25 — verified against Ghidra + Cpp2IL stub.

namespace KKUpdater
{
    public class PatchFile
    {
        // Fields (offsets từ dump.cs)
        public string date;     // 0x10
        public string MD5;      // 0x18
        public int size;        // 0x20
        public int ver;         // 0x24

        // VMA: 0x01bc7919 — Source: KTO_DecompiledReference/KKUpdater/PatchFile.c:15 (.ctor)
        // gốc body: System_Object___ctor(this, 0); — chain to base.
        public PatchFile() { }
    }
}
