//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static System.Runtime.CompilerServices.Unsafe;
    using static System.Runtime.InteropServices.MemoryMarshal;

    partial struct core
    {
        /// <summary>
        /// Returns a reference to the head of a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T first<T>(Span<T> src)
            => ref GetReference<T>(src);

        /// <summary>
        /// Returns a reference to the head of a readonly span
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T first<T>(ReadOnlySpan<T> src)
            => ref GetReference<T>(src);

        /// <summary>
        /// Returns a readonly reference to the first source cell
        /// </summary>
        /// <param name="src">The source span</param>
        [MethodImpl(Inline), Op]
        public static ref readonly char first(ReadOnlySpan<char> src)
            => ref GetReference(src);

        /// <summary>
        /// Reads the first T-cell from a bytespan
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly T first<T>(ReadOnlySpan<byte> src)
            where T : struct
                => ref @as<byte,T>(first(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T first<T>(Span<byte> src)
            where T : struct
                => ref first(recover<T>(src));

        /// <summary>
        /// Returns a reference to the location of the first element
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T">The element type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ref T first<T>(T[] src)
            => ref seek<T>(src, 0);

        /// <summary>
        /// Presents the span head as a readonly reference to an unsigned 8-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly byte first<T>(W8 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => ref As<T,byte>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an signed 8-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly sbyte first<T>(W8i w, ReadOnlySpan<T> src)
            where T : unmanaged
                => ref As<T,sbyte>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an unsigned 16-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ushort first<T>(W16 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => ref As<T,ushort>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an signed 16-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly short first<T>(W16i w, ReadOnlySpan<T> src)
            where T : unmanaged
                => ref As<T,short>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly uint first<T>(W32 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => ref As<T,uint>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an signed 32-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly int first<T>(W32i w, ReadOnlySpan<T> src)
            where T : unmanaged
                => ref As<T,int>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an unsigned 64-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ulong first<T>(W64 w, ReadOnlySpan<T> src)
            where T : unmanaged
                => ref As<T,ulong>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an signed 64-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly long first<T>(W64i w, ReadOnlySpan<T> src)
            where T : unmanaged
                => ref As<T,long>(ref GetReference(src));


        /// <summary>
        /// Presents the span head as a reference to an unsigned 8-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte first<T>(W8 w, Span<T> src)
            where T : unmanaged
                => ref As<T,byte>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a reference to a signed 8-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte first<T>(W8i w, Span<T> src)
            where T : unmanaged
                => ref As<T,sbyte>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a reference to an unsigned 16-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ushort first<T>(W16 w, Span<T> src)
            where T : unmanaged
                => ref As<T,ushort>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a reference to a signed 16-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref short first<T>(W16i w, Span<T> src)
            where T : unmanaged
                => ref As<T,short>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a reference to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint first<T>(W32 w, Span<T> src)
            where T : unmanaged
                => ref As<T,uint>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a reference to a signed 32-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref int first<T>(W32i w, Span<T> src)
            where T : unmanaged
                => ref As<T,int>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a reference to an unsigned 64-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ulong first<T>(W64 w, Span<T> src)
            where T : unmanaged
                => ref As<T,ulong>(ref GetReference(src));

        /// <summary>
        /// Presents the span head as a reference to a signed 64-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref long first<T>(W64i w, Span<T> src)
            where T : unmanaged
                => ref As<T,long>(ref GetReference(src));
    }
}