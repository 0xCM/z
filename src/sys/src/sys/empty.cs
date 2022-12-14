//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Returns an empty array
        /// </summary>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Options), Op, Closures(Closure)]
        public static T[] empty<T>()
            => Array.Empty<T>();

        /// <summary>
        /// Tests whether a specified <see cref='string'/> is either null or of zero length
        /// </summary>
        /// <param name="src">The source text</param>
        [MethodImpl(Options), Op]
        public static bool empty(string src)
            => string.IsNullOrEmpty(src);

        [MethodImpl(Inline), Op]
        public static bool empty(ReadOnlySpan<char> src)
            => empty(new string(src));
    }
}