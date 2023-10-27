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
    public static Vector256<byte> vperm8x32(Vector256<byte> src, Vector256<uint> spec)
        => v8u(PermuteVar8x32(v32u(src), spec));

    /// <summary>
    /// __m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx) VPERMD ymm, ymm/m256, ymm
    /// Applies a cross-lane permutation over 8 32-bit source vector segments
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The perm spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vperm8x32(Vector256<sbyte> src, Vector256<uint> spec)
        => v8i(PermuteVar8x32(v32u(src), spec));

    /// <summary>
    /// __m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx) VPERMD ymm, ymm/m256, ymm
    /// Applies a cross-lane permutation over 8 32-bit source vector segments
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The perm spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vperm8x32(Vector256<short> src, Vector256<uint> spec)
        => v16i(PermuteVar8x32(v32u(src), spec));

    /// <summary>
    /// __m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx) VPERMD ymm, ymm/m256, ymm
    /// Applies a cross-lane permutation over 8 32-bit source vector segments
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The perm spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vperm8x32(Vector256<ushort> src, Vector256<uint> spec)
        => v16u(PermuteVar8x32(v32u(src), spec));

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
    public static Vector256<int> vperm8x32(Vector256<int> src, Vector256<uint> spec)
        => PermuteVar8x32(src, v32i(spec));

    /// <summary>
    /// __m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx) VPERMD ymm, ymm/m256, ymm
    /// Applies a cross-lane permutation over 8 32-bit source vector segments
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The perm spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vperm8x32(Vector256<long> src, Vector256<uint> spec)
        => v64i(PermuteVar8x32(v32u(src), spec));

    /// <summary>
    /// __m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx) VPERMD ymm, ymm/m256, ymm
    /// Applies a cross-lane permutation over 8 32-bit source vector segments
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="spec">The perm spec</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vperm8x32(Vector256<ulong> src, Vector256<uint> spec)
        => v64u(PermuteVar8x32(v32u(src), spec));
}
