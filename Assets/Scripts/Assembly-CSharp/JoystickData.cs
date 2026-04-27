// Class:  JoystickData
// GUID:   3597ae25f9ef46c91dd677af04994d4c (preserved via .meta)
// Source: KTO_DecompiledReference/_root/JoystickData.c (1 method) +
//         KTO_Resources/il2cpp_full_dump/dump.cs (TypeDefIndex 461)
//
// FULL 1-1 PORT 2026-04-25 — verified against Ghidra + dump signature.

public class JoystickData
{
    // Fields (offsets từ dump.cs)
    public float radians;     // 0x10
    public float angle;       // 0x14
    public float angle360;    // 0x18
    public float power;       // 0x1C

    // VMA: 0x01cab4e8 — Source: JoystickData.c:15 (.ctor)
    // gốc body: System_Object___ctor(this, 0); — chain to base.
    public JoystickData() { }
}
