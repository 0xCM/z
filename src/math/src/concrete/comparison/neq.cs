//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

partial class math
{
    /// <summary>
    /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Neq]
    public static bit ne(sbyte a, sbyte b)
        => a != b;

    /// <summary>
    /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Neq]
    public static bit ne(byte a, byte b)
        => a != b;

    /// <summary>
    /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Neq]
    public static bit ne(short a, short b)
        => a != b;

    /// <summary>
    /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Neq]
    public static bit ne(ushort a, ushort b)
        => a != b;

    /// <summary>
    /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Neq]
    public static bit ne(int a, int b)
        => a != b;

    /// <summary>
    /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Neq]
    public static bit ne(uint a, uint b)
        => a != b;

    /// <summary>
    /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Neq]
    public static bit ne(long a, long b)
        => a != b;

    /// <summary>
    /// Defines the test neq:bit := a != b, succeeding if the operands are not equal
    /// </summary>
    /// <param name="a">The left operand</param>
    /// <param name="b">The right operand</param>
    [MethodImpl(Inline), Neq]
    public static bit ne(ulong a, ulong b)
        => a != b;
}
