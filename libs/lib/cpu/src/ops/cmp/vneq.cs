//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.Intrinsics.X86;

    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx;

    partial struct cpu
    {
        /// <summary>
        /// __m128 _mm_cmpneq_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(4)
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vneq(Vector128<float> a, Vector128<float> b)
            => CompareNotEqual(a, b);

        /// <summary>
        /// __m128d _mm_cmpneq_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(4)
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vneq(Vector128<double> a, Vector128<double> b)
            => CompareNotEqual(a, b);

        /// <summary>
        /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8) VCMPPS ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vneq(Vector256<float> a, Vector256<float> b)
            => Compare(a, b, FloatComparisonMode.OrderedNotEqualNonSignaling);

        /// <summary>
        /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8) VCMPPD ymm, ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vneq(Vector256<double> a, Vector256<double> b)
            => Compare(a, b, FloatComparisonMode.OrderedNotEqualNonSignaling);
    }
}