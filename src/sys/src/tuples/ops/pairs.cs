//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tuples
    {
        /// <summary>
        /// Allocates an homogenous pair store
        /// </summary>
        /// <param name="count">The store capacity</param>
        /// <typeparam name="T">The member type</typeparam>
        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static Pairs<T> pairs<T>(uint count)
            where T : unmanaged
                => new Pairs<T>(sys.alloc<Pair<T>>(count));

        [MethodImpl(Inline)]
        public static Pairings<A,B> pairings<A,B>(Paired<A,B>[] src)
            => src;

        /// <summary>
        /// Allocates a specified number of pairings
        /// </summary>
        /// <param name="count">The number of pairings to allocate</param>
        /// <typeparam name="A">The left type</typeparam>
        /// <typeparam name="B">The right type</typeparam>
        public static Pairings<A,B> pairings<A,B>(uint count)
            => new Paired<A,B>[count];
    }
}