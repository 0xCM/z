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
    /// PMOVZXBQ xmm, m16
    /// 2x8u -> 2x64i
    /// Projects two unsigned 8-bit integers onto 2 signed 64-bit integers
    /// </summary>
    /// <param name="pSrc">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    /// <param name="i">Signals a sign extension</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<ulong> pmovzxbq(W128 w,  byte* pSrc)
        => v64u(ConvertToVector128Int64(pSrc));
}