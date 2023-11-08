//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_unpacklo_epi8 (__m128i a, __m128i b)
    /// PUNPCKLBW xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vunpacklo(Vector128<sbyte> x, Vector128<sbyte> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m128i _mm_unpacklo_epi8 (__m128i a, __m128i b)
    /// PUNPCKLBW xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vunpacklo(Vector128<byte> x, Vector128<byte> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m128i _mm_unpacklo_epi16 (__m128i a, __m128i b)
    /// PUNPCKLWD xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vunpacklo(Vector128<short> x, Vector128<short> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m128i _mm_unpacklo_epi16 (__m128i a, __m128i b)
    /// PUNPCKLWD xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vunpacklo(Vector128<ushort> x, Vector128<ushort> y)
        => UnpackLow(x,y);

    /// <summary>
    ///  __m128i _mm_unpacklo_epi32 (__m128i a, __m128i b)
    ///  PUNPCKLDQ xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vunpacklo(Vector128<int> x, Vector128<int> y)
        => UnpackLow(x,y);

    /// <summary>
    ///  __m128i _mm_unpacklo_epi32 (__m128i a, __m128i b)
    ///  PUNPCKLDQ xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vunpacklo(Vector128<uint> x, Vector128<uint> y)
        => UnpackLow(x,y);

    /// <summary>
    ///  __m128i _mm_unpacklo_epi64 (__m128i a, __m128i b)
    ///  PUNPCKLQDQ xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vunpacklo(Vector128<long> x, Vector128<long> y)
        => UnpackLow(x,y);

    /// <summary>
    ///  __m128i _mm_unpacklo_epi64 (__m128i a, __m128i b)
    ///  PUNPCKLQDQ xmm, xmm/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vunpacklo(Vector128<ulong> x, Vector128<ulong> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m256i _mm256_unpacklo_epi8 (__m256i a, __m256i b)
    /// VPUNPCKLBW ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vunpacklo(Vector256<sbyte> x, Vector256<sbyte> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m256i _mm256_unpacklo_epi8 (__m256i a, __m256i b)
    /// VPUNPCKLBW ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vunpacklo(Vector256<byte> x, Vector256<byte> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m256i _mm256_unpacklo_epi16 (__m256i a, __m256i b)
    /// VPUNPCKLWD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vunpacklo(Vector256<short> x, Vector256<short> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m256i _mm256_unpacklo_epi16 (__m256i a, __m256i b)
    /// VPUNPCKLWD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vunpacklo(Vector256<ushort> x, Vector256<ushort> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m256i _mm256_unpacklo_epi32 (__m256i a, __m256i b)
    /// VPUNPCKLDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vunpacklo(Vector256<int> x, Vector256<int> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m256i _mm256_unpacklo_epi32 (__m256i a, __m256i b)
    /// VPUNPCKLDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vunpacklo(Vector256<uint> x, Vector256<uint> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b)
    /// VPUNPCKLQDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vunpacklo(Vector256<long> x, Vector256<long> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b)
    /// VPUNPCKLQDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vunpacklo(Vector256<ulong> x, Vector256<ulong> y)
        => UnpackLow(x,y);



    /// <summary>
    /// __m512i _mm512_unpacklo_epi8 (__m512i a, __m512i b)
    /// VPUNPCKLBW zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vunpacklo(Vector512<sbyte> x, Vector512<sbyte> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi8 (__m512i a, __m512i b)
    /// VPUNPCKLBW zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vunpacklo(Vector512<byte> x, Vector512<byte> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi16 (__m512i a, __m512i b)
    /// VPUNPCKLWD zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vunpacklo(Vector512<short> x, Vector512<short> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi16 (__m512i a, __m512i b)
    /// VPUNPCKLWD zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vunpacklo(Vector512<ushort> x, Vector512<ushort> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi32 (__m512i a, __m512i b)
    /// VPUNPCKLDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vunpacklo(Vector512<int> x, Vector512<int> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi32 (__m512i a, __m512i b)
    /// VPUNPCKLDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vunpacklo(Vector512<uint> x, Vector512<uint> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi64 (__m512i a, __m512i b)
    /// VPUNPCKLQDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vunpacklo(Vector512<long> x, Vector512<long> y)
        => UnpackLow(x,y);

    /// <summary>
    /// __m512i _mm512_unpacklo_epi64 (__m512i a, __m512i b)
    /// VPUNPCKLQDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vunpacklo(Vector512<ulong> x, Vector512<ulong> y)
        => UnpackLow(x,y);        
}
