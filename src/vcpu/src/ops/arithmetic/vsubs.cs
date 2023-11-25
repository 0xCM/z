//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// __m128i _mm_subs_epu8 (__m128i a, __m128i b) PSUBUSB xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), SubS]
    public static Vector128<byte> vsubs(Vector128<byte> x, Vector128<byte> y)
        => SubtractSaturate(x, y);

    /// <summary>
    /// __m128i _mm_subs_epi8 (__m128i a, __m128i b) PSUBSB xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), SubS]
    public static Vector128<sbyte> vsubs(Vector128<sbyte> x, Vector128<sbyte> y)
        => SubtractSaturate(x, y);

    /// <summary>
    /// __m128i _mm_subs_epi16 (__m128i a, __m128i b) PSUBSW xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), SubS]
    public static Vector128<short> vsubs(Vector128<short> x, Vector128<short> y)
        => SubtractSaturate(x, y);

    /// <summary>
    /// __m128i _mm_subs_epi16 (__m128i a, __m128i b) PSUBSW xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), SubS]
    public static Vector128<ushort> vsubs(Vector128<ushort> x, Vector128<ushort> y)
        => SubtractSaturate(x, y);

    /// <summary>
    ///  __m256i _mm256_subs_epu8 (__m256i a, __m256i b) VPSUBUSB ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), SubS]
    public static Vector256<byte> vsubs(Vector256<byte> x, Vector256<byte> y)
        => SubtractSaturate(x, y);

    /// <summary>
    ///  __m256i _mm256_subs_epi8 (__m256i a, __m256i b)
    ///  VPSUBSB ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), SubS]
    public static Vector256<sbyte> vsubs(Vector256<sbyte> x, Vector256<sbyte> y)
        => SubtractSaturate(x, y);

    /// <summary>
    /// __m256i _mm256_subs_epi16 (__m256i a, __m256i b)
    /// VPSUBSW ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), SubS]
    public static Vector256<short> vsubs(Vector256<short> x, Vector256<short> y)
        => SubtractSaturate(x, y);

    /// <summary>
    /// __m256i _mm256_subs_epu16 (__m256i a, __m256i b)
    /// VPSUBUSW ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), SubS]
    public static Vector256<ushort> vsubs(Vector256<ushort> x, Vector256<ushort> y)
        => SubtractSaturate(x, y);

    /// <summary>
    /// __m512i _mm512_subs_epu8 (__m512i a, __m512i b)
    /// VPSUBUSB zmm1 {k1}{z}, zmm2, zmm3/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), SubS]
    public static Vector512<byte> vsubs(Vector512<byte> x, Vector512<byte> y)
        => SubtractSaturate(x, y);

    /// <summary>
    /// __m512i _mm512_subs_epi8 (__m512i a, __m512i b)
    /// VPSUBSB zmm1 {k1}{z}, zmm2, zmm3/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), SubS]
    public static Vector512<sbyte> vsubs(Vector512<sbyte> x, Vector512<sbyte> y)
        => SubtractSaturate(x, y);

    /// <summary>
    /// __m512i _mm512_subs_epu16 (__m512i a, __m512i b)
    /// VPSUBUSW zmm1 {k1}{z}, zmm2, zmm3/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), SubS]
    public static Vector512<ushort> vsubs(Vector512<ushort> x, Vector512<ushort> y)
        => SubtractSaturate(x, y);

    /// <summary>
    /// __m512i _mm512_subs_epi16 (__m512i a, __m512i b)
    /// VPSUBSW zmm1 {k1}{z}, zmm2, zmm3/m128
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), SubS]
    public static Vector512<short> vsubs(Vector512<short> x, Vector512<short> y)
        => SubtractSaturate(x, y);

}
