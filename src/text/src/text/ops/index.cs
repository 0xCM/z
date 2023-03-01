//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [MethodImpl(Inline)]
        public static int index(ReadOnlySpan<char> src, int offset, char match)
            => SQ.index(src,offset,match);

        [MethodImpl(Inline), Op]
        public static int index(ReadOnlySpan<char> src, int offset, ReadOnlySpan<char> match)
            => sys.slice(src, 0, offset).IndexOf(match);

        [MethodImpl(Inline)]
        public static int index(ReadOnlySpan<char> src, char match)
            => SQ.index(src, 0, match);

        [MethodImpl(Inline), Op]
        public static int index(ReadOnlySpan<char> src, char a, char b)
            => src.IndexOfAny(a,b);

        [MethodImpl(Inline), Op]
        public static int index(string src, string match)
            => src.IndexOf(match);
    }
}