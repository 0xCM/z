//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class text
    {
        [MethodImpl(Inline), Op]
        public static string lpad(string src, int count, char c)
            => src.PadLeft(count, c);

        [MethodImpl(Inline), Op]
        public static string lpad(string src, uint count, char c)
            => src.PadLeft((int)count, c);

        [Op]
        public static Index<string> lpad(ReadOnlySpan<string> src, int count, char c)
            => map(src, x => lpad(x,count,c));

        [Op]
        public static Index<string> lpad(ReadOnlySpan<string> src, uint count, char c)
            => map(src, x => lpad(x,count,c));
    }
}