//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAdditiveGroup<S> : IGroupLike<S>, IAdditiveMonoid<S>
        where S : new()
    {
        /// <summary>
        /// Unary structural negation
        /// </summary>
        S Invert();
    }

    /// <summary>
    /// Characterizes an additive group structure
    /// </summary>
    /// <typeparam name="T">The type over which the structure is defind</typeparam>
    /// <typeparam name="S">The structure type</typeparam>
    public interface IAdditiveGroup<S,T> : IAdditiveGroup<S>, IGroupLike<S,T>, IAdditiveMonoid<S,T>
        where S : IAdditiveGroup<S,T>, new()
    {

    }
}