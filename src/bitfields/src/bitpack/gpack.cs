//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static vcpu;

using static BitPack;
using static BitMaskLiterals;

[ApiHost,Free]
public class gpack
{    
    const NumericKind Closure = UnsignedInts;

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static T extract<T>(uint offset, byte width, T src)
        where T : unmanaged
            => generic<T>(BitPack.extract(bw64(src), (byte)offset, width));

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint pack<A>(A a, uint offset, Span<byte> dst)
        where A : unmanaged
    {
        var i0 = offset;
        var i = i0;
        @as<A>(seek(dst, offset)) = a;
        i += size<A>();
        return (uint)(i - i0);
    }

    [MethodImpl(Inline)]
    public static uint pack<A,B>(A a, B b, uint offset, Span<byte> dst)
        where A : unmanaged
        where B : unmanaged
    {
        var i0 = offset;
        var i = i0;
        @as<A>(seek(dst,i)) = a;
        i += size<A>();
        @as<B>(seek(dst, i)) = b;
        i += size<B>();
        return (uint)(i - i0);
    }

    [MethodImpl(Inline)]
    public static uint pack<A,B,C>(A a, B b, C c, uint offset, Span<byte> dst)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
    {
        var i0 = offset;
        var i = i0;
        @as<A>(seek(dst,i)) = a;
        i += size<A>();
        @as<B>(seek(dst, i)) = b;
        i += size<B>();
        @as<C>(seek(dst, i)) = c;
        i += size<C>();
        return (uint)(i - i0);
    }

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint pack<A>(A a, Span<byte> dst)
        where A : unmanaged
            => gpack.pack(a,0,dst);

    [MethodImpl(Inline)]
    public static uint pack<A,B,C>(A a, B b, C c, Span<byte> dst)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
            => gpack.pack(a,b,c,0u,dst);

    [MethodImpl(Inline)]
    public static uint pack<A,B,C,D>(A a, B b, C c, D d, uint offset, Span<byte> dst)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
        where D : unmanaged
    {
        var i0 = offset;
        var i = i0;
        @as<A>(seek(dst,i)) = a;
        i += size<A>();
        @as<B>(seek(dst, i)) = b;
        i += size<B>();
        @as<C>(seek(dst, i)) = c;
        i += size<C>();
        @as<D>(seek(dst, i)) = d;
        i += size<D>();
        return (uint)(i - i0);
    }

    [MethodImpl(Inline)]
    public static uint pack<A,B,C,D>(A a, B b, C c, D d, Span<byte> dst)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
        where D : unmanaged
            => pack(a,b,c,d,0u,dst);

    [MethodImpl(Inline)]
    public static uint pack<A,B>(A a, B b, Span<byte> dst)
        where A : unmanaged
        where B : unmanaged
            => gpack.pack(a,b,0u,dst);

    /// <summary>
    /// Reads a partial value if there aren't a sufficient number of bytes to comprise a target value
    /// </summary>
    /// <param name="src">The source span</param>
    /// <typeparam name="T">The target type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static T scalar<T>(ReadOnlySpan<bit> src)
        where T : unmanaged
    {
        var dst = default(T);
        if(src.Length == 0)
            return dst;
        return pack(src, ref dst);
    }

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ref T pack<T>(ReadOnlySpan<bit> src, ref T dst)
        where T : unmanaged
    {
        pack(recover<bit,byte>(src),0u, out dst);
        return ref dst;
    }

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static void pack<T>(ReadOnlySpan<byte> src, uint offset, out T dst)
        where T : unmanaged
    {
        dst = default;
        var buffer = bytes(dst);
        SpanPack.pack(src, offset, ref seek(buffer,0));
    }

