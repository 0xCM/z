//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Algs;

    using C = AsciCode;
    using S = AsciSymbol;

    partial struct Hex
    {
        [MethodImpl(Inline), Op]
        public static uint pack(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var j = 0u;
            var count = min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
            {
                ref readonly var b = ref skip(src,i);
                seek(dst,j++) = hexchar(LowerCase, b, 1);
                seek(dst,j++) = hexchar(LowerCase, b, 0);
            }
            return j;
        }

        [MethodImpl(Inline), Op]
        public static uint pack(ReadOnlySpan<byte> src, Span<S> dst)
        {
            var j = 0u;
            var count = min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
            {
                ref readonly var b = ref skip(src,i);
                seek(dst,j++) = hexchar(LowerCase, b, 1);
                seek(dst,j++) = hexchar(LowerCase, b, 0);
            }
            return j;
        }        

        [MethodImpl(Inline), Op]
        public static uint pack(ReadOnlySpan<byte> src, Span<C> dst)
            => pack(src, recover<C,S>(dst));
    }
}