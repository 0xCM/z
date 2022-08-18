//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        /// <summary>
        /// Selects the substring prior to the first occurrence of a specified character if it is found in the string; otherwise,
        /// returns the original string
        /// </summary>
        /// <param name="src">The string to search</param>
        /// <param name="match">The marking character</param>
        [Op]
        public static string before(string src, char match)
        {
            var found = -1;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(src[i] == match)
                {
                    found = i;
                    break;
                }
            }
            return found != -1 ? substring(src, 0, found) : src;
        }
    }
}