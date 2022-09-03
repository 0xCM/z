//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static cpu;

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
                => vmovemask(gcpu.vsll(vload(w256, view64u(src)),7));

        /// <summary>
        /// Packs 32 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static uint pack32x8x1<T>(in SpanBlock256<T> src, uint block = 0)
            where T : unmanaged
                => pack32x8x1(src.BlockLead((int)block));

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
}