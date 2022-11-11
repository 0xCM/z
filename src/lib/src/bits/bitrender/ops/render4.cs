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
        public static uint render4(byte src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            seek(dst, i++) = bitchar(src, 3);
            seek(dst, i++) = bitchar(src, 2);
            seek(dst, i++) = bitchar(src, 1);
            seek(dst, i++) = bitchar(src, 0);
            return i - i0;
        }

        [MethodImpl(Inline), Op]
        public static uint render4(byte src, Span<char> dst)
        {
            var i = 0u;
            return render4(src, ref i, dst);
        }

        [MethodImpl(Inline), Op]
        public static asci4 render4(byte src, out asci4 dst)
        {
            dst = new asci4(
                bitchar(src, 3),
                bitchar(src, 2),
                bitchar(src, 1),
                bitchar(src, 0)
            )   ;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static asci8 render4(byte src, out asci8 dst)
        {
            dst = new asci8(
                bitchar(src, 3),
                bitchar(src, 2),
                bitchar(src, 1),
                bitchar(src, 0)
            )   ;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static uint render4(byte src, ref uint i, Span<C> dst, N4 n = default)
            => render(n, src, ref i, dst);
    }
}