//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;
using static vpack;
using static BitMasks;
using static BitMaskLiterals;
using static bits;

[ApiHost,Free]
public class SpanPack
{
    /// <summary>
    /// Packs the the leading source bits from 8 32-bit integers into a single 8-bit segment
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="dst">The target value</param>
    [MethodImpl(Inline), Op]
    public static byte pack8x1(ReadOnlySpan<uint> src)
        => (byte)vpacklsb(vpack128x8u(vload(w256, first(src))));

    /// <summary>
    /// Packs 8 1-bit values taken from an index-identified bit of the leading byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="index">The cell-relative bit index from [0,7] </param>
    [MethodImpl(Inline), Op]
    public static byte pack8x1(ReadOnlySpan<byte> src)
        => (byte)vmovemask(v8u(vscalar(w128,@as<ulong>(src))),0);

    /// <summary>
    /// Packs 16 1-bit values taken from an index-identified bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="index">The cell-relative bit index from [0,7] </param>
    [MethodImpl(Inline), Op]
    public static ushort pack16x1(Cell128 src, byte index)
        => vmovemask(vload(w128,bytes(src)), index);

    /// <summary>
    /// Packs 32 1-bit values taken from an index-identified bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="index">The cell-relative bit index from [0,7] </param>
    [MethodImpl(Inline), Op]
    public static uint pack32x1(ReadOnlySpan<byte> src)
        => vmovemask(vload(w256,src), 0);

    /// <summary>
    /// Packs 64 1-bit values taken from an index-identified bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="index">The cell-relative bit index from [0,7] </param>
    [MethodImpl(Inline), Op]
    public static ulong pack64x1(ReadOnlySpan<byte> src)
    {
        var a0 = pack32x1(src);
        var b0 = pack32x1(slice(src,16));
        return join(a0,b0);
    }

    /// <summary>
    /// Packs 64 logical 1-bit values, eqch requiring 8 bits of storage into a 64-bit integer
    /// </summary>
    /// <param name="src">The bit source</param>
    [MethodImpl(Inline), Op]
    public static ulong pack64x1(ReadOnlySpan<bit> src)
        => pack64x1(recover<bit,byte>(src));

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
        seek32(dst, 0) = scatter(src, Lsb32x8x3);
        seek(dst, 4) = (byte)scatter((byte)(src >> 12), Lsb8x8x3);
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
        seek64(dst, 0) = scatter(src, Lsb64x8x3);
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
        seek64(dst, 0) = scatter(x, Lsb64x8x3);
        seek64(dst, 1) = scatter(x >> 24, Lsb64x8x3);
        seek64(dst, 2) = scatter(x >> 48, Lsb64x8x3);
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
        => seek32(dst, 0) = scatter(src, Lsb32x8x4);

    /// <summary>
    /// Partitions a 32-bit source into 8 segments, each of effective width 4
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">A target span of sufficient length</param>
    [MethodImpl(Inline), Op]
    public static void unpack8x4(uint src, Span<byte> dst)
        => seek64(dst,0) = scatter(src, Lsb64x8x4);

    /// <summary>
    /// Partitions the first 20 source bits into 4 segments, each of effective width 5
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The partition target</param>
    [MethodImpl(Inline), Op]
    public static void unpack4x5(uint src, Span<byte> dst)
        => seek32(dst, 0) = scatter(src, Lsb32x8x5);

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
        => seek64(dst,0) = src;

    /// <summary>
    /// Partitions the source into 8 segments, each of effective width 1
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack8x1(num8 src, Span<bit> dst)
        => seek64(dst, 0) = scatter(src, lsb<ulong>(n8,n1));    

    [MethodImpl(Inline), Op]
    public static void unpack8x4(uint src, Span<num4> dst)
    {
        var data = bytes(src);
        var i=z8;
        var j=7;
        var a = num4.Zero;
        var b = num4.Zero;
        Numbers.split(skip(data,i++), out a, out b);
        seek(dst,j--) = a;
        seek(dst,j--) = b;

        Numbers.split(skip(data,i++), out a, out b);
        seek(dst,j--) = a;
        seek(dst,j--) = b;

        Numbers.split(skip(data,i++), out a, out b);
        seek(dst,j--) = a;
        seek(dst,j--) = b;

        Numbers.split(skip(data,i++), out a, out b);
        seek(dst,j--) = a;
        seek(dst,j--) = b;
    }

