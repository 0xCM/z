//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using Asm.Operands;

using static sys;

[ApiHost]
public class AsmSpecs
{
    const NumericKind Closure = UnsignedInts;

    // and r32, imm32 | 81 /4 id
    [MethodImpl(Inline), Op]
    public static AsmInstruction and(r32 a, Imm32 b)
        => asm.inst("and", a, b);

}
