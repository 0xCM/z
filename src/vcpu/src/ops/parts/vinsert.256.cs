//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial class vcpu
    {
        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="lane">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vinsert(Vector128<sbyte> src, Vector256<sbyte> dst, [Imm] LaneIndex lane)
            => InsertVector128(dst, src, (byte)lane);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="lane">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vinsert(Vector128<byte> src, Vector256<byte> dst, [Imm] LaneIndex lane)
            => InsertVector128(dst, src, (byte)lane);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="lane">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vinsert(Vector128<short> src, Vector256<short> dst, [Imm] LaneIndex lane)
            => InsertVector128(dst, src, (byte)lane);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="lane">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vinsert(Vector128<ushort> src, Vector256<ushort> dst, [Imm] LaneIndex lane)
            => InsertVector128(dst, src, (byte)lane);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="lane">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vinsert(Vector128<int> src, Vector256<int> dst, [Imm] LaneIndex lane)
            => InsertVector128(dst, src, (byte)lane);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="lane">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vinsert(Vector128<uint> src, Vector256<uint> dst, [Imm] LaneIndex lane)
            => InsertVector128(dst, src, (byte)lane);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="lane">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vinsert(Vector128<long> src, Vector256<long> dst, [Imm] LaneIndex lane)
            => InsertVector128(dst, src, (byte)lane);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vinsert(Vector128<ulong> src, Vector256<ulong> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        /// _mm256_insertf128_ps: Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vinsert(Vector128<float> src, Vector256<float> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        /// _mm256_insertf128_pd: Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifing low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vinsert(Vector128<double> src, Vector256<double> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);
    }
}