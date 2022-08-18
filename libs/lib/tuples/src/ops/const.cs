//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tuples
    {
        /// <summary>
        /// Defines an homogenous read-only pair
        /// </summary>
        /// <param name="a">The left member</param>
        /// <param name="b">The right member</param>
        /// <typeparam name="T">The member type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ConstPair<T> @const<T>(T a, T b)
            => new ConstPair<T>(a,b);
    }
}