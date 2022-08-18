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
    }
}