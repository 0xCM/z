//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        [Op]
        public static string after(string src, char match)
        {
            var i = src.IndexOf(match);
            return i != NotFound ? substring(src, i + 1) : EmptyString;
        }

        [Op]
        public static string after(string src, string match)
        {
            var i = src.IndexOf(match);
            return i != -1 ? substring(src, i + match.Length) : EmptyString;
        }
    }
}