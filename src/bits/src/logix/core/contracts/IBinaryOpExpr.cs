//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a binary operator parametrized by expression type
    /// </summary>
    public interface IBinaryOpExpr<X> : IOperatorExpr
        where X : IExpr
    {
        X Left {get;}

        X Right {get;}
    }
}