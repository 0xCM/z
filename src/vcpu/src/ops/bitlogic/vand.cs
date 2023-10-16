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
    public static Vector128<byte> vand(Vector128<byte> x, Vector128<byte> y)
        => And(x, y);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<short> vand(Vector128<short> x, Vector128<short> y)
        => And(x, y);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<sbyte> vand(Vector128<sbyte> x, Vector128<sbyte> y)
        => And(x, y);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<ushort> vand(Vector128<ushort> x, Vector128<ushort> y)
        => And(x, y);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<int> vand(Vector128<int> x, Vector128<int> y)
        => And(x, y);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<uint> vand(Vector128<uint> x, Vector128<uint> y)
        => And(x, y);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<long> vand(Vector128<long> x, Vector128<long> y)
        => And(x, y);

    /// <summary>
    /// __m128i _mm_and_si128 (__m128i a, __m128i b) PAND xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector128<ulong> vand(Vector128<ulong> x, Vector128<ulong> y)
        => And(x, y);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<byte> vand(Vector256<byte> x, Vector256<byte> y)
        => And(x, y);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<short> vand(Vector256<short> x, Vector256<short> y)
        => And(x, y);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<sbyte> vand(Vector256<sbyte> x, Vector256<sbyte> y)
        => And(x, y);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<ushort> vand(Vector256<ushort> x, Vector256<ushort> y)
        => And(x, y);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<int> vand(Vector256<int> x, Vector256<int> y)
        => And(x, y);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<uint> vand(Vector256<uint> x, Vector256<uint> y)
        => And(x, y);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<long> vand(Vector256<long> x, Vector256<long> y)
        => And(x, y);

    /// <summary>
    /// __m256i _mm256_and_si256 (__m256i a, __m256i b) VPAND ymm, ymm, ymm/m256
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), And]
    public static Vector256<ulong> vand(Vector256<ulong> x, Vector256<ulong> y)
        => And(x, y);

    /// <summary>
    /// __m128 _mm_and_ps (__m128 a, __m128 b) ANDPS xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<float> vand(Vector128<float> x, Vector128<float> y)
        => And(x, y);

    /// <summary>
    /// __m128d _mm_and_pd (__m128d a, __m128d b) ANDPD xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<double> vand(Vector128<double> x, Vector128<double> y)
        => And(x, y);

    /// <summary>
    /// __m128 _mm_and_ps (__m128 a, __m128 b) ANDPS xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<float> vand(Vector256<float> x, Vector256<float> y)
        => And(x, y);

    /// <summary>
    /// __m128d _mm_and_pd (__m128d a, __m128d b) ANDPD xmm, xmm/m128
    /// Computes the logical and of the operands
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<double> vand(Vector256<double> x, Vector256<double> y)
        => And(x, y);

    [MethodImpl(Inline), And]
    public static Vector512<byte> vand(Vector512<byte> x, Vector512<byte> y)
        => And(x, y);

    [MethodImpl(Inline), And]
    public static Vector512<short> vand(Vector512<short> x, Vector512<short> y)
        => And(x, y);

    [MethodImpl(Inline), And]
    public static Vector512<sbyte> vand(Vector512<sbyte> x, Vector512<sbyte> y)
        => And(x, y);

    [MethodImpl(Inline), And]
    public static Vector512<ushort> vand(Vector512<ushort> x, Vector512<ushort> y)
        => And(x, y);

    [MethodImpl(Inline), And]
    public static Vector512<int> vand(Vector512<int> x, Vector512<int> y)
        => And(x, y);

    [MethodImpl(Inline), And]
    public static Vector512<uint> vand(Vector512<uint> x, Vector512<uint> y)
        => And(x, y);

    [MethodImpl(Inline), And]
    public static Vector512<long> vand(Vector512<long> x, Vector512<long> y)
        => And(x, y);

    [MethodImpl(Inline), And]
    public static Vector512<ulong> vand(Vector512<ulong> x, Vector512<ulong> y)
        => And(x, y);
}
