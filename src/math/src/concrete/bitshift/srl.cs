//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    /// <summary>
    /// Applies a logical right shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift rightwards</param>
    [MethodImpl(Inline), Srl]
    public static sbyte srl(sbyte src, byte count)
        => (sbyte)srl32i(src,count);

    /// <summary>
    /// Applies a logical right shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift rightwards</param>
    [MethodImpl(Inline), Srl]
    public static byte srl(byte src, byte count)
        => (byte)srl32u(src,count);

    /// <summary>
    /// Applies a logical right shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift rightwards</param>
    [MethodImpl(Inline), Srl]
    public static short srl(short src, byte count)
        => (short) srl32i(src,count);

    /// <summary>
    /// Applies a logical right shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift rightwards</param>
    [MethodImpl(Inline), Srl]
    public static ushort srl(ushort src, byte count)
        => (ushort) srl32u(src,count);

    /// <summary>
    /// Applies a logical right shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift rightwards</param>
    [MethodImpl(Inline), Srl]
    public static int srl(int src, byte count)
        => srl32i(src,count);

    /// <summary>
    /// Applies a logical right shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift rightwards</param>
    [MethodImpl(Inline), Srl]
    public static uint srl(uint src, byte count)
        => src >> count;

    /// <summary>
    /// Applies a logical right shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift rightwards</param>
    [MethodImpl(Inline), Srl]
    public static long srl(long src, byte count)
        => srl64i(src,count);

    /// <summary>
    /// Applies a logical right shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift rightwards</param>
    [MethodImpl(Inline), Srl]
    public static ulong srl(ulong src, byte count)
        => src >> count;

    [MethodImpl(Inline), Srl]
    public static UInt128 srl(UInt128 src, byte count)
        => src >> count;

    [MethodImpl(Inline), Srl]
    public static Int128 srl(Int128 src, byte count)
        => src >> count;

    [MethodImpl(Inline), Srl]
    static int srl32i(int src, byte count)
        => (int)((uint)src >> count);

    [MethodImpl(Inline), Srl]
    static uint srl32u(uint src, byte count)
        => src >> count;

    [MethodImpl(Inline), Srl]
    static long srl64i(long src, byte count)
        => (long)((ulong)src >> count);


}
