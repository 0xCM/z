//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILiteralExpr<T> : IExprDeprecated
    {
        Identifier Name {get;}

        Constant<T> Value {get;}
    }
}