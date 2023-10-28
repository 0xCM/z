//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8) VPBLENDD xmm, xmm, xmm/m128, imm8
    /// Combines components from left/right vectors per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vblend4x32(Vector128<int> x, Vector128<int> y, [Imm] byte spec)
        => Blend(x, y, spec);

    /// <summary>
    /// __m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8) VPBLENDD xmm, xmm, xmm/m128, imm8
    /// Combines components from left/right vectors per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vblend4x32(Vector128<uint> x, Vector128<uint> y, [Imm] byte spec)
        => Blend(x, y, spec);

    /// <summary>
    /// __m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8) VPBLENDD xmm, xmm, xmm/m128, imm8
    /// Combines components from left/right vectors per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vblend4x32(Vector128<int> x, Vector128<int> y, [Imm] Blend4x32 spec)
        => Blend(x, y, (byte)spec);

    /// <summary>
    /// __m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8) VPBLENDD xmm, xmm, xmm/m128, imm8
    /// Combines components from left/right vectors per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vblend4x32(Vector128<uint> x, Vector128<uint> y, [Imm] Blend4x32 spec)
        => Blend(x, y, (byte)spec);
}

