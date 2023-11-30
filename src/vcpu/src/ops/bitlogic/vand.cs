//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<byte> vand(Vector128<byte> a, Vector128<byte> b)
        => And(a, b);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<short> vand(Vector128<short> a, Vector128<short> b)
        => And(a, b);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<sbyte> vand(Vector128<sbyte> a, Vector128<sbyte> b)
        => And(a, b);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<ushort> vand(Vector128<ushort> a, Vector128<ushort> b)
        => And(a, b);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<int> vand(Vector128<int> a, Vector128<int> b)
        => And(a, b);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<uint> vand(Vector128<uint> a, Vector128<uint> b)
        => And(a, b);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<long> vand(Vector128<long> a, Vector128<long> b)
        => And(a, b);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<ulong> vand(Vector128<ulong> a, Vector128<ulong> b)
        => And(a, b);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<byte> vand(Vector256<byte> a, Vector256<byte> b)
        => And(a, b);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<short> vand(Vector256<short> a, Vector256<short> b)
        => And(a, b);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<sbyte> vand(Vector256<sbyte> a, Vector256<sbyte> b)
        => And(a, b);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<ushort> vand(Vector256<ushort> a, Vector256<ushort> b)
        => And(a, b);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<int> vand(Vector256<int> a, Vector256<int> b)
        => And(a, b);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<uint> vand(Vector256<uint> a, Vector256<uint> b)
        => And(a, b);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<long> vand(Vector256<long> a, Vector256<long> b)
        => And(a, b);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<ulong> vand(Vector256<ulong> a, Vector256<ulong> b)
        => And(a, b);

    /// <summary>
    /// __m512i _mm512_and_si512 (__m512i a, __m512i b) 
    /// VPANDD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), And]
    public static Vector512<byte> vand(Vector512<byte> a, Vector512<byte> b)
        => And(a, b);

    /// <summary>
    /// __m512i _mm512_and_si512 (__m512i a, __m512i b) 
    /// VPANDD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), And]
    public static Vector512<sbyte> vand(Vector512<sbyte> a, Vector512<sbyte> b)
        => And(a, b);

    /// <summary>
    /// __m512i _mm512_and_si512 (__m512i a, __m512i b)
    /// VPANDD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), And]
    public static Vector512<short> vand(Vector512<short> a, Vector512<short> b)
        => And(a, b);

    /// <summary>
    /// __m512i _mm512_and_si512 (__m512i a, __m512i b)
    /// VPANDD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), And]
    public static Vector512<ushort> vand(Vector512<ushort> a, Vector512<ushort> b)
        => And(a, b);

    /// <summary>
    /// __m512i _mm512_and_epi32 (__m512i a, __m512i b)
    /// VPANDD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), And]
    public static Vector512<int> vand(Vector512<int> a, Vector512<int> b)
        => And(a, b);

    /// <summary>
    /// __m512i _mm512_and_epi32 (__m512i a, __m512i b)
    /// VPANDD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), And]
    public static Vector512<uint> vand(Vector512<uint> a, Vector512<uint> b)
        => And(a, b);

    /// <summary>
    /// __m512i _mm512_and_epi64 (__m512i a, __m512i b)
    /// VPANDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), And]
    public static Vector512<long> vand(Vector512<long> a, Vector512<long> b)
        => And(a, b);

    /// <summary>
    /// __m512i _mm512_and_epi64 (__m512i a, __m512i b)
    /// VPANDQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    [MethodImpl(Inline), And]
    public static Vector512<ulong> vand(Vector512<ulong> a, Vector512<ulong> b)
        => And(a, b);
}
