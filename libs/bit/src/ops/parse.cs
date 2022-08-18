//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct bit
    {
        [MethodImpl(Inline), Op]
        public static bit parse(char c)
            => c == One;

        [MethodImpl(Inline), Op]
        public static bit parse(string src)
            => parse(ifempty(src, "0")[0]);
    }
}