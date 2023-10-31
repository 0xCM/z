//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
    /// Extracts the hi 128-bit lane of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vhi(Vector256<sbyte> src)
        => ExtractVector128(src, 1);

    /// <summary>
    /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
    /// Extracts the hi 128-bit lane of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vhi(Vector256<uint> src)
        => ExtractVector128(src, 1);

    /// <summary>
    /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
    /// Extracts the hi 128-bit lane of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vhi(Vector256<ulong> src)
        => ExtractVector128(src, 1);

    /// <summary>
    /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
    /// Extracts the hi 128-bit lane of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vhi(Vector256<byte> src)
        => ExtractVector128(src, 1);

    /// <summary>
    /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
    /// Extracts the hi 128-bit lane of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vhi(Vector256<short> src)
        => ExtractVector128(src, 1);

    /// <summary>
    /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
    /// Extracts the hi 128-bit lane of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vhi(Vector256<ushort> src)
        => ExtractVector128(src, 1);

    /// <summary>
    /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm,  ymm, imm8
    /// Extracts the hi 128-bit lane of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vhi(Vector256<int> src)
        => ExtractVector128(src, 1);

    /// <summary>
    /// __m128i _mm256_extracti128_si256 (__m256i a, const int imm8) VEXTRACTI128 xmm, ymm, imm8
    /// Extracts the hi 128-bit lane of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vhi(Vector256<long> src)
        => ExtractVector128(src, 1);

    /// <summary>
    /// __m256i _mm512_extracti256_si512 (__m512i a, const int imm8)
    /// VEXTRACTI64x4 ymm1/m256 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vhi(Vector512<byte> src)
        => ExtractVector256(src, 1);

    /// <summary>
    /// __m256i _mm512_extracti256_si512 (__m512i a, const int imm8)
    /// VEXTRACTI64x4 ymm1/m256 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vhi(Vector512<sbyte> src)
        => ExtractVector256(src, 1);

    /// <summary>
    /// __m256i _mm512_extracti256_si512 (__m512i a, const int imm8)
    /// VEXTRACTI64x4 ymm1/m256 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vhi(Vector512<short> src)
        => ExtractVector256(src, 1);

    /// <summary>
    /// __m256i _mm512_extracti256_si512 (__m512i a, const int imm8)
    /// VEXTRACTI64x4 ymm1/m256 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vhi(Vector512<ushort> src)
        => ExtractVector256(src, 1);

    /// <summary>
    /// __m256i _mm512_extracti32x8_epi32 (__m512i a, const int imm8)
    /// VEXTRACTI32x8 ymm1/m256 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vhi(Vector512<int> src)
        => ExtractVector256(src, 1);

    /// <summary>
    /// __m256i _mm512_extracti32x8_epi32 (__m512i a, const int imm8)
    /// VEXTRACTI32x8 ymm1/m256 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vhi(Vector512<uint> src)
        => ExtractVector256(src, 1);

    /// <summary>
    /// __m256i _mm512_extracti64x4_epi64 (__m512i a, const int imm8)
    /// VEXTRACTI64x4 ymm1/m256 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vhi(Vector512<long> src)
        => ExtractVector256(src, 1);

    /// <summary>
    /// __m256i _mm512_extracti64x4_epi64 (__m512i a, const int imm8)
    /// VEXTRACTI64x4 ymm1/m256 {k1}{z}, zmm2, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vhi(Vector512<ulong> src)
        => ExtractVector256(src, 1);
}
