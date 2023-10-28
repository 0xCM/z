//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class BitVectors
{
    /// <summary>
    /// Converts the vector to a bitstring representation
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static BitString bitstring(BitVector4 x)
        => BitStrings.scalar(x.Data, (byte)x.Width);

    /// <summary>
    /// Converts the vector to a bitstring representation
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static BitString bitstring(BitVector8 x)
        => BitStrings.scalar(x.Data);

    /// <summary>
    /// Converts the vector to a bitstring representation
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static BitString bitstring(BitVector16 x)
        => BitStrings.scalar(x.Data);

    /// <summary>
    /// Converts the vector to a bitstring representation
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static BitString bitstring(BitVector24 x)
        => BitStrings.scalar(x.Data,24);

    /// <summary>
    /// Converts the vector to a bitstring representation
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static BitString bitstring(BitVector32 x)
        => BitStrings.scalar(x.Data);

    /// <summary>
    /// Converts the vector to a bitstring representation
    /// </summary>
    /// <param name="x">The source vector</param>
    [MethodImpl(Inline), Op]
    public static BitString bitstring(BitVector64 x)
        => BitStrings.scalar(x.Data);
}