    /// <summary>
    /// Projects each source bit from each source element into an element of the target span at the corresponding index
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The bit target</param>
    /// <typeparam name="T">The bit source type</typeparam>
    /// <typeparam name="T">The target type</typeparam>
    [MethodImpl(Inline)]
    public static Span<T> unpack<S,T>(ReadOnlySpan<S> src, Span<T> dst)
        where S : unmanaged
        where T : unmanaged
    {
        if(typeof(T) == typeof(bit))
        {
            var target = recover<T,bit>(dst);
            unpack(src, target);
            return recover<bit,T>(target);
        }
        else
        {
            var wCell = width<S>(w32);
            var cells = (uint)src.Length;
            var wSource = wCell*(uint)cells;
            var k = 0u;
            for(var i=0; i<cells; i++)
            for(byte j=0; j<wCell; j++)
                seek(dst, k++) = bit.gtest(skip(src,i), j) == bit.On ? one<T>() : zero<T>();
            return dst;
        }
    }

    [MethodImpl(Inline)]
    public static void unpack<S,T>(S src, Span<T> dst)
        where S : unmanaged
        where T : unmanaged
    {
        var count = min(width<S>(), dst.Length);
        for(var i=0u; i<count; i++)
            seek(dst, i) = bit.gtest(src, (byte)i) == bit.On ? one<T>() : zero<T>();
    }

    public static Span<T> unpack<S,T>(Span<S> src, Span<T> dst)
        where S : unmanaged
        where T : unmanaged
            => unpack(src.ReadOnly(), dst);

    [Unpack, Closures(Closure)]
    public static Span<bit> unpack<T>(ReadOnlySpan<T> src)
        where T : unmanaged
    {
        var dst = alloc<bit>(width<T>()*src.Length);
        unpack(src, dst);
        return dst;
    }

    [MethodImpl(Inline), Unpack, Closures(Closure)]
    public static uint unpack<T>(ReadOnlySpan<T> src, Span<bit> dst)
        where T : unmanaged
    {
        var kCell = src.Length;
        var wCell = width<T>(w8);
        var bitcount = width<T>()*kCell;
        ref var target = ref first(dst);
        var k = 0;
        for(var i=0; i<kCell; i++)
        for(byte bitpos=0; bitpos<wCell; bitpos++, k++)
            seek(target, k) = bit.gtest(skip(src, i), bitpos);
        return bitcount;
    }

    [Unpack, Closures(Closure)]
    public static Span<bit> unpack<T>(T src)
        where T : unmanaged
    {
        var count = width<T>(w8);
        var dst = span<bit>(count);
        for(byte i=0; i<count; i++)
            seek(dst,i) = bit.gtest(src,i);
        return dst;
    }


    public static Span<bit> unpack<T,B>(T src, B dst)
        where T : unmanaged, IBitNumber
        where B : unmanaged, IStorageBlock<B>
    {
        var buffer = recover<bit>(dst.Bytes);
        unpack(src, buffer);
        return slice(buffer, 0, src.Width);
    }

    [MethodImpl(Inline)]
    static void unpack<T>(T src, Span<bit> dst)
        where T : unmanaged, IBitNumber
    {
        var width = src.Width;
        if(size<T>() == 8)
            SpanPack.unpack1x8(u8(src), dst);
        else if(size<T>() <= 16)
            SpanPack.unpack16x1(u16(src), dst);
        else if(size<T>() <= 32)
            SpanPack.unpack1x64(u32(src), dst);
        else
            SpanPack.unpack1x64(u64(src), dst);
    }

    /// <summary>
    /// Packs 32 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="n">The number of bits to pack</param>
    /// <param name="mod">The bit selection modulus</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint pack32x8x1<T>(in T src)
        where T : unmanaged
            => vmovemask(vgcpu.vsll(vload(w256, u64(src)),7));

    /// <summary>
    /// Packs 32 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="count">The number of bits to pack</param>
    /// <param name="mod">The selection modulus</param>
    /// <param name="offset">The source offset</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static uint pack32x8x1<T>(ReadOnlySpan<T> src, uint offset = 0)
        where T : unmanaged
            => pack32x8x1(skip(src, offset));

