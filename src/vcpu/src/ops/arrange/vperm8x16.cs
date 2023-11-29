//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_permutevar8x16_epi16 (__m128i a, __m128i b)
    /// VPERMW xmm1 {k1}{z}, xmm2, xmm3/m128
    /// </summary>
    /// <param name="src"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vperm8x16(Vector128<short> src, Vector128<short> spec)
        => PermuteVar8x16(src, spec);

    /// <summary>
    /// __m128i _mm_permutevar8x16_epi16 (__m128i a, __m128i b)
    /// VPERMW xmm1 {k1}{z}, xmm2, xmm3/m128
    /// </summary>
    /// <param name="src"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vperm8x16(Vector128<ushort> src, Vector128<ushort> spec)
        => PermuteVar8x16(src, spec);
}