//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

/// <summary>
/// Defines helpers to detect basic block exits
/// Reference: https://github.com/microsoft/Detours/blob/5f674df62c0e1bbed82ebf86b70f04d13d4acb91/samples/disas/disas.cpp
/// </summary>
[ApiHost]
public readonly struct AsmByteQuery
{
    [MethodImpl(Inline), Op]
    public static bool jmp(byte b0, byte b1)
        => b0 == JmpRel8.OpCode
        || b0 == JmpRel32.OpCode
        || b0 == 0xEA 
        || b0 == 0xFF && b1==0x25
        ;

    [MethodImpl(Inline), Op]
    public static bool ret(byte b0, byte b1)
        => b0 == 0xC3 && b1 == 0x00
            || b0 == 0xCB
            || b0 == 0XC2
            || b0 == 0xCA
        ;
}
