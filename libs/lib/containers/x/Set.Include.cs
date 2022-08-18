//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Adds items from a stream to a target set
        /// </summary>
        /// <param name="dst">The target set</param>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The item type</typeparam>
        public static bool[] Include<T>(this ISet<T> dst, IEnumerable<T> src)
            => src.Map(item => dst.Add(item));

        /// <summary>
        /// Adds items from a parameter array to a target set
        /// </summary>
        /// <param name="dst">The target set</param>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The item type</typeparam>
        public static bool[] Include<T>(this ISet<T> dst, params T[] src)
            => src.Select(item => dst.Add(item));

        public static bool[] Include<T>(this ISet<T> dst, ReadOnlySpan<T> src)
            => src.Select(item => dst.Add(item));
    }
}