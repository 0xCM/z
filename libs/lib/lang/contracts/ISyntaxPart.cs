//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISyntaxPart : ITextual
    {
        TextBlock Content {get;}
    }

    public interface ISyntaxPart<T> : ISyntaxPart
        where T : ISyntaxPart<T>
    {

    }
}