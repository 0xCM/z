//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

using C = RegClassCode;
using W = NativeSizeCode;

partial struct AsmRegs
{
    [MethodImpl(Inline), Op]
    public static RegOp gp8(RegIndexCode r)
        => AsmRegBits.reg(W.W8, C.GP, r);

    [MethodImpl(Inline), Op]
    public static RegOp gp16(RegIndexCode r)
        => AsmRegBits.reg(W.W16, C.GP, r);

    [MethodImpl(Inline), Op]
    public static RegOp gp32(RegIndexCode r)
        => AsmRegBits.reg(W.W32, C.GP, r);

    [MethodImpl(Inline), Op]
    public static RegOp gp64(RegIndexCode r)
        => AsmRegBits.reg(W.W64, C.GP, r);

    [MethodImpl(Inline), Op]
    public static RegOp mask(RegIndexCode r)
        => AsmRegBits.reg(W.W64, C.MASK, r);

    [MethodImpl(Inline), Op]
    public static RegOp v128(RegIndexCode r)
        => AsmRegBits.reg(W.W128, C.XMM, r);

    [MethodImpl(Inline), Op]
    public static RegOp v256(RegIndexCode r)
        => AsmRegBits.reg(W.W128, C.YMM, r);

    [MethodImpl(Inline), Op]
    public static RegOp v512(RegIndexCode r)
        => AsmRegBits.reg(W.W128, C.ZMM, r);

    [MethodImpl(Inline), Op]
    public static RegOp rK(RegIndexCode r)
        => AsmRegBits.reg(W.W64, C.MASK, r);

    [MethodImpl(Inline), Op]
    public static RegOp rK8(RegIndexCode r)
        => AsmRegBits.reg(W.W8, C.MASK, r);

    [MethodImpl(Inline), Op]
    public static RegOp rK16(RegIndexCode r)
        => AsmRegBits.reg(W.W16, C.MASK, r);

    [MethodImpl(Inline), Op]
    public static RegOp rK32(RegIndexCode r)
        => AsmRegBits.reg(W.W32, C.MASK, r);

    [MethodImpl(Inline), Op]
    public static RegOp rK64(RegIndexCode r)
        => AsmRegBits.reg(W.W64, C.MASK, r);

    [MethodImpl(Inline), Op]
    public static RegOp reg(RegKind kind)
        => new ((ushort)kind);

    [MethodImpl(Inline), Op]
    public static RegOp reg(in AsmOperand src)
        => new (first(span16u(src.Data)));

    [MethodImpl(Inline), Op]
    public static RegOp sptr(RegIndexCode r)
        => AsmRegBits.reg(W.W16, C.SPTR, r);

    [MethodImpl(Inline), Op]
    public static RegOp seg(RegIndexCode r)
        => AsmRegBits.reg(W.W16, C.SEG, r);
}
