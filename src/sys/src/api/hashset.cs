//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static HashSet<T> hashset<T>()
            => new HashSet<T>();

        /// <summary>
        /// Constructs an array from a parameter array
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static HashSet<T> hashset<T>(T[] src)
            => new HashSet<T>(src);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static HashSet<T> hashset<T>(IEnumerable<T> members)
            => new HashSet<T>(members);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static HashSet<T> hashset<T>(ReadOnlySpan<T> src)
            => new HashSet<T>(src.ToArray());

        /// <summary>
        /// Allocates a <see cref='HashSet{t}'/> with a specified capacity
        /// </summary>
        /// <param name="capacity">The number of preallocated slots</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static HashSet<T> hashset<T>(int capacity)
            => new HashSet<T>((int)capacity);
    }
}