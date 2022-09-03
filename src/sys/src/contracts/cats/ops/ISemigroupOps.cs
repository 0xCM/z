//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Operational
    {
        public interface ISemigroupOps<T>
        {
            /// <summary>
            /// Adjudicates equality between semigroup members
            /// </summary>
            /// <param name="a">The first operand</param>
            /// <param name="b">The second operand</param>
            bool Equals(T a, T b);
        }
    }
}