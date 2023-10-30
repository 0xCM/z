//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial struct AsmRegs
{
    /// <summary>
    /// Determines whether a specified register index code is within the inclusive range [0,31]
    /// </summary>
    /// <param name="src"></param>
    [MethodImpl(Inline), Op]
    public static bit invalid(RegIndexCode src)
        => (uint)src >= 32;

    [MethodImpl(Inline), Op]
    public static bit valid(RegIndexCode src)
        => (uint)src <= 31;
}
