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
    public static Vector128<int> vperm4x32x2(Vector128<int> lo, Vector128<int> ix, Vector128<int> hi)
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
    public static Vector128<uint> vperm4x32x2(Vector128<uint> lo, Vector128<uint> ix, Vector128<uint> hi)
        => PermuteVar4x32x2(lo,ix,hi);

}