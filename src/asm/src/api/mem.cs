//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using Operands;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static MemOp mem(NativeSize size, RegOp @base)
        => new (size, address(@base, RegOp.Empty, 0));

    [MethodImpl(Inline), Op]
    public static MemOp mem(NativeSize size, RegOp @base, RegOp index)
        => new (size, address(@base, index, 0));

    [MethodImpl(Inline), Op]
    public static MemOp mem(NativeSize size, RegOp @base, RegOp index, Disp disp)
        => new (size, address(@base, index, ScaleFactor.S1, disp));

    [MethodImpl(Inline), Op]
    public static MemOp mem(NativeSize size, RegOp @base, MemoryScale scale, RegOp index)
        => new (size, address(@base, index, scale));

    [MethodImpl(Inline), Op]
    public static MemOp mem(NativeSize size, RegOp @base, MemoryScale scale, RegOp index, Disp disp)
        => new (size, address(@base, index, scale, disp));

    [MethodImpl(Inline), Op]
    public static m8 mem8(RegOp @base)
        => new (@base, RegOp.Empty, 0, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m8 mem8(AsmAddress address)
        => new (address);

    [MethodImpl(Inline), Op]
    public static m8 mem8(RegOp @base, RegOp index)
        => new (@base, index, ScaleFactor.S1, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m8 mem8(RegOp @base,  MemoryScale scale, RegOp index)
        => new (@base, index, scale, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m8 mem8(RegOp @base, MemoryScale scale, RegOp index, Disp disp)
        => new (@base, index, scale, disp);

    [MethodImpl(Inline), Op]
    public static m16 mem16(RegOp @base)
        => new (@base, RegOp.Empty, 0, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m16 mem16(AsmAddress address)
        => new (address);

    [MethodImpl(Inline), Op]
    public static m16 mem16(RegOp @base, RegOp index)
        => new (@base, index, ScaleFactor.S1, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m16 mem16(RegOp @base, MemoryScale scale, RegOp index)
        => new (@base, index, scale, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m16 mem16(RegOp @base, MemoryScale scale, RegOp index, Disp disp)
        => new (@base, index, scale, disp);

    [MethodImpl(Inline), Op]
    public static m32 mem32(RegOp @base)
        => new (@base, RegOp.Empty, 0, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m32 mem32(AsmAddress address)
        => new (address);

    [MethodImpl(Inline), Op]
    public static m32 mem32(RegOp @base, RegOp index)
        => new (@base, index, ScaleFactor.S1, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m32 mem32(RegOp @base, MemoryScale scale, RegOp index)
        => new (@base, index, scale, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m32 mem32(RegOp @base, MemoryScale scale, RegOp index, Disp disp)
        => new (@base, index, scale, disp);

    [MethodImpl(Inline), Op]
    public static m64 mem64(RegOp @base)
        => new (@base, RegOp.Empty, 0, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m64 mem64(AsmAddress address)
        => new (address);

    [MethodImpl(Inline), Op]
    public static m64 mem64(RegOp @base, RegOp index)
        => new (@base, index, 0, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m64 mem64(RegOp @base, MemoryScale scale, RegOp index)
        => new (@base, index, scale, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m64 mem64(RegOp @base, MemoryScale scale, RegOp index, Disp disp)
        => new (@base, index, scale, disp);

    [MethodImpl(Inline), Op]
    public static m128 mem128(AsmAddress address)
        => new (address);

    [MethodImpl(Inline), Op]
    public static m128 mem128(RegOp @base)
        => new (@base, RegOp.Empty, 0, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m128 mem128(RegOp @base, RegOp index)
        => new (@base, index, 0, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m128 mem128(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        => new (@base, index, scale, disp);

    [MethodImpl(Inline), Op]
    public static m256 mem256(AsmAddress address)
        => new (address);

    [MethodImpl(Inline), Op]
    public static m256 mem256(RegOp @base)
        => new (@base, RegOp.Empty, 0, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m256 mem256(RegOp @base, RegOp index)
        => new (@base, index, ScaleFactor.S1, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m256 mem256(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        => new (@base, index, scale, disp);

    [MethodImpl(Inline), Op]
    public static m512 mem512(AsmAddress address)
        => new (address);

    [MethodImpl(Inline), Op]
    public static m512 mem512(RegOp @base)
        => new (@base, RegOp.Empty, 0, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m512 mem512(RegOp @base, RegOp index)
        => new (@base, index, ScaleFactor.S1, Disp.Zero);

    [MethodImpl(Inline), Op]
    public static m512 mem512(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
        => new (@base,index,scale,disp);
}
