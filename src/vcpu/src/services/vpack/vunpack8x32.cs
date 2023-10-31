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
    /// VPMOVZXBD ymm, m64
    /// 8x8u -> 8x32u
    /// Zero extends 8 8-bit integers to 8 32-bit integers in ymm1
    /// </summary>
    /// <param name="src">The source reference</param>
    [MethodImpl(Inline), Op]
    public static unsafe Vector256<uint> vunpack8x32(in byte src)
        => v32u(ConvertToVector256Int32(gptr(src)));
}
