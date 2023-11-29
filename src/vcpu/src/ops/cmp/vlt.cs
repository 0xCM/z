//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_cmplt_epi8 (__m128i a, __m128i b)PCMPGTB xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector128<sbyte> vlt(Vector128<sbyte> x, Vector128<sbyte> y)
        => Sse2.CompareLessThan(x,y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector128<byte> vlt(Vector128<byte> a, Vector128<byte> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m128i _mm_cmplt_epi16 (__m128i a, __m128i b)PCMPGTW xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector128<short> vlt(Vector128<short> x, Vector128<short> y)
        => Sse2.CompareLessThan(x,y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector128<ushort> vlt(Vector128<ushort> a, Vector128<ushort> b)
        => Avx512BWVL.CompareLessThan(a,b);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector128<int> vlt(Vector128<int> a, Vector128<int> b)
        => Avx512BW.CompareLessThan(a,b);

    /// <summary>
    /// __m128i _mm_vcmplt_epi32 (__m128i a, __m128i b)PCMPGTD xmm, xmm/m128
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector128<uint> vlt(Vector128<uint> a, Vector128<uint> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector128<long> vlt(Vector128<long> a, Vector128<long> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector128<ulong> vlt(Vector128<ulong> a, Vector128<ulong> b)
        => CompareLessThan(a,b);

    /// <summary>
    ///  __m256i _mm256_cmplt_epi8 (__m256i a, __m256i b)
    ///  VPCMPB k1 {k2}, ymm2, ymm3/m256, imm8(1)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector256<sbyte> vlt(Vector256<sbyte> a, Vector256<sbyte> b)
        => CompareLessThan(a,b);

    /// <summary>
    ///  __m256i _mm256_cmplt_epu8 (__m256i a, __m256i b)
    ///  VPCMPUB k1 {k2}, ymm2, ymm3/m256, imm8(1)
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector256<byte> vlt(Vector256<byte> a, Vector256<byte> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m256i _mm256_cmplt_epi16 (__m256i a, __m256i b)
    /// VPCMPW k1 {k2}, ymm2, ymm3/m256, imm8(1)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector256<short> vlt(Vector256<short> x, Vector256<short> y)
        => CompareLessThan(y,x);

    /// <summary>
    /// __m256i _mm256_cmplt_epu16 (__m256i a, __m256i b)
    /// VPCMPUW k1 {k2}, ymm2, ymm3/m256, imm8(1)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector256<ushort> vlt(Vector256<ushort> a, Vector256<ushort> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m256i _mm256_cmplt_epi32 (__m256i a, __m256i b)
    /// VPCMPD k1 {k2}, ymm2, ymm3/m256/m32bcst, imm8(1)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector256<int> vlt(Vector256<int> a, Vector256<int> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m256i _mm256_cmplt_epu32 (__m256i a, __m256i b)
    /// VPCMPUD k1 {k2}, ymm2, ymm3/m256/m32bcst, imm8(1)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector256<uint> vlt(Vector256<uint> a, Vector256<uint> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m256i _mm256_cmplt_epi64 (__m256i a, __m256i b)
    /// VPCMPQ k1 {k2}, ymm2, ymm3/m256/m64bcst, imm8(1)
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector256<long> vlt(Vector256<long> a, Vector256<long> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m256i _mm256_cmpgt_epi64 (__m256i a, __m256i b)
    /// VPCMPGTQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Lt]
    public static Vector256<ulong> vlt(Vector256<ulong> a, Vector256<ulong> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m512i _mm512_cmplt_epi8 (__m512i a, __m512i b)
    /// VPCMPB k1 {k2}, zmm2, zmm3/m512, imm8(1)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Lt]
    public static Vector512<sbyte> vlt(Vector512<sbyte> a, Vector512<sbyte> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m512i _mm512_cmplt_epu8 (__m512i a, __m512i b)
    /// VPCMPUB k1 {k2}, zmm2, zmm3/m512, imm8(1)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Lt]
    public static Vector512<byte> vlt(Vector512<byte> a, Vector512<byte> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m512i _mm512_cmplt_epi16 (__m512i a, __m512i b)
    /// VPCMPW k1 {k2}, zmm2, zmm3/m512, imm8(1)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Lt]
    public static Vector512<short> vlt(Vector512<short> a, Vector512<short> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m512i _mm512_cmplt_epu16 (__m512i a, __m512i b)
    /// VPCMPUW k1 {k2}, zmm2, zmm3/m512, imm8(1)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Lt]
    public static Vector512<ushort> vlt(Vector512<ushort> a, Vector512<ushort> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m512i _mm512_cmplt_epi32 (__m512i a, __m512i b)
    /// VPCMPD k1 {k2}, zmm2, zmm3/m512/m32bcst, imm8(1)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Lt]
    public static Vector512<int> vlt(Vector512<int> a, Vector512<int> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m512i _mm512_cmplt_epu32 (__m512i a, __m512i b)
    /// VPCMPUD k1 {k2}, zmm2, zmm3/m512/m32bcst, imm8(1)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Lt]
    public static Vector512<uint> vlt(Vector512<uint> a, Vector512<uint> b)
        => CompareLessThan(a,b);

    [MethodImpl(Inline), Lt]
    public static Vector512<long> vlt(Vector512<long> a, Vector512<long> b)
        => CompareLessThan(a,b);

    /// <summary>
    /// __m512i _mm512_cmplt_epu64 (__m512i a, __m512i b)
    /// VPCMPUQ k1 {k2}, zmm2, zmm3/m512/m64bcst, imm8(1)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Lt]
    public static Vector512<ulong> vlt(Vector512<ulong> a, Vector512<ulong> b)
        => CompareLessThan(a,b);
}
