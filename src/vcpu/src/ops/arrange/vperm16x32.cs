//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// __m512i _mm512_permutevar16x32_epi32 (__m512i a, __m512i b)
    /// VPERMD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="src"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vperm16x32(Vector512<int> src, Vector512<int> spec)
        => PermuteVar16x32(src, spec);

    /// <summary>
    /// __m512i _mm512_permutevar16x32_epi32 (__m512i a, __m512i b)
    /// VPERMD zmm1 {k1}{z}, zmm2, zmm3/m512/m32bcst
    /// </summary>
    /// <param name="src"></param>
    /// <param name="spec"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<uint> vperm16x32(Vector512<uint> src, Vector512<uint> spec)
        => PermuteVar16x32(src, spec);
}