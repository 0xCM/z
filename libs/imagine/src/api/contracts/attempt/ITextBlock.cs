//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ITextBlock : ITextual
    {
        string Content {get;}

        uint Length
            => (uint)Content.Length;

        ReadOnlySpan<char> Characters
            => Content;

        string ITextual.Format()
            => Content;
    }
}