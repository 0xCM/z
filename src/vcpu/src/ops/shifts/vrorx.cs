//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class vcpu     
{
    /// <summary>
    /// Rotates the full 128 bits of a vector rightward a bit-level resolution
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The number of bits to rotate</param>
    [MethodImpl(Inline), Rotrx]
    public static Vector128<ulong> vrorx(Vector128<ulong> src, [Imm] byte count)
        => vor(vsrlx(src, count), vsllx(src, (byte)(128 - count)));

    /// <summary>
    /// Rotates each 128 bit lane rightward a bit-level resolution
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The number of bits to rotate</param>
    [MethodImpl(Inline), Rotrx]
    public static Vector256<ulong> vrorx(Vector256<ulong> src, [Imm] byte count)
        => vor(vsrlx(src, count), vsllx(src, (byte)(128 - count)));

    /// <summary>
    /// Rotates the full 128-bit vector content rightward by 8 bits
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The count selector</param>
    [MethodImpl(Inline), Rotrx]
    public static Vector128<byte> vrorx(Vector128<byte> src, N8 count)
        => vshuffle(src, vror(w128, count));

    /// <summary>
    /// Rotates the full 128-bit vector content rightward by 16 bits
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The count selector</param>
    [MethodImpl(Inline), Rotrx]
    public static Vector128<byte> vrorx(Vector128<byte> src, N16 count)
        => vshuffle(src, vror(w128, count));

    /// <summary>
    /// Rotates the full 128-bit vector content rightward by 24 bits
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The count selector</param>
    [MethodImpl(Inline), Rotrx]
    public static Vector128<byte> vrorx(Vector128<byte> src, N24 count)
        => vshuffle(src, vror(w128, count));

    /// <summary>
    /// Rotates the full 128-bit vector content rightward by 32 bits
    /// </summary>
    /// <param name="src">The source vector</param>
    /// <param name="count">The count selector</param>
    [MethodImpl(Inline), Rotrx]
    public static Vector128<byte> vrorx(Vector128<byte> src, N32 count)
        => vshuffle(src, vror(w128, count));
}