//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct vpack
{
    /// <summary>
    /// PMOVSXDQ xmm, m64
    /// 2x32i -> 2x64i
    /// Projects 2 signed 32-bit integers onto 2 signed 64-bit integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<long> pmovsxdq(W128 w, int* pSrc)
        => ConvertToVector128Int64(pSrc);

}