//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;


    partial class Algs
    {
        /// <summary>
        /// Transforms a readonly T-cell into an editable T-cell
        /// </summary>
        /// <param name="src">The source cell</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T edit<T>(in T src)
            => ref AsRef(src);

        /// <summary>
        /// Transforms a readonly S-cell into an editable T-cell
        /// </summary>
        /// <param name="src">The source cell</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static ref T edit<S,T>(in S src)
            => ref As<S,T>(ref AsRef(src));

        /// <summary>
        /// Transforms a readonly S-cell into an editable T-cell
        /// </summary>
        /// <param name="src">The source cell</param>
        /// <param name="dst">The target cell</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static ref T edit<S,T>(in S src, ref T dst)
            => ref As<S,T>(ref AsRef(src));

        /// <summary>
        /// Covers the content of a readonly span with an editable span
        /// </summary>
        /// <param name="src">The memory source</param>
        /// <param name="count">The number of source cells to read</param>
        /// <typeparam name="T">The cell type</typeparam>
        /// <returns>Obviously, this trick could be particularly dangerous</returns>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> edit<T>(ReadOnlySpan<T> src)
            => cover(edit(first(src)), src.Length);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T edit<T>(MemoryAddress src)
            where T : struct
                => ref first(cover<T>(src, 1));

        /// <summary>
        /// Presents a readonly view of a memory segment beginning at a specified base covering a specified <typeparamref name='T'/> cell count
        /// </summary>
        /// <param name="src">The base adress</param>
        /// <param name="count">The number of cells to cover</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> edit<T>(MemoryAddress src, uint count)
            where T : struct
                => cover<T>(src.Ref<T>(), count);

        /// <summary>
        /// Covers a memory segment with a span
        /// </summary>
        /// <param name="src">The base address</param>
        /// <param name="size">The segment size, in bytes</param>
        [MethodImpl(Inline), Op]
        public static unsafe Span<byte> edit(MemoryAddress src, ByteSize size)
            => cover<byte>(src, size);

        /// <summary>
        /// Creates memory view of specified size beginning at a specified base + offset
        /// </summary>
        /// <param name="base">The base address</param>
        /// <param name="offset">The offset at which the view begins</param>
        /// <param name="size">The view size</param>
        [MethodImpl(Inline), Op]
        public static Span<byte> edit(MemoryAddress @base, ulong offset, ByteSize size)
            => cover<byte>(@base + offset, size);
    }
}