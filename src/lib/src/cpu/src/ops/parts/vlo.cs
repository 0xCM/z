//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
        /// Extracts the lo 128-bit lane of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="pos">The index of the lane to extract</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vlo(Vector256<sbyte> src)
            => ExtractVector128(src, 0);

        /// <summary>
        /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
        /// Extracts the lo 128-bit lane of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="pos">The index of the lane to extract</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vlo(Vector256<byte> src)
            => ExtractVector128(src, 0);

        /// <summary>
        /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
        /// Extracts the lo 128-bit lane of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="pos">The index of the lane to extract</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vlo(Vector256<short> src)
            => ExtractVector128(src, 0);

        /// <summary>
        /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
        /// Extracts the lo 128-bit lane of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vlo(Vector256<ushort> src)
            => ExtractVector128(src, 0);

        /// <summary>
        /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
        /// Extracts the lo 128-bit lane of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vlo(Vector256<int> src)
            => ExtractVector128(src, 0);

        /// <summary>
        /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
        /// Extracts the lo 128-bit lane of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vlo(Vector256<uint> src)
            => ExtractVector128(src, 0);

        /// <summary>
        /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
        /// Extracts the lo 128-bit lane of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vlo(Vector256<long> src)
            => ExtractVector128(src, 0);

        /// <summary>
        /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
        /// Extracts the lo 128-bit lane of the source vector
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vlo(Vector256<ulong> src)
            => ExtractVector128(src, 0);

        /// <summary>
        /// _m128 _mm256_extractf128_ps (__m256 a, const int imm8)VEXTRACTF128 xmm/m128, ymm, imm8
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vlo(Vector256<float> src)
            => ExtractVector128(src, 0);

        /// <summary>
        /// __m128d _mm256_extractf128_pd (__m256d a, const int imm8)VEXTRACTF128 xmm/m128, ymm, imm8
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vlo(Vector256<double> src)
            => ExtractVector128(src, 0);

        /// <summary>
        /// Extracts the lower 128-bit lane from the source vector to scalar targets
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="x0">Receiver for the lo part of the exracted lane</param>
        /// <param name="x1">Receiver for the hi part of the exracted lane</param>
        [MethodImpl(Inline), Op]
        public static void vlo(Vector256<ulong> src, out ulong x0, out ulong x1)
        {
            x0 = src.GetElement(0);
            x1 = src.GetElement(1);
        }

        /// <summary>
        /// Extracts the lower 128-bit lane from the source vector to scalar targets
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="x0">Receiver for the lo part of the exracted lane</param>
        /// <param name="x1">Receiver for the hi part of the exracted lane</param>
        [MethodImpl(Inline), Op]
        public static void vlo(Vector256<byte> src, out ulong x0, out ulong x1)
        {
            x0 = src.GetElement(0);
            x1 = src.GetElement(1);
        }

        /// <summary>
        /// Extracts the lower 128-bit lane from the source vector to a pair
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="dst">Receiver for the lo part of the exracted lane</param>
        [MethodImpl(Inline)]
        public static ref Pair<ulong> vlo(Vector256<ulong> src, ref Pair<ulong> dst)
        {
            dst.Left = src.GetElement(0);
            dst.Right = src.GetElement(1);
            return ref dst;
        }
    }
}