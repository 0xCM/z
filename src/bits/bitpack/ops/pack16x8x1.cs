//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static cpu;

    partial struct BitPack
    {
        /// <summary>
        /// Packs 16 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="n">The number of bits to pack</param>
        /// <param name="mod">The bit selection modulus</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ushort pack16x8x1<T>(in T src)
            where T : unmanaged
                => vmovemask(gcpu.v8u(gcpu.vsll(vload(w128, u64(src)),7)));

        /// <summary>
        /// Pack 16 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The pack source</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ushort pack16x8x1<T>(SpanBlock128<T> src, uint block = 0)
            where T : unmanaged
                => pack16x8x1(src.BlockLead((int)block));

        /// <summary>
        /// Pack 16 1-bit values taken from the least significant bit of each source byte
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="count">The number of bits to pack</param>
        /// <param name="mod">The selection modulus</param>
        /// <param name="offset">The source offset</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ushort pack16x8x1<T>(ReadOnlySpan<T> src, uint offset = 0)
            where T : unmanaged
                => pack16x8x1(skip(src,(uint)offset));
    }
}