//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_cmpne_epi8 (__m128i a, __m128i b)
    /// VPCMPB k1 {k2}, xmm2, xmm3/m128, imm8(4)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<sbyte> vne(Vector128<sbyte> x, Vector128<sbyte> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// __m128i _mm_cmpne_epu8 (__m128i a, __m128i b)
    /// VPCMPUB k1 {k2}, xmm2, xmm3/m128, imm8(4)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<byte> vne(Vector128<byte> x, Vector128<byte> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<short> vne(Vector128<short> x, Vector128<short> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<ushort> vne(Vector128<ushort> x, Vector128<ushort> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<int> vne(Vector128<int> x, Vector128<int> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// </summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<uint> vne(Vector128<uint> x, Vector128<uint> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<long> vne(Vector128<long> x, Vector128<long> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<ulong> vne(Vector128<ulong> x, Vector128<ulong> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<sbyte> vne(Vector256<sbyte> x, Vector256<sbyte> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<byte> vne(Vector256<byte> x, Vector256<byte> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<short> vne(Vector256<short> x, Vector256<short> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// __m256i _mm256_cmpne_epu16 (__m256i a, __m256i b)
    /// VPCMPUW k1 {k2}, ymm2, ymm3/m256, imm8(4)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<ushort> vne(Vector256<ushort> x, Vector256<ushort> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// __m256i _mm256_cmpne_epi32 (__m256i a, __m256i b)
    /// VPCMPD k1 {k2}, ymm2, ymm3/m256/m32bcst, imm8(4)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<int> vne(Vector256<int> x, Vector256<int> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// __m256i _mm256_cmpne_epu32 (__m256i a, __m256i b)
    /// VPCMPUD k1 {k2}, ymm2, ymm3/m256/m32bcst, imm8(4)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<uint> vne(Vector256<uint> x, Vector256<uint> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// __m256i _mm256_cmpne_epi64 (__m256i a, __m256i b)
    /// VPCMPQ k1 {k2}, ymm2, ymm3/m256/m64bcst, imm8(4)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<long> vne(Vector256<long> x, Vector256<long> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// __m256i _mm256_cmpne_epu64 (__m256i a, __m256i b)
    /// VPCMPUQ k1 {k2}, ymm2, ymm3/m256/m64bcst, imm8(4)
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<ulong> vne(Vector256<ulong> x, Vector256<ulong> y)
        => CompareNotEqual(x,y);

    /// <summary>
    /// __m512i _mm512_cmpne_epi8 (__m512i a, __m512i b)
    /// VPCMPB k1 {k2}, zmm2, zmm3/m512, imm8(4)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Gt]
    public static Vector512<sbyte> vne(Vector512<sbyte> a, Vector512<sbyte> b)
        => CompareNotEqual(a,b);

    /// <summary>
    /// __m512i _mm512_cmpne_epu8 (__m512i a, __m512i b)
    /// VPCMPUB k1 {k2}, zmm2, zmm3/m512, imm8(4)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Gt]
    public static Vector512<byte> vne(Vector512<byte> a, Vector512<byte> b)
        => CompareNotEqual(a,b);

    /// <summary>
    /// __m512i _mm512_cmpne_epi16 (__m512i a, __m512i b)
    /// VPCMPW k1 {k2}, zmm2, zmm3/m512, imm8(4)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Gt]
    public static Vector512<short> vne(Vector512<short> a, Vector512<short> b)
        => CompareNotEqual(a,b);

    /// <summary>
    /// __m512i _mm512_cmpne_epu16 (__m512i a, __m512i b)
    /// VPCMPUW k1 {k2}, zmm2, zmm3/m512, imm8(4)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Gt]
    public static Vector512<ushort> vne(Vector512<ushort> a, Vector512<ushort> b)
        => CompareNotEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<int> vne(Vector512<int> a, Vector512<int> b)
        => CompareNotEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<uint> vne(Vector512<uint> a, Vector512<uint> b)
        => CompareNotEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<long> vne(Vector512<long> a, Vector512<long> b)
        => CompareNotEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<ulong> vne(Vector512<ulong> a, Vector512<ulong> b)
        => CompareNotEqual(a,b);        
}
