//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// __m128i _mm_maddubs_epi16 (__m128i a, __m128i b) PMADDUBSW xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vmuladj(Vector128<byte> x, Vector128<sbyte> y)
        => MultiplyAddAdjacent(x,y);

    /// <summary>
    /// __m256i _mm256_maddubs_epi16 (__m256i a, __m256i b) VPMADDUBSW ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vmuladj(Vector256<byte> x, Vector256<sbyte> y)
        => MultiplyAddAdjacent(x,y);

    /// <summary>
    ///  __m256i _mm256_madd_epi16 (__m256i a, __m256i b) VPMADDWD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vmuladj(Vector256<short> x, Vector256<short> y)
        => MultiplyAddAdjacent(x,y);

    /// <summary>
    /// __m512i _mm512_maddubs_epi16 (__m512i a, __m512i b)
    /// VPMADDUBSW zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vmuladj(Vector512<byte> x, Vector512<sbyte> y)
        => MultiplyAddAdjacent(x,y);

    /// <summary>
    /// __m512i _mm512_madd_epi16 (__m512i a, __m512i b)
    /// VPMADDWD zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vmuladj(Vector512<short> x, Vector512<short> y)
        => MultiplyAddAdjacent(x,y);
}
