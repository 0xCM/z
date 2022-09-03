//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class text
    {
        /// <summary>
        /// Creates a new string by weaving a specified character between each character in the source
        /// </summary>
        /// <param name="src">The source string</param>
        /// <param name="c">The character to intersperse</param>
        [Op]
        public static string intersperse(string src, char c)
        {
            var dst = buffer();
            var input = span(src);
            var count = input.Length;
            for(var i=0u; i< count; i++)
            {
                dst.Append(skip(input,i));
                dst.Append(c);
            }

            return dst.Emit();
        }

        /// <summary>
        /// Creates a new string by weaving a substring between each character in the source
        /// </summary>
        /// <param name="src">The source string</param>
        /// <param name="sep">The value to intersperse</param>
        [Op]
        public static string intersperse(string src, string sep)
        {
            var dst = buffer();
            foreach(var item in src)
            {
                dst.Append(item);
                dst.Append(sep);
            }
            return dst.Emit();
        }

        [Op]
        public static string intersperse(string src, char c, uint frequency)
        {
            var count = src.Length;
            var j=0;
            var dst = buffer();
            for(var i=0; i<count; i++)
            {
                dst.Append(src[i]);
                if(i != 0 && ((i - 1) % frequency ==0))
                    dst.Append(c);
            }
            return dst.Emit();
        }

        /// <summary>
        /// Joins the source strings using a specified separator
        /// </summary>
        /// <param name="src">The fields to delimit</param>
        /// <param name="sep">The delimiter to use</param>
        public static string intersperse(ReadOnlySpan<string> src, char sep)
        {
            var dst = buffer();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                dst.Append(skip(src, i));
                if(i != count - 1)
                    dst.Append(sep);
            }
            return dst.Emit();
        }
    }
}