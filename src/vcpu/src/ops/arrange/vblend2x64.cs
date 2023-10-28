//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vblend2x64(Vector128<byte> x, Vector128<byte> y, [Imm] byte spec)
        => v8u(Blend(v64f(x), v64f(y), (byte)spec));

    /// <summary>
    /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vblend2x64(Vector128<ulong> x, Vector128<ulong> y, [Imm] byte spec)
        => v64u(Blend(v64f(x), v64f(y), spec));

    /// <summary>
    /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vblend2x64(Vector128<long> x, Vector128<long> y, [Imm] byte spec)
        => v64i(Blend(v64f(x), v64f(y), spec));

    /// <summary>
    /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vblend(Vector128<long> x, Vector128<long> y, [Imm] Blend2x64 spec)
        => vblend2x64(x,y,(byte)spec);

    /// <summary>
    /// __m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8) BLENDPD xmm, xmm/m128, imm8
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vblend2x64(Vector128<ulong> x, Vector128<ulong> y, [Imm] Blend2x64 spec)
        => vblend2x64(x,y,(byte)spec);
}
