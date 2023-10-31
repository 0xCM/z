//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// __m256i _mm256_cvtepi8_epi16 (__m128i a)
    /// VPMOVSXBW ymm, xmm/m128
    /// </summary>
    /// <param name="src"></param>
    /// <returns></returns>
    public static Vector256<short> vpmovsxbw(W256 w, Vector128<sbyte> src)
        => ConvertToVector256Int16(src);
}
