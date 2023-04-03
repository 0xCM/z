//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vpack;

    partial struct BitPack
    {
        /// <summary>
        /// Distributes each packed source bit to the least significant bit of 64 corresponding target bytes
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static ref byte unpack1x64x8(ulong src, ref byte dst)
        {
            unpack1x32x8((uint)src, ref dst);
            unpack1x32x8((uint)(src >> 32), ref seek(dst, 32));
            return ref dst;
        }

        /// <summary>
        /// Distributes 64 packed source bit to the least significant bit of 64 corresponding target bytes
        /// </summary>
        /// <param name="src">The bit source</param>
        /// <param name="dst">The bit target</param>
        [MethodImpl(Inline), Unpack]
        public static void unpack1x64x8(ulong src, Span<byte> dst)
            => unpack1x64(src, ref first64u(dst));

        /// <summary>
        /// Distributes 64 packed source bits to 64 corresponding target bits
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack1x64(ulong src, Span<bit> dst)
            => unpack1x64x8(src, ref u8(first(dst)));

        /// <summary>
        /// Unpacks 64 source bits over 64 32-bit target segments
        /// </summary>
        /// <param name="src">The source bits</param>
        /// <param name="buffer">The intermediate buffer</param>
        /// <param name="dst">The target buffer</param>
        [MethodImpl(Inline), Op]
        public static void unpack1x64x32(ulong src, Span<uint> dst)
        {
            var buffer = z64;
            ref var tmp = ref uint8(ref buffer);
            ref var lead = ref first(dst);
            var wSrc = w64;
            var wDst = w256;
            unpack1x8((byte)src, ref tmp);
            vinflate8x256x32u(tmp).StoreTo(ref lead);
            unpack1x8((byte)(src >> 8), ref tmp);
            vinflate8x256x32u(tmp).StoreTo(ref lead, 8);
            unpack1x8((byte)(src >> 16), ref tmp);
            vinflate8x256x32u(tmp).StoreTo(ref lead, 16);
            unpack1x8((byte)(src >> 24), ref tmp);
            vinflate8x256x32u(tmp).StoreTo(ref lead, 24);
            unpack1x8((byte)(src >> 32), ref tmp);
            vinflate8x256x32u(tmp).StoreTo(ref lead, 32);
            unpack1x8((byte)(src >> 40), ref tmp);
            vinflate8x256x32u(tmp).StoreTo(ref lead, 40);
            unpack1x8((byte)(src >> 48), ref tmp);
            vinflate8x256x32u(tmp).StoreTo(ref lead, 48);
            unpack1x8((byte)(src >> 56), ref tmp);
            vinflate8x256x32u(tmp).StoreTo(ref lead, 56);
        }

        [MethodImpl(Inline), Op]
        public static void unpack1x64x32_2(ulong src, Span<uint> dst)
        {
            var buffer = ByteBlocks.alloc(n64);
            ref var tmp = ref first(slice(dst,56,8).Recover<uint,byte>());
            ref var target = ref first(dst);

            unpack1x32x8((uint)src, ref tmp);
            vinflate8x256x32u(tmp, 0, ref target, 0);
            vinflate8x256x32u(tmp, 1, ref target, 1);
            vinflate8x256x32u(tmp, 2, ref target, 2);
            vinflate8x256x32u(tmp, 3, ref target, 3);

            unpack1x32x8((uint)(src >> 32), ref tmp);
            vinflate8x256x32u(tmp, 0, ref target, 4);
            vinflate8x256x32u(tmp, 1, ref target, 5);
            vinflate8x256x32u(tmp, 2, ref target, 6);
            vinflate8x256x32u(tmp, 3, ref target, 7);
        }

        [MethodImpl(Inline), Op]
        public static void unpack1x64x32_3(ulong src, Span<uint> dst)
        {
            var buffer = ByteBlocks.alloc(n64);
            ref var tmp = ref ByteBlocks.first<byte>(ref buffer);
            ref var target = ref first(dst);
            unpack1x64x8(src, ref tmp);
            vinflate8x256x32u(tmp, 0, ref target);
            vinflate8x256x32u(tmp, 1, ref target);
            vinflate8x256x32u(tmp, 2, ref target);
            vinflate8x256x32u(tmp, 3, ref target);
            vinflate8x256x32u(tmp, 4, ref target);
            vinflate8x256x32u(tmp, 5, ref target);
            vinflate8x256x32u(tmp, 6, ref target);
            vinflate8x256x32u(tmp, 7, ref target);
        }


        [MethodImpl(Inline), Unpack]
        public static ref ulong unpack1x64(ulong src, ref ulong dst)
        {
            unpack1x8x32((uint)src, ref dst);
            unpack1x32x8((uint)(src >> 32), ref seek8(dst, 32));
            return ref dst;
        }

        /// <summary>
        /// Distributes each packed source bit to the least significant bit of the corresponding target byte
        /// </summary>
        /// <param name="src">The packed source bits</param>
        /// <param name="dst">The blocked target</param>
        /// <param name="block">The block index</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op]
        public static SpanBlock512<byte> unpack1x64(ulong src, in SpanBlock512<byte> dst, int block)
        {
            unpack1x64x8(src, dst.CellBlock(block));
            return dst;
        }
    }
}