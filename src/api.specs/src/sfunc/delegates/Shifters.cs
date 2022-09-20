//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines the canonical shape of a bitwise shift function
    /// </summary>
    /// <param name="a">The source value</param>
    /// <param name="count">The shift amount, typically in bits</param>
    /// <typeparam name="T">The operand type</typeparam>
    [Free]
    public delegate T Shifter<T>(T a, byte count)
        where T : unmanaged;
    [Free]
    public delegate Span<T> Imm8ShiftSpanOp<T>(ReadOnlySpan<T> src, byte imm8, Span<T> dst);
}