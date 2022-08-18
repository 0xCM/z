//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IArithmeticExpr : IExprDeprecated
    {

    }

    public interface IArithmeticExpr<T> : IArithmeticExpr, ILogixExpr<T>
        where  T : unmanaged
    {

    }

    public interface IArithmeticOpExpr : IOperatorExpr
    {

    }

    public interface IArithmeticOpExpr<T> : IArithmeticOpExpr, IArithmeticExpr<T>, IOperatorExpr<T>
        where T : unmanaged
    {


    }

    public interface IArithmeticOpExpr<T,K> : IArithmeticOpExpr<T>, IOperatorExpr<T,K>
        where T : unmanaged
        where K : unmanaged, Enum
    {

    }
}