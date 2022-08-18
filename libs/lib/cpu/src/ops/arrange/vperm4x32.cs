//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_shuffle_epi32 (__m128i a, int immediate) PSHUFD xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vperm4x32(Vector128<uint> src, [Imm] Perm4L spec)
            => Shuffle(src, (byte)spec);

        /// <summary>
        /// __m128i _mm_shuffle_epi32 (__m128i a, int immediate) PSHUFD xmm, xmm/m128, imm8
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vperm4x32(Vector128<int> src, [Imm] Perm4L spec)
            => Shuffle(src, (byte)spec);

        ///<summary>
        /// __m256i _mm256_shuffle_epi32 (__m256i a, const int imm8) VPSHUFD ymm, ymm/m256, imm8
        /// shuffles signed 32-bit integers in the source vector within 128-bit lanes
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vperm4x32(Vector256<int> src, [Imm] Perm4L spec)
            => Shuffle(src, (byte)spec);

        ///<summary>
        /// __m256i _mm256_shuffle_epi32 (__m256i a, const int imm8) VPSHUFD ymm, ymm/m256, imm8
        /// Shuffles 32-bit source segments within 128-bit lanes
        /// </summary>
        /// <param name="src">The content vector</param>
        /// <param name="spec">The shuffle spec</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vperm4x32(Vector256<uint> src, [Imm] Perm4L spec)
             => Shuffle(src, (byte)spec);
    }
}