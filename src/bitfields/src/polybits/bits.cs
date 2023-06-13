//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class PolyBits
    {
        // [MethodImpl(Inline), Op]
        // public static Span<bit> bits(num2 src, out Span<bit> dst)
        // {
        //     var storage = 0u;
        //     dst = recover<bit>(@bytes(storage));
        //     unpack4x1(src,dst);
        //     dst = slice(dst, 0, num2.Width);
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Span<bit> bits(num3 src, out Span<bit> dst)
        // {
        //     var storage = 0u;
        //     dst = recover<bit>(@bytes(storage));
        //     unpack4x1(src, dst);
        //     dst = slice(dst,0, num3.Width);
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Span<bit> unpack(num4 src, out Span<bit> dst)
        // {
        //     var storage = 0u;
        //     dst = recover<bit>(@bytes(storage));
        //     unpack4x1(src,dst);
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Span<bit> bits(num5 src, out Span<bit> dst)
        // {
        //     var storage = 0ul;
        //     dst = recover<bit>(@bytes(storage));
        //     unpack8x1(src,dst);
        //     dst = slice(dst, 0, num5.Width);
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Span<bit> bits(num6 src, out Span<bit> dst)
        // {
        //     var storage = 0ul;
        //     dst = recover<bit>(@bytes(storage));
        //     unpack8x1(src,dst);
        //     dst = slice(dst, 0, num6.Width);
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Span<bit> bits(num7 src, out Span<bit> dst)
        // {
        //     var storage = 0ul;
        //     dst = recover<bit>(@bytes(storage));
        //     unpack8x1(src,dst);
        //     dst = slice(dst, 0, num7.Width);
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Span<bit> bits(num8 src, out Span<bit> dst)
        // {
        //     var storage = 0ul;
        //     dst = recover<bit>(@bytes(storage));
        //     unpack8x1(src,dst);
        //     return dst;
        // }

        // [MethodImpl(Inline), Op]
        // public static Span<bit> bits(num16 src, out Span<bit> dst)
        // {
        //     var storage = ByteBlock16.Empty;
        //     dst = recover<bit>(storage.Bytes);
        //     unpack16x1(src, dst);
        //     dst = slice(dst, 0, num16.Width);
        //     return dst;
        // }

    }
}