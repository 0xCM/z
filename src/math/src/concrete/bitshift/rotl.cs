//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    /// <summary>
    /// Rotates the source bits leftward by a specified count amount
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static byte rotl(byte src, byte count)
        => (byte)((src << count) | (src >> (8 - count)));

    /// <summary>
    /// Rotates the source bits leftward by a specified count amount
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static ushort rotl(ushort src, byte count)
        => (ushort)((src << count) | (src >> (16 - count)));

    /// <summary>
    /// Rotates the source bits leftward by a specified count amount
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static uint rotl(uint src, byte count)
        => (src << count) | (src >> (32 - count));

    /// <summary>
    /// Rotates the source bits leftward by a specified count amount
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static ulong rotl(ulong src, byte count)
        => (src << count) | (src >> (64 - count));

    /// <summary>
    /// Rotates the source bits leftward by a specified count amount
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotl]
    public static UInt128 rotl(UInt128 src, byte count)
        => (src << count) | (src >> (128 - count));
}
