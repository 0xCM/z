//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// __m128i _mm_cvtepi8_epi16 (__m128i a)
    /// PMOVSXBW xmm, xmm/m64
    /// dst[i] = src[i], i = 1, ..., 7
    /// 8x8i -> 8x16u
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vlo128x16u(Vector128<sbyte> src)
        => v16u(ConvertToVector128Int16(src));

    /// <summary>
    /// __m128i _mm_cvtepu8_epi16 (__m128i a)
    /// PMOVZXBW xmm, xmm/m64
    /// 8x8u -> 8x16u
    /// src[i] -> dst[i], i = 0,.., 7
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vlo128x16u(Vector128<byte> src)
        => v16u(ConvertToVector128Int16(src));
}
