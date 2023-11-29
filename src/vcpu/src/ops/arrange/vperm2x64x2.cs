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
    /// VPERMT2Q xmm1 {k1}{z}, xmm2, xmm3/m128/m64bcst
    /// Shuffle 64-bit integers in "a" and "b" using the corresponding selector and index in "ix", and store the results in "dst".
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vperm2x64x2(Vector128<long> lo, Vector128<long> ix, Vector128<long> hi)
        => PermuteVar2x64x2(lo,ix,hi);

    /// <summary>
    /// __m128i _mm_permutex2var_epi64 (__m128i a, __m128i idx, __m128i b)
    /// VPERMI2Q xmm1 {k1}{z}, xmm2, xmm3/m128/m64bcst
    /// VPERMT2Q xmm1 {k1}{z}, xmm2, xmm3/m128/m64bcst
    /// Shuffle 64-bit integers in "a" and "b" using the corresponding selector and index in "ix", and store the results in "dst".
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vperm2x64x2(Vector128<ulong> lo, Vector128<ulong> ix, Vector128<ulong> hi)
        => PermuteVar2x64x2(lo,ix,hi);
}