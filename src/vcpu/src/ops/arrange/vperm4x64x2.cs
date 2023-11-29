//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m256i _mm256_permutex2var_epi64 (__m256i a, __m256i idx, __m256i b)
    /// VPERMI2Q ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst
    /// VPERMT2Q ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vperm4x64x2(Vector256<long> lo, Vector256<long> ix, Vector256<long> hi)
        => PermuteVar4x64x2(lo,ix,hi);

    /// <summary>
    /// __m256i _mm256_permutex2var_epi64 (__m256i a, __m256i idx, __m256i b)
    /// VPERMI2Q ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst
    /// VPERMT2Q ymm1 {k1}{z}, ymm2, ymm3/m256/m64bcst
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vperm4x64x2(Vector256<ulong> lo, Vector256<ulong> ix, Vector256<ulong> hi)
        => PermuteVar4x64x2(lo,ix,hi);
}