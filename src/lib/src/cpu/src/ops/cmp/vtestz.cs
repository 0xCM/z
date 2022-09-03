//-----------------------------------------------------------------------------
// Copymask   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx;

    partial struct cpu
    {
        /// <summary>
        /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector128<byte> src, Vector128<byte> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector128<sbyte> src, Vector128<sbyte> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector128<short> src, Vector128<short> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector128<ushort> src, Vector128<ushort> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector128<int> src, Vector128<int> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector128<uint> src, Vector128<uint> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector128<long> src, Vector128<long> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector128<ulong> src, Vector128<ulong> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector256<sbyte> src, Vector256<sbyte> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector256<byte> src, Vector256<byte> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector256<short> src, Vector256<short> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector256<ushort> src, Vector256<ushort> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector256<int> src, Vector256<int> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector256<uint> src, Vector256<uint> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector256<long> src, Vector256<long> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
        /// Returns true if all mask-identified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector256<ulong> src, Vector256<ulong> mask)
            => TestZ(src, mask);

        /// <summary>
        /// int _mm256_testz_ps (__m256 a, __m256 b) VTESTPS ymm, ymm/m256
        /// Determines whether all mask-specified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector256<float> src, Vector256<float> mask)
            => TestZ(src,mask);

        /// <summary>
        /// int _mm256_testz_pd (__m256d a, __m256d b) VTESTPD ymm, ymm/m256
        /// Determines whether all mask-specified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector256<double> src, Vector256<double> mask)
            => TestZ(src,mask);

        /// <summary>
        /// int _mm_testz_ps (__m128 a, __m128 b) VTESTPS xmm, xmm/m128
        /// Determines whether all mask-specified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector128<float> src, Vector128<float> mask)
            => TestZ(src,mask);

        /// <summary>
        /// int _mm_testz_pd (__m128d a, __m128d b) VTESTPD xmm, xmm/m128
        /// Determines whether all mask-specified source bits are off
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mask">The mask</param>
        [MethodImpl(Inline), TestZ]
        public static bit vtestz(Vector128<double> src, Vector128<double> mask)
            => TestZ(src,mask);
    }
}