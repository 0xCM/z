//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial class Spans
    {
        /// <summary>
        /// Selects a segment [offset, length(src) - 1] from a source span src:ReadOnlySpan[T]
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> slice<T>(ReadOnlySpan<T> src, uint offset)
            => sys.cover(skip(src,offset), (uint)(src.Length - offset));

        /// <summary>
        /// Selects a segment [offset, length(src) - 1] from a source span src:ReadOnlySpan[T]
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> slice<T>(ReadOnlySpan<T> src, ulong offset)
            => sys.cover(skip(src,offset), (ulong)((ulong)src.Length - offset));

        /// <summary>
        /// Selects a segment [offset, length(src) - 1] from a source span src:ReadOnlySpan[T]
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> slice<T>(ReadOnlySpan<T> src, int offset)
            => sys.cover(skip(src,(uint)offset), src.Length - offset);

        /// <summary>
        /// Draws a specified count of T-cells from a source span beginning at a specified offset
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <param name="length"></param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> slice<T>(ReadOnlySpan<T> src, int offset, int length)
            => sys.cover(skip(src,(uint)offset), length);

        /// <summary>
        /// Draws a specified count of T-cells from a source span beginning at a specified offset
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <param name="length"></param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> slice<T>(ReadOnlySpan<T> src, uint offset, uint length)
            => sys.cover(skip(src, offset), length);

        /// <summary>
        /// Draws a specified count of T-cells from a source span beginning at a specified offset
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <param name="length"></param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> slice<T>(ReadOnlySpan<T> src, long offset, long length)
            => sys.cover(skip(src, offset), length);

        /// <summary>
        /// Draws a specified count of T-cells from a source span beginning at a specified offset
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <param name="length"></param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReadOnlySpan<T> slice<T>(ReadOnlySpan<T> src, ulong offset, ulong length)
            => sys.cover(skip(src, offset), length);

        /// <summary>
        /// Selects a segment [offset, length(src) - 1] from a source span src:Span[T]
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> slice<T>(Span<T> src, int offset)
            => CreateSpan(ref sys.seek(first(src), offset), src.Length - offset);

        /// <summary>
        /// Selects a segment [offset, length(src) - 1] from a source span src:Span[T]
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> slice<T>(Span<T> src, uint offset)
            => CreateSpan(ref sys.seek(first(src), offset), (int)(src.Length - offset));

        /// <summary>
        /// Draws a specified count of T-cells from a source span beginning at a specified offset
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <param name="length"></param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> slice<T>(Span<T> src, int offset, int length)
            => CreateSpan(ref sys.seek(first(src), offset), length);

        /// <summary>
        /// Draws a specified count of T-cells from a source span beginning at a specified offset
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <param name="length"></param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> slice<T>(Span<T> src, uint offset, uint length)
            => CreateSpan(ref sys.seek(first(src), offset), (int)length);

        /// <summary>
        /// Draws a specified count of T-cells from a source span beginning at a specified offset
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <param name="length"></param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> slice<T>(Span<T> src, long offset, long length)
            => CreateSpan(ref sys.seek(first(src), offset), (int)length);

        /// <summary>
        /// Draws a specified count of T-cells from a source span beginning at a specified offset
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="offset">The T-measured offset count</param>
        /// <param name="length"></param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> slice<T>(Span<T> src, ulong offset, ulong length)
            => CreateSpan(ref sys.seek(first(src), offset), (int)length);
   }
}