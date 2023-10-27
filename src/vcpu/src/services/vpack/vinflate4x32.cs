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
    /// PMOVZXBD xmm, m32
    /// 4x8u -> 4x32u
    /// Projects 4 unsigned 8-bit values onto 4 unsigned 32-bit values
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="dst">The target component width</param>
    [MethodImpl(Inline), Op(inflate)]
    public static unsafe Vector128<uint> vinflate4x32u(in byte src)
        => v32u(ConvertToVector128Int32(gptr(src)));

    /// <summary>
    /// PMOVZXBD xmm, m32
    /// 4x8u -> 4x32i
    /// Projects four unsigned 8-bit integers onto 4 signed 32-bit integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    /// <param name="i">Signals a sign extension</param>
    [MethodImpl(Inline), Op(inflate)]
    public static unsafe Vector128<int> vinflate4x32i(in byte src)
        => ConvertToVector128Int32(gptr(src));
}
