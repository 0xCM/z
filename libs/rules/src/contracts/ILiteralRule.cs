//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILiteralRule : IRuleExpr
    {
        RuleExprKind IRuleExpr.ExprKind
            => RuleExprKind.Literal;
    }

    public interface ILiteralRule<T> : ILiteralRule, IRuleExpr<T>
    {


    }
}