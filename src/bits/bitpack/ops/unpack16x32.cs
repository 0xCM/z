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
        /// Unpacks 32 8-bit segments onto 32 16-bit targets
        /// </summary>
        /// <param name="src">The data source</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ushort> unpack16x32(in Cell256 src)
        {
            var dst = recover<ushort>(ByteBlocks.alloc(n64).Bytes);
            unpack16x32(src,dst);
            return dst;
        }

        /// <summary>
        /// Unpacks 32 8-bit segments onto 32 16-bit targets
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static void unpack16x32(in Cell256 src, Span<ushort> dst)
        {
            vstore(vpack.vinflatelo256x16u(src), ref seek(dst,0));
            vstore(vpack.vinflatehi256x16u(src), ref seek(dst,16));
        }
    }
}