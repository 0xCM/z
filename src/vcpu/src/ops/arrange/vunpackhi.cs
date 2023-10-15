//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


partial class vcpu
{
    /// <summary>
    /// __m128i _mm_unpackhi_epi8 (__m128i a, __m128i b) PUNPCKHBW xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vunpackhi(Vector128<sbyte> x, Vector128<sbyte> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m128i _mm_unpackhi_epi8 (__m128i a, __m128i b) PUNPCKHBW xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vunpackhi(Vector128<byte> x, Vector128<byte> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m128i _mm_unpackhi_epi16 (__m128i a, __m128i b) PUNPCKHWD xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vunpackhi(Vector128<short> x, Vector128<short> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m128i _mm_unpackhi_epi16 (__m128i a, __m128i b) PUNPCKHWD xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vunpackhi(Vector128<ushort> x, Vector128<ushort> y)
        => UnpackHigh(x,y);

    /// <summary>
    ///  __m128i _mm_unpackhi_epi32 (__m128i a, __m128i b) PUNPCKHDQ xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vunpackhi(Vector128<int> x, Vector128<int> y)
        => UnpackHigh(x,y);

    /// <summary>
    ///  __m128i _mm_unpackhi_epi64 (__m128i a, __m128i b) PUNPCKHQDQ xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vunpackhi(Vector128<uint> x, Vector128<uint> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m128i _mm_unpackhi_epi64 (__m128i a, __m128i b) PUNPCKHQDQ xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vunpackhi(Vector128<long> x, Vector128<long> y)
        => UnpackHigh(x,y);

    /// <summary>
    ///  __m128i _mm_unpacklo_epi64 (__m128i a, __m128i b) PUNPCKLQDQ xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vunpackhi(Vector128<ulong> x, Vector128<ulong> y)
        => UnpackHigh(x,y);

    /// __m256i _mm256_unpackhi_epi8 (__m256i a, __m256i b) VPUNPCKHBW ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vunpackhi(Vector256<sbyte> x, Vector256<sbyte> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m256i _mm256_unpackhi_epi8 (__m256i a, __m256i b) VPUNPCKHBW ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vunpackhi(Vector256<byte> x, Vector256<byte> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m256i _mm256_unpackhi_epi16 (__m256i a, __m256i b) VPUNPCKHWD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vunpackhi(Vector256<short> x, Vector256<short> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m256i _mm256_unpackhi_epi16 (__m256i a, __m256i b) VPUNPCKHWD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vunpackhi(Vector256<ushort> x, Vector256<ushort> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m256i _mm256_unpackhi_epi32 (__m256i a, __m256i b) VPUNPCKHDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vunpackhi(Vector256<int> x, Vector256<int> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m256i _mm256_unpackhi_epi32 (__m256i a, __m256i b) VPUNPCKHDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vunpackhi(Vector256<uint> x, Vector256<uint> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m256i _mm256_unpackhi_epi64 (__m256i a, __m256i b) VPUNPCKHQDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vunpackhi(Vector256<long> x, Vector256<long> y)
        => UnpackHigh(x,y);

    /// <summary>
    /// __m256i _mm256_unpackhi_epi64 (__m256i a, __m256i b) VPUNPCKHQDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vunpackhi(Vector256<ulong> x, Vector256<ulong> y)
        => UnpackHigh(x,y);


}
