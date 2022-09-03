//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMaskLiterals;
    using static core;

    partial struct BitPack
    {
        /// <summary>
        /// Partitions the first 63 source bits into 21 target segments each of effective width 3
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="dst">The receiving buffer</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack3x21(ulong src, ref byte dst)
        {
            Bitfields.unpack21x3(src, cover(dst, 8));
            return ref dst;
        }

        /// <summary>
        /// Partitions a 16-bit source into 4 segments, each of effective width 4
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack4x4(ushort src, ref byte dst)
        {
            seek32(dst, 0) = bits.scatter(src, Lsb32x8x4);
            return ref dst;
        }

        /// <summary>
        /// Partitions the first 24 bits of a 32-bit source value into 9 3-bit target segments
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack3x8(uint src, ref byte dst)
        {
            seek64(dst, 0) = bits.scatter(src, Lsb64x8x3);
            return ref dst;
        }
    }
}