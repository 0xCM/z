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
        => new (selector,offset);

    [MethodImpl(Inline), Op]
    public static NearPtr nearptr(MemoryAddress address)
        => new (address);

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

    [MethodImpl(Inline), Op]
    public static AsmPointerKind ptr(NativeSizeCode src)
        => src switch {
        NativeSizeCode.W8 => AsmPointerKind.@byte,
        NativeSizeCode.W16 => AsmPointerKind.word,
        NativeSizeCode.W32 => AsmPointerKind.dword,
        NativeSizeCode.W64 => AsmPointerKind.qword,
        NativeSizeCode.W128 => AsmPointerKind.xmmword,
        NativeSizeCode.W256 => AsmPointerKind.ymmword,
        NativeSizeCode.W512 => AsmPointerKind.zmmword,
            _ => AsmPointerKind.@byte
        };

}
