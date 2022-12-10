//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static BitMasks;
    using static BitMaskLiterals;

    partial struct BitPack
    {
        /// <summary>
        /// Unpacks 16 source bits over 16 32-bit target segments
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="buffer">The intermediate buffer</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack1x16x32(ushort src, Span<uint> dst)
        {
            var buffer = z64;
            ref var tmp = ref uint8(ref buffer);
            ref var lead = ref first(dst);

            unpack1x8((byte)src, ref tmp);
            vpack.vinflate8x256x32u(tmp).StoreTo(ref lead);
            unpack1x8((byte)(src >> 8), ref tmp);
            vpack.vinflate8x256x32u(tmp).StoreTo(ref lead, 8);
        }

        /// <summary>
        /// Distributes 16 packed source bits to 16 corresponding target bits
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack1x16x8(ushort src, Span<bit> dst)
            => unpack1x16x8(src, ref u8(first(dst)));

        /// <summary>
        /// Distributes each packed source bit to the least significant bit of 16 corresponding target bytes
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack1x16x8(ushort src, ref byte dst)
        {
            var m = lsb<ulong>(n8, n1);
            seek64(dst, 0) = bits.scatter((ulong)(byte)src, m);
            seek64(dst, 1) = bits.scatter((ulong)((byte)(src >> 8)), m);
            return ref dst;
        }

        /// <summary>
        /// Distributes each packed source bit to the least significant bit of the corresponding target byte
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack1x16x8(ushort src, Span<byte> dst)
        {
            var mask = lsb<ulong>(n8, n1);
            ref var lead = ref first(dst);
            seek64(lead, 0) = bits.scatter((ulong)(byte)src, mask);
            seek64(lead, 1) = bits.scatter((ulong)((byte)(src >> 8)), mask);
        }

        /// <summary>
        /// Sends each source bit to a corresponding target cell
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">The bit target</param>
        [MethodImpl(Inline), Unpack]
        public static void unpack1x8x16(ushort src, Span<byte> dst)
            => unpack1x8x16(src, ref first64u(dst));

        /// <summary>
        /// Sends each source bit to a corresponding target cell
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">The bit target</param>
        [MethodImpl(Inline), Unpack]
        public static void unpack1x16x8(ushort src, in SpanBlock128<byte> dst)
            => unpack1x8x16(src, dst.Storage);

        /// <summary>
        /// Distributes each packed source bit to the least significant bit of the corresponding target byte
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The blocked target</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op]
        public static SpanBlock128<byte> unpack1x16x8(ushort src, in SpanBlock128<byte> dst, int block)
        {
            unpack1x16x8(src, dst.CellBlock(block));
            return dst;
        }

        [MethodImpl(Inline), Unpack]
        public static ref ulong unpack1x8x16(ushort src, ref ulong dst)
        {
            const ulong M = (ulong)Lsb64x8x1;
            seek(dst, 0) = bits.scatter(src, M);
            seek(dst, 1) = bits.scatter((ushort)(src >> 8), M);
            return ref dst;
        }
    }
}