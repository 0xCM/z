//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct Asci
    {
        [Op]
        public static string format<T>(in AsciLineCover<T> src)
            where T : unmanaged
        {
            Span<char> buffer = stackalloc char[src.RenderLength];
            var i=0u;
            render(recover<T,AsciCode>(src.View), ref i, buffer);
            return sys.@string(buffer);
        }

        public static string format(in AsciLineCover src)
        {
            Span<char> buffer = stackalloc char[src.RenderLength];
            var i=0u;
            render(src.Codes, ref i, buffer);
            return sys.@string(buffer);
        }

        [Op]
        public static string format(ReadOnlySpan<C> src, Span<char> buffer)
            => sys.@string(Spans.slice(buffer,0, decode(src, buffer)));

        [Op]
        public static string format(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var len = src.Length;
            for(var i=0u; i<len; i++)
                seek(dst, i) = (char)skip(src,i);
            return sys.@string(slice(dst,0,len));
        }

        [Op]
        public static string format(AsciSeq seq)
            => format(seq.Codes);

        [Op]
        public static string format(ReadOnlySpan<byte> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            decode(src, dst);
            return new string(dst);
        }

        [Op]
        public static string format(ReadOnlySpan<C> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            decode(src, dst);
            return new string(dst);
        }

        [Op]
        public static string format(ReadOnlySpan<S> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            decode(src, dst);
            return new string(dst);
        }
    }
}