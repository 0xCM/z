//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial struct vpack
{
    const string inflate = "inflate";

    /// <summary>
    /// PMOVSXWD xmm, m64
    /// 4x16u -> 4x32u
    /// Projects 4 16-bit unsigned integers onto 4 32-bit unsigned integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="w">The target component width</param>
    [MethodImpl(Inline), Op(inflate)]
    public static unsafe Vector128<uint> vinflate4x16u(in ushort src, out Vector128<uint> dst)
        => dst = vunpack4x32(src);
}
