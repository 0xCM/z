//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tuples
    {
        /// <summary>
        /// Creates an homogenous pair
        /// </summary>
        /// <param name="lhs">The left member</param>
        /// <param name="rhs">The right member</param>
        /// <typeparam name="T">The member type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Pair<T> pair<T>(T lhs, T rhs)
            => new Pair<T>(lhs, rhs);
    }
}