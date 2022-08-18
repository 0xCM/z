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
        /// Defines an array-specific join operator
        /// </summary>
        /// <param name="src"></param>
        /// <param name="selector"></param>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="T"></typeparam>
        public static T[] SelectMany<S,T>(this S[] src, Func<S,IEnumerable<T>> selector)
            => Enumerable.SelectMany(src, selector).ToArray();
    }
}