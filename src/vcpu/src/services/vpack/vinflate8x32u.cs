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
    /// VPMOVZXDQ ymm, m128
    /// 8x32u -> 8x64u
    /// Projects 8 unsigned 32-bit integers onto 8 unsigned 64-bit integers
    /// </summary>
    /// <param name="src">The blocked memory source</param>
    /// <param name="lo">The lower target</param>
    /// <param name="hi">The upper target</param>
    [MethodImpl(Inline), Op]
    public static unsafe void vinflate8x32u(in uint src, out Vector256<ulong> lo, out Vector256<ulong> hi)
    {
        lo = v64u(ConvertToVector256Int64(gptr(src)));
        hi = v64u(ConvertToVector256Int64(gptr(src,4)));
    }
}
