//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        static string rightoflast(string src, string match)
        {
            if(sys.empty(src) || sys.empty(match))
                return EmptyString;

            var i = src.LastIndexOf(match);
            if (i != -1)
                return src.Substring(i + match.Length);
            else
                return string.Empty;
        }

        static string rightoflast(string src, char match)
        {
            if(sys.empty(src))
                return EmptyString;

            var i = src.LastIndexOf(match);
            if (i != -1 && i < src.Length - 1)
                return src.Substring(i + 1);
            else
                return EmptyString;
        }

        /// <summary>
        /// Retrieves the substring that follows the last occurrence of a marker
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [TextUtility]
        public static string RightOfLast(this string src, string match)
            => rightoflast(src,match);

        /// <summary>
        /// Retrieves the substring that follows the last occurrence of a marker
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [TextUtility]
        public static string RightOfLast(this string src, char match)
            => rightoflast(src,match);
    }
}