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
        /// __m128i _mm_max_epu8 (__m128i a, __m128i b) PMAXUB xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector128<byte> vmax(Vector128<byte> x, Vector128<byte> y)
            => Max(x, y);

        /// <summary>
        /// __m128i _mm_max_epi8 (__m128i a, __m128i b) PMAXSB xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector128<sbyte> vmax(Vector128<sbyte> x, Vector128<sbyte> y)
            => Max(x, y);

        /// <summary>
        ///  __m128i _mm_max_epi16 (__m128i a, __m128i b) PMAXSW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector128<short> vmax(Vector128<short> x, Vector128<short> y)
            => Max(x, y);

        /// <summary>
        /// __m128i _mm_max_epu16 (__m128i a, __m128i b) PMAXUW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector128<ushort> vmax(Vector128<ushort> x, Vector128<ushort> y)
            => Max(x, y);

        /// <summary>
        ///  __m128i _mm_max_epi32 (__m128i a, __m128i b) PMAXSD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector128<int> vmax(Vector128<int> x, Vector128<int> y)
            => Max(x, y);

        /// <summary>
        /// __m128i _mm_max_epu32 (__m128i a, __m128i b) PMAXUD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector128<uint> vmax(Vector128<uint> x, Vector128<uint> y)
            => Max(x, y);

        /// <summary>
        /// Computes the maximum values of corresponding components
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static Vector128<ulong> vmax(Vector128<ulong> x, Vector128<ulong> y)
            => vselect(vgt(x,y),x,y);

        /// <summary>
        /// Computes the maximum values of corresponding components
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector128<long> vmax(Vector128<long> x, Vector128<long> y)
        {
            var xL = vinsert(x,default, LaneIndex.L0);
            var yL = vinsert(y,default, LaneIndex.L0);
            return vlo(vmax(xL,yL));
        }

        /// <summary>
        /// __m256i _mm256_max_epu8 (__m256i a, __m256i b) VPMAXUB ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector256<byte> vmax(Vector256<byte> x, Vector256<byte> y)
            => Max(x, y);

        /// <summary>
        ///  __m256i _mm256_max_epi8 (__m256i a, __m256i b)VPMAXSB ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector256<sbyte> vmax(Vector256<sbyte> x, Vector256<sbyte> y)
            => Max(x, y);

        /// <summary>
        /// __m256i _mm256_max_epi16 (__m256i a, __m256i b) VPMAXSW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector256<short> vmax(Vector256<short> x, Vector256<short> y)
            => Max(x, y);

        /// <summary>
        /// __m256i _mm256_max_epu16 (__m256i a, __m256i b) VPMAXUW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector256<ushort> vmax(Vector256<ushort> x, Vector256<ushort> y)
            => Max(x, y);

        /// <summary>
        ///  __m256i _mm256_max_epi32 (__m256i a, __m256i b) VPMAXSD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector256<int> vmax(Vector256<int> x, Vector256<int> y)
            => Max(x, y);

        /// <summary>
        /// __m256i _mm256_max_epu32 (__m256i a, __m256i b) VPMAXUD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector256<uint> vmax(Vector256<uint> x, Vector256<uint> y)
            => Max(x, y);

        /// <summary>
        /// Computes the maximum values of corresponding components
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline)]
        public static Vector256<ulong> vmax(Vector256<ulong> x, Vector256<ulong> y)
            => vselect(vgt(x,y),x,y);

        /// <summary>
        /// Computes the maximum values of corresponding components
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Max]
        public static Vector256<long> vmax(Vector256<long> x, Vector256<long> y)
            => vblendv(y, x, v8u(vgt(x,y)));

        ///  __m128 _mm_max_ps (__m128 a, __m128 b) MAXPS xmm, xmm/m128
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vmax(Vector128<float> x, Vector128<float> y)
            => Max(x, y);

        /// <summary>
        ///  __m128d _mm_max_pd (__m128d a, __m128d b)MAXPD xmm, xmm/m128
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vmax(Vector128<double> x, Vector128<double> y)
            => Max(x, y);

        /// <summary>
        /// __m256 _mm256_max_ps (__m256 a, __m256 b) VMAXPS ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vmax(Vector256<float> x, Vector256<float> y)
            => Max(x, y);

        /// <summary>
        /// __m256d _mm256_max_pd (__m256d a, __m256d b)VMAXPD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vmax(Vector256<double> x, Vector256<double> y)
            => Max(x, y);
    }
}