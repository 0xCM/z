//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static bits;
using static BitMasks;

partial class PolyBits
{
    /// <summary>
    /// Partitions the source into 8 segments, each of effective width 1
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack8x1(num8 src, Span<bit> dst)
        => seek64(dst, 0) = scatter(src, lsb<ulong>(n8,n1));
}
