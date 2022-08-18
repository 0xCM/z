//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Returns the second term of the sequence if it exists; otherwise returns the default value
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <typeparam name="T">The item type</typeparam>
        public static T SecondOrDefault<T>(this IEnumerable<T> items)
            => items.Take(2).LastOrDefault();
    }
}