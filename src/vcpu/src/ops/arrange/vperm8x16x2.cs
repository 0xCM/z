//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_permutex2var_epi16 (__m128i a, __m128i idx, __m128i b)
    /// VPERMI2W xmm1 {k1}{z}, xmm2, xmm3/m128 VPERMT2W xmm1 {k1}{z}, xmm2, xmm3/m128
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vperm8x16x2(Vector128<short> lo, Vector128<short> ix, Vector128<short> hi)
        => PermuteVar8x16x2(lo,ix,hi);

    /// <summary>
    /// __m128i _mm_permutex2var_epi16 (__m128i a, __m128i idx, __m128i b)
    /// VPERMI2W xmm1 {k1}{z}, xmm2, xmm3/m128 VPERMT2W xmm1 {k1}{z}, xmm2, xmm3/m128
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vperm8x16x2(Vector128<ushort> lo, Vector128<ushort> ix, Vector128<ushort> hi)
        => PermuteVar8x16x2(lo,ix,hi);
}