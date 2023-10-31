//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

partial struct vpack
{
    /// <summary>
    /// __m256i _mm256_cvtepu8_epi32 (__m128i a)
    /// VPMOVSXBD ymm, xmm/m128
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vpmovsxbd(W256 w, Vector128<sbyte> src)
        => ConvertToVector256Int32(src);

    /// <summary>
    /// __m512i _mm512_cvtepi8_epi32 (__m128i a)
    /// VPMOVSXBD zmm1 {k1}{z}, xmm2/m128
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static Vector512<int> vpmovsxbd(W512 w, Vector128<sbyte> src)
        => ConvertToVector512Int32(src);
}