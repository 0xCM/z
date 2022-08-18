//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XTend
    {
        /// <summary>
        /// Clones the source span into a new span
        /// </summary>
        /// <param name="src">The span to replicate</param>
        /// <typeparam name="T">The element type</typeparam>
        /// <returns>Returns the replicated span</returns>
        [Op, Closures(Closure)]
        public static Span<T> Replicate<T>(this ReadOnlySpan<T> src)
        {
            Span<T> dst = new T[src.Length];
            src.CopyTo(dst);
            return dst;
        }

        /// <summary>
        /// Clones the source span into a new span
        /// </summary>
        /// <param name="src">The span to replicate</param>
        /// <typeparam name="T">The element type</typeparam>
        /// <returns>Returns the replicated span</returns>
        [Op, Closures(Closure)]
        public static Span<T> Replicate<T>(this Span<T> src)
            => src.ReadOnly().Replicate();
    }
}