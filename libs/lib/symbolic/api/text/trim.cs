//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
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

        [Op]
        public static string[] trim(string[] src)
        {
            var count = src.Length;
            var dst = sys.alloc<string>(count);
            for(var i=0; i<count; i++)
                Arrays.seek(dst,i) = trim(Arrays.skip(src,i));
            return dst;
        }

        [Op]
        public static string[] trim(string[] src, char match)
            => src.Select(s => trim(s,match));

        [Op]
        public static string[] trim(string[] src, char[] matches)
            => src.Select(s => trim(s,matches));

        [Op]
        public static ReadOnlySpan<char> trim(ReadOnlySpan<char> src)
            => src.Trim();

        [Op]
        public static ReadOnlySpan<char> trim(ReadOnlySpan<char> src, char match)
            => src.Trim(match);

        [Op]
        public static ReadOnlySpan<char> trim(ReadOnlySpan<char> src, char[] matches)
            => src.Trim(matches);

        [Op]
        public static ReadOnlySpan<char> trim(ReadOnlySpan<char> src, string match)
            => src.Trim(match);
    }
}