//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Creates a heterogenous triple
        /// </summary>
        /// <param name="a">The first member</param>
        /// <param name="b">The second member</param>
        /// <param name="c">The third member</param>
        /// <typeparam name="A">The first member type</typeparam>
        /// <typeparam name="B">The second member type</typeparam>
        /// <typeparam name="C">The third member type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Tripled<A,B,C> tripled<A,B,C>(A a, B b, C c)
            => new Tripled<A,B,C>(a,b,c);
    }
}