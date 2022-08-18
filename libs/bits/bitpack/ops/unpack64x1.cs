//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static BitMasks;
    using static cpu;

    partial struct BitPack
    {
        /// <summary>
        /// Partitions a 64-bit source value into 64 individual bit values
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target span</param>
        [MethodImpl(Inline), Op]
        public static void upack64x1(ulong src, Span<bit> dst)
        {
            ref var target = ref first(recover<bit,byte>(dst));
            unpack64x1(src, ref target);
        }

        /// <summary>
        /// Partitions a 64-bit source into 64 8-bit targets, each of effective width 1
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target span</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack64x1(ulong src, ref byte dst)
        {
            ref var target = ref seek64(dst,0);
            seek(target, 0) = lsb8x1(src);
            seek(target, 1) = lsb8x1(src >> 8);
            seek(target, 2) = lsb8x1(src >> 16);
            seek(target, 3) = lsb8x1(src >> 24);
            seek(target, 4) = lsb8x1(src >> 32);
            seek(target, 5) = lsb8x1(src >> 40);
            seek(target, 6) = lsb8x1(src >> 48);
            seek(target, 7) = lsb8x1(src >> 56);
            return ref dst;
        }
    }
}