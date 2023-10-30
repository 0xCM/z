//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static RegOp reg(NativeSize size, RegClassCode @class, RegIndex r)
        => AsmRegs.reg(size, @class, r);
    
    [MethodImpl(Inline), Op]
    public static RegOp reg(RegKind kind)
        => AsmRegs.reg(kind);
}
