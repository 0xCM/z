//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISourceDispenser : IAllocDispenser<SourceText>
    {
        SourceText Source(string src);

        SourceText Source(ReadOnlySpan<string> src);
    }
}