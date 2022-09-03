//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IListRule : IRuleExpr
    {
        Index<IRuleExpr> Terms {get;}
    }

    public interface IListRule<T> : IListRule
        where T : IRuleExpr
    {
        new Index<T> Terms {get;}

        Index<IRuleExpr> IListRule.Terms
            => Terms.Map(x => (IRuleExpr)x);
    }
}