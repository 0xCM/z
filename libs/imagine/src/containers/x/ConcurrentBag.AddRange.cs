//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Adds a collection of items to a bag
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="bag">The destination bag</param>
        /// <param name="items">The items to add</param>
        [MethodImpl(Inline)]
        public static void AddRange<T>(this ConcurrentBag<T> bag, IEnumerable<T> items)
            => items.Iter(item => bag.Add(item));
    }
}