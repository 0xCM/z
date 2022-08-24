//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    partial class XTend
    {
        /// <summary>
        /// Constructs an array of specified length from a stream
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <param name="length">The length of the index</param>
        /// <typeparam name="T">The item type</typeparam>
        public static T[] TakeArray<T>(this IEnumerable<T> src, int length)
            => src.Take(length).ToArray();

        /// <summary>
        /// Constructs an array from a specified number of elements from a source stream after a skip
        /// </summary>
        /// <param name="src">The source stream</param>
        /// <typeparam name="T">The cell type</typeparam>
        public static T[] TakeArray<T>(this IEnumerable<T> src, int skip, int count)
            => src.Skip(skip).TakeArray(count);
    }
}