//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes a type for which commutative additivity can be defined
        /// </summary>
        /// <typeparam name="T">The operand type</typeparam>
        public interface IAdditive<T> : ICommutativeOps<T>
        {
            /// <summary>
            /// Alias for commutative semigroup composition operator
            /// </summary>
            /// <param name="lhs">The first element</param>
            /// <param name="rhs">The second element</param>
            T Add(T lhs, T rhs);
        }
    }
}