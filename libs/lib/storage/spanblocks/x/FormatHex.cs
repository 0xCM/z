//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XSb
    {
        /// <summary>
        /// The default hex value delimiter
        /// </summary>
        const char HexDelimiter = Chars.Space;

        /// <summary>
        /// Formats blocked content as a sequence of hex values
        /// </summary>
        /// <param name="src">The source block</param>
        /// <param name="sep">The character to use when separating digits</param>
        /// <param name="specifier">Whether to prefix each number with the canonical hex specifier, "0x"</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string FormatHex<T>(this SpanBlock8<T> src, char sep = HexDelimiter, bool specifier = false)
            where T : unmanaged
                => src.Storage.FormatHex(sep, specifier);

        /// <summary>
        /// Formats blocked content as a sequence of hex values
        /// </summary>
        /// <param name="src">The source block</param>
        /// <param name="sep">The character to use when separating digits</param>
        /// <param name="specifier">Whether to prefix each number with the canonical hex specifier, "0x"</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string FormatHex<T>(this SpanBlock16<T> src, char sep = HexDelimiter, bool specifier = false)
            where T : unmanaged
                => src.Storage.FormatHex(sep, specifier);

        /// <summary>
        /// Formats blocked content as a sequence of hex values
        /// </summary>
        /// <param name="src">The source block</param>
        /// <param name="bracket">Whether to enclose the formatted hex within brackets</param>
        /// <param name="sep">The character to use when separating digits</param>
        /// <param name="specifier">Whether to prefix each number with the canonical hex specifier, "0x"</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string FormatHex<T>(this SpanBlock32<T> src, char sep = HexDelimiter, bool specifier = false)
            where T : unmanaged
                => src.Storage.FormatHex(sep, specifier);

        /// <summary>
        /// Formats blocked content as a sequence of hex values
        /// </summary>
        /// <param name="src">The source block</param>
        /// <param name="bracket">Whether to enclose the formatted hex within brackets</param>
        /// <param name="sep">The character to use when separating digits</param>
        /// <param name="specifier">Whether to prefix each number with the canonical hex specifier, "0x"</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string FormatHex<T>(this SpanBlock64<T> src, char sep = HexDelimiter, bool specifier = false)
            where T : unmanaged
                => src.Storage.FormatHex(sep, specifier);

        /// <summary>
        /// Formats blocked content as a sequence of hex values
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="bracket">Whether to enclose the formatted hex within brackets</param>
        /// <param name="sep">The character to use when separating digits</param>
        /// <param name="specifier">Whether to prefix each number with the canonical hex specifier, "0x"</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string FormatHex<T>(this SpanBlock128<T> src, char sep = HexDelimiter, bool specifier = false)
            where T : unmanaged
                => src.Storage.FormatHex(sep, specifier);

        /// <summary>
        /// Formats blocked content as a sequence of hex values
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="bracket">Whether to enclose the formatted hex within brackets</param>
        /// <param name="sep">The character to use when separating digits</param>
        /// <param name="specifier">Whether to prefix each number with the canonical hex specifier, "0x"</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string FormatHex<T>(this SpanBlock256<T> src, char sep = HexDelimiter, bool specifier = false)
            where T : unmanaged
                => src.Storage.FormatHex(sep, specifier);

        /// <summary>
        /// Formats blocked content as a sequence of hex values
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="bracket">Whether to enclose the formatted hex within brackets</param>
        /// <param name="sep">The character to use when separating digits</param>
        /// <param name="specifier">Whether to prefix each number with the canonical hex specifier, "0x"</param>
        /// <typeparam name="T">The primal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static string FormatHex<T>(this SpanBlock512<T> src, char sep = HexDelimiter, bool specifier = false)
            where T : unmanaged
                => src.Storage.FormatHex(sep, specifier);
    }
}