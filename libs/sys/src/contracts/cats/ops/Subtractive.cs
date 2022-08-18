//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes operational negation and subtraction
        /// </summary>
        /// <typeparam name="T">The individual type</typeparam>
        public interface ISubtractive<T>
        {
            /// <summary>
            /// Combines the first operand with the negation of the second
            /// </summary>
            /// <param name="lhs">The first operand</param>
            /// <param name="rhs">The second operand</param>
            /// <returns></returns>
            T Sub(T lhs, T rhs);
        }
    }
}