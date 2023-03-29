//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct AsciSymbols
    {
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

        [MethodImpl(Inline), Op]
        public static string format(AsciSymbol src)
            => src.Text;
        [Op]
        public static string format(ReadOnlySpan<C> src, Span<char> buffer)
            => sys.@string(sys.slice(buffer,0, AsciSymbols.decode(src, buffer)));

        [Op]
        public static string format(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var len = src.Length;
            for(var i=0u; i<len; i++)
                seek(dst, i) = (char)skip(src,i);
            return sys.@string(slice(dst,0,len));
        }

        [Op]
        public static string format(ReadOnlySpan<byte> src)
        {
            Span<char> dst = stackalloc char[src.Length];
            AsciSymbols.decode(src, dst);
            return new string(dst);
        }

    }
}