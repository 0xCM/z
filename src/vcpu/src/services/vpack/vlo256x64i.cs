//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// __m256i _mm256_cvtepi32_epi64 (__m128i a)
    /// VPMOVSXDQ ymm, xmm/m128
    /// 4x32i -> 4x64i
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector256<long> vlo256x64i(Vector256<int> src)
        => ConvertToVector256Int64(vlo(src));        
}