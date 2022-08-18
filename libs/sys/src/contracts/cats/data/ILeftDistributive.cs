//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILeftDistributive<S>: IMultiplicative<S>, IAdditive<S>
    {
        /// <summary>
        /// Characterizes a type that defines an operator that left-distributes
        /// multiplication over addition
        /// </summary>
        /// <typeparam name="X">The operand type</typeparam>
        S LeftDistribute((S x, S y) rhs);
    }

    public interface ILeftDistributive<S,T>  : ILeftDistributive<S>, IMultiplicative<S,T>, IAdditive<S>
        where S : ILeftDistributive<S,T>, new() { }

}