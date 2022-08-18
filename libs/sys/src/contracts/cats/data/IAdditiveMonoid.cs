//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAdditiveMonoid<S> : IMonoid<S>, IAdditiveSemigroup<S>, INullary<S>
        where S : new()
    {

    }

    /// <summary>
    /// Characterizes additive monoidal structure
    /// </summary>
    /// <typeparam name="S">The classified structure</typeparam>
    /// <typeparam name="T">The underlying type</typeparam>
    public interface IAdditiveMonoid<S,T> :  IAdditiveMonoid<S>
        where S : IAdditiveMonoid<S,T>, new()
    {

    }
}