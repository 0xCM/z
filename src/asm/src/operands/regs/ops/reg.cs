//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static Asm.RegFacets;

using C = RegClassCode;
using W = NativeSizeCode;
using I = RegIndexCode;

partial struct AsmRegs
{
    [MethodImpl(Inline), Op]
    public static RegKind kind(W w, C k, I i)
        => (RegKind)(((uint)i  << IndexField) | ((uint)k << ClassField) | ((uint)w << WidthField));

    [MethodImpl(Inline), Op]
    public static RegOp reg(RegKind kind)
        => new ((ushort)kind);

    [MethodImpl(Inline), Op]
    public static RegOp reg(W w, C k, I i)
        => new (kind(w, k, i));

    [MethodImpl(Inline), Op]
    public static RegOp reg(in AsmOperand src)
        => new (first(span16u(src.Data)));

    [MethodImpl(Inline), Op]
    public static RegOp gp8(I r)
        => reg(W.W8, C.GP, r);

    [MethodImpl(Inline), Op]
    public static RegOp gp16(I r)
        => reg(W.W16, C.GP, r);

    [MethodImpl(Inline), Op]
    public static RegOp gp32(I r)
        => reg(W.W32, C.GP, r);

    [MethodImpl(Inline), Op]
    public static RegOp gp64(I r)
        => reg(W.W64, C.GP, r);

    [MethodImpl(Inline), Op]
    public static RegOp mask(I r)
        => reg(W.W64, C.MASK, r);

    [MethodImpl(Inline), Op]
    public static RegOp v128(I r)
        => reg(W.W128, C.XMM, r);

    [MethodImpl(Inline), Op]
    public static RegOp v256(I r)
        => reg(W.W128, C.YMM, r);

    [MethodImpl(Inline), Op]
    public static RegOp v512(I r)
        => reg(W.W128, C.ZMM, r);

    [MethodImpl(Inline), Op]
    public static RegOp rK(I r)
        => reg(W.W64, C.MASK, r);

    [MethodImpl(Inline), Op]
    public static RegOp rK8(I r)
        => reg(W.W8, C.MASK, r);

    [MethodImpl(Inline), Op]
    public static RegOp rK16(I r)
        => reg(W.W16, C.MASK, r);

    [MethodImpl(Inline), Op]
    public static RegOp rK32(I r)
        => reg(W.W32, C.MASK, r);

    [MethodImpl(Inline), Op]
    public static RegOp rK64(I r)
        => reg(W.W64, C.MASK, r);

    [MethodImpl(Inline), Op]
    public static RegOp sptr(I r)
        => reg(W.W16, C.SPTR, r);

    [MethodImpl(Inline), Op]
    public static RegOp seg(I r)
        => reg(W.W16, C.SEG, r);
}
