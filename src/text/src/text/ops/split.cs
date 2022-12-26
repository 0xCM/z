//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [Op]
        public static string[] split(string src, char sep, bool clean = true)
            => empty(src) ? sys.empty<string>() : src.Split(sep,  clean ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);

        [Op]
        public static string[] split(string src, string sep, bool clean = true)
            =>  empty(src) ? sys.empty<string>() : src.Split(sep, clean ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
    }
}