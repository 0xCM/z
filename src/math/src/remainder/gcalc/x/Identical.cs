//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Returns 1 if the left and right spans contain identical content and 0 otherwise
        /// </summary>
        /// <param name="xs">The left span</param>
        /// <param name="ys">The right span</param>
        /// <typeparam name="T">The span cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit Identical<T>(this Span<T> xs, Span<T> ys)
            where T : unmanaged
                => gcalc.identical(xs,ys);

        /// <summary>
        /// Returns 1 if the left and right spans contain identical content and 0 otherwise
        /// </summary>
        /// <param name="xs">The left span</param>
        /// <param name="ys">The right span</param>
        /// <typeparam name="T">The span cell type</typeparam>
        [MethodImpl(Inline)]
        public static bit Identical<T>(this ReadOnlySpan<T> xs, ReadOnlySpan<T> ys)
            where T : unmanaged
                => gcalc.identical(xs,ys);
    }
}