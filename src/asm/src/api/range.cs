//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial struct asm
{
    [MethodImpl(Inline)]
    public static ImmRange range(Imm min, Imm max)
        => new ImmRange(min,max);

    [MethodImpl(Inline)]
    public static RegRange range(RegClass @class, NativeSize size, RegIndex min, RegIndex max)
        => new RegRange(@class, size, min, max);
}
