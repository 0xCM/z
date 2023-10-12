//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static BitMaskLiterals;

    partial struct BitPack
    {
        /// <summary>
        /// Packs 4 1-bit values taken from the least significant bit of each source byte of an index-identified block
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="mod">The bit selection modulus</param>
        /// <param name="block">The index of the block to pack</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static byte pack4x8x1<T>(in SpanBlock32<T> src, int block)
            where T : unmanaged
                => (byte)bits.gather(uint32(src.BlockLead(block)), Lsb32x8x1);
    }
}