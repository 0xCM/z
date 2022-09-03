//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an operator that applies a bitwise shift or rotation to elements in a source span
    /// </summary>
    [Free, SFx]
    public interface ISpanShift : IFunc
    {

    }

    /// <summary>
    /// Characterizes a span operator that shifts each source element by the same amount
    /// </summary>
    /// <typeparam name="T">The operand type</typeparam>
    [Free, SFx]
    public interface ISpanShift<T> : ISpanShift
    {
        Span<T> Invoke(ReadOnlySpan<T> src, byte imm8, Span<T> dst);

        Imm8ShiftSpanOp<T> Operation => Invoke;
    }

    /// <summary>
    /// Characterizes a span operator that shifts each source element by an amount specified in a corresponding count span
    /// </summary>
    /// <typeparam name="T">The operand type</typeparam>
    [Free, SFx]
    public interface IVarSpanShift<T> : ISpanShift
    {
        Span<T> Invoke(ReadOnlySpan<T> src, ReadOnlySpan<byte> counts, Span<T> dst);
    }
}