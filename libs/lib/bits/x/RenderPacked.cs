//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static string FormatPacked(this ReadOnlySpan<bit> src)
        {
            var count = src.Length;
            var dst = span<char>(count);
            src.RenderPacked(dst);
            return new string(dst);
        }

        [MethodImpl(Inline), Op]
        public static string FormatPacked(this Span<bit> src)
            => src.ReadOnly().FormatPacked();

        [MethodImpl(Inline), Op]
        public static uint RenderPacked(this ReadOnlySpan<bit> src, Span<char> dst)
        {
            var count = src.Length;
            for(var i=0; i<count;i++)
                seek(dst,i) = skip(src,i).ToChar();
            return (uint)count;
        }

        [MethodImpl(Inline), Op]
        public static uint RenderPacked(this Span<bit> src, Span<char> dst)
            => src.ReadOnly().RenderPacked(dst);
    }
}