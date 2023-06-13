//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRuleExpr : IExpr
    {
        bool IsTerminal
            => false;

        bool INullity.IsEmpty
            => false;
    }

    public interface IRuleExpr<T> : IRuleExpr
    {
        T Content {get;}
    }
}