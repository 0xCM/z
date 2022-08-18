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
        /// __m128i _mm_unpacklo_epi8 (__m128i a, __m128i b) PUNPCKLBW xmm, xmm/m128
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<sbyte> vmergelo(Vector128<sbyte> x, Vector128<sbyte> y)
            => UnpackLow(x, y);

        /// <summary>
        /// __m128i _mm_unpacklo_epi8 (__m128i a, __m128i b) PUNPCKLBW xmm, xmm/m128
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> vmergelo(Vector128<byte> x, Vector128<byte> y)
            => UnpackLow(x, y);

        /// <summary>
        /// __m128i _mm_unpacklo_epi16 (__m128i a, __m128i b) PUNPCKLWD xmm, xmm/m128
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<short> vmergelo(Vector128<short> x, Vector128<short> y)
            => UnpackLow(x, y);

        /// <summary>
        /// __m128i _mm_unpacklo_epi16 (__m128i a, __m128i b) PUNPCKLWD xmm, xmm/m128
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> vmergelo(Vector128<ushort> x, Vector128<ushort> y)
            => UnpackLow(x, y);

        /// <summary>
        /// __m128i _mm_unpacklo_epi32 (__m128i a, __m128i b) PUNPCKLDQ xmm, xmm/m128
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<int> vmergelo(Vector128<int> x, Vector128<int> y)
            => UnpackLow(x, y);

        /// <summary>
        /// __m128i _mm_unpacklo_epi32 (__m128i a, __m128i b) PUNPCKLDQ xmm, xmm/m128
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<uint> vmergelo(Vector128<uint> x, Vector128<uint> y)
            => UnpackLow(x, y);

        /// <summary>
        ///  __m128i _mm_unpacklo_epi64 (__m128i a, __m128i b) PUNPCKLQDQ xmm, xmm/m128
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<long> vmergelo(Vector128<long> x, Vector128<long> y)
            => UnpackLow(x, y);

        /// <summary>
        ///  __m128i _mm_unpacklo_epi64 (__m128i a, __m128i b) PUNPCKLQDQ xmm, xmm/m128
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<ulong> vmergelo(Vector128<ulong> x, Vector128<ulong> y)
            => UnpackLow(x, y);

        /// <summary>
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        /// <remarks>__m256i _mm256_unpacklo_epi8 (__m256i a, __m256i b) VPUNPCKLBW ymm, ymm, ymm/m256</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<byte> vmergelo(Vector256<byte> x, Vector256<byte> y)
           => UnpackLow(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        /// <remarks>__m256i _mm256_unpacklo_epi8 (__m256i a, __m256i b) VPUNPCKLBW ymm, ymm, ymm/m256</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<sbyte> vmergelo(Vector256<sbyte> x, Vector256<sbyte> y)
           => UnpackLow(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        /// <remarks>__m256i _mm256_unpacklo_epi16 (__m256i a, __m256i b) VPUNPCKLWD ymm, ymm, ymm/m256</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<short> vmergelo(Vector256<short> x, Vector256<short> y)
           => UnpackLow(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        /// <remarks>__m256i _mm256_unpacklo_epi16 (__m256i a, __m256i b) VPUNPCKLWD ymm, ymm, ymm/m256</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<ushort> vmergelo(Vector256<ushort> x, Vector256<ushort> y)
           => UnpackLow(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        /// <remarks>__m256i _mm256_unpacklo_epi32 (__m256i a, __m256i b) VPUNPCKLDQ ymm, ymm, ymm/m256</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<int> vmergelo(Vector256<int> x, Vector256<int> y)
           => UnpackLow(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        /// <remarks>__m256i _mm256_unpacklo_epi32 (__m256i a, __m256i b) VPUNPCKLDQ ymm, ymm, ymm/m256</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<uint> vmergelo(Vector256<uint> x, Vector256<uint> y)
           => UnpackLow(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        /// <remarks>__m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b) VPUNPCKLQDQ ymm, ymm, ymm/m256</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<long> vmergelo(Vector256<long> x, Vector256<long> y)
           => UnpackLow(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));

        /// <summary>
        /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
        /// </summary>
        /// <param name="x">The left source vector</param>
        /// <param name="y">The right source vector</param>
        /// <remarks> __m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b) VPUNPCKLQDQ ymm, ymm, ymm/m256</remarks>
        [MethodImpl(Inline), Op]
        public static Vector256<ulong> vmergelo(Vector256<ulong> x, Vector256<ulong> y)
           => UnpackLow(vperm4x64(x, Perm4L.ACBD), vperm4x64(y, Perm4L.ACBD));
    }
}