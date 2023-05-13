//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IStringDispenser : IAllocDispenser
    {
        StringRef String(ReadOnlySpan<char> content);
    }
}