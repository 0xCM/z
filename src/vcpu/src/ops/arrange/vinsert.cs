//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
    /// Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively identifying low or hi </param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vinsert(Vector128<byte> src, Vector256<byte> dst, byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
    /// Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
    /// identifying low or hi</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vinsert(Vector128<short> src, Vector256<short> dst, byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
    ///  VINSERTI128 ymm, ymm, xmm, imm8
    /// Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
    /// identifying low or hi</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vinsert(Vector128<ushort> src, Vector256<ushort> dst, byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
    ///  VINSERTI128 ymm, ymm, xmm, imm8
    /// Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
    /// identifying low or hi</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vinsert(Vector128<int> src, Vector256<int> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
    ///  VINSERTI128 ymm, ymm, xmm, imm8
    /// Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
    /// identifying low or hi</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vinsert(Vector128<uint> src, Vector256<uint> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
    /// Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
    /// identifying low or hi</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vinsert(Vector128<long> src, Vector256<long> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    ///  __m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8) VINSERTI128 ymm, ymm, xmm, imm8
    /// Overwrites a 128-bit lane in the target with the content of the source vector
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    /// <param name="index">Identifies the lane in the target to overwrite, either 0 or 1 respectively
    /// identifying low or hi</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vinsert(Vector128<ulong> src, Vector256<ulong> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    /// __m512i _mm512_inserti128_si512 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI32x4 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vinsert(Vector128<byte> src, Vector512<byte> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    /// __m512i _mm512_inserti128_si512 (__m512i a, __m128i b, const int imm8)
    /// VINSERTF32x4 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vinsert(Vector128<sbyte> src, Vector512<sbyte> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    /// __m512i _mm512_inserti128_si512 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI32x4 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vinsert(Vector128<short> src, Vector512<short> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    /// __m512i _mm512_inserti128_si512 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI32x4 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vinsert(Vector128<ushort> src, Vector512<ushort> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    /// __m512i _mm512_inserti32x4_epi32 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI32x4 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vinsert(Vector128<int> src, Vector512<int> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    /// __m512i _mm512_inserti32x4_epi32 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI32x4 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vinsert(Vector128<uint> src, Vector512<uint> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    /// __m512i _mm512_inserti64x2_si512 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI64x2 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vinsert(Vector128<long> src, Vector512<long> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

    /// <summary>
    /// __m512i _mm512_inserti64x2_si512 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI64x2 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vinsert(Vector128<ulong> src, Vector512<ulong> dst, [Imm] byte index)
        => InsertVector128(dst, src, index);

}
