//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [MethodImpl(Inline), Op]
        public static string substring(string src, int start)
            => src?.Substring(start) ?? EmptyString;

        [MethodImpl(Inline), Op]
        public static string substring(string src, int start, int len)
            => src?.Substring(start, len) ?? EmptyString;
    }
}