    /// <summary>
    /// Packs the least significant bit from 8 32-bit source values to a an 8-bit target
    /// </summary>
    /// <param name="src">The intput sequence</param>
    /// <param name="dst">The target</param>
    [MethodImpl(Inline), Op]
    public static ref byte pack1x8(in NatSpan<N8,uint> src, ref byte dst)
    {
        dst = BitPack.pack1x8(src.First);
        return ref dst;
    }    

    [MethodImpl(Inline), Op]
    public static void pack(ReadOnlySpan<byte> src, uint offset, ref byte dst)
    {
        const byte M = 8;
        var count = src.Length;
        var kIn = (uint)(count - offset);
        var kOut = kIn/M + (kIn % M == 0 ? 0 : 1);
        for(int i=0, j=0; j<kOut; i+=M, j++)
        {
            ref var b = ref seek(dst, j);
            for(var k=0; k<M; k++)
            {
                var srcIx = i + k + offset;
                if(srcIx < kIn && skip(src, srcIx) != 0)
                    b |= (byte)(1 << k);
            }
        }
    }    
    /// <summary>
    /// Distributes each packed source bit to the least significant bit of the corresponding target byte
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack1x8(byte src, Span<byte> dst)
        => seek64(first(dst), 0) = bits.scatter((ulong)(byte)src, lsb<ulong>(n8, n1));

    /// <summary>
    /// Distributes 8 packed source bits to 8 corresponding target bits
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack1x8(byte src, Span<bit> dst)
        => BitPack.unpack1x8(src, ref u8(first(dst)));

    /// <summary>
    /// Sends each source bit to a corresponding target cell
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The bit target</param>
    [MethodImpl(Inline), Unpack]
    public static ref ulong unpack1x8(byte src, uint offset, Span<byte> dst)
        => ref BitPack.unpack1x8(src, ref seek64(dst, offset));

    /// <summary>
    /// Sends each source bit to a corresponding target cell
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The bit target</param>
    [MethodImpl(Inline), Unpack]
    public static void unpack1x8(ReadOnlySpan<byte> src, Span<byte> dst)
    {
        var count = src.Length;
        var offset = 0u;
        for(var i=0; i<count; i++, offset +=8)
            unpack1x8(skip(src,i), offset, dst);
    }

    /// <summary>
    /// Distributes the first 4 source bits acros 4 segments, each of effective width of 1
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack1x4(byte src, Span<bit> dst)
        => first(recover<bit,uint>(dst)) = bits.scatter((uint)src, BitMasks.lsb<uint>(n8, n1));            

    /// <summary>
    /// Distributes each packed source bit to the least significant bit of the corresponding target byte
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static uint unpack1x16x8(ushort src, Span<byte> dst)
    {
        var mask = lsb<ulong>(n8, n1);
        ref var lead = ref first(dst);
        seek64(lead, 0) = bits.scatter((ulong)(byte)src, mask);
        seek64(lead, 1) = bits.scatter((ulong)((byte)(src >> 8)), mask);
        return 2;
    }

    /// <summary>
    /// Distributes 32 packed source bits to 32 corresponding target bits
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack1x32x8(uint src, Span<bit> dst)
        =>BitPack.unpack1x32x8(src, ref u8(first(dst)));

    /// <summary>
    /// Partitions a 64-bit source value into 64 individual bit values
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="dst">The target span</param>
    [MethodImpl(Inline), Op]
    public static void upack1x64(ulong src, Span<bit> dst)
    {
        ref var target = ref first(recover<bit,byte>(dst));
        BitPack.unpack1x64(src, ref target);
    }

