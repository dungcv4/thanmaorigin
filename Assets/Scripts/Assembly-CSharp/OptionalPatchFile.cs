// Class:  KKUpdater.OptionalPatchFile
// GUID:   (no existing .meta — new file)
// Source: KTO_DecompiledReference/KKUpdater/OptionalPatchFile.c (1 method)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1372)
//
// FULL 1-1 PORT 2026-04-25 — verified against Ghidra + Cpp2IL stub.
// Inherits PatchFile (priority field added at offset 0x28).

namespace KKUpdater
{
    public class OptionalPatchFile : PatchFile
    {
        public int priority;    // 0x28

        // VMA: 0x01bc7920 — Source: KTO_DecompiledReference/KKUpdater/OptionalPatchFile.c:15 (.ctor)
        // gốc body: System_Object___ctor(this, 0); — chain to base.
        public OptionalPatchFile() : base() { }
    }
}
