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
    using static System.Runtime.Intrinsics.X86.Avx;
    using static System.Runtime.Intrinsics.X86.Avx2;
    using static Root;

    partial struct cpu
    {
        /// <summary>
        ///  __m128i _mm_unpackhi_epi8 (__m128i a, __m128i b) PUNPCKHBW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vmergehi(Vector128<sbyte> x, Vector128<sbyte> y)
            => UnpackHigh(x, y);

        /// <summary>
        /// __m128i _mm_unpackhi_epi8 (__m128i a, __m128i b) PUNPCKHBW xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vmergehi(Vector128<byte> x, Vector128<byte> y)
            => UnpackHigh(x, y);

        /// <summary>
        /// __m128i _mm_unpackhi_epi16 (__m128i a, __m128i b) PUNPCKHWD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vmergehi(Vector128<short> x, Vector128<short> y)
            => UnpackHigh(x, y);

        /// <summary>
        /// __m128i _mm_unpackhi_epi16 (__m128i a, __m128i b) PUNPCKHWD xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vmergehi(Vector128<ushort> x, Vector128<ushort> y)
            => UnpackHigh(x, y);

        /// <summary>
        ///  __m128i _mm_unpackhi_epi32 (__m128i a, __m128i b) PUNPCKHDQ xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vmergehi(Vector128<int> x, Vector128<int> y)
            => UnpackHigh(x, y);

        /// <summary>
        ///  __m128i _mm_unpackhi_epi32 (__m128i a, __m128i b) PUNPCKHDQ xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vmergehi(Vector128<uint> x, Vector128<uint> y)
            => UnpackHigh(x, y);

        /// <summary>
        /// __m128i _mm_unpackhi_epi64 (__m128i a, __m128i b) PUNPCKHQDQ xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vmergehi(Vector128<long> x, Vector128<long> y)
            => UnpackHigh(x, y);

        /// <summary>
        /// __m128i _mm_unpackhi_epi64 (__m128i a, __m128i b) PUNPCKHQDQ xmm, xmm/m128
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vmergehi(Vector128<ulong> x, Vector128<ulong> y)
            => UnpackHigh(x, y);

        /// <summary>
        /// __m256i _mm256_unpackhi_epi8 (__m256i a, __m256i b) VPUNPCKHBW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vmergehi(Vector256<sbyte> x, Vector256<sbyte> y)
            => UnpackHigh(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// __m256i _mm256_unpackhi_epi8 (__m256i a, __m256i b) VPUNPCKHBW ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vmergehi(Vector256<byte> x, Vector256<byte> y)
            => UnpackHigh(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// __m256i _mm256_unpackhi_epi16 (__m256i a, __m256i b) VPUNPCKHWD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vmergehi(Vector256<short> x, Vector256<short> y)
            => UnpackHigh(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// __m256i _mm256_unpackhi_epi16 (__m256i a, __m256i b) VPUNPCKHWD ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vmergehi(Vector256<ushort> x, Vector256<ushort> y)
            => UnpackHigh(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// __m256i _mm256_unpackhi_epi32 (__m256i a, __m256i b) VPUNPCKHDQ ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vmergehi(Vector256<int> x, Vector256<int> y)
            => UnpackHigh(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// __m256i _mm256_unpackhi_epi32 (__m256i a, __m256i b) VPUNPCKHDQ ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vmergehi(Vector256<uint> x, Vector256<uint> y)
            => UnpackHigh(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// __m256i _mm256_unpackhi_epi64 (__m256i a, __m256i b) VPUNPCKHQDQ ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vmergehi(Vector256<ulong> x, Vector256<ulong> y)
             => UnpackHigh(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// __m256i _mm256_unpackhi_epi64 (__m256i a, __m256i b) VPUNPCKHQDQ ymm, ymm, ymm/m256
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vmergehi(Vector256<long> x, Vector256<long> y)
            => UnpackHigh(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));
    }
}