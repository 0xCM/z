//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m512i _mm512_permutex2var_epi32 (__m512i a, __m512i idx, __m512i b)
    /// VPERMI2D zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// VPERMT2D zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// Shuffle 32-bit integers in "lo" and "hi" across lanes using the corresponding selector and index in "ix"
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vperm16x32x2(Vector512<int> lo, Vector512<int> ix, Vector512<int> hi)
        => PermuteVar16x32x2(lo,ix,hi);

    /// <summary>
    /// __m512i _mm512_permutex2var_epi32 (__m512i a, __m512i idx, __m512i b)
    /// VPERMI2D zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// VPERMT2D zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// Shuffle 32-bit integers in "lo" and "hi" across lanes using the corresponding selector and index in "ix"
    /// </summary>
    /// <param name="lo"></param>
    /// <param name="ix"></param>
    /// <param name="hi"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vperm16x32x2(Vector512<uint> lo, Vector512<uint> ix, Vector512<uint> hi)
        => PermuteVar16x32x2(lo,ix,hi);
}