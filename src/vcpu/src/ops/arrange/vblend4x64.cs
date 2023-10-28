//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m256d _mm256_blend_pd (__m256d a, __m256d b, const int imm8) VBLENDPD ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vblend4x64(Vector256<long> x, Vector256<long> y, [Imm] byte spec)
        => v64i(Blend(v64f(x), v64f(y), spec));

    /// <summary>
    /// __m256d _mm256_blend_pd (__m256d a, __m256d b, const int imm8) VBLENDPD ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vblend4x64(Vector256<ulong> x, Vector256<ulong> y, [Imm] byte spec)
        => v64u(Blend(v64f(x), v64f(y), spec));

    /// <summary>
    /// __m256d _mm256_blend_pd (__m256d a, __m256d b, const int imm8) VBLENDPD ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vblend4x64(Vector256<long> x, Vector256<long> y, [Imm] Blend4x64 spec)
        => vblend4x64(x, y,(byte)spec);

    /// <summary>
    /// __m256d _mm256_blend_pd (__m256d a, __m256d b, const int imm8) VBLENDPD ymm, ymm, ymm/m256, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vblend4x64(Vector256<ulong> x, Vector256<ulong> y, [Imm] Blend4x64 spec)
        => vblend4x64(x,y,(byte)spec);
}
