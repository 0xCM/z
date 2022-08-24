//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct AsciSymbols
    {
        /// <summary>
        /// Returns the asci codes [offset, ..., offset + count] where offset <= (2^7-1) - count
        /// </summary>
        /// <param name="offset">The zero-based offset</param>
        /// <param name="count">Tne number of codes to select</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<AsciCode> codes(sbyte offset, sbyte count)
            => recover<AsciCode>(slice(AsciChars.CodeBytes, offset, count));

        [MethodImpl(Inline), Op]
        public static void codes(in char src, int count, ref AsciCode dst)
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = (AsciCode)skip(src,i);
        }

        [MethodImpl(Inline), Op]
        public static void codes(in char src, int count, ref byte dst)
        {
            for(var i=0u; i<count; i++)
                seek(dst,i) = (byte)skip(src,i);
        }

        [MethodImpl(Inline), Op]
        public static void codes(ReadOnlySpan<char> src, Span<AsciCode> dst)
        {
            var count = min(src.Length, dst.Length);
            codes(first(src), count, ref first(dst));
        }

        [MethodImpl(Inline), Op]
        public static void codes(ReadOnlySpan<char> src, Span<byte> dst)
        {
            var count = min(src.Length, dst.Length);
            codes(first(src), count, ref first(dst));
        }
    }
}