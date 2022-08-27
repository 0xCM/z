//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class text
    {
        [Op, Closures(Closure)]
        public static string join<T>(string sep, IEnumerable<T> src)
            => string.Join(sep, src);

        [Op, Closures(Closure)]
        public static string join<T>(string sep, Index<T> src)
            => string.Join(sep, src.Storage);

        [Op, Closures(Closure)]
        public static string join<T>(string sep, params T[] src)
            => string.Join(sep, src);

        [Op, Closures(Closure)]
        public static string join<T>(char sep, ReadOnlySpan<T> src)
        {
            var dst = emitter();
            var count = src.Length;
            var last = count - 1;
            for(var i=0; i<count; i++)
            {
                dst.Append(Require.notnull(skip(src,i)));
                if(i != last)
                    dst.Append(sep);
            }
            return dst.Emit();
        }

        [Op, Closures(Closure)]
        public static string join<T>(string sep, ReadOnlySpan<T> src)
        {
            var dst = buffer();
            var count = src.Length;
            var last = count - 1;
            for(var i=0; i<count; i++)
            {
                dst.Append(Require.notnull(skip(src,i)));
                if(i != last)
                    dst.Append(sep);
            }
            return dst.Emit();
        }

        [Op, Closures(Closure)]
        public static string join<T>(char sep, params T[] src)
            => string.Join(sep, src);
    }
}