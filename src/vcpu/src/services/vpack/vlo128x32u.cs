//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static vcpu;

partial struct vpack
{
    /// <summary>
    /// __m128i _mm_cvtepu16_epi32 (__m128i a)
    /// PMOVZXWD xmm, xmm/m64
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<uint> vlo128x32u(Vector128<ushort> src)
        => v32u(ConvertToVector128Int32(src));
}
