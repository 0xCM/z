//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class BitSpans32
    {
        /// <summary>
        /// Unpacks each primal source bit to a 32-bit blocked target
        /// </summary>
        /// <param name="src">The packed bit source</param>
        /// <param name="dst">The unpacked bit target</param>
        /// <param name="block">The target block index</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        static void unpack1x32<T>(ReadOnlySpan<T> src, SpanBlock256<uint> dst, int block)
            where T : unmanaged
        {
            const int blocklen = 8;
            const int blockcount = 1;
            gpack.unpack1x32(skip(src, block), dst.CellBlock(block));
        }

        /// <summary>
        /// Wraps a bitspan over a span of extant bits
        /// </summary>
        /// <param name="src">The source bits</param>
        [MethodImpl(Inline), Op]
        public static BitSpan32 load(Span<Bit32> src)
            => new BitSpan32(src);

        /// <summary>
        /// Loads a bitspan from an array
        /// </summary>
        /// <param name="src">The source array</param>
        [MethodImpl(Inline), Op]
        public static BitSpan32 load(Bit32[] src)
            => new BitSpan32(src);

        /// <summary>
        /// Loads a bitspan from a reference
        /// </summary>
        /// <param name="bits">The bit source</param>
        /// <param name="count">The number of bits to load</param>
        [MethodImpl(Inline), Op]
        public static BitSpan32 load(ref Bit32 bits, int count)
            => new BitSpan32(cover(bits,count));

        /// <summary>
        /// Creates a bitspan from an arbitrary number of packed bytes
        /// </summary>
        /// <param name="packed">The packed data source</param>
        [Op]
        internal static BitSpan32 load(ReadOnlySpan<byte> packed)
        {
            var srcbits = 8*packed.Length;
            var dstbits = 32*srcbits;
            var blocks = dstbits/256 + (dstbits % 256 == 0 ? 0 : 1);
            var dst = SpanBlocks.alloc<uint>(n256,blocks);

            for(var block=0; block<blocks; block++)
                unpack1x32(packed, dst, block);

            return load(dst.As<Bit32>());
        }

        /// <summary>
        /// Creates a bitspan from an arbitrary number of packed bytes
        /// </summary>
        /// <param name="packed">The packed data source</param>
        internal static BitSpan32 load(Span<byte> packed)
            => load(packed.ReadOnly());
    }
}