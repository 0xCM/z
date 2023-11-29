//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m512i _mm512_permutex2var_epi16 (__m512i a, __m512i idx, __m512i b)
    /// VPERMI2W zmm1 {k1}{z}, zmm2, zmm3/m512
    /// VPERMT2W zmm1 {k1}{z}, zmm2, zmm3/m512
    /// Shuffle 64-bit integers in "a" and "b" using the corresponding selector and index in "ix", and store the results in "dst".
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vperm32x16x2(Vector512<short> lo, Vector512<short> ix, Vector512<short> hi)
        => PermuteVar32x16x2(lo,ix,hi);

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
    public static Vector512<ushort> vperm32x16x2(Vector512<ushort> lo, Vector512<ushort> ix, Vector512<ushort> hi)
        => PermuteVar32x16x2(lo,ix,hi);
}