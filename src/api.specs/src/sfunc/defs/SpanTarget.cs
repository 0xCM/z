//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public delegate void ReadOnlySpanTarget<T>(ReadOnlySpan<T> src);

    [Free]
    public interface IReadOnlySpanTarget<T> : IFunc
    {
        void Invoke(ReadOnlySpan<T> src);

        ReadOnlySpanTarget<T> Delegate()
            => Invoke;
    }

    [Free]
    public delegate void SpanTarget<T>(Span<T> src);

    [Free]
    public interface ISpanTarget<T> : IFunc
    {
        void Invoke(Span<T> src);

        SpanTarget<T> Delegate()
            => Invoke;
    }
}