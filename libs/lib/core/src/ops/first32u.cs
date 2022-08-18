//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Presents the bytespan head as a reference to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint first32u<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,uint>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly uint first32u<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,uint>(src));
    }
}