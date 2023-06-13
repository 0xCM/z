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
        public static uint render8x3x3x2(byte src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            seek(dst, i++) = bitchar(src, 7);
            seek(dst, i++) = bitchar(src, 6);
            seek(dst, i++) = bitchar(src, 5);
            separate(i++, dst);
            seek(dst, i++) = bitchar(src, 4);
            seek(dst, i++) = bitchar(src, 3);
            seek(dst, i++) = bitchar(src, 2);
            separate(i++, dst);
            seek(dst, i++) = bitchar(src, 1);
            seek(dst, i++) = bitchar(src, 0);
            separate(i++, dst);
            return i-i0;
        }

        [MethodImpl(Inline), Op]
        public static string render8x3x3x2(byte src)
        {
            Span<char> buffer = stackalloc char[16];
            var i=0u;
            var count = render8x3x3x2(src,ref i, buffer);
            return new(slice(buffer,0,count));
        }

        [MethodImpl(Inline), Op]
        public static uint render8x3x3x2(ReadOnlySpan<byte> src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var size = (int)src.Length;
            var length = min(size, dst.Length);
            for(var j=0; j<length; j++)
                render8x3x3x2(skip(src, j), ref i, dst);
            return i - i0;
        }
    }
}