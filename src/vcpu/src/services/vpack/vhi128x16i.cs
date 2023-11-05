//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// __m128i _mm_cvtepu8_epi16 (__m128i a)
    /// PMOVZXBW xmm, xmm/m64
    /// 8x8u -> 8x16u
    /// movzx(src[i]) -> dst[i], i = 0,.., 7
    /// </summary>
    /// <param name="n">The lane selector</param>
    /// <param name="src">The source</param>
    /// <param name="dst">The target</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ushort> vhi128x16u(Vector128<byte> src)
        => v16u(ConvertToVector128Int16(vshi(src)));
}
