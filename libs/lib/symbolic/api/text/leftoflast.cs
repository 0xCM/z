//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        /// <summary>
        /// Retrieves the substring that precedes the last occurrence of a marker
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [Op]
        public static string leftoflast(string src, string match)
        {
            if(empty(src) || empty(match))
                return EmptyString;

            var i = src.LastIndexOf(match);
            if (i != -1)
                return src.Substring(0, i);
            else
                return string.Empty;
        }

        /// <summary>
        /// Retrieves the substring that precedes the last occurrence of a marker
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [Op]
        public static string leftoflast(string src, char match)
        {
            if(empty(src))
                return EmptyString;

            var i = src.LastIndexOf(match);
            if (i != -1)
                return src.Substring(0, i);
            else
                return string.Empty;
        }
    }
}