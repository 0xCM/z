//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static MemOp mem(NativeSize size, RegOp @base)
            => new MemOp(size, address(@base, RegOp.Empty, 0));

        [MethodImpl(Inline), Op]
        public static MemOp mem(NativeSize size, RegOp @base, RegOp index)
            => new MemOp(size, address(@base, index, 0));

        [MethodImpl(Inline), Op]
        public static MemOp mem(NativeSize size, RegOp @base, RegOp index, Disp disp)
            => new MemOp(size, address(@base, index, ScaleFactor.S1, disp));

        [MethodImpl(Inline), Op]
        public static MemOp mem(NativeSize size, RegOp @base, MemoryScale scale, RegOp index)
            => new MemOp(size, address(@base, index, scale));

        [MethodImpl(Inline), Op]
        public static MemOp mem(NativeSize size, RegOp @base, MemoryScale scale, RegOp index, Disp disp)
            => new MemOp(size, address(@base, index, scale, disp));

        [MethodImpl(Inline), Op]
        public static m8 mem8(RegOp @base)
            => new m8(@base, RegOp.Empty, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m8 mem8(AsmAddress address)
            => new m8(address);

        [MethodImpl(Inline), Op]
        public static m8 mem8(RegOp @base, RegOp index)
            => new m8(@base, index, ScaleFactor.S1, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m8 mem8(RegOp @base,  MemoryScale scale, RegOp index)
            => new m8(@base, index, scale, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m8 mem8(RegOp @base, MemoryScale scale, RegOp index, Disp disp)
            => new m8(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m16 mem16(RegOp @base)
            => new m16(@base, RegOp.Empty, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m16 mem16(AsmAddress address)
            => new m16(address);

        [MethodImpl(Inline), Op]
        public static m16 mem16(RegOp @base, RegOp index)
            => new m16(@base, index, ScaleFactor.S1, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m16 mem16(RegOp @base, MemoryScale scale, RegOp index)
            => new m16(@base, index, scale, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m16 mem16(RegOp @base, MemoryScale scale, RegOp index, Disp disp)
            => new m16(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m32 mem32(RegOp @base)
            => new m32(@base, RegOp.Empty, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m32 mem32(AsmAddress address)
            => new m32(address);

        [MethodImpl(Inline), Op]
        public static m32 mem32(RegOp @base, RegOp index)
            => new m32(@base, index, ScaleFactor.S1, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m32 mem32(RegOp @base, MemoryScale scale, RegOp index)
            => new m32(@base, index, scale, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m32 mem32(RegOp @base, MemoryScale scale, RegOp index, Disp disp)
            => new m32(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m64 mem64(RegOp @base)
            => new m64(@base, RegOp.Empty, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m64 mem64(AsmAddress address)
            => new m64(address);

        [MethodImpl(Inline), Op]
        public static m64 mem64(RegOp @base, RegOp index)
            => new m64(@base, index, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m64 mem64(RegOp @base, MemoryScale scale, RegOp index)
            => new m64(@base, index, scale, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m64 mem64(RegOp @base, MemoryScale scale, RegOp index, Disp disp)
            => new m64(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m128 mem128(AsmAddress address)
            => new m128(address);

        [MethodImpl(Inline), Op]
        public static m128 mem128(RegOp @base)
            => new m128(@base, RegOp.Empty, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m128 mem128(RegOp @base, RegOp index)
            => new m128(@base, index, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m128 mem128(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m128(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m256 mem256(AsmAddress address)
            => new m256(address);

        [MethodImpl(Inline), Op]
        public static m256 mem256(RegOp @base)
            => new m256(@base, RegOp.Empty, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m256 mem256(RegOp @base, RegOp index)
            => new m256(@base, index, ScaleFactor.S1, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m256 mem256(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m256(@base, index, scale, disp);

        [MethodImpl(Inline), Op]
        public static m512 mem512(AsmAddress address)
            => new m512(address);

        [MethodImpl(Inline), Op]
        public static m512 mem512(RegOp @base)
            => new m512(@base, RegOp.Empty, 0, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m512 mem512(RegOp @base, RegOp index)
            => new m512(@base, index, ScaleFactor.S1, Disp.Zero);

        [MethodImpl(Inline), Op]
        public static m512 mem512(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            => new m512(@base,index,scale,disp);
    }
}