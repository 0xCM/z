//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Runtime.Intrinsics.X86;

using static vcpu;
using static vpack;
using static sys;
using static bits;
using static BitMaskLiterals;
using static BitMasks;

[ApiHost,Free]
public class BitPack
{
    const NumericKind Closure = UnsignedInts;

    [MethodImpl(Inline)]
    public static ulong extract(ulong src, byte offset, byte width)
        => Bmi1.X64.BitFieldExtract(src, offset, width);

    /// <summary>
    /// Distributes the first 4 source bits across 4 segments, each of effective width of 1
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack4x1(num4 src, Span<bit> dst)
        => first(recover<bit,uint>(dst)) = scatter((uint)src, lsb<uint>(n8, n1));

    /// <summary>
    /// Partitions the source into 16 segments, each of effective width 1
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack16x1(num16 src, Span<bit> dst)
    {
        var mask = BitMasks.lsb<ulong>(n8, n1);
        ref var lead = ref first(dst);
        seek64(lead, 0) = scatter((ulong)(byte)src, mask);
        seek64(lead, 1) = scatter((ulong)((byte)(src >> 8)), mask);
    }

    public static byte scalar(string src, out byte dst)
    {
        var storage = ByteBlock8.Empty;
        var buffer = recover<bit>(storage.Bytes);
        dst = 0;
        var count = BitParser.parse(src, buffer);
        if(count >= 0)
            dst = gpack.scalar<byte>(buffer);
        return (byte)count;
    }

    public static byte scalar(string src, out ushort dst)
    {
        var storage = ByteBlock16.Empty;
        var buffer = recover<bit>(storage.Bytes);
        dst = 0;
        var count = BitParser.parse(src, buffer);
        if(count >= 0)
            dst = gpack.scalar<ushort>(buffer);
        return (byte)count;
    }

    /// <summary>
    /// Unpacks a specified number source bytes to a corresponding count of 32-bit target values
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="count">The number of bytes to pack</param>
    /// <param name="dst">The target reference, of size at least 256*count bits</param>
    [MethodImpl(Inline), Op]
    public static void unpack(in byte src, int count, ref uint dst)
    {
        var buffer = z64;
        ref var tmp = ref uint8(ref buffer);
        for(var i=0; i<count; i++)
        {
            unpack1x8(skip(src, i), ref tmp);
            vpack.vinflate8x256x32u(tmp).StoreTo(ref seek(dst, i*8));
        }
    }
    /// <summary>
    /// Sends each source bit to to least bit of each 8-bit segment in the target
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The bit target</param>
    [MethodImpl(Inline), Unpack]
    public static ref ulong unpack1x8(byte src, ref ulong dst)
    {
        dst = bits.scatter(src, lsb<ulong>(n8,n1));
        return ref dst;
    }

    /// <summary>
    /// Distributes each packed source bit to the least significant bit of 8 corresponding target bytes
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">A reference to the target buffer</param>
    [MethodImpl(Inline), Op]
    public static ref byte unpack1x8(byte src, ref byte dst)
    {
        seek64(dst, 0) = bits.scatter(src, lsb<ulong>(n8,n1));
        return ref dst;
    }

    /// <summary>
    /// Packs the least significant bit from 32 32-bit source values to a 32-bit target
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="dst">The target value</param>
    [MethodImpl(Inline), Op]
    public static ref uint pack1x32(in uint src, ref uint dst)
    {
        var v0 = vload(w256, skip(src,0*8));
        var v1 = vload(w256, skip(src,1*8));
        var x = vpack.vpack256x16u(v0, v1);

        v0 = vload(w256, skip(src,2*8));
        v1 = vload(w256, skip(src,3*8));
        var y = vpack.vpack256x16u(v0,v1);

        dst = vpack.vpacklsb(vpack.vpack256x8u(x, y));
        return ref dst;
    }

    /// <summary>
    /// Packs 4 1-bit values taken from the least significant bit of each 8-bit source segment
    /// </summary>
    [MethodImpl(Inline), Op]
    public static byte pack2x1(ushort src)
        => (byte)bits.gather(src, Lsb32x8x1);

    /// <summary>
    /// Packs 4 1-bit values taken from the least significant bit of each 8-bit source segment
    /// </summary>
    [MethodImpl(Inline), Op]
    public static byte pack4x1(uint src)
        => (byte)bits.gather(src, Lsb32x8x1);

