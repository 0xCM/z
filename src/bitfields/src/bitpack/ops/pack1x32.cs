//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

partial class BitPack
{
    /// <summary>
    /// Packs the least significant bit from 32 32-bit source values to a 32-bit target
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="dst">The target value</param>
    [MethodImpl(Inline), Op]
    public static ref uint pack1x32(in uint src, ref uint dst)
    {
        var v0 = vload(w256, skip(src,0*8));
        var v1 = vload(w256, skip(src,1*8));
        var x = vpack.vpack256x16u(v0, v1);

        v0 = vload(w256, skip(src,2*8));
        v1 = vload(w256, skip(src,3*8));
        var y = vpack.vpack256x16u(v0,v1);

        dst = vpack.vpacklsb(vpack.vpack256x8u(x, y));
        return ref dst;
    }

    /// <summary>
    /// Packs the 32 leading source bits
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="n">The number of bits to pack</param>
    [MethodImpl(Inline), Op]
    public static uint pack1x32(Span<uint> src)
    {
        var buffer = z32;
        return pack1x32(first(src), ref buffer);
    }

    /// <summary>
    /// Packs the least significant bit from 32 32-bit source values to a 32-bit target
    /// </summary>
    /// <param name="src">The intput sequence</param>
    /// <param name="dst">The target</param>
    [MethodImpl(Inline), Op]
    public static ref uint pack1x32(in NatSpan<N32,uint> src, ref uint dst)
    {
        dst = pack1x32(src.First, ref dst);
        return ref dst;
    }
}
