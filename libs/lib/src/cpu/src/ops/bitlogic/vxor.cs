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
        /// Computes the bitwise XOR between operands
        /// __m128i _mm_xor_si128 (__m128i a, __m128i b) PXOR xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector128<sbyte> vxor(Vector128<sbyte> x, Vector128<sbyte> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m128i _mm_xor_si128 (__m128i a, __m128i b) PXOR xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector128<byte> vxor(Vector128<byte> x, Vector128<byte> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m128i _mm_xor_si128 (__m128i a, __m128i b) PXOR xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector128<short> vxor(Vector128<short> x, Vector128<short> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m128i _mm_xor_si128 (__m128i a, __m128i b) PXOR xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector128<ushort> vxor(Vector128<ushort> x, Vector128<ushort> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m128i _mm_xor_si128 (__m128i a, __m128i b) PXOR xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector128<int> vxor(Vector128<int> x, Vector128<int> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m128i _mm_xor_si128 (__m128i a, __m128i b) PXOR xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector128<uint> vxor(Vector128<uint> x, Vector128<uint> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m128i _mm_xor_si128 (__m128i a, __m128i b) PXOR xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector128<long> vxor(Vector128<long> x, Vector128<long> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m128i _mm_xor_si128 (__m128i a, __m128i b) PXOR xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector128<ulong> vxor(Vector128<ulong> x, Vector128<ulong> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m256i _mm256_xor_si256 (__m256i a, __m256i b) VPXOR ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector256<byte> vxor(Vector256<byte> x, Vector256<byte> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m256i _mm256_xor_si256 (__m256i a, __m256i b) VPXOR ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector256<short> vxor(Vector256<short> x, Vector256<short> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m256i _mm256_xor_si256 (__m256i a, __m256i b) VPXOR ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector256<sbyte> vxor(Vector256<sbyte> x, Vector256<sbyte> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m256i _mm256_xor_si256 (__m256i a, __m256i b) VPXOR ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector256<ushort> vxor(Vector256<ushort> x, Vector256<ushort> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m256i _mm256_xor_si256 (__m256i a, __m256i b) VPXOR ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector256<int> vxor(Vector256<int> x, Vector256<int> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m256i _mm256_xor_si256 (__m256i a, __m256i b) VPXOR ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector256<uint> vxor(Vector256<uint> x, Vector256<uint> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m256i _mm256_xor_si256 (__m256i a, __m256i b) VPXOR ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector256<long> vxor(Vector256<long> x, Vector256<long> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m256i _mm256_xor_si256 (__m256i a, __m256i b) VPXOR ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Xor]
        public static Vector256<ulong> vxor(Vector256<ulong> x, Vector256<ulong> y)
            => Xor(x, y);

        /// <summary>
        /// __m128 _mm_xor_ps (__m128 a, __m128 b) XORPS xmm, xmm/m128
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vxor(Vector128<float> lhs, Vector128<float> rhs)
            => Xor(lhs, rhs);

        /// <summary>
        /// __m128d _mm_xor_pd (__m128d a, __m128d b) XORPD xmm, xmm/m128
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vxor(Vector128<double> lhs, Vector128<double> rhs)
            => Xor(lhs, rhs);

        /// <summary>
        /// __m256 _mm256_xor_ps (__m256 a, __m256 b) VXORPS ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vxor(Vector256<float> lhs, Vector256<float> rhs)
            => Xor(lhs, rhs);

        /// <summary>
        ///  __m256 _mm256_xor_ps (__m256 a, __m256 b) VXORPS ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vxor(Vector256<double> lhs, Vector256<double> rhs)
            => Xor(lhs, rhs);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<float> vxor(in Vector128<float> x, in Vector128<float> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m128d _mm_xor_pd (__m128d a, __m128d b) XORPD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector128<double> vxor(in Vector128<double> x, in Vector128<double> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m256 _mm256_xor_ps (__m256 a, __m256 b) VXORPS ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<float> vxor(in Vector256<float> x, in Vector256<float> y)
            => Xor(x, y);

        /// <summary>
        /// Computes the bitwise XOR between operands
        /// __m256d _mm256_xor_pd (__m256d a, __m256d b) VXORPS ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left operand</param>
        /// <param name="y">The right operand</param>
        [MethodImpl(Inline), Op]
        public static Vector256<double> vxor(in Vector256<double> x, in Vector256<double> y)
            => Xor(x, y);
    }
}