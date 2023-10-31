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
    /// __m256i _mm256_cvtepi32_epi64 (__m128i a)
    /// VPMOVSXDQ ymm, xmm/m128
    /// 4x32w -> 4x64w
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vpmovsxdq(W256 w, Vector128<int> src)
        => ConvertToVector256Int64(src);        

    /// <summary>
    /// VPMOVSXDQ ymm, m128
    /// </summary>
    /// <param name="pSrc"></param>
    /// <returns></returns>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<long> vpmovsxdq(W256 w, int* pSrc)
        => ConvertToVector256Int64(pSrc);        
}