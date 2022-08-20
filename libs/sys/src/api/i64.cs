//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents a T-references as a <see cref='long'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref long i64<T>(in T src)
            => ref @as<T,long>(src);

        /// <summary>
        /// Presents the bytespan head as a reference to a signed 64-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref long i64<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,long>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an signed 64-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly long i64<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,long>(src));            
    }
}