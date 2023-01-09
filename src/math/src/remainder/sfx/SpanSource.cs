//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public delegate ReadOnlySpan<T> ReadOnlySpanSource<T>();

    [Free]
    public interface IReadOnlySpanSource<T> : IFunc
    {
        ReadOnlySpan<T> Invoke();

        ReadOnlySpanSource<T> Delegate()
            => Invoke;
    }

    [Free]
    public delegate Span<T> SpanSource<T>();

    [Free]
    public interface ISpanSource<T> : IFunc
    {
        Span<T> Invoke();

        SpanSource<T> Delegate()
            => Invoke;
    }    
}