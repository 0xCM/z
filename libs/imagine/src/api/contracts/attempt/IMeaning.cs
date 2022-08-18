//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes type that defines a Description facet
    /// </summary>
    public interface IMeaning : ITextual
    {
        object Content {get;}

        string ITextual.Format()
            => string.Format("{0}", Content);
    }

    /// <summary>
    /// Characterizes type that defines a Description facet
    /// </summary>
    public interface IMeaning<M> : IMeaning
    {
        new M Content {get;}

        object IMeaning.Content
            => Content;
    }

    public interface IMeaning<H,M> : IMeaning<M>
        where H : IMeaning<H,M>
    {

    }

    public interface IMeaning<H,M,T> : IMeaning<H,M>
        where H : IMeaning<H,M,T>
    {
        T Target {get;}
    }
}