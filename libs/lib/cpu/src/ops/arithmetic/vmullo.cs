//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_mullo_epi16 (__m128i a, __m128i b) PMULLW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), MulLo]
        public static Vector128<short> vmullo(Vector128<short> x, Vector128<short> y)
            => MultiplyLow(x, y);

        /// <summary>
        /// __m128i _mm_mullo_epi16 (__m128i a, __m128i b) PMULLW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), MulLo]
        public static Vector128<ushort> vmullo(Vector128<ushort> x, Vector128<ushort> y)
            => MultiplyLow(x, y);

        /// <summary>
        /// __m128i _mm_mullo_epi32 (__m128i a, __m128i b) PMULLD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), MulLo]
        public static Vector128<int> vmullo(Vector128<int> x, Vector128<int> y)
            => MultiplyLow(x, y);

        /// <summary>
        /// __m128i _mm_mullo_epi32 (__m128i a, __m128i b) PMULLD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), MulLo]
        public static Vector128<uint> vmullo(Vector128<uint> x, Vector128<uint> y)
            => MultiplyLow(x, y);

        /// <summary>
        /// __m256i _mm256_mullo_epi16 (__m256i a, __m256i b) VPMULLW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), MulLo]
        public static Vector256<short> vmullo(Vector256<short> x, Vector256<short> y)
            => MultiplyLow(x, y);

        /// <summary>
        /// __m256i _mm256_mullo_epi16 (__m256i a, __m256i b)VPMULLW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), MulLo]
        public static Vector256<ushort> vmullo(Vector256<ushort> x, Vector256<ushort> y)
            => MultiplyLow(x, y);

        /// <summary>
        /// __m256i _mm256_mullo_epi32 (__m256i a, __m256i b) VPMULLD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), MulLo]
        public static Vector256<int> vmullo(Vector256<int> x, Vector256<int> y)
            => MultiplyLow(x, y);

        /// <summary>
        /// __m256i _mm256_mullo_epi32 (__m256i a, __m256i b) VPMULLD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), MulLo]
        public static Vector256<uint> vmullo(Vector256<uint> x, Vector256<uint> y)
            => MultiplyLow(x, y);
    }
}