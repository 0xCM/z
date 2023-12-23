//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    /// <summary>
    /// Applies a logical left shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift leftwards</param>
    [MethodImpl(Inline), Sll]
    public static sbyte sll(sbyte src, byte count)
        => (sbyte)(src << count);

    /// <summary>
    /// Applies a logical left shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift leftwards</param>
    [MethodImpl(Inline), Sll]
    public static byte sll(byte src, byte count)
        => (byte)(src << count);

    /// <summary>
    /// Applies a logical left shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift leftwards</param>
    [MethodImpl(Inline), Sll]
    public static short sll(short src, byte count)
        => (short)(src << count);

    /// <summary>
    /// Applies a logical left shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift leftwards</param>
    [MethodImpl(Inline), Sll]
    public static ushort sll(ushort src, byte count)
        => (ushort)(src << count);

    /// <summary>
    /// Applies a logical left shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift leftwards</param>
    [MethodImpl(Inline), Sll]
    public static int sll(int src, byte count)
        => src << count;

    /// <summary>
    /// Applies a logical left shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift leftwards</param>
    [MethodImpl(Inline), Sll]
    public static uint sll(uint src, byte count)
        => src << count;

    /// <summary>
    /// Applies a logical left shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift leftwards</param>
    [MethodImpl(Inline), Sll]
    public static long sll(long src, byte count)
        => src << count;

    /// <summary>
    /// Applies a logical left shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift leftwards</param>
    [MethodImpl(Inline), Sll]
    public static ulong sll(ulong src, byte count)
        => src << count;        

    /// <summary>
    /// Applies a logical left shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift leftwards</param>
    [MethodImpl(Inline), Sll]
    public static UInt128 sll(UInt128 src, byte count)
        => src << count;        

    /// <summary>
    /// Applies a logical left shift to the source value
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The number of bits to shift leftwards</param>
    [MethodImpl(Inline), Sll]
    public static Int128 sll(Int128 src, byte count)
        => src << count;        
}
