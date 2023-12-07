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
    /// __m256i _mm256_blend_epi16 (__m256i a, __m256i b, const int imm8)
    /// VPBLENDW ymm, ymm, ymm/m256, imm8
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

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<byte> vblend(Vector128<byte> x, Vector128<byte> y, Vector128<byte> spec)
        =>  BlendVariable(x, y, spec);

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vblend(Vector128<sbyte> x, Vector128<sbyte> y, Vector128<sbyte> spec)
        => BlendVariable(x, y, spec);

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<sbyte> vblend(Vector128<sbyte> x, Vector128<sbyte> y, Vector128<byte> spec)
        => BlendVariable(x, y, v8i(spec));

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask)PBLENDVB xmm, xmm/m128,xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vblend(Vector128<short> x, Vector128<short> y, Vector128<short> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vblend(Vector128<short> x, Vector128<short> y, Vector128<byte> spec)
        => BlendVariable(x, y, v16i(spec));

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vblend(Vector128<ushort> x, Vector128<ushort> y, Vector128<byte> spec)
        => BlendVariable(x, y, v16u(spec));

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vblend(Vector128<int> x, Vector128<int> y, Vector128<byte> spec)
        => BlendVariable(x, y, v32i(spec));

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vblend(Vector128<uint> x, Vector128<uint> y, Vector128<byte> spec)
        => BlendVariable(x, y, v32u(spec));

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128,xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vblend(Vector128<ushort> x, Vector128<ushort> y, Vector128<ushort> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128,xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<int> vblend(Vector128<int> x, Vector128<int> y, Vector128<int> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128,xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vblend(Vector128<uint> x, Vector128<uint> y, Vector128<uint> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128,xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vblend(Vector128<long> x, Vector128<long> y, Vector128<long> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128,xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vblend(Vector128<ulong> x, Vector128<ulong> y, Vector128<ulong> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<byte> vblend(Vector256<byte> x, Vector256<byte> y, Vector256<byte> spec)
        =>  BlendVariable(x, y, spec);

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask)PBLENDVB xmm, xmm/m128, xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vblend(Vector256<sbyte> x, Vector256<sbyte> y, Vector256<sbyte> spec)
        => BlendVariable(x, y, spec);

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm, ymm, ymm/m256, ymm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vblend(Vector256<short> x, Vector256<short> y, Vector256<short> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)VPBLENDVB ymm, ymm, ymm/m256, ymm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vblend(Vector256<ushort> x, Vector256<ushort> y, Vector256<ushort> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)VPBLENDVB ymm, ymm, ymm/m256, ymm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vblend(Vector256<int> x, Vector256<int> y, Vector256<int> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)VPBLENDVB ymm, ymm, ymm/m256, ymm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vblend(Vector256<uint> x, Vector256<uint> y, Vector256<uint> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)VPBLENDVB ymm, ymm, ymm/m256, ymm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vblend(Vector256<long> x, Vector256<long> y, Vector256<long> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm, ymm, ymm/m256, ymm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vblend(Vector256<ulong> x, Vector256<ulong> y, Vector256<ulong> spec)
        => BlendVariable(x,y,spec);

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<long> vblend(Vector128<long> x, Vector128<long> y, Vector128<byte> spec)
        => BlendVariable(x, y, v64i(spec));

    /// <summary>
    /// __m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask) PBLENDVB xmm, xmm/m128, xmm
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> vblend(Vector128<ulong> x, Vector128<ulong> y, Vector128<byte> spec)
        => BlendVariable(x, y, v64u(spec));

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
    /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
    [MethodImpl(Inline), Op]
    public static Vector256<sbyte> vblend(Vector256<sbyte> x, Vector256<sbyte> y, Vector256<byte> spec)
        => BlendVariable(x, y, v8i(spec));

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
    /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vblend(Vector256<short> x, Vector256<short> y, Vector256<byte> spec)
        => BlendVariable(x, y, v16i(spec));

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
    /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vblend(Vector256<ushort> x, Vector256<ushort> y, Vector256<byte> spec)
        => BlendVariable(x, y, v16u(spec));

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
    /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vblend(Vector256<int> x, Vector256<int> y, Vector256<byte> spec)
        => BlendVariable(x, y, v32i(spec));

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
    /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
    [MethodImpl(Inline), Op]
    public static Vector256<uint> vblend(Vector256<uint> x, Vector256<uint> y, Vector256<byte> spec)
        => BlendVariable(x, y, v32u(spec));

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
    /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vblend(Vector256<long> x, Vector256<long> y, Vector256<byte> spec)
        => BlendVariable(x, y, v64i(spec));

    /// <summary>
    /// __m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask) VPBLENDVB ymm,ymm, ymm/m256, ymm
    /// Forms a vector z[i] = testbit(spec[i],7) ? x[i] : y[i] where i = 0,...31
    /// </summary>
    /// <param name="x">The left vector</param>
    /// <param name="y">The right vector</param>
    /// <param name="spec">The blend specification</param>
    /// <remarks>https://www.felixcloutier.com/x86/pblendvb</remarks>
    [MethodImpl(Inline), Op]
    public static Vector256<ulong> vblend(Vector256<ulong> x, Vector256<ulong> y, Vector256<byte> spec)
        => BlendVariable(x, y, v64u(spec));

    /// <summary>
    /// __m512i _mm512_blendv_epu8 (__m512i a, __m512i b, __m512i mask)
    /// VPBLENDMB zmm1 {k1}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<byte> vblend(Vector512<byte> x, Vector512<byte> y, Vector512<byte> spec)
        => BlendVariable(x, y, spec);

    /// <summary>
    /// __m512i _mm512_blendv_epi8 (__m512i a, __m512i b, __m512i mask)
    /// VPBLENDMB zmm1 {k1}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<sbyte> vblend(Vector512<sbyte> x, Vector512<sbyte> y, Vector512<sbyte> spec)
        => BlendVariable(x, y, spec);

    /// <summary>
    /// __m512i _mm512_blendv_epi16 (__m512i a, __m512i b, __m512i mask)
    /// VPBLENDMW zmm1 {k1}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vblend(Vector512<short> x, Vector512<short> y, Vector512<short> spec)
        => BlendVariable(x, y, spec);

    /// <summary>
    /// __m512i _mm512_blendv_epu16 (__m512i a, __m512i b, __m512i mask)
    /// VPBLENDMW zmm1 {k1}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vblend(Vector512<ushort> x, Vector512<ushort> y, Vector512<ushort> spec)
        => BlendVariable(x, y, spec);

    /// <summary>
    /// __m512i _mm512_blendv_epu32 (__m512i a, __m512i b, __m512i mask)
    /// VPBLENDMD zmm1 {k1}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vblend(Vector512<uint> x, Vector512<uint> y, Vector512<uint> spec)
        => BlendVariable(x, y, spec);

    /// <summary>
    /// __m512i _mm512_blendv_epi32 (__m512i a, __m512i b, __m512i mask)
    /// VPBLENDMD zmm1 {k1}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vblend(Vector512<int> x, Vector512<int> y, Vector512<int> spec)
        => BlendVariable(x, y, spec);

    /// <summary>
    /// __m512i _mm512_blendv_epi64 (__m512i a, __m512i b, __m512i mask)
    /// VPBLENDMQ zmm1 {k1}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<long> vblend(Vector512<long> x, Vector512<long> y, Vector512<long> spec)
        => BlendVariable(x, y, spec);

    /// <summary>
    /// __m512i _mm512_blendv_epu64 (__m512i a, __m512i b, __m512i mask)
    /// VPBLENDMQ zmm1 {k1}, zmm2, zmm3/m512/m64bcst
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ulong> vblend(Vector512<ulong> x, Vector512<ulong> y, Vector512<ulong> spec)
        => BlendVariable(x, y, spec);        
}
