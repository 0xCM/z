//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_max_epu8 (__m128i a, __m128i b)
    /// PMAXUB xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector128<byte> vmax(Vector128<byte> x, Vector128<byte> y)
        => Max(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector128<sbyte> vmax(Vector128<sbyte> x, Vector128<sbyte> y)
        => Max(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector128<short> vmax(Vector128<short> x, Vector128<short> y)
        => Max(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector128<ushort> vmax(Vector128<ushort> x, Vector128<ushort> y)
        => Max(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector128<int> vmax(Vector128<int> x, Vector128<int> y)
        => Max(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector128<uint> vmax(Vector128<uint> x, Vector128<uint> y)
        => Max(x, y);

    /// <summary>
    /// Computes the maximum values of corresponding components
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline)]
    public static Vector128<ulong> vmax(Vector128<ulong> x, Vector128<ulong> y)
        => Max(x, y);

    /// <summary>
    /// Computes the maximum values of corresponding components
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector128<long> vmax(Vector128<long> x, Vector128<long> y)
        => Max(x, y);

    /// <summary>
    /// __m256i _mm256_max_epu8 (__m256i a, __m256i b)
    /// VPMAXUB ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector256<byte> vmax(Vector256<byte> x, Vector256<byte> y)
        => Max(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector256<sbyte> vmax(Vector256<sbyte> x, Vector256<sbyte> y)
        => Max(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector256<short> vmax(Vector256<short> x, Vector256<short> y)
        => Max(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector256<ushort> vmax(Vector256<ushort> x, Vector256<ushort> y)
        => Max(x, y);

    /// <summary>
    /// __m256i _mm256_max_epi32 (__m256i a, __m256i b)
    /// VPMAXSD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector256<int> vmax(Vector256<int> x, Vector256<int> y)
        => Max(x, y);

    /// <summary>
    /// __m256i _mm256_max_epu32 (__m256i a, __m256i b)
    /// VPMAXUD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector256<uint> vmax(Vector256<uint> x, Vector256<uint> y)
        => Max(x, y);

    /// <summary>
    /// Computes the maximum values of corresponding components
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline)]
    public static Vector256<ulong> vmax(Vector256<ulong> x, Vector256<ulong> y)
        => Max(x, y);

    /// <summary>
    /// Computes the maximum values of corresponding components
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector256<long> vmax(Vector256<long> x, Vector256<long> y)
        => Max(x, y);

    /// <summary>
    /// __m512i _mm512_max_epu8 (__m512i a, __m512i b)
    /// VPMAXUB zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector512<byte> vmax(Vector512<byte> x, Vector512<byte> y)
        => Max(x, y);

    /// <summary>
    /// __m512i _mm512_max_epi8 (__m512i a, __m512i b)
    /// VPMAXSB zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector512<sbyte> vmax(Vector512<sbyte> x, Vector512<sbyte> y)
        => Max(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector512<short> vmax(Vector512<short> x, Vector512<short> y)
        => Max(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector512<ushort> vmax(Vector512<ushort> x, Vector512<ushort> y)
        => Max(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector512<int> vmax(Vector512<int> x, Vector512<int> y)
        => Max(x, y);

    /// <summary>
    /// __m512i _mm512_max_epu32 (__m512i a, __m512i b)
    /// VPMAXUD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector512<uint> vmax(Vector512<uint> x, Vector512<uint> y)
        => Max(x, y);

    /// <summary>
    /// Computes the maximum values of corresponding components
    /// __m512i _mm512_max_epu64 (__m512i a, __m512i b)
    /// VPMAXUQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector512<ulong> vmax(Vector512<ulong> x, Vector512<ulong> y)
        => Max(x, y);

    /// <summary>
    /// Computes the maximum values of corresponding components
    /// __m512i _mm512_max_epi64 (__m512i a, __m512i b)
    /// VPMAXSQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Max]
    public static Vector512<long> vmax(Vector512<long> x, Vector512<long> y)
        => Max(x, y);        
}
