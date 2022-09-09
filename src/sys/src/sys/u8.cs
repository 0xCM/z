//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents a T-references as a <see cref='byte'/> reference
        /// </summary>
        /// <param name="src">The source reference</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte u8<T>(in T src)
            => ref @as<T,byte>(src);            

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
    }
}