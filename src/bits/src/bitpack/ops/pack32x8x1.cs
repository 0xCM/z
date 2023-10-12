//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

partial struct BitPack
{
    /// <summary>
    /// Packs 32 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="n">The number of bits to pack</param>
    /// <param name="mod">The bit selection modulus</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint pack32x8x1<T>(in T src)
        where T : unmanaged
            => vmovemask(vgcpu.vsll(vload(w256, u64(src)),7));

    /// <summary>
    /// Packs 32 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="count">The number of bits to pack</param>
    /// <param name="mod">The selection modulus</param>
    /// <param name="offset">The source offset</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint pack32x8x1<T>(ReadOnlySpan<T> src, uint offset = 0)
        where T : unmanaged
            => pack32x8x1(skip(src, offset));
}
