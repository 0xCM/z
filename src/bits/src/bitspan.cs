//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public static class BitVectorsK
{
    const NumericKind Closure = Root.UnsignedInts;

    /// <summary>
    /// Converts the vector to a bitspan representation
    /// </summary>
    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BitSpan32 bitspan32<T>(ScalarBits<T> src, int? maxbits = null)
        where T : unmanaged
            => BitSpans32.from(src.State, maxbits ?? 0);

    /// <summary>
    /// Converts the vector to a bitspan representation
    /// </summary>
    [MethodImpl(Inline)]
    public static BitSpan32 bitspan32<N,T>(ScalarBits<N,T> x)
        where T : unmanaged
        where N : unmanaged, ITypeNat
            => BitSpans32.from(x.State, Typed.nat32i<N>());

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static BitSpan bitspan<T>(BitVector256<T> src, Span<bit> buffer)
        where T : unmanaged
    {
        var storage = ByteBlock32.Empty;
        var dst = recover<T>(storage.Bytes);
        vgcpu.vstore(src.State, dst);
        BitPack.unpack(dst, buffer);
        return new BitSpan(buffer);
    }
    
    /// <summary>
    /// Converts the vector to a bitspan representation
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static BitSpan bitspan(BitVector4 x)
        => BitSpans.create(x.State);

    /// <summary>
    /// Converts the vector to a bitspan representation
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static BitSpan bitspan(BitVector8 x)
        => BitSpans.create(x.State);

    /// <summary>
    /// Converts the vector to a bitspan representation
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static BitSpan bitspan(BitVector16 x)
        => BitSpans.create(x.State);

    /// <summary>
    /// Converts the vector to a bitspan representation
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static BitSpan bitspan(BitVector24 x)
        => BitSpans.create(x.State);

    /// <summary>
    /// Converts the vector to a bitspan representation
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static BitSpan bitspan(BitVector32 x)
        => BitSpans.create(x.State);

    /// <summary>
    /// Converts the vector to a bitspan representation
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static BitSpan bitspan(BitVector64 x)
        => BitSpans.create(x.State);
}

