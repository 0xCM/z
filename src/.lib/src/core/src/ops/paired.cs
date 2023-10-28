//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Creates a non-homogenous pair
        /// </summary>
        /// <param name="a">The first member</param>
        /// <param name="b">The second member</param>
        /// <typeparam name="T0">The first member type</typeparam>
        /// <typeparam name="T1">The second member type</typeparam>
        [MethodImpl(Inline)]
        public static Paired<T0,T1> paired<T0,T1>(T0 a, T1 b)
            => new Paired<T0,T1>(a,b);
    }
}