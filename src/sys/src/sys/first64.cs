//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents the span head as a reference to a <see cref='long'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref long first64i<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,long>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to a <see cref='long'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly long first64i<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,long>(src));

        /// <summary>
        /// Presents the span head as a reference to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ulong first64u<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,ulong>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to a <see cref='ulong'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ulong first64u<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,ulong>(src));
    }
}