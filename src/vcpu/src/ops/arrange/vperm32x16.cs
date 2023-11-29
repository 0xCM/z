//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m512i _mm512_permutevar32x16_epi16 (__m512i a, __m512i spec)
    /// VPERMW zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="a"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vperm32x16(Vector512<short> a, Vector512<short> spec)
        => PermuteVar32x16(a, spec);

    /// <summary>
    /// __m512i _mm512_permutevar32x16_epi16 (__m512i a, __m512i spec)
    /// VPERMW zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="a"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vperm32x16(Vector512<ushort> a, Vector512<ushort> spec)
        => PermuteVar32x16(a, spec);
}