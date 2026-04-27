// Class:  KKUpdater.ReinstallException
// Source: KTO_DecompiledReference/KKUpdater/ReinstallException.c (1 method)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1388)
//
// FULL 1-1 PORT 2026-04-25 — verified against Ghidra + Cpp2IL stub.
// Thrown when remote MainVersion (e.g. "2.21.0") is greater than local — requires APK reinstall.

using System;

namespace KKUpdater
{
    // VMA: 0x01AC9463 — Source: KTO_DecompiledReference/KKUpdater/ReinstallException.c:15 (.ctor)
    // gốc body: System_Exception___ctor(this, 0); — chain to base parameterless ctor.
    public class ReinstallException : Exception
    {
        public ReinstallException() : base() { }
    }
}
