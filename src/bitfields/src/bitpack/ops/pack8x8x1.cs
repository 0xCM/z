//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static Numeric;
using static BitMaskLiterals;

partial class BitPack
{
    /// <summary>
    /// Packs 8 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static byte pack8x8x1<T>(in T src)
        where T : unmanaged
            => (byte)bits.gather(force<T,ulong>(src), Lsb64x8x1);

    /// <summary>
    /// Packs 8 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="count">The number of bits to pack</param>
    /// <param name="mod">The selection modulus</param>
    /// <param name="offset">The source offset</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static byte pack8x8x1<T>(ReadOnlySpan<T> src, uint offset)
        where T : unmanaged
            => (byte)bits.gather(uint64(skip(src, offset)), Lsb64x8x1);
}