    /// <summary>
    /// Unpacks 32 source bits over 32 32-bit target segments
    /// </summary>
    /// <param name="src">The source bits</param>
    /// <param name="buffer">The intermediate buffer</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack1x32x32(uint src, Span<uint> dst)
    {
        var buffer = z64;
        var w = w256;
        var n = n64;
        ref var tmp = ref uint8(ref buffer);
        ref var lead = ref first(dst);
        BitPack.unpack1x8((byte)src, ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead);
        BitPack.unpack1x8((byte)(src >> 8), ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead, 8);
        BitPack.unpack1x8((byte)(src >> 16), ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead, 16);
        BitPack.unpack1x8((byte)(src >> 24), ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead, 24);
    }

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

        BitPack.unpack1x8((byte)src, ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead);
        BitPack.unpack1x8((byte)(src >> 8), ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead, 8);
    }

    /// <summary>
    /// Distributes 16 packed source bits to 16 corresponding target bits
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack1x16x8(ushort src, Span<bit> dst)
        => BitPack.unpack1x16x8(src, ref u8(first(dst)));

    /// <summary>
    /// Sends each source bit to a corresponding target cell
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The bit target</param>
    [MethodImpl(Inline), Unpack]
    public static uint unpack1x8x16(ushort src, Span<byte> dst)
        => BitPack.unpack1x8x16(src, ref first64u(dst));

    /// <summary>
    /// Distributes 64 packed source bit to the least significant bit of 64 corresponding target bytes
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The bit target</param>
    [MethodImpl(Inline), Unpack]
    public static void unpack1x64x8(ulong src, Span<byte> dst)
        => BitPack.unpack1x64(src, ref first64u(dst));

    /// <summary>
    /// Distributes 64 packed source bits to 64 corresponding target bits
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack1x64(ulong src, Span<bit> dst)
        => BitPack.unpack1x64x8(src, ref u8(seek(dst,0)));

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
        BitPack.unpack1x8((byte)src, ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead);
        BitPack.unpack1x8((byte)(src >> 8), ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead, 8);
        BitPack.unpack1x8((byte)(src >> 16), ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead, 16);
        BitPack.unpack1x8((byte)(src >> 24), ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead, 24);
        BitPack.unpack1x8((byte)(src >> 32), ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead, 32);
        BitPack.unpack1x8((byte)(src >> 40), ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead, 40);
        BitPack.unpack1x8((byte)(src >> 48), ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead, 48);
        BitPack.unpack1x8((byte)(src >> 56), ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref lead, 56);
    }

    [MethodImpl(Inline), Op]
    public static void unpack1x64x32_2(ulong src, Span<uint> dst)
    {
        var buffer = ByteBlocks.alloc(n64);
        ref var tmp = ref first(slice(dst,56,8).Recover<uint,byte>());
        ref var target = ref first(dst);

        BitPack.unpack1x32x8((uint)src, ref tmp);
        vinflate8x256x32u(tmp, 0, ref target, 0);
        vinflate8x256x32u(tmp, 1, ref target, 1);
        vinflate8x256x32u(tmp, 2, ref target, 2);
        vinflate8x256x32u(tmp, 3, ref target, 3);

        BitPack.unpack1x32x8((uint)(src >> 32), ref tmp);
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
        BitPack.unpack1x64x8(src, ref tmp);
        vinflate8x256x32u(tmp, 0, ref target);
        vinflate8x256x32u(tmp, 1, ref target);
        vinflate8x256x32u(tmp, 2, ref target);
        vinflate8x256x32u(tmp, 3, ref target);
        vinflate8x256x32u(tmp, 4, ref target);
        vinflate8x256x32u(tmp, 5, ref target);
        vinflate8x256x32u(tmp, 6, ref target);
        vinflate8x256x32u(tmp, 7, ref target);
    }

    /// <summary>
    /// Projects 16 8-bit segments onto 16 16-bit targets
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="src">The target</param>
    [MethodImpl(Inline), Op]
    public static void unpack16x16(Cell128 src, Span<ushort> dst)
        => vgcpu.vstore(vcpu.vpmovzxbw(src), dst);

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
}
