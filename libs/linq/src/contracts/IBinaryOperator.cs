//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    public interface IBinaryOperator : IOperator
    {
        IOperatorApplication Apply(object Left, object Right);
    }

    public interface IBinaryOperator<F> : IBinaryOperator, IOperator<F>
        where F : IBinaryOperator<F>
    {

    }

    public interface IBinaryOperator<F,T> : IBinaryOperator<F>
        where F : IBinaryOperator<F,T>
    {
        T Apply(T x, T y);
    }

    public interface IBinaryPredicate<F,T> : IBinaryOperator<F,T>
        where F : IBinaryOperator<F,T>
    {

    }
}