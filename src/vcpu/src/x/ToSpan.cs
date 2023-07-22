//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        /// <summary>
        /// Allocates a span into which vector content is stored
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> ToSpan<T>(this Vector128<T> src)
            where T : unmanaged
                => vgcpu.vspan(src);

        /// <summary>
        /// Allocates and deposits vector content to a span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The component type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> ToSpan<T>(this Vector256<T> src)
            where T : unmanaged
                => vgcpu.vspan(src);

    }
}