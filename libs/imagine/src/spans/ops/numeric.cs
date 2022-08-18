//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Spans
    {
        /// <summary>
        /// Presents the bytespan head as a reference to an unsigned 32-bit uinteger
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte u8<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,byte>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an unsigned 32-bit uinteger
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly byte u8<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,byte>(src));

        /// <summary>
        /// Presents the bytespan head as a reference to an unsigned 32-bit uinteger
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ushort u16<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,ushort>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an unsigned 32-bit uinteger
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ushort u16<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,ushort>(src));

        /// <summary>
        /// Presents the bytespan head as a reference to an unsigned 32-bit uinteger
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref uint u32<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,uint>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an unsigned 32-bit uinteger
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly uint u32<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,uint>(src));

        /// <summary>
        /// Presents the bytespan head as a reference to a signed 64-bit uinteger
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref ulong u64<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,ulong>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an signed 64-bit uinteger
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly ulong u64<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,ulong>(src));

        /// <summary>
        /// Presents the bytespan head as a reference to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte i8<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,sbyte>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly sbyte i8<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,sbyte>(src));

        /// <summary>
        /// Presents the bytespan head as a reference to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref short i16<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,short>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly short i16<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,short>(src));

        /// <summary>
        /// Presents the bytespan head as a reference to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref int i32<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,int>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to an unsigned 32-bit integer
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly int i32<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,int>(src));

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