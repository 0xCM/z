//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
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