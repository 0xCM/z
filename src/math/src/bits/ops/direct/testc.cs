//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class bits
{
    /// <summary>
    /// Returns true of all bits are enabled, false otherwise
    /// </summary>
    [MethodImpl(Inline),TestC]
    public static bit testc(byte src)
        => (byte.MaxValue & src) == byte.MaxValue;

    /// <summary>
    /// Returns true of all bits are enabled, false otherwise
    /// </summary>
    [MethodImpl(Inline),TestC]
    public static bit testc(ushort src)
        => (ushort.MaxValue & src) == ushort.MaxValue;

    /// <summary>
    /// Returns true of all bits are enabled, false otherwise
    /// </summary>
    [MethodImpl(Inline),TestC]
    public static bit testc(uint src)
        => (uint.MaxValue & src) == uint.MaxValue;

    /// <summary>
    /// Returns true of all bits are enabled, false otherwise
    /// </summary>
    [MethodImpl(Inline),TestC]
    public static bit testc(ulong src)
        => (ulong.MaxValue & src) == ulong.MaxValue;
}
