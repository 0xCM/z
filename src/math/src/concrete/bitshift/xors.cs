//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    /// <summary>
    /// Computes a ^ ((a << offset) ^ (a >> offset));
    /// </summary>
    /// <param name="a">The source value</param>
    /// <param name="offset">The number of bits to shift the source value</param>
    [MethodImpl(Inline), Xors]
    public static byte xors(byte a, byte offset)
        => (byte)xors((uint)a,offset);

    /// <summary>
    /// Computes a ^ ((a << offset) ^ (a >> offset));
    /// </summary>
    /// <param name="a">The source value</param>
    /// <param name="offset">The number of bits to shift the source value</param>
    [MethodImpl(Inline), Xors]
    public static sbyte xors(sbyte a, byte offset)
        => (sbyte)xors((byte)a,offset);

    /// <summary>
    /// Computes a ^ ((a << offset) ^ (a >> offset));
    /// </summary>
    /// <param name="a">The source value</param>
    /// <param name="offset">The number of bits to shift the source value</param>
    [MethodImpl(Inline), Xors]
    public static ushort xors(ushort a, byte offset)
        => (ushort)xors((uint)a,offset);

    /// <summary>
    /// Computes a ^ ((a << offset) ^ (a >> offset));
    /// </summary>
    /// <param name="a">The source value</param>
    /// <param name="offset">The number of bits to shift the source value</param>
    [MethodImpl(Inline), Xors]
    public static short xors(short a, byte offset)
        => (short)xors((ushort)a,offset);

    /// <summary>
    /// Computes a ^ ((a << offset) ^ (a >> offset));
    /// </summary>
    /// <param name="a">The source value</param>
    /// <param name="offset">The number of bits to shift the source value</param>
    [MethodImpl(Inline), Xors]
    public static uint xors(uint a, byte offset)
        => a^((a << offset) ^ (a >> offset));

    /// <summary>
    /// Computes a ^ ((a << offset) ^ (a >> offset));
    /// </summary>
    /// <param name="a">The source value</param>
    /// <param name="offset">The number of bits to shift the source value</param>
    [MethodImpl(Inline), Xors]
    public static int xors(int a, byte offset)
        => a^((a << offset) ^ (a >> offset));

    /// <summary>
    /// Computes a ^ ((a << offset) ^ (a >> offset));
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="offset">The number of bits to shift the source value</param>
    [MethodImpl(Inline), Xors]
    public static long xors(long src, byte offset)
        => src^((src << offset) ^ (src >> offset));

    /// <summary>
    /// Computes a ^ ((a << offset) ^ (a >> offset));
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="offset">The number of bits to shift the source value</param>
    [MethodImpl(Inline), Xors]
    public static ulong xors(ulong src, byte offset)
        => src^((src << offset) ^ (src >> offset));
}
