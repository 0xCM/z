//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents a <typeparamref name='T'/> reference as an <see cref='sbyte'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte i8<T>(in T src)
            => ref @as<T,sbyte>(src);

        [MethodImpl(Inline)]
        public static ref sbyte int8<T>(in T src)
             => ref i8(src);

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
    }
}