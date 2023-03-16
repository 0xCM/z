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
        public static char decode(byte src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static char decode(AsciCode src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static char decode(AsciSymbol src)
            => src;

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<AsciSymbol> src, Span<char> dst)
        {
            var count = (uint)src.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = decode(skip(src,i));
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<AsciCode> src, Span<char> dst)
        {
            var count = (uint)src.Length;
            for(var i=0; i<count; i++)
                seek(dst,i) = decode(skip(src,i));
            return count;
        }

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var count = min(src.Length, dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst,i) = (char)skip(src,i);
            return (uint)count;
        }

    }
}