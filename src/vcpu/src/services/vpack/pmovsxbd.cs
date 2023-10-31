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
    /// __m128i _mm_cvtepi8_epi32 (__m128i a)
    /// PMOVSXBD xmm, xmm/m32
    /// </summary>
    /// <param name="src"></param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<int> pmovsxbd(W128 w, Vector128<sbyte> src)
        => ConvertToVector128Int32(src);

}