//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        /// <summary>
        /// Extracts an inclusive seqment form the source span
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first span cell</param>
        /// <param name="i1">The index of the last last span cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> segment<T>(Span<T> src, long i0, long i1)
            => slice(src, i0, i1 - i0 + 1);

        /// <summary>
        /// Extracts an inclusive seqment form the source span
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first span cell</param>
        /// <param name="i1">The index of the last last span cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> segment<T>(Span<T> src, ulong i0, ulong i1)
            => slice(src, i0, i1 - i0 + 1);

        /// <summary>
        /// Extracts an inclusive seqment form the source span
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first span cell</param>
        /// <param name="i1">The index of the last last span cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> segment<T>(ReadOnlySpan<T> src, long i0, long i1)
            => slice(src, i0, i1 - i0 + 1);

        /// <summary>
        /// Extracts an inclusive seqment form the source span
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first span cell</param>
        /// <param name="i1">The index of the last last span cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> segment<T>(ReadOnlySpan<T> src, ulong i0, ulong i1)
            => slice(src, i0, i1 - i0 + 1);

        /// <summary>
        /// Extracts an inclusive seqment form the source span
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first span cell</param>
        /// <param name="i1">The index of the last last span cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<char> segment(ReadOnlySpan<char> src, long i0, long i1)
            => slice(src, i0, i1 - i0 + 1);

        /// <summary>
        /// Extracts an inclusive seqment form the source span
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="i0">The index of the first span cell</param>
        /// <param name="i1">The index of the last last span cell</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<char> segment(ReadOnlySpan<char> src, ulong i0, ulong i1)
            => slice(src, i0, i1 - i0 + 1);
    }
}