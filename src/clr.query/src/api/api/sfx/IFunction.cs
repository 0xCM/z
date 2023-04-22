//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IFunction
    {

    }

    [Free]
    public interface IFunction<F,S,T> : IFunction
        where F : IFunction<F,S,T>
    {
        T Eval(S x);

        KeyedValue<S,T> Map(S x);
    }
}