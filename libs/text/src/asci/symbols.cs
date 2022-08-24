//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct AsciSymbols
    {
        [MethodImpl(Inline), Op]
        public static void symbols(in char src, int count, ref AsciSymbol dst)
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = (AsciSymbol)skip(src,i);
        }

        [MethodImpl(Inline), Op]
        public static void symbols(ReadOnlySpan<char> src, Span<AsciSymbol> dst)
        {
            var count = min(src.Length, dst.Length);
            symbols(first(src), count, ref first(dst));
        }

        /// <summary>
        /// Returns the asci symbols corresponding to the asci codes [offset, ..., offset + count] where offset <= (2^7-1) - count
        /// </summary>
        /// <param name="offset">The zero-based offset</param>
        /// <param name="count">Tne number of characters to select</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciSymbol> symbols(sbyte offset, sbyte count)
            => recover<char,AsciSymbol>(chars(offset,count));
    }
}