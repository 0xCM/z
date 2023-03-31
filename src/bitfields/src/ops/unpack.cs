//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static BitMaskLiterals;
    using static sys;
    using static cpu;
    using static BitMasks;

    partial struct Bitfields
    {
        /// <summary>
        /// Partitions the source into 16 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack16x1(ushort src, Span<byte> dst)
        {
            var mask = BitMasks.lsb<ulong>(n8, n1);
            ref var lead = ref first(dst);
            seek64(lead, 0) = bits.scatter((ulong)(byte)src, mask);
            seek64(lead, 1) = bits.scatter((ulong)((byte)(src >> 8)), mask);
        }

        /// <summary>
        /// Partitions the source into 16 segments, each of effective width 1
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack16x1(ushort src, Span<bit> dst)
            => unpack16x1(src, recover<bit,byte>(dst));


        /// <summary>
        /// Partitions a the source into 2 segments, each of effective width of 4
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static void unpack2x4(byte src, Span<byte> dst)
        {
            seek(dst, 0) = (byte)((src >> 0) & Lsb8x8x4);
            seek(dst, 1) = (byte)((src >> 4) & Lsb8x8x4);
        }

        /// <summary>
        /// [7:0] => [7:6 | 5:4 | 3:2 | 1:0]
        /// Partitions the source into 4 target segments each of effective width of 2
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target memory location</param>
        [MethodImpl(Inline), Op]
        public static void unpack4x2(byte src, Span<byte> dst)
        {
            seek(dst, 0) = (byte)(src >> 0 & Lsb8x8x2);
            seek(dst, 1) = (byte)(src >> 2 & Lsb8x8x2);
            seek(dst, 2) = (byte)(src >> 4 & Lsb8x8x2);
            seek(dst, 3) = (byte)(src >> 6 & Lsb8x8x2);
        }

        /// <summary>
        /// Partitions the source into 8 segments, each of effective width of 2
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target memory location</param>
        [MethodImpl(Inline), Op]
        public static void unpack8x2(ushort src, Span<byte> dst)
        {
            unpack2x4((byte)src, dst);
            unpack4x2((byte)(src >> 8), slice(dst,4));
        }

        /// <summary>
        /// Distributes the source value across 16 segments, each of effective width of 2
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static void unpack16x2(uint src, Span<byte> dst)
        {
            unpack8x2((ushort)src, dst);
            unpack8x2((ushort)(src >> 16), slice(dst,8));
        }

        /// <summary>
        /// Distributes the first 6 source bits acros 2 segments, each of effective width of 3
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target memory location</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack2x3(byte src, ref byte dst)
        {
            seek(dst, 0) = (byte)(src >> 0 & Lsb8x8x3);
            seek(dst, 1) = (byte)(src >> 3 & Lsb8x8x3);
            return ref dst;
        }

        /// <summary>
        /// [8:0] => [8:6 | 5:3 | 2:0]
        /// Partitions the first 9 source bits into 3 segments, each of effective width of 3
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target span</param>
        [MethodImpl(Inline), Op]
        public static void unpack3x3(ushort src, Span<byte> dst)
        {
            unpack2x3((byte)src, ref first(dst));
            seek(dst, 2) = (byte)(src >> 6 & Lsb8x8x3);
        }

        /// <summary>
        /// [11:0] => [11:9 | 8:6 | 5:3 | 2:0]
        /// Distributes the first 12 source bits into 4 segments, each of effective width of 3
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [MethodImpl(Inline), Op]
        public static void unpack4x3(ushort src, Span<byte> dst)
        {
            unpack3x3(src, dst);
            seek(dst, 3) = (byte)(src >> 9 & Lsb8x8x3);
        }

        /// <summary>
        /// Partitions the first 15 source bits into 5 segments, each of effective width 3
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack5x3(ushort src, ref byte dst)
        {
            seek32(dst, 0) = bits.scatter(src, Lsb32x8x3);
            seek(dst, 4) = (byte)bits.scatter((byte)(src >> 12), Lsb8x8x3);
            return ref dst;
        }

        /// <summary>
        /// Partitions the first 24 source bits 9 segments, each of effective width 3
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static void unpack9x3(uint src, Span<byte> dst)
        {
            seek64(dst, 0) = bits.scatter(src, Lsb64x8x3);
        }

        /// <summary>
        /// Partitions the first 63 source bits into 21 segments each of effective width 3
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="dst">The receiving buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack21x3(ulong src, Span<byte> dst)
        {
            var x = BitMasks.lo(n63) & src;
            seek64(dst, 0) = bits.scatter(x, Lsb64x8x3);
            seek64(dst, 1) = bits.scatter(x >> 24, Lsb64x8x3);
            seek64(dst, 2) = bits.scatter(x >> 48, Lsb64x8x3);
        }

        /// <summary>
        /// [11:0] => [11:8 | 7:4 | 3:0]
        /// Partitions the first 12 source bits into 3 segments, each of effective width of 4
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static void unpack3x4(ushort src, Span<byte> dst)
        {
            seek(dst, 0) = (byte)((src >> 0) & Lsb8x8x4);
            seek(dst, 1) = (byte)((src >> 4) & Lsb8x8x4);
            seek(dst, 2) = (byte)((src >> 8) & Lsb8x8x4);
        }

        /// <summary>
        /// Partitions a 16-bit source into 4 segments,each of effective width 4
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static void unpack4x4(ushort src, Span<byte> dst)
            => seek32(dst, 0) = bits.scatter(src, Lsb32x8x4);

        /// <summary>
        /// Partitions a 32-bit source into 8 segments, each of effective width 4
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static void unpack8x4(uint src, Span<byte> dst)
            => seek64(dst,0) = bits.scatter(src, Lsb64x8x4);

        /// <summary>
        /// Partitions the first 20 source bits into 4 segments, each of effective width 5
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">The partition target</param>
        [MethodImpl(Inline), Op]
        public static void unpack4x5(uint src, Span<byte> dst)
            => seek32(dst, 0) = bits.scatter(src, Lsb32x8x5);

        /// <summary>
        /// Partitions a 16-bit source value into 2 segments of effective width 8
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">The partition target</param>
        [MethodImpl(Inline), Op]
        public static void unpack2x8(ushort src, Span<byte> dst)
        {
            seek(dst, 0) = (byte)src;
            seek(dst, 1) = (byte)(src >> 8);
        }

        /// <summary>
        /// Partitions a 32-bit source into 4 8-bit segments, each of effective width 8
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The partition target</param>
        [MethodImpl(Inline), Op]
        public static void unpack4x8(uint src, Span<byte> dst)
            => seek32(dst, 0) = src;

        /// <summary>
        /// [31:0] => [31:16 | 15:0]
        /// Partitions a 32-bit source into 2 segments, each of effective width 16
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static void unpack2x16(uint src, ref ushort dst)
            => seek32(dst,0) = src;

        /// <summary>
        /// Partitions a source into 2 segments, each of effective width 32
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">A target span of sufficient length</param>
        [MethodImpl(Inline), Op]
        public static void unpack2x32(ulong src, Span<uint> dst)
        {
            seek64(dst,0) = src;
        }

        /// <summary>
        /// Partitions the source bits evenly across 8 16-bit segments
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<ushort> unpack8x16(ulong src)
            => vlo(vpack.vinflate256x16u(vbytes(w128, src)));

    }
}