//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Allocates a specified number of pairs
        /// </summary>
        /// <param name="count">The number of pairs to allocate</param>
        /// <typeparam name="T">The pair type</typeparam>
        public static Pairs<T> pairs<T>(uint count)
            => alloc<Pair<T>>(count);
   }
}