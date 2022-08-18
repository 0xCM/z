//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render8x2(char sep, byte src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            seek(dst, i++) = bitchar(src, 7);
            seek(dst, i++) = bitchar(src, 6);
            i += separate(i, sep, dst);
            seek(dst, i++) = bitchar(src, 5);
            seek(dst, i++) = bitchar(src, 4);
            i += separate(i, sep, dst);
            seek(dst, i++) = bitchar(src, 3);
            seek(dst, i++) = bitchar(src, 2);
            i += separate(i, sep, dst);
            seek(dst, i++) = bitchar(src, 1);
            seek(dst, i++) = bitchar(src, 0);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render8x2(byte src, ref uint i, Span<char> dst)
            => render8x2(Chars.Space, src, ref i, dst);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render8x2(char sep, byte src)
        {
            var dst = CharBlock16.Null.Data;
            var i = 0u;
            var count = render8x2(src, ref i, dst);
            return slice(dst,0,count);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render8x2(byte src)
            => render8x2(Chars.Space, src);
    }
}