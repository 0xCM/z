//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.Intrinsics.X86.Sse;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;

    partial struct cpu
    {
        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m128i _mm_andnot_si128 (__m128i a, __m128i b) PANDN xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector128<sbyte> vcnonimpl(Vector128<sbyte> x, Vector128<sbyte> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m128i _mm_andnot_si128 (__m128i a, __m128i b) PANDN xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector128<byte> vcnonimpl(Vector128<byte> x, Vector128<byte> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m128i _mm_andnot_si128 (__m128i a, __m128i b) PANDN xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector128<short> vcnonimpl(Vector128<short> x, Vector128<short> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m128i _mm_andnot_si128 (__m128i a, __m128i b) PANDN xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector128<ushort> vcnonimpl(Vector128<ushort> x, Vector128<ushort> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m128i _mm_andnot_si128 (__m128i a, __m128i b) PANDN xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector128<int> vcnonimpl(Vector128<int> x, Vector128<int> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m128i _mm_andnot_si128 (__m128i a, __m128i b) PANDN xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector128<uint> vcnonimpl(Vector128<uint> x, Vector128<uint> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m128i _mm_andnot_si128 (__m128i a, __m128i b) PANDN xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector128<long> vcnonimpl(Vector128<long> x, Vector128<long> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector128<ulong> vcnonimpl(Vector128<ulong> x, Vector128<ulong> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m256i _mm256_andnot_si256 (__m256i a, __m256i b) VPANDN ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector256<sbyte> vcnonimpl(Vector256<sbyte> x, Vector256<sbyte> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m256i _mm256_andnot_si256 (__m256i a, __m256i b) VPANDN ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector256<byte> vcnonimpl(Vector256<byte> x, Vector256<byte> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m256i _mm256_andnot_si256 (__m256i a, __m256i b) VPANDN ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector256<short> vcnonimpl(Vector256<short> x, Vector256<short> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector256<ushort> vcnonimpl(Vector256<ushort> x, Vector256<ushort> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m256i _mm256_andnot_si256 (__m256i a, __m256i b) VPANDN ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector256<int> vcnonimpl(Vector256<int> x, Vector256<int> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m256i _mm256_andnot_si256 (__m256i a, __m256i b) VPANDN ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector256<uint> vcnonimpl(Vector256<uint> x, Vector256<uint> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m256i _mm256_andnot_si256 (__m256i a, __m256i b) VPANDN ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector256<long> vcnonimpl(Vector256<long> x, Vector256<long> y)
            => AndNot(y, x);

        /// <summary>
        /// Computes the converse nonimplication z := x & (~y) for operands x and y
        /// __m256i _mm256_andnot_si256 (__m256i a, __m256i b) VPANDN ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), CNonImpl]
        public static Vector256<ulong> vcnonimpl(Vector256<ulong> x, Vector256<ulong> y)
            => AndNot(y, x);

        /// <summary>
        /// __m128 _mm_andnot_ps (__m128 a, __m128 b) ANDNPS xmm, xmm/m128
        /// Effects the composite operation x & (~y) for the left and right operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vcnonimpl(Vector128<float> x, Vector128<float> y)
            => AndNot(y, x);

        /// <summary>
        ///  __m128d _mm_andnot_pd (__m128d a, __m128d b) ADDNPD xmm, xmm/m128
        /// Effects the composite operation x & (~y) for the left and right operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vcnonimpl(Vector128<double> x, Vector128<double> y)
            => AndNot(y, x);

        /// <summary>
        /// __m256 _mm256_andnot_ps (__m256 a, __m256 b) VANDNPS ymm, ymm, ymm/m256
        /// Effects the composite operation x & (~y) for the left and right operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vcnonimpl(Vector256<float> x, Vector256<float> y)
            => AndNot(y, x);

        /// <summary>
        /// __m256d _mm256_andnot_pd (__m256d a, __m256d b) VANDNPD ymm, ymm, ymm/m256
        /// Effects the composite operation x & (~y) for the left and right operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vcnonimpl(Vector256<double> x, Vector256<double> y)
            => AndNot(y, x);
    }

}