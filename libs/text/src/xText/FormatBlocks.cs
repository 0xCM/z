//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XText
    {
        /// <summary>
        /// Formats a span as [c0   c1 ...  cm]  where m = length - 1
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="cellpad">The width of a padded cell, if applicable</param>
        /// <param name="padchar">The character to use for cell padding, if applicable</param>
        /// <typeparam name="T">The element type</typeparam>
        [TextUtility]
        public static string FormatBlocks<T>(this ReadOnlySpan<T> src, uint? cellpad = null, char? padchar = null, bool padright = true)
            where T : unmanaged
        {
            static Func<string,uint,string> PadFunc(bool padright)
                => padright
                ? new Func<string,uint,string>((s,n) => s.PadRight((int)n))
                : new Func<string,uint,string>((s,n) => s.PadLeft((int)n));

            var padlen = cellpad ?? sys.size<T>()*4;
            var filler = padchar ?? ' ';
            var pad = PadFunc(padright);
            var sb = text.build();
            sb.Append(Chars.LBracket);
            for(var i = 0; i< src.Length; i++)
            {
                var fmt = $"{src[i]}";
                if(i != src.Length - 1)
                    sb.Append(pad(fmt, padlen));
                else
                    sb.Append(fmt);

            }
            sb.Append(Chars.RBracket);
            return sb.ToString();
        }

        /// <summary>
        /// Formats a span as [c0   c1 ...  cm]  where m = length - 1
        /// </summary>
        /// <param name="src">The source span</param>
        /// <param name="cellpad">The width of a padded cell, if applicable</param>
        /// <param name="padchar">The character to use for cell padding, if applicable</param>
        /// <typeparam name="T">The element type</typeparam>
        [TextUtility]
        public static string FormatBlocks<T>(this Span<T> src, uint? cellpad = null, char? padchar = null, bool padright = true)
            where T : unmanaged
                => src.ReadOnly().FormatBlocks(cellpad, padchar, padright);
    }
}