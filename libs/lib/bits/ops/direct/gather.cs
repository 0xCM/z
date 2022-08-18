//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Bmi2;
    using static System.Runtime.Intrinsics.X86.Bmi2.X64;

    partial class bits
    {
        /// <summary>
        /// unsigned int _pext_u32 (unsigned int a, unsigned int mask) PEXT r32a, r32b, reg/m32
        /// Copies mask-identified source bits to contiguous low bits in the returned target
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="mask">The mask that defines the bits to select</param>
        [MethodImpl(Inline), Gather]
        public static byte gather(byte src, byte mask)
            => (byte)ParallelBitExtract((uint)src,(uint)mask);

        /// <summary>
        /// unsigned int _pext_u32 (unsigned int a, unsigned int mask) PEXT r32a, r32b, reg/m32
        /// Copies mask-identified source bits to contiguous low bits in the returned target
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="mask">The mask that defines the bits to select</param>
        [MethodImpl(Inline), Gather]
        public static ushort gather(ushort src, ushort mask)
            => (ushort)ParallelBitExtract((uint)src,(uint)mask);

        /// <summary>
        /// unsigned int _pext_u32 (unsigned int a, unsigned int mask) PEXT r32a, r32b, reg/m32
        /// Copies mask-identified source bits to contiguous low bits in the returned target
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="mask">The mask that defines the bits to select</param>
        [MethodImpl(Inline), Gather]
        public static uint gather(uint src, uint mask)
            => ParallelBitExtract(src, mask);

        /// <summary>
        /// __int64 _pext_u64 (unsigned __int64 a, unsigned __int64 mask) PEXT r64a, r64b, reg/m64
        /// Copies mask-identified source bits to contiguous low bits in the returned target
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="mask">The mask that defines the bits to select</param>
        [MethodImpl(Inline), Gather]
        public static ulong gather(ulong src, ulong mask)
            => ParallelBitExtract(src,mask);
    }
}