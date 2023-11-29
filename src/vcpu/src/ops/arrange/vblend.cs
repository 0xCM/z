//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_blend_epi16 (__m128i a, __m128i b, const int imm8) PBLENDW xmm, xmm/m128, imm8
    /// Combines components from left/right vectors per the blend spec
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vblend(Vector128<short> a, Vector128<short> b, [Imm] byte spec)
        => Blend(a, b, (byte)spec);

    /// <summary>
    /// __m128i _mm_blend_epi16 (__m128i a, __m128i b, const int imm8) PBLENDW xmm, xmm/m128, imm8
    /// Combines components from left/right vectors per the blend spec
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vblend(Vector128<ushort> a, Vector128<ushort> b, [Imm] byte spec)
        => Blend(a, b, (byte)spec);

    /// <summary>
    /// __m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8) VPBLENDD xmm, xmm, xmm/m128, imm8
    /// Combines components from left/right vectors per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vblend(Vector128<int> x, Vector128<int> y, [Imm] byte spec)
        => Blend(x, y, spec);

    /// <summary>
    /// __m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8) VPBLENDD xmm, xmm, xmm/m128, imm8
    /// Combines components from left/right vectors per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vblend(Vector128<uint> x, Vector128<uint> y, [Imm] byte spec)
        => Blend(x, y, spec);

    /// <summary>
    /// __m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8)
    /// VPBLENDD xmm, xmm, xmm/m128, imm8
    /// Combines components from left/right vectors per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vblend(Vector128<int> x, Vector128<int> y, [Imm] Blend4x32 spec)
        => Blend(x, y, (byte)spec);

    /// <summary>
    /// __m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8) VPBLENDD xmm, xmm, xmm/m128, imm8
    /// Combines components from left/right vectors per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vblend(Vector128<uint> x, Vector128<uint> y, [Imm] Blend4x32 spec)
        => Blend(x, y, (byte)spec);

    /// <summary>
    /// __m256i _mm256_blend_epi16 (__m256i a, __m256i b, const int imm8) VPBLENDW ymm, ymm, ymm/m256, imm8
    /// Combines components from left/right vectors within 128-bit lanes per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vblend(Vector256<short> x, Vector256<short> y, [Imm] byte spec)
        => Blend(x, y, (byte)spec);

    /// <summary>
    /// __m256i _mm256_blend_epi16 (__m256i a, __m256i b, const int imm8) VPBLENDW ymm, ymm, ymm/m256, imm8
    /// Combines components from left/right vectors within 128-bit lanes per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vblend(Vector256<ushort> x, Vector256<ushort> y, [Imm] byte spec)
        => Blend(x, y, (byte)spec);

    /// <summary>
    /// __m128i _mm_blend_epi16 (__m128i a, __m128i b, const int imm8) PBLENDW xmm, xmm/m128, imm8
    /// Combines components from left/right vectors per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vblend(Vector128<short> x, Vector128<short> y, [Imm] Blend8x16 spec)
        => vblend(x, y, (byte)spec);

    /// <summary>
    /// __m128i _mm_blend_epi16 (__m128i a, __m128i b, const int imm8) PBLENDW xmm, xmm/m128, imm8
    /// Combines components from left/right vectors per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vblend(Vector128<ushort> x, Vector128<ushort> y, [Imm] Blend8x16 spec)
        => vblend(x, y, (byte)spec);

    /// <summary>
    /// __m256i _mm256_blend_epi16 (__m256i a, __m256i b, const int imm8) VPBLENDW ymm, ymm, ymm/m256, imm8
    /// Combines components from left/right vectors within 128-bit lanes per the blend spec
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vblend(Vector256<short> x, Vector256<short> y, [Imm] Blend8x16 spec)
        => vblend(x, y, (byte)spec);

    /// <summary>
    /// __m256i _mm256_blend_epi16 (__m256i a, __m256i b, const int imm8) VPBLENDW ymm, ymm, ymm/m256, imm8
    /// Combines components from left/right vectors within 128-bit lanes per the blend spec
    /// </summary>
    /// <param name="a">The left vector</param>
    /// <param name="b">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vblend(Vector256<ushort> a, Vector256<ushort> b, [Imm] Blend8x16 spec)
        => vblend(a, b, (byte)spec);        
        
    /// <summary>
    ///  __m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8)
    ///  VPBLENDD ymm,ymm, ymm/m256, imm8
    /// Forms a vector z[i] := testbit(spec,i) ? x[i] : y[i], i = 0,...7
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vblend(Vector256<int> x, Vector256<int> y, [Imm] byte spec)
        => Blend(x, y, spec);

    /// <summary>
    /// __m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8) VPBLENDD ymm, ymm, ymm/m256, imm8
    /// Forms a vector z[i] := testbit(spec,i) ? x[i] : y[i], i = 0,...7
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vblend(Vector256<uint> x, Vector256<uint> y, [Imm] byte spec)
        => Blend(x, y, spec);

    /// <summary>
    ///  __m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8) VPBLENDD ymm,ymm, ymm/m256, imm8
    /// Forms a vector z[i] := testbit(spec,i) ? x[i] : y[i], i = 0,...7
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vblend(Vector256<int> x, Vector256<int> y, [Imm] Blend8x32 spec)
        => Blend(x, y, (byte)spec);

    /// <summary>
    /// __m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8) VPBLENDD ymm, ymm, ymm/m256, imm8
    /// Forms a vector z[i] := testbit(spec,i) ? x[i] : y[i], i = 0,...7
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vblend(Vector256<uint> x, Vector256<uint> y, [Imm] Blend8x32 spec)
        => Blend(x, y, (byte)spec);


}
