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
        [MethodImpl(Inline), Op]
        public static string decode(ReadOnlySpan<byte> src, out string dst)
        {
            Span<char> buffer = stackalloc char[src.Length];
            AsciSymbols.decode(src, buffer);
            dst = sys.@string(buffer);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<C> src, Span<char> dst, bool stopOnNull = true)
        {
            var count = min(src.Length, dst.Length);
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                if(code == 0 && stopOnNull)
                    break;

                seek(dst,i) = (char)code;
                counter++;
            }
            return counter;
        }

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<S> src, Span<char> dst, bool stopOnNull = true)
            => decode(recover<S,C>(src), dst, stopOnNull);

        [MethodImpl(Inline), Op]
        public static uint decode(ReadOnlySpan<byte> src, Span<char> dst, bool stopOnNull = true)
            => decode(recover<byte,C>(src), dst, stopOnNull);

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