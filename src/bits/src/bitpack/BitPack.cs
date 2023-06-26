//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    [ApiHost]
    public readonly partial struct BitPack
    {
        /// <summary>
        /// Unpacks 8 source bits over 8 32-bit target segments
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="buffer">The intermediate buffer</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack8x32(byte src, Span<uint> dst)
        {
            var buffer = z64;
            ref var tmp = ref uint8(ref buffer);
            ref var lead = ref first(dst);
            BitPack.unpack1x8(src, ref tmp);
            vpack.vinflate8x256x32u(tmp).StoreTo(ref lead);
        }

        /// <summary>
        /// Partitions the source into 8 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack8x1(byte src, Span<bit> dst)
            => BitPack.unpack1x8(src, ref u8(first(dst)));

        /// <summary>
        /// Distributes the first 4 source bits acros 4 segments, each of effective width of 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack4x1(byte src, Span<bit> dst)
            => first(recover<bit,uint>(dst)) = bits.scatter((uint)src, BitMasks.lsb<uint>(n8, n1));

        /// <summary>
        /// Partitions the source into 8 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack8x1(byte src, Span<byte> dst)
            => BitPack.unpack1x8(src, ref first(dst));

        /// <summary>
        /// Partitions the source into 64 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack64x1(num64 src, Span<bit> dst)
            => BitPack.upack64x1(src,dst);

        const NumericKind Closure = UnsignedInts;
    }
}