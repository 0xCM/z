//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static RegOp reg(NativeSizeCode width, RegClassCode @class, RegIndex r)
        => AsmRegs.reg(width, @class,r);

    [MethodImpl(Inline), Op]
    public static RegOp reg(RegKind kind)
        => AsmRegs.reg(kind);
}
