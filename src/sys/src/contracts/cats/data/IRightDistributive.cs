//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRightDistributive<S> : IMultiplicative<S>, IAdditive<S>
    {
        /// <summary>
        /// Characterizes a type that defines an operator that left-distributes
        /// multiplication over addition
        /// </summary>
        /// <typeparam name="X">The operand type</typeparam>
        S RightDistribute((S x, S y) rhs);
    }

    public interface IRightDistributive<S,T>  : IRightDistributive<S>, IMultiplicative<S,T>, IAdditive<S>
        where S : IRightDistributive<S,T>, new() { }
}