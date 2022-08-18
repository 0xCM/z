//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class RP
    {
        [MethodImpl(Inline), Op]
        public static string substring(string src, int startidx)
            => src?.Substring(startidx) ?? EmptyString;

        [MethodImpl(Inline), Op]
        public static string substring(string src, int startidx, int len)
            => src?.Substring(startidx, len) ?? EmptyString;
    }
}
