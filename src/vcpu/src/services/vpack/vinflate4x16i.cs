//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static System.Runtime.Intrinsics.X86.Sse41;
using static System.Runtime.Intrinsics.X86.Avx;
using static sys;

partial struct vpack
{
    /// <summary>
    /// PMOVSXWD xmm, m64
    /// 4x16i -> 4x32i
    /// Projects 4 16-bit signed integers onto 4 32-bit signed integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<int> vinflate4x16i(in short src)
        => ConvertToVector128Int32(gptr(src));
}
