//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Creates an homogenous truple
        /// </summary>
        /// <param name="a">The first member</param>
        /// <param name="b">The second member</param>
        /// <param name="c">The third member</param>
        /// <typeparam name="T">The member type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Triple<T> triple<T>(T a, T b, T c)
            => new Triple<T>(a,b,c);
    }
}