// Class:  KKUpdater.CancelException
// Source: KTO_DecompiledReference/KKUpdater/CancelException.c (1 method)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1386)
//
// FULL 1-1 PORT 2026-04-25 — verified against Ghidra + Cpp2IL stub.
// Thrown when user cancels download.

using System;

namespace KKUpdater
{
    // VMA: 0x01AC646C — Source: KTO_DecompiledReference/KKUpdater/CancelException.c:15 (.ctor)
    // gốc body: System_Exception___ctor(this, 0); — chain to base parameterless ctor.
    public class CancelException : Exception
    {
        public CancelException() : base() { }
    }
}
