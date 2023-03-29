//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XSb
    {
        /// <summary>
        /// The default item list delimiter
        /// </summary>
        const char ItemDelimiter = Chars.Comma;

        /// <summary>
        /// Formats blocked content
        /// </summary>
        /// <param name="src">The source block sequence</param>
        /// <param name="delimiter">The cell delimiter</param>
        /// <param name="pad">The dell padding</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string Format<T>(this SpanBlock8<T> src, char delimiter = ItemDelimiter, int pad = 0)
            where T : unmanaged
                => src.Storage.FormatList(delimiter, 0, pad, true);

        /// <summary>
        /// Formats blocked content
        /// </summary>
        /// <param name="src">The source block sequence</param>
        /// <param name="delimiter">The cell delimiter</param>
        /// <param name="pad">The dell padding</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string Format<T>(this SpanBlock16<T> src, char delimiter = ItemDelimiter, int pad = 0)
            where T : unmanaged
                => src.Storage.FormatList(delimiter, 0, pad, true);

        /// <summary>
        /// Formats blocked content
        /// </summary>
        /// <param name="src">The source block sequence</param>
        /// <param name="delimiter">The cell delimiter</param>
        /// <param name="pad">The dell padding</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string Format<T>(this SpanBlock32<T> src, char delimiter = ItemDelimiter, int pad = 0)
            where T : unmanaged
                => src.Storage.FormatList(delimiter, 0, pad, true);

        /// <summary>
        /// Formats blocked content
        /// </summary>
        /// <param name="src">The source block sequence</param>
        /// <param name="delimiter">The cell delimiter</param>
        /// <param name="pad">The dell padding</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string Format<T>(this SpanBlock64<T> src, char delimiter = ItemDelimiter, int pad = 0)
            where T : unmanaged
                => src.Storage.FormatList(delimiter, 0, pad, true);

        /// <summary>
        /// Formats blocked content
        /// </summary>
        /// <param name="src">The source block sequence</param>
        /// <param name="delimiter">The cell delimiter</param>
        /// <param name="pad">The dell padding</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string Format<T>(this SpanBlock128<T> src, char delimiter = ItemDelimiter, int pad = 0)
            where T : unmanaged
                => src.Storage.FormatList(delimiter, 0, pad, true);

        /// <summary>
        /// Formats blocked content
        /// </summary>
        /// <param name="src">The source block sequence</param>
        /// <param name="delimiter">The cell delimiter</param>
        /// <param name="pad">The dell padding</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string Format<T>(this SpanBlock256<T> src, char delimiter = ItemDelimiter, int pad = 0)
            where T : unmanaged
                => src.Storage.FormatList(delimiter, 0, pad, true);

        /// <summary>
        /// Formats blocked content
        /// </summary>
        /// <param name="src">The source block sequence</param>
        /// <param name="delimiter">The cell delimiter</param>
        /// <param name="pad">The dell padding</param>
        /// <typeparam name="T">The cell type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string Format<T>(this SpanBlock512<T> src, char delimiter = ItemDelimiter, int pad = 0)
            where T : unmanaged
                => src.Storage.FormatList(delimiter, 0, pad, true);
    }
}