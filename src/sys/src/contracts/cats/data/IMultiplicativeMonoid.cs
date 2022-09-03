//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IMultiplicativeMonoid<T> : IMonoid<T>, IMultiplicativeSemigroup<T>, IUnital<T>
    {

    }

    /// <summary>
    /// Characterizes multiplicative monoidal structure
    /// </summary>
    /// <typeparam name="S">The classified structure</typeparam>
    /// <typeparam name="T">The underlying type</typeparam>
    public interface IMultiplicativeMonoid<S,T> : IMultiplicativeMonoid<T>
        where S : IMultiplicativeMonoid<S,T>, new()
    {

    }
}