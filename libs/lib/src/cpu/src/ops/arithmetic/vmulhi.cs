//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Sse2;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_mulhi_epu16 (__m128i a, __m128i b) PMULHUW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), MulHi]
        public static Vector128<short> vmulhi(Vector128<short> x, Vector128<short> y)
            => MultiplyHigh(x, y);

        /// <summary>
        /// __m128i _mm_mulhi_epu16 (__m128i a, __m128i b) PMULHUW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), MulHi]
        public static Vector128<ushort> vmulhi(Vector128<ushort> x, Vector128<ushort> y)
            => MultiplyHigh(x, y);

        /// <summary>
        ///  __m256i _mm256_mulhi_epu16 (__m256i a, __m256i b) VPMULHUW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), MulHi]
        public static Vector256<short> vmulhi(Vector256<short> x, Vector256<short> y)
            => MultiplyHigh(x, y);

        /// <summary>
        ///  __m256i _mm256_mulhi_epu16 (__m256i a, __m256i b) VPMULHUW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), MulHi]
        public static Vector256<ushort> vmulhi(Vector256<ushort> x, Vector256<ushort> y)
            => MultiplyHigh(x, y);
    }
}