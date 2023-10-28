//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static System.Runtime.Intrinsics.X86.Sse41;
using static sys;
using static vcpu;

partial struct vpack
{
    /// <summary>
    /// VPMOVZXBD ymm, m64
    /// 8x8u -> 8x32u
    /// Zero extends 8 8-bit integers to 8 32-bit integers in ymm1
    /// </summary>
    /// <param name="src">The source reference</param>
    [MethodImpl(Inline), Op]
    public static unsafe void vinflate8x8u(in byte src, out Vector256<uint> dst)
        => dst = vunpack8x32(src);

    /// <summary>
    /// PMOVZXBW xmm, m64
    /// 8x8u -> 8x16u
    /// Projects 8 8-bit unsigned integers onto 8 16-bit unsigned integers
    /// </summary>
    /// <param name="src">The input component source</param>
    /// <param name="n">The source component count</param>
    /// <param name="dst">The target component width</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector128<ushort> vinflate8x8u(in byte src, out Vector128<ushort> dst)
        => dst = v16u(ConvertToVector128Int16(gptr(src)));
}
