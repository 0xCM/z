//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Defines an instance of a JMP r/m64 instruction: Jump near, absolute indirect, RIP = 64-Bit offset from register or memory
    /// </summary>
    /// <example>
    /// jmp qword ptr [rip+3ffah]                     # 0000h  | 6   | ff 25 fa 3f 00 00                | (JMP r/m64) = FF /4
    /// </example>
    [StructLayout(LayoutKind.Sequential,Size = 16)]
    public readonly record struct Jmp64
    {
        
    }
}
