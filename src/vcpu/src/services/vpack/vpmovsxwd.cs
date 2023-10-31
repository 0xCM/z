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
    /// __m256i _mm256_cvtepi16_epi32 (__m128i a)
    /// VPMOVSXWD ymm, xmm/m128
    /// 8x16i -> 8x32i
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="w">The target vector width</param>
    /// <param name="t">A target component type representative</param>
    [MethodImpl(Inline), Op]
    public static Vector256<int> vpmovsxwd(W256 w, Vector128<short> src)
        => ConvertToVector256Int32(src);

    /// <summary>
    /// __m512i _mm512_cvtepi16_epi32 (__m128i a)
    /// VPMOVSXWD zmm1 {k1}{z}, ymm2/m256
    /// </summary>
    /// <param name="w"></param>
    /// <param name="src"></param>
    /// <returns></returns>
    public static Vector512<int> vpmovsxwd(W512 w, Vector256<short> src)
        => ConvertToVector512Int32(src);        

}