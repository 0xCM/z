//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_shufflelo_epi16 (__m128i a, int control) PSHUFLW xmm, xmm/m128, imm8
        /// Shuffles the lower half of a vector as specified by a permutation while leaving the upper half unchanged
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="spec">The permutation spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vpermlo4x16(Vector128<short> src, [Imm] Perm4L spec)
            => ShuffleLow(src, (byte)spec);

        /// <summary>
        /// __m128i _mm_shufflelo_epi16 (__m128i a, int control) PSHUFLW xmm, xmm/m128, imm8
        /// Shuffles the lower half of a vector as specified by a permutation while leaving the upper half unchanged
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="spec">The permutation spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vpermlo4x16(Vector128<ushort> src, [Imm] Perm4L spec)
            => ShuffleLow(src, (byte)spec);

        /// <summary>
        /// __m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8) VPSHUFLW ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="spec">The permutation spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vpermlo4x16(Vector256<short> src, [Imm] Perm4L spec)
            => ShuffleLow(src, (byte)spec);

        /// <summary>
        /// __m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8) VPSHUFLW ymm, ymm/m256,imm8
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="spec">The permutation spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vpermlo4x16(Vector256<ushort> src, [Imm] Perm4L spec)
            => ShuffleLow(src, (byte)spec);
    }
}