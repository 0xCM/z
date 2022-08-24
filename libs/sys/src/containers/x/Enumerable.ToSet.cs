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
        /// Creates a set from an item stream
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="items">The item sequence</param>
        public static ISet<T> ToSet<T>(this IEnumerable<T> items)
            => new HashSet<T>(items);

        /// <summary>
        /// Creates a set from a sequence projection
        /// </summary>
        /// <typeparam name="T">The source element type</typeparam>
        /// <typeparam name="U">The targert element type</typeparam>
        /// <param name="items">The item sequence</param>
        public static ISet<U> ToSet<T,U>(this IEnumerable<T> items, Func<T,U> selector)
            => new HashSet<U>(items.Select(selector));
    }
}