    /// <summary>
    /// Packs 64 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ulong pack64x8x1<T>(in T src)
        where T : unmanaged
    {
        var dst = 0ul;
        dst = (ulong)pack32x8x1(src);
        dst |=((ulong)pack32x8x1(skip(src, 32))) << 32;
        return dst;
    }

    /// <summary>
    /// Packs 64 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The data source</param>
    /// <param name="offset">The source offset</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ulong pack64x8x1<T>(ReadOnlySpan<T> src, uint offset)
        where T : unmanaged
            => pack64x8x1(skip(src, offset));

    /// <summary>
    /// Packs 8 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The data source</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static byte pack8x8x1<T>(in T src)
        where T : unmanaged
            => (byte)bits.gather(Numeric.force<T,ulong>(src), Lsb64x8x1);

    /// <summary>
    /// Packs 8 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="count">The number of bits to pack</param>
    /// <param name="mod">The selection modulus</param>
    /// <param name="offset">The source offset</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static byte pack8x8x1<T>(ReadOnlySpan<T> src, uint offset)
        where T : unmanaged
            => (byte)bits.gather(uint64(skip(src, offset)), Lsb64x8x1);
    /// <summary>
    /// Packs 16 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="n">The number of bits to pack</param>
    /// <param name="mod">The bit selection modulus</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ushort pack16x8x1<T>(in T src)
        where T : unmanaged
            => vmovemask(v8u(vgcpu.vsll(vload(w128, u64(src)),7)));

    /// <summary>
    /// Pack 16 1-bit values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="count">The number of bits to pack</param>
    /// <param name="mod">The selection modulus</param>
    /// <param name="offset">The source offset</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ushort pack16x8x1<T>(ReadOnlySpan<T> src, uint offset = 0)
        where T : unmanaged
            => pack16x8x1(skip(src,(uint)offset));

    /// <summary>
    /// Sends each source bit to a corresponding target cell
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The bit target</param>
    [MethodImpl(Inline), Unpack]
    public static void unpack1x32x8(uint src, Span<byte> dst)
        => unpack1x8x32(src, ref first64u(dst));


    [MethodImpl(Inline), Unpack, Closures(Closure)]
    public static Span<Bit32> unpack32<T>(ReadOnlySpan<T> src, Span<Bit32> dst)
        where T : unmanaged
    {
        var srcsize = width<T>();
        var bitcount = width<T>()*src.Length;
        ref var target = ref first(dst);
        var k = 0;
        for(var i=0; i<src.Length; i++)
        for(byte j=0; j<srcsize; j++, k++)
            seek(target, k) = bit.gtest(skip(src,i), j);
        return dst;
    }

    /// <summary>
    /// Extracts each bit from each source element into caller-supplied target at the corresponding index
    /// </summary>
    /// <param name="src">The source values to be unpacked</param>
    /// <param name="dst">The target span of length at least bitsize[T]*length(Span[T])</param>
    /// <typeparam name="T">The source value type</typeparam>
    [MethodImpl(Inline), Unpack, Closures(Closure)]
    public static Span<Bit32> unpack32<T>(Span<T> src, Span<Bit32> dst)
        where T : unmanaged
            => unpack32(src.ReadOnly(),dst);

    /// <summary>
    /// Extracts each bit from each source element into caller-supplied target at the corresponding index
    /// </summary>
    /// <param name="src">The source values to be unpacked</param>
    /// <param name="dst">The target array of length at least bitsize[T]*length(Span[T])</param>
    /// <typeparam name="T">The source value type</typeparam>
    [MethodImpl(Inline), Unpack, Closures(Closure)]
    public static Span<Bit32> unpack32<T>(Span<T> src, Bit32[] dst)
        where T : unmanaged
            => unpack32(src, dst.AsSpan());

