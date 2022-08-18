//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IDag : IExpr
    {
        IExpr Left {get;}

        IExpr Right {get;}
    }

    [Free]
    public interface IDag<L,R> : IDag
        where L : IExpr
        where R : IExpr
    {
        new L Left {get;}

        new R Right {get;}

        IExpr IDag.Left
            => Left;

        IExpr IDag.Right
            => Right;
    }

    [Free]
    public interface IDag<T> : IDag<T,T>
        where T : IExpr
    {

    }
}