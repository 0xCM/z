//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Defines an instance of a JMP r/m64 instruction: Jump near, absolute indirect, RIP = 64-Bit offset from register or memory
/// </summary>
/// <example>
/// jmp qword ptr [rip+3ffah]                     # 0000h  | 6   | ff 25 fa 3f 00 00                | (JMP r/m64) = FF /4
/// </example>
[StructLayout(LayoutKind.Sequential)]
public readonly record struct JmpRm64
{
    public readonly MemoryAddress Rip;

    public readonly ulong Offset;

    [MethodImpl(Inline)]
    public JmpRm64(MemoryAddress rip, ulong offset)
    {
        Rip = rip;
        Offset = offset;
    }
}

