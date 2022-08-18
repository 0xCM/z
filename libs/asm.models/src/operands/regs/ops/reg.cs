//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct AsmRegs
    {
        [MethodImpl(Inline), Op]
        public static RegOp gp8(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W8, RegClassCode.GP, r);

        [MethodImpl(Inline), Op]
        public static RegOp gp16(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W16, RegClassCode.GP, r);

        [MethodImpl(Inline), Op]
        public static RegOp gp32(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W32, RegClassCode.GP, r);

        [MethodImpl(Inline), Op]
        public static RegOp gp64(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W64, RegClassCode.GP, r);

        [MethodImpl(Inline), Op]
        public static RegOp mask(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W64, RegClassCode.MASK, r);

        [MethodImpl(Inline), Op]
        public static RegOp v128(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W128, RegClassCode.XMM, r);

        [MethodImpl(Inline), Op]
        public static RegOp v256(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W128, RegClassCode.YMM, r);

        [MethodImpl(Inline), Op]
        public static RegOp v512(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W128, RegClassCode.ZMM, r);

        [MethodImpl(Inline), Op]
        public static RegOp rK(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W64, RegClassCode.MASK, r);

        [MethodImpl(Inline), Op]
        public static RegOp rK8(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W8, RegClassCode.MASK, r);

        [MethodImpl(Inline), Op]
        public static RegOp rK16(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W16, RegClassCode.MASK, r);

        [MethodImpl(Inline), Op]
        public static RegOp rK32(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W32, RegClassCode.MASK, r);

        [MethodImpl(Inline), Op]
        public static RegOp rK64(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W64, RegClassCode.MASK, r);

        [MethodImpl(Inline), Op]
        public static RegOp reg(RegKind kind)
            => new RegOp((ushort)kind);

        [MethodImpl(Inline), Op]
        public static RegOp reg(in AsmOperand src)
            => new RegOp(first(span16u(src.Data)));

        [MethodImpl(Inline), Op]
        public static RegOp sptr(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W16, RegClassCode.SPTR, r);

        [MethodImpl(Inline), Op]
        public static RegOp seg(RegIndexCode r)
            => AsmRegBits.reg(NativeSizeCode.W16, RegClassCode.SEG, r);
    }
}