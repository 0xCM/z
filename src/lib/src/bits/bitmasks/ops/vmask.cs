//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.Vector128;

    using x64 = System.Runtime.Intrinsics.X86.Bmi2.X64;

    partial class BitMasks
    {
        /// <summary>
        /// Distributes each bit of the source to the hi bit of each byte in a 128-bit target vector
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vmask128x8u(ushort src)
            => Create(maskpart(src, 0), maskpart(src,8)).AsByte();

        /// <summary>
        /// Distributes each bit of the source to the hi bit of each byte a 256-bit target vector
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vmask256x8u(uint src)
            => vconcat(vmask128x8u((ushort)src), vmask128x8u((ushort)(src >> 16)));

        [MethodImpl(Inline), Op]
        public static ulong maskpart(uint src, byte offset)
            => scatter((ulong)((byte)(src >> offset)), BitMaskLiterals.Msb64x8x1);

        [MethodImpl(Inline), Op]
        public static ulong maskpart(uint src, byte offset, ulong mask)
            => scatter((ulong)((byte)(src >> offset)), mask);

        [MethodImpl(Inline)]
        static Vector256<byte> vconcat(Vector128<byte> lo, Vector128<byte> hi)
            => InsertVector128(InsertVector128(default, lo, 0), hi, 1);

        /// <summary>
        /// unsigned __int64 _pdep_u64 (unsigned __int64 a, unsigned __int64 mask) PDEP r64a, r64b, reg/m64
        /// Deposits contiguous low bits from the source across a target according to a mask
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), Scatter]
        static ulong scatter(ulong src, ulong mask)
            => x64.ParallelBitDeposit(src,mask);
    }
}