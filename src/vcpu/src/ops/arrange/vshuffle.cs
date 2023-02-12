//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Ssse3;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial class vcpu
    {
        /// <summary>
        /// __m128d _mm_shuffle_pd (__m128d a, __m128d b, int immediate) SHUFPD xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vshuffle(Vector128<uint> x, Vector128<uint> y, [Imm] BitState spec)
            => v32u(Shuffle(v32f(x), v32f(y), (byte)spec));

        /// <summary>
        /// __m128d _mm_shuffle_pd (__m128d a, __m128d b, int immediate) SHUFPD xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vshuffle(Vector128<ulong> x, Vector128<ulong> y, [Imm] BitState spec)
            => v64u(Shuffle(v64f(x), v64f(y), (byte)spec));

        /// <summary>
        /// __m128 _mm_shuffle_ps (__m128 a, __m128 b, unsigned int control) SHUFPS xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vshuffle(Vector128<float> x, Vector128<float> y, [Imm] byte spec)
            => Shuffle(x, y, spec);

        /// <summary>
        /// __m128d _mm_shuffle_pd (__m128d a, __m128d b, int immediate) SHUFPD xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec"></param>
        /// <remarks>
        /// dst[63:0] := (imm8[0] == 0) ? a[63:0] : a[127:64]
        /// dst[127:64] := (imm8[1] == 0) ? b[63:0] : b[127:64]
        /// </remarks>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vshuffle(Vector128<double> x, Vector128<double> y, [Imm] byte spec)
            => Shuffle(x, y, spec);
    }
}