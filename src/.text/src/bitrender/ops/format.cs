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
        public static string format2(byte src)
        {
            var i=0u;
            Span<char> buffer = stackalloc char[2];
            render2(src, ref i, buffer);            
            return text.format(buffer);
        }

        [Op]
        public static string format3(byte src)
        {
            Span<char> buffer = stackalloc char[8];
            var i=0u;
            var count = render3(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format4(byte src)
        {
            Span<char> buffer = stackalloc char[8];
            var i=0u;
            var count = render4(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format5(byte src)
        {
            Span<char> buffer = stackalloc char[8];
            var i=0u;
            var count = render5(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format6(byte src)
        {
            Span<char> buffer = stackalloc char[8];
            var i=0u;
            var count = render6(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format7(byte src)
        {
            Span<char> buffer = stackalloc char[8];
            var i=0u;
            var count = render7(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format8(byte src)
        {
            Span<char> buffer = stackalloc char[8];
            var i=0u;
            var count = render8(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format16(ushort src)
        {
            Span<char> buffer = stackalloc char[16];
            var i=0u;
            var count = render16(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [MethodImpl(Inline), Op]
        public static string format32(uint src)
        {
            Span<char> buffer = stackalloc char[32];
            var i=0u;
            render32(src, ref i, buffer);
            return text.format(buffer);
        }

        [MethodImpl(Inline), Op]
        public static string format64(ulong src)
        {
            Span<char> buffer = stackalloc char[64];
            var i=0u;
            render64(src, ref i, buffer);
            return text.format(buffer);
        }

        [MethodImpl(Inline), Op]
        public static string format(N2 n, byte src)
            => format2(src);

        [MethodImpl(Inline), Op]
        public static string format(N3 n, byte src)
            => format3(src);

        [MethodImpl(Inline), Op]
        public static string format(N4 n, byte src)
            => format4(src);

        [MethodImpl(Inline), Op]
        public static string format(N5 n, byte src)
            => format5(src);

        [MethodImpl(Inline), Op]
        public static string format(N6 n, byte src)
            => format6(src);

        [MethodImpl(Inline), Op]
        public static string format(N7 n, byte src)
            => format7(src);

        [MethodImpl(Inline), Op]
        public static string format(N8 n, byte src)
            => format8(src);

        [MethodImpl(Inline), Op]
        public static string format(N16 n, ushort src)
            => format16(src);

        [MethodImpl(Inline), Op]
        public static string format(N32 n, uint src)
            => format32(src);

        [MethodImpl(Inline), Op]
        public static string format(N64 n, ulong src)
            => format64(src);

        [Op]
        public static string format8x4(byte src)
        {
            Span<char> buffer = stackalloc char[16];
            var i=0u;
            var count = render8x4(src, ref i, buffer);
            return text.format(slice(buffer, 0, count));
        }

        [Op]
        public static string format16x4(ushort src, char sep = Chars.Space)
        {
            Span<char> buffer = stackalloc char[24];
            var i=0u;
            var count = render16x4(sep, src, ref i, buffer);
            return text.format(slice(buffer, 0, count));
        }

        [Op]
        public static string format16x8(ushort src)
        {
            Span<char> buffer = stackalloc char[24];
            var i=0u;
            var count = render16x8(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format20x4(uint src, char sep = Chars.Space)
        {
            Span<char> buffer = stackalloc char[32];
            var i=0u;
            var count = render20x4(sep, src, ref i, buffer);
            return text.format(slice(buffer, 0, count));
        }

        [Op]
        public static string format24x4(uint src, char sep = Chars.Space)
        {
            Span<char> buffer = stackalloc char[32];
            var i=0u;
            var count = render24x4(sep, src, ref i, buffer);
            return text.format(slice(buffer, 0, count));
        }

        [Op]
        public static string format28x4(uint src, char sep = Chars.Space)
        {
            Span<char> buffer = stackalloc char[48];
            var i=0u;
            var count = render28x4(sep, src, ref i, buffer);
            return text.format(slice(buffer, 0, count));
        }

        [Op]
        public static string format32x4(uint src, char sep = Chars.Space)
        {
            Span<char> buffer = stackalloc char[128];
            var i=0u;
            var count = render32x4(sep, src, ref i, buffer);
            return text.format(slice(buffer, 0, count));
        }

        [Op]
        public static string format64x4(ulong src, char sep = Chars.Space)
        {
            Span<char> buffer = stackalloc char[128];
            var i=0u;
            var count = render64x4(sep, src, ref i, buffer);
            return text.format(slice(buffer, 0, count));
        }

        [Op]
        public static string format32x8(uint src)
        {
            Span<char> buffer = stackalloc char[128];
            var i=0u;
            var count = render32x8(src, ref i, buffer);
            return text.format(slice(buffer,0,count));
        }

        [Op]
        public static string format64x8(ulong src)
        {
            Span<char> buffer = stackalloc char[128];
            var i=0u;
            var count = render64x8(Chars.Space, src, ref i, buffer);
            return text.format(slice(buffer, 0, count));
        }

        [MethodImpl(Inline), Op]
        public static uint length(ReadOnlySpan<bit> src, BitFormat options)
        {
            var bitcount = min((uint)options.MaxBitCount,(uint)src.Length);
            var blocked = options.BlockWidth != 0;
            var blocks = (uint)(blocked ? src.Length/options.BlockWidth : 0);
            bitcount += blocks; // space for block separators
            return bitcount;
        }

        public static string format(ReadOnlySpan<bit> src, BitFormat? fmt = null)
        {
            var options = fmt ?? BitFormatter.configure();
            var blocked = options.BlockWidth != 0;
            var blocks = (uint)(blocked ? src.Length/options.BlockWidth : 0);
            var bitcount = length(src,options);

            Span<char> buffer = stackalloc char[(int)bitcount];
            ref var dst = ref first(buffer);
            var digits = 0;
            for(uint i = 0, j=bitcount-1; i<bitcount; i++, j--)
            {
                if(blocked && (digits % options.BlockWidth) == 0)
                    seek(dst, j--) = options.BlockSep;

                seek(dst, j) = skip(src,i).ToChar();
                digits++;
            }

            if(options.TrimLeadingZeros)
                return new string(buffer).TrimStart(bit.Zero);
            else
                return new string(buffer);
        }
    }
}