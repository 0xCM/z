//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vbsll(Vector128<sbyte> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vbsll(Vector128<byte> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vbsll(Vector128<short> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vbsll(Vector128<ushort> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vbsll(Vector128<int> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vbsll(Vector128<uint> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vbsll(Vector128<long> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        ///  __m128i _mm_bslli_si128 (__m128i a, int imm8) PSLLDQ xmm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vbsll(Vector128<ulong> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vbsll(Vector256<sbyte> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vbsll(Vector256<byte> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vbsll(Vector256<short> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vbsll(Vector256<ushort> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vbsll(Vector256<int> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vbsll(Vector256<uint> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vbsll(Vector256<long> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);

        /// <summary>
        /// __m256i _mm256_bslli_epi128 (__m256i a, const int imm8) VPSLLDQ ymm, ymm, imm8
        /// Shifts the source vector leftwards with byte-level resolution
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bytes to shift</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vbsll(Vector256<ulong> x, [Imm] byte count)
            => ShiftLeftLogical128BitLane(x, count);
    }
}