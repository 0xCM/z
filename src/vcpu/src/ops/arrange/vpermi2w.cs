//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m128i _mm_permutex2var_epi16 (__m128i a, __m128i idx, __m128i b)
    /// VPERMI2W xmm1 {k1}{z}, xmm2, xmm3/m128 VPERMT2W xmm1 {k1}{z}, xmm2, xmm3/m128
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<short> vpermi2w(Vector128<short> lo, Vector128<short> ix, Vector128<short> hi)
        => PermuteVar8x16x2(lo,ix,hi);

    /// <summary>
    /// __m128i _mm_permutex2var_epi16 (__m128i a, __m128i idx, __m128i b)
    /// VPERMI2W xmm1 {k1}{z}, xmm2, xmm3/m128 VPERMT2W xmm1 {k1}{z}, xmm2, xmm3/m128
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vpermi2w(Vector128<ushort> lo, Vector128<ushort> ix, Vector128<ushort> hi)
        => PermuteVar8x16x2(lo,ix,hi);

    /// <summary>
    /// __m256i _mm256_permutex2var_epi16 (__m256i a, __m256i idx, __m256i b)
    /// VPERMI2W ymm1 {k1}{z}, ymm2, ymm3/m256
    /// VPERMT2W ymm1 {k1}{z}, ymm2, ymm3/m256
    /// Shuffle 16-bit integers in lo and hi across lanes using the corresponding selector and index in ix, and store the results in dst.
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<short> vpermi2w(Vector256<short> lo, Vector256<short> ix, Vector256<short> hi)
        => PermuteVar16x16x2(lo, ix, hi);

    /// <summary>
    /// __m256i _mm256_permutex2var_epi16 (__m256i a, __m256i idx, __m256i b)
    /// VPERMI2W ymm1 {k1}{z}, ymm2, ymm3/m256
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<ushort> vpermi2w(Vector256<ushort> lo, Vector256<ushort> ix, Vector256<ushort> hi)
        => PermuteVar16x16x2(lo, ix, hi);        

    /// <summary>
    ///  __m512i _mm512_permutex2var_epi16 (__m512i a, __m512i idx, __m512i b)
    /// VPERMI2W zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<short> vpermi2w(Vector512<short> lo, Vector512<short> ix, Vector512<short> hi)
        => PermuteVar32x16x2(lo,ix,hi);

    /// <summary>
    ///  __m512i _mm512_permutex2var_epi16 (__m512i a, __m512i idx, __m512i b)
    /// VPERMI2W zmm1 {k1}{z}, zmm2, zmm3/m512
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<ushort> vpermi2w(Vector512<ushort> lo, Vector512<ushort> ix, Vector512<ushort> hi)
        => PermuteVar32x16x2(lo,ix,hi);        
}