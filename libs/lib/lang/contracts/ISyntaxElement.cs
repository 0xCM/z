//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ISyntaxElement : ITextual
    {
        string RenderPattern {get;}
    }

    public interface ISyntaxElement<T> : ISyntaxElement
    {

    }

    public interface ISyntaxElement<H,T> : ISyntaxElement
        where H : ISyntaxElement<H,T>
    {

    }
}