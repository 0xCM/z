//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static System.Runtime.Intrinsics.X86.Avx2;
    using static System.Runtime.Intrinsics.X86.Sse2;
    using static Root;
    using static core;

    partial struct cpu
    {
        /// <summary>
        /// Defines the unfortunately missing _mm_slli_epi8 that shifts each vector component leftward by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count left</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<byte> vsll(Vector128<byte> src, [Imm] byte count)
        {
            var y = v8u(vsll(v64u(src), count));
            var m = vmsb<byte>(n128, n8, (byte)(8 - count));
            return vand(y,m);
        }

        /// <summary>
        /// Shifts each component in the source vector leftwards by a specified number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count each component</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<sbyte> vsll(Vector128<sbyte> src, [Imm] byte count)
            => v8i(vsll(src.AsByte(), count));

        /// <summary>
        /// __m128i _mm_slli_epi16 (__m128i a, int immediate) PSLLW xmm, imm8
        /// Shifts each component of the source vector leftwards by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<short> vsll(Vector128<short> src, [Imm] byte count)
            => ShiftLeftLogical(src, (byte)count);

        /// <summary>
        /// __m128i _mm_slli_epi16 (__m128i a, int immediate) PSLLW xmm, imm8
        /// Shifts each component of the source vector leftwards by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<ushort> vsll(Vector128<ushort> src, [Imm] byte count)
            => ShiftLeftLogical(src, (byte)count);

        /// <summary>
        /// __m128i _mm_slli_epi32 (__m128i a, int immediate) PSLLD xmm, imm8
        /// Shifts each component of the source vector leftwards by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<int> vsll(Vector128<int> src, [Imm] byte count)
            => ShiftLeftLogical(src, (byte)count);

        /// <summary>
        /// __m128i _mm_slli_epi32 (__m128i a, int immediate) PSLLD xmm, imm8
        /// Shifts each component of the source vector leftwards by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<uint> vsll(Vector128<uint> src, [Imm] byte count)
            => ShiftLeftLogical(src, (byte)count);

        /// <summary>
        /// __m128i _mm_slli_epi64 (__m128i a, int immediate) PSLLQ xmm, imm8
        /// Shifts each component of the source vector leftwards by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<long> vsll(Vector128<long> src, [Imm] byte count)
            => ShiftLeftLogical(src, (byte)count);

        /// <summary>
        /// __m128i _mm_slli_epi64 (__m128i a, int immediate) PSLLQ xmm, imm8
        /// Shifts each component of the source vector leftwards by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<ulong> vsll(Vector128<ulong> src, [Imm] byte count)
            => ShiftLeftLogical(src, (byte)count);

        /// <summary>
        /// Shifts each component in the source vector leftwards by a specified number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count each component</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<sbyte> vsll(Vector256<sbyte> src, [Imm] byte count)
            => vsll(src.AsByte(), count).AsSByte();

        /// <summary>
        /// Defines the unfortunately missing _mm256_slli_epi16 that shifts each vector component
        /// leftward by a common number of bits
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The number of bits to count left</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<byte> vsll(Vector256<byte> src, [Imm] byte count)
        {
            var y = v8u(vsll(v64u(src), count));
            var m = vmsb<byte>(w256, n8, (byte)(8 - count));
            return vand(y,m);
        }

        /// <summary>
        /// __m256i _mm256_slli_epi16 (__m256i a, int imm8) VPSLLW ymm, ymm, imm8
        /// Shifts each component of the source vector leftwards by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<short> vsll(Vector256<short> src, [Imm] byte count)
            => ShiftLeftLogical(src, (byte)count);

        /// <summary>
        /// __m256i _mm256_slli_epi16 (__m256i a, int imm8) VPSLLW ymm, ymm, imm8
        /// Shifts each component of the source vector leftwards by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<ushort> vsll(Vector256<ushort> src, [Imm] byte count)
            => ShiftLeftLogical(src, (byte)count);

        /// <summary>
        /// __m256i _mm256_slli_epi32 (__m256i a, int imm8) VPSLLD ymm, ymm, imm8
        /// Shifts each component of the source vector leftwards by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<int> vsll(Vector256<int> src, [Imm] byte count)
            => ShiftLeftLogical(src, (byte)count);

        /// <summary>
        /// __m256i _mm256_slli_epi32 (__m256i a, int imm8) VPSLLD ymm, ymm, imm8
        /// Shifts each component of the source vector leftwards by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<uint> vsll(Vector256<uint> src, [Imm] byte count)
            => ShiftLeftLogical(src, (byte)count);

        /// <summary>
        /// __m256i _mm256_slli_epi64 (__m256i a, int imm8) VPSLLQ ymm, ymm, imm8
        /// Shifts each component of the source vector leftwards by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<long> vsll(Vector256<long> src, [Imm] byte count)
            => ShiftLeftLogical(src, (byte)count);

        /// <summary>
        /// __m256i _mm256_slli_epi64 (__m256i a, int imm8) VPSLLQ ymm, ymm, imm8
        /// Shifts each component of the source vector leftwards by a common number of bits
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The number of bits to count</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<ulong> vsll(Vector256<ulong> src, [Imm] byte count)
            => ShiftLeftLogical(src, (byte)count);

        /// <summary>
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<byte> vsll(Vector128<byte> src, Vector128<byte> count)
        {
            var y = v16u(count);
            var dst = vsll(vpack.vinflate256x16u(src), y);
            return vpack.vpack128x8u(dst);
        }

        /// <summary>
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<sbyte> vsll(Vector128<sbyte> src, Vector128<sbyte> count)
        {
            var y = v16i(count);
            var dst = vsll(vpack.vinflate256x16i(src), y);
            return vpack.vpack128x8i(dst);
        }

        /// <summary>
        ///  __m128i _mm_sll_epi16 (__m128i a, __m128i count) PSRLW xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<short> vsll(Vector128<short> src, Vector128<short> count)
            => ShiftLeftLogical(src, count);

        /// <summary>
        /// __m128i _mm_sll_epi16 (__m128i a, __m128i count) PSRLW xmm, xmm/m128
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<ushort> vsll(Vector128<ushort> src, Vector128<ushort> count)
            => ShiftLeftLogical(src, count);

        /// <summary>
        /// __m128i _mm_sll_epi16 (__m128i a, __m128i count) PSRLW xmm, xmm/m128
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<int> vsll(Vector128<int> src, Vector128<int> count)
            => ShiftLeftLogical(src, count);

        /// <summary>
        /// __m128i _mm_sll_epi32 (__m128i a, __m128i count) PSRLD xmm, xmm/m128
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<uint> vsll(Vector128<uint> src, Vector128<uint> count)
            => ShiftLeftLogical(src, count);

        /// <summary>
        /// __m128i _mm_sll_epi64 (__m128i a, __m128i count) PSRLQ xmm, xmm/m128
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<long> vsll(Vector128<long> src, Vector128<long> count)
            => ShiftLeftLogical(src, count);

        /// <summary>
        /// __m128i _mm_sll_epi64 (__m128i a, __m128i count) PSRLQ xmm, xmm/m128
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector128<ulong> vsll(Vector128<ulong> src, Vector128<ulong> count)
            => ShiftLeftLogical(src, count);

        /// <summary>
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<sbyte> vsll(Vector256<sbyte> src, Vector128<sbyte> count)
        {
            var y = v16i(count);
            var lo = vsll(vpack.vinflate256x16i(vlo(src)), y);
            var hi = vsll(vpack.vinflate256x16i(vhi(src)), y);
            return vpack.vpack256x8i(lo,hi);
        }

        /// <summary>
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<byte> vsll(Vector256<byte> src, Vector128<byte> count)
        {
            var y = v16u(count);
            var lo = vsll(vpack.vinflate256x16u(vlo(src)), y);
            var hi = vsll(vpack.vinflate256x16u(vhi(src)), y);
            return vpack.vpack256x8u(lo, hi);
        }

        /// <summary>
        /// __m256i _mm256_sll_epi16 (__m256i a, __m128i count) VPSRLW ymm, ymm, xmm/m128
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<short> vsll(Vector256<short> src, Vector128<short> count)
            => ShiftLeftLogical(src, count);

        /// <summary>
        /// __m256i _mm256_sll_epi16 (__m256i a, __m128i count) VPSRLW ymm, ymm, xmm/m128
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<ushort> vsll(Vector256<ushort> src, Vector128<ushort> count)
            => ShiftLeftLogical(src, count);

        /// <summary>
        ///  __m256i _mm256_sll_epi32 (__m256i a, __m128i count) VPSRLD ymm, ymm, xmm/m128
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<int> vsll(Vector256<int> src, Vector128<int> count)
            => ShiftLeftLogical(src, count);

        /// <summary>
        ///  __m256i _mm256_sll_epi32 (__m256i a, __m128i count) VPSRLD ymm, ymm, xmm/m128
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<uint> vsll(Vector256<uint> src, Vector128<uint> count)
            => ShiftLeftLogical(src, count);

        /// <summary>
        /// __m256i _mm256_sll_epi64 (__m256i a, __m128i count) VPSRLQ ymm, ymm, xmm/m128
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<long> vsll(Vector256<long> src, Vector128<long> count)
            => ShiftLeftLogical(src, count);

        /// <summary>
        /// __m256i _mm256_sll_epi64 (__m256i a, __m128i count) VPSRLQ ymm, ymm, xmm/m128
        /// Shifts each source vector component leftwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Sll]
        public static Vector256<ulong> vsll(Vector256<ulong> src, Vector128<ulong> count)
            => ShiftLeftLogical(src, count);

        [MethodImpl(Inline), Op]
        static byte msb8f(byte density)
            => (byte)(byte.MaxValue << (8 - density));

        /// <summary>
        /// The f most significant bits of each 8 bits are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">A value in the range [2,7] that defines the bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline)]
        static Vector128<T> vmsb<T>(N128 w, N8 f, byte d, T t = default)
            where T : unmanaged
                => generic<T>(gcpu.vbroadcast<byte>(w, msb8f(d)));

        /// <summary>
        /// Creates a mask where f most significant bits of each 8 bits are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">A value in the range [2,7] that defines the bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline)]
        static Vector256<T> vmsb<T>(N256 w, N8 f, byte d, T t = default)
            where T : unmanaged
                => generic<T>(gcpu.vbroadcast<byte>(w, msb8f(d)));
    }
}