//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tuples
    {
        /// <summary>
        /// Allocates an homogenous triplestore
        /// </summary>
        /// <param name="count">The store capacity</param>
        /// <typeparam name="T">The member type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Triples<T> triples<T>(int count)
            where T : unmanaged
                => new Triples<T>(sys.alloc<Triple<T>>(count));

        /// <summary>
        /// Allocates an homogenous triplestore
        /// </summary>
        /// <param name="count">The store capacity</param>
        /// <typeparam name="T">The member type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Triples<T> triples<T>(uint count)
            where T : unmanaged
                => new Triples<T>(sys.alloc<Triple<T>>(count));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Triples<T> triples<T>(Triple<T>[] src)
            where T : unmanaged
                => src;
    }
}