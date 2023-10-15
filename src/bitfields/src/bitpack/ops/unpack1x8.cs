//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;
using static BitMasks;

partial class BitPack
{
    /// <summary>
    /// Distributes each packed source bit to the least significant bit of the corresponding target byte
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack1x8(byte src, Span<byte> dst)
        => seek64(first(dst), 0) = bits.scatter((ulong)(byte)src, lsb<ulong>(n8, n1));

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
    /// Distributes 8 packed source bits to 8 corresponding target bits
    /// </summary>
    /// <param name="src">The packed source bits</param>
    /// <param name="dst">The target buffer</param>
    [MethodImpl(Inline), Op]
    public static void unpack1x8(byte src, Span<bit> dst)
        => unpack1x8(src, ref u8(first(dst)));

    /// <summary>
    /// Sends each source bit to a corresponding target cell
    /// </summary>
    /// <param name="src">The bit source</param>
    /// <param name="dst">The bit target</param>
    [MethodImpl(Inline), Unpack]
    public static ref ulong unpack1x8(byte src, uint offset, Span<byte> dst)
        => ref unpack1x8(src, ref seek64(dst, offset));

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
}
