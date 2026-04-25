// Class:  KKUpdater.UpdaterException
// GUID:   80b73e6aaa05184b8c1dd66fa546249f (preserved via .meta)
// Source: KTO_DecompiledReference/KKUpdater/UpdaterException.c (1 method)
// Dump:   KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 1384)
//
// FULL 1-1 PORT 2026-04-25 — verified against Ghidra + Cpp2IL stub.
// Inherits System.Exception (gốc body just chains to base ctor).

using System;

namespace KKUpdater
{
    // VMA: 0x01AC937C — Source: KTO_DecompiledReference/KKUpdater/UpdaterException.c:15 (.ctor)
    // gốc body: System_Exception___ctor(this, message, 0); — chain to base.
    public class UpdaterException : Exception
    {
        public UpdaterException(string message) : base(message) { }
    }
}
