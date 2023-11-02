//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;
using static Asm.RegFacets;

using Operands;
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
    public static r8 gp8(I r)
        => r;

    [MethodImpl(Inline), Op]
    public static r16 gp16(I r)
        => r;

    [MethodImpl(Inline), Op]
    public static r32 gp32(I r)
        => r;

    [MethodImpl(Inline), Op]
    public static r64 gp64(I r)
        => r;

    [MethodImpl(Inline), Op]
    public static rK mask(I r)
        => r;

    [MethodImpl(Inline), Op]
    public static rKz zmask(I r)
        => r;

    [MethodImpl(Inline), Op]
    public static xmm xmm(I r)
        => r;

    [MethodImpl(Inline), Op]
    public static ymm ymm(I r)
        => r;

    [MethodImpl(Inline), Op]
    public static zmm zmm(I r)
        => r;

    [MethodImpl(Inline), Op]
    public static rSeg seg(I r)
        => r;
}
