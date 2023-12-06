//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    /// <summary>
    /// Rotates the source bits rightward by a specified offset
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="offset">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static byte rotr(byte src, byte offset)
        => (byte)((src >> offset) | (src << (8 - offset)));

    /// <summary>
    /// Rotates the source bits rightward by a specified offset
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="offset">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static ushort rotr(ushort src, byte offset)
        => (ushort)((src  >> offset) | (src << (16 - offset)));

    /// <summary>
    /// Rotates the source bits rightward by a specified offset
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="offset">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static uint rotr(uint src, byte offset)
        => (src >> offset) | (src << (32 - offset));

    /// <summary>
    /// Rotates the source bits rightward by a specified offset
    /// </summary>
    /// <param name="src">The source value</param>
    /// <param name="offset">The magnitude of the rotation</param>
    [MethodImpl(Inline), Rotr]
    public static ulong rotr(ulong src, byte offset)
        => (src >> offset) | (src << (64 - offset));
}
