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
    /// PMOVZXBW xmm, m64
    /// 8x8u -> 8x16u
    /// Projects 8 8-bit unsigned integers onto 8 16-bit unsigned integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="dst">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<ushort> pmovzxbw(W128 w, Vector128<byte> src)
        => v16u(ConvertToVector128Int16(src));

    /// <summary>
    /// PMOVZXBW xmm, m64
    /// 8x8u -> 8x16u
    /// Projects 8 8-bit unsigned integers onto 8 unsigned 16-bit integers
    /// </summary>
    /// <returns></returns>
    [MethodImpl(Inline)]
    public static unsafe Vector128<ushort> pmovzxbw(W128 w, byte* pSrc)
        => v16u(ConvertToVector128Int16(pSrc));            
}
