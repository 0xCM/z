//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ISourceDispenser : IAllocDispenser
    {
        SourceText SourceText(string src);

        SourceText SourceText(ReadOnlySpan<string> src);
    }
}