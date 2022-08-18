//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IReadOnlySpanProvider<T>
    {
        ReadOnlySpan<T> Data();
    }

    [Free]
    public interface ISpanProvider<T> : IReadOnlySpanProvider<T>
    {
        new Span<T> Data();

        ReadOnlySpan<T> IReadOnlySpanProvider<T>.Data()
            => Data();
    }
}