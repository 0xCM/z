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
        /// Prepends one or more items to the head of the sequence
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="src">The sequence that will be prependend</param>
        /// <param name="preceding">The items that will be prepended</param>
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> src, params T[] preceding)
            => preceding.Concat(src); 
    }
}