    /// <summary>
    /// Packs 8 1-bit values taken from the least significant bit of each 8-bit source segment
    /// </summary>
    [MethodImpl(Inline), Op]
    public static byte pack8x1(ulong src)
        => (byte)bits.gather(src, Lsb64x8x1);

    /// <summary>
    /// Packs the least significant bit from 8 32-bit unsigned integers to an 8-bit target
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="dst">The target value</param>
    [MethodImpl(Inline), Op]
    public static ref byte pack1x8(in uint src, ref byte dst)
    {
        var v0 = vload(w256, src);
        dst = (byte)vpack.vpacklsb(vpack.vpack128x8u(v0));
        return ref dst;
    }

    [MethodImpl(Inline), Op]
    public static byte pack1x8(uint src)
    {
        var buffer = z8;
        return pack1x8(src, ref buffer);
    }

    /// <summary>
    /// Packs the least significant bit from 16 32-bit unsigned integers to a 16-bit target
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="dst">The target value</param>
    [MethodImpl(Inline), Op]
    public static ref ushort pack1x16(in uint src, ref ushort dst)
    {
        var v0 = vload(w256, skip(src, 0*8));
        var v1 = vload(w256, skip(src, 1*8));
        dst = vpack.vpacklsb(vpack.vpack128x8u(v0, v1));
        return ref dst;
    }

    /// <summary>
    /// Packs the least significant bit from 16 32-bit unsigned integers to a 16-bit target
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="count">The number of bits to pack</param>
    /// <param name="dst">The target width</param>
    [MethodImpl(Inline), Op]
    public static ushort pack1x16(in uint src)
    {
        var buffer = z16;
        return pack1x16(src, ref buffer);
    }

    /// <summary>
    /// Packs the least significant bit from 64 32-bit unsigned integers to a 64-bit target
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="n">The number of bits to pack</param>
    /// <param name="w">The target width</param>
    [MethodImpl(Inline), Op]
    public static ulong pack64x1(in uint src)
    {
        var buffer = z64;
        return pack64x1(src, ref buffer);
    }

    /// <summary>
    /// Packs the least significant bit from 64 32-bit unsigned integers to a 64-bit target
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="dst">The target value</param>
    [MethodImpl(Inline), Op]
    public static ref ulong pack64x1(in uint src, ref ulong dst)
    {
        var w = w256;
        var v0 = vload(w, skip(src, 0*8));
        var v1 = vload(w, skip(src, 1*8));
        var x = vpack.vpack256x16u(v0, v1);
        v0 = vload(w, skip(src,2*8));
        v1 = vload(w, skip(src,3*8));

        var y = vpack.vpack256x16u(v0, v1);
        var packed = (ulong)vpack.vpacklsb(vpack.vpack256x8u(x,y));

        v0 = vload(w, skip(src,4*8));
        v1 = vload(w, skip(src,5*8));
        x = vpack.vpack256x16u(v0,v1);

        v0 = vload(w, skip(src,6*8));
        v1 = vload(w, skip(src,7*8));
        y = vpack.vpack256x16u(v0,v1);

        packed |= (ulong)vpack.vpacklsb(vpack.vpack256x8u(x,y)) << 32;

        dst = packed;
        return ref dst;
    }

