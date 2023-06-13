//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILiteralRule : IRuleExpr
    {
    }

    public interface ILiteralRule<T> : ILiteralRule, IRuleExpr<T>
    {


    }
}