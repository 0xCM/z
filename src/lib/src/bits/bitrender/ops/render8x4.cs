//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render8x4(ReadOnlySpan<byte> src, ref uint i, Span<char> dst)
        {
            var i0=i;
            var size = (int)src.Length;
            var length = min(size, dst.Length);
            for(var j=0; j<length; j++)
            {
                render8x4(skip(src, j), ref i, dst);
                if(j != length - 1)
                    i+= separate(i,dst);
            }
            return i-i0;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render8x4(char sep, byte src)
        {
            var storage = CharBlock16.Null;
            var dst = storage.Data;
            var i = 0u;
            seek(dst, i++) = bitchar(src, 7);
            seek(dst, i++) = bitchar(src, 6);
            seek(dst, i++) = bitchar(src, 5);
            seek(dst, i++) = bitchar(src, 4);
            i += separate(i, sep, dst);
            seek(dst, i++) = bitchar(src, 3);
            seek(dst, i++) = bitchar(src, 2);
            seek(dst, i++) = bitchar(src, 1);
            seek(dst, i++) = bitchar(src, 0);
            return slice(dst, 0, i);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render8x4(byte src)
            => render8x4(Chars.Space, src);

        [MethodImpl(Inline), Op]
        public static uint render8x4(char sep, byte src, ref uint i, Span<char> dst)
        {
            var i0=i;
            seek(dst, i++) = bitchar(src, 7);
            seek(dst, i++) = bitchar(src, 6);
            seek(dst, i++) = bitchar(src, 5);
            seek(dst, i++) = bitchar(src, 4);
            i += separate(i, sep, dst);
            seek(dst, i++) = bitchar(src, 3);
            seek(dst, i++) = bitchar(src, 2);
            seek(dst, i++) = bitchar(src, 1);
            seek(dst, i++) = bitchar(src, 0);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render8x4(byte src, ref uint i, Span<char> dst)
            => render8x4(Chars.Space, src, ref i,dst);

        [MethodImpl(Inline), Op]
        public static uint render8x4(char sep, byte src, Span<char> dst)
        {
            var i=0u;
            return render8x4(src, ref i, dst);
        }

        [MethodImpl(Inline), Op]
        public static uint render8x4(byte src, Span<char> dst)
            => render8x4(Chars.Space, src, dst);
    }
}