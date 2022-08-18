//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        /// <summary>
        /// Linq orderby operator specialized for arrays
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="f">The order criterion selector</param>
        /// <typeparam name="T">The array element type</typeparam>
        /// <typeparam name="K">The order criterion type</typeparam>
        public static T[] OrderBy<T,K>(this T[] src, Func<T,K> f)
            => Enumerable.OrderBy(src,f).ToArray();

        /// <summary>
        /// Linq orderby operator specialized for arrays
        /// </summary>
        /// <param name="src">The source array</param>
        /// <param name="f">The order criterion selector</param>
        /// <typeparam name="T">The array element type</typeparam>
        /// <typeparam name="K">The order criterion type</typeparam>
        public static T[] OrderBy<T,K1,K2>(this T[] src, Func<T,K1> f1, Func<T,K2> f2)
            => src.AsEnumerable().OrderBy(f1).ThenBy(f2).ToArray();
    }
}