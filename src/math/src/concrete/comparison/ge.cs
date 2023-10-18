//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    /// <summary>
    /// Defines the test gt:bit := a >= b, succeeding if the first operand is larger than or equal to the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="a">The second operand</param>
    [MethodImpl(Inline), GtEq]
    public static bit ge(sbyte a, sbyte b)
        => a >= b;

    /// <summary>
    /// Defines the test gt:bit := a >= b, succeeding if the first operand is larger than or equal to the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="a">The second operand</param>
    [MethodImpl(Inline), GtEq]
    public static bit ge(byte a, byte b)
        => a >= b;

    /// <summary>
    /// Defines the test gt:bit := a >= b, succeeding if the first operand is larger than or equal to the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="a">The second operand</param>
    [MethodImpl(Inline), GtEq]
    public static bit ge(short a, short b)
        => a >= b;

    /// <summary>
    /// Defines the test gt:bit := a >= b, succeeding if the first operand is larger than or equal to the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="a">The second operand</param>
    [MethodImpl(Inline), GtEq]
    public static bit ge(ushort a, ushort b)
        => a >= b;

    /// <summary>
    /// Defines the test gt:bit := a >= b, succeeding if the first operand is larger than or equal to the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="a">The second operand</param>
    [MethodImpl(Inline), GtEq]
    public static bit ge(int a, int b)
        => a >= b;

    /// <summary>
    /// Defines the test gt:bit := a >= b, succeeding if the first operand is larger than or equal to the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="a">The second operand</param>
    [MethodImpl(Inline), GtEq]
    public static bit ge(uint a, uint b)
        => a >= b;

    /// <summary>
    /// Defines the test gt:bit := a >= b, succeeding if the first operand is larger than or equal to the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="a">The second operand</param>
    [MethodImpl(Inline), GtEq]
    public static bit ge(long a, long b)
        => a >= b;

    /// <summary>
    /// Defines the test gt:bit := a >= b, succeeding if the first operand is larger than or equal to the second
    /// </summary>
    /// <param name="a">The first operand</param>
    /// <param name="a">The second operand</param>
    [MethodImpl(Inline), GtEq]
    public static bit ge(ulong a, ulong b)
        => a >= b;
}
