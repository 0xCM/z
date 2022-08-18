//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Algs
    {
        /// <summary>
        /// Returns an empty array
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] empty<T>()
            => Array.Empty<T>();

        /// <summary>
        /// Tests whether a specified <see cref='string'/> is either null or of zero length
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Inline), Op]
        public static bool empty(string src)
            => string.IsNullOrEmpty(src);
    }
}