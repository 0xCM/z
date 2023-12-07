//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_permutex2var_epi32 (__m128i a, __m128i idx, __m128i b)
    /// Shuffle 32-bit integers in "lo" and "hi" using the corresponding selector and index in "ix", and store the results in "dst".
    /// VPERMI2D xmm1 {k1}{z}, xmm2, xmm3/m128/m32bcst
    /// VPERMT2D xmm1 {k1}{z}, xmm2, xmm3/m128/m32bcst
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vpermi2d(Vector128<int> lo, Vector128<int> ix, Vector128<int> hi)
        => PermuteVar4x32x2(lo,ix,hi);

    /// <summary>
    /// __m128i _mm_permutex2var_epi32 (__m128i a, __m128i idx, __m128i b)
    /// VPERMI2D xmm1 {k1}{z}, xmm2, xmm3/m128/m32bcst
    /// VPERMT2D xmm1 {k1}{z}, xmm2, xmm3/m128/m32bcst
    /// Shuffle 32-bit integers in "lo" and "hi" using the corresponding selector and index in "ix", and store the results in "dst".
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vpermi2d(Vector128<uint> lo, Vector128<uint> ix, Vector128<uint> hi)
        => PermuteVar4x32x2(lo,ix,hi);

    /// <summary>
    /// __m256i _mm256_permutex2var_epi32 (__m256i a, __m256i idx, __m256i b)
    /// VPERMI2D ymm1 {k1}{z}, ymm2, ymm3/m256/m32bcst 
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vpermi2d(Vector256<int> lo, Vector256<int> ix, Vector256<int> hi)
        => PermuteVar8x32x2(lo,ix,hi);

    /// <summary>
    /// __m256i _mm256_permutex2var_epi32 (__m256i a, __m256i idx, __m256i b)
    /// VPERMI2D ymm1 {k1}{z}, ymm2, ymm3/m256/m32bcst 
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vpermi2d(Vector256<uint> lo, Vector256<uint> ix, Vector256<uint> hi)
        => PermuteVar8x32x2(lo,ix,hi);

    /// <summary>
    /// __m512i _mm512_permutex2var_epi32 (__m512i a, __m512i idx, __m512i b)
    /// VPERMI2D zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// VPERMT2D zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// Shuffle 32-bit integers in "lo" and "hi" across lanes using the corresponding selector and index in "ix"
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vpermi2d(Vector512<int> lo, Vector512<int> ix, Vector512<int> hi)
        => PermuteVar16x32x2(lo,ix,hi);

    /// <summary>
    /// __m512i _mm512_permutex2var_epi32 (__m512i a, __m512i idx, __m512i b)
    /// VPERMI2D zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// VPERMT2D zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// Shuffle 32-bit integers in "lo" and "hi" across lanes using the corresponding selector and index in "ix"
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vpermi2d(Vector512<uint> lo, Vector512<uint> ix, Vector512<uint> hi)
        => PermuteVar16x32x2(lo,ix,hi);        
}