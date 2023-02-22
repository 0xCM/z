//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Popcnt;
    using static System.Runtime.Intrinsics.X86.Popcnt.X64;

    partial class bits
    {
        /// <summary>
        /// Counts the enabled bits in the source
        /// int _mm_popcnt_u32 (unsigned int a) POPCNT reg, reg/m32
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Pop]
        public static uint pop(sbyte src)
            => PopCount((uint)src);

        /// <summary>
        /// Counts the enabled bits in the source
        /// int _mm_popcnt_u32 (unsigned int a) POPCNT reg, reg/m32
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Pop]
        public static uint pop(byte src)
            => PopCount(src);

        /// <summary>
        /// Counts the enabled bits in the source
        /// int _mm_popcnt_u32 (unsigned int a) POPCNT reg, reg/m32
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Pop]
        public static uint pop(short src)
            => PopCount((uint)src);

        /// <summary>
        /// Counts the enabled bits in the source
        /// int _mm_popcnt_u32 (unsigned int a) POPCNT reg, reg/m32
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Pop]
        public static uint pop(ushort src)
            => PopCount(src);

        /// <summary>
        /// Counts the enabled bits in the source
        /// int _mm_popcnt_u32 (unsigned int a) POPCNT reg, reg/m32
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Pop]
        public static uint pop(int src)
            => PopCount((uint)src);

        /// <summary>
        /// Counts the enabled bits in the source
        /// int _mm_popcnt_u32 (unsigned int a) POPCNT reg, reg/m32
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Pop]
        public static uint pop(uint src)
            => PopCount(src);

        /// <summary>
        /// Counts the enabled bits in the source
        /// __int64 _mm_popcnt_u64 (unsigned __int64 a) POPCNT reg64, reg/m64
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Pop]
        public static uint pop(long src)
            => (uint)PopCount((ulong)src);

        /// <summary>
        /// Counts the enabled bits in the source
        /// __int64 _mm_popcnt_u64 (unsigned __int64 a) POPCNT reg64, reg/m64
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Pop]
        public static uint pop(ulong src)
            => (uint)PopCount(src);

        /// <summary>
        /// Computes the population count of the content of 3 64-bit unsigned integers
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <remarks>Reference: https://www.chessprogramming.org/Population_Count</remarks>
        [MethodImpl(Inline), Pop]
        public static uint pop(ulong x, ulong y, ulong z)
        {
            var maj = ((x ^ y ) & z) | (x & y);
            var odd = ((x ^ y ) ^ z);

            maj =  maj - ((maj >> 1) & k1 );
            odd =  odd - ((odd >> 1) & k1 );

            maj = (maj & k2) + ((maj >> 2) & k2);
            odd = (odd & k2) + ((odd >> 2) & k2);

            maj = (maj + (maj >> 4)) & k4;
            odd = (odd + (odd >> 4)) & k4;

            odd = ((maj + maj + odd) * kf ) >> 56;
            return (uint) odd;
        }

        [MethodImpl(Inline), Pop]
        public static uint pop(ulong x0, ulong x1, ulong x2, ulong x3)
            => (uint)(PopCount(x0) + PopCount(x1) + PopCount(x2) + PopCount(x3));

        [MethodImpl(Inline), Pop]
        public static uint pop(ulong x0, ulong x1, ulong x2, ulong x3, ulong x4, ulong x5, ulong x6, ulong x7)
            => pop(x0,x1,x2,x3) + pop(x4,x5,x6,x7);

        [MethodImpl(Inline), Pop]
        public static uint pop(ulong x0, ulong x1, ulong x2, ulong x3, ulong x4, ulong x5)
            => pop(x0,x1,x2) + pop(x3,x4,x5);

        const ulong k1 = 0x5555555555555555;

        const ulong k2 = 0x3333333333333333;

        const ulong k4 = 0x0f0f0f0f0f0f0f0f;

        const ulong kf = 0x0101010101010101;
    }
}