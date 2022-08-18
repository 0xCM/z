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
        /// Returns the last element if it exists; otherwise returns the supplied default
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="default">The replacement value if the sequence is empty</param>
        /// <typeparam name="T">The item type</typeparam>
        public static T LastOrDefault<T>(this IEnumerable<T> src, T @default = default)
            => src.Any() ? src.Last() : @default;

        /// <summary>
        /// Returns the last element if it exists; otherwise returns the value supplied
        /// by invoking the default function
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="default">The function invoked to produce a default value</param>
        /// <typeparam name="T">The item type</typeparam>
        public static T LastOrDefault<T>(this IEnumerable<T> src, Func<T> @default)
            => src.Any() ? src.Last() : @default(); 
    }
}