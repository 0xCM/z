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
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively identifying low or hi </param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vlane(Vector128<byte> src, Vector256<byte> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively identifying low or hi </param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vlane(Vector128<byte> src, Vector256<byte> dst, N0 index)
            => InsertVector128(dst, src, 0);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively identifying low or hi </param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vlane(Vector128<byte> src, Vector256<byte> dst, N1 index)
            => InsertVector128(dst, src, 1);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifying low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vlane(Vector128<short> src, Vector256<short> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifying low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vlane(Vector128<short> src, Vector256<short> dst, N0 index)
            => InsertVector128(dst, src, 0);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifying low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vlane(Vector128<short> src, Vector256<short> dst, N1 index)
            => InsertVector128(dst, src, 1);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifying low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vlane(Vector128<ushort> src, Vector256<ushort> dst, [Imm] LaneIndex index)
            => InsertVector128(dst, src, (byte)index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifying low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vlane(Vector128<ushort> src, Vector256<ushort> dst, N0 index)
            => InsertVector128(dst, src, 0);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifying low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vlane(Vector128<ushort> src, Vector256<ushort> dst, N1 index)
            => InsertVector128(dst, src, 1);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifying low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vlane(Vector128<int> src, Vector256<int> dst, [Imm] byte index)
            => InsertVector128(dst, src, index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifying low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vlane(Vector128<uint> src, Vector256<uint> dst, [Imm] byte index)
            => InsertVector128(dst, src, index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifying low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vlane(Vector128<long> src, Vector256<long> dst, [Imm] byte index)
            => InsertVector128(dst, src, index);

        /// <summary>
        ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
        /// Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
        /// identifying low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vlane(Vector128<ulong> src, Vector256<ulong> dst, [Imm] byte index)
            => InsertVector128(dst, src, index);

        /// <summary>
        /// _mm256_insertf128_ps: Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane the target to overwrite, either 0 or 1 respectively
        /// identifying low or hi</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vlane(Vector128<float> src, Vector256<float> dst, [Imm] byte index)
            => InsertVector128(dst, src, index);

        /// <summary>
        /// _mm256_insertf128_pd: Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively identifying low or hi </param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vlane(Vector128<double> src, Vector256<double> dst, [Imm] byte index)
            => InsertVector128(dst, src, index);

        /// <summary>
        /// _mm256_insertf128_pd: Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively identifying low or hi </param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vlane(Vector128<double> src, Vector256<double> dst, N0 index)
            => InsertVector128(dst, src, 0);

        /// <summary>
        /// _mm256_insertf128_pd: Overwrites a 128-bit lane in the target with the content of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">The target vector</param>
        /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively identifying low or hi </param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vlane(Vector128<double> src, Vector256<double> dst, N1 index)
            => InsertVector128(dst, src, 1);
    }
}