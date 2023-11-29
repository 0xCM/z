//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m256i _mm256_permutex2var_epi16 (__m256i a, __m256i idx, __m256i b)
    /// VPERMI2W ymm1 {k1}{z}, ymm2, ymm3/m256
    /// VPERMT2W ymm1 {k1}{z}, ymm2, ymm3/m256
    /// Shuffle 16-bit integers in lo and hi across lanes using the corresponding selector and index in ix, and store the results in dst.
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vperm16x16x2(Vector256<short> lo, Vector256<short> ix, Vector256<short> hi)
        => PermuteVar16x16x2(lo, ix, hi);

    /// <summary>
    /// __m256i _mm256_permutex2var_epi16 (__m256i a, __m256i idx, __m256i b)
    /// VPERMI2W ymm1 {k1}{z}, ymm2, ymm3/m256
    /// VPERMT2W ymm1 {k1}{z}, ymm2, ymm3/m256
    /// Shuffle 16-bit integers in lo and hi across lanes using the corresponding selector and index in ix, and store the results in dst.
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vperm16x16x2(Vector256<ushort> lo, Vector256<ushort> ix, Vector256<ushort> hi)
        => PermuteVar16x16x2(lo, ix, hi);        
}