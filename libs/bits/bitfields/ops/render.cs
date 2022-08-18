//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(Bitfield8 src)
        {
            var buffer = CharBlock16.Null.Data;
            var count = render(src, buffer);
            return slice(buffer, 0, count);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(Bitfield16 src)
        {
            var buffer = CharBlock32.Null.Data;
            var count = render(src, buffer);
            return slice(buffer, 0, count);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(Bitfield32 src)
        {
            var buffer = CharBlock64.Null.Data;
            var count = render(src, buffer);
            return slice(buffer, 0, count);
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> render(Bitfield64 src)
        {
            var buffer = CharBlock128.Null.Data;
            var count = render(src, buffer);
            return slice(buffer, 0, count);
        }

        [MethodImpl(Inline), Op]
        public static uint render(Bitfield8 src, Span<char> dst)
            => BitRender.render4x4(src.Bytes, dst);

        [MethodImpl(Inline), Op]
        public static uint render(Bitfield16 src, Span<char> dst)
            => BitRender.render4x4(src.Bytes, dst);

        [MethodImpl(Inline), Op]
        public static uint render(Bitfield32 src, Span<char> dst)
            => BitRender.render4x4(src.Bytes, dst);

        [MethodImpl(Inline), Op]
        public static uint render(Bitfield64 src, Span<char> dst)
            => BitRender.render4x4(src.Bytes, dst);
    }
}