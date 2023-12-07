//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx)
    /// VPERMD ymm, ymm/m256, ymm
    /// Applies a cross-lane permutation over 8 32-bit source vector segments
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The perm spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vpermd(Vector256<uint> src, Vector256<uint> spec)
        => PermuteVar8x32(src, spec);

    /// <summary>
    /// __m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx)
    /// VPERMD ymm, ymm/m256, ymm
    /// Applies a cross-lane permutation over 8 32-bit source vector segments
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The perm spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vpermd(Vector256<int> src, Vector256<int> spec)
        => PermuteVar8x32(src, spec);

    /// <summary>
    /// __m512i _mm512_permutevar16x32_epi32 (__m512i a, __m512i b)
    /// VPERMD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="src"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vpermd(Vector512<int> src, Vector512<int> spec)
        => PermuteVar16x32(src, spec);

    /// <summary>
    /// __m512i _mm512_permutevar16x32_epi32 (__m512i a, __m512i b)
    /// VPERMD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="src"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vpermd(Vector512<uint> src, Vector512<uint> spec)
        => PermuteVar16x32(src, spec);
}
