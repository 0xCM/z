//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IPredicate : IFunc<object,bool>, IExpr
    {

    }

    [Free]
    public interface IPredicate<T> : IFunc<T,bool>, IExpr
    {

    }


    public interface IConversionOp<S,T> : IFunc, IExpr
    {

    }
}