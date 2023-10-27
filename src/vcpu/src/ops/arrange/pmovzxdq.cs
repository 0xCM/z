//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static System.Runtime.Intrinsics.X86.Sse41;

partial class vcpu
{
    /// <summary>
    /// 2x32u -> 2x64u
    /// movzx(src[i]) -> dst[i], i = 0,..,1
    /// __m128i _mm_cvtepu32_epi64(__m128i a)
    /// PMOVZXDQ xmm, xmm/m64
    /// PMOVZXDQ_XMMdq_XMMq
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> pmovzxdq(Vector128<uint> src)
        => v64u(ConvertToVector128Int64(src));

    /// <summary>
    /// 2x32u -> 2x64u
    /// movzx(src[i]) -> dst[i], i = 0,..,1
    /// __m128i _mm_cvtepu32_epi64(__m128i a)
    /// PMOVZXDQ xmm, xmm/m64
    /// PMOVZXDQ_XMMdq_XMMq
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="dst">The target vector</param>
    [MethodImpl(Inline), Op]
    public static Vector128<ulong> pmovzxdq(ulong src)
        => v64u(ConvertToVector128Int64(vload(w128, sys.bytes(src))));

}
