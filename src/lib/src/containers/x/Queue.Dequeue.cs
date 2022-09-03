//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Linq;

    partial class XTend
    {
        /// <summary>
        /// Pops all items off the queue
        /// </summary>
        /// <typeparam name="T">The type of value contained int he queue</typeparam>
        /// <param name="q">The queue to manipulate</param>
        public static IEnumerable<T> Dequeue<T>(this ConcurrentQueue<T> q)
        {
            var item = default(T);
            var go = true;
            while (go)
            {
                if (q.TryDequeue(out item))
                    yield return item;
                else
                    go = false;
            }
        }

        /// <summary>
        /// Pops a sequence of items off a queue
        /// </summary>
        /// <typeparam name="T">The item type</typeparam>
        /// <param name="q">The queue to manipulate</param>
        /// <param name="max">The maximum number of items to remove</param>
        public static IEnumerable<T> Dequeue<T>(this ConcurrentQueue<T> q, int max)
            => q.Dequeue().Take(max);
    }
}