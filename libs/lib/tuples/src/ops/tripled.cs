//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tuples
    {
        /// <summary>
        /// Creates a non-homogenous triple
        /// </summary>
        /// <param name="a">The first member</param>
        /// <param name="b">The second member</param>
        /// <param name="c">The third member</param>
        /// <typeparam name="T0">The first member type</typeparam>
        /// <typeparam name="T1">The second member type</typeparam>
        /// <typeparam name="T2">The third member type</typeparam>
        [MethodImpl(Inline)]
        public static Tripled<T0,T1,T2> tripled<T0,T1,T2>(T0 a = default, T1 b = default, T2 c = default)
            => new Tripled<T0,T1,T2>(a,b,c);
    }
}