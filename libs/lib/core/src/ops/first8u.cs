//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct core
    {
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