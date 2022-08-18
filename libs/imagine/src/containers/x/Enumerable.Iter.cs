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
        /// Applies an action to each member of the collection
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="items">The items to enumerate</param>
        /// <param name="action">The action to apply</param>
        /// <param name="pll">Indicates whether the action should be applied concurrently</param>
        [MethodImpl(Inline)]
        public static void Iter<T>(this IEnumerable<T> items, Action<T> action, bool pll = false)
        {
            if (pll)
                items.AsParallel().ForAll(action);
            else
                foreach (var item in items)
                    action(item);
        }

        /// <summary>
        /// Enumerates stream elements in pairs, until one of the streams is exhausted,
        /// invoking a traversal action for each enumerated pair
        /// </summary>
        /// <param name="lhs">The left stream</param>
        /// <param name="rhs">The right stream</param>
        /// <param name="f">The side-effect</param>
        /// <typeparam name="T">The element type</typeparam>
        public static void Iter<T>(this IEnumerable<T> lhs, IEnumerable<T> rhs, Action<T,T> f)
        {
            var left = lhs.GetEnumerator();
            var right = rhs.GetEnumerator();

            while(left.MoveNext() && right.MoveNext())
                f(left.Current, right.Current);
        }
    }
}