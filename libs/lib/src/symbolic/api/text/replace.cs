//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class text
    {
        [Op]
        public static string replace(string src, char a, char b)
            => nonempty(src) ? src.Replace(a,b) : EmptyString;

        [MethodImpl(Inline), Op]
        public static void replace(Span<char> src, char a, char b)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                if(skip(src,i) == a)
                    seek(src,i) = b;
        }

        [Op]
        public static string replace(string src, string match, string repl)
            => nonempty(src) ? src.Replace(match, repl) : EmptyString;

        [Op]
        public static ReadOnlySpan<char> replace(ReadOnlySpan<char> src, char a, char b)
        {
            var count = src.Length;
            var dst = span<char>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                seek(dst,i) = equals(c,a) ? b : c;
            }
            return dst;
        }
    }
}