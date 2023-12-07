//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_permutex2var_epi64 (__m128i a, __m128i idx, __m128i b)
    /// VPERMI2Q xmm1 {k1}{z}, xmm2, xmm3/m128/m64bcst
    /// Shuffle 64-bit integers in "a" and "b" using the corresponding selector and index in "ix", and store the results in "dst".
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vpermi2q(Vector128<long> lo, Vector128<long> ix, Vector128<long> hi)
        => PermuteVar2x64x2(lo,ix,hi);

    /// <summary>
    /// __m128i _mm_permutex2var_epi64 (__m128i a, __m128i idx, __m128i b)
    /// VPERMI2Q xmm1 {k1}{z}, xmm2, xmm3/m128/m64bcst
    /// Shuffle 64-bit integers in "a" and "b" using the corresponding selector and index in "ix", and store the results in "dst".
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vpermi2q(Vector128<ulong> lo, Vector128<ulong> ix, Vector128<ulong> hi)
        => PermuteVar2x64x2(lo,ix,hi);

    /// <summary>
    /// __m256i _mm256_permutex2var_epi64 (__m256i a, __m256i idx, __m256i b)
    /// VPERMI2Q ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst
    /// VPERMT2Q ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vpermi2q(Vector256<long> lo, Vector256<long> ix, Vector256<long> hi)
        => PermuteVar4x64x2(lo,ix,hi);

    /// <summary>
    /// __m256i _mm256_permutex2var_epi64 (__m256i a, __m256i idx, __m256i b)
    /// VPERMI2Q ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst
    /// VPERMT2Q ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vpermi2q(Vector256<ulong> lo, Vector256<ulong> ix, Vector256<ulong> hi)
        => PermuteVar4x64x2(lo,ix,hi);

    /// <summary>
    /// __m512i _mm512_permutex2var_epi64 (__m512i a, __m512i idx, __m512i b)
    /// VPERMI2Q zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vpermi2q(Vector512<long> lo, Vector512<long> ix, Vector512<long> hi)
        => PermuteVar8x64x2(lo,ix,hi);

    /// <summary>
    /// __m512i _mm512_permutex2var_epi64 (__m512i a, __m512i idx, __m512i b)
    /// VPERMI2Q zmm1 {k1}{z}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vpermi2q(Vector512<ulong> lo, Vector512<ulong> ix, Vector512<ulong> hi)
        => PermuteVar8x64x2(lo,ix,hi);
}