//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Allocates a specified number of triples
        /// </summary>
        /// <param name="count">The number of triples to allocate</param>
        /// <typeparam name="T">The triple type</typeparam>
        public static Triples<T> triples<T>(uint count)
            => new Triple<T>[count];
    }
}