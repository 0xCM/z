//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
    /// Computes the bitwise or between the source operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector128<byte> vor(Vector128<byte> a, Vector128<byte> b)
        => Or(a, b);

    /// <summary>
    ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
    /// Computes the bitwise or between the source operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector128<short> vor(Vector128<short> a, Vector128<short> b)
        => Or(a, b);

    /// <summary>
    ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
    /// Computes the bitwise or between the source operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector128<sbyte> vor(Vector128<sbyte> a, Vector128<sbyte> b)
        => Or(a, b);

    /// <summary>
    ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
    /// Computes the bitwise or between the source operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector128<ushort> vor(Vector128<ushort> a, Vector128<ushort> b)
        => Or(a, b);

    /// <summary>
    ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
    /// Computes the bitwise or between the source operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector128<int> vor(Vector128<int> a, Vector128<int> b)
        => Or(a, b);

    /// <summary>
    ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
    /// Computes the bitwise or between the source operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector128<uint> vor(Vector128<uint> a, Vector128<uint> b)
        => Or(a, b);

    /// <summary>
    ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
    /// Computes the bitwise or between the source operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector128<long> vor(Vector128<long> a, Vector128<long> b)
        => Or(a, b);

    /// <summary>
    ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
    /// Computes the bitwise or between the source operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector128<ulong> vor(Vector128<ulong> a, Vector128<ulong> b)
        => Or(a, b);

    /// <summary>
    ///  __m128i _mm_or_si128 (__m128i a, __m128i b) POR xmm, xmm/m128
    /// Computes the bitwise or between the source operands
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector256<byte> vor(Vector256<byte> a, Vector256<byte> b)
        => Or(a, b);

    /// <summary>
    ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector256<short> vor(Vector256<short> a, Vector256<short> b)
        => Or(a, b);

    /// <summary>
    ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector256<sbyte> vor(Vector256<sbyte> a, Vector256<sbyte> b)
        => Or(a, b);

    /// <summary>
    ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector256<ushort> vor(Vector256<ushort> a, Vector256<ushort> b)
        => Or(a, b);

    /// <summary>
    ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector256<int> vor(Vector256<int> a, Vector256<int> b)
        => Or(a, b);

    /// <summary>
    ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector256<uint> vor(Vector256<uint> a, Vector256<uint> b)
        => Or(a, b);

    /// <summary>
    ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector256<long> vor(Vector256<long> a, Vector256<long> b)
        => Or(a, b);

    /// <summary>
    ///  __m256i _mm256_or_si256 (__m256i a, __m256i b) VPOR ymm, ymm, ymm/m25
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Or]
    public static Vector256<ulong> vor(Vector256<ulong> a, Vector256<ulong> b)
        => Or(a, b);

    /// <summary>
    /// __m512i _mm512_or_si512 (__m512i a, __m512i b)
    /// VPORD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Or]
    public static Vector512<byte> vor(Vector512<byte> a, Vector512<byte> b)
        => Or(a, b);

    /// <summary>
    /// __m512i _mm512_or_si512 (__m512i a, __m512i b)
    /// VPORD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Or]
    public static Vector512<sbyte> vor(Vector512<sbyte> a, Vector512<sbyte> b)
        => Or(a, b);

    /// <summary>
    /// __m512i _mm512_or_si512 (__m512i a, __m512i b)
    /// VPORD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Or]
    public static Vector512<short> vor(Vector512<short> a, Vector512<short> b)
        => Or(a, b);

    /// <summary>
    /// __m512i _mm512_or_si512 (__m512i a, __m512i b)
    /// VPORD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Or]
    public static Vector512<ushort> vor(Vector512<ushort> a, Vector512<ushort> b)
        => Or(a, b);

    /// <summary>
    /// __m512i _mm512_or_epi32 (__m512i a, __m512i b)
    /// VPORD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Or]
    public static Vector512<int> vor(Vector512<int> a, Vector512<int> b)
        => Or(a, b);

    /// <summary>
    /// __m512i _mm512_or_epi32 (__m512i a, __m512i b)
    /// VPORD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Or]
    public static Vector512<uint> vor(Vector512<uint> a, Vector512<uint> b)
        => Or(a, b);

    /// <summary>
    /// __m512i _mm512_or_epi64 (__m512i a, __m512i b)
    /// VPORQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Or]
    public static Vector512<long> vor(Vector512<long> a, Vector512<long> b)
        => Or(a, b);

    /// <summary>
    /// __m512i _mm512_or_epi64 (__m512i a, __m512i b)
    /// VPORQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Or]
    public static Vector512<ulong> vor(Vector512<ulong> a, Vector512<ulong> b)
        => Or(a, b);
}
