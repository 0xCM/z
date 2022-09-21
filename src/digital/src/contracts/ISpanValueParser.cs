//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISpanValueParser<S,T>
    {
        bool Parse(ReadOnlySpan<S> src, out T dst);
    }
}