//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct NumRender : IRenderRegistrar
    {
        public static IRenderRegistrar Service => new NumRender();

        public void RegisterFomatters()
        {
            TextFormat.RegisterFormatter(Fixed9, RenderStyle.Fixed);
            TextFormat.RegisterFormatter(Fixed8, RenderStyle.Fixed);
            TextFormat.RegisterFormatter(Fixed4, RenderStyle.Fixed);
            TextFormat.RegisterFormatter(Hex8, RenderStyle.Fixed);
            TextFormat.RegisterFormatter(Hex16, RenderStyle.Fixed);
            TextFormat.RegisterFormatter(Hex32, RenderStyle.Fixed);
        }

        public static RenderDelegate<num4> Fixed4 => src => string.Format("{0:D2}", (byte)src);

        public static RenderDelegate<num8> Fixed8 => src => string.Format("{0:D2}", (byte)src);

        public static RenderDelegate<num9> Fixed9 => src => string.Format("{0:D3}", (byte)src);

        public static RenderDelegate<Hex8> Hex8 => src => string.Format("0x{0:X2}", (byte)src);

        public static RenderDelegate<Hex16> Hex16 => src => string.Format("0x{0:X4}", (byte)src);

        public static RenderDelegate<Hex32> Hex32 => src => string.Format("0x{0:X8}", (uint)src);

        [MethodImpl(Inline), Op]
        public static uint render8x8(ReadOnlySpan<num4> src, Span<char> dst, char sep = Chars.Space)
        {
            var k=0u;
            var m=z8;
            seek(dst,k++) = (char)skip(src,m++);
            seek(dst,k++) = (char)skip(src,m++);

            seek(dst,k++) = sep;
            seek(dst,k++) = (char)skip(src,m++);
            seek(dst,k++) = (char)skip(src,m++);

            seek(dst,k++) = sep;
            seek(dst,k++) = (char)skip(src,m++);
            seek(dst,k++) = (char)skip(src,m++);

            seek(dst,k++) = sep;
            seek(dst,k++) = (char)skip(src,m++);
            seek(dst,k++) = (char)skip(src,m++);

            return k;
        }
    }
}