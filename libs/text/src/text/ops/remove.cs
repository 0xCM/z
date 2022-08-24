//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class text
    {
        [Op]
        public static string remove(string src, params char[] matches)
        {
            var index = hashset(matches);
            if (!src.ContainsAny(index))
                return src;

            var length = src.Length;
            var dst = span<char>(length);
            var data = span(src);
            var j = 0u;
            for (var i=0; i<length; i++)
            {
                ref readonly var c = ref skip(data,i);
                if (!index.Contains(c))
                    seek(dst,j++) = c;
            }
            return new string(sys.slice(dst,0,j));
        }

        /// <summary>
        /// Removes an identified substring wherever it occurs in the source
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="match">The string to remove</param>
        [MethodImpl(Inline), Op]
        public static string remove(string src, string match)
        {
            if(src == null || match == null)
                return src ?? EmptyString;
            else
                return src.Replace(match, EmptyString);
        }
    }
}