//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Implementation of a basic multiset
    /// </summary>
    /// <remarks>See https://en.wikipedia.org/wiki/Multiset</remarks>
    public struct Multiset<T>
    {
        readonly Dictionary<T,int> data;

        [MethodImpl(Inline)]
        public Multiset(IEnumerable<T> src)
        {
            data = new Dictionary<T,int>();
            AddRange(src);
        }

        /// <summary>
        /// Adds a sequence of items to the set
        /// </summary>
        /// <param name="src">The source items</param>
        public void AddRange(IEnumerable<T> src)
        {
            foreach(var item in src)
            {
                if(data.ContainsKey(item))
                    data[item] = ++data[item];
                else
                    data[item] = 1;
            }
        }

        public int Count
            => data.Count;

        public bool IsEmtpty
            => Count != 0;

        /// <summary>
        /// Selects the occurrence count for each item in the source
        /// </summary>
        /// <param name="src">The soruce items</param>
        public IEnumerable<(T item, int count)> DistinctCounts(IEnumerable<T> src)
        {
            foreach(var item in src)
                yield return (item, DistinctCount(item));
        }

        static IEnumerable<T> _Duplicates(Multiset<T> src)
            => from k in src.data.Keys
                    where src.data[k] > 1 select k;

        /// <summary>
        /// Selects the members that occur more than once
        /// </summary>
        public IEnumerable<T> Duplicates
            => _Duplicates(this);

        /// <summary>
        /// Determines whether an item exists in the set
        /// </summary>
        /// <param name="candidate">The search item</param>
        [MethodImpl(Inline)]
        public bool IsMember(T candidate)
            => data.ContainsKey(candidate);

        /// <summary>
        /// Selects all contained items with their occurrence counts
        /// </summary>
        /// <param name="item">The item</param>
        /// <param name="count">The number of itmes the item occurs</param>
        public IEnumerable<(T item, int count)> Occurrences()
            => data.Select(x => (x.Key,x.Value));

        /// <summary>
        /// Retrieves the times a specified item appears in the set
        /// </summary>
        /// <param name="subject">The item to count</param>
        public int DistinctCount(T subject)
        {
            var count = 0;
            data.TryGetValue(subject, out count);
            return count;
        }

        /// <summary>
        /// Enumerates the distinct members
        /// </summary>
        public IEnumerable<T> Members
            => data.Keys;
   }
}