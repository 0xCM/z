//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu 
{
    /// <summary>
    /// __m128i _mm_sub_epi8 (__m128i a, __m128i b) PSUBB xmm, xmm/m128
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector128<byte> vsub(Vector128<byte> x, Vector128<byte> y)
        => Subtract(x,y);

    /// <summary>
    ///  __m128i _mm_sub_epi8 (__m128i a, __m128i b) PSUBB xmm, xmm/m128
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector128<sbyte> vsub(Vector128<sbyte> x, Vector128<sbyte> y)
        => Subtract(x,y);

    /// <summary>
    /// __m128i _mm_sub_epi16 (__m128i a, __m128i b) PSUBW xmm, xmm/m128
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector128<short> vsub(Vector128<short> x, Vector128<short> y)
        => Subtract(x,y);

    /// <summary>
    /// __m128i _mm_sub_epi16 (__m128i a, __m128i b) PSUBW xmm, xmm/m128
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector128<ushort> vsub(Vector128<ushort> x, Vector128<ushort> y)
        => Subtract(x,y);

    /// <summary>
    /// __m128i _mm_sub_epi32 (__m128i a, __m128i b) PSUBD xmm, xmm/m12
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector128<int> vsub(Vector128<int> x, Vector128<int> y)
        => Subtract(x,y);

    /// <summary>
    /// __m128i _mm_sub_epi32 (__m128i a, __m128i b) PSUBD xmm, xmm/m128
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector128<uint> vsub(Vector128<uint> x, Vector128<uint> y)
        => Subtract(x,y);

    /// <summary>
    /// __m128i _mm_sub_epi64 (__m128i a, __m128i b) PSUBQ xmm, xmm/m128
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector128<long> vsub(Vector128<long> x, Vector128<long> y)
        => Subtract(x,y);

    /// <summary>
    /// __m128i _mm_sub_epi64 (__m128i a, __m128i b) PSUBQ xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector128<ulong> vsub(Vector128<ulong> x, Vector128<ulong> y)
        => Subtract(x,y);

    /// <summary>
    /// __m256i _mm256_sub_epi8 (__m256i a, __m256i b) VPSUBB ymm, ymm, ymm/m256
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector256<byte> vsub(Vector256<byte> x, Vector256<byte> y)
        => Subtract(x, y);

    /// <summary>
    /// __m256i _mm256_sub_epi8 (__m256i a, __m256i b) VPSUBB ymm, ymm, ymm/m256
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector256<sbyte> vsub(Vector256<sbyte> x, Vector256<sbyte> y)
        => Subtract(x, y);

    /// <summary>
    /// __m256i _mm256_sub_epi16 (__m256i a, __m256i b) VPSUBW ymm, ymm, ymm/m256
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector256<short> vsub(Vector256<short> x, Vector256<short> y)
        => Subtract(x, y);

    /// <summary>
    /// __m256i _mm256_sub_epi16 (__m256i a, __m256i b) VPSUBW ymm, ymm, ymm/m256
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector256<ushort> vsub(Vector256<ushort> x, Vector256<ushort> y)
        => Subtract(x, y);

    /// <summary>
    ///  __m256i _mm256_sub_epi32 (__m256i a, __m256i b) VPSUBD ymm, ymm, ymm/m256
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector256<int> vsub(Vector256<int> x, Vector256<int> y)
        => Subtract(x, y);

    /// <summary>
    ///  __m256i _mm256_sub_epi32 (__m256i a, __m256i b) VPSUBD ymm, ymm, ymm/m256
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector256<uint> vsub(Vector256<uint> x, Vector256<uint> y)
        => Subtract(x, y);

    /// <summary>
    /// __m256i _mm256_sub_epi64 (__m256i a, __m256i b) VPSUBQ ymm, ymm, ymm/m256
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector256<long> vsub(Vector256<long> x, Vector256<long> y)
        => Subtract(x, y);

    /// <summary>
    /// __m256i _mm256_sub_epi64 (__m256i a, __m256i b) VPSUBQ ymm, ymm, ymm/m256
    /// Subtracts the right vector from the left
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector256<ulong> vsub(Vector256<ulong> x, Vector256<ulong> y)
        => Subtract(x, y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector512<byte> vsub(Vector512<byte> x, Vector512<byte> y)
        => Subtract(x, y);

    /// <summary>
    /// __m512i _mm512_sub_epi8 (__m512i a, __m512i b)
    /// VPSUBB zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector512<sbyte> vsub(Vector512<sbyte> x, Vector512<sbyte> y)
        => Subtract(x, y);

    /// <summary>
    /// __m512i _mm512_sub_epi16 (__m512i a, __m512i b)
    /// VPSUBW zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector512<short> vsub(Vector512<short> x, Vector512<short> y)
        => Subtract(x, y);

    /// <summary>
    /// __m512i _mm512_sub_epi16 (__m512i a, __m512i b)
    /// VPSUBW zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector512<ushort> vsub(Vector512<ushort> x, Vector512<ushort> y)
        => Subtract(x, y);

    /// <summary>
    /// __m512i _mm512_sub_epi32 (__m512i a, __m512i b)
    /// VPSUBD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector512<int> vsub(Vector512<int> x, Vector512<int> y)
        => Subtract(x, y);

    /// <summary>
    /// __m512i _mm512_sub_epi32 (__m512i a, __m512i b)
    /// VPSUBD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector512<uint> vsub(Vector512<uint> x, Vector512<uint> y)
        => Subtract(x, y);

    /// <summary>
    /// __m512i _mm512_sub_epi64 (__m512i a, __m512i b)
    /// VPSUBQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector512<long> vsub(Vector512<long> x, Vector512<long> y)
        => Subtract(x, y);

    /// <summary>
    /// __m512i _mm512_sub_epi64 (__m512i a, __m512i b)
    /// VPSUBQ zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Sub]
    public static Vector512<ulong> vsub(Vector512<ulong> x, Vector512<ulong> y)
        => Subtract(x, y);
}
