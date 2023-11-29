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
    /// Shuffle 16-bit integers in a and b across lanes using the corresponding selector and index in idx, and store the results in dst.
    /// </summary>
    /// <param name="lower"></param>
    /// <param name="indices"></param>
    /// <param name="upper"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vperm16x16x2(Vector256<short> lower, Vector256<short> indices, Vector256<short> upper)
        => PermuteVar16x16x2(lower, indices, upper);

    /// <summary>
    /// __m256i _mm256_permutex2var_epi16 (__m256i a, __m256i idx, __m256i b)
    /// VPERMI2W ymm1 {k1}{z}, ymm2, ymm3/m256
    /// VPERMT2W ymm1 {k1}{z}, ymm2, ymm3/m256
    /// Shuffle 16-bit integers in a and b across lanes using the corresponding selector and index in idx, and store the results in dst.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="idx"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vperm16x16x2(Vector256<ushort> a, Vector256<ushort> idx, Vector256<ushort> b)
        => PermuteVar16x16x2(a, idx, b);        
}