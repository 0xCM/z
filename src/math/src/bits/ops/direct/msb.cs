//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class bits
{
    /// <summary>
    /// Computes the position of the highest enabled source bit, a number between 0 and 7
    /// </summary>
    /// <param name="src">The source bit</param>
    [MethodImpl(Inline), Msb]
    public static byte msb(byte src)
        => (byte)(width<byte>(w8) - 1 - nlz(src));

    /// <summary>
    /// Computes the position of the highest enabled source bit, a number between 0 and 15
    /// </summary>
    /// <param name="src">The source bit</param>
    [MethodImpl(Inline), Msb]
    public static byte msb(ushort src)
        => (byte)(width<ushort>(w8) - 1 - nlz(src));

    /// <summary>
    /// Computes the position of the highest enabled source bit, a number between 0 and 31
    /// </summary>
    /// <param name="src">The source bit</param>
    [MethodImpl(Inline), Msb]
    public static byte msb(uint src)
        => (byte)(width<uint>(w8) - 1 - nlz(src));

    /// <summary>
    /// Computes the position of the highest enabled source bit, a number between 0 and 63
    /// </summary>
    /// <param name="src">The source bit</param>
    [MethodImpl(Inline), Msb]
    public static byte msb(ulong src)
        => (byte)(width<ulong>(w8) - 1 - nlz(src));
}
