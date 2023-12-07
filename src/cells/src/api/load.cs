//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class Cells
    {

        /// <summary>
        /// Loads a width-selected cell from a specified source beginning at a specified source-relative offset
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        [MethodImpl(Inline), Op]
        public static ref readonly Cell128 load(W128 w, ReadOnlySpan<byte> src, uint offset = 0)
            => ref sys.first(recover<Cell128>(slice(src, offset)));

        /// <summary>
        /// Loads a width-selected cell from a specified source beginning at a specified source-relative offset
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        [MethodImpl(Inline), Op]
        public static ref readonly Cell256 load(W256 w, ReadOnlySpan<byte> src, uint offset = 0)
            => ref sys.first(recover<Cell256>(slice(src, offset)));

        /// <summary>
        /// Loads a width-selected cell from a specified source beginning at a specified source-relative offset
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        [MethodImpl(Inline), Op]
        public static ref readonly Cell512 load(W512 w, ReadOnlySpan<byte> src, uint offset = 0)
            => ref sys.first(recover<Cell512>(slice(src, offset)));

        /// <summary>
        /// Loads a width-selected cell from a specified source beginning at a specified source-relative offset
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <typeparam name="T">The source cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly Cell128 load<T>(W128 w, ReadOnlySpan<T> src, uint offset = 0)
            where T : unmanaged
                => ref sys.first(recover<T,Cell128>(slice(src, offset)));

        /// <summary>
        /// Loads a width-selected cell from a specified source beginning at a specified source-relative offset
        /// </summary>
        /// <param name="w">The width selector</param>
        /// <param name="src">The data source</param>
        /// <param name="offset">The source offset</param>
        /// <typeparam name="T">The source cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref readonly Cell256 load<T>(W256 w, ReadOnlySpan<T> src, uint offset = 0)
            where T : unmanaged
                => ref sys.first(recover<T,Cell256>(slice(src, offset)));
    }
}