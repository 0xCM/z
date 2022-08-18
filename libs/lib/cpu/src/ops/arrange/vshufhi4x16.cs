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
        /// __m128i _mm_shufflehi_epi16 (__m128i a, int immediate) PSHUFHW xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vshufhi4x16(Vector128<ushort> src, [Imm] byte spec)
            => ShuffleHigh(src, spec);

        /// <summary>
        /// __m128i _mm_shufflehi_epi16 (__m128i a, int immediate) PSHUFHW xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vshufhi4x16(Vector128<short> src, [Imm] byte spec)
            => ShuffleHigh(src, spec);

        /// <summary>
        /// __m128i _mm_shufflehi_epi16 (__m128i a, int immediate) PSHUFHW xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vshufhi4x16(Vector128<short> src, [Imm] Arrange4L spec)
            => vshufhi4x16(src,(byte)spec);

        /// <summary>
        /// __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)VPSHUFHW ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vshufhi4x16(Vector256<ushort> src, [Imm] byte spec)
            => ShuffleHigh(src,spec);

        /// <summary>
        /// __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)VPSHUFHW ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vshufhi4x16(Vector256<short> src, [Imm] byte spec)
            => ShuffleHigh(src,spec);

        /// <summary>
        /// __m128i _mm_shufflehi_epi16 (__m128i a, int control) PSHUFHW xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vshufhi4x16(Vector128<ushort> src, [Imm] Arrange4L spec)
            => vshufhi4x16(src,(byte)spec);

        /// <summary>
        /// __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)VPSHUFHW ymm, ymm/m256, imm8
        /// Shuffles the hi 64 bits of each 128-bit lane as determined by the shuffle spec and leaves
        /// the lo 64 bits of each 128-bit lane unchanged
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vshufhi4x16(Vector256<ushort> src, [Imm] Arrange4L spec)
            => vshufhi4x16(src,(byte)spec);

        /// <summary>
        /// __m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)VPSHUFHW ymm, ymm/m256, imm8
        /// Shuffles the hi 64 bits of each 128-bit lane as determined by the shuffle spec and leaves
        /// the lo 64 bits of each 128-bit lane unchanged
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vshufhi4x16(Vector256<short> src, [Imm] Arrange4L spec)
            => vshufhi4x16(src,(byte)spec);
    }
}