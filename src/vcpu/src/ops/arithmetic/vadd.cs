//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;


partial class vcpu 
{
    /// <summary>
    /// __m128i _mm_add_epi8 (__m128i a, __m128i b) PADDB xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector128<byte> vadd(Vector128<byte> x, Vector128<byte> y)
        => Add(x, y);

    /// <summary>
    /// __m128i _mm_add_epi8 (__m128i a, __m128i b) PADDB xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector128<sbyte> vadd(Vector128<sbyte> x, Vector128<sbyte> y)
        => Add(x, y);

    /// <summary>
    /// __m128i _mm_add_epi16 (__m128i a, __m128i b) PADDW xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector128<short> vadd(Vector128<short> x, Vector128<short> y)
        => Add(x, y);

    /// <summary>
    /// __m128i _mm_add_epi16 (__m128i a, __m128i b) PADDW xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector128<ushort> vadd(Vector128<ushort> x, Vector128<ushort> y)
        => Add(x, y);

    /// <summary>
    ///  __m128d _mm_add_pd (__m128d a, __m128d b) ADDPD xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector128<int> vadd(Vector128<int> x, Vector128<int> y)
        => Add(x, y);

    /// <summary>
    /// __m128i _mm_add_epi32 (__m128i a, __m128i b) PADDD xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector128<uint> vadd(Vector128<uint> x, Vector128<uint> y)
        => Add(x, y);

    /// <summary>
    ///  __m128i _mm_add_epi64 (__m128i a, __m128i b) PADDQ xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector128<long> vadd(Vector128<long> x, Vector128<long> y)
        => Add(x, y);

    /// <summary>
    /// __m128i _mm_add_epi64 (__m128i a, __m128i b) PADDQ xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector128<ulong> vadd(Vector128<ulong> x, Vector128<ulong> y)
        => Add(x, y);

    /// <summary>
    ///  __m256i _mm256_add_epi8 (__m256i a, __m256i b) VPADDB ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector256<byte> vadd(Vector256<byte> x, Vector256<byte> y)
        => Add(x, y);

    /// <summary>
    /// __m256i _mm256_add_epi8 (__m256i a, __m256i b) VPADDB ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector256<sbyte> vadd(Vector256<sbyte> x, Vector256<sbyte> y)
        => Add(x, y);

    /// <summary>
    /// __m256i _mm256_add_epi16 (__m256i a, __m256i b) VPADDW ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector256<short> vadd(Vector256<short> x, Vector256<short> y)
        => Add(x, y);

    /// <summary>
    /// __m256i _mm256_add_epi16 (__m256i a, __m256i b) VPADDW ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector256<ushort> vadd(Vector256<ushort> x, Vector256<ushort> y)
        => Add(x, y);

    /// <summary>
    ///  __m256i _mm256_add_epi32 (__m256i a, __m256i b) VPADDD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector256<int> vadd(Vector256<int> x, Vector256<int> y)
        => Add(x, y);

    /// <summary>
    ///  __m256i _mm256_add_epi32 (__m256i a, __m256i b) VPADDD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector256<uint> vadd(Vector256<uint> x, Vector256<uint> y)
        => Add(x, y);

    /// <summary>
    /// __m256i _mm256_add_epi64 (__m256i a, __m256i b) VPADDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector256<long> vadd(Vector256<long> x, Vector256<long> y)
        => Add(x, y);

    /// <summary>
    /// __m256i _mm256_add_epi64 (__m256i a, __m256i b) VPADDQ ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector256<ulong> vadd(Vector256<ulong> x, Vector256<ulong> y)
        => Add(x, y);

    /// <summary>
    /// __m128 _mm_add_ps (__m128 a, __m128 b) ADDPS xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector128<float> vadd(Vector128<float> x, Vector128<float> y)
        => Add(x, x);

    /// <summary>
    /// __m128d _mm_add_pd (__m128d a, __m128d b) ADDPD xmm, xmm/m128
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector128<double> vadd(Vector128<double> x, Vector128<double> y)
        => Add(x, y);

    /// <summary>
    /// __m256 _mm256_add_ps (__m256 a, __m256 b) VADDPS ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector256<float> vadd(Vector256<float> x, Vector256<float> y)
        => Add(x, y);

    /// <summary>
    /// __m256d _mm256_add_pd (__m256d a, __m256d b) VADDPD ymm, ymm, ymm/m256
    /// </summary>
    /// <param name="x">The left operand</param>
    /// <param name="y">The right operand</param>
    [MethodImpl(Inline), Add]
    public static Vector256<double> vadd(Vector256<double> x, Vector256<double> y)
        => Add(x, y);
}
