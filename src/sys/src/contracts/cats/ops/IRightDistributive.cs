//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a type that defines an operator that right-distributes
        /// multiplication over addition
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IRightDistributive<T> : IMultiplicative<T>, IAdditive<T>
            where T : unmanaged
        {
            T Distribute((T x, T y) lhs, T rhs);
        }
    }
}