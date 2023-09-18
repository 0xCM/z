//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using Operands;

partial struct asm
{
    [MethodImpl(Inline), Op]
    public static FarPtr farptr(Address16 selector, long offset)
        => new FarPtr(selector,offset);

    [MethodImpl(Inline), Op]
    public static NearPtr nearptr(MemoryAddress address)
        => new NearPtr(address);

    [MethodImpl(Inline), Op]
    public static m8 ptr8(r64 reg)
        => mem8(reg);

    [MethodImpl(Inline), Op]
    public static m16 ptr16(r64 reg)
        => mem16(reg);

    [MethodImpl(Inline), Op]
    public static m32 ptr32(r64 reg)
        => mem32(reg);

    [MethodImpl(Inline), Op]
    public static m64 ptr64(r64 reg)
        => mem64(reg);

    [MethodImpl(Inline), Op]
    public static m128 ptr128(r64 reg)
        => mem128(reg);

    [MethodImpl(Inline), Op]
    public static m256 ptr256(r64 reg)
        => mem256(reg);

    [MethodImpl(Inline), Op]
    public static m512 ptr512(r64 reg)
        => mem512(reg);
}
