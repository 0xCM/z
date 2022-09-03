//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RpOps
    {
        [MethodImpl(Inline), Op]
        public static string substring(string src, int startidx)
            => src?.Substring(startidx) ?? EmptyString;

        [MethodImpl(Inline), Op]
        public static string substring(string src, int startidx, int len)
            => src?.Substring(startidx, len) ?? EmptyString;

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
