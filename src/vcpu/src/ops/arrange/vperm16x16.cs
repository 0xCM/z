//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m256i _mm256_permutevar16x16_epi16 (__m256i a, __m256i b)
    /// VPERMW ymm1 {k1}{z}, ymm2, ymm3/m256
    /// </summary>
    /// <param name="src"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vperm16x16(Vector256<short> src, Vector256<short> spec)
        => PermuteVar16x16(src, spec);

    /// <summary>
    /// __m256i _mm256_permutevar16x16_epi16 (__m256i a, __m256i b)
    /// VPERMW ymm1 {k1}{z}, ymm2, ymm3/m256
    /// </summary>
    /// <param name="src"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vperm16x16(Vector256<ushort> src, Vector256<ushort> spec)
        => PermuteVar16x16(src, spec);
}