//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu
{
    /// <summary>
    /// 2x16u -> 2x64u
    /// movzx(src[i]) -> dst[i], i = 0,..,1
    /// __m128i _mm_cvtepu16_epi64 (__m128i a)
    /// PMOVZXWQ xmm, xmm/m32
    /// PMOVZXWQ_XMMdq_XMMd
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> pmovzxwq(Vector128<ushort> src)
        => v64u(ConvertToVector128Int64(src));

    /// <summary>
    /// 2x16u -> 2x64u
    /// movzx(src[i]) -> dst[i], i = 0,..,1
    /// __m128i _mm_cvtepu16_epi64 (__m128i a)
    /// PMOVZXWQ xmm, xmm/m32
    /// PMOVZXWQ_XMMdq_XMMd
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> pmovzxwq(uint src)
        => v64u(ConvertToVector128Int64(vload(w128, sys.u16(sys.bytes(src)))));
}
