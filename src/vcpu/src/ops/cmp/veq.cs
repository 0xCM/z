//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<sbyte> veq(Vector128<sbyte> x, Vector128<sbyte> y)
        => CompareEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<byte> veq(Vector128<byte> x, Vector128<byte> y)
        => CompareEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<short> veq(Vector128<short> x, Vector128<short> y)
        => CompareEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<ushort> veq(Vector128<ushort> x, Vector128<ushort> y)
        => CompareEqual(x,y);

    /// <summary>
    /// </summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<int> veq(Vector128<int> x, Vector128<int> y)
        => CompareEqual(x,y);

    /// <summary>
    /// </summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<uint> veq(Vector128<uint> x, Vector128<uint> y)
        => CompareEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<long> veq(Vector128<long> x, Vector128<long> y)
        => CompareEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector128<ulong> veq(Vector128<ulong> x, Vector128<ulong> y)
        => CompareEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<sbyte> veq(Vector256<sbyte> x, Vector256<sbyte> y)
        => CompareEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<byte> veq(Vector256<byte> x, Vector256<byte> y)
        => CompareEqual(x,y);

    /// <summary>
    /// __m256i _mm256_cmpeq_epi16 (__m256i a, __m256i b)
    /// VPCMPEQW ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<short> veq(Vector256<short> x, Vector256<short> y)
        => CompareEqual(x,y);

    /// <summary>
    /// __m256i _mm256_cmpeq_epi16 (__m256i a, __m256i b)
    /// VPCMPEQW ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<ushort> veq(Vector256<ushort> x, Vector256<ushort> y)
        => CompareEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<int> veq(Vector256<int> x, Vector256<int> y)
        => CompareEqual(x,y);

    /// <summary>
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<uint> veq(Vector256<uint> x, Vector256<uint> y)
        => CompareEqual(x,y);

    /// <summary>
    /// __m256i _mm256_cmpeq_epi64 (__m256i a, __m256i b)
    /// VPCMPEQQ ymm, ymm, ymm/m256
    /// Compares the source operands for equality. For equal components, the corresponding
    /// component in the result vector has all bits enabled; otherwise all bits are disabled
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<long> veq(Vector256<long> x, Vector256<long> y)
        => CompareEqual(x,y);

    /// <summary>
    /// __m256i _mm256_cmpeq_epi64 (__m256i a, __m256i b)
    /// VPCMPEQQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Eq]
    public static Vector256<ulong> veq(Vector256<ulong> x, Vector256<ulong> y)
        => CompareEqual(x,y);

    /// <summary>
    /// __m512i _mm512_cmpeq_epi8 (__m512i a, __m512i b)
    /// VPCMPEQB k1 {k2}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Gt]
    public static Vector512<sbyte> veq(Vector512<sbyte> a, Vector512<sbyte> b)
        => CompareEqual(a,b);

    /// <summary>
    /// __m512i _mm512_cmpeq_epu8 (__m512i a, __m512i b)
    /// VPCMPEQB k1 {k2}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Gt]
    public static Vector512<byte> veq(Vector512<byte> a, Vector512<byte> b)
        => CompareEqual(a,b);

    /// <summary>
    /// __m512i _mm512_cmpeq_epi16 (__m512i a, __m512i b)
    /// VPCMPEQW k1 {k2}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Gt]
    public static Vector512<short> veq(Vector512<short> a, Vector512<short> b)
        => CompareEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<ushort> veq(Vector512<ushort> a, Vector512<ushort> b)
        => CompareEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<int> veq(Vector512<int> a, Vector512<int> b)
        => CompareEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<uint> veq(Vector512<uint> a, Vector512<uint> b)
        => CompareEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<long> veq(Vector512<long> a, Vector512<long> b)
        => CompareEqual(a,b);

    [MethodImpl(Inline), Gt]
    public static Vector512<ulong> veq(Vector512<ulong> a, Vector512<ulong> b)
        => CompareEqual(a,b);        
}
