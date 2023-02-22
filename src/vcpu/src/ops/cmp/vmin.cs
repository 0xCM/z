//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial class vcpu
    {
        /// <summary>
        /// __m128i _mm_min_epu8 (__m128i a, __m128i b) PMINUB xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector128<byte> vmin(Vector128<byte> x, Vector128<byte> y)
            => Min(x, y);

        /// <summary>
        /// __m128i _mm_min_epi8 (__m128i a, __m128i b) PMINSB xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector128<sbyte> vmin(Vector128<sbyte> x, Vector128<sbyte> y)
            => Min(x, y);

        /// <summary>
        /// __m128i _mm_min_epi16 (__m128i a, __m128i b) PMINSW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector128<short> vmin(Vector128<short> x, Vector128<short> y)
            => Min(x, y);

        /// <summary>
        /// __m128i _mm_min_epu16 (__m128i a, __m128i b) PMINUW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector128<ushort> vmin(Vector128<ushort> x, Vector128<ushort> y)
            => Min(x, y);

        /// <summary>
        /// __m128i _mm_min_epu32 (__m128i a, __m128i b) PMINUD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector128<int> vmin(Vector128<int> x, Vector128<int> y)
            => Min(x, y);

        /// <summary>
        /// __m128i _mm_min_epu32 (__m128i a, __m128i b) PMINUD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector128<uint> vmin(Vector128<uint> x, Vector128<uint> y)
            => Min(x, y);

        /// <summary>
        /// Computes the maximum values of corresponding components
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector128<long> vmin(Vector128<long> x, Vector128<long> y)
        {
            var xL = vinsert(x,default, LaneIndex.L0);
            var yL = vinsert(y,default, LaneIndex.L0);
            return vlo(vmin(xL,yL));
        }

        /// <summary>
        /// Computes the maximum values of corresponding components
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline)]
        public static Vector128<ulong> vmin(Vector128<ulong> x, Vector128<ulong> y)
            => vselect(vlt(x,y),x,y);

        /// <summary>
        /// __m256i _mm256_min_epu8 (__m256i a, __m256i b) VPMINUB ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Min]
        public static Vector256<byte> vmin(Vector256<byte> x, Vector256<byte> y)
            => Min(x, y);

        /// <summary>
        /// __m256i _mm256_min_epi8 (__m256i a, __m256i b) VPMINSB ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Min]
        public static Vector256<sbyte> vmin(Vector256<sbyte> x, Vector256<sbyte> y)
            => Min(x, y);

        /// <summary>
        /// __m256i _mm256_min_epi16 (__m256i a, __m256i b) VPMINSW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector256<short> vmin(Vector256<short> x, Vector256<short> y)
            => Min(x, y);

        /// <summary>
        /// __m256i _mm256_min_epu16 (__m256i a, __m256i b) VPMINUW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector256<ushort> vmin(Vector256<ushort> x, Vector256<ushort> y)
            => Min(x, y);

        /// <summary>
        /// __m256i _mm256_min_epi32 (__m256i a, __m256i b) VPMINSD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector256<int> vmin(Vector256<int> x, Vector256<int> y)
            => Min(x, y);

        /// <summary>
        /// __m256i _mm256_min_epu32 (__m256i a, __m256i b) VPMINUD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector256<uint> vmin(Vector256<uint> x, Vector256<uint> y)
            => Min(x, y);

        /// <summary>
        /// Computes the maximum values of corresponding components
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector256<ulong> vmin(Vector256<ulong> x, Vector256<ulong> y)
            => vselect(vlt(x,y),x,y);

        /// <summary>
        /// Computes the maximum values of corresponding components
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Min]
        public static Vector256<long> vmin(Vector256<long> x, Vector256<long> y)
            => vblendv(y, x, v8u(vlt(x,y)));

        /// <summary>
        /// __m128 _mm_min_ps (__m128 a, __m128 b) MINPS xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vmin(Vector128<float> x, Vector128<float> y)
            => Min(x, y);

        /// <summary>
        /// __m128d _mm_min_pd (__m128d a, __m128d b) MINPD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vmin(Vector128<double> x, Vector128<double> y)
            => Min(x, y);

        /// <summary>
        /// __m256 _mm256_min_ps (__m256 a, __m256 b) VMINPS ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vmin(Vector256<float> x, Vector256<float> y)
            => Min(x, y);

        /// <summary>
        /// __m256d _mm256_min_pd (__m256d a, __m256d b) VMINPD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vmin(Vector256<double> x, Vector256<double> y)
            => Min(x, y);
    }
}