    /// <summary>
    /// Partitions the first 63 source bits into 21 target segments each of effective width 3
    /// </summary>
    /// <param name="src">The source bits</param>
    /// <param name="dst">The receiving buffer</param>
    [MethodImpl(Inline), Op]
    public static ref byte unpack3x21(ulong src, ref byte dst)
    {
        SpanPack.unpack21x3(src, cover(dst, 8));
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

    [MethodImpl(Inline), Unpack]
    public static uint unpack1x8x16(ushort src, ref ulong dst)
    {
        const ulong M = (ulong)Lsb64x8x1;
        seek(dst, 0) = bits.scatter(src, M);
        seek(dst, 1) = bits.scatter((ushort)(src >> 8), M);
        return 16;
    }

    /// <summary>
    /// Unpacks 32 8-bit segments onto 32 16-bit targets
    /// </summary>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline), Op]
    public static ByteBlock64 unpack16x32(Cell256 src)
    {
        var storage = ByteBlock64.Empty;
        var dst = recover<ushort>(storage.Bytes);
        vstore(vinflatelo256x16u(src), ref seek(dst,0));
        vstore(vinflatehi256x16u(src), ref seek(dst,16));
        return storage;
    }

    [MethodImpl(Inline), Unpack]
    public static ref ulong unpack1x8x32(uint src, ref ulong dst)
    {
        unpack1x8x16((ushort)src, ref dst);
        unpack1x16x8((ushort)(src >> 16), ref seek8(dst, 16));
        return ref dst;
    }    

    /// <summary>
    /// Packs 4 1-bit values taken from the least significant bit of each source byte of an index-identified block
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="mod">The bit selection modulus</param>
    /// <param name="block">The index of the block to pack</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static byte pack4x8x1(uint src)
        => (byte)bits.gather(src, Lsb32x8x1);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static byte pack8x8x1(ulong src)
        => (byte)bits.gather(src, Lsb64x8x1);    

    /// <summary>
    /// Distributes 32 packed source bits to the least significant bit of 32 corresponding target bytes
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static ref byte unpack1x32x8(uint src, ref byte dst)
    {
        var m = lsb<ulong>(n8,n1);
        seek64(dst, 0) = scatter((ulong)(byte)src, m);
        seek64(dst, 1) = scatter((ulong)((byte)(src >> 8)), m);
        seek64(dst, 2) = scatter((ulong)((byte)(src >> 16)), m);
        seek64(dst, 3) = scatter((ulong)((byte)(src >> 24)), m);
        return ref dst;
    }

    /// <summary>
    /// Distributes 8 source bits to the least bit of 8 32-bit targets
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="dst">The target reference</param>
    [MethodImpl(Inline), Op]
    public static void unpack1x32x32(byte src, ref uint dst)
    {
        var buffer = z64;
        ref var tmp = ref uint8(ref buffer);
        unpack1x8(src, ref tmp);
        vinflate8x256x32u(tmp).StoreTo(ref dst);
    }

    [MethodImpl(Inline), Op]
    public static ByteBlock128 unpack1x32x32(uint src)
    {
        var buffer = ByteBlocks.alloc(n32);
        ref var tmp = ref ByteBlocks.first<byte>(ref buffer);

        var block = ByteBlocks.alloc(n128);
        ref var target = ref ByteBlocks.first<uint>(ref block);

        unpack1x32x8(src, ref tmp);
        vinflate8x256x32u(tmp, 0, ref target);
        vinflate8x256x32u(tmp, 1, ref target);
        vinflate8x256x32u(tmp, 2, ref target);
        vinflate8x256x32u(tmp, 3, ref target);
        return block;
    }        

    /// <summary>
    /// Distributes the first 27-bits of a 32-bit source evenly over the lower 3 bits of 9 8-bit segments
    /// </summary>
    /// <param name="src">The source</param>
    /// <param name="dst">The target</param>
    [MethodImpl(Inline), Op]
    public static ref byte unpack3x9(uint src, ref byte dst)
    {
        seek64(dst, 0) = bits.scatter(src, Lsb64x8x3);
        seek16(dst, 4) = (byte)bits.scatter(src >> 24, Lsb64x8x3);
        return ref dst;
    }    

    /// <summary>
    /// Partitions a 64-bit source into 64 8-bit targets, each of effective width 1
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="dst">The target span</param>
    [MethodImpl(Inline), Op]
    public static ref byte unpack1x64(ulong src, ref byte dst)
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

    [MethodImpl(Inline), Unpack]
    public static ref ulong unpack1x64(ulong src, ref ulong dst)
    {
        unpack1x8x32((uint)src, ref dst);
        unpack1x32x8((uint)(src >> 32), ref seek8(dst, 32));
        return ref dst;
    }    

    [MethodImpl(Inline), Op]
    public static ref byte unpack3x10(uint src, ref byte dst)
    {
        seek64(dst, 0) = scatter(src, Lsb64x8x3);
        seek16(dst, 4) = (ushort)scatter(src >> 24, Lsb64x8x3);
        return ref dst;
    }    

    /// <summary>
    /// Partitions a 64-bit source value into 4 segments of width 16
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="dst">A target span of sufficient length</param>
    [MethodImpl(Inline), Op]
    public static ref ushort unpack16x4(ulong src, ref ushort dst)
    {
        seek64(dst, 0) = src;
        return ref dst;
    }    
}
