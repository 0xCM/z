//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IChoiceRule : IRuleExpr
    {
        Index<IRuleExpr> Terms {get;}
    }
}