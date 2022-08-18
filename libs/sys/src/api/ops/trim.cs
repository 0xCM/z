//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        [Op]
        public static string trim(string src)
            => sys.empty(src) ? EmptyString : src.Trim();

        [Op]
        public static string trim(string src, char match)
            => sys.empty(src) ? EmptyString : src.Trim(match);

        [Op]
        public static string trim(string src, char[] matches)
            => sys.empty(src) ? EmptyString : src.Trim(matches);
    }
}