//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
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
    /// <remarks>__m256i _mm256_unpacklo_epi32 (__m256i a, __m256i b) VPUNPCKLDQ ymm, ymm, ymm/m256</remarks>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vmergelo(Vector256<uint> x, Vector256<uint> y)
        => UnpackLow(x, y);

    /// <summary>
    /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    /// <remarks>__m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b) VPUNPCKLQDQ ymm, ymm, ymm/m256</remarks>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vmergelo(Vector256<long> x, Vector256<long> y)
        => UnpackLow(x, y);

    /// <summary>
    /// ([A,B,C,D], [E,F,G,H]) -> [A,E,B,F]
    /// __m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b)
    /// VPUNPCKLQDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vmergelo(Vector256<ulong> x, Vector256<ulong> y)
        => UnpackLow(x, y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi8 (__m512i a, __m512i b)
    /// VPUNPCKLBW zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vmergelo(Vector512<sbyte> x, Vector512<sbyte> y)
        => UnpackLow(x, y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi8 (__m512i a, __m512i b)
    /// VPUNPCKLBW zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vmergelo(Vector512<byte> x, Vector512<byte> y)
        => UnpackLow(x, y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi16 (__m512i a, __m512i b)
    /// VPUNPCKLWD zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vmergelo(Vector512<short> x, Vector512<short> y)
        => UnpackLow(x, y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi16 (__m512i a, __m512i b)
    /// VPUNPCKLWD zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vmergelo(Vector512<ushort> x, Vector512<ushort> y)
        => UnpackLow(x, y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi32 (__m512i a, __m512i b)
    /// VPUNPCKLDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vmergelo(Vector512<int> x, Vector512<int> y)
        => UnpackLow(x, y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi32 (__m512i a, __m512i b)
    /// VPUNPCKLDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vmergelo(Vector512<uint> x, Vector512<uint> y)
        => UnpackLow(x, y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi64 (__m512i a, __m512i b)
    /// VPUNPCKLQDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vmergelo(Vector512<long> x, Vector512<long> y)
        => UnpackLow(x, y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi64 (__m512i a, __m512i b)
    /// VPUNPCKLQDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vmergelo(Vector512<ulong> x, Vector512<ulong> y)
        => UnpackLow(x, y);
}
