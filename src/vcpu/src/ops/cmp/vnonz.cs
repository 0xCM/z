//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector128<byte> src)
        => !TestZ(src,src);

    /// <summary>
    /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector128<sbyte> src)
        => !TestZ(src, src);

    /// <summary>
    /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector128<short> src)
        => !TestZ(src, src);

    /// <summary>
    /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector128<ushort> src)
        => !TestZ(src, src);

    /// <summary>
    /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector128<int> src)
        => !TestZ(src, src);

    /// <summary>
    /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector128<uint> src)
        => !TestZ(src, src);

    /// <summary>
    /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector128<long> src)
        => !TestZ(src, src);

    /// <summary>
    /// int _mm_testz_si128 (__m128i a, __m128i b) PTEST xmm, xmm/m128
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector128<ulong> src)
        => !TestZ(src, src);

    /// <summary>
    /// Returns true if the source vector is nonzero, false otherwise
    /// int _mm_testz_ps (__m128 a, __m128 b) VTESTPS xmm, xmm/m128
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector128<float> src)
        => !TestZ(src, src);

    /// <summary>
    /// Returns true if the source vector is nonzero, false otherwise
    /// int _mm_testz_pd (__m128d a, __m128d b) VTESTPD xmm, xmm/m128
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector128<double> src)
        => !TestZ(src, src);

    /// <summary>
    /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector256<byte> src)
        => !TestZ(src,src);

    /// <summary>
    /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector256<sbyte> src)
        => !TestZ(src,src);

    /// <summary>
    /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector256<short> src)
        => ! TestZ(src,src);

    /// <summary>
    /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector256<ushort> src)
        => ! TestZ(src,src);

    /// <summary>
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector256<int> src)
        => ! TestZ(src,src);

    /// <summary>
    /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector256<uint> src)
        => !TestZ(src,src);

    /// <summary>
    /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector256<long> src)
        => !TestZ(src,src);

    /// <summary>
    /// int _mm256_testz_si256 (__m256i a, __m256i b) VPTEST ymm, ymm/m256
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector256<ulong> src)
        => !TestZ(src,src);

    /// <summary>
    /// int _mm256_testz_ps (__m256 a, __m256 b) VTESTPS ymm, ymm/m256
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector256<float> src)
        => !TestZ(src,src);

    /// <summary>
    /// int _mm256_testz_pd (__m256d a, __m256d b) VTESTPD ymm, ymm/m256
    /// Returns true if the source vector is nonzero, false otherwise
    /// </summary>
    /// <param name="src">The vector to test</param>
    [MethodImpl(Inline), Nonz]
    public static bool vnonz(Vector256<double> src)
        => !TestZ(src,src);
}
