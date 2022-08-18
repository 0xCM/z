//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Sse41;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        ///  __m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8) VPBLENDD ymm,ymm, ymm/m256, imm8
        /// Forms a vector z[i] := testbit(spec,i) ? x[i] : y[i], i = 0,...7
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vblend8x32(Vector256<int> x, Vector256<int> y, [Imm] byte spec)
            => Blend(x, y, spec);

        /// <summary>
        /// __m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8) VPBLENDD ymm, ymm, ymm/m256, imm8
        /// Forms a vector z[i] := testbit(spec,i) ? x[i] : y[i], i = 0,...7
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vblend8x32(Vector256<uint> x, Vector256<uint> y, [Imm] byte spec)
            => Blend(x, y, spec);

        /// <summary>
        ///  __m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8) VPBLENDD ymm,ymm, ymm/m256, imm8
        /// Forms a vector z[i] := testbit(spec,i) ? x[i] : y[i], i = 0,...7
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vblend(Vector256<int> x, Vector256<int> y, [Imm] Blend8x32 spec)
            => Blend(x, y, (byte)spec);

        /// <summary>
        /// __m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8) VPBLENDD ymm, ymm, ymm/m256, imm8
        /// Forms a vector z[i] := testbit(spec,i) ? x[i] : y[i], i = 0,...7
        /// </summary>
        /// <param name="x">The left vector</param>
        /// <param name="y">The right vector</param>
        /// <param name="spec">The blend specification</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vblend(Vector256<uint> x, Vector256<uint> y, [Imm] Blend8x32 spec)
            => Blend(x, y, (byte)spec);
    }
}