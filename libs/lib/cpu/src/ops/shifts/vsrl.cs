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
    using static LimitValues;

    partial struct cpu
    {
        /// <summary>
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<byte> vsrl(Vector128<byte> src, [Imm] byte count)
        {
            var y = v8u(ShiftRightLogical(v64u(src), count));
            var m = vlsb<byte>(n128, n8, (byte)(8 - count));
            return vand(y,m);
        }

        /// <summary>
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<sbyte> vsrl(Vector128<sbyte> src, [Imm] byte count)
        {
            var x = v16u(ShiftRightLogical(vpack.vinflate256x16i(src),count));
            var y = vand(x, v16u(vbroadcast(w256, byte.MaxValue)));
            return v8i(vpack.vpack128x8u(y));
        }

        /// <summary>
        /// __m128i _mm_srli_epi16 (__m128i a, int immediate) PSRLW xmm, imm8
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<short> vsrl(Vector128<short> src, [Imm] byte count)
            => ShiftRightLogical(src, count);

        /// <summary>
        ///  __m128i _mm_srli_epi16 (__m128i a, int immediate) PSRLW xmm, imm8
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<ushort> vsrl(Vector128<ushort> src, [Imm] byte count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m128i _mm_srli_epi32 (__m128i a, int immediate) PSRLD xmm, imm8
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<int> vsrl(Vector128<int> src, [Imm] byte count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m128i _mm_srli_epi32 (__m128i a, int immediate) PSRLD xmm, imm8
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<uint> vsrl(Vector128<uint> src, [Imm] byte count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m128i _mm_srli_epi64 (__m128i a, int immediate) PSRLQ xmm, imm8
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<long> vsrl(Vector128<long> src, [Imm] byte count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m128i _mm_srli_epi64 (__m128i a, int immediate) PSRLQ xmm, imm8
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<ulong> vsrl(Vector128<ulong> src, [Imm] byte count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<sbyte> vsrl(Vector256<sbyte> src, [Imm] byte count)
        {
            var x = v16u(ShiftRightLogical(vpack.vinflate256x16i(vlo(src)),count));
            var y = v16u(ShiftRightLogical(vpack.vinflate256x16i(vhi(src)),count));
            var m = v16u(vbroadcast(w256, byte.MaxValue));
            return v8i(vpack.vpack256x8u(vand(x,m), vand(y,m)));
        }

        /// <summary>
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="x">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<byte> vsrl(Vector256<byte> src, [Imm] byte count)
        {
            var y = v8u(ShiftRightLogical(v64u(src), count));
            var m = vlsb<byte>(w256, n8, (byte)(8 - count));
            return vand(y,m);
        }

        /// <summary>
        /// __m256i _mm256_srli_epi16 (__m256i a, int imm8) VPSRLW ymm, ymm, imm8
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<short> vsrl(Vector256<short> src, [Imm] byte count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m256i _mm256_srli_epi16 (__m256i a, int imm8) VPSRLW ymm, ymm, imm8
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<ushort> vsrl(Vector256<ushort> src, [Imm] byte count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m256i _mm256_srli_epi32 (__m256i a, int imm8) VPSRLD ymm, ymm, imm8
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<int> vsrl(Vector256<int> src, [Imm] byte count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m256i _mm256_srli_epi32 (__m256i a, int imm8) VPSRLD ymm, ymm, imm8
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<uint> vsrl(Vector256<uint> src, [Imm] byte count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m256i _mm256_srli_epi64 (__m256i a, int imm8) VPSRLQ ymm, ymm, imm8
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<long> vsrl(Vector256<long> src, [Imm] byte count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m256i _mm256_srli_epi64 (__m256i a, int imm8) VPSRLQ ymm, ymm, imm8
        /// Shifts each each component rightward by a specified bitcount
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The bitcount</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<ulong> vsrl(Vector256<ulong> src, [Imm] byte count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<byte> vsrl(Vector128<byte> src, Vector128<byte> count)
        {
            var y = v16u(count);
            var dst = vsrl(vpack.vinflate256x16u(src),y);
            return vpack.vpack128x8u(dst);
        }

        /// <summary>
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<sbyte> vsrl(Vector128<sbyte> src, Vector128<sbyte> count)
        {
            var y = v16i(count);
            var dst = vsrl(vpack.vinflate256x16i(src),y);
            return vpack.vpack128x8i(dst);
        }

        /// <summary>
        ///  __m128i _mm_srl_epi16 (__m128i a, __m128i count) PSRLW xmm, xmm/m128
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<short> vsrl(Vector128<short> src, Vector128<short> count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m128i _mm_srl_epi16 (__m128i a, __m128i count) PSRLW xmm, xmm/m128
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<ushort> vsrl(Vector128<ushort> src, Vector128<ushort> count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m128i _mm_srl_epi16 (__m128i a, __m128i count) PSRLW xmm, xmm/m128
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<int> vsrl(Vector128<int> src, Vector128<int> count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m128i _mm_srl_epi32 (__m128i a, __m128i count) PSRLD xmm, xmm/m128
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<uint> vsrl(Vector128<uint> src, Vector128<uint> count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m128i _mm_srl_epi64 (__m128i a, __m128i count) PSRLQ xmm, xmm/m128
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<long> vsrl(Vector128<long> src, Vector128<long> count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m128i _mm_srl_epi64 (__m128i a, __m128i count) PSRLQ xmm, xmm/m128
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector128<ulong> vsrl(Vector128<ulong> src, Vector128<ulong> count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<sbyte> vsrl(Vector256<sbyte> src, Vector128<sbyte> count)
        {
            var y = v16i(count);
            var lo = vsrl(vpack.vinflate256x16i(vlo(src)), y);
            var hi = vsrl(vpack.vinflate256x16i(vhi(src)),y);
            return vpack.vpack256x8i(lo, hi);
        }

        /// <summary>
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<byte> vsrl(Vector256<byte> src, Vector128<byte> count)
        {
            var y = v16u(count);
            var lo = vsrl(vpack.vinflate256x16u(vlo(src)),y);
            var hi = vsrl(vpack.vinflate256x16u(vhi(src)),y);
            return vpack.vpack256x8u(lo, hi);
        }

        /// <summary>
        /// __m256i _mm256_srl_epi16 (__m256i a, __m128i count)VPSRLW ymm, ymm, xmm/m128
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<short> vsrl(Vector256<short> src, Vector128<short> count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m256i _mm256_srl_epi16 (__m256i a, __m128i count)VPSRLW ymm, ymm, xmm/m128
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<ushort> vsrl(Vector256<ushort> src, Vector128<ushort> count)
            => ShiftRightLogical(src, count);

        /// <summary>
        ///  __m256i _mm256_srl_epi32 (__m256i a, __m128i count) VPSRLD ymm, ymm, xmm/m128
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<int> vsrl(Vector256<int> src, Vector128<int> count)
            => ShiftRightLogical(src, count);

        /// <summary>
        ///  __m256i _mm256_srl_epi32 (__m256i a, __m128i count) VPSRLD ymm, ymm, xmm/m128
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<uint> vsrl(Vector256<uint> src, Vector128<uint> count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m256i _mm256_srl_epi64 (__m256i a, __m128i count) VPSRLQ ymm, ymm, xmm/m128
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<long> vsrl(Vector256<long> src, Vector128<long> count)
            => ShiftRightLogical(src, count);

        /// <summary>
        /// __m256i _mm256_srl_epi64 (__m256i a, __m128i count) VPSRLQ ymm, ymm, xmm/m128
        /// Shifts each source vector component rightwards by an amount specified in the first component of the offset vector
        /// </summary>
        /// <param name="src">The source vector</param>
        /// <param name="count">The offset vector</param>
        [MethodImpl(Inline), Srl]
        public static Vector256<ulong> vsrl(Vector256<ulong> src, Vector128<ulong> count)
            => ShiftRightLogical(src, count);

        [MethodImpl(Inline),Op]
        static byte lsb8f(byte density)
            => (byte)(Max8u >> (8 - density));

        /// <summary>
        /// The f least significant bits of each 8 bit segment are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">A value in the range [2,7] that defines the bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline)]
        static Vector128<T> vlsb<T>(N128 w, N8 f, byte d)
            where T : unmanaged
                => generic<T>(gcpu.vbroadcast<byte>(w, lsb8f(d)));

        /// <summary>
        /// The f least significant bits of each 8 bit segment are enabled
        /// </summary>
        /// <param name="w">The target vector width</param>
        /// <param name="f">The repetition frequency</param>
        /// <param name="d">A value in the range [2,7] that defines the bit density</param>
        /// <typeparam name="T">The vector component type</typeparam>
        [MethodImpl(Inline)]
        static Vector256<T> vlsb<T>(N256 w, N8 f, byte d)
            where T : unmanaged
                => generic<T>(gcpu.vbroadcast<byte>(w, lsb8f(d)));
    }
}