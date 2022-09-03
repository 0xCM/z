//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        [MethodImpl(Inline)]
        public static T[] array<T>(IEnumerable<T> src)
            => sys.array(src);

        [MethodImpl(Inline)]
        public static T[] array<T>(List<T> src)
            => sys.array(src);

        [MethodImpl(Inline)]
        public static T[] array<T>(Span<T> src)
            => sys.array(src);

        /// <summary>
        /// Returns an empty array
        /// </summary>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] array<T>()
            => Array.Empty<T>();

        [MethodImpl(Inline)]
        public static T[] array<T>(params T[] src)
            => src;
    }
}