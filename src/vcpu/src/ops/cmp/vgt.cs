//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{    
    /// <summary>
    /// __m128i _mm_cmpgt_epi8 (__m128i a, __m128i b) PCMPGTB xmm, xmm/m128
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector128<sbyte> vgt(Vector128<sbyte> x, Vector128<sbyte> y)
        => CompareGreaterThan(x,y);

    /// <summary>
    /// __m128i _mm_cmpgt_epi8 (__m128i a, __m128i b) PCMPGTB xmm, xmm/m128
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector128<byte> vgt(Vector128<byte> x, Vector128<byte> y)
        => CompareGreaterThan(x,y);

    /// <summary>
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector128<short> vgt(Vector128<short> x, Vector128<short> y)
        => CompareGreaterThan(x,y);

    /// <summary>
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector128<ushort> vgt(Vector128<ushort> a, Vector128<ushort> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector128<int> vgt(Vector128<int> a, Vector128<int> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector128<uint> vgt(Vector128<uint> a, Vector128<uint> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector128<long> vgt(Vector128<long> a, Vector128<long> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline),Gt]
    public static Vector128<ulong> vgt(Vector128<ulong> a, Vector128<ulong> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector256<sbyte> vgt(Vector256<sbyte> a, Vector256<sbyte> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// __m256i _mm256_cmpgt_epi8 (__m256i a, __m256i b) VPCMPGTB ymm, ymm, ymm/m256
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector256<byte> vgt(Vector256<byte> a, Vector256<byte> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector256<short> vgt(Vector256<short> a, Vector256<short> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector256<ushort> vgt(Vector256<ushort> a, Vector256<ushort> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// __m256i _mm256_cmpgt_epi32 (__m256i a, __m256i b) VPCMPGTD ymm, ymm, ymm/m256
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector256<int> vgt(Vector256<int> a, Vector256<int> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector256<uint> vgt(Vector256<uint> a, Vector256<uint> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector256<long> vgt(Vector256<long> a, Vector256<long> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// Determines whether component values the left vector are larger than the
    /// corresponding components the right vector. When a left value is larger
    /// than a right value, the corresponding component the result vector
    /// will have all bits enabled; otherwise, all bits the component are disabled
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    [MethodImpl(Inline), Gt]
    public static Vector256<ulong> vgt(Vector256<ulong> a, Vector256<ulong> b)
        => CompareGreaterThan(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<sbyte> vgt(Vector512<sbyte> a, Vector512<sbyte> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// __m512i _mm512_cmpgt_epu8 (__m512i a, __m512i b)
    /// VPCMPUB k1 {k2}, zmm2, zmm3/m512, imm8(6)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Gt]
    public static Vector512<byte> vgt(Vector512<byte> a, Vector512<byte> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// __m512i _mm512_cmpgt_epi16 (__m512i a, __m512i b)
    /// VPCMPGTW k1 {k2}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Gt]
    public static Vector512<short> vgt(Vector512<short> a, Vector512<short> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// __m512i _mm512_cmpgt_epu16 (__m512i a, __m512i b)
    /// VPCMPUW k1 {k2}, zmm2, zmm3/m512, imm8(6)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Gt]
    public static Vector512<ushort> vgt(Vector512<ushort> a, Vector512<ushort> b)
        => CompareGreaterThan(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<int> vgt(Vector512<int> a, Vector512<int> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// __m512i _mm512_cmpgt_epu32 (__m512i a, __m512i b)
    /// VPCMPUD k1 {k2}, zmm2, zmm3/m512/m32bcst, imm8(6)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Gt]
    public static Vector512<uint> vgt(Vector512<uint> a, Vector512<uint> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    /// __m512i _mm512_cmpgt_epi64 (__m512i a, __m512i b)
    /// VPCMPGTQ k1 {k2}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    [MethodImpl(Inline), Gt]
    public static Vector512<long> vgt(Vector512<long> a, Vector512<long> b)
        => CompareGreaterThan(a,b);

    /// <summary>
    ///  __m512i _mm512_cmpgt_epu64 (__m512i a, __m512i b)
    ///  VPCMPUQ k1 {k2}, zmm2, zmm3/m512/m64bcst, imm8(6)
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Gt]
    public static Vector512<ulong> vgt(Vector512<ulong> a, Vector512<ulong> b)
        => CompareGreaterThan(a,b);
}