    /// <summary>
    /// Projects each source bit from each source element into an element of the target span at the corresponding index
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The bit target</param>
    /// <typeparam name="T">The bit source type</typeparam>
    /// <typeparam name="T">The target type</typeparam>
    [MethodImpl(Inline)]
    public static Span<T> unpack32<S,T>(ReadOnlySpan<S> src, Span<T> dst)
        where S : unmanaged
        where T : unmanaged
    {
        if(typeof(T) == typeof(Bit32))
            return recover<Bit32,T>(unpack32(src, recover<T,Bit32>(dst)));
        else
        {
            var srcsize = width<S>();
            var bitcount = width<S>()*src.Length;
            var k = 0u;
            for(var i=0; i<src.Length; i++)
            for(byte j=0; j<srcsize; j++)
                seek(dst,k++) = bit.gtest(skip(src,i), j) == bit.On ? one<T>() : zero<T>();
            return dst;
        }
    }

    [MethodImpl(Inline)]
    public static Span<T> unpack32<S,T>(Span<S> src, Span<T> dst)
        where S : unmanaged
        where T : unmanaged
            => unpack32(src.ReadOnly(), dst);
            
    /// <summary>
    /// Unpacks each primal source bit to a 32-bit target
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The bit target</param>
    /// <typeparam name="T">The source type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static void unpack1x32<T>(T src, Span<uint> dst)
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            SpanPack.unpack8x32(uint8(src), dst);
        else if(typeof(T) == typeof(ushort))
            SpanPack.unpack1x16x32(uint16(src), dst);
        else if(typeof(T) == typeof(uint))
            SpanPack.unpack1x32x32(uint32(src), dst);
        else if(typeof(T) == typeof(ulong))
            SpanPack.unpack1x64x32(uint64(src), dst);
        else
            throw no<T>();
    }


    /// <summary>
    /// Packs bitsize[T] values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="mod">The bit selection modulus</param>
    /// <param name="offset">The source offset</param>
    /// <param name="t">A target type representative</param>
    /// <typeparam name="S">The source cell type</typeparam>
    /// <typeparam name="T">The target type</typeparam>
    [MethodImpl(Inline)]
    public static T pack<S,T>(ReadOnlySpan<S> src, N8 mod, uint offset)
        where S : unmanaged
        where T : unmanaged
            => pack_u<S,T>(src, mod, offset);

    /// <summary>
    /// Packs bitsize[T] values taken from the least significant bit of each source byte
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="mod">The bit selection modulus</param>
    /// <param name="offset">The source offset</param>
    /// <param name="t">A target type representative</param>
    /// <typeparam name="S">The source cell type</typeparam>
    /// <typeparam name="T">The target type</typeparam>
    [MethodImpl(Inline)]
    public static T pack<S,T>(Span<S> src, N8 mod, uint offset)
        where S : unmanaged
        where T : unmanaged
            => pack_u<S,T>(src.ReadOnly(), mod, offset);

    [MethodImpl(Inline)]
    static T pack_u<S,T>(ReadOnlySpan<S> src, N8 mod, uint offset)
        where S : unmanaged
        where T : unmanaged
    {
        if(typeof(T) == typeof(byte))
            return generic<T>(pack8x8x1(src, offset));
        else if(typeof(T) == typeof(ushort))
            return generic<T>(pack16x8x1(src, offset));
        else if(typeof(T) == typeof(uint))
            return generic<T>(pack32x8x1(src, offset));
        else if(typeof(T) == typeof(ulong))
            return generic<T>(pack64x8x1(src, offset));
        else
            return pack_i<S,T>(src, mod, offset);
    }

    [MethodImpl(Inline)]
    static T pack_i<S,T>(ReadOnlySpan<S> src, N8 mod, uint offset)
        where S : unmanaged
        where T : unmanaged
    {
        if(typeof(T) == typeof(sbyte))
            return generic<T>((sbyte)pack8x8x1(src, offset));
        else if(typeof(T) == typeof(short))
            return generic<T>((short)pack16x8x1(src, offset));
        else if(typeof(T) == typeof(int))
            return generic<T>((int)pack32x8x1(src, offset));
        else if(typeof(T) == typeof(long))
            return generic<T>((long)pack64x8x1(src, offset));
        else
            throw no<T>();
    }    
}
