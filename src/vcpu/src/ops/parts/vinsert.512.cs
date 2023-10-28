//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public enum VectorLane : byte
{
    L0 = 0,

    L1 = 1,

    L2 = 2,

    L3 = 3
}

partial class vcpu
{
    /// <summary>
    /// __m512i _mm512_inserti128_si512 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI32x4 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="lane"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vinsert(Vector128<sbyte> src, Vector512<sbyte> dst, [Imm] VectorLane lane)
        => InsertVector128(dst, src, (byte)lane);

    /// <summary>
    /// __m512i _mm512_inserti128_si512 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI32x4 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="lane"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vinsert(Vector128<byte> src, Vector512<byte> dst, [Imm] VectorLane lane)
        => InsertVector128(dst, src, (byte)lane);

    /// <summary>
    /// __m512i _mm512_inserti128_si512 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI32x4 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="lane"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vinsert(Vector128<short> src, Vector512<short> dst, [Imm] VectorLane lane)
        => InsertVector128(dst, src, (byte)lane);

    /// <summary>
    /// __m512i _mm512_inserti128_si512 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI32x4 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="lane"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vinsert(Vector128<ushort> src, Vector512<ushort> dst, [Imm] VectorLane lane)
        => InsertVector128(dst, src, (byte)lane);

    /// <summary>
    /// __m512i _mm512_inserti32x4_epi32 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI32x4 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="lane"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vinsert(Vector128<int> src, Vector512<int> dst, [Imm] VectorLane lane)
        => InsertVector128(dst, src, (byte)lane);

    /// <summary>
    /// __m512i _mm512_inserti32x4_epi32 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI32x4 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="lane"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vinsert(Vector128<uint> src, Vector512<uint> dst, [Imm] VectorLane lane)
        => InsertVector128(dst, src, (byte)lane);

    /// <summary>
    /// __m512i _mm512_inserti64x2_si512 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI64x2 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="lane"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vinsert(Vector128<long> src, Vector512<long> dst, [Imm] VectorLane lane)
        => InsertVector128(dst, src, (byte)lane);

    /// <summary>
    /// __m512i _mm512_inserti64x2_si512 (__m512i a, __m128i b, const int imm8)
    /// VINSERTI64x2 zmm1 {k1}{z}, zmm2, xmm3/m128, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="lane"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vinsert(Vector128<ulong> src, Vector512<ulong> dst, [Imm] VectorLane lane)
        => InsertVector128(dst, src, (byte)lane);


    /// <summary>
    /// __m512i _mm512_inserti256_si512 (__m512i a, __m256i b, const int imm8)
    /// VINSERTI64x4 zmm1 {k1}{z}, zmm2, xmm3/m256, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vinsert(Vector256<byte> src, Vector512<byte> dst, [Imm] VectorLane index)
        => InsertVector256(dst, src, (byte)index);

    /// <summary>
    /// __m512i _mm512_inserti256_si512 (__m512i a, __m256i b, const int imm8)
    /// VINSERTI64x4 zmm1 {k1}{z}, zmm2, xmm3/m256, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vinsert(Vector256<sbyte> src, Vector512<sbyte> dst, [Imm] VectorLane index)
        => InsertVector256(dst, src, (byte)index);

    /// <summary>
    /// __m512i _mm512_inserti256_si512 (__m512i a, __m256i b, const int imm8)
    /// VINSERTI64x4 zmm1 {k1}{z}, zmm2, xmm3/m256, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vinsert(Vector256<short> src, Vector512<short> dst, [Imm] VectorLane index)
        => InsertVector256(dst, src, (byte)index);

    /// <summary>
    /// __m512i _mm512_inserti256_si512 (__m512i a, __m256i b, const int imm8)
    /// VINSERTI64x4 zmm1 {k1}{z}, zmm2, xmm3/m256, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vinsert(Vector256<ushort> src, Vector512<ushort> dst, [Imm] VectorLane index)
        => InsertVector256(dst, src, (byte)index);

    /// <summary>
    /// __m512i _mm512_inserti32x8_si512 (__m512i a, __m256i b, const int imm8)
    /// VINSERTI32x8 zmm1 {k1}{z}, zmm2, xmm3/m256, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vinsert(Vector256<int> src, Vector512<int> dst, [Imm] VectorLane index)
        => InsertVector256(dst, src, (byte)index);

    /// <summary>
    /// __m512i _mm512_inserti32x8_si512 (__m512i a, __m256i b, const int imm8)
    /// VINSERTI32x8 zmm1 {k1}{z}, zmm2, xmm3/m256, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vinsert(Vector256<uint> src, Vector512<uint> dst, [Imm] VectorLane index)
        => InsertVector256(dst, src, (byte)index);

    /// <summary>
    /// __m512i _mm512_inserti64x4_epi64 (__m512i a, __m256i b, const int imm8)
    /// VINSERTI64x4 zmm1 {k1}{z}, zmm2, xmm3/m256, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vinsert(Vector256<long> src, Vector512<long> dst, [Imm] VectorLane index)
        => InsertVector256(dst, src, (byte)index);

    /// <summary>
    /// __m512i _mm512_inserti64x4_epi64 (__m512i a, __m256i b, const int imm8)
    /// VINSERTI64x4 zmm1 {k1}{z}, zmm2, xmm3/m256, imm8
    /// </summary>
    /// <param name="src"></param>
    /// <param name="dst"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vinsert(Vector256<ulong> src, Vector512<ulong> dst, [Imm] VectorLane index)
        => InsertVector256(dst, src, (byte)index);
}
