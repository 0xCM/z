//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using Operands;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static AsmOperand op(RegKind kind)
            => AsmRegs.reg(kind);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(RegOp target, RegIndex mask, RegMaskKind kind)
            => regmask(target,mask,kind);
    }
}