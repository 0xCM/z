//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

/// <summary>
/// Characterizes a function that accepts two source spans and a target span of bits
/// </summary>
/// <typeparam name="T">The span element type</typeparam>
[Free, SFx]
public interface IUnarySpanPred<T> : IFunc
{
    Span<bit> Invoke(ReadOnlySpan<T> src, Span<bit> dst);
}

/// <summary>
/// Characterizes a function that accepts two source spans and a target span of bits
/// </summary>
/// <typeparam name="T">The span element type</typeparam>
[Free, SFx]
public interface IBinarySpanPred<T> : IFunc
{
    Span<bit> Invoke(ReadOnlySpan<T> lhs, ReadOnlySpan<T> rhs, Span<bit> dst);
}

/// <summary>
/// Characterizes a function that accepts two source spans and a target span of parametric type
/// </summary>
/// <typeparam name="T">The span element type</typeparam>
[Free, SFx]
public interface IBinarySpanPred<T,P> : IFunc
{
    Span<P> Invoke(ReadOnlySpan<T> lhs, ReadOnlySpan<T> rhs, Span<P> dst);
}
