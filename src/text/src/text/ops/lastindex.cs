//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        /// <summary>
        /// Searches for the last index of a specified character in a string
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The character to match</param>
        [Op]
        public static int lastindex(string src, char match)
        {
            if(empty(src))
                return -1;

            return src.LastIndexOf(match);
        }

        /// <summary>
        /// Searches for the last index of a specified character in a string
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The substring to match</param>
        [Op]
        public static int lastindex(string src, string match)
        {
            if(empty(src) || empty(match))
                return -1;

            return src.LastIndexOf(match);
        }
    }
}