//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMultiplicativeSemigroup<T>: ISemigroup<T>, IMultiplicative<T>
    {

    }

    public interface IMulitplicativeSemigroup<S,T> : ISemigroup<T>, IMultiplicative<T>
        where S : IMulitplicativeSemigroup<S,T>, new()
    {

    }

}