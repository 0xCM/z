//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_permutevar8x16_epi16 (__m128i a, __m128i b)
    /// VPERMW xmm1 {k1}{z}, xmm2, xmm3/m128
    /// </summary>
    /// <param name="src"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vpermw(Vector128<short> src, Vector128<short> spec)
        => PermuteVar8x16(src, spec);

    /// <summary>
    /// __m128i _mm_permutevar8x16_epi16 (__m128i a, __m128i b)
    /// VPERMW xmm1 {k1}{z}, xmm2, xmm3/m128
    /// </summary>
    /// <param name="src"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vpermw(Vector128<ushort> src, Vector128<ushort> spec)
        => PermuteVar8x16(src, spec);

    /// <summary>
    /// __m256i _mm256_permutevar16x16_epi16 (__m256i a, __m256i b)
    /// VPERMW ymm1 {k1}{z}, ymm2, ymm3/m256
    /// </summary>
    /// <param name="src"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vpermw(Vector256<short> src, Vector256<short> spec)
        => PermuteVar16x16(src, spec);

    /// <summary>
    /// __m256i _mm256_permutevar16x16_epi16 (__m256i a, __m256i b)
    /// VPERMW ymm1 {k1}{z}, ymm2, ymm3/m256
    /// </summary>
    /// <param name="src"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vpermw(Vector256<ushort> src, Vector256<ushort> spec)
        => PermuteVar16x16(src, spec);

    /// <summary>
    /// __m512i _mm512_permutexvar_epi16 (__m512i idx, __m512i a)
    /// vpermw zmm, zmm, zmm
    /// </summary>
    /// <param name="a"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vpermw(Vector512<short> a, Vector512<short> spec)
        => PermuteVar32x16(a, spec);

    /// <summary>
    /// __m512i _mm512_permutexvar_epi16 (__m512i idx, __m512i a)
    /// vpermw zmm, zmm, zmm
    /// </summary>
    /// <param name="a"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vpermw(Vector512<ushort> a, Vector512<ushort> spec)
        => PermuteVar32x16(a, spec);        
}