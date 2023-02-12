//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse3;
    using static System.Runtime.Intrinsics.X86.Ssse3;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial class vcpu 
    {
        /// <summary>
        /// __m128i _mm_hsub_epi16 (__m128i a, __m128i b)
        /// PHSUBW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), SubH]
        public static Vector128<short> vhsub(Vector128<short> x, Vector128<short> y)
            => HorizontalSubtract(x, y);

        /// <summary>
        /// __m128i _mm_hsub_epi32 (__m128i a, __m128i b)
        /// PHSUBD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), SubH]
        public static Vector128<int> vhsub(Vector128<int> x, Vector128<int> y)
            => HorizontalSubtract(x, y);

        /// <summary>
        /// __m256i _mm256_hsub_epi16 (__m256i a, __m256i b)
        /// VPHSUBW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), SubH]
        public static Vector256<short> vhsub(Vector256<short> x, Vector256<short> y)
            => HorizontalSubtract(x, y);

        /// <summary>
        /// __m256i _mm256_hsub_epi32 (__m256i a, __m256i b)
        /// VPHSUBD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), SubH]
        public static Vector256<int> vhsub(Vector256<int> x, Vector256<int> y)
            => HorizontalSubtract(x, y);
    }
}