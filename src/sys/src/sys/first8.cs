//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        /// <summary>
        /// Presents the bytespan head as a reference to a <see cref='sbyte'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref sbyte first8i<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,sbyte>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to a <see cref='sbyte'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly sbyte first8i<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,sbyte>(src));                
                
        /// <summary>
        /// Presents the bytespan head as a reference to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref byte first8u<T>(Span<T> src)
            where T : unmanaged
                => ref first(recover<T,byte>(src));

        /// <summary>
        /// Presents the span head as a readonly reference to a <see cref='byte'/>
        /// </summary>
        /// <param name="src">The source span</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly byte first8u<T>(ReadOnlySpan<T> src)
            where T : unmanaged
                => ref first(recover<T,byte>(src));
    }
}