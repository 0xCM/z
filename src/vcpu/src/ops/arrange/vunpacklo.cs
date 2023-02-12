//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;

    partial class vcpu
    {
        /// <summary>
        /// __m128i _mm_unpacklo_epi8 (__m128i a, __m128i b) PUNPCKLBW xmm, xmm/m128
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vunpacklo(Vector128<sbyte> x, Vector128<sbyte> y)
            => UnpackLow(x,y);

        /// <summary>
        /// __m128i _mm_unpacklo_epi8 (__m128i a, __m128i b) PUNPCKLBW xmm, xmm/m128
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vunpacklo(Vector128<byte> x, Vector128<byte> y)
            => UnpackLow(x,y);

        /// <summary>
        /// __m128i _mm_unpacklo_epi16 (__m128i a, __m128i b) PUNPCKLWD xmm, xmm/m128
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vunpacklo(Vector128<short> x, Vector128<short> y)
            => UnpackLow(x,y);

        /// <summary>
        /// __m128i _mm_unpacklo_epi16 (__m128i a, __m128i b) PUNPCKLWD xmm, xmm/m128
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vunpacklo(Vector128<ushort> x, Vector128<ushort> y)
            => UnpackLow(x,y);

        /// <summary>
        ///  __m128i _mm_unpacklo_epi32 (__m128i a, __m128i b) PUNPCKLDQ xmm, xmm/m128
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vunpacklo(Vector128<int> x, Vector128<int> y)
            => UnpackLow(x,y);

        /// <summary>
        ///  __m128i _mm_unpacklo_epi32 (__m128i a, __m128i b) PUNPCKLDQ xmm, xmm/m128
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vunpacklo(Vector128<uint> x, Vector128<uint> y)
            => UnpackLow(x,y);

        /// <summary>
        ///  __m128i _mm_unpacklo_epi64 (__m128i a, __m128i b) PUNPCKLQDQ xmm, xmm/m128
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vunpacklo(Vector128<long> x, Vector128<long> y)
            => UnpackLow(x,y);

        /// <summary>
        ///  __m128i _mm_unpacklo_epi64 (__m128i a, __m128i b) PUNPCKLQDQ xmm, xmm/m128
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vunpacklo(Vector128<ulong> x, Vector128<ulong> y)
            => UnpackLow(x,y);

        /// <summary>
        /// __m128 _mm_unpacklo_ps (__m128 a, __m128 b) UNPCKLPS xmm, xmm/m128
        /// Creates a 128-bit vector where the lower 64 bits are taken from the
        /// lower 64 bits of the first source vector and the higher 64 bits are taken
        /// from the lower 64 bits of the second source vector
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vunpacklo(Vector128<float> x, Vector128<float> y)
            => UnpackLow(x, y);

        /// <summary>
        /// __m128d _mm_unpacklo_pd (__m128d a, __m128d b) UNPCKLPD xmm, xmm/m128
        /// Creates a 128-bit vector where the lower 64 bits are taken from the
        /// lower 64 bits of the first source vector and the higher 64 bits are taken
        /// from the lower 64 bits of the second source vector
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vunpacklo(Vector128<double> x, Vector128<double> y)
            => UnpackLow(x, y);

        /// <summary>
        /// __m256i _mm256_unpacklo_epi8 (__m256i a, __m256i b) VPUNPCKLBW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vunpacklo(Vector256<sbyte> x, Vector256<sbyte> y)
            => UnpackLow(x,y);

        /// <summary>
        /// __m256i _mm256_unpacklo_epi8 (__m256i a, __m256i b) VPUNPCKLBW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vunpacklo(Vector256<byte> x, Vector256<byte> y)
            => UnpackLow(x,y);

        /// <summary>
        /// __m256i _mm256_unpacklo_epi16 (__m256i a, __m256i b) VPUNPCKLWD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vunpacklo(Vector256<short> x, Vector256<short> y)
            => UnpackLow(x,y);

        /// <summary>
        /// __m256i _mm256_unpacklo_epi16 (__m256i a, __m256i b) VPUNPCKLWD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vunpacklo(Vector256<ushort> x, Vector256<ushort> y)
            => UnpackLow(x,y);

        /// <summary>
        /// __m256i _mm256_unpacklo_epi32 (__m256i a, __m256i b) VPUNPCKLDQ ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vunpacklo(Vector256<int> x, Vector256<int> y)
            => UnpackLow(x,y);

        /// <summary>
        /// __m256i _mm256_unpacklo_epi32 (__m256i a, __m256i b) VPUNPCKLDQ ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vunpacklo(Vector256<uint> x, Vector256<uint> y)
            => UnpackLow(x,y);

        /// <summary>
        /// __m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b) VPUNPCKLQDQ ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vunpacklo(Vector256<long> x, Vector256<long> y)
            => UnpackLow(x,y);

        /// <summary>
        /// __m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b) VPUNPCKLQDQ ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vunpacklo(Vector256<ulong> x, Vector256<ulong> y)
            => UnpackLow(x,y);

        /// <summary>
        /// __m256 _mm256_unpacklo_ps (__m256 a, __m256 b) VUNPCKLPS ymm, ymm, ymm/m256
        /// Creates a 256-bit vector where the lower 128 bits are taken from the
        /// lower 128 bits of the first source vector and the higher 128 bits are taken
        /// from the lower 128 bits of the second source vector
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vunpacklo(Vector256<float> x, Vector256<float> y)
            => UnpackLow(x, y);

        /// <summary>
        /// __m256d _mm256_unpacklo_pd (__m256d a, __m256d b) VUNPCKLPD ymm, ymm, ymm/m256
        /// Creates a 256-bit vector where the lower 128 bits are taken from the
        /// lower 128 bits of the first source vector and the higher 128 bits are taken
        /// from the lower 128 bits of the second source vector
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vunpacklo(Vector256<double> x, Vector256<double> y)
            => UnpackLow(x,y);
    }
}