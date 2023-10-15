//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static vcpu;

    [ApiHost]
    public readonly struct BitSpan32Scalars
    {
        [MethodImpl(Inline), Op]
        public static BitSpan32 from(byte src)
        {
            var buffer = ByteBlocks.alloc(n8);
            ref var tmp = ref ByteBlocks.first<byte>(ref buffer);

            Span<byte> storage = new byte[32];
            ref var target = ref sys.first(sys.recover<uint>(storage));

            BitPack.unpack1x8(src, ref tmp);
            vpack.vinflate8x256x32u(tmp, 0, ref target);
            return BitSpans32.load(storage.Recover<Bit32>());
        }

        [MethodImpl(Inline), Op]
        public static BitSpan32 from(ushort src)
        {

            var buffer = ByteBlocks.alloc(n16);
            ref var tmp = ref ByteBlocks.first<byte>(ref buffer);

            Span<byte> storage = new byte[64];
            ref var target = ref sys.first(sys.recover<uint>(storage));

            BitPack.unpack1x16x8(src, ref tmp);
            vpack.vinflate8x256x32u(tmp, 0, ref target);
            vpack.vinflate8x256x32u(tmp, 1, ref target);
            return BitSpans32.load(storage.Recover<Bit32>());
        }

        [MethodImpl(Inline), Op]
        public static BitSpan32 from(uint src)
        {
            var buffer = ByteBlocks.alloc(n32);
            ref var tmp = ref ByteBlocks.first<byte>(ref buffer);

            Span<byte> storage = new byte[128];
            ref var target = ref sys.first(sys.recover<uint>(storage));

            BitPack.unpack1x32x8(src, ref tmp);
            vpack.vinflate8x256x32u(tmp, 0, ref target);
            vpack.vinflate8x256x32u(tmp, 1, ref target);
            vpack.vinflate8x256x32u(tmp, 2, ref target);
            vpack.vinflate8x256x32u(tmp, 3, ref target);
            return BitSpans32.load(storage.Recover<Bit32>());
        }

        [MethodImpl(Inline), Op]
        public static BitSpan32 from(ulong src)
        {
            Span<uint> dst = new uint[64];
            SpanPack.unpack1x64x32_3(src, dst);
            return BitSpans32.load(dst.Recover<Bit32>());
        }

        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 fill(byte src, in BitSpan32 dst)
        {
            var buffer = ByteBlocks.alloc(n8);
            ref var tmp = ref ByteBlocks.first<byte>(ref buffer);
            ref var target = ref Unsafe.As<Bit32,uint>(ref first(dst.Edit));

            BitPack.unpack1x8(src, ref tmp);
            vpack.vinflate8x256x32u(tmp, 0, ref target);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 fill(ushort src, in BitSpan32 dst)
        {
            var buffer = ByteBlocks.alloc(n16);
            ref var tmp = ref ByteBlocks.first<byte>(ref buffer);
            ref var target = ref Unsafe.As<Bit32,uint>(ref first(dst.Edit));

            BitPack.unpack1x16x8(src, ref tmp);
            vpack.vinflate8x256x32u(tmp, 0, ref target);
            vpack.vinflate8x256x32u(tmp, 1, ref target);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 fill(uint src, in BitSpan32 dst)
        {
            ref var tmp = ref first(dst.Edit.Slice(24,8).Recover<Bit32,byte>());
            ref var target = ref Unsafe.As<Bit32,uint>(ref first(dst.Edit));

            BitPack.unpack1x32x8(src, ref tmp);
            vpack.vinflate8x256x32u(tmp, 0, ref target);
            vpack.vinflate8x256x32u(tmp, 1, ref target);
            vpack.vinflate8x256x32u(tmp, 2, ref target);
            vpack.vinflate8x256x32u(tmp, 3, ref target);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref readonly BitSpan32 fill(ulong src, in BitSpan32 dst)
        {
            var buffer = ByteBlocks.alloc(n64);
            ref var tmp = ref first(dst.Edit.Slice(56,8).Recover<Bit32,byte>());
            ref var target = ref Unsafe.As<Bit32,uint>(ref first(dst.Edit));

            BitPack.unpack1x32x8((uint)src, ref tmp);
            vpack.vinflate8x256x32u(tmp, 0, ref target, 0);
            vpack.vinflate8x256x32u(tmp, 1, ref target, 1);
            vpack.vinflate8x256x32u(tmp, 2, ref target, 2);
            vpack.vinflate8x256x32u(tmp, 3, ref target, 3);

            BitPack.unpack1x32x8((uint)(src >> 32), ref tmp);
            vpack.vinflate8x256x32u(tmp, 0, ref target, 4);
            vpack.vinflate8x256x32u(tmp, 1, ref target, 5);
            vpack.vinflate8x256x32u(tmp, 2, ref target, 6);
            vpack.vinflate8x256x32u(tmp, 3, ref target, 7);
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static Span<uint> extract(in BitSpan32 src, int offset, int count)
           => slice(src.Edit,offset, count).Recover<Bit32,uint>();

        [MethodImpl(Inline), Op]
        public static byte extract8(in BitSpan32 src, int offset)
        {
            ref readonly var unpacked = ref first(extract(src, offset, 8));
            return (byte)vpack.vpacklsb(vpack.vpack128x8u(vload(w256, unpacked)));
        }

        [MethodImpl(Inline), Op]
        public static ushort extract16(in BitSpan32 src, int offset)
        {
            ref readonly var unpacked = ref first(extract(src, offset, 16));
            var buffer = z16;
            return BitPack.pack1x16(unpacked, ref buffer);
        }

        [MethodImpl(Inline), Op]
        public static uint extract32(in BitSpan32 src, int offset)
        {
            ref readonly var unpacked = ref first(extract(src, offset, 32));
            var buffer = z32;
            return BitPack.pack1x32(unpacked, ref buffer);
        }

        [MethodImpl(Inline), Op]
        public static ulong extract64(in BitSpan32 src, int offset)
        {
            ref readonly var unpacked = ref first(extract(src, offset, 64));
            var buffer = z64;
            return BitPack.pack64x1(unpacked, ref buffer);
        }
    }
}