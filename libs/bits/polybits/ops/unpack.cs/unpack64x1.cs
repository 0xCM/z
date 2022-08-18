//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        /// <summary>
        /// Partitions the source into 64 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack64x1(num64 src, Span<bit> dst)
            => BitPack.upack64x1(src,dst);
    }
}