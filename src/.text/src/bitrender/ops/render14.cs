//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using C = AsciCode;

    partial struct BitRender
    {
        [MethodImpl(Inline), Op]
        public static uint render14(ushort src, ref uint i, Span<char> dst)
        {
            var i0  = i;
            seek(dst, i++) = bitchar(src, 13);
            seek(dst, i++) = bitchar(src, 12);
            seek(dst, i++) = bitchar(src, 11);
            seek(dst, i++) = bitchar(src, 10);
            seek(dst, i++) = bitchar(src, 9);
            seek(dst, i++) = bitchar(src, 8);
            seek(dst, i++) = bitchar(src, 7);
            seek(dst, i++) = bitchar(src, 6);
            seek(dst, i++) = bitchar(src, 5);
            seek(dst, i++) = bitchar(src, 4);
            seek(dst, i++) = bitchar(src, 3);
            seek(dst, i++) = bitchar(src, 2);
            seek(dst, i++) = bitchar(src, 1);
            seek(dst, i++) = bitchar(src, 0);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render14(ushort src, ref uint i, Span<C> dst, N14 n = default)
            => render(n, src, ref i, dst);
    }
}