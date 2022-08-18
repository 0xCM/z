//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx;

    partial struct cpu
    {
        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<sbyte> src)
            => TestC(src, gcpu.vones<sbyte>(w128));

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<byte> src)
            => TestC(src, gcpu.vones<byte>(w128));

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<short> src)
            => TestC(src, gcpu.vones<short>(w128));

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<ushort> src)
            => TestC(src, gcpu.vones<ushort>(w128));

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<int> src)
            => TestC(src, gcpu.vones<int>(w128));

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<uint> src)
            => TestC(src, gcpu.vones<uint>(w128));

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<long> src)
            => TestC(src, gcpu.vones<long>(w128));

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<ulong> src)
            => TestC(src, gcpu.vones<ulong>(w128));

        /// <summary>
        /// int _mm_testc_ps (__m128 a, __m128 b) VTESTPS xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<float> src)
            => TestC(src, gcpu.vones<float>(w128));

        /// <summary>
        /// int _mm_testc_pd (__m128d a, __m128d b) VTESTPD xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<double> src)
            => TestC(src, gcpu.vones<double>(w128));

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all source bits are on enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<sbyte> src)
            => TestC(src, gcpu.vones<sbyte>(w256));

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all source bits are on enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<byte> src)
            => TestC(src, gcpu.vones<byte>(w256));

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all source bits are on enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<short> src)
            => TestC(src, gcpu.vones<short>(w256));

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all source bits are on enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<ushort> src)
            => TestC(src, gcpu.vones<ushort>(w256));

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all source bits are on enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<int> src)
            => TestC(src, gcpu.vones<int>(w256));

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all source bits are on enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<uint> src)
            => TestC(src, gcpu.vones<uint>(w256));

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all source bits are on enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<long> src)
            => TestC(src, gcpu.vones<long>(w256));

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all source bits are on enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<ulong> src)
            => TestC(src, gcpu.vones<ulong>(w256));

        /// <summary>
        /// int _mm256_testc_ps (__m256 a, __m256 b) VTESTPS ymm, ymm/m256
        /// Returns true if all source bits are on enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits in the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<float> src)
            => TestC(src, gcpu.vones<float>(w256));

        /// <summary>
        /// int _mm256_testc_pd (__m256d a, __m256d b) VTESTPS ymm, ymm/m256
        /// Returns true if all source bits are on enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits in the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<double> src)
            => TestC(src, gcpu.vones<double>(w256));

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are on
        /// Compute the bitwise AND of 128 bits (representing integer data) in "a" and "b", and set "ZF" to 1 if the result is zero, otherwise set "ZF" to 0.
        /// Compute the bitwise NOT of "a" and then AND with "b", and set "CF" to 1 if the result is zero, otherwise set "CF" to 0. Return the "CF" value.
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        /// <algorithm>
        /// IF (a[127:0] AND b[127:0] == 0)
        ///     ZF := 1
        /// ELSE
        ///     ZF := 0
        /// IF (((NOT a[127:0]) AND b[127:0]) == 0)
        ///   	CF := 1
        /// ELSE
        ///     CF := 0
        /// <algorithm>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<sbyte> src, Vector128<sbyte> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<byte> src, Vector128<byte> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<short> src, Vector128<short> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<ushort> src, Vector128<ushort> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<int> src, Vector128<int> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<uint> src, Vector128<uint> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<long> src, Vector128<long> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm_testc_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are enabled
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<ulong> src, Vector128<ulong> mask)
            => TestC(src, mask);


        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<sbyte> src, Vector256<sbyte> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<byte> src, Vector256<byte> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<short> src, Vector256<short> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<ushort> src, Vector256<ushort> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<int> src, Vector256<int> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<uint> src, Vector256<uint> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm256_testc_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<long> src, Vector256<long> mask)
            => TestC(src, mask);

        /// <summary>
        /// _mm256_testc_si256
        /// Returns true if all mask-identified source bits are on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<ulong> src, Vector256<ulong> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm_testc_ps (__m128 a, __m128 b) VTESTPS xmm, xmm/m128
        /// Determines whether mask-specified source bits are all on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits in the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<float> src, Vector128<float> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm_testc_pd (__m128d a, __m128d b) VTESTPD xmm, xmm/m128
        /// Determines whether mask-specified source bits are all on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits in the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector128<double> src, Vector128<double> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm256_testc_ps (__m256 a, __m256 b) VTESTPS ymm, ymm/m256
        /// Determines whether mask-specified source bits are all on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits in the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<float> src, Vector256<float> mask)
            => TestC(src, mask);

        /// <summary>
        /// int _mm256_testc_pd (__m256d a, __m256d b) VTESTPS ymm, ymm/m256
        /// Determines whether mask-specified source bits are all on
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="mask">Specifies the bits in the source to test</param>
        [MethodImpl(Inline), TestC]
        public static bit vtestc(Vector256<double> src, Vector256<double> mask)
            => TestC(src, mask);
    }
}