//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Spans
    {
        /// <summary>
        /// Presents the leading source bytes as a <typeparamref name='T'/>-cell reference
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(Closure)]
        public static ref T @as<T>(Span<byte> src)
            where T : unmanaged
                => ref first(recover<T>(src));

        /// <summary>
        /// Presents the leading source bytes as a readonly <typeparamref name='T'/>-cell reference
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Keyword, Closures(Closure)]
        public static ref readonly T @as<T>(ReadOnlySpan<byte> src)
            where T : unmanaged
                => ref first(recover<T>(src));
    }
}