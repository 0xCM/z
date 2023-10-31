//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct vpack
{
    /// <summary>
    /// PMOVZXDQ xmm, m64
    /// 2x32i -> 2x64i
    /// Projects 2 unsigned 32-bit integers onto 2 usigned 64-bit integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<ulong> pmovzxdq(W128 w, uint* pSrc)
        => vcpu.v64u(ConvertToVector128Int64(pSrc));
}
