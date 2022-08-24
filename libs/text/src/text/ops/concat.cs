//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    partial class text
    {
        [MethodImpl(Inline), Op]
        public static string concat(params object[] src)
            => string.Concat(src);

        [Op]
        public static string concat(ReadOnlySpan<string> src, char? delimiter)
        {
            var dst = buffer();
            for(var i=0; i<src.Length; i++)
            {
                if(i != 0 && delimiter != null)
                    dst.Append(delimiter.Value);

                dst.Append(skip(src,i));
            }
            return dst.ToString();
        }

        [Op]
        public static string concat(ReadOnlySpan<string> src, string sep)
        {
            var dst = emitter();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(i != 0 && sep != null)
                    dst.Append(sep);

                dst.Append(skip(src,i));
            }
            return dst.Emit();
        }

        /// <summary>
        /// Concatenates a sequence of characters with no intervening delimiter
        /// </summary>
        /// <param name="src">The characters to concatenate</param>
        [MethodImpl(Inline), Op]
        public static string concat(IEnumerable<char> src)
            => string.Concat(src);

        /// <summary>
        /// Concatenates a sequence of strings, padding each to a specified width and interspersed with a specified delimiter
        /// </summary>
        /// <param name="src">The text to join</param>
        /// <param name="widths">The corresponding widths</param>
        /// <param name="delimiter">The delimiter to use</param>
        [Op]
        public static string concat(ReadOnlySpan<string> src, ReadOnlySpan<byte> widths, char delimiter = FieldDelimiter)
        {
            var dst = buffer();
            var count = min(src.Length, widths.Length);
            for(var i=0u; i<count; i++)
            {
                ref readonly var field = ref skip(src,i);
                ref readonly var width = ref skip(widths,i);
                dst.Append(field.PadRight(width));
                if(i != count - 1)
                {
                    dst.Append(delimiter);
                    dst.Append(Chars.Space);
                }
            }
            return dst.ToString();
        }
    }
}