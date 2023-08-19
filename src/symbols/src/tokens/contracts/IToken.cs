//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToken
    {
        string Group {get;}

        uint Index {get;}

        string Name {get;}

        string Expr {get;}

        string Info {get;}
    }

    [Free]
    public interface IToken<K> : IToken
        where K : unmanaged
    {   
        K Kind {get;}
    }
}