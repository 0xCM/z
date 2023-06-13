//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct SymbolicQuery
    {
        /// <summary>
        /// Searches for the last index of a specified character in a string
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The character to match</param>
        [Op]
        public static int lastindex(ReadOnlySpan<char> src, char match)
        {
            if(src.Length == 0)
                return -1;

            return src.LastIndexOf(match);
        }
    }
}