//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
        /// Computes the bitwise or between the source operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector128<byte> vor(Vector128<byte> x, Vector128<byte> y)
            => Or(x, y);

        /// <summary>
        ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
        /// Computes the bitwise or between the source operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector128<short> vor(Vector128<short> x, Vector128<short> y)
            => Or(x, y);

        /// <summary>
        ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
        /// Computes the bitwise or between the source operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector128<sbyte> vor(Vector128<sbyte> x, Vector128<sbyte> y)
            => Or(x, y);

        /// <summary>
        ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
        /// Computes the bitwise or between the source operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector128<ushort> vor(Vector128<ushort> x, Vector128<ushort> y)
            => Or(x, y);

        /// <summary>
        ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
        /// Computes the bitwise or between the source operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector128<int> vor(Vector128<int> x, Vector128<int> y)
            => Or(x, y);

        /// <summary>
        ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
        /// Computes the bitwise or between the source operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector128<uint> vor(Vector128<uint> x, Vector128<uint> y)
            => Or(x, y);

        /// <summary>
        ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
        /// Computes the bitwise or between the source operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector128<long> vor(Vector128<long> x, Vector128<long> y)
            => Or(x, y);

        /// <summary>
        ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
        /// Computes the bitwise or between the source operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector128<ulong> vor(Vector128<ulong> x, Vector128<ulong> y)
            => Or(x, y);

        /// <summary>
        ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
        /// Computes the bitwise or between the source operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector256<byte> vor(Vector256<byte> x, Vector256<byte> y)
            => Or(x, y);

        /// <summary>
        ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector256<short> vor(Vector256<short> x, Vector256<short> y)
            => Or(x, y);

        /// <summary>
        ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector256<sbyte> vor(Vector256<sbyte> x, Vector256<sbyte> y)
            => Or(x, y);

        /// <summary>
        ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector256<ushort> vor(Vector256<ushort> x, Vector256<ushort> y)
            => Or(x, y);

        /// <summary>
        ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector256<int> vor(Vector256<int> x, Vector256<int> y)
            => Or(x, y);

        /// <summary>
        ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector256<uint> vor(Vector256<uint> x, Vector256<uint> y)
            => Or(x, y);

        /// <summary>
        ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector256<long> vor(Vector256<long> x, Vector256<long> y)
            => Or(x, y);

        /// <summary>
        ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector256<ulong> vor(Vector256<ulong> x, Vector256<ulong> y)
            => Or(x, y);

        /// <summary>
        /// __m128 _mm_or_ps (__m128 a, __m128 b) ORPS xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector128<float> vor(Vector128<float> x, Vector128<float> y)
            => Or(x, y);

        /// <summary>
        /// __m128d _mm_or_pd (__m128d a, __m128d b) ORPD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector128<double> vor(Vector128<double> x, Vector128<double> y)
            => Or(x, y);

        /// <summary>
        /// __m256 _mm256_or_ps (__m256 a, __m256 b) VORPS ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector256<float> vor(Vector256<float> x, Vector256<float> y)
            => Or(x, y);

        /// <summary>
        /// __m256d _mm256_or_pd (__m256d a, __m256d b) VORPD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Or]
        public static Vector256<double> vor(Vector256<double> x, Vector256<double> y)
            => Or(x, y);
    }
}