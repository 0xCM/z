//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
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
    /// __m256i _mm256_unpackhi_epi8 (__m256i a, __m256i b)
    /// VPUNPCKHBW ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vmergehi(Vector256<byte> x, Vector256<byte> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m256i _mm256_unpackhi_epi16 (__m256i a, __m256i b) VPUNPCKHWD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vmergehi(Vector256<short> x, Vector256<short> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m256i _mm256_unpackhi_epi32 (__m256i a, __m256i b) VPUNPCKHDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vmergehi(Vector256<int> x, Vector256<int> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m256i _mm256_unpackhi_epi32 (__m256i a, __m256i b) VPUNPCKHDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vmergehi(Vector256<uint> x, Vector256<uint> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m256i _mm256_unpackhi_epi64 (__m256i a, __m256i b) VPUNPCKHQDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vmergehi(Vector256<ulong> x, Vector256<ulong> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m256i _mm256_unpackhi_epi64 (__m256i a, __m256i b)
    /// VPUNPCKHQDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left source vector</param>
    /// <param name="y">The right source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vmergehi(Vector256<long> x, Vector256<long> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m512i _mm512_unpackhi_epi8 (__m512i a, __m512i b)
    /// VPUNPCKHBW zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vmergehi(Vector512<sbyte> x, Vector512<sbyte> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m512i _mm512_unpackhi_epi8 (__m512i a, __m512i b)
    /// VPUNPCKHBW zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vmergehi(Vector512<byte> x, Vector512<byte> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m512i _mm512_unpackhi_epi16 (__m512i a, __m512i b)
    /// VPUNPCKHWD zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vmergehi(Vector512<short> x, Vector512<short> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m512i _mm512_unpackhi_epi16 (__m512i a, __m512i b)
    /// VPUNPCKHWD zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vmergehi(Vector512<ushort> x, Vector512<ushort> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m512i _mm512_unpackhi_epi32 (__m512i a, __m512i b)
    /// VPUNPCKHDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vmergehi(Vector512<int> x, Vector512<int> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m512i _mm512_unpackhi_epi32 (__m512i a, __m512i b)
    /// VPUNPCKHDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vmergehi(Vector512<uint> x, Vector512<uint> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m512i _mm512_unpackhi_epi64 (__m512i a, __m512i b)
    /// VPUNPCKHQDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vmergehi(Vector512<long> x, Vector512<long> y)
        => UnpackHigh(x, y);

    /// <summary>
    /// __m512i _mm512_unpackhi_epi64 (__m512i a, __m512i b)
    /// VPUNPCKHQDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vmergehi(Vector512<ulong> x, Vector512<ulong> y)
        => UnpackHigh(x, y);

}
