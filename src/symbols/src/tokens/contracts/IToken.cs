//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IToken
    {
        uint Index {get;}

        ReadOnlySpan<char> Name {get;}

        ReadOnlySpan<char> Expr {get;}
    }

    [Free]
    public interface IToken<K> : IToken
        where K : unmanaged
    {   
        K Kind {get;}
    }
}