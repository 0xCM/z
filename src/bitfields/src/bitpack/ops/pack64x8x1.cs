//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class BitPack
{
    /// <summary>
    /// Packs 64 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ulong pack64x8x1<T>(in T src)
        where T : unmanaged
    {
        var dst = 0ul;
        dst = (ulong)pack32x8x1(src);
        dst |=((ulong)pack32x8x1(skip(src, 32))) << 32;
        return dst;
    }

    /// <summary>
    /// Packs 64 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="offset">The source offset</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ulong pack64x8x1<T>(ReadOnlySpan<T> src, uint offset)
        where T : unmanaged
            => pack64x8x1(skip(src, offset));
}
