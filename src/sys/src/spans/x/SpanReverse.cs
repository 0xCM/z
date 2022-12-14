//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Produces a reversed span from a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The element type</typeparam>
        [Op, Closures(Closure)]
        public static Span<T> Reverse<T>(this ReadOnlySpan<T> src)
        {
            var dst = src.ToArray();
            dst.Reverse();
            return dst;
        }
    }
}