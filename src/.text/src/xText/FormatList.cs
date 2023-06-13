//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [TextUtility, Closures(Closure)]
        public static string FormatList<T>(this ReadOnlySpan<T> src, char sep = Chars.Comma, int offset = 0, int pad = 0, bool bracketed = true)
        {
            var count = src.Length;
            if(count == 0)
                return string.Empty;

            var sb = new StringBuilder();
            for(var i = offset; i<count; i++)
            {
                var item =$"{src[i]}";
                sb.Append(pad != 0 ? item.PadLeft(pad) : item);
                if(i != count - 1)
                {
                    sb.Append(sep);
                    sb.Append(Chars.Space);
                }
            }
            return bracketed ? $"[{sb.ToString()}]" : sb.ToString();
        }

        static ReadOnlySpan<T> RO<T>(Span<T> src)
            => src;

        [TextUtility]
        public static string FormatList<T>(this Span<T> src, char sep = Chars.Comma, int offset = 0, int pad = 0, bool bracketed = true)
            => RO(src).FormatList(sep, offset, pad, bracketed);

        [TextUtility]
        public static string FormatList<T>(this T[] src, char sep = Chars.Comma, int offset = 0, int pad = 0, bool bracketed = true)
            => src.ToSpan().FormatList(sep, offset);

        /// <summary>
        /// Formats a sequence of objects as a delimited list
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="delimiter">The delimiter, if specified; otherwise, a system default is chosen</param>
        /// <typeparam name="T">A formattable type</typeparam>
        [TextUtility]
        public static string FormatList(this IEnumerable<object> items, char sep = Chars.Comma)
            => string.Join(sep, items);
    }
}