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

    [Free]
    public interface IToken<K,E> : IToken<K>
        where K : unmanaged
        where E : ICharBlock
    {
        new E Name {get;}

        new E Expr {get;}

        ReadOnlySpan<char> IToken.Expr
            => Expr.Cells;

        ReadOnlySpan<char> IToken.Name
            => Name.Cells;
    }
}