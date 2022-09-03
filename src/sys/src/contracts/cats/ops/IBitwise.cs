//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        /// <summary>
        /// Characterizes bitwise operations over an operand
        /// </summary>
        public interface IBitwise<T>
            where T : unmanaged
        {
            /// <summary>
            /// Computes the bitwise AND
            /// </summary>
            /// <param name="a">The left value</param>
            /// <param name="b">The right value</param>
            T And(T a, T b);

            /// <summary>
            /// Computes the bitwise OR
            /// </summary>
            /// <param name="a">The left value</param>
            /// <param name="b">The right value</param>
            T Or(T a, T b);

            /// <summary>
            /// Computes the bitwise XOR
            /// </summary>
            /// <param name="a">The left value</param>
            /// <param name="b">The right value</param>
            T XOr(T a, T b);

            /// <summary>
            /// Computes the bitwise complement
            /// </summary>
            /// <param name="a">The operand</param>
            T Not(T a);
        }
    }
}