//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Spans
    {
        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, sbyte count)
            => ref sys.add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, short count)
            => ref sys.add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <remarks>
        /// Effects
        /// width[T]=8:  mov rax,[rcx] => movsxd rdx,edx => add rax,rdx
        /// width[T]=16: mov rax,[rcx] => movsxd rdx,edx => lea rax,[rax+rdx*2]
        /// width[T]=32: mov rax,[rcx] => movsxd rdx,edx => lea rax,[rax+rdx*4]
        /// width[T]=64: mov rax,[rcx] => movsxd rdx,edx => lea rax,[rax+rdx*8]
        /// </remarks>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, uint count)
            => ref sys.add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, long count)
            => ref sys.add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, ulong count)
            => ref sys.add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, byte count)
            => ref sys.add(first(src), count);

        /// <summary>
        /// Returns a reference to a T-measured count-identified cell
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="count">The T-measured count count</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T seek<T>(Span<T> src, ushort count)
            => ref sys.add(first(src), count);

        [MethodImpl(Inline)]
        public static ref T seek<S,T>(Span<S> src, int offset = 0)
            where S : unmanaged
            where T : unmanaged
                => ref MemoryMarshal.AsRef<T>(Algs.bytes(src, offset, null));

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
    }
}
