//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static AsmOperand op(RegKind kind)
        => AsmRegs.reg(kind);

    [MethodImpl(Inline), Op]
    public static AsmOperand op(RegOp target, RegIndex index, RegMaskKind kind)
        => mask(target, index, kind);
}
