//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static math;

partial class bits
{
    /// <summary>
    /// Computes the parity of the source vector, which is 1 if an odd number of its components are enabled and 0 otherwise
    /// </summary>
    /// <remarks>
    /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
    /// value 1 when an odd number of its input values are 1 and 0 otherwise.
    /// </remarks>
    [MethodImpl(Inline), Op]
    public static bit parity(byte src)
        => odd(pop(src));

    /// <summary>
    /// Computes the parity of the source vector, which is 1 if an odd number of its components are enabled and 0 otherwise
    /// </summary>
    /// <remarks>
    /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
    /// value 1 when an odd number of its input values are 1 and 0 otherwise.
    /// </remarks>
    [MethodImpl(Inline), Op]
    public static bit parity(ushort src)
        => odd(pop(src));

    /// <summary>
    /// Computes the parity of the source vector, which is 1 if an odd number of its components are enabled and 0 otherwise
    /// </summary>
    /// <remarks>
    /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
    /// value 1 when an odd number of its input values are 1 and 0 otherwise.
    /// </remarks>
    [MethodImpl(Inline), Op]
    public static bit parity(uint src)
        => odd(pop(src));

    /// <summary>
    /// Computes the parity of the source vector, which is 1 if an odd number of its components are enabled and 0 otherwise
    /// </summary>
    /// <remarks>
    /// The parity function p:{0,1}x...x{0,1} -> {0,1} is a boolean function that attains the
    /// value 1 when an odd number of its input values are 1 and 0 otherwise.
    /// </remarks>
    [MethodImpl(Inline), Op]
    public static bit parity(ulong src)
        => odd(pop(src));
}
