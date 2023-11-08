//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using Operands;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static xmm xmm(RegIndex r)
        => r.Code;

    [MethodImpl(Inline), Op]
    public static ymm ymm(RegIndex r)
        => r.Code;

    [MethodImpl(Inline), Op]
    public static zmm zmm(RegIndex r)
        => r.Code;

    [MethodImpl(Inline), Op]
    public static RegOp reg(NativeSize size, RegClassCode @class, RegIndex r)
        => AsmRegs.reg(size, @class, r);
    
    [MethodImpl(Inline), Op]
    public static RegOp reg(RegKind kind)
        => AsmRegs.reg(kind);
}
