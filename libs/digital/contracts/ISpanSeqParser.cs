//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISpanSeqParser<S,T>
    {
        uint Parse(ReadOnlySpan<S> src, Span<T> dst);
    }
}