//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using static BitPack;
using static BitMaskLiterals;

[ApiHost,Free]
public class gpack
{
    const NumericKind Closure = UnsignedInts;

    /// <summary>
    /// Sends each source bit to a corresponding target cell
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The bit target</param>
    [MethodImpl(Inline), Unpack]
    public static void unpack1x32x8(uint src, SpanBlock256<byte> dst)
        => unpack1x32x8(src, dst.Storage);

    /// <summary>
    /// Sends each source bit to a corresponding target cell
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The bit target</param>
    [MethodImpl(Inline), Unpack]
    public static void unpack1x32x8(uint src, Span<byte> dst)
        => unpack1x8x32(src, ref first64u(dst));

    /// <summary>
    /// Distributes each packed source bit to the least significant bit of the corresponding target byte
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The blocked target</param>
    /// <param name="block">The block index</param>
    /// <typeparam name="T">The source type</typeparam>
    [MethodImpl(Inline), Op]
    public static SpanBlock256<byte> unpack1x32x8(uint src, SpanBlock256<byte> dst, int block)
    {
        unpack1x32x8(src, dst.CellBlock(block));
        return dst;
    }
    
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
            BitPack.unpack8x32(uint8(src), dst);
        else if(typeof(T) == typeof(ushort))
            BitPack.unpack1x16x32(uint16(src), dst);
        else if(typeof(T) == typeof(uint))
            BitPack.unpack1x32x32(uint32(src), dst);
        else if(typeof(T) == typeof(ulong))
            BitPack.unpack1x64x32(uint64(src), dst);
        else
            throw no<T>();
    }

    /// <summary>
    /// Unpacks each primal source bit to a 32-bit target
    /// </summary>
    /// <param name="src">The packed bit source</param>
    /// <param name="dst">The unpacked bit target</param>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static void unpack1x32<T>(ReadOnlySpan<T> src, SpanBlock256<uint> dst)
        where T : unmanaged
    {
        var blockcount = dst.BlockCount;
        var bytes = src.Bytes();
        ref readonly var input = ref first(bytes);
        for(var block=0; block<blockcount; block++)
            BitPack.unpack8x32(skip(input, block), dst.CellBlock(block));
    }

    /// <summary>
    /// Unpacks each primal source bit to a 32-bit blocked target
    /// </summary>
    /// <param name="src">The packed bit source</param>
    /// <param name="dst">The unpacked bit target</param>
    /// <param name="block">The target block index</param>
    /// <typeparam name="T">The source type</typeparam>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static void unpack1x32<T>(ReadOnlySpan<T> src, SpanBlock256<uint> dst, int block)
        where T : unmanaged
    {
        const int blocklen = 8;
        const int blockcount = 1;
        unpack1x32(skip(src, block), dst.CellBlock(block));
    }

    /// <summary>
    /// Unpacks each primal source bit to a 32-bit target
    /// </summary>
    /// <param name="src">The packed bit source</param>
    /// <param name="dst">The unpacked bit target</param>
    [MethodImpl(Inline)]
    public static void unpack1x32<T>(Span<T> src, SpanBlock256<uint> dst)
        where T : unmanaged
            => unpack1x32(src.ReadOnly(),dst);

    /// <summary>
    /// Unpacks each primal source bit to a 32-bit blocked target
    /// </summary>
    /// <param name="src">The packed bit source</param>
    /// <param name="dst">The unpacked bit target</param>
    /// <param name="block">The target block index</param>
    /// <typeparam name="T">The source type</typeparam>
    [MethodImpl(Inline)]
    public void unpack1x32<T>(Span<T> src, SpanBlock256<uint> dst, int block)
        where T : unmanaged
            => unpack1x32(src.ReadOnly(), dst, block);

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
