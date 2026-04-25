// Class:  KKUpdater.RestartException
// Source: KTO_DecompiledReference/KKUpdater/RestartException.c (1 method)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1387)
//
// FULL 1-1 PORT 2026-04-25 — verified against Ghidra + Cpp2IL stub.
// Thrown when patch flow requires app restart.

using System;

namespace KKUpdater
{
    // VMA: 0x01AC9420 — Source: KTO_DecompiledReference/KKUpdater/RestartException.c:15 (.ctor)
    // gốc body: System_Exception___ctor(this, 0); — chain to base parameterless ctor.
    public class RestartException : Exception
    {
        public RestartException() : base() { }
    }
}
