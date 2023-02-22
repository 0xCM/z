//-----------------------------------------------------------------------------
// Copymask   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx;

    partial class vcpu
    {
        /// <summary>
        /// int _mm_testnzc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <algorithm>
        /// IF (a[127:0] AND b[127:0] == 0)
        ///     ZF := 1
        /// ELSE
        ///     ZF := 0
        /// FI
        /// IF ((NOT a[127:0]) AND b[127:0] == 0)
        ///     CF := 1
        /// ELSE
        ///     CF := 0
        /// FI
        /// IF (ZF == 0 && CF == 0)
        ///     dst := 1
        /// ELSE
        ///     dst := 0
        /// FI
        /// </algorithm>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector128<sbyte> x, Vector128<sbyte> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm_testnzc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector128<byte> x, Vector128<byte> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm_testnzc_si128 (__m128i a, __m128i b)PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector128<short> x, Vector128<short> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm_testnzc_si128 (__m128i a, __m128i b)PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector128<ushort> x, Vector128<ushort> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm_testnzc_si128 (__m128i a, __m128i b)PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector128<int> x, Vector128<int> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm_testnzc_si128 (__m128i a, __m128i b)PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector128<uint> x, Vector128<uint> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm_testnzc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector128<long> x, Vector128<long> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm_testnzc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector128<ulong> x, Vector128<ulong> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm_testnzc_ps (__m128 a, __m128 b) VTESTPS xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector128<float> x, Vector128<float> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm_testnzc_pd (__m128d a, __m128d b) VTESTPD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector128<double> x, Vector128<double> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm_testnzc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector256<sbyte> x, Vector256<sbyte> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm256_testnzc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector256<byte> x, Vector256<byte> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm256_testnzc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector256<short> x, Vector256<short> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm256_testnzc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector256<ushort> x, Vector256<ushort> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm256_testnzc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector256<int> x, Vector256<int> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm256_testnzc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector256<uint> x, Vector256<uint> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm256_testnzc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector256<long> x, Vector256<long> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm256_testnzc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector256<ulong> x, Vector256<ulong> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm256_testnzc_ps (__m256 a, __m256 b) VTESTPS ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector256<float> x, Vector256<float> y)
            => TestNotZAndNotC(x, y);

        /// <summary>
        /// int _mm256_testnzc_pd (__m256d a, __m256d b)VTESTPD ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), TestZnC]
        public static bool vtestznc(Vector256<double> x, Vector256<double> y)
            => TestNotZAndNotC(x, y);
    }
}