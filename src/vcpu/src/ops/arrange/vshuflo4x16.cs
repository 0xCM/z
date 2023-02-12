//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial class vcpu
    {
        /// <summary>
        /// __m128i _mm_shufflelo_epi16 (__m128i a, int control) PSHUFLW xmm, xmm/m128, imm8
        /// </summary>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vshuflo4x16(Vector128<ushort> src, [Imm] byte spec)
            => ShuffleLow(src, spec);

        /// <summary>
        /// __m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8)VPSHUFLW ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vshuflo4x16(Vector256<short> src, [Imm] byte spec)
            => ShuffleLow(src,spec);

        /// <summary>
        /// __m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8)VPSHUFLW ymm, ymm/m256, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vshuflo4x16(Vector256<ushort> src, [Imm] byte spec)
            => ShuffleLow(src,spec);

        /// <summary>
        /// __m128i _mm_shufflelo_epi16 (__m128i a, int control) PSHUFLW xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vshuflo4x16(Vector128<short> src, [Imm] byte spec)
            => ShuffleLow(src, spec);


        /// <summary>
        /// __m128i _mm_shufflelo_epi16 (__m128i a, int control) PSHUFLW xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vshuflo4x16(Vector128<short> src, [Imm] Arrange4L spec)
            => vshuflo4x16(src,(byte)spec);

        /// <summary>
        /// __m128i _mm_shufflelo_epi16 (__m128i a, int control) PSHUFLW xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vshuflo4x16(Vector128<ushort> src, [Imm] Arrange4L spec)
            => vshuflo4x16(src, (byte)spec);

        /// <summary>
        /// __m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8)VPSHUFLW ymm, ymm/m256, imm8
        /// Shuffles the lo 64 bits of each 128-bit lane as determined by the shuffle spec and leaves
        /// the hi 64 bits of each 128-bit lane unchanged
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vshuflo4x16(Vector256<short> src, [Imm] Arrange4L spec)
            => vshuflo4x16(src,(byte)spec);

        /// <summary>
        /// __m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8)VPSHUFLW ymm, ymm/m256, imm8
        /// Shuffles the lo 64 bits of each 128-bit lane as determined by the shuffle spec and leaves the hi 64 bits of each 128-bit lane unchanged
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vshuflo4x16(Vector256<ushort> src, [Imm] Arrange4L spec)
            => vshuflo4x16(src,(byte)spec);
    }
}