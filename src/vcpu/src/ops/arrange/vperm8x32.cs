//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx) VPERMD ymm, ymm/m256, ymm
    /// Applies a cross-lane permutation over 8 32-bit source vector segments
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The perm spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vperm8x32(Vector256<uint> src, Vector256<uint> spec)
        => PermuteVar8x32(src, spec);

    /// <summary>
    /// __m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx) VPERMD ymm, ymm/m256, ymm
    /// Applies a cross-lane permutation over 8 32-bit source vector segments
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The perm spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vperm8x32(Vector256<int> src, Vector256<int> spec)
        => PermuteVar8x32(src, spec);
}
