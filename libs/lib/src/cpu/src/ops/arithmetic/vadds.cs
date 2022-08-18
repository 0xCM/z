//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_adds_epu8 (__m128i a, __m128i b) PADDUSB xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), AddS]
        public static Vector128<byte> vadds(Vector128<byte> x, Vector128<byte> y)
            => AddSaturate(x,y);

        /// <summary>
        /// __m128i _mm_adds_epi8 (__m128i a, __m128i b) PADDSB xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), AddS]
        public static Vector128<sbyte> vadds(Vector128<sbyte> x, Vector128<sbyte> y)
            => AddSaturate(x,y);

        /// <summary>
        /// __m128i _mm_adds_epi16 (__m128i a, __m128i b) PADDSW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), AddS]
        public static Vector128<short> vadds(Vector128<short> x, Vector128<short> y)
            => AddSaturate(x,y);

        /// <summary>
        /// __m128i _mm_adds_epu16 (__m128i a, __m128i b) PADDUSW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), AddS]
        public static Vector128<ushort> vadds(Vector128<ushort> x, Vector128<ushort> y)
            => AddSaturate(x,y);

        /// <summary>
        /// __m256i _mm256_adds_epu8 (__m256i a, __m256i b) VPADDUSB ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), AddS]
        public static Vector256<byte> vadds(Vector256<byte> x, Vector256<byte> y)
            => AddSaturate(x,y);

        /// <summary>
        ///  __m256i _mm256_adds_epi8 (__m256i a, __m256i b) VPADDSB ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), AddS]
        public static Vector256<sbyte> vadds(Vector256<sbyte> x, Vector256<sbyte> y)
            => AddSaturate(x,y);

        /// <summary>
        /// __m256i _mm256_adds_epi16 (__m256i a, __m256i b) VPADDSW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), AddS]
        public static Vector256<short> vadds(Vector256<short> x, Vector256<short> y)
            => AddSaturate(x,y);

        /// <summary>
        ///  __m256i _mm256_adds_epu16 (__m256i a, __m256i b) VPADDUSW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), AddS]
        public static Vector256<ushort> vadds(Vector256<ushort> x, Vector256<ushort> y)
            =>  AddSaturate(x,y);
    }
}