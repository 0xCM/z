//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a semiring structure
    /// </summary>
    /// <typeparam name="S">The structure type</typeparam>
    public interface ISemiring<S> : IAdditiveMonoid<S>, IMultiplicativeMonoid<S>, IDistributive<S>
        where S : ISemiring<S>, new()
     {
        S MulAdd(S y, S z);
     }
}