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
        /// Returns the first element if it exists; otherwise returns the supplied default
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="src">The items to search</param>
        /// <param name="default">The replacement value if the sequence is empty</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T FirstOrDefault<T>(this IEnumerable<T> src, T @default)
            => src.Any() ? src.First() : @default;

        /// <summary>
        /// Returns the first element if it exists; otherwise returns the value supplied
        /// by invoking the default function
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="src">The items to search</param>
        /// <param name="default">The function invoked to produce a default value</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T FirstOrDefault<T>(this IEnumerable<T> src, Func<T> @default)
            => src.Any() ? src.First() : @default();

        /// <summary>
        /// Applies a function to the first item in the list that satisfies the predicate if such an item exists.
        /// If no such item exists, the function is applied to the default value of the item
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <typeparam name="R">The function result type</typeparam>
        /// <param name="items">The items to search</param>
        /// <param name="predicate">The predicate applied during the search</param>
        /// <param name="f">The function to apply to the identified item</param>
        [MethodImpl(Inline)]
        public static R OnFirstOrDefault<T,R>(this IEnumerable<T> items, Predicate<T> predicate, Func<T,R> f)
            => f(items.FirstOrDefault(x => predicate(x)));
    }
}