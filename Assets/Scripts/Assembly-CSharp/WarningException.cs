// Class:  KKUpdater.WarningException
// Source: KTO_DecompiledReference/KKUpdater/WarningException.c (1 method)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1385)
//
// FULL 1-1 PORT 2026-04-25 — verified against Ghidra + Cpp2IL stub.
// Used when network down during update check.

using System;

namespace KKUpdater
{
    // VMA: 0x01AC93CE — Source: KTO_DecompiledReference/KKUpdater/WarningException.c:15 (.ctor)
    // gốc body: System_Exception___ctor(this, noNetworkToUpdate, 0); — chain to base.
    public class WarningException : Exception
    {
        public WarningException(string noNetworkToUpdate) : base(noNetworkToUpdate) { }
    }
}
