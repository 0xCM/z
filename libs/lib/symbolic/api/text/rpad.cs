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
        public static string rpad(string src, int count, char c)
            => src.PadRight(count, c);

        [MethodImpl(Inline), Op]
        public static string rpad(string src, uint count, char c)
            => src.PadRight((int)count, c);

        [Op]
        public static Index<string> rpad(ReadOnlySpan<string> src, int count, char c)
            => map(src, x => rpad(x, count,c));

        [Op]
        public static Index<string> rpad(ReadOnlySpan<string> src, uint count, char c)
            => map(src, x => rpad(x, count,c));
    }
}