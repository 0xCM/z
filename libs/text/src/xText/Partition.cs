//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XText
    {
        /// <summary>
        /// Partitions a string into parts of a specified maximum width
        /// </summary>
        /// <param name="src">The source string</param>
        /// <param name="maxlen">The maximum length of a partition</param>
        [TextUtility]
        public static IEnumerable<string> Partition(this string src, int maxlen)
        {
            var dst = list<string>();
            src.Partition(maxlen, x => dst.Add(x));
            return dst;
        }

        /// <summary>
        /// Partitions a string into parts of a specified maximum width
        /// </summary>
        /// <param name="src">The source string</param>
        /// <param name="maxlen">The maximum length of a partition</param>
        [TextUtility]
        public static void Partition(this string src, int maxlen, Action<string> dst)
        {
            var count = src.Length;
            var buffer = span<char>(maxlen);
            var chars = span(src);
            for(int i=0, j=0; i<count; i++, j++)
            {
                if(j < maxlen)
                    seek(buffer, j) = skip(chars, i);
                else
                {
                    dst(new string(buffer));

                    buffer = span<char>(maxlen);

                    j = 0;
                    seek(buffer, j) = skip(chars, i);
                }
            }

            var trim = buffer.Trim();
            if(trim.Length != 0)
                dst(new string(trim));
        }
    }
}