//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tuples
    {
        /// <summary>
        /// Creates a non-homogenous pair
        /// </summary>
        /// <param name="left">The left member</param>
        /// <param name="right">The right member</param>
        /// <typeparam name="L">The first member type</typeparam>
        /// <typeparam name="R">The second member type</typeparam>
        [MethodImpl(Inline)]
        public static Paired<L,R> paired<L,R>(L left, R right)
            => new Paired<L,R>(left, right);
    }
}