//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;

    partial class sys
    {
        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(in T src, byte count)
            => ref Add(ref edit(in src), (int)count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(in T src, ushort count)
            => ref Add(ref edit(in src), (int)count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(in T src, uint count)
            => ref Add(ref edit(in src), (int)count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(in T src, ulong count)
            => ref Add(ref edit(in src), (int)count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(in T src, long count)
            => ref Add(ref edit(in src), (int)count);


         /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(ReadOnlySpan<T> src, byte count)
            => ref sys.skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(ReadOnlySpan<T> src, ushort count)
            => ref sys.skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(ReadOnlySpan<T> src, uint count)
            => ref sys.skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(ReadOnlySpan<T> src, ulong count)
            => ref sys.skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(ReadOnlySpan<T> src, long count)
            => ref sys.skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(Span<T> src, byte count)
            => ref sys.skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(Span<T> src, ushort count)
            => ref sys.skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(Span<T> src, ulong count)
            => ref sys.skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T skip<T>(Span<T> src, uint count)
            => ref sys.skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of <typeparamref name='T'/> cells and returns a readonly reference to the next cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The number of cells to skip</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(Span<T> src, long count)
            => ref sys.skip(in first(src), count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(T[] src, byte count)
            => ref seek(src, count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(T[] src, ushort count)
            => ref seek(src, count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(T[] src, uint count)
            => ref seek(src, count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(T[] src, long count)
            => ref seek(src, count);

        /// <summary>
        /// Skips a specified number of source elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline)]
        public static ref readonly T skip<T>(T[] src, ulong count)
            => ref seek(src, count);            

        /// <summary>
        /// Skips a specified number of pointer-identified elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static ref readonly T skip<T>(T* pSrc, long count)
            where T : unmanaged
                => ref @ref(pSrc + size<T>()*count);

        /// <summary>
        /// Skips a specified number of pointer-identified elements and returns a readonly reference to the result
        /// </summary>
        /// <param name="pSrc">The source pointer</param>
        /// <param name="count">The number of elements to skip</param>
        /// <typeparam name="T">The source element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static ref readonly T skip<T>(T* pSrc, ulong count)
            where T : unmanaged
                => ref @ref(pSrc + size<T>()*count);            
    }
}