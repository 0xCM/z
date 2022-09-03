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
        /// _mm_missing
        /// Computes a <= b
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vle(Vector128<byte> a, Vector128<byte> b)
            => veq(vmin(a,b), a);

        /// <summary>
        /// _mm_missing
        /// Computes a <= b
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vle(Vector128<ushort> a, Vector128<ushort> b)
            => veq(vmin(a,b), a);

        /// <summary>
        /// _mm_missing
        /// Computes a <= b
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vle(Vector128<uint> a, Vector128<uint> b)
            => veq(vmin(a,b), a);

        /// <summary>
        /// _mm_missing
        /// Computes a <= b
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vle(Vector128<ulong> a, Vector128<ulong> b)
            => veq(vmin(a,b), a);

        /// <summary>
        /// _mm_missing
        /// Computes a <= b
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vle(Vector256<byte> a, Vector256<byte> b)
            => veq(vmin(a,b), a);

        /// <summary>
        /// _mm_missing
        /// Computes a <= b
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vle(Vector256<ushort> a, Vector256<ushort> b)
            => veq(vmin(a,b), a);

        /// <summary>
        /// _mm_missing
        /// Computes a <= b
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vle(Vector256<uint> a, Vector256<uint> b)
            => veq(vmin(a,b), a);

        /// <summary>
        /// _mm_missing
        /// Computes a <= b
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vle(Vector256<ulong> a, Vector256<ulong> b)
            => veq(vmin(a,b), a);

        /// <summary>
        /// __m128 _mm_cmple_ps (__m128 a, __m128 b) CMPPS xmm, xmm/m128, imm8(2)
        /// Computes a <= b
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vle(Vector128<float> a, Vector128<float> b)
            => CompareLessThanOrEqual(a, b);

        /// <summary>
        /// __m128d _mm_cmple_pd (__m128d a, __m128d b) CMPPD xmm, xmm/m128, imm8(2)
        /// Computes a <= b
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vle(Vector128<double> a, Vector128<double> b)
            => CompareLessThanOrEqual(a, b);

        /// <summary>
        /// __m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8) VCMPPS ymm, ymm, ymm/m256, imm8
        /// Computes a <= b
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vle(Vector256<float> a, Vector256<float> b)
            => Compare(a, b, FloatComparisonMode.OrderedLessThanOrEqualNonSignaling);

        /// <summary>
        /// __m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8) VCMPPD ymm, ymm, ymm/m256, imm8
        /// Computes a <= b
        /// </summary>
        /// <param name="a">The left vector</param>
        /// <param name="b">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vle(Vector256<double> a, Vector256<double> b)
            => Compare(a, b,FloatComparisonMode.OrderedLessThanOrEqualNonSignaling);
    }
}