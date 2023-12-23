//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    /// <summary>
    /// Rotates the source bits rightward by a specified count
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static byte rotr(byte src, byte count)
        => (byte)((src >> count) | (src << (8 - count)));

    /// <summary>
    /// Rotates the source bits rightward by a specified count
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static ushort rotr(ushort src, byte count)
        => (ushort)((src  >> count) | (src << (16 - count)));

    /// <summary>
    /// Rotates the source bits rightward by a specified count
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static uint rotr(uint src, byte count)
        => (src >> count) | (src << (32 - count));

    /// <summary>
    /// Rotates the source bits rightward by a specified count
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static ulong rotr(ulong src, byte count)
        => (src >> count) | (src << (64 - count));

    /// <summary>
    /// Rotates the source bits rightward by a specified count
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="count">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static UInt128 rotr(UInt128 src, byte count)
        => (src >> count) | (src << (64 - count));
}
