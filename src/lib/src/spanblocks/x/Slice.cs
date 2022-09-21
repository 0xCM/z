//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XSb
    {
        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock8<T> src, int offset)
            where T : unmanaged
                => src.Storage.Slice(offset);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <param name="length">The cell-relative slice length</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock8<T> src, int offset, int length)
            where T : unmanaged
                => src.Storage.Slice(offset,length);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock16<T> src, int offset)
            where T : unmanaged
                => src.Storage.Slice(offset);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <param name="length">The cell-relative slice length</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock16<T> src, int offset, int length)
            where T : unmanaged
                => src.Storage.Slice(offset,length);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock32<T> src, int offset)
            where T : unmanaged
                => src.Storage.Slice(offset);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <param name="length">The cell-relative slice length</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock32<T> src, int offset, int length)
            where T : unmanaged
                => src.Storage.Slice(offset,length);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock64<T> src, int offset)
            where T : unmanaged
                => src.Storage.Slice(offset);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <param name="length">The cell-relative slice length</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock64<T> src, int offset, int length)
            where T : unmanaged
                => src.Storage.Slice(offset,length);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock128<T> src, int offset)
            where T : unmanaged
                => src.Storage.Slice(offset);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <param name="length">The cell-relative slice length</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock128<T> src, int offset, int length)
            where T : unmanaged
                => src.Storage.Slice(offset,length);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock256<T> src, int offset)
            where T : unmanaged
                => src.Storage.Slice(offset);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <param name="length">The cell-relative slice length</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock256<T> src, int offset, int length)
            where T : unmanaged
                => src.Storage.Slice(offset,length);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <param name="length">The cell-relative slice length</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock256<T> src, uint offset, uint length)
            where T : unmanaged
                => src.Storage.Slice((int)offset, (int)length);

        /// <summary>
        /// Slices a blocked data source at the cellular level
        /// </summary>
        /// <param name="src">The source data</param>
        /// <param name="offset">The cell-relative offset at which to dice</param>
        /// <param name="length">The cell-relative slice length</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> Slice<T>(this in SpanBlock512<T> src, int offset, int length)
            where T : unmanaged
                => src.Storage.Slice(offset,length);
    }
}