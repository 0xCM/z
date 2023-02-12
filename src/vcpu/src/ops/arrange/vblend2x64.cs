//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Sse41;

    partial class vcpu
    {
        /// <summary>
        /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vblend2x64(Vector128<byte> x, Vector128<byte> y, [Imm] byte spec)
            => v8u(Blend(v64f(x), v64f(y), (byte)spec));

        /// <summary>
        /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vblend2x64(Vector128<ulong> x, Vector128<ulong> y, [Imm] byte spec)
            => v64u(Blend(v64f(x), v64f(y), spec));

        /// <summary>
        /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vblend2x64(Vector128<long> x, Vector128<long> y, [Imm] byte spec)
            => v64i(Blend(v64f(x), v64f(y), spec));

        /// <summary>
        /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vblend(Vector128<long> x, Vector128<long> y, [Imm] Blend2x64 spec)
            => vblend2x64(x,y,(byte)spec);

        /// <summary>
        /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vblend2x64(Vector128<ulong> x, Vector128<ulong> y, [Imm] Blend2x64 spec)
            => vblend2x64(x,y,(byte)spec);

        /// <summary>
        /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vblend2x64(Vector128<double> x, Vector128<double> y, [Imm] Blend2x64 spec)
            => Blend(x, y, (byte)spec);

        /// <summary>
        /// __m128 _mm_blend_ps (__m128 a, __m128 b, const int imm8) BLENDPS xmm, xmm/m128, imm8
        /// Produces a new vector by assembling components from two source vectors as dermined by a mask
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vblend(Vector128<float> x, Vector128<float> y, [Imm] byte spec)
            => Blend(x, y, spec);

        /// <summary>
        /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
        /// Produces a new vector by assembling components from two source vectors as dermined by a mask
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vblend(Vector128<double> x, Vector128<double> y, [Imm] byte spec)
            => Blend(x, y, spec);

        /// <summary>
        /// __m256 _mm256_blend_ps (__m256 a, __m256 b, const int imm8) VBLENDPS ymm, ymm, ymm/m256, imm8
        /// Produces a new vector by assembling components from two source vectors as dermined by a mask
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vblend(Vector256<float> x, Vector256<float> y, [Imm] byte spec)
            => Blend(x, y, spec);

        /// <summary>
        /// __m256d _mm256_blend_pd (__m256d a, __m256d b, const int imm8) VBLENDPD ymm, ymm, ymm/m256, imm8
        /// Produces a new vector by assembling components from two source vectors as dermined by a mask
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vblend(Vector256<double> x, Vector256<double> y, [Imm] byte spec)
            => Blend(x, y, spec);
    }
}